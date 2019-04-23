using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressList
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text.Trim()=="")
            {
                MessageBox.Show("用户名不能为空！");
            }
            else
            {
                Sql sql = new Sql("address");
                string cmd = string.Format("delete from telephoneinfo where name='{0}';", this.textBox1.Text);
                sql.Execute(cmd);
                this.Close();
            }

        }
    }
}
