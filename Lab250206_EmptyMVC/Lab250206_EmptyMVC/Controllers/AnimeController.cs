using Microsoft.AspNetCore.Mvc;

namespace Lab250206_EmptyMVC.Controllers
{
    public class AnimeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Jeff()
        {
            return View();
        }
    }
}
