using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModelsLibrary;

namespace PizzaFEConsoleApp
{
    internal class ManageMenu
    {
        Pizza[] pizzas;

        public Pizza this[int index]
        {
            get { return pizzas[index]; }
            set { pizzas[index] = value; }
        }
        public ManageMenu()
        {
            pizzas = new Pizza[3];
        }

        public ManageMenu(int size)
        {
            pizzas = new Pizza[size]; 
        }
        public void AddPizzas()
        {
            for (int i = 0; i < pizzas.Length; i++)
            {
                int id= GenerateId();
                pizzas[i] = new Pizza();
                pizzas[i].Id = id;
                pizzas[i].GetPizzaDetails();
            }
        }

        private int GenerateId()
        {
            if (pizzas[0] == null)
                return 101;
            else
            {
                for (int i = 0; i < pizzas.Length; i++)
                {
                    if (pizzas[i] == null)
                        return 101 + i;
                }
            }
            return 0;

        }

        public Pizza GetPizzaById(int id)   //return pizza obj
        {
            Pizza pizza = null;
            for (int i = 0; i < pizzas.Length; i++)
            {
                if (pizzas[i].Id == id)
                    pizza = pizzas[i];
            }
            return pizza;
        }
        public void EditPizzaPrice()
        {
            int id = GetIdFromUser();
            Pizza pizza = GetPizzaById(id);
            if (pizza == null)
            {
                Console.WriteLine("Invalid Id, cannot edit");
                return;
            }
            Console.WriteLine("The pizza for you have chosen to edit price");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid entry for price. Please try again...");
            }
            pizza.Price = price;

            Console.WriteLine("Updated. New details");
            PrintPizza(pizza);
        }

        public void PrintSinglePizzaByID()
        {
            int id = GetIdFromUser();
            Pizza pizza = GetPizzaById(id);
            if (pizza != null)
            {
                PrintPizza(pizza);
            }
            else
            {
                Console.WriteLine("No such pizza");
            }
        }

        private void PrintPizza(Pizza pizza)
        {
            Console.WriteLine("************************************");
            Console.WriteLine(pizza);
            Console.WriteLine("************************************");
        }

        public void RemovePizza()
        {
            int id = GetIdFromUser();
            int idx = -1;
            for (int i = 0; i < pizzas.Length; i++)
            {
                if (pizzas[i].Id == id)
                    idx = i;
            }

            Pizza pizza = GetPizzaById(id);
            if (pizza != null)
            {
                Console.WriteLine("Do you want to delete the following pizza??");
                PrintPizza(pizza);
                string check = Console.ReadLine();
                if (check == "yes")
                    pizza = null;
            }
        }

        int GetIdFromUser()
        {
            Console.WriteLine("Please enter the pizza id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for id. Please try again...");
            }
            return id;
        }

        public void PrintPizzas()
        {

            foreach (var item in pizzas)
            {
                if(item!=null)
                //Console.WriteLine(item);
                    PrintPizza(item);
            }
        }
    }
}
