using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PassingInputAssignmentApp.Models;
using PassingInputAssignmentApp.Services;

namespace PassingInputAssignmentApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;
        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
        public IActionResult Details(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        public IActionResult Create()
        {
            ViewBag.Category = GetProductCategories();
            ViewBag.Pic = GetProductPic();
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //server side also can do validations
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        public IActionResult Edit(int id)
        {
            Product product = _repo.Get(id);
            ViewBag.Category = GetProductCategories();
            ViewBag.Pic = GetProductPic();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            _repo.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id, Product customer)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult QtyOfProduct(int qty)
        {
            int myValue = qty;
            return RedirectToAction("Index");
        }

        IEnumerable<SelectListItem> GetProductCategories()
        {
            List<SelectListItem> category = new List<SelectListItem>();
            category.Add(new SelectListItem { Text = "Food", Value = "Food" });
            category.Add(new SelectListItem { Text = "Toy", Value = "Toy" });
            category.Add(new SelectListItem { Text = "Clothing", Value = "Clothing" });

            return category;
        }

        IEnumerable<SelectListItem> GetProductPic()
        {
            List<SelectListItem> pics = new List<SelectListItem>();
            pics.Add(new SelectListItem { Text = "Green Bell Pepper", Value = "/images/green.png" });
            pics.Add(new SelectListItem { Text = "Red Bell Pepper", Value = "/images/red.png" });
            pics.Add(new SelectListItem { Text = "Stacking Wooden Hoop", Value = "/images/teddy.png" });

            return pics;
        }
    }
}
