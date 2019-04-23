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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //Insert 添加数据
        private void Insert(object sender, EventArgs e)
        {
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            string newrecord = this.textBox1.Text + "\t" + this.textBox2.Text + "\t" + this.textBox3.Text + "\t" + this.textBox4.Text + "\t" + this.textBox5.Text + "\t";

            double Allgrade = (Convert.ToDouble(this.textBox3.Text) + Convert.ToDouble(this.textBox4.Text)+ Convert.ToDouble(this.textBox5.Text));
            double Avgrade = Allgrade / 3;
            //保留一位数字
            newrecord += Allgrade.ToString("0.#") + "\t" + Avgrade.ToString("0.#") + "\r\n";
            File.AppendAllText("G:\\scoremanagenment.txt", newrecord, UTF8Encoding.Default);
            //结束form2的调用
            this.Dispose(false);

        }

        //Cancel 取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
        }
    }
}
