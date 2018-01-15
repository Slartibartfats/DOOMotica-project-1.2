using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace DOOMotica_1._2
{
    public partial class Login : System.Web.UI.Page
    {
        OleDbConnection Conn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        string Username, Password, Wachtwoord, Param1;



        protected void Page_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(@"\App_data") + @"\Web-Applicatie Database.accdb";
            cmd.Connection = Conn;
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                cmd.CommandText = "SELECT Wachtwoord FROM LID WHERE Gebruikersnaam = ? ";
                cmd.Parameters.Clear(); //verwijderen eerdere parameters
                Param1 = Username;
                cmd.Parameters.Add(Param1);
                OleDbDataReader Reader = cmd.ExecuteReader();
                Username = txt_Username.Text;
                Password = txt_Password.Text;

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