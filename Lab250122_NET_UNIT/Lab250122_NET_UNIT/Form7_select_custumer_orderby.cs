using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab250122_NET_UNIT
{
    public partial class Form7_select_custumer_orderby : Form
    {

        //select Distinct  EnglishEducation
        //from DimCustomer

        //--CustomerKey,FirstName,LastName,BirthDate,Gender,
        private DataTable xxa;
        public Form7_select_custumer_orderby()
        {
            InitializeComponent();
        }
        
        private void Form7_select_custumer_orderby_Load(object sender, EventArgs e)
        {
            DB myDB = new DB();
            string sql = "select Distinct  CustomerKey,FirstName,LastName,BirthDate,Gender,EnglishEducation\r\nfrom DimCustomer";
            xxa = myDB.GetDataTable(sql,"xxa");
            dataGridView1.DataSource = xxa;
        }

        private void radioButton_Orderby_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton xa = (RadioButton)sender;
            if (xa.Checked == true)
            {

                switch (xa.Text)
                {
                    //選擇性名
                    //第2步驟 全域變數增加 private DataTable xxa;
                    //從原本的 dataGridView1.DataSource = myDB.GetDataTable(sql, "xxa");
                    //改成 xxa = myDB.GetDataTable(sql, "xxa")
                    //加上 dataGridView1.DataSource = xxa;

                    case "FirstName":
                        //查詢語法:
                        //var apple = from bee
                        //            in xxa.AsEnumerable()
                        //            orderby bee.Field<string>("FirstName"), bee.Field<string>("LastName")//3
                        //            select bee;
                        //dataGridView1.DataSource = apple.CopyToDataTable();//更新datatable
                        //方法語法:
                        var bpple = xxa.AsEnumerable()
                            .OrderBy(xb => xb.Field<string>("FirstName")).ThenBy(xb => xb.Field<string>("LastName"));
                        dataGridView1.DataSource = bpple.CopyToDataTable();
                        break;
                    case "BirthDate":
                        //查詢語法:
                        //var apple2 = from bee
                        //            in xxa.AsEnumerable()

                        //             orderby bee.Field<DateTime>("BirthDate")
                        //             select bee;
                        //dataGridView1.DataSource = apple2.CopyToDataTable();
                        //方法語法:
                        var bpple2 = xxa.AsEnumerable()
                        .OrderBy(xb => xb.Field<DateTime>("BirthDate"));
                        dataGridView1.DataSource = bpple2.CopyToDataTable();
                        break;
                    default:
                        break;
                }
            }
        }

        private void radioButton_Filter_CheckedChanged(object sender, EventArgs e) 
        {
            RadioButton xa = (RadioButton)sender;
            //MessageBox.Show(xa.Text);

            if (xa.Checked == true)
            {
                //查詢語法:
                //var data = from row in xxa.AsEnumerable()
                //           where row.Field<string>("EnglishEducation") == xa.Text
                //           select row;
                //dataGridView1.DataSource = data.CopyToDataTable();
                //方法語法:
                var data = xxa.AsEnumerable().Where(oUo => oUo.Field<string>("EnglishEducation") == xa.Text);
                dataGridView1.DataSource = data.CopyToDataTable();

            }
        }
    }

}
