using ConsumeAPIEFApplication.Models;
using ConsumeAPIEFApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPIEFApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }
        public async Task<ActionResult> Index()
        {
            var products = await _repo.GetAll();
            return View(products);
        }
        public async Task<ActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            var prod = await _repo.Add(product);
            if (prod == null)
                return View();
            return RedirectToAction("Index");
        }
    }
}
