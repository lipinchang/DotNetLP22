using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {
             
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)   //override onmodel tab
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 101, Name = "Green Peppers", Age = 33 }
                );
        }
    }
}
