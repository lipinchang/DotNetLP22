using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApplication
{
    internal class Customer
    {
        public int Id { get; set; }  //prop + tab
        public string Name { get; set; }

        string phone;   //use ctrl + . to generate

        public string Phone
        {
            get
            {
                string masked = "XXXXXX" + phone.Substring(6, 4);
                return masked;
            }
            set
            {
                phone = value;
            }
        }
    }
}
