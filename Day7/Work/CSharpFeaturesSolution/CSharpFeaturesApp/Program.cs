using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeaturesApp
{
    internal class Program
    {
        void UnderstandingCheckedBlocked()
        {
            int num = int.MaxValue;
            Console.WriteLine(num);
            unchecked
            {
                num++; 
                Console.WriteLine(num);
            }
        }
        void NullablePrimitiveTypes()
        {
            int? num1 = 100;
            num1 = null;   //now u can use it// int?
            int num2 = num1 ?? 10;  //null collasing /if num1 is null then value is 10. use for when age is 0
            Console.WriteLine(num2);
        }

        bool MethodWithOut(int value, out int value2)
        {
            value2 = value * 50;
            return true;
        }

        
        static void Main(string[] args)
        {
            Program program = new Program();
            int v1 = 10, v2 = 0;
            //program.MethodWithOut(v1, out v2);
            program.UnderstandingCheckedBlocked();
            Console.WriteLine(v2);
            Console.ReadKey();
        }
    }
}
