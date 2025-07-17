using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestRazorApp.Pages
{
    public class ProductModel : PageModel
    {
        // Property to hold the Customer ID received from the query string
        [BindProperty(SupportsGet = true)] // This attribute is essential for binding GET request data
        public int ID { get; set; }

        public required string Name { get; set; }

        public required string Product { get; set; }
        

        public void OnGet()
        {
            // The ID will be automatically populated by model binding
            // because of [BindProperty(SupportsGet = true)] and the query parameter name matches.

            switch (ID)
            {
                case 0:
                    Name = "SpaceX Starship";
                    Product = "Reusable spacecraft for deep-space exploration.";
                    Name = "Elon Musk";
                    break;
                case 1: 
                    Name = "Blue Origin New Glenn";
                    Product = "Heavy-lift orbital launch vehicle.";
                    Name = "Jeff Bezos";
                    break;
                case 2:
                    Name = "Meta Quest 3";
                    Product = "Mixed reality headset for immersive experiences.";
                    Name = "Mark Zuckerberg";
                    break;
                case 3:
                    Name = "Oracle Autonomous Database";
                    Product = "Self-driving, self-securing, self-repairing database service.";
                    Name = "Larry Ellison";
                    break;
                default:
                    Name = "Unknown Product";
                    Product = "Please select a valid customer.";
                    Name = "None";
                    break;
            }

            // Once the properties are set, the Razor Page will be rendered.
        }
    }
}