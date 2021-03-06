using Microsoft.AspNetCore.Mvc;
using SampleMVCTogetherApp.Models;
using System.Diagnostics;

namespace SampleMVCTogetherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowProducts()
        {
            List<Product> products=new List<Product>()
            {
                new Product(){Id=1, Name="qwe" },
                new Product(){Id=2, Name="asd"}
            };
            ViewBag.Username = HttpContext.Session.GetString("un");   //get session to set to viewbag.username
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}