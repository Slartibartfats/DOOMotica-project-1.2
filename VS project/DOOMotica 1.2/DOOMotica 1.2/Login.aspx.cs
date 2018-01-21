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


        public int OphalenRol()
        {
            int Rolnr = 0;
            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Connectie;
            HttpCookie AutKoekje = Request.Cookies["AuthenticationCookie"];

            OleDbParameter Henk = new OleDbParameter();
            Henk.Value = AutKoekje["Username"];
            Query.Parameters.Add(Henk);


            Query.CommandText = "SELECT RolNr FROM LID WHERE Gebruikersnaam = ?";
            try
            {
                Connectie.Open();
                OleDbDataReader Leesding = Query.ExecuteReader();
                if (Leesding.HasRows)
                {
                    while (Leesding.Read())
                    {
                        Rolnr = Convert.ToInt32(Leesding["Rolnr"]);
                    }
                }
            }
            catch (Exception e)
            { lbl_gelukt.Text = e.ToString(); }
            finally
            { Connectie.Close(); }


            return Rolnr;
        }
        public void Doorverwijzen(int Rol)
        {
            switch (Rol)
            {
                case 1:
                    Server.Transfer("~/ADMIN/AdminHome.aspx");
                    break;
                case 2:
                    Server.Transfer("~/MEMBERS/Home.aspx");
                    break;
                default:
                    Server.Transfer("~/Login.aspx");
                    break;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["AuthenticationCookie"] != null)
            {
                //opzoeken rolnr in DB
                int Rol = OphalenRol();
                //opzetten splitsing
                Doorverwijzen(Rol);
                
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();

            //voorkomen dat de browser dingen opslaat
            //https://stackoverflow.com/questions/17186821/asp-net-session-doesnt-work-when-backward-to-login-page-after-redirect    Peter


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
            string password = txt_Pass.Text;

            //leegmaken uitkosmt txtbox
            lbl_gelukt.Text = "";
            // connectie aanwijzen
            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Connectie;
            // salt genereren



            //----------------------------------------------------------------------------------------------------------------------------------------------

            //     byte[] salt;
            //     new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //     //hash genereren + de key voor het wachtwoord
            //     var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 20000);
            //     byte[] hash = pbkdf2.GetBytes(20);
            //     // combineren salt en wachtwoord bytes
            //     byte[] hashbytes = new byte[36];
            //     Array.Copy(salt, 0, hashbytes, 0, 16);
            //     Array.Copy(hash, 0, hashbytes, 0, 20);
            //
            //     var Base64Hash = Convert.ToBase64String(hashbytes);
            //
            //
            //
            //
            //     //---------https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129----USER:csharptest.net----------  

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
            int Lengte = SavedHash.Length;
            //opzetten query
            Query.CommandText = "INSERT INTO LID (Gebruikersnaam, Wachtwoord, E_mail,Rolnr) VALUES (?,?,?,2)";
            //parameters invoeren
            Param1.Value = txt_User.Text;
            Param2.Value = SavedHash.ToString();
            Param3.Value = txt_Email.Text;

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

                    //uitzetten van Home knop + navigatiebalk

                }

                catch (Exception exc) { lbl_gelukt.Text = exc.ToString(); }
                finally { Connectie.Close(); }


                if (lbl_gelukt.Text != "GELUKT!")
                {
                    lbl_gelukt.Text = "Er is een fout opgetreden!";
                }
                else
                {
                    mltvw_Login.ActiveViewIndex = 2;
                }
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
            }
            else
            {
                lbl_gelukt.Text = ("Formulier is nog niet juist.");
            }
        }
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string Wachtwoord = "";
            int Lidnr = 0, Rolnr = 0;
            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Connectie;

            Query.CommandText = "SELECT Wachtwoord, Lidnr, Rolnr FROM LID WHERE Gebruikersnaam = ? ";
            OleDbParameter Param1 = new OleDbParameter();
            Param1.Value = txt_Username.Text;
            Query.Parameters.Add(Param1);

            try
            {
                Connectie.Open();
                OleDbDataReader Leesding = Query.ExecuteReader();
                while (Leesding.Read())
                {
                    Wachtwoord = Leesding["Wachtwoord"].ToString();
                    Lidnr = Convert.ToInt32(Leesding["Lidnr"]);
                    Rolnr = Convert.ToInt32(Leesding["Rolnr"]);
                }
            }
            catch (Exception exc)
            {
                lbl_gelukt.Text = exc.ToString();
            }
            finally { Connectie.Close(); }

            //converteren string naar bytes
            byte[] DBhash = Convert.FromBase64String(Wachtwoord);


            //AANMAKEN SALT VAN DBHASH
            byte[] DBsalt = new byte[16];
            Array.Copy(DBhash, 0, DBsalt, 0, 16);
            //Aanmaken en converten hash uit ww
            byte[] Controle_DBhash = new byte[20];
            Array.Copy(DBhash, 16, Controle_DBhash, 0, 20);
            string DBww = Convert.ToBase64String(Controle_DBhash);

            //HASHEN
            var pbkdf2 = new Rfc2898DeriveBytes(txt_Password.Text, DBsalt, 10000);
            byte[] CtHash = pbkdf2.GetBytes(20);
            string ControlePass = Convert.ToBase64String(CtHash);

            if (ControlePass == DBww)
            {
                //toevoegen cookie met username + lidnr
                HttpCookie Koekje = new HttpCookie("AuthenticationCookie");
                Koekje.Values.Add("Username", txt_Username.Text);
                Koekje.Values.Add("Lidnr", Lidnr.ToString());
                Koekje.Expires = DateTime.Now.AddMinutes(20);
                Response.Cookies.Add(Koekje);

                Doorverwijzen(Rolnr);
                //doorsturen naar naar juiste homepage gebeurd in de page_load
                //Server.Transfer("~/MEMBERS/Home.aspx");
            }


        }

        protected void btn_TerugLogin_Click(object sender, EventArgs e)
        {

            /*     Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
                 Query.Connection = Connectie;

                 Query.CommandText = "INSERT INTO Gebruiker SELECT Lidnr FROM LID WHERE Gebruikersnaam = '?'";
                 //parameters invoeren
                 Param1.Value = txt_User.Text;
                 Query.Parameters.Add(Param1);

                 try                                                             Vanwege het toevoegen van rolnrs is dit niet meer nodig.

                 {
                     Connectie.Open();
                     Query.ExecuteNonQuery();

                 }

                 catch (Exception exc) { lbl_gelukt.Text = exc.ToString(); }
                 finally { Connectie.Close(); }
                 */
            mltvw_Login.ActiveViewIndex = 0;

        }

    }
}