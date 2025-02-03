using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab250122_NET_UNIT
{

    public partial class Form6_DB_review : Form
    {

        public Form6_DB_review()
        {
            InitializeComponent();
        }
        DB myDB = new DB();
        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=AdventureWorksDW2022;Integrated Security=True;TrustServerCertificate=True");
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand  cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM DimPromotion";
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM DimCurrency";

            DataTable dt = myDB.GetDataTable(sql, "Dim");

            dataGridView1.DataSource = dt;
        }

        //多條件
        private void button3_Click(object sender, EventArgs e)
        {

            //string sql = textBox1.Text;
            //DataTable dt = myDB.GetDataTable(textBox1.Text, "Dim",);

            dataGridView1.DataSource = myDB.GetDataTable(textBox1.Text,textBox2.Text,textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<string,string> condition = new Dictionary<string,string>();
            condition.Add(textBox2.Text, textBox3.Text);
            condition.Add(textBox4.Text, textBox5.Text);
            dataGridView1.DataSource = myDB.GetDataTable(textBox1.Text,condition);

            //SELECT* FROM DimCustomer where CustomerKey = @1 and GeographyKey< @2
            //select* from Products where CategoryID = @1 and UnitPrice > @2




        }

        private void Form6_DB_review_Load(object sender, EventArgs e)
        {

        }
    }
}
