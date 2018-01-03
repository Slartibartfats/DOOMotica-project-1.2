using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;


namespace DOOMotica_1._2.MEMBERS
{
    public partial class Home : System.Web.UI.Page
    {
            OleDbConnection Connectie = new OleDbConnection();
            OleDbCommand Query = new OleDbCommand();
            
        protected void Page_Load(object sender, EventArgs e)
        {

            Connectie.ConnectionString = ConfigurationManager.ConnectionStrings["Harry"].ToString();

            Query.CommandText = "SELECT DISTINCT Hyperlink, Website_naam FROM(WEBSITES INNER JOIN Geeft_weer1 ON  Geeft_weer1.URLnr = WEBSITES.URLnr) INNER JOIN LID ON LID.Lidnr = Geeft_weer1.Lidnr";

            try
            {
                Connectie.Open();

            }
            catch (Exception exc) { }
            finally { Connectie.Close(); }







        }
    }
}