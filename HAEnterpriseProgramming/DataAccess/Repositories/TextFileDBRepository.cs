﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using DataAccess.Context;
using System.Linq;

public class TextFileDbRepository
{
    private FileSharingContext context { get; set; }

    public TextFileDbRepository(FileSharingContext _context)
    {
        context = _context;
    }
    public IQueryable<TextFileModel> GetFileEntries()
    {
        // Retrieve a list of all files in the database
        return context.TextFiles;
    }

    public void Create(TextFileModel f)
    {
        // Add the new file to the database
        context.TextFiles.Add(f);

        // Save changes to the database
        context.SaveChanges();
    }

    public void Share(int fileId, string recipient)
    {
        // Retrieve the file from the database
        var file = context.TextFiles.Find(fileId);

        // Give the recipient access to the file
        file.Recipients.Add(recipient);

        // Save changes to the database
        context.SaveChanges();
    }

    public void Edit(TextFileModel updatedFile)
    {
        // Retrieve the file from the database
        var originalFile = GetFileEntries(updatedFile.Id);

        // Update the file content
        originalFile.FileName = updatedFile.FileName;
        originalFile.Author = updatedFile.Author;
        originalFile.Data = updatedFile;
        originalFile.LastUpdated = updatedFile;
        originalFile.LastEditedBy = updatedFile;

        // Save changes to the database
        context.SaveChanges();
    }

    public void Edit(int fileId, string changes)
    {
        // Retrieve the file from the database
        var originalFile = context.TextFiles.Find(fileId);

        // Update the file content and metadata
        originalFile.Data = changes;
        originalFile.LastUpdated = DateTime.Now;
        originalFile.LastEditedBy = recipient;

        // Save changes to the database
        context.SaveChanges();
    }

    public List<TextFileModel> GetPermissions()
    {
        // Retrieve a list of files that the current user has access to
        return context.TextFiles.Where(f => f.Recipients.Contains(User.Identity.Name)).ToList();
    }

    public List<TextFileModel> GetFileEntries()
    {
        // Retrieve a list of all files in the database
        return _context.TextFiles.ToList();
    }



    //public void Share(int fileId, string recipient)
    //{
    //    // Retrieve the file from the database using the fileId
    //    // Add the recipient to the list of users who have access to the file
    //    // Update the database with the new list of users
    //}
    //public void Edit(int fileId, string changes)
    //{
    //    // Retrieve the file from the database using the fileId
    //    // Update the file content with the new changes
    //    // Update the LastUpdated and LastEditedBy fields
    //    // Update the database with the new file information
    //}
    //public void Create(TextFileModel f)
    //{
    //    // Read the content of the file
    //    // Insert the file information and content into the database
    //}
    //public void GetPermissions(int fileId)
    //{
    //    // Retrieve the permissions set for the specified file using the fileId
    //    // Return the permissions
    //}
    //public void GetFileEntries()
    //{
    //    // Retrieve all file entries from the database
    //    // Return the list of file entries
    //}

}
