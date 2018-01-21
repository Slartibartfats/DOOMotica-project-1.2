using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

namespace DOOMotica_1._2.MEMBERS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //checken voor cookie
            Cookiecheck();
            //lbl opvullen met username, deze wordt gebruikt door de Accesdatasource
            lbl_user.Text = OphalenUser();
            //lbl opvullen met lidnr
            lbl_Lidnr.Text = OphalenLidnr();
        }
        public string OphalenUser()
        {
            string User;
            HttpCookie Koekje = Request.Cookies["AuthenticationCookie"];
            User = Koekje["Username"];
            return User;

        }

        public string OphalenLidnr()
        {
            OleDbParameter Param1 = new OleDbParameter();
           
            int Lidnr = 0;

            OleDbConnection Conn = new OleDbConnection();
            OleDbCommand Query = new OleDbCommand();

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;
            Query.CommandText = "SELECT Lidnr FROM LID WHERE Gebruikersnaam = ?";
            Query.Parameters.Clear();
            Param1.Value = OphalenUser();

            Query.Parameters.Add(Param1);

            try
            {
                Conn.Open();
                OleDbDataReader Leesding = Query.ExecuteReader();
                if (Leesding.HasRows)
                {
                    while (Leesding.Read())
                    {
                        Lidnr = Convert.ToInt32(Leesding["Lidnr"]);                        
                    }
                }
                else { lbl_text.Text = "Er is iets foutgegaan met het ophalen van je gegevens :("; }
            }
            catch
            { lbl_text.Text = "Er is iets foutgegaan met het ophalen van je gegevens :("; }
            finally
            { Conn.Close(); }

            return Lidnr.ToString();
        }

        public void Cookiecheck()
        {
            if (Request.Cookies["AuthenticationCookie"] == null)
            { Server.Transfer("~/Login.aspx"); }
        }
        protected void Accesdtsrc_GebuikerSites_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

       

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            OleDbConnection Conn = new OleDbConnection();
            OleDbCommand Query = new OleDbCommand();

            OleDbParameter Param1 = new OleDbParameter();
            OleDbParameter Param2 = new OleDbParameter();

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;
            Query.CommandText = "DELETE FROM toegevoegd WHERE Lidnr = ? AND Webnr = ?";
            Query.Parameters.Clear();

            Param1.Value = int.Parse(lbl_Lidnr.Text);
            Param2.Value = int.Parse(lstbx_Websites.SelectedValue);

            Query.Parameters.Add(Param1);
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