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
    public partial class Login : System.Web.UI.Page
    {
        //aanmaken connectie object, query opbject en 3 parameters voor het aanmaken account
        OleDbConnection Connectie = new OleDbConnection();
        
        OleDbCommand Query = new OleDbCommand();
        OleDbParameter Param1 = new OleDbParameter();
        OleDbParameter Param2 = new OleDbParameter(); // deze heet express 2, ivm MS-veiligheid enzo
        OleDbParameter Param3 = new OleDbParameter();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_CreateUser_Click1(object sender, EventArgs e)
        {
            mltvw_Login.ActiveViewIndex = 1;
        }

        protected void btn_Terug_Click(object sender, EventArgs e)
        {
            mltvw_Login.ActiveViewIndex = 0;
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            // connectie aanwijzen
            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Connectie;
            
            //opzetten query
            Query.CommandText = "INSERT INTO LID (Gebruikersnaam, Wachtwoord, E_mail) VALUES (?,?,?)";
            //parameters invoeren
            Param1.Value = txt_User.Text;
            Param2.Value = txt_Pass.Text;
            Param3.Value = txt_Email.Text;
            //parameters toevoegen aan query, op volgorde
            Query.Parameters.Add(Param1);
            Query.Parameters.Add(Param2);
            Query.Parameters.Add(Param3);

            try
            {
                Connectie.Open();
                lbl_gelukt.Text = "";
                Query.ExecuteReader();
                lbl_gelukt.Text = "GELUKT!";
                txt_Username.Text = txt_User.Text;

            }
            catch (Exception exc) { lbl_gelukt.Text = exc.ToString(); }
            finally { Connectie.Close();}
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {

        }
    }
}