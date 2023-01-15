using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using BusinessLogic.ViewModels;

namespace AsynchronousFileTransferWebsite.Controllers
{
    public class FileController : Controller
    {
        private FileService fileService;

        public FileController(FileService _fileService)
        {
            fileService = _fileService;
        }



        //a method to open the page, then the user starts typing
        public IActionResult Create()
        {
            return View();
        }

        //a method to handle the submission of the form 
        [HttpPost]
        public IActionResult Create(CreateTextFileViewModel data)
        {
            fileService.Create(data);    //to test

            return View();
        }



        //private readonly FileService _fileService;
        //private readonly IWebHostEnvironment _environment;

        //public FileController(FileService fileService, IWebHostEnvironment environment)
        //{
        //    _fileService = fileService;
        //    _environment = environment;
        //}

        //public IActionResult Share(int fileId)
        //{
        //    // Get the list of users who have access to the file
        //    var file = _fileService.GetFile(fileId);
        //    var recipients = file.Recipients;

        //    // Get the list of all users
        //    var allUsers = GetAllUsers();

        //    // Remove the recipients from the list of all users
        //    allUsers.RemoveAll(r => recipients.Contains(r));

        //    // Pass the list of users to the view
        //    ViewBag.Users = allUsers;

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Share(int fileId, string recipient)
        //{
        //    // Share the file with the selected user
        //    _fileService.Share(fileId, recipient);

        //    return RedirectToAction("Index");
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(TextFileModel file, IFormFile data)
        //{
        //    // Save the file data to the Data folder
        //    var filePath = Path.Combine(_environment.WebRootPath, "Data", file.FileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        data.CopyTo(stream);
        //    }

        //    // Set the file data on the model
        //    file.Data = System.IO.File.ReadAllText(filePath);

        //    // Create the file in the repository
        //    _fileService.Create(file);

        //    return RedirectToAction("Index");
        //}

        //public IActionResult Edit(int fileId)
        //{
        //    // Validate that the user has permission to edit the file
        //    var file = _fileService.GetFile(fileId);
        //    if (file.Author != User.Identity.Name && !file.Recipients.Contains(User.Identity.Name))
        //    {
        //        return Unauthorized();
        //    }

        //    return View(file);
        //}

        //[HttpPost]
        //public IActionResult Edit(TextFileModel file)
        //{
        //    // Update the file in the repository
        //    _fileService.Edit(file.FileId, file.Data);

        //    return RedirectToAction("Index");
        //}

        //private List<string> GetAllUsers()
        //{
        //    // Get the list of all users from the database or some other source
        //    // (This is just an example. You would need to implement this method for your application.)
        //    return new List<string> { "user1", "user2", "user3" };
        //}
    }
}
