using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDALEFLibrary
{
    internal class PizzaContext : DbContext
    {
        public PizzaContext() : base("conn")
        {

        }
        public virtual  DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartPizzas> CartPizzas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartPizzas>().HasKey(cp => new { cp.PizzaId, cp.CartNumber});
        }
    }
}
