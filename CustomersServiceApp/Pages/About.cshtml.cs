using CustomersServiceApp.ViewModels;
using CustomersServiceApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CustomersServiceApp.Pages
{
    public class AboutModel : PageModel
    {
        private readonly CustomerContext _context;

        public AboutModel(CustomerContext context)
        {
            _context = context;
        }

        public IList<BirthYearGroup> Customers { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<BirthYearGroup> data =
                from customer in _context.Customers
                group customer by customer.birthyear into dateGroup
                select new BirthYearGroup()
                {
                    birthyear = dateGroup.Key,
                    CustomerCount = dateGroup.Count()
                };

            Customers = await data.AsNoTracking().ToListAsync();
        }
    }
}