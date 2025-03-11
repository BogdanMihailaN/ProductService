using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductService.Infrastructure
{
    public class ProductServiceDbContextFactory : IDesignTimeDbContextFactory<ProductServiceDbContext>
    {
        public ProductServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductServiceDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=ProductServiceDb;TrustServerCertificate=True;Integrated Security=True;");

            return new ProductServiceDbContext(optionsBuilder.Options);
        }
    }
}
