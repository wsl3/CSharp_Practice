using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.listView1.Columns.Add("学号", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("姓名", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("数学", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("英语", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("政治", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("总分", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("平均分", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("名次", 100, HorizontalAlignment.Center);
            this.listView1.View = System.Windows.Forms.View.Details;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        //Search 查找学生信息
        private void Search(object sender, EventArgs e)
        {
            string number = this.textBox1.Text;
            string name = this.textBox2.Text;
            string file = File.ReadAllText("G:\\scoremanagenment.txt", UTF8Encoding.Default);
            string[] records = Regex.Split(file, "\r\n");

     
            this.listView1.Items.Clear();
            for (int index = 0; index < records.Length; index++)
            {  
                string[] components = Regex.Split(records[index], "\t");
                //Console.Write(components.Length);
                if (components.Length >= 2)
                {
                    Console.Write(components[0]+components[1]);
                    if(components[0] == number || components[1] == name)
                    {
                        //生成listview的一行
                        ListViewItem lvi = new ListViewItem(components);
                        //添加背景色
                        lvi.SubItems[0].BackColor = Color.Red;
                        //把新生成的行加入到listview中
                        this.listView1.Items.Add(lvi);
                    }
                }
                   
                
            }
            this.listView1.EndUpdate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
