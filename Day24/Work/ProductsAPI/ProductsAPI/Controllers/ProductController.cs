using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetAll();
            return Ok(products);
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var products = await _repo.Get(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            var prod = await _repo.Add(product);
            return Ok(prod);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            var prod = await _repo.Update(product);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }
        [HttpDelete]
        public async Task<IActionResult> Deletet(int id)
        {
            var prod = await _repo.Delete(id);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }
    }
}
