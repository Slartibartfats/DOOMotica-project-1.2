using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DOOMotica_1._2
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //is het de eerste keer
            if(!IsPostBack)
            {
                //bestaat het koekje
                if (HttpContext.Current.Request.Cookies["AuthenticationCookie"] != null)
                {
                    //bestaat de waarde Username
                    lbl_GebruikerNaam.Text = HttpContext.Current.Request.Cookies["AuthenticationCookie"]["Username"];
                    Server.Transfer("~/ MEMBERS / Home.aspx");
                }
            }
        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

    }
}