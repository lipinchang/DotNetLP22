using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UnderstandingCollectionsApp
{
    internal class Program
    {
        void UnderstandingList()
        {
            //ArrayList list = new ArrayList();
            //list.Add(100);
            //list.Add("200");  //legacy arraylist is not type safe//collection
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}


            //type safe//generic
            List<int> list2 = new List<int>();
            list2.Add(100);
            Console.WriteLine("list can be indexed: "+list2[0]);
        }

        void UnderstandingStack()
        {
            Stack<string> names = new Stack<string>();   //LIFO
            names.Push("Tim");
            names.Push("Jim");
            foreach (var item in names)     //uses peek so it doesnt pop
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(names.Count);
            Console.WriteLine(names.Pop());
            Console.WriteLine(names.Peek());//peeks all
            Console.WriteLine(names.Count);
        }

        //queue is FIFO
        void UnderstandingQueue()  //for appointment
        {
            Queue<string> names = new Queue<string>();   //LIFO
            names.Enqueue("Tim");
            names.Enqueue("Jim");
            foreach (var item in names)     //uses peek so it doesnt pop
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(names.Count);
            Console.WriteLine(names.Dequeue());//aka pop
            Console.WriteLine(names.Peek());
            Console.WriteLine(names.Count);
        }

        void UnderstandingDictionary()
        {
            Dictionary<int, string> users = new Dictionary<int, string>();
            users.Add(101, "Tim");   //cannot have duplicate key/null key
            users.Add(102, "Lim");
            users.Add(103, "Kim");
            users.Add(104, "Jim");  //values can be duplicated/null
            users.Add(105, "Bim");
            foreach (var item in users.Keys)     //uses peek so it doesnt pop
            {
                Console.WriteLine(item + " "+users[item]);
            }
            //check if exists
            if(users.ContainsKey(103))
                Console.WriteLine("key 103 already present");
        
            Console.WriteLine(users.ContainsValue("Jim"));
        }

        void UnderstandingSets()
        {
            HashSet<string> names = new HashSet<string>();
            //SortedSet<string> names = new SortedSet<string>();  //sorted set
            names.Add("Tim");
            names.Add("Lim");
            names.Add("Kim");
            names.Add("Jim");
            names.Add("Bim");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            new Program().UnderstandingDictionary();   //anon method
            Console.ReadKey();
        }
    }
}
