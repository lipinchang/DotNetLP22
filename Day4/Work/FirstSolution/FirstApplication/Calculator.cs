using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    internal class Calculator
    {
        int number1, number2;
        void TakeNumbers()
        {
            Console.WriteLine("Please enter the first number");
            number1 = Convert.ToInt32(Console.ReadLine());      //read line reads a string only
            Console.WriteLine("Please enter the second number");
            number2 = Convert.ToInt32(Console.ReadLine());

            float fNum1 = float.Parse(Console.ReadLine());
        }

        public void Add()
        {
            TakeNumbers();
            int sum = number1 + number2;
            Console.WriteLine("The sum of "+number1+" and " + number2+" is "+sum);
        }

        public void Product()
        {
            TakeNumbers();  //calling instance from another instance no need create object
            int product = number1 * number2;
            Console.WriteLine("The product of " + number1 + " and " + number2 + " is " + product);
        }
    }
}
