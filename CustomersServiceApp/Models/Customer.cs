using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomersServiceApp.Models
{
    public class Customer
    {
        [Required]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters.")]
        [Display(Name = "Surname")]
        [Required]
        public string surname { get; set; }

        [Display(Name = "Birth Year")]
        [Required]
        public int birthyear { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return name + ", " + surname;
            }
        }
    }
}
