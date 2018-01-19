using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

namespace DOOMotica_1._2
{
    public partial class Login : System.Web.UI.Page
    {
        OleDbConnection Conn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
    
        OleDbParameter Param1 = new OleDbParameter();


        string Username, Wachtwoord;



        protected void Page_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(@"\App_data") + @"\Web-Applicatie Database.accdb";
            cmd.Connection = Conn;
           
            
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {

            Username = txt_Username.Text;
            cmd.CommandText = "SELECT Wachtwoord FROM LID WHERE Gebruikersnaam = ? ";
            cmd.Parameters.Clear(); //verwijderen eerdere parameters
            Param1.Value = Username;
            cmd.Parameters.Add(Param1);

           
 //ophalen DB

            try
            {
               
                Conn.Open();
                OleDbDataReader Reader = cmd.ExecuteReader();
                
                if(Reader.Read() == false)
                {
                    lbl_ConnFeedBack.Text = "Er is een fout opgetreden";
                }
                else
                {
                    while(Reader.Read())
                    {
                        Wachtwoord += string.Format("{0}: <br />\n", Reader["Wachtwoord"].ToString());
                    }
                }

                               
              
            }
            catch (Exception exc)
            {
                lbl_ConnFeedBack.Text = exc.Message;
            }
            finally
            {

                Conn.Close();
                
            }




            //Opsplitsen

            byte[] DBSalt = Encoding.ASCII.GetBytes(Wachtwoord.Substring(0, 16));
            
            string DBHash = Wachtwoord.Substring(16, 20);

            //Salt en Password aanelkaar zetten

            string ConWachtwoord = DBSalt + txt_Password.Text;

            //Controle wachtwoord hashen

            var pbkdf2 = new Rfc2898DeriveBytes(ConWachtwoord, DBSalt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashbytes = new byte[36];

            Array.Copy(DBSalt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);

            string SavedPassWordHash = Convert.ToBase64String(hashbytes);
            //vergelijken
            
            if(Wachtwoord == SavedPassWordHash)
            {
                HttpCookie AuthenticationCookie = new HttpCookie("koekje");
                DateTime Now = DateTime.Now;

                AuthenticationCookie.Values.Add("Time", Now.ToString());
                AuthenticationCookie.Values.Add("Username", Username);

                Server.Transfer(home.aspx);
            }
           

        }
    }
}