using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInterfaceApplication
{
    internal class Program
    {
        void CheckSky(IFlying flying)
        {
            flying.TakeOff();
            flying.Fly();
            flying.Land();
        }
        void ExploreForest(ILiving living)
        {
            living.Breathe();
            living.Eat();
            living.Sleep();
        }
        void SortAndPrintName()
        {
            string[] names = { "Tim", "Jim", "Lim" };
            Array.Sort(names);
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
        static void Main(string[] args)
        {
            //interface is a way of abstracting a class. showing what is necceasry

            Bird bird = new Bird();
            Program program = new Program();
            //program.ExploreForest(bird);
            //program.CheckSky(bird);
            program.SortAndPrintName();
            Console.ReadKey();
            
        }
    }
}
