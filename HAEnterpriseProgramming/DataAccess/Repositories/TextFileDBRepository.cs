using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using DataAccess.Context;

public class TextFileDbRepository
{
    private FileSharingContext _context { get; set; }

    public TextFileDbRepository(FileSharingContext context)
    {
        _context = context;
    }

    public void Share(int fileId, string recipient)
    {
        // Retrieve the file from the database
        var file = _context.TextFiles.Find(fileId);

        // Give the recipient access to the file
        file.Recipients.Add(recipient);

        // Save changes to the database
        _context.SaveChanges();
    }

    public void Edit(int fileId, string changes)
    {
        // Retrieve the file from the database
        var file = _context.TextFiles.Find(fileId);

        // Update the file content and metadata
        file.Data = changes;
        file.LastUpdated = DateTime.Now;
        file.LastEditedBy = recipient;

        // Save changes to the database
        _context.SaveChanges();
    }

    public void Create(TextFileModel f)
    {
        // Add the new file to the database
        _context.TextFiles.Add(f);

        // Save changes to the database
        _context.SaveChanges();
    }

    public List<TextFileModel> GetPermissions()
    {
        // Retrieve a list of files that the current user has access to
        return _context.TextFiles.Where(f => f.Recipients.Contains(User.Identity.Name)).ToList();
    }

    public List<TextFileModel> GetFileEntries()
    {
        // Retrieve a list of all files in the database
        return _context.TextFiles.ToList();
    }
}
