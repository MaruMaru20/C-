using Microsoft.AspNetCore.Mvc;

namespace Lab250207_ASP_NET_MVC.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Member()
        {
            ViewBag.MName = "小鯊魚傑夫";
            ViewBag.MGender = "男";
            ViewBag.MCity = "台南";

            return View();
        }

        public IActionResult Member2()
        {
            ViewBag.MName = "小鯊魚傑夫";
            ViewBag.MEmail = "asyoucansee@hotmail.com";
            ViewBag.MCity = "台南";
            return View();
        }
    }
    
    
}

