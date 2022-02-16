using APIEFAssigment.Models;
using APIEFAssigment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEFAssigment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepo<int, Customer> _repo;
        public CustomerController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _repo.GetAll();
        }

        [HttpGet]
        [Route("SingleCustomer")]
        public Customer Get(int id)
        {
            return _repo.Get(id);
        }

        [HttpPost]
        public Customer Post(Customer customer)
        {
            _repo.Add(customer);
            return customer;
        }

        [HttpPut]
        public Customer Put(int id, Customer cust)   //update    //in postman to put in parameter id(3) and body(one customer obj id 3 in json)
        {
            var customer = _repo.Get(cust.Id);
            if (customer != null)
            {
                customer.Name = cust.Name;
                customer.Age = cust.Age;
                _repo.Update(customer);
            }
            return customer;
        }

        [HttpDelete]
        public Customer Delete(int id)
        {
            _repo.Remove(id);
            var customer = _repo.Get(id);
            return customer;
        }
    }
}
