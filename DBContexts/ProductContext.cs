using Microsoft.EntityFrameworkCore;
using product_microservices.Model;
namespace product_microservices.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic Items"
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothes",
                    Description = "Clothes Items"
                },
                new Category
                {
                    Id = 3,
                    Name = "Grocery",
                    Description = "Grocery Items"
                }
            ) ;

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)");
        }

    }
}
