using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomersServiceApp.Pages.Customers
{

    public class ExportCsvModel : PageModel
    {
        private readonly CustomersServiceApp.Data.CustomerContext _context;

        public ExportCsvModel(CustomersServiceApp.Data.CustomerContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            var builder = new StringBuilder();
            builder.AppendLine("id,name,surname,birthyear");
            foreach (var customer in _context.Customers)
            {
                builder.AppendLine($"{customer.id},{customer.name},{customer.surname},{customer.birthyear}");
            }

           return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Customers.csv");
        }
    }
}
