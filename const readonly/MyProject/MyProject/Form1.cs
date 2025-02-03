using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClassLibrary;

namespace MyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //const 的值在編譯時內嵌，因此修改後需要重新建置所有引用該常量的程序集。
            label1.Text = MSIT62.classroom;
            //static會在每次啟動時給值
            label2.Text = MSIT62.hours;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cool cool = new Cool();
            label3.Text =cool.Hi();

        }
    }
}
