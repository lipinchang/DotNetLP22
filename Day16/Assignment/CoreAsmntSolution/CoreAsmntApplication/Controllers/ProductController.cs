using CoreAsmntApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAsmntApplication.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> Products = new List<Product>()     //static so list will be common
        {
            new Product()
            {
                Id = 1,
                Name ="ABC",
                Price = 5,
                SupplierId = 1,
                Quantity=1,
                Remarks="Carrots from Malaysia"
            }
        };
        public IActionResult Index()
        {
            var products = Products;
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Products.Add(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var product = Products.Where(c => c.Id == ID).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            Product oldProduct = new Product();
            oldProduct = Products.Where(c => c.Id==product.Id).SingleOrDefault();
            Products.Remove(oldProduct);
            Products.Add(product);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Details(int ID)
        {
            var product = Products.Where(c => c.Id == ID).SingleOrDefault();
            return View(product);
        }
       
    }
}
