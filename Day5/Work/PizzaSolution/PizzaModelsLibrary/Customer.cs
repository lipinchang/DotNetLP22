using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaModelsLibrary
{
    public class Customer :IComparable  
    {   [Key]
        public int CustomerNumber { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        string phone;

        public int MinimumAmount { get; set; }

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

        //ctor + tab
        public Customer()
        {
            //constructor has no return type, use to initialize value
            MinimumAmount = 100;
            Type = "Standard";
        }

        public virtual void TakeCustomerDetailsFromUser()   //has to be public for other proj to use
        {
            Console.WriteLine("Please enter the customer ID");
            CustomerNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Customer Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the Customer phone number");
            Phone = Console.ReadLine();
        }

        public void PrintCustomerDetails()
        {
            Console.WriteLine("Customer ID {0} Customer Name {1} Customer Phone {2}", CustomerNumber, Name, Phone);
        }

       
        public override string ToString()    //override normal tostring
        {
            return "Customer ID " + CustomerNumber + "\nCustomer Name " + Name + "\nCustomer Phone " + Phone+"\nCustomer Type "+Type;

        }

        public int CompareTo(object obj)
        {
            Customer c1, c2;
            c1 = this;
            c2 = (Customer)obj;

            //if (c1.Id < c2.Id)    //type one
            //    return -1;
            //else if (c1.Id > c2.Id) return 1;
            //else return 0;

            return c1.CustomerNumber.CompareTo(c2.CustomerNumber);    //type 2
        }

        //public int CartNumber { get; set; }

        //[ForeignKey("CartNumber")]    //one to one r/s one cust has one cart    one side can already
        //public Cart MyCart { get; set; }    //ref for FE easily
    }
}
