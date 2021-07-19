using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomersServiceApp.Data;
using CustomersServiceApp.Models;
using CustomersServiceApp.ViewModels;

namespace CustomersServiceApp.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly CustomersServiceApp.Data.CustomerContext _context;

        public CreateModel(CustomersServiceApp.Data.CustomerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        /* [BindProperty]
         public Customer Customer { get; set; }

         // To protect from overposting attacks, enable the specific properties you want to bind to, for
         // more details, see https://aka.ms/RazorPagesCRUD.
         public async Task<IActionResult> OnPostAsync()
         {

             var emptyCustomer = new Customer();

             if (!ModelState.IsValid)
             {
                 if (await TryUpdateModelAsync<Customer>(
                 emptyCustomer,
                 "customer",   // Prefix for form value.
                 s => s.name, s => s.surname, s => s.birthyear))
                 {
                     _context.Customers.Add(emptyCustomer);
                     await _context.SaveChangesAsync();
                     return RedirectToPage("./Index");
                 }
                 return Page();
             }

             _context.Customers.Add(Customer);
             await _context.SaveChangesAsync();

             return RedirectToPage("./Index");
         } */

        [BindProperty]
        public CustomerVM CustomerVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Customer());
            entry.CurrentValues.SetValues(CustomerVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
