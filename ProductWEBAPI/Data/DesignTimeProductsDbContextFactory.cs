using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductWEBAPI.Data
{
    public class DesignTimeProductsDbContextFactory : IDesignTimeDbContextFactory<ProductsDbContext>
    {
        public ProductsDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // factory class 
            var optionsBuilder = new DbContextOptionsBuilder<ProductsDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString); // or UseNpgsql, UseSqlite, etc.

            return new ProductsDbContext(optionsBuilder.Options);
        }
    }
}
