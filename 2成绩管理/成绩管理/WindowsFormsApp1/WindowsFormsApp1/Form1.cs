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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Display 显示
        private void Display(object sender, EventArgs e)
        {
            if(!File.Exists("G:\\scoremanagenment.txt"))
            {
                
                File.WriteAllText("G:\\scoremanagenment.txt","");
            }
            string file = File.ReadAllText("G:\\scoremanagenment.txt", UTF8Encoding.Default);
            
            //写文件，把string对象file中的内容写入txt文件中
            //File.WriteAllText("./data.txt", file, UTF8Encoding.Default);

            //追加记录到txt文件中
            //File.AppendAllText("./data.txt", newrecord, UTF8Encoding.Default);
            
           
            //把txt文件中按行存储的信息利用regex.Split按行存入string数组中
            string[] records = Regex.Split(file, "\r\n");

            //开始更新视图
            this.listView1.BeginUpdate();

            //清空原有视图
            this.listView1.Items.Clear();
            // records.Length为数组的元素个数
            for (int index = 0; index < records.Length; index++)
            {   //分割每行记录的各个字段
                string[] components = Regex.Split(records[index], "\t");

                if(records[index].Trim().Length == 0)
                {
                    continue;
                }
                //生成listview的一行
                ListViewItem lvi = new ListViewItem(components);
                //添加背景色
                lvi.SubItems[0].BackColor = Color.Red;
                //把新生成的行加入到listview中
                this.listView1.Items.Add(lvi);
            }
            //视图更新结束
            this.listView1.EndUpdate();

        }

        //Insert 插入数据
        private void Insert(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            
            //利用string的加法操作构造新纪录，作为一行，写入txt文件中
            //string newrecord = this.textBox1.Text + " " + this.textBox2.Text + " " + this.textBox3.Text + " " + this.textBox4.Text + " " + this.textBox5.Text + "\r\n";
            //File.AppendAllText("G:\\scoremanagenment.txt", newrecord, UTF8Encoding.Default);
            //结束form2的调用
            //this.Dispose(false);
        }

        //delete 删除记录
        private void Delete(object sender, EventArgs e)
        {
            try
            { 

                int index = this.listView1.SelectedItems[0].Index;
                this.listView1.Items.RemoveAt(this.listView1.SelectedItems[0].Index);
               
                string file = File.ReadAllText("G:\\scoremanagenment.txt", UTF8Encoding.Default);
                string[] records = Regex.Split(file, "\r\n");
          
                for(int i=0; i<records.Length; i++)
                {
                    if(i != index)
                    {
                        continue;
                    }
                    records[i] = " ";
                }
                File.Delete("G:\\scoremanagenment.txt");
                for (int i = 0; i < records.Length; i++)
                {
                    if (records[i] != "" && records[i] != " ")
                    {
                        records[i] += "\r\n";
                        File.AppendAllText("G:\\scoremanagenment.txt", records[i], UTF8Encoding.Default);
                    }
                }

            }
            catch
            {
                Form4 form4 = new Form4();
                form4.Show();
            }
        }

            
                

        //Search 成绩的查询
        private void Search(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        //排序
        private void Sort(object sender, EventArgs e)
        {
            if (!File.Exists("G:\\scoremanagenment.txt"))
            {
                File.WriteAllText("G:\\scoremanagenment.txt", "");
            }
            string file = File.ReadAllText("G:\\scoremanagenment.txt", UTF8Encoding.Default);
            string[] records = Regex.Split(file, "\r\n");
           
            
            for(int i=0; i<records.Length-1; i++)
            {
                for(int j=records.Length-1; j>i; j--)
                {
                    //这里的字符串可能为空
                    if(records[i].Trim().Length == 0 || records[j].Trim().Length == 0)
                    {
                        continue;
                    }
  
                    string temp1 = Regex.Split(records[i], "\t")[5];
                    string temp2 = Regex.Split(records[j], "\t")[5];

                    if (Convert.ToDouble(temp1) < Convert.ToDouble(temp2))
                    {
                        string temp = records[i];
                        records[i] = records[j];
                        records[j] = temp;
                    }
                }
            }
            File.Delete("G:\\scoremanagenment.txt");
            int range = 1;
            for (int i=0; i<records.Length; i++)
            {
                if(records[i].Trim().Length != 0)
                {
                    string[] components = Regex.Split(records[i], "\t");
                    if (components.Length == this.listView1.Columns.Count)
                    {
                        records[i] = "";
                        for(int index=0; index< this.listView1.Columns.Count-1; index++)
                        {
                            records[i] += components[index] + "\t";
                        }
                        records[i] += range.ToString();
                    }
                    else
                    {
                        records[i] += "\t" + range.ToString();
                    }
                    records[i] += "\r\n";
                    range += 1;
                    File.AppendAllText("G:\\scoremanagenment.txt", records[i], UTF8Encoding.Default);
                }
            }

            Display(sender, e);
        }

        //Clear 
        private void Clear(object sender, EventArgs e)
        {
            //清除屏幕数据并删除txt文件
            this.listView1.Items.Clear();
            //File.Delete("G:\\scoremanagenment.txt");
        }

        //统计
        private void Count(object sender, EventArgs e)
        {
            //先进行排序
            Sort(sender, e);

            string temp = "";
            int[,] array = new int[4,3] { {0,0,0}, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            double[] avg_array = new double[3] { 0,0,0};
            string[] range = new string[5] { "<60", "60-69", "70-79", "80-89", "平均分" };
            int peopleNum = 0;
            File.Delete("G:\\data.txt");
            
            //向data.txt中输入列头
            for(int i=0; i<this.listView1.Columns.Count; i++)
            {
                temp += this.listView1.Columns[i].Text + "\t";
            }
            temp = temp.TrimEnd() + "\r\n";
            File.AppendAllText("G:\\data.txt", temp, UTF8Encoding.Default);

            //向data.txt中输入排名信息
            if (!File.Exists("G:\\scoremanagenment.txt"))
            {
                File.WriteAllText("G:\\scoremanagenment.txt", "");
            }
            string file = File.ReadAllText("G:\\scoremanagenment.txt", UTF8Encoding.Default);
            string[] records = Regex.Split(file, "\r\n");
            for(int i=0; i<records.Length; i++)
            {
                if(records[i].Trim().Length != 0)
                {
                    //统计各个分数段的人数
                    peopleNum += 1;
                    string[] components = Regex.Split(records[i], "\t");
                    for(int index=2; index<components.Length-3; index++)
                    {
                        double grade = Convert.ToDouble(components[index]);
                        avg_array[index - 2] += grade;
                        
                        switch ((int)(grade / 10))
                        {
                            case 10:
                                break;
                            case 9:
                                break;
                            case 8:
                                array[3,index - 2] += 1;
                                break;
                            case 7:
                                array[2, index - 2] += 1;
                                break;
                            case 6:
                                array[1, index - 2] += 1;
                                break;
                            default:
                                array[0, index - 2] += 1;
                                break;
                        }
                    }
                    File.AppendAllText("G:\\data.txt", records[i] + "\r\n", UTF8Encoding.Default);
                }
            }

            //向data.txt中输入统计信息
            temp = "";
            for(int i=2; i<this.listView1.Columns.Count-3; i++)
            {
                temp += this.listView1.Columns[i].Text + "\t";
            }
            temp = "\r\n\r\n\r\n" + "分数段\t" + temp.Trim() + "\r\n";
            File.AppendAllText("G:\\data.txt", temp, UTF8Encoding.Default);

            //输入具体信息
            
            for(int i=0; i<5; i++)
            {
                temp = range[i] + "\t";
                if (i == 4)
                {
                    for(int index=0; index<avg_array.Length; index++)
                    {
                        temp += (avg_array[index] * 1.0 / peopleNum).ToString("0.#") + "\t";
                    }
                    File.AppendAllText("G:\\data.txt", temp.TrimEnd()+"\r\n", UTF8Encoding.Default);
                }
                else
                {
                    for(int index=0; index<3; index++)
                    {
                        temp += array[i,index] + "\t";
                    }
                    File.AppendAllText("G:\\data.txt", temp.TrimEnd() + "\r\n", UTF8Encoding.Default);
                }
            }
            

        }
    }

   

}
