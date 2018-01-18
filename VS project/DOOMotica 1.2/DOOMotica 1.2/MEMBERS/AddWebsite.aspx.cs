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
    public partial class WebForm1 : System.Web.UI.Page
    {
        //  OleDbConnection Conn = new OleDbConnection(); --> De connectie en query dienen elke keer opnieuw aangegeven te worden
        //   OleDbCommand Query = new OleDbCommand();          als ik meerdere keren een connectie wil openen met een postback.

        OleDbParameter Param1 = new OleDbParameter();
        OleDbParameter Param2 = new OleDbParameter();
        OleDbParameter Param3 = new OleDbParameter();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Home_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home.aspx");
        }
        public void Aanmaken_lblFooter(string text)
        {
            Label lbl = new Label();
            lbl.Text = text;

            Master.Controls.Add(lbl);

        }

        public void SelecteerInvullen(int Urlnr)
        {
            using (OleDbConnection Conn = new OleDbConnection())
            using (OleDbCommand Query = new OleDbCommand())
            {
                Conn.ConnectionString = Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                Query.Connection = Conn;

                Query.CommandText = "SELECT * FROM WEBSITES WHERE URLnr = ?";

                OleDbParameter Param1 = new OleDbParameter();
                Param1.Value = Urlnr;

                Query.Parameters.Add(Param1);

                try
                {
                    Conn.Open();
                    OleDbDataReader Leesding = Query.ExecuteReader();


                    while (Leesding.Read())
                    {
                        txt_Hyperlink.Text = Leesding["Hyperlink"].ToString();
                        txt_NaamWebsite.Text = Leesding["Website_naam"].ToString();
                        txt_URLplaatje.Text = Leesding["Logo_Url"].ToString();
                    }




                }
                catch (Exception exc)
                { Aanmaken_lblFooter(exc.ToString()); }
                finally
                { Conn.Close(); }

            }
        }

        protected void ddl_Voorbeeldlinkjes_SelectedIndexChanged(object sender, EventArgs e)
        {

            int URLnr = int.Parse(ddl_Voorbeeldlinkjes.SelectedValue);

            SelecteerInvullen(URLnr);

        }

        protected void btn_terug_Click(object sender, EventArgs e)
        {
            using (OleDbConnection Conn = new OleDbConnection())
            using (OleDbCommand Query = new OleDbCommand())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                Query.Connection = Conn;

                int Lidnr = 26, URLnr = 7;
                string User = "Gebruiker";
                

                Query.CommandText = "INSERT INTO Geeft_weer1 (Lidnr,     ";



                Server.Transfer("Home.aspx");

            }
        }



        public bool ControleAddWebsite(string ControleHL)
        {
            using (OleDbConnection Conn = new OleDbConnection())
            using (OleDbCommand Query = new OleDbCommand())
            {
                //opzetten connectie
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                Query.Connection = Conn;

                //aanmaken terug te sturen boolean
                bool TF = false;

                Query.CommandText = "SELECT Hyperlink FROM WEBSITES WHERE Hyperlink LIKE ?";

                Query.Parameters.Clear();
                Param1.Value = ControleHL;
                Query.Parameters.Add(Param1);

                //query uitvoeren en kijken of de URL al bestaat.
                try
                {
                    Conn.Open();
                    OleDbDataReader Leesding = Query.ExecuteReader();
                    if (!Leesding.HasRows)
                    { TF = true; }

                }
                finally { Conn.Close(); }

                return TF;
            }
        } //Dit is een opgeschorte functie


        public void InsertOpzet(string HL, string WNaam, string LogoUrl)
        {
            using (OleDbConnection Conn = new OleDbConnection())
            using (OleDbCommand Query = new OleDbCommand())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                Query.Connection = Conn;

                Param1.Value = HL;
                Param2.Value = WNaam;

                //Als er geen url is ingevuld, dan wordt de default URL ingevuld.
                if (LogoUrl == "")
                {
                    Param3.Value = "~/images/hyperlink.jpg";
                }
                else
                { Param3.Value = LogoUrl; }

                Query.CommandText = "INSERT INTO WEBSITES (Hyperlink, Website_naam, Logo_Url) VALUES (?, ?, ?)";
                Query.Parameters.Clear();
                Query.Parameters.Add(Param1);
                Query.Parameters.Add(Param2);
                Query.Parameters.Add(Param3);


                try
                {
                    Conn.Open();
                    Query.ExecuteNonQuery();
                    mltvw_AddSite.ActiveViewIndex = 1;

                }
                catch (Exception exc) { vldtnsmmr_ErrorAddSite.HeaderText = exc.ToString(); }
                finally
                {
                    Conn.Close();
                }

            }
        }

        protected void btn_VoegToe_Click(object sender, EventArgs e)
        {
            //Variabelen declareren en textboxen uitlezen
            string HyperLink = txt_Hyperlink.Text, Website_Naam = txt_NaamWebsite.Text, Logo_Url = txt_URLplaatje.Text;

            
                InsertOpzet(HyperLink, Website_Naam, Logo_Url);
                vldtnsmmr_ErrorAddSite.HeaderText = "Gelukt!";
            


        }
    }
}