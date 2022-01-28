using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingDelegatesApp
{
    class Sample
    {
        //action-for methods with or without parameter ut o return
        //func for methods with or without parameters with one return types
        //predicate -for methods with one paramter with a boolean return type


        ////public delegate void SampleDelegate(int n1, int n2);  //type for a method    for sharing of a method, so they cant see ur class
        //public delegate void SampleDelegate<T>(T n1, T n2);  //type for a method   
        ////public SampleDelegate MyDel;   //create ref for the type
        //public SampleDelegate<int> MyDel;   //create ref for the type
        //public SampleDelegate<string> MyStringDel;   //create ref for the type

        public Action<int, int> MyDel;
        public Action<string, string> myStringDel;

        public Sample()
        {
            
            //MyDel = new SampleDelegate(Add);   way1
            //MyDel += Product;   //second method signature should match. other wise delegate is useless


            MyDel = delegate (int n1, int n2)     //way2
            {
                Console.WriteLine("the sum is "+(n1 +n2));
              
            };

            //MyDel += delegate (int n1, int n2)
            //{
            //    Console.WriteLine("the product is " + (n1 * n2));
            //};

            //lambda expression, use more.  to replace the above
            MyDel += (n1, n2) => Console.WriteLine("The product is " + (n1 * n2));

            //MyStringDel = new SampleDelegate<string>(Add);   //generic delegate
        }
        void Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("the sum is: "+sum);
        }

        void Add(string num1, string num2)
        {
            string sum = num1 + num2;
            Console.WriteLine("the result is: " + sum);
        }

        void Product(int num1, int num2)
        {
            int prod = num1 * num2;
            Console.WriteLine("the prod is: " + prod);
        }

    }
}
