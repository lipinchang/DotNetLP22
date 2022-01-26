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
        //Pizza[] pizzas;
        List<Pizza> pizzas;

        public Pizza this[int index]
        {
            get { return pizzas[index]; }
            set { pizzas[index] = value; }
        }
        public ManageMenu()
        {
            //pizzas = new Pizza[3];
            pizzas = new List<Pizza>();
        }

        public ManageMenu(int size)
        {
            //pizzas = new Pizza[size]; 
        }
        public void AddPizzas()
        {
            //for (int i = 0; i < pizzas.Count; i++)
            //{
            //    int id= GenerateId();
            //    pizzas[i] = new Pizza();
            //    pizzas[i].Id = id;
            //    pizzas[i].GetPizzaDetails();
            //}
            Pizza pizza = new Pizza();
            pizza.Id = GenerateId();
            pizza.GetPizzaDetails();
            pizzas.Add(pizza);
        }

        private int GenerateId()
        {
            //if (pizzas[0] == null)
            //    return 101;
            //else
            //{
            //    for (int i = 0; i < pizzas.Length; i++)
            //    {
            //        if (pizzas[i] == null)
            //            return 101 + i;
            //    }
            //}

            if (pizzas.Count == 0)
                return 101;
            return pizzas.Count+101;

        }

        public Pizza GetPizzaById(int id)   //return pizza obj
        {
            //Pizza pizza = null;
            //for (int i = 0; i < pizzas.Count; i++)
            //{
            //    if (pizzas[i].Id == id)
            //        pizza = pizzas[i];
            //}


            //Predicate<Pizza> findPizza = p => p.Id == id;
            //Pizza pizza = pizzas.Find(findPizza);  //keep interating until it get true. if false will return back null


            //Pizza pizza = pizzas.Find(p => p.Id == id);

            Pizza pizza = pizzas.SingleOrDefault(p => p.Id == id);

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
            //for (int i = 0; i < pizzas.Count; i++)
            //{
            //    if (pizzas[i].Id == id)
            //        idx = i;
            //}

            try
            {
                idx = pizzas.SingleOrDefault(p => p.Id == id).Id;
            }
            catch (Exception)
            {
                Console.WriteLine("no such pizza");
            }

            Pizza pizza = GetPizzaById(id);
            if (idx != -1)
            {
                Console.WriteLine("Do you want to delete the following pizza??");
                PrintPizza(pizza);
                string check = Console.ReadLine();
                if (check == "yes")
                    //pizza = null;
                    pizzas.RemoveAt(idx);
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
            //Array.Sort(pizzas);
            pizzas.Sort();
            foreach (var item in pizzas)
            {
                if(item!=null)
                //Console.WriteLine(item);
                    PrintPizza(item);
            }
        }
    }
}
