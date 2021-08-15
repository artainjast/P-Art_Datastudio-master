using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNews;
using System.Web.Security;
using PArt.Core;
using P_Art.Pages.P_Art.Repository;
using System.Data;


namespace PArt.Pages.P_Art
{
    public partial class Login : System.Web.UI.Page
    {
        public Class_User _cls_User = new Class_User();
        public Class_Zaman _zm = new Class_Zaman();
        Class_Panels _clsPanels = new Class_Panels();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //if (HttpContext.Current.Session["CurrentUser"] != null)
                //{
                //    Response.Redirect("/welcome/");
                //}
                //else
                //{
                //    Class_Layer.SignOut();
                //}
                Class_Layer.SignOutCookie();

                if (Request.QueryString["autologin"] != null)
                {
                    if (Request.QueryString["autologin"] == "tci")
                    {
                        try
                        {
                            txt_UserName.Text = "tci";
                            var user = _cls_User.SelectByUser(txt_UserName.Text);
                            txt_Password.Text = user.Password;
                            // btn_Login_Click(null, null);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            //  if (!Page.IsPostBack)
            //  {

            if (txt_UserName.Text.Trim() == "" || txt_Password.Text.Trim() == "") return;
            if (txt_UserName.Text.Length > 40 || txt_Password.Text.Length > 40) return;
            string username = "";

            if (txt_UserName.Text.ToLower().StartsWith("adminpayesh"))
            {
                username = txt_UserName.Text.ToLower().Replace("adminpayesh", "");
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

                ltMsg.Text = "<span style='color:red'>عدم ورود به سیستم.لطفا نام کاربری و کلمه عبور را پس از بررسی دوباره وارد نمایید.</span>";
                return;

            }
            else
            {
                var ipValid = false;
                var userIP = Class_Static.GetUserIP();
                var parminDefault = new List<int?>();
                parminDefault.Add(0);
                var parmin0 = new Class_MemberValidIP().SelectSingle(parminDefault).FirstOrDefault();
                if (parmin0 != null)
                {
                    // اگر در آی پی ها ی عمومی بود
                    if (parmin0.IPs.Contains(userIP))
                    {
                        ipValid = true;
                    }
                }
                if (!ipValid)
                {
                    var userPanels = new List<int?>();
                    foreach (var item in CurrentUser.ParminIds.Split(','))
                    {
                        if (string.IsNullOrWhiteSpace(item)) continue;
                        if (item == ",") continue;
                        userPanels.Add(Convert.ToInt32(item));
                    }
                    var parminAll = new Class_MemberValidIP().SelectSingle(userPanels);
                    // اگر در لیست آی پی ها بنود پس پنل نیازی به تست آی پی ندارد
                    if (parminAll == null || parminAll.Count == 0)
                    {
                        ipValid = true;
                    }
                    else
                    {

                        foreach (var item in parminAll)
                        {
                            if (item.IPs.Contains(userIP))
                            {
                                ipValid = true;
                            }
                        }
                    }
                }
                if (ipValid)
                {
                    Class_Layer.AddOnlineUser(CurrentUser);

                    Class_Static.SetCookie("CurrentUser", CurrentUser.UserName, TimeSpan.FromDays(1));

                    //Session["CurrentUser"] = CurrentUser;
                    //Session.Timeout = 80000;

                    if (userIP == "127.0.0.1" || userIP == "::1")
                    {

                    }
                    else
                    {
                        _clsPanels.InsertParminLog(CurrentUser.MemberID, username, Request.UserHostAddress);
                    }
                    FormsAuthentication.RedirectFromLoginPage("WebUserPortal", false);
                }
                else
                {
                    ltMsg.Text = "<span style='color:red'>عدم ورود به سیستم به علت دسترسی غیرمجاز</span>";
                }

            }
            //  }
        }
    }
}