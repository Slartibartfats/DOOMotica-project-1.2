using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace DOOMotica_1._2
{
    public partial class Login : System.Web.UI.Page
    {
        OleDbConnection Conn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        byte[] salt;

        

        string Username, Password, Wachtwoord, Param1;



        protected void Page_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(@"\App_data") + @"\Web-Applicatie Database.accdb";
            cmd.Connection = Conn;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {

            Username =txt_Username.Text;
            cmd.CommandText = "SELECT Wachtwoord FROM LID WHERE Gebruikersnaam = ? ";
            cmd.Parameters.Clear(); //verwijderen eerdere parameters
            Param1 = Username;
            cmd.Parameters.Add(Param1);

            var pbkdf2 = new Rfc2898DeriveBytes(txt_Password.Text, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);



            try
            {
                Conn.Open();
                OleDbDataReader Reader = cmd.ExecuteReader();
                
                if(Reader == null)
                {
                    lbl_ConnFeedBack.Text = "Er is een fout opgetreden";
                }
                else
                {
                    while(Reader.Read())
                    {
                        Wachtwoord += string.Format("{0}: {1}<br />\n", Reader["Wachtwoord"].ToString());
                    }
                }

                Wachtwoord = Reader.ToString();

                if(Password == Wachtwoord)
                {
                    //ga naar begin pagina
                }
                else
                {
                    //foutmelding
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

        }
    }
}