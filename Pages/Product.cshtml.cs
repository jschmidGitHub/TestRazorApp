using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestRazorApp.Pages
{
    public class ProductModel : PageModel
    {
        // Property to hold the Customer ID received from the query string
        [BindProperty(SupportsGet = true)] // This attribute is essential for binding GET request data
        public int CustomerID { get; set; }

        // Property to hold the product information you'll display
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public void OnGet()
        {
            // The CustomerID will be automatically populated by model binding
            // because of [BindProperty(SupportsGet = true)] and the query parameter name matches.

            // Here, you would typically fetch product data from a database
            // based on the CustomerID. For this example, we'll use a switch statement.
            switch (CustomerID)
            {
                case 0: // Elon Musk
                    ProductName = "SpaceX Starship";
                    ProductDescription = "Reusable spacecraft for deep-space exploration.";
                    break;
                case 1: // Jeff Bezos
                    ProductName = "Blue Origin New Glenn";
                    ProductDescription = "Heavy-lift orbital launch vehicle.";
                    break;
                case 2: // Mark Zuckerberg
                    ProductName = "Meta Quest 3";
                    ProductDescription = "Mixed reality headset for immersive experiences.";
                    break;
                case 3: // Larry Ellison
                    ProductName = "Oracle Autonomous Database";
                    ProductDescription = "Self-driving, self-securing, self-repairing database service.";
                    break;
                default:
                    ProductName = "Unknown Product";
                    ProductDescription = "Please select a valid customer.";
                    break;
            }

            // Once the properties are set, the Razor Page will be rendered.
        }
    }
}