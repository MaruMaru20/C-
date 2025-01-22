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
    public partial class Form2_openfile : Form
    {
        public Form2_openfile()
        {
            InitializeComponent();
        }

        private void Form2_openfile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                
                openFileDialog1.Title = "選擇要開啟的圖片檔案";
                openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"; 
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = false;

                

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string theFile = openFileDialog1.FileName;
                    textBox1.Text = openFileDialog1.FileName;
                    //pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Title = "選擇要開啟的文字檔案";
                openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.DereferenceLinks = true;
                openFileDialog1.Multiselect = false;
                richTextBox1.DetectUrls = true;


                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string theFile = openFileDialog1.FileName; 
                    //Encoding enc = Encoding.GetEncoding("utf-8");
                    richTextBox1.Text = System.IO.File.ReadAllText(theFile);
                    textBox2.Text = openFileDialog1.FileName;
                    



                }
            }
        }



        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            richTextBox1.SelectionColor = default;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {

                richTextBox1.SelectionColor = Color.Red;
            
            
            

        }
    }
}
