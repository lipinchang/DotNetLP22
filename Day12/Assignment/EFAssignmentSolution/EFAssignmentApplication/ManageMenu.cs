using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignmentApplication
{
    internal class ManageMenu
    {
        CompanyDAL companyDAL;
        ICollection<Department> departments;
        ICollection<Employee> employees;

        public ManageMenu()
        {
            companyDAL = new CompanyDAL();
        }
        public void GetAllDepartments()
        {
            departments = null;
            try
            {
                departments = companyDAL.GetAllDepartments();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Will fix soon...");
                Console.WriteLine(e.Message);
            }
            PrintDepartments();
        }


        private void PrintDepartment(Department department)
        {
            Console.WriteLine("************************************");
            Console.WriteLine(department);
            Console.WriteLine("************************************");
        }

        public void PrintDepartments()
        {

           
            var sortedDepartments = departments.OrderBy(p => p.Department_Id);
            foreach (var item in sortedDepartments)
            {
                if (item != null)
                    //Console.WriteLine(item);
                    PrintDepartment(item);
            }
        }

        public void GetAllEmployees()
        {
            employees = null;
            try
            {
                employees = companyDAL.GetAllEmployees();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Will fix soon...");
                Console.WriteLine(e.Message);
            }
            PrintEmployees();
        }

        private void PrintEmployee(Employee employee)
        {
            Console.WriteLine("************************************");
            Console.WriteLine(employee);
            Console.WriteLine("************************************");
        }

        public void PrintEmployees()
        {
            
            var sortedEmployees = employees.OrderBy(p => p.Id);
            foreach (var item in sortedEmployees)
            {
                if (item != null)
                    //Console.WriteLine(item);
                    PrintEmployee(item);
            }
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            employee.GetNewEmployeeDetails();

            try
            {
                companyDAL.InsertNewEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add the employee");
                Console.WriteLine(e.Message);
            }
        }

        public void AddDepartment()
        {
            Department department = new Department();
            department.GetNewDepartmentDetails();

            try
            {
                companyDAL.InsertNewDepartment(department);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add the department");
                Console.WriteLine(e.Message);
            }
        }

        public void EditDepartmentName()
        {
            GetAllDepartments();
            int id = GetDepartmentIdFromUser();
            string name = GetDepartmentNameToEditFromUser();
            try
            {
                companyDAL.UpdateDepartmentName(id, name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not change the department name");
                Console.WriteLine(e.Message);
            }

        }

        public void EditEmployeeAge()
        {
            GetAllEmployees();
            int id = GetEmployeeIdFromUser();
            int age = GetAgeToEditFromEmployee();
            try
            {
                companyDAL.UpdateEmployeeAge(id, age);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not change employee age");
                Console.WriteLine(e.Message);
            }

        }

        int GetAgeToEditFromEmployee()
        {
            Console.WriteLine("Please enter the age you want to change to");
            int age = Convert.ToInt32(Console.ReadLine());
            return age;
        }

        string GetDepartmentNameToEditFromUser()
        {
            Console.WriteLine("Please enter the department name you want to change to");
            string name = Console.ReadLine();
            return name;
        }
        
        int GetDepartmentIdFromUser()
        {
            Console.WriteLine("Please enter the department id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for id. Please try again...");
            }
            return id;
        }

        int GetEmployeeIdFromUser()
        {
            Console.WriteLine("Please enter the employee id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for id. Please try again...");
            }
            return id;
        }

        public void EditEmployeeDepartment()
        {
            GetAllEmployees();
            int id = GetEmployeeIdFromUser();
            int departmentId = GetEmployeeDepartmentId();
            try
            {
                companyDAL.UpdateEmployeeDepartment(id, departmentId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not change employee department");
                Console.WriteLine(e.Message);
            }
        }

        int GetEmployeeDepartmentId()
        {
            GetAllDepartments();
            Console.WriteLine("Please enter your new department id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry for id. Please try again...");
            }
            return id;
        }

        
    }
}
