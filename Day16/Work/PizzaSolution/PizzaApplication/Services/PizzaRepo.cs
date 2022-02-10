using PizzaApplication.Models;

namespace PizzaApplication.Services
{
    public class PizzaRepo : IRepo<int, Pizza>
    {
        static List<Pizza> Pizzas = new List<Pizza>()     //static so list will be common
        {
            new Pizza()
            {
                Id = 1,
                Name ="ABC",
                IsVeg = true,
                Price = 12.4,
                Pic = "/images/Pizza1.jpg",
                Details="This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, "
            },
             new Pizza()
            {
                Id = 2,
                Name ="BBB",
                IsVeg = false,
                Price = 45.7,
                Pic = "/images/Pizza2.jpg",
                Details="This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, "
            }
        };

        public bool Add(Pizza t)
        {
            Pizzas.Add(t);
            return true;
        }

        public bool Delete(int k)
        {
            try
            {
                Pizzas.Remove(Pizzas.Find(p => p.Id == k));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public ICollection<Pizza> GetAll()
        {
           return Pizzas;
        }

        public Pizza GetT(int k)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == k);
            return pizza;
        }

        public bool Update(int k, Pizza t)
        {
            var MyPizza = Pizzas.FirstOrDefault(p => p.Id == k);
            if (MyPizza != null)
            {
                MyPizza.Name = t.Name;
                MyPizza.Price = t.Price;
                MyPizza.IsVeg = t.IsVeg;
                MyPizza.Details = t.Details;
                return true;
            }
            return false;
        }
    }
}
