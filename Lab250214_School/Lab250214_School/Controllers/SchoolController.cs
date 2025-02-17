using Microsoft.AspNetCore.Mvc;

namespace Lab250214_School.Controllers
{
    public class SchoolController : Controller
    {
        List<Student> students = new List<Student>
        {
            new Student{sID=1, sName="Pikachu", Chinese=100, English=90, Math=60},
            new Student{sID=12, sName="Mary", Chinese=92, English=82, Math=60},
            new Student{sID=23, sName="Lisa", Chinese=98, English=91, Math=94},
            new Student{sID=34, sName="John", Chinese=63, English=85, Math=55},
            new Student{sID=45, sName="David", Chinese=59, English=77, Math=82}


        };

        
        public IActionResult Index()
        {
            //01.設定一個TEMPDATA 轉換成JSON系列物件
            //TempData["Students"] = Newtonsoft.Json.JsonConvert.SerializeObject(students);
            students.ForEach(s => s.Total = (s.Chinese + s.English + s.Math));
            return View(students);
        }
        public IActionResult Edit(int sID) 
        {



            // 02.找出對應的學生
            // (在        students 單找到對應的          值 
            students.ForEach(s => s.Total = (s.Chinese + s.English + s.Math));
            var student = students?.FirstOrDefault(s => s.sID == sID);


                    return View(student);



        }
    }
}
