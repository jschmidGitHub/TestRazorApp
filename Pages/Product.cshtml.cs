using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestRazorApp.Pages
{
    public class ProductModel : PageModel
    {
        // Property to hold the Customer ID received from the query string
        [BindProperty(SupportsGet = true)] // This attribute is essential for binding GET request data
        public int CustomerID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CustomerName { get; set; }

        // Property to hold the product information you'll display
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        

        public void OnGet()
        {
            // The CustomerID will be automatically populated by model binding
            // because of [BindProperty(SupportsGet = true)] and the query parameter name matches.

            switch (CustomerID)
            {
                case 0:
                    ProductName = "SpaceX Starship";
                    ProductDescription = "Reusable spacecraft for deep-space exploration.";
                    CustomerName = "Elon Musk";
                    break;
                case 1: 
                    ProductName = "Blue Origin New Glenn";
                    ProductDescription = "Heavy-lift orbital launch vehicle.";
                    CustomerName = "Jeff Bezos";
                    break;
                case 2:
                    ProductName = "Meta Quest 3";
                    ProductDescription = "Mixed reality headset for immersive experiences.";
                    CustomerName = "Mark Zuckerberg";
                    break;
                case 3:
                    ProductName = "Oracle Autonomous Database";
                    ProductDescription = "Self-driving, self-securing, self-repairing database service.";
                    CustomerName = "Larry Ellison";
                    break;
                default:
                    ProductName = "Unknown Product";
                    ProductDescription = "Please select a valid customer.";
                    CustomerName = "None";
                    break;
            }

            // Once the properties are set, the Razor Page will be rendered.
        }
    }
}