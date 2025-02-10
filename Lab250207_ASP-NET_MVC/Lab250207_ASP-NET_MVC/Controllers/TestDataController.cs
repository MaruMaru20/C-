using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Lab250207_ASP_NET_MVC.Controllers
{
    public class TestDataController : Controller
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";
        public IActionResult Index()
        {
            ViewBag.A1 = 7;
            ViewBag.A2 = "皮卡丘";
            ViewData["A3"] = "鯊魚可愛";
            TempData["A4"] = "我愛鯊鯊";
            //算數
            ViewBag.Q1 = 5;
            ViewData["Q2"] = 5;
            TempData["Q3"] = 5;
            //日期
            ViewBag.D1 = DateTime.Now;//date + datetime + datetime-local
            ViewBag.D2 = DateTime.Now.ToString("yyyy-MM-dd"); //date + datetime
            ViewBag.D3 = DateTime.Now.ToString("yyyy-MM-dd-HH:mm");//date +  datetime-local

            TempData["H1"] = "吃飯嚕";
            TempData["H2"] = "去打針";

            return View();

        }
        public IActionResult DataDog()
        {
            ViewBag.A2 = "皮卡丘(汪汪?)";

            return View();
        }
        public IActionResult DataCat()
        {
            return View();
        }
        public IActionResult DataSession()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "The Doctor");
                HttpContext.Session.SetInt32(SessionKeyAge, 73);
            }
            return View();
        }
    }
}
