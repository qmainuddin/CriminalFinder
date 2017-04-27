using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriminalFinder.WebClient.Models
{
    public class CriminalModal
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public String Gender { get; set; }


        [Required(ErrorMessage = "Enter Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter Height")]
        public float Height { get; set; }

        [Required(ErrorMessage = "Enter Weight")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Enter Your Nationality")]
        public String Nationality { get; set; }
    }
}