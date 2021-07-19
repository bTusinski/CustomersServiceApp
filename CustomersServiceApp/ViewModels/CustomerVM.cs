using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersServiceApp.ViewModels
{
    public class CustomerVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int birthyear { get; set; }
    }
}
