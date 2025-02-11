using Microsoft.AspNetCore.Mvc;

namespace Lab250207_ASP_NET_MVC.Controllers
{
    public class JSONController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult ProductData()
        { 
            List<Member> xa = new List<Member>();

            return Json(xa);
        }
    }
}
