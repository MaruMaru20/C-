using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab250122_NET_UNIT
{
    public partial class Form4_renamefile : Form
    {
        public Form4_renamefile()
        {
            InitializeComponent();
        }

        private void Form4_renamefile_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox2.SelectionMode = SelectionMode.MultiExtended;
            listBox1.HorizontalScrollbar = true;

            button2.Enabled = false;
            button3.Enabled = false;

        }
        //private void select_folder(TextBox GO)
        //{
        //    FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        GO.Text = openFileDialog1.SelectedPath;
        //    }
        //}


        //選擇檔案 限定TXT(非資料夾) OpenFileDialog
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "選擇要開啟的文字檔案";
            openFileDialog1.Filter = "Text Files (.txt)|";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] theFile = openFileDialog1.FileNames;
                textBox1.Text = System.IO.Path.GetDirectoryName(theFile[0]);
                foreach (string files in theFile)
                {
                    listBox1.Items.Add(files);

                }
                button2.Enabled = true;

            }

        }
        //選擇資料夾 FolderBrowserDialog
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.Description = "選擇要開啟的資料夾";
            folderBrowserDialog1.ShowNewFolderButton = false;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = folderBrowserDialog1.SelectedPath;
                textBox2.Text = selectedFolder;
            }
            button3.Enabled = true;
        }



        private void button3_Click(object sender, EventArgs e)
        {

            foreach (var item in listBox1.Items)
            {
                string originalPath = item.ToString();
                string fileName = Path.GetFileName(originalPath);
                string extension = Path.GetExtension(originalPath);
                string time = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{time}{extension}";

                //最終路徑--新命名檔案
                string NewPath = Path.Combine(textBox2.Text, newFileName);

                //會將來源改名並移動到 NewPath
                File.Move(originalPath, NewPath); 

                listBox2.Items.Add(NewPath);

            }
            listBox1.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
