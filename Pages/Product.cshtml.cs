using System.Net;
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
        [BindProperty(SupportsGet = true)] // This attribute binds GET request data
        public int ID { get; set; }

        public required string CustomerName { get; set; }

        public List<Product>? Products;

        public Product getClickedProduct(int productID)
        {
            return Products[productID];
        }

        public async Task<IActionResult> OnGetAsync() // Changed return type to IActionResult for NotFound()
        {
            // --- Fetch Customer Name using Raw SQL ---
            // Note: Use FromSqlRaw with caution. Parameterization is crucial for security.
            // The {0} syntax is used for parameters and is handled by EF Core for safety.
            var customer = await _context.Customers
                                         .FromSqlRaw("SELECT ID, Name FROM Customers WHERE ID = {0}", ID)
                                         .AsNoTracking() // Optional: Prevents tracking if you only need read access
                                         .FirstOrDefaultAsync(); // Materializes the first result or null

            if (customer == null)
            {
                // Handle case where customer is not found
                CustomerName = "Customer Not Found";
                // Optionally, redirect to an error page or the index page
                return NotFound(); // Returns a 404 Not Found result
            }

            CustomerName = customer.Name;

            // --- Fetch Products using Raw SQL ---
            Products = await _context.Products
                                     .FromSqlRaw("SELECT ID, CustomerID, Name FROM Products WHERE CustomerID = {0}", ID)
                                     .AsNoTracking() // Optional: Prevents tracking if you only need read access
                                     .ToListAsync(); // Materializes all results into a list

            // Once the properties are set, the Razor Page will be rendered.
            return Page(); // Returns the current Razor Page
        }
    }
}