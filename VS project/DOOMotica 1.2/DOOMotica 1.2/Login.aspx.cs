using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace DOOMotica_1._2
{
    public partial class Login : System.Web.UI.Page
    {
        OleDbConnection Conn = new OleDbConnection();
        Conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(@"\App_data") + @"\Web-Applicatie Database.accdb";

        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                



            }
            catch (Exception exc)
            {
                lbl_ConnFeedBack.Text = exc.Message;
            }
            finally
            {

                Conn.Close();
                
            }

        }
    }
}