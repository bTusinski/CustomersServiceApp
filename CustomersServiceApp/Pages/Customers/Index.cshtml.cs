using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomersServiceApp.Data;
using CustomersServiceApp.Models;
using Microsoft.Extensions.Options;

namespace CustomersServiceApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomersServiceApp.Data.CustomerContext _context;
        private readonly MvcOptions _mvcOptions;

        public IndexModel(CustomersServiceApp.Data.CustomerContext context, IOptions<MvcOptions> mvcOptions)
        {
            _context = context;
            _mvcOptions = mvcOptions.Value;
        }

        public IList<Customer> CustomerList { get;set; }

        public async Task OnGetAsync()
        {
            CustomerList = await _context.Customers.ToListAsync();
            //Customer customer  = new Customer { Id = 1, Name = "Carson", Surname = "Alexander", BirthYear = int.Parse("1996") };
           // CustomerList = new List<Customer>() { customer };
            // Customer = await _context.Customers.Take(_mvcOptions.MaxModelBindingCollectionSize).ToListAsync();
        }
    }
}
