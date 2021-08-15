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

namespace P_Art.Pages.P_Art.Pages
{
    public partial class AfterLogin : System.Web.UI.Page
    {
        public Class_User _cls_User = new Class_User();
        public Class_Zaman _zm = new Class_Zaman();
        Class_Panels _clsPanels = new Class_Panels();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        private void prepareLogins()
        {
            Class_Layer.CheckSession();
            if (HttpContext.Current.Session["CurrentUser"] == null)
            {
              //  linkInfo.HRef = "#";
                linkJaryan.HRef = "#";
                linkNews.HRef = "#";
                linkOtherNation.HRef = "#";
                linkSima.HRef = "#";
                linkTahlil.HRef = "#";
                linkTamarkoz.HRef = "#";
                linkTelegram.HRef = "#";
                linkTwitter.HRef = "#";
                linkTv.HRef = "#";
            }
            else
            {
              //  linkInfo.HRef = "#";
                linkJaryan.HRef = "/Pages/P-Art/Pages/NewsTimeLine.aspx";
                linkNews.HRef = "/News/Latest/";
                linkOtherNation.HRef = "/Pages/P-Art/Pages/Internationalnews.aspx";
                linkSima.HRef = "/Movies/Latest/";
                linkTahlil.HRef = "/Analysis";
                linkTamarkoz.HRef = "/Pages/P-Art/Pages/NewsFocus.aspx";
                linkTelegram.HRef = "/Pages/P-Art/Pages/Telegram.aspx";
                linkTwitter.HRef = "/Pages/P-Art/Pages/Social.aspx";
                linkTv.HRef = "/Movies/Latest#showtv";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!Page.IsPostBack)
            {
                string date = _zm.Today();
                lblDate.InnerText = date;
                List<Class_CurrencyStats> currencyStatsList = Class_CurrencyStats.GetList(date.Replace("/", ""));
                //lblDolar.InnerText = currencyStatsList.FirstOrDefault(i => i.Title == "دلار" &&
                //i.CurrencyType == (byte)2).Price;
                //lblEuro.InnerText = currencyStatsList.FirstOrDefault(i => i.Title == "یورو" &&
                //i.CurrencyType == (byte)2).Price;
                //lblSeke.InnerText = currencyStatsList.FirstOrDefault(i => i.Title == "سکه بهار آزادی" &&
                //i.CurrencyType == (byte)3).Price;
                //lblNim.InnerText = currencyStatsList.FirstOrDefault(i => i.Title == "نیم سکه" &&
                //i.CurrencyType == (byte)3).Price;
                //lblRob.InnerText = currencyStatsList.FirstOrDefault(i => i.Title == "ربع سکه" &&
                //i.CurrencyType == (byte)3).Price;

                lblToday.InnerText = Class_Static.StrPersianWeekday(DateTime.Now.DayOfWeek.ToString());
                lblWeekdayMonth.InnerText = Class_Static.StrDayOfMonthWord(date.Split('/')[2]) +
                    " " + Class_Static.StrMonthName(date.Split('/')[1]);
                prepareLogins();
                UserPanelList = Class_Layer.UserPanels();
                List<NimtaType> nimta = (new Class_Nimta()).GetTodayNimta();
                rptNimta.DataSource = nimta;
                rptNimta.DataBind();
                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);

                    lblUser.InnerText = (new Class_Panels()).GetParminById(Convert.ToInt32(UserPanelList[0])).AgName;
                }
            }
        }
    }
}