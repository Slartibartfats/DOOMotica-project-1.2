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
        OleDbParameter Param1 = new OleDbParameter();
        

        string Username, Password, Wachtwoord;



        protected void Page_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(@"\App_data") + @"\Web-Applicatie Database.accdb";
            cmd.Connection = Conn;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            
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

            string DBSalt = Wachtwoord.Substring(0, 16);
            string DBHash = Wachtwoord.Substring(15, 20);

            //Salt en Password aanelkaar zetten
            string ConWachtwoord = DBSalt + txt_Password.Text;

            //Controle wachtwoord hashen



            //vergelijken
            

           

        }
    }
}