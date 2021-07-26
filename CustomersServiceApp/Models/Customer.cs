using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace CustomersServiceApp.Models
{
    public class Customer
    {
        [Name(Constants.CsvHeaders.id)]
        [Index (0)]
        [Required]
        public int id { get; set; }

        [Name(Constants.CsvHeaders.name)]
        [Index (1)]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Name(Constants.CsvHeaders.surname)]
        [Index(2)]
        [StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters.")]
        [Display(Name = "Surname")]
        [Required]
        public string surname { get; set; }

        [Name(Constants.CsvHeaders.birthyear)]
        [Index(3)]
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
