using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInheritanceApplication
{
    internal class Phone
    {


        public string PhoneNumber { get; set; }

        public Phone()
        {
            PhoneNumber = "123456789097";
            Console.WriteLine("Hey its a phone");
        }

        public virtual void MakeCall()   //let to override
        {
            Console.WriteLine("We can make calls from teh number " + PhoneNumber);
            Console.WriteLine("dial number wait for lines to connect");
        }

        public void ReceiveCall()
        {
            Console.WriteLine("Tring .... Tring");
            Console.WriteLine("We can receive calls  ");
        }
    }
}
