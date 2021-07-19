using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomersServiceApp.ViewModels
{
    public class BirthYearGroup
    {
        public int birthyear { get; set; }
        public int CustomerCount { get; set; }
    }

}

