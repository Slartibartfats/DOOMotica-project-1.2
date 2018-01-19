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
    public partial class Home : System.Web.UI.Page
    {
        OleDbConnection Conn = new OleDbConnection();
        OleDbCommand Query = new OleDbCommand();
        OleDbParameter Usern = new OleDbParameter();
        int Aantal = 1;
        //  ////-------------------------//-------------------------//-------------------------//-------------------------
        //      private void CreateAButton()
        //      {
        //          
        //          var button = new ImageButton();
        //          button.ImageUrl = "~/images/hyperlink.jpg";
        //          button.ID = "mgbtn_Tegeltje" + Aantal.ToString();
        //          button.CssClass = "imagebutton";
        //          button.Height = 140;
        //
        //          Aantal++;
        //          button.Click += ButtonClick;
        //
        //          Page.Form.Controls.Add(button);
        //
        //      }
        //  //-------------------------//https://stackoverflow.com/questions/11061872/dynamically-create-an-imagebutton-------------------------

        public void Aanmaken_Tegeltjes(string Usern)
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;
            OleDbParameter Param1 = new OleDbParameter();
            Param1.Value = Usern;

            Query.CommandText = "SELECT W.Hyperlink, W.Website_naam, W.Logo_Url, L.Lidnr FROM WEBSITES AS W INNER JOIN(LID AS L INNER JOIN Geeft_weer1 AS GW ON L.Lidnr = GW.Lidnr) ON W.URLnr = GW.URLnr WHERE L.Gebruikersnaam = ?";
            Query.Parameters.Add(Param1);

            try
            {
                Conn.Open();
                OleDbDataReader Reader = Query.ExecuteReader();
                while (Reader.Read())
                {
                    ImageButton button = new ImageButton();
                    button.ImageUrl = Reader["Logo_Url"].ToString();
                    button.ID = "mgbtn_Tegeltje" + Aantal.ToString();
                    button.CssClass = "Imagebutton";
                    Aantal++;
                    button.PostBackUrl = Reader["Hyperlink"].ToString();
                    button.ToolTip = Reader["Website_naam"].ToString();
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

        private void ButtonClick(object sender, ImageClickEventArgs e)
        {

        }

        public void Checktegels()
        {
            //   if (ImageButton1.PostBackUrl == "")
            //   {
            //       ImageButton1.Visible = false;
            //   }
            //   if (ImageButton2.PostBackUrl == "")
            //   {
            //       ImageButton2.Visible = false;
            //   }
            //   if (ImageButton3.PostBackUrl == "")
            //   {
            //       ImageButton3.Visible = false;
            //   }
            //   if (ImageButton4.PostBackUrl == "")
            //   {
            //       ImageButton4.Visible = false;
            //   }
            //   if (ImageButton5.PostBackUrl == "")
            //   {
            //       ImageButton5.Visible = false;
            //   }
            //   if (ImageButton6.PostBackUrl == "")
            //   {
            //       ImageButton6.Visible = false;
            //   }
            //   if (ImageButton7.PostBackUrl == "")
            //   {
            //       ImageButton7.Visible = false;
            //   }
            //   if (ImageButton8.PostBackUrl == "")
            //   {
            //       ImageButton8.Visible = false;
            //   }
            //   if (ImageButton9.PostBackUrl == "")
            //   {
            //       ImageButton9.Visible = false;
            //   }
            //   if (ImageButton10.PostBackUrl == "")
            //   {
            //       ImageButton10.Visible = false;
            //   }
            //   if (ImageButton11.PostBackUrl == "")
            //   {
            //       ImageButton11.Visible = false;
            //   }
            //   if (ImageButton12.PostBackUrl == "")
            //   {
            //       ImageButton12.Visible = false;
            //   }



        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // Gebruiker uitlezen van Cookie
                string Usern = "Gebruiker";                    //voor het voorbeeld gebruiken we Gebruiker

                Aanmaken_Tegeltjes(Usern);




                //Checktegels(); <-- hoeft niet meer gebruikt te worden ivm dat er geen onnodige tegels meer ingeladen worden.

            }
        }
    }
}
