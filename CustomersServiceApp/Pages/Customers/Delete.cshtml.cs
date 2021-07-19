using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomersServiceApp.Data;
using CustomersServiceApp.Models;
using Microsoft.Extensions.Logging;

namespace CustomersServiceApp.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly CustomersServiceApp.Data.CustomerContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(CustomersServiceApp.Data.CustomerContext context,
                          ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;

        }

        [BindProperty]
        public Customer Customer { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
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

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            // Customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            try
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
