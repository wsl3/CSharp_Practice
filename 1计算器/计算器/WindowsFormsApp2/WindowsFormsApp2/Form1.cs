using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void On1(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
        }

        private void On2(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
        }

        private void On3(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
        }

        //对中缀表达式进行求值
        private void Caculate(string numbers)
        {
            //2.把中缀表达式转换为后缀表达式
            string[] list = Regex.Split(numbers, " ");

            List<string> exp = new List<string>();
            Stack<string> stack = new Stack<string>();
            Dictionary<string, int> priority = new Dictionary<string, int>();
            priority.Add("(", 1);
            priority.Add("+", 3);
            priority.Add("-", 3);
            priority.Add("*", 5);
            priority.Add("/", 5);
            double temp1=0, temp2=0, temp3=0;

            foreach(string str in list)
            {
                //list[i]是数字
                if(str!="+" && str!="-" && str!="*" && str!="/" && str!="(" && str!=")")
                {
                    exp.Add(str);
                }
                else if(stack.Count==0 || str == "(")
                {
                    stack.Push(str);
                }
                else if(str == ")")
                {
                    
                    while (!(stack.Count==0) && stack.Peek() != "(")
                    {
                        exp.Add(stack.Pop());
                    }
                    if(stack.Count == 0)
                    {
                        this.textBox1.Text = "括号匹配错误";
                        return;
                    }
                    stack.Pop();
                }
                else
                {

                    while(!(stack.Count == 0) && (priority[stack.Peek()] >= priority[str]))
                    {
                        exp.Add(stack.Pop());
                    }
                    stack.Push(str);
                }
            }
            while(!(stack.Count == 0))
            {
                if(stack.Peek() == "(")
                {
                    this.textBox1.Text = "括号匹配错误";
                    return;
                }
                exp.Add(stack.Pop());
                
            }

            //后缀表达式求值
            Stack<double> stack2 = new Stack<double>();
        
            foreach (string str in exp)
            {

                if(str == " " ||str == "")
                {
                    Console.WriteLine("这是空的字符");
                    continue;
                }
                if(str != "+" && str != "-" && str != "*" && str != "/")
                {
                    
                    stack2.Push(Convert.ToDouble(str));
                    continue;
                }

                if(stack2.Count < 2)
                {
                    this.textBox1.Text = "输入错误1";
                    return;
                }
                temp1 = stack2.Pop();
                temp2 = stack2.Pop();
                if(str == "+")
                {
                    temp3 = temp2 + temp1;
                }
                else if(str == "-")
                {
                    temp3 = temp2 - temp1;
                }
                else if(str == "*")
                {
                    temp3 = temp2 * temp1;
                }
                else if(str == "/")
                {
                    if(temp1 == Convert.ToDouble(0))
                    {
                        this.textBox1.Text = "除数不能为0";
                        return;
                    }
                    temp3 = temp2 / temp1;
                }
                stack2.Push(temp3);
            }
            if(stack2.Count == 1)
            {
                this.textBox1.Text = stack2.Pop().ToString();
            }
            else
            {
                this.textBox1.Text = "输入错误！";
            }
        }

        //显示结果
        private void show(object sender, EventArgs e)
        {

        }

        //加法
        private void Onadd(object sender, EventArgs e)
        {
            this.textBox1.Text += "+";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //等于
        private void Onequal(object sender, EventArgs e)
        {
            //1、先把中缀表达式转换为列表
            string numbers = string.Empty;
            int i;
            char s;

            for (i = 0; i < this.textBox1.Text.Length; i++)
            {
                s = this.textBox1.Text[i];
                if (s == ' ')
                {
                    continue;
                }
                //s是数字
                if (s >= '0' && s <= '9')
                {
                    numbers += s.ToString();
                }
                //s是运算符
                else
                {
                    numbers += " " + s + " ";
                }
            }
            //去除字符串首位的空格
            numbers = numbers.Trim();

            //返回运算结果到前端界面
            Caculate(numbers);
            //this.textBox1.Text = result.ToString();
        }
        //减法
        private void Onminus(object sender, EventArgs e)
        {
            this.textBox1.Text += "-";
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void On5(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
        }

        private void On4(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
        }

        private void On6(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
        }
        
        //乘法
        private void Onmultiplicative(object sender, EventArgs e)
        {
            this.textBox1.Text += "*";
        }
        //除法
        private void Ondevides(object sender, EventArgs e)
        {
            this.textBox1.Text += "/";
        }

        private void On7(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void On8(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
        }

        private void On9(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
        }

        private void On0(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
        }

        private void Clear(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void Ondot(object sender, EventArgs e)
        {
            this.textBox1.Text += ".";
        }

        //左括号
        private void Onleft(object sender, EventArgs e)
        {
            this.textBox1.Text += "(";
        }

        //右括号
        private void Onright(object sender, EventArgs e)
        {
            this.textBox1.Text += ")";
        }

        //
        private void Ondelete(object sender, EventArgs e)
        {
            string str = "";
            int i = 0;
            for(i=0; i<this.textBox1.Text.Length-1; i++)
            {
                str = str + this.textBox1.Text[i];
            }
            this.textBox1.Text = str;
        }
    }
}
