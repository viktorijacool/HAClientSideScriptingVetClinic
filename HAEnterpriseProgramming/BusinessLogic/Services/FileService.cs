using BusinessLogic.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class FileService
    {
        private TextFileDbRepository txtfr;

        public FileService(TextFileDbRepository _textFileFepository)
        {
            txtfr = _textFileFepository;
        }

        public void Create(CreateTextFileViewModel textFile)
        {

            if (txtfr.GetFileEntries().Any(f => f.FileName == textFile.FileName))
                throw new Exception("File with the same name already exists");
            else
            {
                txtfr.Create(new Domain.Models.TextFileModel()
                {
                    FileName = textFile.FileName,
                    UploadedOn = textFile.UploadedOn,
                    Data = textFile.Data,
                    Author = textFile.Author,
                    LastEditedBy = textFile.LastEditedBy,
                    LastUpdated = textFile.LastUpdated
                });
            }

        }

        public TextFileViewModel GetFile(int id)
        {
            return GetFiles().SingleOrDefault(x => x.Id == id);
        }


        public void Create(TextFileModel file)
        {
            // calculate the checksum of the file data
            var checksum = CalculateChecksum(file.data);

            // set the checksum on the file model
            file.checksum = checksum;

            // create the file in the repository
            _textFileFepository.create(file);
        }

        public IQueryable<TextFileViewModel> GetFiles()
        {
            var list = from f in txtfr.GetFileEntries()
                       select new TextFileViewModel()
                       {
                           FileName = f.FileName,
                           UploadedOn = f.UploadedOn,
                           Data = f.Data,
                           Author = f.Author,
                           LastEditedBy = f.LastEditedBy,
                           LastUpdated = f.LastUpdated
                       };
            return list;
        }

        public TextFileViewModel GetFiles(int id)
        {
            return GetFiles().SingleOrDefault(x => x.Id == id);
        }



        public IQueryable<TextFileViewModel> Search(string keyword)
        {
            return GetFiles().Where(x => x.FileName.Contains(keyword));
        }


        public void Share(int fileId, string recipient)
        {
            txtfr.Share(fileId, recipient);
        }

        public void Edit(int fileId, string changes)
        {
            // validate that the user has permission to edit the file
            var file = txtfr.GetFile(fileId);
            if (file.Author != User.Identity.Name && !file.recipients.contains(User.Identity.Name))
            {
                throw new UnauthorizedAccessException("You do not have permission to edit this file.");
            }

            // calculate the checksum of the updated data
            var checksum = CalculateChecksum(changes);

            // update the file in the repository
            txtfr.Edit(fileId, changes, checksum);
        }

        public TextFileModel GetFile(int fileId)
        {
            return txtfr.GetFile(fileId);
        }

        public List<TextFileModel> GetPermissions()
        {
            return txtfr.GetPermissions();
        }

        private string CalculateChecksum(string data)
        {
            // calculate the checksum of the data
            // (this is just an example. you should use a more secure hash algorithm in production.)
            return data.GetHashCode().ToString();
        }
    }
}

