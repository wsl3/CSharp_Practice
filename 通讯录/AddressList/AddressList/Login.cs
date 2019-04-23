using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AddressList
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text.Trim() == "" || password.Text.Trim() == "")
            {
                MessageBox.Show("请完整填写用户信息", "提示");
            }
            else
            {
                if(username.Text.Trim()=="wsl3" && password.Text.Trim()=="wsl3")
                {
                    MessageBox.Show("登录成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户信息有误，请重新登录！");
                    username.Text = "";
                    password.Text = "";
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

