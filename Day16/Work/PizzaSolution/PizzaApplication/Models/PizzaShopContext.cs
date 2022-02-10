using Microsoft.EntityFrameworkCore;

namespace PizzaApplication.Models
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)    //seeding records
        {
            modelBuilder.Entity<Pizza>().HasData(
            new Pizza()
            {
                Id = 1,
                Name = "ABC",
                IsVeg = true,
                Price = 12.4,
                Pic = "/images/Pizza1.jpg",
                Details = "This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, "
            },
             new Pizza()
             {
                 Id = 2,
                 Name = "BBB",
                 IsVeg = false,
                 Price = 45.7,
                 Pic = "/images/Pizza2.jpg",
                 Details = "This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, "
             }
             );
        }

    }
}
