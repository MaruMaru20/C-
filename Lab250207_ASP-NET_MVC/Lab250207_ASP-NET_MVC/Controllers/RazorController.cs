using Microsoft.AspNetCore.Mvc;

namespace Lab250207_ASP_NET_MVC.Controllers
{
    public class RazorController : Controller
    {
        public const string SessionKeyName = "_Where";

        public IActionResult Index()
        {
            ViewBag.Name = "丘~~~~~~";
            ViewData["MMM"] = "公";
            TempData["FFF"] = "母";

            ViewBag.where = "台北";
            ViewBag.where2  = "台中";
            ViewBag.where3 = "高雄";

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "居住地:");
            }
            return View();


        }
    }
}
