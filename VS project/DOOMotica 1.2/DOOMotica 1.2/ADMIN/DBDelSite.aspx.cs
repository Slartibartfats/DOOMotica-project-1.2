using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

namespace DOOMotica_1._2.ADMIN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthenticationCookie"] == null)
            {
                Server.Transfer("~/Login.aspx");
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            OleDbConnection Conn = new OleDbConnection();
            OleDbCommand Query = new OleDbCommand();

            
            OleDbParameter Param2 = new OleDbParameter();

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;
            Query.CommandText = "DELETE FROM WEBSITE WHERE Webnr = ?";
            Query.Parameters.Clear();
            
            Param2.Value = int.Parse(lstbx_Websites.SelectedValue);
            
            Query.Parameters.Add(Param2);
            try
            {
                Conn.Open();
                Query.ExecuteNonQuery();
            }
            catch
            { lbl_text.Text = "Er is iets foutgegaan met het verwijderen :("; }
            finally { Conn.Close(); }

            lstbx_Websites.DataSourceID = "";
            lstbx_Websites.DataSourceID = "Accesdbsrc_WebsitesUser";
        }
    }
}