using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using BusinessLogic.ViewModels;
using System;

namespace AsynchronousFileTransferWebsite.Controllers
{
    public class FileController : Controller
    {
        private FileService fileService;
        private IWebHostEnvironment host;

        public FileController(FileService _fileService, IWebHostEnvironment _host)
        {
            fileService = _fileService;
            host = _host;
        }



        //a method to open the page, then the user starts typing
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //a method to handle the submission of the form 
        [HttpPost]
        public IActionResult Create(CreateTextFileViewModel data, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    //1. change filename
                    string uniqueFilename = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);

                    //2. the absolute path of the folder where the image is going...

                    string absolutePath = host.WebRootPath;

                    //3. saving file
                    using (System.IO.FileStream fsOut = new System.IO.FileStream(absolutePath + "\\Images\\" + uniqueFilename, System.IO.FileMode.CreateNew))
                    {
                        file.CopyTo(fsOut);
                    }

                    ////4. save the path to the image in the database
                    ////http://localhost:xxxx/Images/filename.jpg
                    //data.PhotoPath = "/Images/" + uniqueFilename;
                }

            }
        }



        public IActionResult Share(int fileId)
        {
            // Get the list of users who have access to the file
            var file = _fileService.GetFile(fileId);
            var recipients = file.Recipients;

            // Get the list of all users
            var allUsers = GetAllUsers();

            // Remove the recipients from the list of all users
            allUsers.RemoveAll(r => recipients.Contains(r));

            // Pass the list of users to the view
            ViewBag.Users = allUsers;

            return View();
        }

        [HttpPost]
        public IActionResult Share(int fileId, string recipient)
        {
            // Share the file with the selected user
            _fileService.Share(fileId, recipient);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TextFileModel file, IFormFile data)
        {
            // Save the file data to the Data folder
            var filePath = Path.Combine(_environment.WebRootPath, "Data", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                data.CopyTo(stream);
            }

            // Set the file data on the model
            file.Data = System.IO.File.ReadAllText(filePath);

            // Create the file in the repository
            _fileService.Create(file);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int fileId)
        {
            // Validate that the user has permission to edit the file
            var file = _fileService.GetFile(fileId);
            if (file.Author != User.Identity.Name && !file.Recipients.Contains(User.Identity.Name))
            {
                return Unauthorized();
            }

            return View(file);
        }

        [HttpPost]
        public IActionResult Edit(TextFileModel file)
        {
            // Update the file in the repository
            _fileService.Edit(file.FileId, file.Data);

            return RedirectToAction("Index");
        }

        private List<string> GetAllUsers()
        {
            // Get the list of all users from the database or some other source
            // (This is just an example. You would need to implement this method for your application.)
            return new List<string> { "user1", "user2", "user3" };
        }
    }
}
