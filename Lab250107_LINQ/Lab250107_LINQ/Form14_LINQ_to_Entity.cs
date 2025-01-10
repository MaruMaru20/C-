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
    public partial class Form14_LINQ_to_Entity : Form
    {

        //請先參閱Form 前置01 02jpg
        public Form14_LINQ_to_Entity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindEntities xa = new NorthwindEntities();
            var result = from xb in xa.Customers select xb;
            dataGridView1.DataSource = result.ToList();//沒有tolist會印出型態
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NorthwindEntities xa = new NorthwindEntities();
            var result = from xb in xa.Customers where xb.CustomerID == "ALFKI" select xb;
            dataGridView1.DataSource = result.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            NorthwindEntities xa = new NorthwindEntities();
            var result = from o in xa.Orders 
                         join c in xa.Customers on o.CustomerID equals c.CustomerID
                         where o.CustomerID == "ALFKI" 
                         orderby c.CustomerID descending //後來加入的 同desc
                         select new  { o.OrderID,c.CompanyName };
            dataGridView1.DataSource = result.ToList();

            //End of Form14
        }
    }
}
