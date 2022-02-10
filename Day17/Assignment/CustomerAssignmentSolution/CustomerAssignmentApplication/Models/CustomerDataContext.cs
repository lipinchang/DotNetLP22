using Microsoft.EntityFrameworkCore;

namespace CustomerAssignmentApplication.Models
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)   //seeding records
        {
            modelBuilder.Entity<Customer>().HasData(
            new Customer()
            {
                Id = 1,
                Username = "LPC",
                Password = "P@ssw0rd",
                Email = "lp@gmail.com",
                Phone = 87654321,
                CustomerName = "LP",
                DOB = Convert.ToDateTime("20/08/1999"),
                Age = 23,
                Gender = "Female"
            }
            );
        }


    }
}
