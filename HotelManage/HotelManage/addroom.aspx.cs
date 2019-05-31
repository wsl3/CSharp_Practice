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
    public partial class addroom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string roomtype = Request.Form["roomtype"];
            string info = Request.Form["info"];
            string charge = Request.Form["charge"];

            string constr = ConfigurationManager.ConnectionStrings["HotelConString"].ConnectionString;
            SQLiteConnection con = new SQLiteConnection(constr);
            try
            {
                con.Open();
                string sql = string.Format("insert into room(roomtype,info,charge) values('{0}','{1}','{2}');", roomtype,info,charge);
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
                Response.Redirect("index.aspx");
            }
        

        }
    }
}