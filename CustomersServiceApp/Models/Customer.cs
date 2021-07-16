using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersServiceApp.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int birthyear { get; set; }
    }
}
