using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace TestRazorApp.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}