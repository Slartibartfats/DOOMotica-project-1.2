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
    public partial class Home_master : System.Web.UI.Page
    {
        OleDbConnection Conn = new OleDbConnection();
        OleDbCommand Query = new OleDbCommand();
        OleDbParameter Usern = new OleDbParameter();
        int Aantal = 1;

        public void Aanmaken_Tegeltjes(string Usern)
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;
            OleDbParameter Param1 = new OleDbParameter();
            Param1.Value = Usern;

            Query.CommandText = "SELECT W.Hyperlink, W.W_Omschrijving, W.Logo_URL, L.Lidnr FROM WEBSITE AS W INNER JOIN(LID AS L INNER JOIN toegevoegd AS T ON L.Lidnr = T.Lidnr) ON W.Webnr = T.Webnr WHERE L.Gebruikersnaam = ?";
            Query.Parameters.Add(Param1);

            try
            {
                Conn.Open();
                OleDbDataReader Reader = Query.ExecuteReader();
                while (Reader.Read())
                {
                    ImageButton button = new ImageButton();
                    button.ImageUrl = Reader["Logo_URL"].ToString();
                    button.ID = "mgbtn_Tegeltje" + Aantal.ToString();
                    button.CssClass = "Imagebutton";
                    Aantal++;
                    button.PostBackUrl = Reader["Hyperlink"].ToString();
                    button.ToolTip = Reader["W_Omschrijving"].ToString();
                    button.Height = 150;
                    button.Width = 150;


                    Raamwerk.Controls.Add(button);

                    //  Page.Form.Controls.Add(button);  <-- deze code zorgde ervoor dat de tegels onder de webpagina 
                    //  terecht kwamen
                }
            }
            catch (Exception exc)
            {
                Aanmaken_lblFooter(exc.ToString());
            }
            finally { Conn.Close(); }

        }

        public void Aanmaken_lblFooter(string text)
        {
            Label lbl = new Label();
            lbl.Text = text;

            Master.Controls.Add(lbl);

        }

        public string OphalenUsern()
        {
            HttpCookie koekje = Request.Cookies["AuthenticationCookie"];
            string Username = koekje["Username"];

            return Username;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthenticationCookie"] == null)
            {
                Server.Transfer("~/Login.aspx");
            }
            else
            {
                string Username = OphalenUsern();

                Aanmaken_Tegeltjes(Username);
            }
        }
    }
}