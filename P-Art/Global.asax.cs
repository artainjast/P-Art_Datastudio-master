using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace P_Art
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("CompetitorsAnalyze",
                      "CompetitorsAnalyze/{*query}",
                      "~/Pages/P-Art/Pages/CompetitorsAnalyze.aspx", false,
                      new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });
            RouteTable.Routes.MapPageRoute("Welcome",
            "Welcome/{*query}",
            "~/Pages/P-Art/Pages/welcome.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("BultanArchive",
            "News/BultanArchive",
            "~/Pages/P-Art/Pages/BultanArchive.aspx");

            //RouteTable.Routes.MapPageRoute("LoginPage",
            //"login",
            //"~/Pages/P-Art/login.aspx");

            RouteTable.Routes.MapPageRoute("LoginPage",
            "login",
            "~/Pages/P-Art/Login.aspx");

            RouteTable.Routes.MapPageRoute("LoginPageNamayandeh",
            "loging",
            "~/Pages/P-Art/LoginNamayandeh.aspx");

            RouteTable.Routes.MapPageRoute("NewsSearch",
            "News/Search/{*query}",
            "~/Pages/P-Art/Pages/SearchResult.aspx", false,
            new RouteValueDictionary
            { { "tag","[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("NewsExport",
            "News/export",
            "~/Pages/P-Art/Pages/ReportNews.aspx");

            RouteTable.Routes.MapPageRoute("NewsList",
            "NewsList/{*query}",
            "~/Pages/P-Art/Pages/DomesticNews.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });


            RouteTable.Routes.MapPageRoute("RssShowNews",
           "RssShowNews/{*query}",
           "~/Pages/P-Art/Pages/RssShowNews.aspx", false,
           new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("RssNewsList",
            "RssNewsList/{*query}",
            "~/Pages/P-Art/Pages/RssPage.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("FasterNewsList",
            "FasterNewsList/{*query}",
            "~/Pages/P-Art/Pages/FasterDomesticNews.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("NewMediaNewsList",
            "NewMediaNewsList/{*query}",
            "~/Pages/P-Art/Pages/NewMediaNewsList.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("Inbox",
            "Inbox/{*query}",
            "~/Pages/P-Art/Pages/Inbox.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("PagingNewsList",
            "PagingNewsList/{*query}",
            "~/Pages/P-Art/Pages/DomesticNewsPaging.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("PagingGoogleApi",
            "PagingGoogleApi/{*query}",
            "~/Pages/P-Art/Pages/GoogleApiNewsPaging.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });


            RouteTable.Routes.MapPageRoute("AdvertisesList",
            "AdvertisesList/{*query}",
            "~/Pages/P-Art/Pages/envAllAdvertises.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("AdvertiseImagesList",
            "AdvertiseImagesList/{*query}",
            "~/Pages/P-Art/Pages/envDailyScreen.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("SiteSettings",
           "SiteSettings/{*query}",
           "~/Pages/P-Art/Pages/SiteSettings.aspx", false,
           new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("LiveNews",
            "LiveNews/{*query}",
            "~/Pages/P-Art/Pages/LiveNews.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TelegramOld",
            "TelegramOld/{*query}",
            "~/Pages/P-Art/Pages/Telegram.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TelegramBultanArchive",
            "TelegramBultanArchive/{*query}",
            "~/Pages/P-Art/Pages/TelegramBultanArchive.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TelegramKeywordsOld",
            "TelegramKeywordsOld/{*query}",
            "~/Pages/P-Art/Pages/TelegramKeywords.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TelegramMessageShowOld",
            "TelegramMessageShowOld/{Id}",
            "~/Pages/P-Art/Pages/TelegramMessageShow.aspx");

            RouteTable.Routes.MapPageRoute("TelegramAnalyzeOld",
            "TelegramAnalyzeOld/{*query}",
            "~/Pages/P-Art/Pages/TelegramAnalyze.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("Telegram",
            "Telegram/{*query}",
            "~/Pages/P-Art/Pages/TelegramNew.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });


            RouteTable.Routes.MapPageRoute("TelegramKeywords",
            "TelegramKeywords/{*query}",
            "~/Pages/P-Art/Pages/TelegramKeywordsNew.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("topbrands",
           "topbrands/{*query}",
           "~/topbranda3.aspx", false,
           new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TelegramMessageShow",
            "TelegramMessageShow/{Id}",
            "~/Pages/P-Art/Pages/TelegramMessageShowNew.aspx");

            RouteTable.Routes.MapPageRoute("TelegramAnalyze",
            "TelegramAnalyze/{*query}",
            "~/Pages/P-Art/Pages/TelegramAnalyzeNew.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });


            RouteTable.Routes.MapPageRoute("Twitter",
          "Twitter/{*query}",
          "~/Pages/P-Art/Pages/Twitter.aspx", false,
          new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TwitterBultanArchive",
            "TwitterBultanArchive/{*query}",
            "~/Pages/P-Art/Pages/TwitterBultanArchive.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TwitterKeywords",
            "TwitterKeywords/{*query}",
            "~/Pages/P-Art/Pages/TwitterKeywords.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });


            RouteTable.Routes.MapPageRoute("TwitterAnalyze",
            "TwitterAnalyze/{*query}",
            "~/Pages/P-Art/Pages/TwitterAnalyze.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TwitterPostShow",
           "TwitterPostShow/{Id}",
           "~/Pages/P-Art/Pages/TwitterPostShow.aspx");



            RouteTable.Routes.MapPageRoute("Instagram",
          "Instagram/{*query}",
          "~/Pages/P-Art/Pages/Instagram.aspx", false,
          new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            // RouteTable.Routes.MapPageRoute("InstagramBultanArchive",
            // "InstagramBultanArchive/{*query}",
            // "~/Pages/P-Art/Pages/InstagramBultanArchive.aspx", false,
            // new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("InstagramKeywords",
            "InstagramKeywords/{*query}",
            "~/Pages/P-Art/Pages/InstagramKeywords.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });


            // RouteTable.Routes.MapPageRoute("InstagramAnalyze",
            // "InstagramAnalyze/{*query}",
            // "~/Pages/P-Art/Pages/InstagramAnalyze.aspx", false,
            // new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("InstagramPostShow",
           "InstagramPostShow/{Id}",
           "~/Pages/P-Art/Pages/InstagramPostShow.aspx");


            RouteTable.Routes.MapPageRoute("ShowAdvertise",
            "ShowAdvertise/{Id}",
            "~/Pages/P-Art/Pages/envShowAdvertise.aspx");



            RouteTable.Routes.MapPageRoute("SearchAllMedia",
            "SearchAllMedia/{*query}",
            "~/Pages/P-Art/Pages/SearchAllMedia.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("SearchAllMediaPaging",
            "SearchAllMediaPaging/{*query}",
            "~/Pages/P-Art/Pages/SearchAllMediaPaging.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TwitterOld",
          "TwitterOld/{*query}",
          "~/Pages/P-Art/Pages/Social.aspx", false,
          new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TwitterBultanArchiveOld",
            "TwitterBultanArchiveOld/{*query}",
            "~/Pages/P-Art/Pages/SocialBultanArchive.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("TwitterKeywordsOld",
            "TwitterKeywordsOld/{*query}",
            "~/Pages/P-Art/Pages/SocialKeywords.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });


            RouteTable.Routes.MapPageRoute("TwitterAnalyzeOld",
            "TwitterAnalyzeOld/{*query}",
            "~/Pages/P-Art/Pages/SocialAnalyz.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });




            RouteTable.Routes.MapPageRoute("DataCenter",
            "DataCenter/{*query}",
            "~/Pages/P-Art/Pages/DataCenter.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("ForeignNews",
            "ForeignNews/{*query}",
            "~/Pages/P-Art/Pages/ForeignNews.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("AfterLogin",
            "AfterLogin",
            "~/Pages/P-Art/Pages/AfterLogin.aspx");


            RouteTable.Routes.MapPageRoute("ExportExcel",
            "ExportExcel",
            "~/Pages/P-Art/Pages/ExportReports.aspx");


            RouteTable.Routes.MapPageRoute("Advertising",
            "Advertising",
            "~/Pages/P-Art/Pages/AdvertisingProcessing.aspx");

            RouteTable.Routes.MapPageRoute("Highlight",
            "News/highlight",
            "~/Pages/P-Art/Pages/Highlight.aspx");

            RouteTable.Routes.MapPageRoute("NewsUpdate",
            "News/{query}",
            "~/Pages/P-Art/Pages/DomesticNews.aspx");

            RouteTable.Routes.MapPageRoute("NewsArchive",
            "News/{query}",
            "~/Pages/P-Art/Pages/DomesticNews.aspx");

            RouteTable.Routes.MapPageRoute("NewsPaging",
            "News/{query}/{Paging}",
            "~/Pages/P-Art/Pages/DomesticNews.aspx");

            RouteTable.Routes.MapPageRoute("ShowNews",
            "ShowNews/{newsid}",
            "~/Pages/P-Art/Pages/ShowNews.aspx");

            RouteTable.Routes.MapPageRoute("DataCenterShowNews",
            "DataCenterShowNews/{newsid}",
            "~/Pages/P-Art/Pages/DataCenterShowNews.aspx");

            RouteTable.Routes.MapPageRoute("DataCenterSavedNews",
            "DataCenterSavedNews/{newsid}",
            "~/Pages/P-Art/Pages/DataCenterSavedNews.aspx");


            RouteTable.Routes.MapPageRoute("Gallery",
            "Gallery",
            "~/Pages/P-Art/Pages/gallery.aspx");

            RouteTable.Routes.MapPageRoute("ShowImage",
            "ShowImage/{ImageId}",
            "~/Pages/P-Art/Pages/ShowImage.aspx");

            RouteTable.Routes.MapPageRoute("BreakNews",
            "BreakNews",
            "~/Pages/P-Art/Pages/BreakNews.aspx");

            RouteTable.Routes.MapPageRoute("ShowNewsBlocks",
            "ShowBlock/{newsid}",
            "~/Pages/P-Art/Pages/ShowNews.aspx");

            RouteTable.Routes.MapPageRoute("Movie",
            "Movies/{query}",
            "~/Pages/P-Art/Pages/Movies.aspx");

            RouteTable.Routes.MapPageRoute("ShowVideo",
            "ShowVideo/{VideoId}",
            "~/Pages/P-Art/Pages/Movies.aspx");

            RouteTable.Routes.MapPageRoute("Movies",
            "Movies/{query}",
            "~/Pages/P-Art/Pages/Movies.aspx");

            RouteTable.Routes.MapPageRoute("MoviesPaging",
            "Movies/{query}/{Paging}",
            "~/Pages/P-Art/Pages/Movies.aspx");

            RouteTable.Routes.MapPageRoute("Radio",
            "Radio/{query}",
            "~/Pages/P-Art/Pages/Radio.aspx");

            RouteTable.Routes.MapPageRoute("Nimta",
           "Nimta/{query}",
           "~/Pages/P-Art/Pages/Nimta.aspx");

            RouteTable.Routes.MapPageRoute("PlayRadio",
            "PlayRadio/{SoundId}",
            "~/Pages/P-Art/Pages/Radio.aspx");

            RouteTable.Routes.MapPageRoute("SendMail",
            "SendMail",
            "~/Pages/P-Art/Pages/SendMail.aspx");

            RouteTable.Routes.MapPageRoute("Analysis",
            "Analysis",
            "~/Pages/P-Art/Pages/Analyz.aspx");

            RouteTable.Routes.MapPageRoute("Analysis1",
            "Analysis1",
            "~/Pages/P-Art/Pages/MediaAnalyze.aspx");

            RouteTable.Routes.MapPageRoute("ProcessMediaAnalysis",
            "ProcessMediaAnalysis",
            "~/Pages/P-Art/Pages/MediaAnalyze.aspx");

            RouteTable.Routes.MapPageRoute("ProcessMediaAnalysisPrint",
            "ProcessMediaAnalysisPrint/{*query}",
            "~/Pages/P-Art/Pages/MediaAnalyzePrint.aspx");


            RouteTable.Routes.MapPageRoute("about",
            "about",
            "~/Pages/P-Art/Pages/about.aspx");


            RouteTable.Routes.MapPageRoute("collaboration",
            "collaboration",
            "~/Pages/P-Art/Pages/collaboration.aspx");

            RouteTable.Routes.MapPageRoute("Print",
            "Print/{*query}",
            "~/Pages/P-Art/Pages/PrintLead.aspx", false,
            new RouteValueDictionary { { "tag", "[a-z]" }, { "page", @"\d" } });

            RouteTable.Routes.MapPageRoute("tv",
            "tv",
            "~/Pages/P-Art/Pages/DomesticNews.aspx");

            RouteTable.Routes.MapPageRoute("Social",
            "Social",
            "~/Pages/P-Art/Pages/Social.aspx");

            RouteTable.Routes.MapPageRoute("keywords",
            "keywords",
            "~/Pages/P-Art/Pages/Keywords.aspx");

            RouteTable.Routes.MapPageRoute("addnews",
            "addnews",
            "~/Pages/P-Art/Pages/addnews.aspx");



            RouteTable.Routes.MapPageRoute("KeywordAnalyse",
            "KeywordAnalyse",
            "~/Pages/P-Art/Pages/AnalyzeKeywords.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
           
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Class_Layer.SignOutCookie();

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}