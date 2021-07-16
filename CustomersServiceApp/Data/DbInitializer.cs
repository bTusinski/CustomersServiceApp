using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomersServiceApp.Data;
using CustomersServiceApp.Models;

namespace CustomersServiceApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(CustomerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer{id = 1, name="Carson", surname="Alexander", birthyear=int.Parse("1996")},
                new Customer{id = 2, name="Meredith", surname="Alonso", birthyear=int.Parse("1985")},
                new Customer{id = 3, name="Arturo", surname="Anand", birthyear=int.Parse("1997")},
                new Customer{id = 4, name="Gytis", surname="Barzdukas", birthyear=int.Parse("2001")},
                new Customer{id = 5, name="Yan", surname="Li", birthyear=int.Parse("1995")},

            };

            context.Customers.AddRange(customers);
            context.SaveChanges();

        }
    }
}
