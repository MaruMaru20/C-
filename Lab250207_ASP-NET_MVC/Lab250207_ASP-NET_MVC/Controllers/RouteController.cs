using System;
using Microsoft.AspNetCore.Mvc;

namespace Lab250207_ASP_NET_MVC.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public string Mouse(string id) {
        //    return "<@~" + id;
        //}

        public string Mouse(string apple, string bee, string id)
        {
            string data = $"米老鼠 id:{id}  apple:{apple}  bee:{bee}";
            return data;
        }
        /*
         

    ----------------------------------------------------------------------------------
    問題： 若URL 為 http://localhost:XXXX/TestRoute/Mouse/123
        則回傳字串中的 id 、 apple 、 bee 三者各自會呈現什麼？ 


    答案：  米老鼠 id:123  apple:  bee:
     
    -----------------------------------------
    問題： 若URL 為 http://localhost:XXXX/TestRoute/Mouse/123/456
        則回傳字串中的 id 、 apple 、 bee 三者各自會呈現什麼？ 


    答案： id: apple:123 bee:456


    -----------------------------------------
    問題： 如果把 MouseA 和 MouseB 執行的順序交換，是否還會得到相同的測試結果？


    答案：不?
        id:123  apple:  bee:>>>id:  apple:123  bee:
         
    -----------------------------------------
    問題： 為什麼 id 、 apple 、 bee 這三者不能同時有值？


    答案： 沒有路由


 



         */
        public string Duck() {
            string x = HttpContext.Request.Query["cat"];
            string y = HttpContext.Request.Query["dog"];
            return "唐老鴨" + x + "和" + y;

        }
        public string Rabbit(string id)
        {

            string data = $"id:{id}  ";
            return data;

        }
        public string prod() 
        {
            
            return "123";
        }

    }
}
