namespace TestRazorApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        //public required string Price { get; set; }
    }
}
