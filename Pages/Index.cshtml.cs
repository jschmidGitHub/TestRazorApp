using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestRazorApp.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _context;
        private readonly ILogger<IndexModel> _logger;

        // Property to hold the new Customer's Name received from the query string
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ShouldDelete { get; set; }
        public List<Customer> Customers { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDBContext context)
        {
            _context = context;
            _logger = logger;
            Customers = new List<Customer>();
            Name = new string(' ', 0);
            ID = new string(' ', 0);
            ShouldDelete = new string(' ', 0);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            _logger.Log(LogLevel.Warning, "Get: name: " + Name + " shouldDelete: " + ShouldDelete);
            if ((Name != null) && (Name != ""))
            {
                if (ShouldDelete == "true") // delete selected Customer
                {
                    int id = int.Parse(ID);
                    var customer = await _context.Customers.FindAsync(id);
                    if (customer == null)
                    {
                        return NotFound();
                    }
                    
                    _context.Customers.Remove(customer);
                    await _context.SaveChangesAsync();
                }
                else // Add new Customer at next index
                {
                    Customer newCustomer = new Customer();
                    int maxCustomerID = await _context.Customers.MaxAsync(c => (int?)c.ID) ?? 0;  // Empty table defaults 0
                    newCustomer.ID = maxCustomerID + 1;
                    newCustomer.Name = Name;
                    _context.Add<Customer>(newCustomer);
                    _context.SaveChanges();
                }
            }

            // Get all customers from database
            Customers = _context.Customers.ToList();

            return Page();
        }
    }
}
