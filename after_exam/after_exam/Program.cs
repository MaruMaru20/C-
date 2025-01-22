using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace after_exam
{
    internal class Program
    {
        static void P1_about_enum()
        {
            Console.WriteLine("\r\n ");
            //enum     ->    可以寫在class的內部或外部
            //enum     ->    外部 只需列舉名稱      furit
            //enum     ->    內部 類別名稱.列舉名稱 Demo.Data

            //enum     ->    key value兩兩一組的結合
            //enum     ->    透過 資料 取得 數字(要轉型)
            //enum     ->    透過 數字 取得 資料(指定列舉)
            //外部
            Console.WriteLine(furit.B);  //想要取得value
            Console.WriteLine((int)furit.B);  //資料轉型
            Console.WriteLine((furit)100);
            //內部 
            Console.WriteLine((Demo.Data)0); //要public才能取得內容
            Console.WriteLine((int)Demo.Data.content3); //資料轉型


        }

        static void P2_parameter()
        {
            //Q1:參數 parameter = 引數 argument? Y 
            //Q2: Is this two are Key?           NO


            string x = "豪爽歐";
            int y = 100;
            string z = "撿到億百塊";
            Console.WriteLine($"{x},{y},{z}");
        }

        static void P3_Interface()
        {
            COCO s1 = new COCO();
            Console.WriteLine(s1.Bubble);
            Console.WriteLine(s1.Tea);
        }

        static void P4_int_init()
        {
            Test s1 = new Test();
        }

        static void Main(string[] args)
        {
            //P1_about_enum();
            //P2_parameter();
            //P3_Interface();
            P4_int_init();
        }
    }
}
