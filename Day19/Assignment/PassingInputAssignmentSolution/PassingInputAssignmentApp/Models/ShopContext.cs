using Microsoft.EntityFrameworkCore;

namespace PassingInputAssignmentApp.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)   //override onmodel tab
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 101, Name = "Green Peppers", Category = "Food", Price=1, Quantity=20, Pic= "/images/green.png", Description="From Malaysia" }
                );
        }
    }
}
