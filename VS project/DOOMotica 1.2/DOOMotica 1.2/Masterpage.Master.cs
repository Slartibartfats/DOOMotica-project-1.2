using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

namespace DOOMotica_1._2
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        OleDbCommand Query = new OleDbCommand();
        OleDbConnection Conn = new OleDbConnection();

        public void Aanmaken_lblFooter(string text)
        {
            Label lbl = new Label();
            lbl.Text = text;

            footer.Controls.Add(lbl);

        }

        public void Bepalen_Gebruiker(string Usern)
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                Query.Connection = Conn;
                OleDbParameter Param1 = new OleDbParameter();

                Param1.Value = Usern;

                Query.CommandText = "SELECT Lidnr FROM LID WHERE Gebruikersnaam = ?";
            Query.Parameters.Add(Param1);
                try
                {
                    Conn.Open();
                    OleDbDataReader Leesding = Query.ExecuteReader();
                    while (Leesding.Read())
                    {
                        if (Convert.ToInt32((Leesding["Lidnr"])) != 26)
                        {
                        AddSite.Visible = false;
                        AddSite.Disabled = true;
                        }
                    }

                }
                catch (Exception exc) { Aanmaken_lblFooter(exc.ToString()); }
                finally { Conn.Close(); }





            }
        protected void Page_Load(object sender, EventArgs e)
        {

            //cookie uitlezen voor de gebruiker, als dit leeg is doorverwijzen naar Login.aspx
            string User = "Gebruiker";
            //als de persoon een gebruiker is ADD WEBSITE KNOP laten zien

            
            Bepalen_Gebruiker(User);
        }

      
    }
}