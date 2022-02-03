using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignmentApplication
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        
        public int Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public Department Department { get; set; }

        public void GetNewEmployeeDetails()
        {
            Console.WriteLine("Please enter employee name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter employee age");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter department id");
            Department_Id = Convert.ToInt32(Console.ReadLine());
        }

        public override string ToString()
        {
            return "Employee ID " + Id
                + "\nName " + Name
                + "\nAge "+Age
                + "\nDepartment Id "+Department_Id;

        }
    }
}
