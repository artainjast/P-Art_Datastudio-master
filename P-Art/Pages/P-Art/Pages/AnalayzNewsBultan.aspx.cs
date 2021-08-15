using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Core;
using P_Art.Pages.P_Art.Repository;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class AnalayzNewsBultan : System.Web.UI.Page
    {
        private Class_Zaman _zm = new Class_Zaman();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!Page.IsPostBack)
            {
                string date = _zm.Today();
                UserPanelList = Class_Layer.UserPanels();
                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                    CurrentUserLabel.InnerText = string.Empty;
                    CurrentUserLabel.InnerText = "بولتن تحلیل محتوای اخبار ";
                    CurrentUserLabel.InnerText += (new Class_Panels()).GetParminById(Convert.ToInt32(UserPanelList[0])).AgName;

                }
                if (Request.QueryString["FromDate"] != null)
                {
                    FromDateHiddenField.Value = FromDateLabel.Text = Request.QueryString["FromDate"];
                    FromDateLabel.Text = Request.QueryString["FromDate"].ToString();
                    ToDateHiddenField.Value = ToDateLabel.Text = Request.QueryString["ToDate"];
                    //ToDateLabel.Text = Request.QueryString["ToDate"].ToString();

                }
                else
                {
                    FromDateHiddenField.Value = _zm.Today();
                    ToDateHiddenField.Value = _zm.Today();
                }
            }



        }
    }
}