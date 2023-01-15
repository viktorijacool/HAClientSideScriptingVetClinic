using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.ViewModels
{
    public class TextFileViewModel
    {
        public int Id { get; set; }

        public Guid FileName { get; set; }

        public DateTime UploadedOn { get; set; }

        public string Data { get; set; }

        public string Author { get; set; }

        public string LastEditedBy { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
