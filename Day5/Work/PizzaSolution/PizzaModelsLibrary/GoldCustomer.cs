//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PizzaModelsLibrary
//{
//    public class GoldCustomer : Customer  //rememeber make public   //inherit
//    {
//        public GoldCustomer()
//        {
//            MinimumAmount = 0;
//            Type = "Gold";
//        }

//        public override string ToString()
//        {
//            return base.ToString()+ " Minimum amount for delivery is 0";
//        }

//        public override void TakeCustomerDetailsFromUser()
//        {
//            base.TakeCustomerDetailsFromUser();   //take method from base class(parent class)
//            Console.WriteLine("Please enter your preferred minimum ammount");
//            //MinimumAmount = Convert.ToInt32(Console.ReadLine());

//            int amount = 0;
//            //bool result = Int32.TryParse(Console.ReadLine(), out amount);   //out is what is being given out
//            //Console.WriteLine(result);

//            while(!Int32.TryParse(Console.ReadLine(), out amount))
//            {
//                Console.WriteLine("could not get the amount. Please try again.................");
//            }
//        }
//    }
//}
