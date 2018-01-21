using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Threading;

namespace DOOMotica_1._2
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        OleDbCommand Query = new OleDbCommand();
        OleDbConnection Conn = new OleDbConnection();

        const string ROL1 = "(ADMIN)", ROL2 = "(Gebruiker)";
        public void Aanmaken_lblFooter(string text)
        {
            Label lbl = new Label();
            lbl.Text = text;

            footer.Controls.Add(lbl);

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
                   
                    break;
            }
        }
        public void Navigatiecontrols(string Usern)
        {
            //ophalen rolnr
            int Rolnr = 0;

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();
            Query.Connection = Conn;
            OleDbParameter Param1 = new OleDbParameter();

            Param1.Value = Usern;

            Query.CommandText = "SELECT Lidnr,Rolnr FROM LID WHERE Gebruikersnaam = ?";
            Query.Parameters.Add(Param1);
            try
            {
                Conn.Open();
                OleDbDataReader Leesding = Query.ExecuteReader();
                if (!Leesding.HasRows)
                {
                    lbl_error.Text = "Je staat niet in de DTB, neem contact op met de ICT. Ga terug naar het inlogscherm.";
                    AddSite.Visible = false;
                    AddSite.Disabled = true;
                }
                else
                {
                    while (Leesding.Read())
                    {
                        Rolnr = Convert.ToInt32(Leesding["Rolnr"]);
                    }
                }
            }
            catch (Exception exc) { Aanmaken_lblFooter(exc.ToString()); }
            finally { Conn.Close(); }

            //Bepalen welke knoppen aanmogen en welke niet.
            switch (Rolnr)
            {
                case 1:
                    AddSite.Visible = true; AddSite.Disabled = false;
                    DeleteSite.Visible = true; DeleteSite.Disabled = false;
                    AdminDeleteSite.Visible = true; AdminDeleteSite.Disabled = false;
                    CreateAdmin.Visible = true; CreateAdmin.Disabled = false;
                    SpelPagina.Visible = true; SpelPagina.Disabled = false;
                    lnkbtn_Logout.Visible = true; lnkbtn_Logout.Enabled = true;

                    lbl_Titel.Text = ROL1;
                    lbl_Username.Text = Usern;
                    break;
                case 2:
                    AddSite.Visible = true; AddSite.Disabled = false;
                    DeleteSite.Visible = true; DeleteSite.Disabled = false;
                    SpelPagina.Visible = true; SpelPagina.Disabled = false;
                    lnkbtn_Logout.Visible = true; lnkbtn_Logout.Enabled = true;
                    lbl_Titel.Text = ROL2;
                    lbl_Username.Text = Usern;
                    break;
                default:
                    lbl_error.Text = ROL2;
                    break;
            }
        }
        //  ----------------------https://stackoverflow.com/questions/6635349/how-to-delete-cookies-on-an-asp-net-website door Pixelbits----------------------------------
        public void ExpireAllCookies() //kill all cookies
        {
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i];
                    if (cookie != null)
                    {
                        var cookieName = cookie.Name;
                        var expiredCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }

                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();
            }
        }
        //  ----------------------https://stackoverflow.com/questions/6635349/how-to-delete-cookies-on-an-asp-net-website door Pixelbits----------------------------------
        protected void lnkbtn_Logout_Click(object sender, EventArgs e)
        {
            
            if (Request.Cookies["AuthenticationCookie"] != null)
            {
                ExpireAllCookies();
            }
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/Login.aspx");            //   <--    https://stackoverflow.com/questions/19652021/how-to-really-logout-in-asp-net

        }
        /* protected void Logout_ServerClick(object sender, EventArgs e) //opgeschorte functie
         {
             // https://forums.asp.net/t/2059637.aspx?how+to+a+href+OnClick+event+in+asp+net+C+ -----------------------------------

             if (Request.Cookies["AuthenticationCookie"] != null)
             {
                 HttpCookie Koekje = new HttpCookie("AuthenticationCookie");
                 Koekje.Expires = DateTime.Now.AddDays(-1D);
                 Response.Cookies.Add(Koekje);
                 Server.Transfer("~/Login.aspx");
             }




         }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["AuthenticationCookie"] != null)
                {
                    HttpCookie Koekje = Request.Cookies["AuthenticationCookie"];
                    string User = Koekje["Username"];
                    Navigatiecontrols(User);
                }
                else
                {
                    int Rol = 0;

                    Doorverwijzen(Rol);
                }


            }
        }


    }
}