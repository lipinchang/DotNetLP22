using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]  //attribute based routing
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static List<Customer> _customers = new List<Customer> { 
            new Customer { Id = 1, Name = "Tim", Age = 22 } ,
            new Customer { Id = 2, Name = "Jim", Age = 23 } ,
            new Customer { Id = 3, Name = "Bim", Age = 29 } 
        };
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }
        [HttpPut]
        public ActionResult Put(int id, Customer cust)   //update    //in postman to put in parameter id(3) and body(one customer obj id 3 in json)
        {
            var customer=_customers.SingleOrDefault(c=> c.Id == id);
            if (customer != null)
            {
                customer.Name = cust.Name;
                customer.Age = cust.Age;
                return Created("Updated", customer);
            }
            return NotFound();
        }
        [HttpDelete]
        public Customer Delete(int id)
        {
            var customer = _customers.IndexOf(_customers.Find(c=>c.Id==id));
            if (customer != -1)
            {
                _customers.RemoveAt(customer);
                return _customers.SingleOrDefault(c => c.Id == id);
            }
            return null;
        }

        [HttpGet]
        [Route("SingleEmployee")]
        public ActionResult Get(int id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                return NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public Customer Post(Customer customer)
        {
            _customers.Add(customer);
            return customer;
        }
    }
}
