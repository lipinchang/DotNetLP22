using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingLINQApp
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_ID { get; set; }
        public override string ToString()
        {
            return Id+" "+Name+ " " + Department_ID;
        }
    }

    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
    
    internal class Program
    {
        List<Department> departments = new List<Department>()
            {
                new Department{Id = 1, Name ="Admin"},
                new Department{Id = 2, Name ="Development"},
                new Department{Id = 3, Name ="Testing"},
            };

        List<Employee> employees = new List<Employee>()
           {
               new Employee{Id = 101,Name ="Tim",Department_ID=1},
               new Employee{Id = 102,Name ="Jim",Department_ID=2},
               new Employee{Id = 103,Name ="Kim",Department_ID=3},
               new Employee{Id = 104,Name ="Lim",Department_ID=2},
               new Employee{Id = 105,Name ="Pim",Department_ID=2},
               new Employee{Id = 106,Name ="Rim",Department_ID=1},
           };


        void LINQWithCollection()
        {
            //var myEmployees = employees.Where(e => e.Department_ID == 1);
            //foreach (var item in myEmployees)
            //{
            //    Console.WriteLine(item);
            //}

            //var myEmp = employees.SingleOrDefault(e => e.Id == 102);     //third    uses function           
            ////var myEmp = employees.Where(e => e.Id == 102).SingleOrDefault();   //second    uses predicate
            ////var myEmp = employees.Where(e => e.Id == 102).Single();   //first
            //if (myEmp == null)
            //    Console.WriteLine("No such employee");
            //else
            //    Console.WriteLine(myEmp);

            var MyData = employees
                .Join(departments, emp => emp.Department_ID, dept => dept.Id, (emp, dept) => new {
                    EmployeeName = emp.Name, emp.Id, emp.Department_ID, DepartmentName = dept.Name
                
                } )
                .Where(e => e.Department_ID == 2 || e.Department_ID == 1)
                .OrderBy(e => e.Id)   //orderby id
                .Select(e => new { e.EmployeeName, EmployeeId = e.Id, DepartmentName = e.DepartmentName });

            foreach (var item in MyData)
            {
                Console.WriteLine("Employee ID : " + item.EmployeeId);    //finds me employees name & id with dept id 2 and 1
                Console.WriteLine("Employee Name : " + item.EmployeeName);
                Console.WriteLine("Department Name : " + item.DepartmentName);
            }

        }
        void SimpleWhere()
        {
            int[] scores = {90,67,86,74,40 };
            //List<int> results = new List<int>();              //m1  slower processing/performance
            //foreach (var score in scores)
            //{
            //    if (score > 70)
            //        results.Add(score);
            //}
            //var results = from s in scores where s > 70 select s;           //m2
            //pass method as parameter is a delegate
            //var results = scores.Where(x => x > 70);                    //m3 delegate  //lambda =>   //get executed only when its needed like for foreach below// linq runs faster//it is an expression
            //var results = scores.Where(x => x > 70).ToList();           //execute itself rightaway
            //linq is a engine, lambda is an expression
            //linq can be used by backend query, ado.net
        //    foreach (var item in results)
        //    {
        //        Console.WriteLine(item);
        //    }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.LINQWithCollection();

            Console.ReadKey();
        }
    }
}
