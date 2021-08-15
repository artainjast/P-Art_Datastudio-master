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


namespace P_Art.Pages.P_Art.MasterPages
{
    public partial class PanelMasterPage : System.Web.UI.MasterPage
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public Class_User _cls_User = new Class_User();
        public Class_Zaman _zm = new Class_Zaman();
        Class_Panels _clsPanels = new Class_Panels();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        private void prepareLogins()
        {
            //////if (HttpContext.Current.Session["CurrentUser"] == null)
            //////{
            //////    linkJaryan.HRef = "";
            //////    linkNews.HRef = "";
            //////    linkOtherNation.HRef = "";
            //////    linkSima.HRef = "";
            //////    linkTahlil.HRef = "";
            //////    linkTamarkoz.HRef = "";
            //////    linkTelegram.HRef = "";
            //////    linkTwitter.HRef = "";
            //////    linkTv.HRef = "";
            //////    linkInstagram.HRef = "";
            //////    LinkExportExcel.HRef = "";
            //////    NewMedia.HRef = "";
            //////    LinkGoogleApi.HRef = "";
            //////    Competitors.HRef = "";
            //////}
            //////else
            //////{
            //////    linkNews.HRef = "/fasterNewsList/";

            //////    if (ParminTable.AccessPagingNews == true)
            //////    {
            //////        linkNewsPaging.Style.Remove("display");
            //////        linkNewsPaging.HRef = "/PagingNewsList/";
            //////    }
            //////    else
            //////    {
            //////        linkNewsPaging.Style.Add("display", "none");
            //////        linkNewsPaging.Disabled = true;
            //////    }

            //////    if (ParminTable.AccessSearchAllMedia == true)
            //////    {
            //////        linkNewsStreaming.Style.Remove("display");
            //////        linkNewsStreaming.HRef = "/SearchAllMediaPaging/";
            //////    }
            //////    else
            //////    {
            //////        linkNewsStreaming.Style.Add("display", "none");
            //////        linkNewsStreaming.Disabled = true;
            //////    }

            //////    linkOtherNation.HRef = "/ForeignNews/";
            //////    linkSima.HRef = "/Movies/Latest/";
            //////    if (ParminTable.AccessAnalysis == true)
            //////    {
            //////        linkTahlil.HRef = "/Analysis";
            //////    }
            //////    else
            //////    {
            //////        linkTahlil.Disabled = true;
            //////    }
            //////    linkTamarkoz.HRef = "";/*"/Pages/P-Art/Pages/NewsFocus.aspx";*/
            //////    if (ParminTable.AccessTelegram == true)
            //////    {
            //////        linkTelegram.HRef = "/Telegram/";
            //////    }
            //////    else
            //////    {
            //////        linkTelegram.Disabled = true;
            //////    }


            //////    if (ParminTable.AccessTwitter == true)
            //////    {
            //////        linkTwitter.HRef = "/Twitter/";
            //////    }
            //////    else
            //////    {
            //////        linkTwitter.Disabled = true;
            //////    }


            //////    if (ParminTable.AccessJaryan == true)
            //////    {
            //////        linkJaryan.HRef = "/ProcessMediaAnalysis/";
            //////    }
            //////    else
            //////    {
            //////        linkJaryan.Disabled = true;
            //////    }

            //////    if (ParminTable.AccessInstagram == true)
            //////    {
            //////        linkInstagram.HRef = "/Instagram/";
            //////    }
            //////    else
            //////    {
            //////        linkInstagram.Disabled = true;
            //////    }

            //////    if (ParminTable.AccessExcelExport == true)
            //////    {
            //////        LinkExportExcel.Style.Remove("display");
            //////        LinkExportExcel.HRef = "/ExportExcel/";
            //////    }
            //////    else
            //////    {
            //////        LinkExportExcel.Style.Add("display", "none");
            //////        LinkExportExcel.Disabled = true;
            //////    }

            //////    if (ParminTable.AccessGoogleSearchApi == true)
            //////    {
            //////        LinkGoogleApi.Style.Remove("display");
            //////        LinkGoogleApi.HRef = "/pagingGoogleApi/";
            //////    }
            //////    else
            //////    {
            //////        LinkGoogleApi.Style.Add("display", "none");
            //////        LinkGoogleApi.Disabled = true;
            //////    }

            //////    linkTv.HRef = "/LiveNews/";
          
            //////    NewMedia.HRef = "/NewMediaNewsList/";
            //////    if (ParminTable.AccessAdvertise == true)
            //////    {
            //////        LinkAdvertising.HRef = "/Advertising/";
            //////        LinkAdvertising.Style.Remove("display");
            //////    }

            //////    else
            //////    {
            //////        LinkAdvertising.Style.Add("display", "none");
            //////        LinkAdvertising.Disabled = true;
            //////    }
            //////    Competitors.HRef= "/CompetitorsAnalyze/";
            //////}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!Page.IsPostBack)
            {
                string date = _zm.Today();
                List<Class_CurrencyStats> currencyStatsList = Class_CurrencyStats.GetList(date.Replace("/", ""));
                UserPanelList = Class_Layer.UserPanels();
                ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
                CurrentDateLabel.InnerText = _zm.GetTodayLongString();
                prepareLogins();
                UserPanelList = Class_Layer.UserPanels();
                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);

                    CurrentUserLabel.InnerText = (new Class_Panels()).GetParminById(Convert.ToInt32(UserPanelList[0])).AgName;
                }
            }

        }

        protected void lblLogout_Click(object sender, EventArgs e)
        {
            Class_Layer.SignOutCookie();
            HttpContext.Current.Response.Redirect("~/login");
        }
    }
}