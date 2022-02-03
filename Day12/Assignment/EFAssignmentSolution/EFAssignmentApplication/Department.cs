using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignmentApplication
{
    public class Department
    {
        [Key]
        public int Department_Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public void GetNewDepartmentDetails()
        {
            Console.WriteLine("Please enter department name");
            Name = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Department ID " + Department_Id
                + "\nName " + Name;
            
        }
    }
}
