using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast.Selectors;

namespace WebApp
{
    public partial class Login : Page
    {
        private void MsgBox(string sMessage)
        {
            string msg = "<script language=\"javascript\">";
            msg += "alert('" + sMessage + "');";
            msg += "</script>";
            Response.Write(msg);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["LoggedAdmin"] = false;
            Session["LoggedUserName"] = "";
            Session["LoggedToIS"] = false;

            if (edJmeno.Text == "user" && edHeslo.Text == "user")
            {
                Session["LoggedAdmin"] = false;
                Session["LoggedUserName"] = "User";
                Session["LoggedToIS"] = true;

            }
            else if (edJmeno.Text == "admin" && edHeslo.Text == "admin")
            {
                Session["LoggedAdmin"] = true;
                Session["LoggedUserName"] = "Admin";
                Session["LoggedToIS"] = true;
            }
            else 
               MsgBox("Chybné jméno nebo heslo pro přihlášení");

            Response.Redirect(@"~/Default.aspx");
        }
    }
}