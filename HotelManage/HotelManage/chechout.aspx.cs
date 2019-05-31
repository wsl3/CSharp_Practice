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
    public partial class chechout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
          

            string roomid = Request.QueryString.Get("id");
            string customerid = Request.QueryString.Get("customerid");
            string constr = ConfigurationManager.ConnectionStrings["HotelConString"].ConnectionString;
            SQLiteConnection con = new SQLiteConnection(constr);
            try
            {
                con.Open();
                string sql = string.Format("update customer set leave='离开'where id={0};",customerid);
                SQLiteCommand cmd = new SQLiteCommand(sql, con);

                cmd.ExecuteNonQuery();
                cmd.CommandText = "update room set customer_id=NULL where id=" + roomid +";";
                cmd.ExecuteNonQuery();
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