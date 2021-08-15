using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class AutoLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "", password = "",returnUrl= "";
            if (Request.QueryString.Count == 0) return;

            username = Request.QueryString["username"];
            password = Request.QueryString["pass"];
            returnUrl = Request.QueryString["url"];



            Tbl_AgenceMembers CurrentUser = new Tbl_AgenceMembers();
            Class_User _cls_User = new Class_User();

            CurrentUser = _cls_User.AuthenticateUser(username, password);

            if (CurrentUser == null)
            {

                return;

            }
            else
            {
                Class_Layer.AddOnlineUser(CurrentUser);
                Session["CurrentUser"] = CurrentUser;
                Session["IsAdmin"] = false;
                if (returnUrl == "")
                {

                    FormsAuthentication.RedirectFromLoginPage("WebUserPortal", false);
                }else
                {
                    FormsAuthentication.SetAuthCookie("WebUserPortal", false);
                    Response.Redirect("~/" + returnUrl);

                }

            }
        }
    }
}