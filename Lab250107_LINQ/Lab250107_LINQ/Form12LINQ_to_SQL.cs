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
    public partial class Form12LINQ_to_SQL : Form
    {
        public Form12LINQ_to_SQL()
        {
            InitializeComponent();
        }

        private void Form12LINQ_to_SQL_Load(object sender, EventArgs e)
        {
            //01.先新增 dataGridView button label
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* 
             因為想要使用 MyDataClasses1DataContext類別 底下的 Products類別 ，
             所以要 new MyDataClasses1DataContext類別 來獲得使用權
            */

            //02.從昨天的LINQ to SQL 
            //新增查詢語法 查詢資料  from  in  select
            //綁定dataGridView
            MyDataClasses1DataContext xa = new MyDataClasses1DataContext(); //你的LINQ to SQL
            var result = from data in xa.Products select data;
            dataGridView1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //03.新增一個按鈕 *挑選產品資料表*
            //新增查詢語法 這次要挑選資料 要 where
            MyDataClasses1DataContext xa = new MyDataClasses1DataContext(); //你的LINQ to SQL

            var result = from data in xa.Products where data.ProductID == 1 select data;
            dataGridView1.DataSource = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //04. 新增一個按鈕  
            //SQL語法參閱 SQL-join.jpg
            //JOIN :  from join on select
            MyDataClasses1DataContext xa = new MyDataClasses1DataContext(); //你的LINQ to SQL
            var result = from od in xa.Order_Details
                         join p in xa.Products
                         on od.ProductID equals p.ProductID
                         where od.OrderID == 10285  //#3這是最後加入的 要查詢特定ID 
                         select p;  // 查詢結束#1


                        //#2
                        //想要同時看到 p跟od的資料 訂單編號及 產品名稱
                        //所以用了  {}
                        //以前的new int[] {1,2,3,4}
                        //            同AS      訂單編號 ,     同AS      產品名稱
                        //select new { OrderID = od.OrderID, ProductName = p.ProductName };// #2類型型別型態的宣告

            dataGridView1.DataSource = result;


            
            //END.創建表單13
        }
    }
}
