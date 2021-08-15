using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P_Art.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNews;
using System.Web.Security;
using PArt.Pages.P_Art.Repository;

namespace P_Art.Pages.P_Art
{
    public partial class LoginNamayandeh : System.Web.UI.Page
    {
        public Class_User _cls_User = new Class_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Panels _clsPanel = new Class_Panels();
            var panels = _clsPanel.GetPanelNamayandehById(_clsPanel.GetLastUpdatePanel(8));

            rpt_menu.DataSource = panels;
            rpt_menu.DataBind();

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text.Trim() == "" || txt_Password.Text.Trim() == "") return;
            string username = "";

            if (txt_UserName.Text.ToLower().IndexOf("admin") > -1)
            {
                username = txt_UserName.Text.ToLower().Replace("admin", "");
                Session["IsAdmin"] = true;
            }
            else
            {
                username = txt_UserName.Text;

                Session["IsAdmin"] = false;
            }
            Tbl_AgenceMembers CurrentUser = new Tbl_AgenceMembers();
            CurrentUser = _cls_User.AuthenticateUser(username, txt_Password.Text);

            if (CurrentUser == null)
            {

                return;

            }
            else
            {
                Class_Layer.AddOnlineUser(CurrentUser);
                Session["CurrentUser"] = CurrentUser;


                FormsAuthentication.RedirectFromLoginPage("WebUserPortal", false);


            }
        }
    }
}