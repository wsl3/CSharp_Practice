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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            this.RoomDataBind();
        }
        public void RoomDataBind()
        {
            string constr = ConfigurationManager.ConnectionStrings["HotelConString"].ConnectionString;
            SQLiteConnection con = new SQLiteConnection(constr);
            con.Open();

            string query = "select room.id,roomtype,info,charge,customer.name,customer.id as customerid from room,customer  where room.customer_id=customer.id;";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            query = "select id,roomtype,info,charge from room where customer_id is NULL;";
            SQLiteCommand cmd2 = new SQLiteCommand(query, con);
            SQLiteDataAdapter sda2 = new SQLiteDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Repeater3.DataSource = dt2;
            Repeater3.DataBind();
   
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}