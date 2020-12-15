using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(bool) Session["LoggedToIS"])
            {
                miKnihy.Disabled = true;
                miKnihy.HRef = string.Empty;
                miKnihy.Style.Add("color", "red");

                miUzivatele.Disabled = true;
                miUzivatele.HRef = string.Empty;
                miUzivatele.Style.Add("color", "red");

                miZamestnanci.Disabled = true;
                miZamestnanci.HRef = string.Empty;
                miZamestnanci.Style.Add("color", "red");
                
            }
            else
            {
                miKnihy.Disabled = false;
                miKnihy.HRef = @"~/Knihy";
                miKnihy.Style.Remove("color");

                miUzivatele.Disabled = false;
                miUzivatele.HRef = @"~/Uzivatele";
                miUzivatele.Style.Remove("color");

                miZamestnanci.Disabled = true;
                miZamestnanci.HRef = string.Empty;
                miZamestnanci.Style.Add("color", "red");

                if ((bool) Session["LoggedAdmin"])
                {
                    miZamestnanci.Disabled = false;
                    miZamestnanci.HRef = @"~/Zamestnanci";
                    miZamestnanci.Style.Remove("color");
                }
            }
        }
    }
}