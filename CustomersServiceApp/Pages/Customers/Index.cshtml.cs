using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomersServiceApp.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;


namespace CustomersServiceApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomersServiceApp.Data.CustomerContext _context;
        private readonly MvcOptions _mvcOptions;
        private readonly IConfiguration Configuration;

        public IndexModel(CustomersServiceApp.Data.CustomerContext context, IOptions<MvcOptions> mvcOptions, IConfiguration configuration)
        {
            _context = context;
            _mvcOptions = mvcOptions.Value;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string BirthYearSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Customer> CustomerList { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            BirthYearSort = sortOrder == "BirthYear" ? "birthYear_desc" : "BirthYear";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Customer> customersIQ = from s in _context.Customers
                                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                customersIQ = customersIQ.Where(s => s.surname.Contains(searchString)
                                       || s.name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customersIQ = customersIQ.OrderByDescending(s => s.name);
                    break;
                case "BirthYear":
                    customersIQ = customersIQ.OrderBy(s => s.birthyear);
                    break;
                case "birthYear_desc":
                    customersIQ = customersIQ.OrderByDescending(s => s.birthyear);
                    break;
                default:
                    customersIQ = customersIQ.OrderBy(s => s.surname);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            CustomerList = await PaginatedList<Customer>.CreateAsync(
            customersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }


    }
}

