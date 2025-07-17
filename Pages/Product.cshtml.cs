using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestRazorApp.Models;

namespace TestRazorApp.Pages
{
    public class ProductModel : PageModel
    {

        private readonly AppDBContext _context;

        public ProductModel(AppDBContext context)
        {
            _context = context;
        }

        // Property to hold the Customer ID received from the query string
        [BindProperty(SupportsGet = true)] // This attribute is essential for binding GET request data
        public int ID { get; set; }

        public required string Name { get; set; }

        public required string Product { get; set; }
        

        public void OnGet()
        {
            // The ID will be automatically populated by model binding
            // because of [BindProperty(SupportsGet = true)] and the query parameter name matches.

            // Query the database to get the selected customer
            var customer = _context.Customers.FromSqlRaw("SELECT * FROM Customers WHERE ID = {0}", ID)
                                                .AsEnumerable()
                                                .SingleOrDefault();

            if (customer != null)
            {
                Name = customer.Name;
                Product = customer.Product;
            }
            else
            {
                Name = "Unknown Product";
                Product = "Please select a valid customer.";
            }

            // Once the properties are set, the Razor Page will be rendered.
        }
    }
}