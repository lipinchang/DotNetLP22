using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInterfaceApplication
{
    internal class Bird : IFlying, ILiving    //abstracting: way of abstracting an object.in multiple objs. show diff groups of ppl diff things. not all stuff like a class would
    {
        public void Breathe()
        {
            Console.WriteLine("Breathe in...");
        }

        public void Eat()
        {
            Console.WriteLine("munch..");
        }

        public void Sleep()
        {
            Console.WriteLine("zzzzzzzzzzz");
        }

        public void TakeOff() {
            Console.WriteLine("take off");
        }

        public void Fly()
        {
            Console.WriteLine("Fly");
        }

        public void Land()
        {
            Console.WriteLine("Land");
        }
    }
}
