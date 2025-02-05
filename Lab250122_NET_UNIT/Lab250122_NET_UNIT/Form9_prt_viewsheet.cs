using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab250122_NET_UNIT
{
    public partial class Form9_prt_viewsheet : Form
    {
        public Form9_prt_viewsheet()
        {
            InitializeComponent();
        }
        DB myDB = new DB();
        private void Form9_prt_viewsheet_Load(object sender, EventArgs e)
        {
            //**底下使用 Northwind ，希望透過現有資料表 / 檢視表完成產品銷售查詢動作 * *

            // 18.會使用到的檢視表為 Sales by Category

            //請嘗試透過SQL指令確認檢視表存在並且可以讀取

            // 20.請在表單開啟時就帶入產品類別到下拉選單中

            // 在使用者點選查詢按鈕後，根據產品類別以及銷售金額前往資料庫帶出正確的資料

            string Sql = "SELECT CategoryID, CategoryName FROM Categories";
            comboBox1.DataSource = myDB.GetDataTable(Sql,"123");
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid = ((DataRowView)comboBox1.SelectedItem).Row.ItemArray[0].ToString();
            string price = textBox1.Text;
            //MessageBox.Show($" 類 + {cid} 錢 {price}");
            string sql = "select * from [Sales by Category] where CategoryID = @cid and ProductSales > @price";
            Dictionary<string,string> dc = new Dictionary<string,string>();
            dc.Add("@cid", cid);
            dc.Add("@price", price);


            dataGridView1.DataSource = myDB.GetDataTable(sql, dc);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
