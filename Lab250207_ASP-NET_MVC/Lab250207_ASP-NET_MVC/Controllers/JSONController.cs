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
            //希望清單裡有2個產品
            List<Product> xa = new List<Product>();
            
            Product apple = new Product();
            apple.PDescription = "None";
            apple.PName = "apple";
            Product bpple = new Product();
            bpple.PDescription = "None";
            bpple.PName = "bpple";

            xa.Add(apple);
            xa.Add(bpple);

            return Json(xa);
        }

    }
}
