using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab250122_NET_UNIT
{
    public partial class Form3_calculator : Form
    {
        public Form3_calculator()
        {
            InitializeComponent();
        }

        private void Form3_calculator_Load(object sender, EventArgs e)
        {
            //button10.Enabled = false;
        }
        private void click_btn(object sender, EventArgs e)
        {
            if (label3.Text != "0")
            {
                //button10.Enabled = true;
                label3.Text += (sender as Button).Text;
            }
            else
            {
                label3.Text = (sender as Button).Text;

            }



        }

        private void sympol_btn(object sender, EventArgs e)
        {
            //label3.Text = label2.Text;
            //Button btn = (Button)sender;


            label2.Text = label3.Text + ((Button)sender).Text;
            label3.Text = string.Empty;
        }
        private void equal_btn(object sender, EventArgs e)
        {
            
            
                string operation = Regex.Match(label2.Text, @"[\+\-]").Value; // 抓取 +, -, *, /
                string[] numbers = label2.Text.Split(new[] { operation }, StringSplitOptions.None);

                if (numbers.Length == 2)
                {
                    double num1 = Convert.ToDouble(numbers[0]);
                    double num2 = Convert.ToDouble(label3.Text);
                    double result = 0;

                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                    }

                    label3.Text = result.ToString();
                    label2.Text = string.Empty; 
                }

            

        }
    }
}
