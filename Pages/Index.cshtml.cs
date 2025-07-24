using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestRazorApp.Models;

namespace TestRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _context;
        private readonly ILogger<IndexModel> _logger;

        // Property to hold the new Customer's Name received from the query string
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            _logger.Log(LogLevel.Information, "Got to GET async.");
            if((Name != null) && (Name != ""))
            {
                Customer newCustomer = new Customer();
                int maxCustomerID = await _context.Customers.MaxAsync(c => (int?)c.ID) ?? 0;  // Empty table defaults 0
                newCustomer.ID = maxCustomerID + 1;
                newCustomer.Name = Name;
                _context.Add<Customer>(newCustomer);
                _context.SaveChanges();
            }
            else
            {
                _logger.Log(LogLevel.Information, "Regular GET");
            }

            // Get all customers from database
            Customers = _context.Customers.ToList();

            return Page();
        }
    }
}
