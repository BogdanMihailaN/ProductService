using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure
{
    public class ProductServiceDbContext : DbContext
    {
        public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurare relații și alte setări

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductSpecification>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.Specifications)
                .HasForeignKey(ps => ps.ProductId);

            // Seed pentru Categorii
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    Id = 1,
                    Name = "Electronics"
                },
                new ProductCategory
                {
                    Id = 2,
                    Name = "Home Appliances"
                }
            );

            // Seed pentru Produse
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Smartphone XYZ",
                    Description = "Un smartphone performant cu camera de 108 MP.",
                    Price = 1500.00m,
                    Discount = 10,
                    CreatedAt = new DateTime(2025, 3, 7),
                    UpdatedAt = new DateTime(2025, 3, 7),
                    CategoryId = 1 // Aici vom pune ID-ul corect al categoriei
                },
                new Product
                {
                    Id = 2,
                    Name = "Frigider ABC",
                    Description = "Frigider cu consum redus de energie.",
                    Price = 2500.00m,
                    Discount = 15,
                    CreatedAt = new DateTime(2025, 3, 7),
                    UpdatedAt = new DateTime(2025, 3, 7),
                    CategoryId = 2 // Aici vom pune ID-ul corect al categoriei
                }
            );

            // Seed pentru Imagini Produse
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    Id = 1,
                    Url = "https://example.com/smartphone.jpg",
                    IsPrimary = true,
                    ProductId = 1 // Aici vom pune ID-ul corect al produsului
                },
                new ProductImage
                {
                    Id = 2,
                    Url = "https://example.com/fridge.jpg",
                    IsPrimary = true,
                    ProductId = 2 // Aici vom pune ID-ul corect al produsului
                }
            );

            // Seed pentru Specificații Produse
            modelBuilder.Entity<ProductSpecification>().HasData(
                new ProductSpecification
                {
                    Id = 1,
                    Key = "Capacitate",
                    Value = "500GB",
                    ProductId = 1 // Aici vom pune ID-ul corect al produsului
                },
                new ProductSpecification
                {
                    Id = 2,
                    Key = "Culoare",
                    Value = "Negru",
                    ProductId = 2 // Aici vom pune ID-ul corect al produsului
                }
            );
        }
    }
}
