namespace TestRazorApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public required string Name { get; set; }
    }
}
