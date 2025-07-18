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
        public List<Customer> Customers { get; set; }


        public IndexModel(ILogger<IndexModel> logger, AppDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            // Get all customers from the database
            Customers = _context.Customers.ToList();
        }
    }
}
