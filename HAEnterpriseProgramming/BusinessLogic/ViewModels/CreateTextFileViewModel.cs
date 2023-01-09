using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace BusinessLogic.ViewModels
{
    public class CreateTextFileViewModel
    {
        public class CreateItemViewModel
        {
            //Validator
            [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be blank")]
            public string FileName { get; set; }

            [Display(Name = "Uploaded on")]
            public DateTime UploadedOn { get; set; }

            public string Data { get; set; }

            public string Author { get; set; }

            [Display(Name = "Last edited by")]
            public string LastEditedBy { get; set; }

            [Display(Name = "Last updated")]
            public DateTime LastUpdated { get; set; }


        }
    }
}
