using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace HotelManage
{
    public partial class adminList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            this.AdminDataBind();
        }
        public void AdminDataBind()
        {
            string constr = ConfigurationManager.ConnectionStrings["HotelConString"].ConnectionString;
            SQLiteConnection con = new SQLiteConnection(constr);
            con.Open();

            string query = "select id,username from admin;";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            con.Close();
        }
    }
}