using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab250107_LINQ
{
    public partial class Form13_LINQ_Lambda : Form
    {
        public Form13_LINQ_Lambda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //

            MyDataClasses1DataContext db = new MyDataClasses1DataContext();
            var result = db.Products.Select(x => x);

            dataGridView1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyDataClasses1DataContext db = new MyDataClasses1DataContext();
            var result = db.Products.Where(x => x.ProductID == 1);
            //var result = db.Order_Details.Where(x => x.OrderID == 10285);

            dataGridView1.DataSource = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyDataClasses1DataContext db = new MyDataClasses1DataContext();

            //SQL語法參閱 SQL-join.jpg

            //官方文件: C# LINQ JOIN
            //var query = students.Join(departments,
            //    student => student.DepartmentID,
            //    department => department.ID,
            //    (student, department) => new { Name = $"{student.FirstName} {student.LastName}", DepartmentName = department.Name });


            /* 
               var 隨意名稱變數 = 表1.Join(表2,

               代表表1的隨意名稱變數1 => 表1.A欄位(與表2.B欄位建立連結的欄位), 

               代表表2的隨意名稱變數2 => 表2.B欄位(與表1.A欄位建立連結的欄位),

               (表1, 表2) =>new { 畫面要顯示的欄位1名稱 = 表1.A欄位, 畫面要顯示的欄位2名稱 = 表2.B欄位 }        ---> 位置可自行安排

               );

            */
            /*表1 JOIN(表2,
             * 表1別名 => 表1別名.建立連結的欄位,
             * 表2別名 => 表2別名.建立連結的欄位,
               (表1別名,表2別名) => New {表1別名.欄位,表2別名.欄位} );

            */
            //#1
            //var result = db.Order_Details.Join(
            //    db.Products,
            //    od => od.ProductID,
            //    p => p.ProductID,
            //    (od,p) => new { od.OrderID, p.ProductID }
            //    );
            //dataGridView1.DataSource = result;

            //#2 正名
            var result2 = db.Order_Details.Join(
    db.Products,
    Order_Details => Order_Details.ProductID,
    Products => Products.ProductID,
    (Order_Details, Products) => new { Order_Details.OrderID, Products.ProductID }

    );
dataGridView1.DataSource = result2;

            //End of Form13
}

        private void Form13_LINQ_Lambda_Load(object sender, EventArgs e)
        {

        }
    }
}
