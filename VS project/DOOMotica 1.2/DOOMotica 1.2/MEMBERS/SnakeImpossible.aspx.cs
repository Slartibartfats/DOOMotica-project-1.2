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
    public partial class SnakeMedium : System.Web.UI.Page
    {
        OleDbCommand Query = new OleDbCommand();
        OleDbConnection Conn = new OleDbConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthenticationCookie"] == null)
            {
                Server.Transfer("~/Login.aspx");
            }

            

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;

            Query.CommandText = "SELECT SpelNaam, Omschrijving, BronURL FROM SPEL WHERE SpelNaam = 'SnakeImpossible'";

            try
            {
                Conn.Open();
                OleDbDataReader Leesding = Query.ExecuteReader();
                if (Leesding.HasRows)
                {
                    while (Leesding.Read())
                    {
                        lbl_omschrijving.Text = Leesding["Omschrijving"].ToString();
                        lbl_Titel.Text = Leesding["SpelNaam"].ToString();
                        lbl_BronUrl.Text = Leesding["BronURL"].ToString();
                    }

                }
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}