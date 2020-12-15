using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp
{
    public class Global : HttpApplication
    {
        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session["LoggedToIS"] = false;
            HttpContext.Current.Session["LoggedAdmin"] = false;
            HttpContext.Current.Session["LoggedUserName"] = "";
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
    }
}