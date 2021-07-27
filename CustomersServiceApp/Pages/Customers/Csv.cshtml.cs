using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CustomersServiceApp.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomersServiceApp.Pages.Customers
{
    public class CsvModel : PageModel
    {

        private readonly CustomersServiceApp.Data.CustomerContext _context;

        private readonly IWebHostEnvironment _environment;

        public CsvModel(CustomersServiceApp.Data.CustomerContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        [BindProperty]
        public IFormFile Upload { get; set; }

        //[BindProperty]
        //public IFormFile Export { get; set; }

        public async Task OnPostAsync()
        {
            if (Upload != null)
            {

                var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                //Create a DataTable.
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id", typeof(int)),
                                    new DataColumn("name", typeof(string)),
                                    new DataColumn("surname",typeof(string)),
                                    new DataColumn("birthyear", typeof(int))});

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(file);

                var list = new List<Customer>();

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;

                        var data = row.Split(',');

                        //data[0] - id
                        //data[1] - name
                        //data[2] - surname
                        //data[3] - year

                        var customer = new Customer();
                        //customer.id = int.Parse(data[0].Trim());
                        customer.birthyear = int.Parse(data[3].Trim());
                        customer.name = data[1].Trim();
                        customer.surname = data[2].Trim();

                        var entry = _context.Add(customer);
                        await _context.SaveChangesAsync();
                        RedirectToPage("./Index");
                    }
                }
            }
        }
        public async Task<IActionResult> Export()
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



