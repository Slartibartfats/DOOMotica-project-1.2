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
            if (Request.Cookies["AuthenticationCookie"] == null)
            {
                Server.Transfer("~/Login.aspx");
            }
            
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
            OleDbConnection Conn = new OleDbConnection();
            OleDbCommand Query = new OleDbCommand();
            
                Conn.ConnectionString = Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                Query.Connection = Conn;

                Query.CommandText = "SELECT Hyperlink ,W_Omschrijving, Logo_URL FROM WEBSITE WHERE Webnr = ?";

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
                        txt_NaamWebsite.Text = Leesding["W_Omschrijving"].ToString();
                        txt_URLplaatje.Text = Leesding["Logo_URL"].ToString();
                    }
                }
                catch (Exception exc)
                { Aanmaken_lblFooter(exc.ToString()); }
                finally
                { Conn.Close(); }

            
        }

        protected void ddl_Voorbeeldlinkjes_SelectedIndexChanged(object sender, EventArgs e)
        {

            int URLnr = int.Parse(ddl_Voorbeeldlinkjes.SelectedValue);
            
            SelecteerInvullen(URLnr);

        }

        public int OphalenLidnr()
        {
            int Lidnr = 0;
            HttpCookie Koekje = Request.Cookies["AuthenticationCookie"];
            Lidnr = Convert.ToInt32(Koekje["Rolnr"]);

            return Lidnr;
        }

        public string OphalenUsern()
        {
            string Usern = "";
            HttpCookie Koekje = Request.Cookies["AuthenticationCookie"];
            Usern = Koekje["Username"].ToString();

            return Usern;
        }

        protected void btn_terug_Click(object sender, EventArgs e)
        {
            using (OleDbConnection Conn = new OleDbConnection())
            using (OleDbCommand Query = new OleDbCommand())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                Query.Connection = Conn;

                Query.Parameters.Clear();
                Query.CommandText = "INSERT INTO toegevoegd(Lidnr, Webnr) SELECT LID.Lidnr, WEBSITE.Webnr FROM LID, WEBSITE WHERE Gebruikersnaam = ? AND Hyperlink = ?";
                //invullen van parameters met username en hyperlink
                Param1.Value = OphalenUsern();
                Param2.Value = txt_Hyperlink.Text;

                Query.Parameters.Clear();
                Query.Parameters.Add(Param1);
                Query.Parameters.Add(Param2);

                try
                {
                    Conn.Open();
                    Query.ExecuteNonQuery();

                }
                catch (Exception exc)
                { Aanmaken_lblFooter(exc.ToString()); }
                finally
                { Conn.Close(); }
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

                Query.CommandText = "INSERT INTO WEBSITE (Hyperlink, W_Omschrijving, Logo_URL) VALUES (?, ?, ?)";
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
                catch 
                {
                    lbl_error.Text = "Deze Website komt al voor, kijk even in de lijst bovenin!";
                    ddl_Voorbeeldlinkjes.Focus();
                    vldtnsmmr_ErrorAddSite.Visible = true;
                }
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

        protected void btn_VoegToeConn_Click(object sender, EventArgs e)
        {
            OleDbConnection Conn = new OleDbConnection();
            OleDbCommand Query = new OleDbCommand();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();

            Query.Connection = Conn;

            Query.CommandText = "INSERT INTO toegevoegd(Lidnr, Webnr) SELECT LID.Lidnr, WEBSITE.Webnr FROM LID, WEBSITE WHERE Gebruikersnaam = ? AND Hyperlink = ?";
            //invullen van parameters met username en hyperlink
            Param1.Value = OphalenUsern();
            Param2.Value = txt_Hyperlink.Text;
            Query.Parameters.Clear();
            Query.Parameters.Add(Param1);
            Query.Parameters.Add(Param2);

            try
            {
                Conn.Open();
                Query.ExecuteNonQuery();
                lbl_error.Text = "Je website is toegevoegd!";
            }
            catch
            {
                lbl_error.Text = "Oeps, er is iets misgegaan!";
            }
            finally
            {
                Conn.Close();
            }




        }
    }
}