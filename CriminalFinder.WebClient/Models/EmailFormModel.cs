using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriminalFinder.WebClient.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        public List<HttpPostedFileBase> Uploads { get; set; }
    }
}