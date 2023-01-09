using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class TextFileModel
    {
        //– FileName(Guid), UploadedOn, Data, Author, LastEditedBy, LastUpdated
        [Key]
        public int Id { get; set; }

        public Guid FileName { get; set; }
        public DateTime UploadedOn { get; set; }
        public string Data { get; set; }
        public string Author { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastUpdated { get; set; }

    }


}
