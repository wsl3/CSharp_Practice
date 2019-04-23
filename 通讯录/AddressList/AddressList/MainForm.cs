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

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Sql sql = new Sql("address");
        private void Form1_Load(object sender, EventArgs e)
        {

            //主窗口加载，先显示login窗口
            Login loginForm = new Login();
            loginForm.ShowDialog();

            //加载时间
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString();

            //从数据库中读出所有数据并显示
            showAll();
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert insertForm = new Insert();
            insertForm.Show();

        }

        private void 浏览用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAll();
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete deleteForm = new Delete();
            deleteForm.Show();
        }
        public void showAll(string strcmd = "select * from telephoneinfo;")
        {
            this.listView1.Items.Clear();
            List<List<string>> result = sql.ReadAll(strcmd);
            for (int row = 0; row < result.Count; row++)
            {
                ListViewItem item = new ListViewItem(result[row][0]);
                for (int col = 1; col < result[row].Count; col++)
                {
                    item.SubItems.Add(result[row][col]);
                }
                this.listView1.Items.Add(item);
            }
        }
        public void search(string strcmd)
        {
            strcmd = string.Format("select * from telephoneinfo where name='{0}';", strcmd);
            showAll(strcmd);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 搜索用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search searchForm = new Search();
            searchForm.sendmsg += new SendValue(search);
            searchForm.Show();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Sql
    {
        private MySqlConnection con;
        
        public Sql(string DATABASE = "test", string USERNAME = "wsl3", string PASSWORD = "wsl3")
        {
            string str = string.Format("Server=127.0.0.1;User ID={0};Password={1};Database={2};Charset=utf8;", USERNAME, PASSWORD, DATABASE);
            con = new MySqlConnection(str);//实例化链接
            con.Open();
        }
        ~Sql()
        {
            con.Close();
        }
        public List<List<string>> ReadAll(string strcmd)
        {
            List<List<string>> result = new List<List<string>>();
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                List<string> temp = new List<string>();
                for(int i=0;i<reader.FieldCount;i++)
                {
                    temp.Add(reader[i].ToString());
                }
                result.Add(temp);
               
            }
            reader.Close();
            return result;
        }
        //增
        public void Execute(string strcmd)
        {

            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            int lines = cmd.ExecuteNonQuery();
            if(lines>0)
            {
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show("操作失败！");
            }
        }
/*        //删
        public void Delete(string strcmd)
        {
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            cmd.ExecuteNonQuery();
        }
        //改
        public void Update(string strcmd)
        {
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            cmd.ExecuteNonQuery();
        }*/
        //查
        public void Search(string strcmd)
        {
            
        }

    }
}
