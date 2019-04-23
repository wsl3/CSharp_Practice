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
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }


        private void insert_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(name.Text.Trim()==""||sex.Text.Trim()==""||officetel.Text.Trim()==""||hometel.Text.Trim()==""||mark.Text.Trim()=="")
            {
                MessageBox.Show("不能为空！");
            }
            else
            {
                string strcmd = string.Format("insert into telephoneinfo(name,sex,officetel,hometel,mark) values('{0}','{1}','{2}','{3}','{4}');", name.Text,sex.Text,officetel.Text,hometel.Text,mark.Text);
                Sql sql = new Sql("address");
                sql.Execute(strcmd);
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "" || sex.Text.Trim() == "" || officetel.Text.Trim() == "" || hometel.Text.Trim() == "" || mark.Text.Trim() == "")
            {
                MessageBox.Show("不能为空！");
            }
            else
            {
                string strcmd = string.Format("update telephoneinfo set name='{0}',sex='{1}',officetel='{2}',hometel='{3}',mark='{4}' where name='{0}'", name.Text, sex.Text, officetel.Text, hometel.Text, mark.Text);
                Sql sql = new Sql("address");
                sql.Execute(strcmd);
                this.Close();
            }
        }
    }
}
