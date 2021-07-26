using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
