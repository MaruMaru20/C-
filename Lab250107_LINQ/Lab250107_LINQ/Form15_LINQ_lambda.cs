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
    public partial class Form15_LINQ_lambda : Form
    {
        public Form15_LINQ_lambda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindEntities northwind = new NorthwindEntities();
            dataGridView1.DataSource = northwind.Customers.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NorthwindEntities northwind = new NorthwindEntities();
            var result = northwind.Customers.Where(Customer => Customer.CustomerID == "ALFKI");
                dataGridView1.DataSource = result.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NorthwindEntities northwind = new NorthwindEntities();

            //想要查詢特定條件 然後從尾部開始排序
            //join() where() orderbydescending()
            //#1先一個一個試

            //var a = northwind.Customers.OrderByDescending(Customer => Customer.CustomerID);

            //var b = northwind.Customers.Where(Customer => Customer.CustomerID == "ALFKI");

            //var c = northwind.Orders.Join(
            //    northwind.Customers,
            //    aa => aa.CustomerID,
            //    bb => bb.CustomerID,
            //    (aa, bb) => new { aa.CustomerID, bb.CompanyName }
            //    );
            //都成功後組合在一起
            var result = northwind.Customers.Where(Customer => Customer.CustomerID == "ALFKI")
                .Join(
                northwind.Customers,
                aa => aa.CustomerID,
                bb => bb.CustomerID,
                (aa, bb) => new { aa.CustomerID, bb.CompanyName })
                .OrderByDescending(Customer => Customer.CustomerID);

            dataGridView1.DataSource = result.ToList();

        }
    }
}
