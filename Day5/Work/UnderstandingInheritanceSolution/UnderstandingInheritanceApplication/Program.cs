using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInheritanceApplication
{
    internal class Program
    {
        void UsePhone(Phone phone)
        {
            //MobilePhone phone = new MobilePhone();
            phone.MakeCall();
            phone.ReceiveCall();
            //((MobilePhone)phone).Carry();   //explicit casting
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Phone phone = new MobilePhone();   //notice how its new MobilePhone? its polymorphism
            program.UsePhone(phone);   
            Console.ReadKey();
        }
    }
}
