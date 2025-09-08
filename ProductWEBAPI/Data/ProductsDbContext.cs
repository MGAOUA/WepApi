using Microsoft.EntityFrameworkCore;
using ProductWEBAPI.Models;

namespace ProductWEBAPI.Data
{
    public class ProductsDbContext : DbContext
    {
        // Constructor: passes options to the base DbContext
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        // These properties represent your database tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Optional: You can override this method to further configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ... Fluent API configuration goes here
        }
    }
}
