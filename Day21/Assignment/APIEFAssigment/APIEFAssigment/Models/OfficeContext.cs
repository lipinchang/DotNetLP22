using Microsoft.EntityFrameworkCore;

namespace APIEFAssigment.Models
{
    public class OfficeContext : DbContext
    {
        public OfficeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)   //override onmodel tab
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 101, Name = "Peppers", Age = 23 }
                );
        }
    }
}
