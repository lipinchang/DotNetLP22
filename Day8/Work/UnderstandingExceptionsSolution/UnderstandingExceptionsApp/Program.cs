using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingExceptionsApp
{
    internal class Program
    {
        int num1, num2;
       void TakeTwoNumbersFromUsers()
        {
            Console.WriteLine("Please enter the first number");
            num1 = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Please enter the second number");
            num2 = Convert.ToInt32(Console.ReadLine());



        }
        void Calculate()
        {
            float result = 0;
            result = num1 / num2;
            Console.WriteLine("The result is "+ result);
            Console.WriteLine("done");
        }
        static void Main(string[] args)
        {

            try
            {
                Program program = new Program();
                program.TakeTwoNumbersFromUsers();
                program.Calculate();
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("we are expecting a whole number");
            }catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                Console.WriteLine("number is too big");
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine(dbze.Message);
                Console.WriteLine("the denominator cannot be zero") ;
            }
            catch (Exception e)   ///general exception
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("oops something went wrong");
            }
            finally{
                Console.WriteLine("bye");
            }
            

            Console.ReadKey();
        }
    }
}
