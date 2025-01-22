using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace after_exam
{
    enum furit
    {
        A = 100,
        B = 100,
        C = 200,
    }

    class Demo
    {
        public enum Data
        {
            content,
            content2,
            content3

        }
    }
    public interface IBubbleTea
    {
        //欄位
        //變數(Ｘ) 屬性(Ｏ) 方法(／＼) 建構子(Ｘ)

        string Bubble {  get; }
        string Tea {  get; }

    }
    class COCO : IBubbleTea
    {
        public string Bubble { get { return "白珠珠"; } }
        public string Tea { get { return "一般紅茶"; } }

    }
    class Test
    {
        int xa;
        public Test() 
        {
            Console.WriteLine("CLASS");
            Console.WriteLine(xa);
        }
    }

}
