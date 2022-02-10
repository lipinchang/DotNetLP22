using CustomerAssignmentApplication.Models;
using CustomerAssignmentApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAssignmentApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepo<int, Customer> _repo;
        public CustomerController(IRepo<int, Customer> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var customers = _repo.GetAll();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var customer = _repo.GetT(id);
            return View(customer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _repo.Add(customer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _repo.GetT(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer customer)
        {
            _repo.Update(id, customer);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var customer = _repo.GetT(id);
            return View(customer);
        }

    }
}
