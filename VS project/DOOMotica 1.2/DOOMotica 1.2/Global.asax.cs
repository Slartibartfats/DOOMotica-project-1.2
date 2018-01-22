using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Diagnostics;


namespace DOOMotica_1._2
{
    public class Global : System.Web.HttpApplication
    {
        Process p = new Process();
        protected void Application_Start(object sender, EventArgs e)
        {
            
         //   p.StartInfo.FileName = "~/DaHaus project/DaHaus.application";
           // p.Start();

            //-----https://forums.asp.net/post/1679786.aspx---Jessica Cao - MSFT
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}