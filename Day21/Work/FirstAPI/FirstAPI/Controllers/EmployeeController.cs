using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> _employees = new List<Employee> {
            new Employee { Id = 1, Name = "Tim", Department = "IT" } ,
            new Employee { Id = 2, Name = "Jim", Department = "Accounts" } ,
            new Employee { Id = 3, Name = "Bim", Department = "HR" }
        };
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employees;
        }
        [HttpPost]
        public Employee Post(Employee employee)
        {
            _employees.Add(employee);
            return employee;
        }
    }
}
