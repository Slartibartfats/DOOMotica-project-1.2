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
    public partial class SpelPagina : System.Web.UI.Page
    {
        OleDbConnection Conn = new OleDbConnection();
        OleDbCommand Query = new OleDbCommand();
        int Aantal = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthenticationCookie"] == null)
            {
                Server.Transfer("~/Login.aspx");
            }
            Aanmaken_Tegeltjes();            
        }

        public void Aanmaken_Tegeltjes()
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;

            Query.CommandText = "SELECT SpelNaam FROM SPEL";
            

            try
            {
                Conn.Open();
                OleDbDataReader Reader = Query.ExecuteReader();
                while (Reader.Read())
                {
                    ImageButton button = new ImageButton();
                    button.ImageUrl = "~/images/flowfree.jpg";
                    button.ID = "mgbtn_Tegeltje" + Aantal.ToString();
                    button.CssClass = "Imagebutton";
                    Aantal++;
                    button.PostBackUrl = "~/MEMBERS/" + Reader["SpelNaam"].ToString()+ ".aspx";
                    button.ToolTip = Reader["SpelNaam"].ToString();
                    button.Height = 150;
                    button.Width = 150;


                    Raamwerk.Controls.Add(button);

                    //  Page.Form.Controls.Add(button);  <-- deze code zorgde ervoor dat de tegels onder de webpagina 
                    //  terecht kwamen
                }
            }
            catch 
            {
                lbl_error.Text = "Ër is iets misgegaan :(";
            }
            finally { Conn.Close(); }

        }

    }
}