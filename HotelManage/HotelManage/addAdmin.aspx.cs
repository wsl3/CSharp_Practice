using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;

namespace HotelManage
{
    public partial class addAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string constr = ConfigurationManager.ConnectionStrings["HotelConString"].ConnectionString;
            SQLiteConnection con = new SQLiteConnection(constr);
            try
            {
                con.Open();
                string sql = string.Format("insert into admin(username,password) values('{0}','{1}');",username,password);
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();

            }
            catch (SQLiteException error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                con.Close();
                Response.Redirect("adminList.aspx");
            }
        }
    }
}