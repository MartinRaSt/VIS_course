using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! (bool) Session["LoggedToIS"])
            {
                laLoggedUser.Text = "žádný uživatel";
            }
            else
            {
                laLoggedUser.Text = (string) Session["LoggedUserName"];
            }
        }
    }
}