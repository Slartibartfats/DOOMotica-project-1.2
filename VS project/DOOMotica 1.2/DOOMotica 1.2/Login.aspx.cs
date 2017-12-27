using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Security.Cryptography; // --> Deze library wordt gebruikt voor het beveiligen van het wachtwoord


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
        OleDbParameter Param4 = new OleDbParameter();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_CreateUser_Click1(object sender, EventArgs e)
        {
            mltvw_Login.ActiveViewIndex = 1;
        }

        protected void btn_Terug_Click(object sender, EventArgs e)
        {

        }

      

        protected void btn_Create_Click(object sender, EventArgs e)
        {
            string password = txt_Pass.Text;

            //leegmaken uitkosmt txtbox
            lbl_gelukt.Text = "";
            // connectie aanwijzen
            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Connectie;
            // salt genereren



            //----------------------------------------------------------------------------------------------------------------------------------------------
            
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //hash genereren + de key voor het wachtwoord
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 20000);
            byte[] hash = pbkdf2.GetBytes(20);
            // combineren salt en wachtwoord bytes
            byte[] hashbytes = new byte[36];
            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 0, 20);

            var Base64Hash = Convert.ToBase64String(hashbytes);




            //---------https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129----USER:csharptest.net----------  
            //opzetten query
            Query.CommandText = "INSERT INTO LID (Gebruikersnaam, Wachtwoord, E_mail) VALUES (?,?,?)";
            //parameters invoeren
            Param1.Value = txt_User.Text;
            Param2.Value = Base64Hash;
            Param3.Value = txt_Email.Text;
            Param4.Value = txt_User.Text;
            //parameters toevoegen aan query, op volgorde
            Query.Parameters.Add(Param1);
            Query.Parameters.Add(Param2);
            Query.Parameters.Add(Param3);


            if (Page.IsValid)

            {

                //eerste query
                try

                {
                    Connectie.Open();
                    lbl_gelukt.Text = "";
                    Query.ExecuteNonQuery();
                    lbl_gelukt.Text = "GELUKT!"; //feedback als het gelukt is
                    txt_Username.Text = txt_User.Text; // een aardigheidje, Username wordt onthouden.
                }

                catch (Exception exc) { lbl_gelukt.Text = exc.ToString(); }
                finally { Connectie.Close(); }


                /*           //tweede query
                           try
                           {
                               Connectie.Open();
                               Query.CommandText = "SELECT Lidnr FROM LID WHERE Gebruikersnaam = '?'";
                               Query.Parameters.Clear(); //verwijderen parameters, niet meer meesturen dan nodig is
                               Query.Parameters.Add(Param1);
                               OleDbDataReader reader = Query.ExecuteReader();// HEt is nu een SELECT query dus er moet gelezen worden ipv uitgevoerd  

                               while (!reader.Read())
                               {
                                   nw_Lidnr = Convert.ToInt64(String.Format("{0}", reader["Lidnr"]));
                               }
                           }

                           catch (Exception exc) { lbl_gelukt.Text = exc.ToString(); }
                           finally { Connectie.Close(); }

                           //derde query
                           try
                           {
                               Connectie.Open();
                               Query.CommandText = "INSERT INTO GEBRUIKER (Lidnr) SELECT Lidnr FROM LID WHERE Gebruikersnaam = '?'"; //CHECK CHECK DUBBEL CHECK
                               Query.Parameters.Clear();                    
                               Query.Parameters.Add(Param1);
                               Query.ExecuteNonQuery();



                           }
                           catch (Exception exc) { lbl_gelukt.Text = exc.ToString(); }
                           finally { Connectie.Close(); }
                       */
                mltvw_Login.ActiveViewIndex = 2;
            }

            vldtnsmmr_CreateUser.HeaderText = "Formulier is nog niet juist.";

        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {

        }

        protected void btn_TerugLogin_Click(object sender, EventArgs e)
        {

            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Connectie;

            Query.CommandText = "INSERT INTO Gebruiker SELECT Lidnr FROM LID WHERE Gebruikersnaam = '?'";
            //parameters invoeren
            Param1.Value = txt_User.Text;
            Query.Parameters.Add(Param1);
                          
                try

                {
                    Connectie.Open();
                    Query.ExecuteNonQuery();

                }

                catch (Exception exc) { lbl_gelukt.Text = exc.ToString(); }
                finally { Connectie.Close(); }

                mltvw_Login.ActiveViewIndex = 0;
            
        }
    }
}