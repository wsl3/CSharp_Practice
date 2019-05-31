using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Configuration;

namespace HotelManage
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]!=null)
            {
                Response.Redirect("index.aspx");
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string constr = ConfigurationManager.ConnectionStrings["HotelConString"].ConnectionString;
            SQLiteConnection con = new SQLiteConnection(constr);
            try
            {
                con.Open();
                string sql = string.Format("select * from admin where username='{0}' and password='{1}';", username, password);
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                SQLiteDataReader res = cmd.ExecuteReader();
                if (res.Read())
                {
                    res.Close();
                    Session["username"] = username;
                    //Response.Write(username);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    res.Close();
                    Response.Redirect("login.aspx");
                }
                
              
            }
            catch (SQLiteException error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                
                con.Close();
            }
        }
    }
}