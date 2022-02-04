using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDALEFLibrary
{
    public class CartDAL
    {
        readonly PizzaContext _pizzaContext;
        public CartDAL()
        {
            _pizzaContext = new PizzaContext();
        }

        public void GetCart(int cid)
        {
            //List<CartPizzas> crtDetails = new List<CartPizzas>();

            //var crtDetails = _pizzaContext.Carts.Where(c => c.CustomerNumber == cid).ToList();
            //var crtDetails = _pizzaContext.Carts.Include("Customer").Where(c => c.CustomerNumber == cid).ToList();
            //foreach (var crt in crtDetails)
            //{
            //    Console.WriteLine("The cart number +"+crt.CartNumber);
            //    Console.WriteLine("Hi "+crt.Customer.Name);
            //    Console.WriteLine("Pizzas in your cart");
            //    Console.WriteLine("---------------------------------------");
            //    foreach (var item in crt.Pizzas)
            //    {
            //        Console.WriteLine("---pizza name                "+item.Name);
            //        Console.WriteLine("---pizza price                "+item.Price);
            //        if(item.IsVeg)
            //            Console.WriteLine("---             veg");
            //        else
            //            Console.WriteLine("---              non veg");
            //    }
            //    Console.WriteLine("---------------------------------------");
            //}


            var crt = _pizzaContext.Carts.Where(c=>c.CustomerNumber==cid)
               .Join(_pizzaContext.Customers,
               c => c.CustomerNumber,
               cus => cus.CustomerNumber,
               (cart, cust) => new
               {
                   CustomerName = cust.Name,
                   CartNumber = cart.CartNumber
               })
               .Join(_pizzaContext.CartPizzas,
               cc => cc.CartNumber,
               cp => cp.CartNumber,
               (custCart, cartPiz) => new
               {
                   CustomerName = custCart.CustomerName,
                   CartNumber = custCart.CartNumber,
                   PizzaName = cartPiz.Pizza.Name,
                   PizzaPrice = cartPiz.Pizza.Price,
                   IsVeg = cartPiz.Pizza.IsVeg ? "Veg" : "Non-Veg",
                   PizzaQuantity = cartPiz.Quantity
               }).ToList();
            Console.WriteLine("Hi");
        }
    }
}
