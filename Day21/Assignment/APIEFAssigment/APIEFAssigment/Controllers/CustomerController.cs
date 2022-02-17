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
        public ActionResult<IEnumerable<Customer>> Get()     //notice action result
        {
            List<Customer> customers = _repo.GetAll().ToList();
            if (customers.Count == 0)
                return BadRequest("No customers found");
            return Ok(customers);
        }

        [HttpGet]
        [Route("SingleCustomer")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _repo.GetT(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            var cust = _repo.Add(customer);
            if (cust != null)
            {
                return Created("Customer Created", cust);
            }
            return BadRequest("Unable to create");
        }

        [HttpPut]
        public ActionResult<Customer> Put(int id, Customer cust)   //update    //in postman to put in parameter id(3) and body(one customer obj id 3 in json)
        {
            var customer = _repo.Update(cust);
            if (customer != null)
            {
                return Created("Updated", customer);
            }
            
            return NotFound();
        }

        [HttpDelete]
        public ActionResult<Customer> Delete(int id)
        {
            var customer = _repo.Delete(id);
            if (customer != null)
            {
                return NoContent();
            }
            return NotFound(customer);
        }
    }
}
