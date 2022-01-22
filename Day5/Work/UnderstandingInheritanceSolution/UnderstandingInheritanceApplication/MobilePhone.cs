using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInheritanceApplication
{
    internal class MobilePhone : Phone
    {
        public MobilePhone()
        {
            Console.WriteLine("and its mobile phone");
            PhoneNumber = "1234567890";  //can change phone number from child. parent class will execute first, then the body of the child class will be executed
        }

        public void Carry()
        {
            Console.WriteLine("Take where you go....");
        }

        public override void MakeCall()
        {
            Console.WriteLine("go wireless");
        }
    }
}
