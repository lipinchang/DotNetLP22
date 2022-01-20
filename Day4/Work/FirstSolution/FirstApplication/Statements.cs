using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    internal class Statements
    {
        public void UnderstandingSelectionWithIf()
        {
            int number1;
            Console.WriteLine("Please enter the first number");
            number1 = Convert.ToInt32(Console.ReadLine());
            if(number1 == 0)
                Console.WriteLine("It is zero");
            else if(number1>100)
                Console.WriteLine("Good");
            else
                Console.WriteLine("idk what to say");
        }

        public void UnderstandingSelectionWhichSwitch()
        {
            int number1;
            Console.WriteLine("Please enter the first number");
            number1 = Convert.ToInt32(Console.ReadLine());
            switch (number1)
            {
                case 0:
                    Console.WriteLine("It is zero");
                    break;
                case 100:
                    Console.WriteLine("Good");
                    break;
                default:
                    Console.WriteLine("Not a valid input");
                    break;
            }                    
        }

        public void IterationWithFor()
        {
            for (int i = 0; i < 3; i++)     //finite condition, when you know how many times the loop should run
            {
                Console.WriteLine(i);
            }
        }
        public void IterationWithWhile()
        {
            Console.WriteLine("Understanding While");   //If you want the loop to break based on a condition other than the number of times it runs(eg. boolean), you should use a while loop.
            int i = 0;

            while (i < 3)
            {
                Console.WriteLine(i);
                i = i + 1;
            }
        }
        public void IterationWithDoWhile()
        {
            Console.WriteLine("Understanding Do While");
            int i = 0;

            do
            {
                Console.WriteLine(i);
                i = i + 1;
            } while (i < 3);
        }

        
    }
}
