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

//    select ProductCategoryKey, EnglishProductCategoryName from DimProductCategory
//select ProductCategoryKey ID,EnglishProductSubcategoryName English,
//SpanishProductSubcategoryName Spanish,
//FrenchProductSubcategoryName French
//from DimProductSubcategory
//where ProductCategoryKey = 2
    public partial class Form8_product_Category : Form
    {
        public Form8_product_Category()
        {
            InitializeComponent();
        }
        DB myDB = new DB();
        private void Form8_product_Category_Load(object sender, EventArgs e)
        {

            

        }

        private void DictBtn_Click(object sender, EventArgs e)
        {
            string sql = "select ProductCategoryKey,EnglishProductCategoryName from DimProductCategory";
            DataTable dt = myDB.GetDataTable(sql, "ProductCategory");
            Dictionary<string, string> tmp = myDB.GetDataTable(sql);
            comboBox1.DataSource = new BindingSource(tmp,null);
            comboBox1.DisplayMember = "Value";

            comboBox1.ValueMember = "Key";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string key = ((keyValuePair<string,string>)comboBox1.SelectedItem).Key;
            string key = ((KeyValuePair<string,string>)comboBox1.SelectedItem).Key;
            string sql = @"select ProductCategoryKey ID,EnglishProductSubcategoryName English,
                        SpanishProductSubcategoryName Spanish,
                        FrenchProductSubcategoryName French
                        from DimProductSubcategory
                        where ProductCategoryKey =@id";
            dataGridView1.DataSource = myDB.GetDataTable(sql, "@id", key);


        }

        private void TableBtn_Click(object sender, EventArgs e)
        {
            string sql = "select ProductCategoryKey,EnglishProductCategoryName from DimProductCategory";
            comboBox2.DataSource = myDB.GetDataTable(sql, "EnglishProductCategoryName");
            comboBox2.DisplayMember = "EnglishProductCategoryName"; 
            comboBox2.ValueMember = "ProductCategoryKey";
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;



        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((DataRowView)comboBox2.SelectedItem).Row.ItemArray[0].ToString();

            string sql = @"select ProductCategoryKey ID,EnglishProductSubcategoryName English,
                        SpanishProductSubcategoryName Spanish,
                        FrenchProductSubcategoryName French
                        from DimProductSubcategory
                        where ProductCategoryKey =@id";

            dataGridView1.DataSource = myDB.GetDataTable(sql, "@id", key);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create viewsheet
            //SQL  檢視表  與  資料表  的差異是什麼?
            //資料表 select up date insert delete
            //檢視表 selete only
        }
    }
}
