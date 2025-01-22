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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
            label1.Text += textBox1.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //label2.Text += comboBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void button3_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("TPE", "台北");
            dc.Add("TCG", "台中");
            dc.Add("KS", "高雄");
            //err: req Ilist
            comboBox2.DataSource = new BindingSource(dc,null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
            //label3.Text = "地點: " + ((KeyValuePair<string,string>)comboBox2.SelectedItem).key;
            //label4.Text =  comboBox2.SelectedValue.ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "地點: " + ((KeyValuePair<string, string>)comboBox2.SelectedItem).Value;

            label4.Text = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;

        }
    }
}
