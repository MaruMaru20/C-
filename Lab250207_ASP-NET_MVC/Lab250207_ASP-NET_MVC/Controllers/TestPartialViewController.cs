using Microsoft.AspNetCore.Mvc;

namespace Lab250207_ASP_NET_MVC.Controllers
{
    public class TestPartialViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Shiro()
        {
            return View();
        }
        public IActionResult Nanako()
        {
            return View();
        }
        public IActionResult Himawari()
        {
            ViewData["1234"] = "窩不知道";
            return View();
        }
    }
}
