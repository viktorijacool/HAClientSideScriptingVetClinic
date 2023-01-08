using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class FileService
    {
        private ItemsRepository ir;

        public ItemsServices(ItemsRepository _itemRepository)
        {
            ir = _itemRepository;
        }



        private TextFileDbRepository repository;

        public FileService(TextFileDbRepository _textFileRepository)
        {
            repository = _textFileRepository;
        }

        public void Share(int fileId, string recipient)
        {
            repository.Share(fileId, recipient);
        }

        public void Edit(int fileId, string changes)
        {
            // Validate that the user has permission to edit the file
            var file = repository.GetFile(fileId);
            if (file.Author != User.Identity.Name && !file.Recipients.Contains(User.Identity.Name))
            {
                throw new UnauthorizedAccessException("You do not have permission to edit this file.");
            }

            // Calculate the checksum of the updated data
            var checksum = CalculateChecksum(changes);

            // Update the file in the repository
            repository.Edit(fileId, changes, checksum);
        }

        public void Create(TextFileModel file)
        {
            // Calculate the checksum of the file data
            var checksum = CalculateChecksum(file.Data);

            // Set the checksum on the file model
            file.Checksum = checksum;

            // Create the file in the repository
            _repository.Create(file);
        }

        public TextFileModel GetFile(int fileId)
        {
            return repository.GetFile(fileId);
        }

        public List<TextFileModel> GetPermissions()
        {
            return repository.GetPermissions();
        }

        private string CalculateChecksum(string data)
        {
            // Calculate the checksum of the data
            // (This is just an example. You should use a more secure hash algorithm in production.)
            return data.GetHashCode().ToString();
        }
    }
}
