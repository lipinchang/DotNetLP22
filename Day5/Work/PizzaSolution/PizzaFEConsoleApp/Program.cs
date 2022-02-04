using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFEConsoleApp
{
    class Program
    {    //try parse is eror handling, check for id is present. handle error first then exception as error is within our reach
        Customer customer = new Customer();     //so can use everywhere

        void manageMenu()
        {
            //Console.WriteLine("Welcome to menu management");
            //int choice = 0;
            //ManageMenu menu = new ManageMenu();
            //do
            //{
            //    Console.WriteLine("1: Add 3 pizzas");
            //    Console.WriteLine("2: Edit Pizza price");
            //    Console.WriteLine("3: Remove pizza");
            //    Console.WriteLine("4: Print a pizza detail");
            //    Console.WriteLine("5: Print all pizza details");
            //    Console.WriteLine("0: Exit");
            //    while (!int.TryParse(Console.ReadLine(), out choice))
            //    {
            //        Console.WriteLine("Please enter a number");
            //    }
            //    try
            //    {
            //        switch (choice)
            //        {
            //            case 1:
            //                menu.AddPizzas();
            //                break;
            //            case 2:
            //                menu.EditPizzaPrice();
            //                break;
            //            case 3:
            //                menu.RemovePizza();
            //                break;
            //            case 4:
            //                menu.PrintSinglePizzaByID();
            //                break;
            //            case 5:
            //                menu.PrintPizzas();
            //                break;
            //            case 0:
            //                Console.WriteLine("bye");
            //                break;
            //            default:
            //                Console.WriteLine("Invalid choice, pls try again");
            //                break;
            //        }
            //    }
            //    catch (NullReferenceException nre)
            //    {
            //        Console.WriteLine("null mistake");
            //        Console.WriteLine(nre.Message);
            //    }
            //    catch(ArgumentOutOfRangeException aore)
            //    {
            //        Console.WriteLine("Pizza could not be found");
            //        Console.WriteLine(aore.Message);
            //    }
            //    catch (FormatException fe)
            //    {
            //        Console.WriteLine("expecting a number");
            //        Console.WriteLine(fe.Message);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("oops something went wrong");
            //        Console.WriteLine(e.Message);
            //    }
            //} while (choice != 0);
            new ManageCart().PrintCart();
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
