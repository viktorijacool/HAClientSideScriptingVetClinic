//using BusinessLogic.ViewModels;
//using Domain.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace BusinessLogic.Services
//{
//    public class FileService
//    {
//        public FileService() { }

//        private TextFileDbRepository txtfr;

//        public FileService(TextFileDbRepository _textFileRepository)
//        {
//            txtfr = _textFileRepository;
//        }

//        public void Create(CreateTextFileViewModel textFile)
//        {

//            if (txtfr.GetFileEntries().Any(f => f.FileName == textFile.FileName))
//                throw new Exception("File with the same name already exists");
//            else
//            {
//                txtfr.Create(new Domain.Models.TextFileModel()
//                {
//                    FileName = textFile.FileName,
//                    UploadedOn = textFile.UploadedOn,
//                    Data = textFile.Data,
//                    Author = textFile.Author,
//                    LastEditedBy = textFile.LastEditedBy,
//                    LastUpdated = textFile.LastUpdated
//                });
//            }

//        }


//        //public void Create(TextFileModel file)
//        //{
//        //    // Calculate the checksum of the file data
//        //    var checksum = CalculateChecksum(file.Data);

//        //    // Set the checksum on the file model
//        //    file.Checksum = checksum;

//        //    // Create the file in the repository
//        //    _textFileRepository.Create(file);
//        //}


//        //public void Share(int fileId, string recipient)
//        //{
//        //    txtfr.Share(fileId, recipient);
//        //}

//        //public void Edit(int fileId, string changes)
//        //{
//        //    // Validate that the user has permission to edit the file
//        //    var file = txtfr.GetFile(fileId);
//        //    if (file.Author != User.Identity.Name && !file.Recipients.Contains(User.Identity.Name))
//        //    {
//        //        throw new UnauthorizedAccessException("You do not have permission to edit this file.");
//        //    }

//        //    // Calculate the checksum of the updated data
//        //    var checksum = CalculateChecksum(changes);

//        //    // Update the file in the repository
//        //    txtfr.Edit(fileId, changes, checksum);
//        //}

//        //public TextFileModel GetFile(int fileId)
//        //{
//        //    return txtfr.GetFile(fileId);
//        //}

//        //public List<TextFileModel> GetPermissions()
//        //{
//        //    return txtfr.GetPermissions();
//        //}

//        //private string CalculateChecksum(string data)
//        //{
//        //    // Calculate the checksum of the data
//        //    // (This is just an example. You should use a more secure hash algorithm in production.)
//        //    return data.GetHashCode().ToString();
//        //}
//    }
//}
