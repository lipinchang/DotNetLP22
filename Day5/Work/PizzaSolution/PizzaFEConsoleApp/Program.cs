using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFEConsoleApp
{
    class Program
    {
        Customer customer = new Customer();     //so can use everywhere

        

        static void Main(string[] args)
        {
            ManageCustomer program = new ManageCustomer();
            program.RegisterCustomer();
            program.DisplayCustomer();
            Console.ReadKey();

        }
    }
}
