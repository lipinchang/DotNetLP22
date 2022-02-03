using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignmentApplication
{
    public class CompanyDAL
    {
        readonly CompanyContext _companyContext;

        public CompanyDAL()
        {
            _companyContext = new CompanyContext();
        }

        public ICollection<Department> GetAllDepartments()
        {
            List<Department> departments = _companyContext.Departments.ToList();
            if (departments.Count == 0)
                Console.WriteLine("No departments available");
            return departments;

        }
        
        public ICollection<Employee> GetAllEmployees()
        {
            List<Employee> employees = _companyContext.Employees.ToList();
            if (employees.Count == 0)
                Console.WriteLine("No employees available");
            return employees;

        }


        public void InsertNewDepartment(Department department)
        {
            _companyContext.Departments.Add(department);
            _companyContext.SaveChanges();
            Console.WriteLine("Department added");
        }
        
        public void InsertNewEmployee(Employee employee)
        {
            _companyContext.Employees.Add(employee);
            _companyContext.SaveChanges();
            Console.WriteLine("Employee added");
            
        }

        public void UpdateDepartmentName(int id, string name)
        {
            Department department = _companyContext.Departments.SingleOrDefault(p => p.Department_Id == id);
            if (department == null)
            {
                Console.WriteLine("no such department");
                return;
            }
            department.Name = name;
            _companyContext.SaveChanges();
            Console.WriteLine("Department name editted");
        }

        public void UpdateEmployeeAge(int id, int age)
        {
            Employee employee = _companyContext.Employees.SingleOrDefault(p => p.Id == id);
            if (employee == null)
            {
                Console.WriteLine("no such employee");
                return;
            }
            employee.Age = age;
            _companyContext.SaveChanges();
            Console.WriteLine("Employee age editted");
        }

        public void UpdateEmployeeDepartment(int id, int deptId)
        {
            Employee employee = _companyContext.Employees.SingleOrDefault(p => p.Id == id);
            if (employee == null)
            {
                Console.WriteLine("no such employee");
                return;
            }
            employee.Department_Id = deptId;
            _companyContext.SaveChanges();
            Console.WriteLine("Employee department editted");
        }
    }
}
