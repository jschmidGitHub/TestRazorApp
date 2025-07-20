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
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public required string CustomerName { get; set; }

        public List<Product>? Products;

        public JsonResult OnGetClickedProduct(int productId)
        {
            var product = _context.Products
                .FromSqlRaw("SELECT ID, CustomerID, Name, Description, Price FROM Products WHERE ID = {0}", productId)
                .AsNoTracking()
                .FirstOrDefault();

            if (product != null)
            {
                return new JsonResult(new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                });
            }
            else
            {
                return new JsonResult(new
                {
                    Name = "Unknown Product",
                    Description = "No product found for this ID.",
                    Price = 0.0
                });
            }
        }

        public async Task<IActionResult> OnGetAsync() // Changed return type to IActionResult for NotFound()
        {
            var customer = await _context.Customers
                                         .FromSqlRaw("SELECT ID, Name FROM Customers WHERE ID = {0}", ID)
                                         .AsNoTracking() // Optional: Prevents tracking if you only need read access
                                         .FirstOrDefaultAsync(); // Materializes the first result or null

            if (customer == null)
            {
                CustomerName = "Customer Not Found";
                return NotFound(); // Returns a 404 Not Found result
            }

            CustomerName = customer.Name;
            Products = await _context.Products
                                     .FromSqlRaw("SELECT ID, CustomerID, Name, Description, Price FROM Products WHERE CustomerID = {0}", ID)
                                     .AsNoTracking()
                                     .ToListAsync(); // Materializes all results into a list

            // Once the properties are set, the Razor Page will be rendered.
            return Page();
        }
    }
}