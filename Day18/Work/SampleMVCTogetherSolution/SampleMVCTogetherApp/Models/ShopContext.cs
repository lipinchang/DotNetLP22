using Microsoft.EntityFrameworkCore;

namespace SampleMVCTogetherApp.Models
{
    public class ShopContext :DbContext
    {
        public ShopContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }  //table name, creating table
        public DbSet<User> Users { get; set; }  //table name, creating table
        protected override void OnModelCreating(ModelBuilder modelBuilder)   //override onmodel tab
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id=101, Name ="Tim", Age=23},
                new Customer() { Id = 102, Name = "Jim", Age = 22 }
                );
        }
    }
}
