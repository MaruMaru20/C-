using Microsoft.AspNetCore.Mvc;

namespace Lab250207_ASP_NET_MVC.Controllers
{
    public class TestViewController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", "皮卡丘");
            //return View();
        }
        public IActionResult Bob()
        {
            //*
            //未來可以應用的情境是什麼？
            //答案：
            // if order > 0
            //*
            if (true)
            {
                return View();

            }
            else
            {
                return View("Pikachu");
                //return View("/Views/TestView/Pikachu.cshtml"); OK
                //return View("./Views/TestView/Pikachu.cshtml"); OK
                //return View("~/Views/TestView/Pikachu.cshtml"); OK
                //return View("/TestView/Pikachu.cshtml"); NG

            }

        }
        public IActionResult Olaf()
        {
            ViewBag.Q1 = "8877";
            TempData["QQ"] = "7788";
            return View();
        }
        public IActionResult Elsa()
        {/*
              練習： return View("Olaf");
    執行結果： 不會回傳 IActionResult Olaf的文字
               因為沒有經過action


    練習： return Redirect("~/TestView/Olaf");
    執行結果： 會回傳網頁文字


    練習： return RedirectToAction("Olaf", "TestView");
    執行結果： 會回傳網頁文字


    練習： return RedirectToAction(controllerName:"TestView", actionName:"Olaf");
    執行結果： 

          */
            return RedirectToAction(controllerName: "TestView", actionName: "Olaf");
        }
        [ActionName("ILoveOnePiece")]  //不讓你看 保護
        public IActionResult Pikachu()
        {
            return View("Pikachu");
        }
    }
}
