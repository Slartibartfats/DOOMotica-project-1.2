using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Security.Cryptography;

namespace DOOMotica_1._2.ADMIN
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        OleDbConnection Connectie = new OleDbConnection();
        OleDbCommand Query = new OleDbCommand();
        OleDbParameter Param1 = new OleDbParameter();
        OleDbParameter Param2 = new OleDbParameter(); // deze heet express 2, ivm MS-veiligheid enzo
        OleDbParameter Param3 = new OleDbParameter();
        OleDbParameter Param4 = new OleDbParameter();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthenticationCookie"] == null)
            {
                Server.Transfer("~/Login.aspx");
            }
        }

        public string HashenPW()
        {
            //in deze array komt de salt
            byte[] salt;
            // het genereren van de salt, 16 'random' cijfers
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            // hashen van het salt + de inhoud van de textbox
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(txt_Pass.Text, salt, 10000);

            // bovenstaande hash wordt in een array geplaatst
            byte[] hash = pbkdf2.GetBytes(20);

            //Een nieuwe array maken waar de hash + de salt in wordt opgeslagen
            byte[] hashBytes = new byte[36];
            //De hash en de salt in bovenstaande array plaatsen
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20); //de laatste 2 getallen geven aan dat de array 'hash' pas geplaatst moet worden vanaf plek 16 (de 17de plek dus) en 20 plaatsen inneemt.

            //nu nog de salthasharray converteren naar een string
            string SavedHash = Convert.ToBase64String(hashBytes);
            int Lengte = SavedHash.Length; //weten waarom er 36 bytes zijn maar 48 tekens.



            return SavedHash;
        }

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string password = txt_Pass.Text;

            lbl_gelukt.Text = "";

            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Connectie;
            
            //opzetten query
            Query.CommandText = "INSERT INTO LID (Gebruikersnaam, Wachtwoord, E_mail,Rolnr) VALUES (?,?,?,?)";
            //parameters invoeren
            Param1.Value = txt_User.Text;
            Param2.Value = HashenPW();
            Param3.Value = txt_Email.Text;
            Param4.Value = ddl_Rol.SelectedItem.Value;

            //parameters toevoegen aan query, op volgorde
            Query.Parameters.Add(Param1);
            Query.Parameters.Add(Param2);
            Query.Parameters.Add(Param3);
            Query.Parameters.Add(Param4);

            try
            {
                Connectie.Open();
                Query.ExecuteNonQuery();
                lbl_gelukt.Text = txt_User.Text + " is succesvol toegevoegd :D";
            }
            catch
            { lbl_gelukt.Text = "Er is iets misgegaan met het toevoegen :("; }
            finally
            { Connectie.Close(); }


        }

        protected void btn_Terug_Click(object sender, EventArgs e)
        {

        }

        protected void AccesDBsrc_Rollen_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}