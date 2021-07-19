using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomersServiceApp.Data;
using CustomersServiceApp.Models;

namespace CustomersServiceApp.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly CustomersServiceApp.Data.CustomerContext _context;

        public DetailsModel(CustomersServiceApp.Data.CustomerContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(m => m.id == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
