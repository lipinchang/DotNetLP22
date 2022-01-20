using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    internal class Program
    {
        //method header
        void PrintName()
        {
            //method body
            Console.WriteLine("hello lp");
        }

        void PrintAnyName(string name)
        {
            Console.WriteLine("Hello "+name);
        }

        void Greet(string greet)
        {
            string name;
            Console.WriteLine("Please enter your name");
            name = Console.ReadLine();
            Console.WriteLine(greet+ " "+name);
        }
        
        static void Main(string[] args)
        {
            //Console.WriteLine("hello"); //cw double tab
            //Program program = new Program();  //calling from static to instance, need create object
            //program.Greet("Hi!");

            //Calculator calc = new Calculator();
            //calc.Add();
            //calc.Product();

            //Statements s = new Statements();
            //s.IterationWithDoWhile();

            ClassExercises ce = new ClassExercises();
            ce.PrintNumbersFromZeroToGivenNumber();
            Console.ReadKey();  //waiting/stay put for user input






            //ctrl k + c   comment
            //ctrl k + u   uncomment
            //another way to run -> project, bin, debug, run project exe
            //for double tab - for loop
            //ctor double tab - constructor

        }



    }

}
