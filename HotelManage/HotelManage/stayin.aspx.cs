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
    public partial class stayin : System.Web.UI.Page
    {
        private string roomID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]==null)
            {
                Response.Redirect("login.aspx");
            }
            roomID = Request.QueryString.Get("id");
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = Request.Form["name"];
            string iphone = Request.Form["iphone"];
            string constr = ConfigurationManager.ConnectionStrings["HotelConString"].ConnectionString;

            SQLiteConnection con = new SQLiteConnection(constr);
            try
            {
                con.Open();
                string sql = string.Format("insert into customer(name,iphone) values('{0}','{1}');", name,iphone);
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
                
                cmd.CommandText = "select id from customer order by id desc;";
                SQLiteDataReader res = cmd.ExecuteReader();
           
                if(res.Read())
                {
                    int customerID = res.GetInt32(0);
                    res.Close();
                    string updateString = string.Format("update room set customer_id={0} where room.id={1};",customerID,roomID);
                    cmd.CommandText = updateString;
                    cmd.ExecuteNonQuery();
                }
                Response.Redirect("index.aspx");

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