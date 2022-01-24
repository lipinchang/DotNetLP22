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

        void manageMenu()
        {
            Console.WriteLine("Welcome to menu management");
            int choice = 0;
            ManageMenu menu = new ManageMenu();
            do
            {
                Console.WriteLine("1: Add 3 pizzas");
                Console.WriteLine("2: Edit Pizza price");
                Console.WriteLine("3: Remove pizza");
                Console.WriteLine("4: Print a pizza detail");
                Console.WriteLine("5: Print all pizza details");
                Console.WriteLine("0: Exit");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a number");
                }
                switch (choice)
                {
                    case 1:
                        menu.AddPizzas();
                        break;
                    case 2:
                        menu.EditPizzaPrice();
                        break;
                    case 3:
                        menu.RemovePizza();
                        break;
                    case 4:
                        menu.PrintSinglePizzaByID();
                        break;
                    case 5:
                        menu.PrintPizzas();
                        break;
                    case 0:
                        Console.WriteLine("bye");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, pls try again");
                        break;
                }
            } while (choice != 0);
        }

        static void Main(string[] args)
        {
            //ManageCustomer program = new ManageCustomer();
            //program.RegisterCustomer();
            //program.DisplayCustomer();

            Program program = new Program();
            program.manageMenu();

            Console.ReadKey();

        }
    }
}
