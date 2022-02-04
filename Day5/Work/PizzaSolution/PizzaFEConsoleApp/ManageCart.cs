using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDALEFLibrary;

namespace PizzaFEConsoleApp
{
    internal class ManageCart
    {
        public void PrintCart()
        {
            Console.WriteLine("Enter the customer number");
            int id = Convert.ToInt32(Console.ReadLine());
            CartDAL cartDAL = new CartDAL();
            cartDAL.GetCart(1);
        }
    }
}
