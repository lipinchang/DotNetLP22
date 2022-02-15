using Microsoft.AspNetCore.Mvc;

namespace PassingInputAssignmentApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
