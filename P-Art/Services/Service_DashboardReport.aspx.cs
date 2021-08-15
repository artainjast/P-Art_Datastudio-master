using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using PArt.Core;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Services;
using System.Data.SqlClient;

namespace P_Art.Services
{
    public partial class Service_DashboardReport : System.Web.UI.Page
    {

        Class_Sites _clsSite = new Class_Sites();



        [WebMethod]
        public static string GetChartDay(int date)
        {
            Class_Zaman _clsZm = new Class_Zaman();
            var fromDate = "";
            var toDate = "";
            var today = _clsZm.Today();
            //   txt_fromDate.Value = _clsZm.AddDayShamsi(today ,-2);

            switch (date)
            {
                case (1):
                    {
                        toDate = today;
                        fromDate = today;
                        break;
                    }
                case (3):
                    {
                        toDate = today;
                        fromDate = _clsZm.AddDayShamsi(today, -2);
                        break;
                    }
                case (7):
                    {
                        toDate = today;
                        fromDate = _clsZm.AddDayShamsi(today, -6);
                        break;
                    }
                case (30):
                    {
                        toDate = today;
                        fromDate = _clsZm.AddDayShamsi(today, -29);
                        break;
                    }
                default: break;
            }

            return fromDate + ";" + toDate;


        }
        [WebMethod]
        public static string GetParminAll_ByMedia(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return "";
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var telegramCount = 0;
            var twitterCount = 0;
            var NewspaperCount = 0;
            var instagramCount = 0;
            var websiteCount = 0;
            if (ParminTable.AccessTelegram == true)
            {
                telegramCount = (from Massage in _db.Tbl_TLPMessage
                                 where UserPanelList.Contains(Massage.PanelID)
                                 && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                                 select Massage).Count();
            }
            if (ParminTable.AccessTwitter == true)
            {
                twitterCount = (from Post in _db.Tbl_TwitterPost
                                where UserPanelList.Contains(Post.PanelID) && Post.Active == true
                                 && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                select Post).Count();

            }

            if (ParminTable.AccessInstagram == true)
            {
                instagramCount = (from Post in _db.Tbl_InstagramPosts
                                  where UserPanelList.Contains(Post.PanelId)
                                  && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                  && Post.Active == true
                                  select Post).Count();
            }

            if (ParminTable.AccessNews == true)
            {
                websiteCount = _clsNews.GetNewsCountBySiteType(UserPanelList[0].ToString(), fromDateIndex, toDateIndex, "1");
                NewspaperCount = _clsNews.GetNewsCountBySiteType(UserPanelList[0].ToString(), fromDateIndex, toDateIndex, "2");
            }


            return NewspaperCount + "," + websiteCount + "," + instagramCount + "," + twitterCount + "," + telegramCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static int GetParminAll_Count_Newspaper(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var NewspaperCount = 0;


            if (ParminTable.AccessNews == true)
            {
                NewspaperCount = _clsNews.GetNewsCountBySiteType(UserPanelList[0].ToString(), fromDateIndex, toDateIndex, "2");
            }


            return NewspaperCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static int GetParminAll_Count_Website(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var websiteCount = 0;


            if (ParminTable.AccessNews == true)
            {
                websiteCount = _clsNews.GetNewsCountBySiteType(UserPanelList[0].ToString(), fromDateIndex, toDateIndex, "1");

            }


            return websiteCount;


        }

        [WebMethod]
        public static int GetParminAll_Count_Telegram(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var telegramCount = 0;

            if (ParminTable.AccessTelegram == true)
            {
                telegramCount = (from Massage in _db.Tbl_TLPMessage
                                 where UserPanelList.Contains(Massage.PanelID)
                                 && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                                 select Massage).Count();

              
            }


            return telegramCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }

        [WebMethod]
        public static int GetParminAll_Count_Twitter(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var twitterCount = 0;

            if (ParminTable.AccessTwitter == true)
            {
                twitterCount = (from Post in _db.Tbl_TwitterPost
                                where UserPanelList.Contains(Post.PanelID) && Post.Active == true
                                 && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                select Post).Count();

            }





            return twitterCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }

        [WebMethod]
        public static int GetParminAll_Count_Instagram(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }

            var instagramCount = 0;


            if (ParminTable.AccessInstagram == true)
            {
                instagramCount = (from Post in _db.Tbl_InstagramPosts
                                  where UserPanelList.Contains(Post.PanelId)
                                  && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                  && Post.Active == true
                                  select Post).Count();
            }




            return instagramCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }


        [WebMethod]
        public static Tbl_Media_Type[] LoadLast_Telegram_Source(int count, string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;
            var telegramCount = new List<Tbl_Media_Type>();

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return telegramCount.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }




            if (ParminTable.AccessTelegram == true)
            {
                string fromTime = "0000";
                string toTime = "2400";
                long fromDateTimeIndex_ = Convert.ToInt64(fromDate.Replace("/", "") + fromTime);
                long toDateTimeIndex_ = Convert.ToInt64(toDate.Replace("/", "") + toTime);

                DataSet ds = Tbl_News_General.GetHighNumberMedia(Convert.ToInt32(UserPanelList.FirstOrDefault()), fromDateTimeIndex_, toDateTimeIndex_, "");
                AllMedia_HighSource mediaList = new AllMedia_HighSource();
                //mediaList.AllMediaCount = Tbl_Media_CountType.GetFromDataRow(ds.Tables[0].Select());
                //mediaList.NewsCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[1].Select());
                //mediaList.NewsPaperCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[2].Select());

                // telegramCount = mediaList.AllMediaCount.TelegramCount;
                mediaList.TelegramCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[3].Select());
                telegramCount = mediaList.TelegramCountList;
                //  mediaList.TwitterCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[4].Select());
            }
            foreach (var item in telegramCount)
            {
                var channel = _db.Tbl_TLPChannels.FirstOrDefault(t => t.ChannelTitle == item.SourceMedia);
                if (channel != null)
                {

                    item.ChannelID = "@" + channel.Username;
                }
            }

            return telegramCount.ToArray();
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static Tbl_Media_Type[] LoadLast_Twitter_Source(int count, string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;
            var telegramCount = new List<Tbl_Media_Type>();

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return telegramCount.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }

            if (ParminTable.AccessTwitter == true)
            {
                string fromTime = "0000";
                string toTime = "2400";
                long fromDateTimeIndex_ = Convert.ToInt64(fromDate.Replace("/", "") + fromTime);
                long toDateTimeIndex_ = Convert.ToInt64(toDate.Replace("/", "") + toTime);

                DataSet ds = Tbl_News_General.GetHighNumberMedia(Convert.ToInt32(UserPanelList.FirstOrDefault()), fromDateTimeIndex_, toDateTimeIndex_, "");
                AllMedia_HighSource mediaList = new AllMedia_HighSource();
                //mediaList.AllMediaCount = Tbl_Media_CountType.GetFromDataRow(ds.Tables[0].Select());
                //mediaList.NewsCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[1].Select());
                //mediaList.NewsPaperCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[2].Select());

                // telegramCount = mediaList.AllMediaCount.TelegramCount;
                mediaList.TwitterCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[4].Select());
                telegramCount = mediaList.TwitterCountList;
                //  mediaList.TwitterCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[4].Select());
            }
           

            return telegramCount.ToArray();
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static Tbl_Media_Type[] LoadLast_Instagram_Source(int count, string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
           
            var telegramCount = new List<Tbl_Media_Type>();

         

            return telegramCount.ToArray();
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue_New[] Social_Count_Day(string fromDate, string toDate)
        {
            var values = new List<ChartValue_New>();


            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
#pragma warning disable CS0219 // The variable 'telegramData' is assigned but its value is never used
            var telegramData = 0;
#pragma warning restore CS0219 // The variable 'telegramData' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'twitterCount' is assigned but its value is never used
            var twitterCount = 0;
#pragma warning restore CS0219 // The variable 'twitterCount' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'instagramCount' is assigned but its value is never used
            var instagramCount = 0;
#pragma warning restore CS0219 // The variable 'instagramCount' is assigned but its value is never used





            //ints0.Add("تلگرام");
            //ints0.Add("توییتر");
            //ints0.Add("اینستاگرام");


            //values.Add(new ChartValue_New { name = "گزارش", data = ints0 });

            values.Clear();
            List<object> ints = new List<object>();
            ints.Clear();
            ints = new List<object>();
            ints.Clear();

            var dt = DateTime.Now;
            var fromDateDT = ShamsiToMiladi(fromDate);
            var toDateDT = ShamsiToMiladi(toDate);
            var chartDate = GetChartDate(toDateDT, fromDateDT, "day");

            var sortedDict = from entry in chartDate orderby entry.Key ascending select entry;

            foreach (var item in sortedDict)
                ints.Add("[" + item.Value + "]");

            values.Add(new ChartValue_New { name = "", data = ints });


            //تلگرام
            ints = new List<object>();
            ints.Clear();
            foreach (var item in chartDate)
            {
                if (ParminTable.AccessTelegram == true)
                {
                    string fromTime = "0000";
                    string toTime = "2400";
                    long fromDateTimeIndex_ = Convert.ToInt64(item.Key.Replace("/", "") + fromTime);
                    long toDateTimeIndex_ = Convert.ToInt64(item.Key.Replace("/", "") + toTime);

                    var count = 0;
                    // count = _clsInbox.SelectAllCount(ShahrsaziSiteID, " WHERE   [DarkhastDateIndex]=" + item.Key.Trim(), "ASC", "DarkhastDateIndex");
                    count = (from Massage in _db.Tbl_TLPMessage
                             where UserPanelList.Contains(Massage.PanelID)
                             && Massage.DateTimeIndex >= fromDateTimeIndex_ && Massage.DateTimeIndex <= toDateTimeIndex_
                             select Massage).Count();
                    ints.Add(count);
                }
                else
                {
                    var count = 0;

                    ints.Add(count);
                }
            }
            values.Add(new ChartValue_New { name = "تلگرام", data = ints });


            //توییتر
            ints = new List<object>();
            ints.Clear();
            foreach (var item in chartDate)
            {
                if (ParminTable.AccessTwitter == true)
                {
                    string fromTime = "0000";
                    string toTime = "2400";
                    long fromDateTimeIndex_ = Convert.ToInt64(item.Key.Replace("/", "") + fromTime);
                    long toDateTimeIndex_ = Convert.ToInt64(item.Key.Replace("/", "") + toTime);

                    var count = 0;
                    // count = _clsInbox.SelectAllCount(ShahrsaziSiteID, " WHERE   [DarkhastDateIndex]=" + item.Key.Trim(), "ASC", "DarkhastDateIndex");
                    count = (from Massage in _db.Tbl_TwitterPost
                             where UserPanelList.Contains(Massage.PanelID)
                             && Massage.DateTimeIndex >= fromDateTimeIndex_ && Massage.DateTimeIndex <= toDateTimeIndex_
                             select Massage).Count();
                    ints.Add(count);
                }
                else
                {

                    var count = 0;

                    ints.Add(count);
                }
            }
            values.Add(new ChartValue_New { name = "توییتر", data = ints });

            //اینستاگرام
            ints = new List<object>();
            ints.Clear();
            foreach (var item in chartDate)
            {
                if (ParminTable.AccessInstagram == true)
                {
                    string fromTime = "0000";
                    string toTime = "2400";
                    long fromDateTimeIndex_ = Convert.ToInt64(item.Key.Replace("/", "") + fromTime);
                    long toDateTimeIndex_ = Convert.ToInt64(item.Key.Replace("/", "") + toTime);

                    var count = 0;
                    // count = _clsInbox.SelectAllCount(ShahrsaziSiteID, " WHERE   [DarkhastDateIndex]=" + item.Key.Trim(), "ASC", "DarkhastDateIndex");
                    count = (from Massage in _db.Tbl_InstagramPosts
                             where UserPanelList.Contains(Massage.PanelId)
                             && Massage.DateTimeIndex >= fromDateTimeIndex_ && Massage.DateTimeIndex <= toDateTimeIndex_
                             select Massage).Count();
                    ints.Add(count);
                }
                else
                {

                    var count = 0;

                    ints.Add(count);
                }

            }
            values.Add(new ChartValue_New { name = "اینستاگرام", data = ints });

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValueSolo_New[] TV_Count_All(string fromDate, string toDate)
        {
            var values = new List<ChartValueSolo_New>();


            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }




            List<string> IranNetworkName = new List<string>();
            List<string> IntenationalNetworkName = new List<string>();

            IranNetworkName.Add("شبکه 1");
            IranNetworkName.Add("شبکه 2");
            IranNetworkName.Add("شبکه خبر");
            IranNetworkName.Add("شبکه 5");
            IranNetworkName.Add("شبکه 3");
            IranNetworkName.Add("شبکه 4");

            IntenationalNetworkName.Add("شبکه بي بي سي");
            IntenationalNetworkName.Add("شبکه منوتو");
            IntenationalNetworkName.Add("شبکه ایران اینترنشنال");
            IntenationalNetworkName.Add("شبکه صدای آمریکا");



            string panelIds = "";
            foreach (int i in UserPanelList)
            { panelIds += "," + i; }
            if (!string.IsNullOrWhiteSpace(panelIds))
            {
                panelIds = panelIds.Substring(1);
            }
            //تلگرام

            foreach (var item in IranNetworkName)
            {
                var lstNetwrok = new List<string>();
                lstNetwrok.Add(item);
                string network = "";

                foreach (string n in lstNetwrok)
                { network += "," + "'" + n + "'"; }
                if (!string.IsNullOrWhiteSpace(network))
                {
                    network = network.Substring(1);
                }
                if (ParminTable.AccessTV == true)
                {

                    string cmd = "SELECT ISNULL(Count(MovieID),0) FROM Tbl_Movies WHERE MovieID IN (SELECT movieId FROM dbo.Tbl_Relation_MovieParminPanel WHERE ParminPanelId IN (" +
                      panelIds + ")) AND [Type] = 0 AND NetworkName IN (" + network + ")  AND VideoDateIndex BETWEEN '" + fromDateIndex + "' AND '" + toDateIndex + "'";

                    SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
                    _Cnn.Open();

                    SqlDataAdapter dtr = new SqlDataAdapter();
                    dtr.SelectCommand = new SqlCommand();
                    dtr.SelectCommand.Connection = _Cnn;
                    dtr.SelectCommand.CommandText = cmd;
                    dtr.SelectCommand.CommandTimeout = 20000;
                    DataTable dt = new DataTable();
                    dtr.Fill(dt);

                    _Cnn.Close();
                    var count = dt.Rows[0][0];


                    values.Add(new ChartValueSolo_New { name = item, data = count });


                }
                else
                {
                    var count = 0;

                    values.Add(new ChartValueSolo_New { name = item, data = count });


                }
            }



            return values.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValueSolo_New[] Social_Count_All(string fromDate, string toDate)
        {
            var values = new List<ChartValueSolo_New>();


            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var telegramCount = 0;
            var twitterCount = 0;
            var instagramCount = 0;

            if (ParminTable.AccessTelegram == true)
            {
                telegramCount = (from Massage in _db.Tbl_TLPMessage
                                 where UserPanelList.Contains(Massage.PanelID)
                                 && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                                 select Massage).Count();
            }
            if (ParminTable.AccessTwitter == true)
            {
                twitterCount = (from Post in _db.Tbl_TwitterPost
                                where UserPanelList.Contains(Post.PanelID) && Post.Active == true
                                 && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                select Post).Count();

            }

            if (ParminTable.AccessInstagram == true)
            {
                instagramCount = (from Post in _db.Tbl_InstagramPosts
                                  where UserPanelList.Contains(Post.PanelId)
                                  && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                  && Post.Active == true
                                  select Post).Count();
            }

            values.Add(new ChartValueSolo_New { name = "تلگرام", data = telegramCount });
            values.Add(new ChartValueSolo_New { name = "توییتر", data = twitterCount });
            values.Add(new ChartValueSolo_New { name = "اینستاگرام", data = instagramCount });





            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValueSolo_New[] WebNewspaper_Count_All(string fromDate, string toDate)
        {
            var values = new List<ChartValueSolo_New>();


            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var websiteCount = 0;
            var paperCount = 0;

            if (ParminTable.AccessNews == true)
            {
                websiteCount = _clsNews.GetNewsCountBySiteType(UserPanelList[0].ToString(), fromDateIndex, toDateIndex, "1");
                paperCount = _clsNews.GetNewsCountBySiteType(UserPanelList[0].ToString(), fromDateIndex, toDateIndex, "2");

            }


            values.Add(new ChartValueSolo_New { name = "سایت های خبری", data = websiteCount });
            values.Add(new ChartValueSolo_New { name = "روزنامه ها", data = paperCount });





            return values.ToArray();
        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValueSolo_New[] Hashtag_Top_All(string fromDate, string toDate)
        {
            var values = new List<ChartValueSolo_New>();


            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var lstKeyword = new List<ChartValue>();
            if (ParminTable.AccessTwitter == true)
            {
                var twitter = (from Post in _db.Tbl_TwitterPost
                               where UserPanelList.Contains(Post.PanelID) && Post.Active == true
                                && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                               group Post by Post.KeywordID into grp
                               select new { key = grp.Key, cnt = grp.Count() }).ToList();


                foreach (var item in twitter)
                {
                    var key = _db.Tbl_TwitterKeywords.FirstOrDefault(t => t.ID == item.key);

                    //  lstKeyword.Add(new ChartValue { Name = key.Title, Value = item.cnt });
                    if (lstKeyword.Any(t => t.Name == key.Title))
                    {
                        lstKeyword.FirstOrDefault(t => t.Name == key.Title).Value += item.cnt;
                    }
                    else
                    {
                        lstKeyword.Add(new ChartValue { Name = key.Title, Value = item.cnt });

                    }
                }


            }
            if (ParminTable.AccessInstagram == true)
            {
                var instagram = (from Post in _db.Tbl_InstagramPosts
                                 where UserPanelList.Contains(Post.PanelId)
                                 && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                 && Post.Active == true
                                 group Post by Post.KeywordId into grp
                                 select new { key = grp.Key, cnt = grp.Count() }).ToList();

                foreach (var item in instagram)
                {
                    var key = _db.Tbl_InstagramKeywords.FirstOrDefault(t => t.Id == item.key);
                    if (lstKeyword.Any(t => t.Name == key.Title))
                    {
                        lstKeyword.FirstOrDefault(t => t.Name == key.Title).Value += item.cnt;
                    }
                    else
                    {
                        lstKeyword.Add(new ChartValue { Name = key.Title, Value = item.cnt });

                    }
                }
            }
            if (ParminTable.AccessTelegram == true)
            {
                var telegram = (from Post in _db.Tbl_TLPMessage
                                where UserPanelList.Contains(Post.PanelID)
                                && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                group Post by Post.KeywordID into grp
                                select new { key = grp.Key, cnt = grp.Count() }).ToList();
                foreach (var item in telegram)
                {
                    var key = _db.Tbl_TLPKeywords.FirstOrDefault(t => t.ID == item.key);

                    if (lstKeyword.Any(t => t.Name == key.Title))
                    {
                        lstKeyword.FirstOrDefault(t => t.Name == key.Title).Value += item.cnt;
                    }
                    else
                    {

                        lstKeyword.Add(new ChartValue { Name = key.Title, Value = item.cnt });

                    }

                }
            }



            // values.Add(new ChartValueSolo_New { name = "سایت های خبری", data = websiteCount });
            // values.Add(new ChartValueSolo_New { name = "روزنامه ها", data = paperCount });



            var top3 = lstKeyword.OrderByDescending(t => t.Value).Take(3);
            foreach (var item in top3)
            {
                values.Add(new ChartValueSolo_New { name = item.Name, data = item.Value });
            }
            return values.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Tbl_TwitterPost[] Hashtag_Top_Count(string fromDate, string toDate,int count)
        {
            var values = new List<Tbl_TwitterPost>();


            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            if (ParminTable.AccessTwitter == true)
            {
                values = (from Post in _db.Tbl_TwitterPost
                          where UserPanelList.Contains(Post.PanelID) && Post.Active == true
                           && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                          orderby Post.FavoriteCount descending
                          select Post).Take(count).ToList();




            }






            return values.ToArray();
        }


        [WebMethod]
        public static int GetParminTop_AllNews(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var NewspaperCount = 0;


            if (ParminTable.AccessNews == true)
            {
                NewspaperCount = _clsNews.GetNewsCountBySiteType(UserPanelList[0].ToString(), fromDate, toDate);
            }


            return NewspaperCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static int GetParminTop_AllRadio(string fromDate, string toDate)
        {

            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var NewspaperCount = 0;
            string panelIds = "";
            foreach (int i in UserPanelList)
            { panelIds += "," + i; }
            if (!string.IsNullOrWhiteSpace(panelIds))
            {
                panelIds = panelIds.Substring(1);
            }

            if (ParminTable.AccessTV == true)
            {
                string cmd = "SELECT ISNULL(Count(SoundID),0) FROM Tbl_Radio WHERE SoundID IN (SELECT SoundId FROM dbo.Tbl_Relation_RadioParminPanel WHERE ParminPanelId IN (" +
                     panelIds + ")) AND SoundDateIndex BETWEEN '" + fromDateIndex + "' AND '" + toDateIndex + "'";

                SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
                _Cnn.Open();

                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = _Cnn;
                dtr.SelectCommand.CommandText = cmd;
               // dtr.SelectCommand.CommandTimeout = 20000;
                DataTable dt = new DataTable();
                dtr.Fill(dt);

                _Cnn.Close();
                NewspaperCount = Class_Static.ToInt(dt.Rows[0][0]);
            }


            return NewspaperCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static int GetParminTop_AllVideo(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
            var NewspaperCount = 0;

            string panelIds = "";
            foreach (int i in UserPanelList)
            { panelIds += "," + i; }
            if (!string.IsNullOrWhiteSpace(panelIds))
            {
                panelIds = panelIds.Substring(1);
            }
            if (ParminTable.AccessNews == true)
            {
                string cmd = "SELECT ISNULL(Count(MovieID),0) FROM Tbl_Movies WHERE MovieID IN (SELECT movieId FROM dbo.Tbl_Relation_MovieParminPanel WHERE ParminPanelId IN (" +
                    panelIds + ")) AND [Type]=0   AND VideoDateIndex BETWEEN '" + fromDateIndex + "' AND '" + toDateIndex + "'";

                SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
                _Cnn.Open();

                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = _Cnn;
                dtr.SelectCommand.CommandText = cmd;
               // dtr.SelectCommand.CommandTimeout = 20000;
                DataTable dt = new DataTable();
                dtr.Fill(dt);

                _Cnn.Close();
                NewspaperCount = Class_Static.ToInt(dt.Rows[0][0]);

            }


            return NewspaperCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static int GetParminTop_AllSocial(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = toDateIndex * 10000;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();


            var keyIds = "";
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }
#pragma warning disable CS0219 // The variable 'NewspaperCount' is assigned but its value is never used
            var NewspaperCount = 0;
#pragma warning restore CS0219 // The variable 'NewspaperCount' is assigned but its value is never used


            var telegramCount = 0;
            var twitterCount = 0;
            var instagramCount = 0;
            if (ParminTable.AccessTelegram == true)
            {
                telegramCount = (from Massage in _db.Tbl_TLPMessage
                                 where UserPanelList.Contains(Massage.PanelID)
                                 && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                                 select Massage).Count();
            }
            if (ParminTable.AccessTwitter == true)
            {
                twitterCount = (from Post in _db.Tbl_TwitterPost
                                where UserPanelList.Contains(Post.PanelID) && Post.Active == true
                                 && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                select Post).Count();

            }

            if (ParminTable.AccessInstagram == true)
            {
                instagramCount = (from Post in _db.Tbl_InstagramPosts
                                  where UserPanelList.Contains(Post.PanelId)
                                  && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex
                                  && Post.Active == true
                                  select Post).Count();
            }


            return telegramCount+ twitterCount+ instagramCount;
            //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);


        }
        [WebMethod]
        public static int ChangeSetting(string setting)
        {

            Class_News _clsNews = new Class_News();
          

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return -2;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            int parmind = ParminTable.ParminID;
            List<Tbl_BultanSettings> settings = (new Class_BultanSetting()).GetList(ParminTable.ParminID);
            if(settings.Any(i=>i.SettingTitle == setting))
            {
                Tbl_BultanSettings stg = settings.FirstOrDefault(i => i.SettingTitle == setting);
              
                if (stg != null)
                {
                    if(stg.SettingValue == "1")
                    {
                        var editedStg = _db.Tbl_BultanSettings.FirstOrDefault(i => i.SettingTitle == setting && i.ParminId == parmind);
                        editedStg.SettingValue = "0";
                        _db.SaveChanges();
                        return 0;
                    }
                    else
                    {
                        var editedStg = _db.Tbl_BultanSettings.FirstOrDefault(i => i.SettingTitle == setting && i.ParminId == parmind);
                        editedStg.SettingValue = "1";
                        _db.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                Tbl_BultanSettings newStg = new Tbl_BultanSettings();
                newStg.ParminId = ParminTable.ParminID;
                newStg.SettingTitle = setting;
                newStg.SettingValue = "1";
                _db.Tbl_BultanSettings.Add(newStg);
                _db.SaveChanges();
                return 1;
            }
            
        }
        [WebMethod]
        public static Tbl_BultanSettings[] GetSetting()
        {

            Class_News _clsNews = new Class_News();

            List<Tbl_BultanSettings> settings = new List<Tbl_BultanSettings>();
            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return settings.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            int parmind = ParminTable.ParminID;
            settings = (new Class_BultanSetting()).GetList(ParminTable.ParminID);
            return settings.ToArray();

        }











        public static string MiladiToShamsi(DateTime Miladi)
        {
            try
            {


                if (Miladi == null) return "";

                return Persia.Calendar.ConvertToPersian(Miladi).ToString();
            }
            catch
            {
                return "";
            }



        }

        public static Dictionary<string, string> GetChartDays(string dateFrom, string dateTo)
        {
            var lstDays = new List<string>();

            var dic = new Dictionary<string, string>();
            var pc = new PersianCalendar();



            //date=1391/01/02
            dateFrom = ShamsiBySlash(dateFrom);
            dateTo = ShamsiBySlash(dateTo);

            var fromDate = Class_Static.ShamsiToMiladi(dateFrom);
            var toDate = Class_Static.ShamsiToMiladi(dateTo);
            var betDays = (toDate - fromDate).TotalDays;

            for (int i = 0; i <= betDays; i++)
            {

                var dtNew = fromDate.AddDays(i);


                var dateStrIndex = pc.GetYear(dtNew) + "" + RoundTenNum(pc.GetMonth(dtNew)) + "" + RoundTenNum(pc.GetDayOfMonth(dtNew));
                var dateStr = pc.GetYear(dtNew) + "/" + RoundTenNum(pc.GetMonth(dtNew)) + "/" + RoundTenNum(pc.GetDayOfMonth(dtNew));

                dic.Add(dateStrIndex, dateStr);
            }

            return dic;
        }
        public static Dictionary<string, string> GetChartMonth(string dateFrom, string dateTo)
        {
            var lstMonth = new List<string>();

            var dic = new Dictionary<string, string>();
            var pc = new PersianCalendar();



            //date=1391/01/02
            dateFrom = ShamsiBySlash(dateFrom);
            dateTo = ShamsiBySlash(dateTo);

            var fromDate = Class_Static.ShamsiToMiladi(dateFrom);
            var toDate = Class_Static.ShamsiToMiladi(dateTo);



            var dateList = GetPersianBetweenYearMonth(dateFrom, dateTo);


            foreach (var date in dateList)
            {
                var monthStr = RoundTenNum(date.Month);
                var str = GetMonthByInt(monthStr) + " " + date.Year;

                dic.Add(date.Year + "" + monthStr, str);
            }


            return dic;

        }
        public static string ShamsiBySlash(object fDate)
        {
            //if (!spilDate[0].ToString().StartsWith("13"))
            //{
            //    spilDate[0] = "13" + spilDate[0];
            //} 


            var fDateStr = fDate + "";
            try
            {
                if (string.IsNullOrWhiteSpace(fDateStr))
                    return fDateStr;
                if (fDate.ToString().Split('/').Count() > 1)
                {
                    return fDateStr;
                }
                else
                {
                    if (!fDate.ToString().StartsWith("13"))
                    {
                        fDate = "13" + fDate;
                    }
                    else if (!fDate.ToString().StartsWith("14"))
                    {
                        fDate = "14" + fDate;
                    }
                    return fDateStr.Substring(0, 4) + "/" + fDateStr.Substring(4, 2) + "/" + fDateStr.Substring(6, 2);
                }
            }
            catch
            {
                return fDateStr;
            }
        }
        public static string ShamsiWithoutSlash(object fDate0)
        {
            var fDate = fDate0.ToString();
            var ret_date = "";



            try
            {
                if (string.IsNullOrWhiteSpace(fDate))
                    return fDate;
                if (fDate.Split('/').Count() < 1)
                {
                    return fDate;
                }
                else
                {
                    var year = fDate.Split('/')[0].Trim();
                    if (!year.StartsWith("13") && year.Length == 2)
                    {
                        ret_date = "13" + fDate;
                    }
                    else if (!year.StartsWith("14") && year.Length == 2)
                    {
                        ret_date = "14" + fDate;
                    }
                    else
                    {
                        ret_date = fDate.Split('/')[0];


                    }
                    ret_date += Class_Static.RoundTenNum(fDate.Split('/')[1].Trim()) + Class_Static.RoundTenNum(fDate.Split('/')[2].Trim());
                    //fDate = fDat.Replace("/", "");
                    //fDate = fDate.Replace("/", "");
                    //if (!fDate.StartsWith("13"))
                    //{
                    //    fDate = "13" + fDate;
                    //}
                    //return fDate.Substring(0, 4) + fDate.Substring(4, 2) + fDate.Substring(6, 2);
                }
            }
            catch
            {

            }
            return ret_date;
        }
        private static Dictionary<string, string> GetChartWeek(string dateFrom, string dateTo)
        {
            var lstWeek = new List<string>();

            var dic = new Dictionary<string, string>();
            var pc = new PersianCalendar();



            //date=1391/01/02
            dateFrom = ShamsiBySlash(dateFrom);
            dateTo = ShamsiBySlash(dateTo);

            var fromDate = Class_Static.ShamsiToMiladi(dateFrom);
            var toDate = Class_Static.ShamsiToMiladi(dateTo);

            var betDays = (toDate - fromDate).TotalDays;
            for (int i = 0; i <= betDays; i++)
            {
                try
                {
                    var dtNew = fromDate.AddDays(i);
                    var dateStr = "";

                    var hafteVal = GetDayWeekInMonthPosition(pc.GetDayOfMonth(dtNew));
                    var yearStr = RoundTenNum(pc.GetYear(dtNew));
                    var monthStr = RoundTenNum(pc.GetMonth(dtNew));
                    dateStr = " هفته " + hafteVal.Item2 + " " + GetMonthByInt(monthStr) + " ماه ";

                    if (!dic.Any(t => t.Value == dateStr))
                    {

                        switch (hafteVal.Item1)
                        {
                            case 1:
                                dic.Add(yearStr + "" + monthStr + "01" + "_" + yearStr + "" + monthStr + "07", dateStr);

                                break;
                            case 2:
                                dic.Add(yearStr + "" + monthStr + "08" + "_" + yearStr + "" + monthStr + "14", dateStr);

                                break;
                            case 3:
                                dic.Add(yearStr + "" + monthStr + "15" + "_" + yearStr + "" + monthStr + "21", dateStr);

                                break;
                            case 4:
                                dic.Add(yearStr + "" + monthStr + "22" + "_" + yearStr + "" + monthStr + "31", dateStr);

                                break;
                            default: break;
                        }
                    }



                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
            }
            return dic;

        }
        public static Dictionary<string, string> GetChartDate(DateTime dateTo, DateTime dateFrom, string dateMode)
        {

            var fromDate = MiladiToShamsi(dateFrom);
            var toDate = MiladiToShamsi(dateTo);
            var betDays = (dateTo - dateFrom).TotalDays;
            if (dateMode == "all")
            {
                if (betDays < 14)
                {
                    dateMode = "day";
                }
                else if (betDays < 31)
                {
                    dateMode = "week";
                }
                else
                {
                    dateMode = "month";
                }
            }
            switch (dateMode)
            {

                case ("day"):
                    return GetChartDays(fromDate, toDate);


                case ("week"):
                    return GetChartWeek(fromDate, toDate);

                case ("month"):
                    return GetChartMonth(fromDate, toDate);

                default: return null;
            }
        }
        public static List<DateListType> GetPersianBetweenYearMonth(string dateFrom, string dateTo)
        {
            var listDic = new List<DateListType>();
            dateFrom = ShamsiBySlash(dateFrom);
            dateTo = ShamsiBySlash(dateTo);
            var startYear = Convert.ToInt32(dateFrom.Split('/')[0]);
            var endYear = Convert.ToInt32(dateTo.Split('/')[0]);
            var startMonth = Convert.ToInt32(dateFrom.Split('/')[1]);
            var endMonth = Convert.ToInt32(dateTo.Split('/')[1]);

            //به ازای تعداد سال ها اجرا شود
            for (var i = startYear; i <= endYear; i++)
            {


                while (startMonth < 13)
                {

                    //تا زمانی که سال نهایی و ماه نهایی نرسیدی ادامه بده
                    if (i == endYear & startMonth > endMonth)
                    {
                        break;
                    }
                    else
                    {
                        var itemNew = new DateListType();
                        itemNew.Year = i;
                        itemNew.Month = startMonth;
                        listDic.Add(itemNew);
                        startMonth++;


                    }
                }
                startMonth = 1;


            }



            return listDic;

        }
        public static Tuple<int, string> GetDayWeekInMonthPosition(int day)
        {
            if (day < 8) return new Tuple<int, string>(1, "اول"); // هفته اول
            else if (day < 15) return new Tuple<int, string>(2, "دوم");// هفته دوم
            else if (day < 22) return new Tuple<int, string>(3, "سوم");// هفته سوم
            else return new Tuple<int, string>(4, "چهارم");// هفته چهارم

        }
        public static string GetMonthByStr(string monthStr)
        {
            monthStr = RoundTenNum(monthStr);
            var dicMonth = new Dictionary<string, string>();
            dicMonth.Add("01", "فروردین");
            dicMonth.Add("02", "اردیبهشت");
            dicMonth.Add("03", "خرداد");
            dicMonth.Add("04", "تیر");
            dicMonth.Add("05", "مرداد");
            dicMonth.Add("06", "شهریور");
            dicMonth.Add("07", "مهر");
            dicMonth.Add("08", "آبان");
            dicMonth.Add("09", "آذر");
            dicMonth.Add("10", "دی");
            dicMonth.Add("11", "بهمن");
            dicMonth.Add("12", "اسفند");


            return dicMonth.FirstOrDefault(x => x.Value == monthStr).Key;
        }
        public static Dictionary<string, string> GetMonthDic()
        {
            var dicMonth = new Dictionary<string, string>();
            dicMonth.Add("01", "فروردین");
            dicMonth.Add("02", "اردیبهشت");
            dicMonth.Add("03", "خرداد");
            dicMonth.Add("04", "تیر");
            dicMonth.Add("05", "مرداد");
            dicMonth.Add("06", "شهریور");
            dicMonth.Add("07", "مهر");
            dicMonth.Add("08", "آبان");
            dicMonth.Add("09", "آذر");
            dicMonth.Add("10", "دی");
            dicMonth.Add("11", "بهمن");
            dicMonth.Add("12", "اسفند");
            return dicMonth;
        }
        public static string GetMonthByInt(string monthStr)
        {
            monthStr = RoundTenNum(monthStr);
            var dicMonth = GetMonthDic();


            return dicMonth.FirstOrDefault(x => x.Key == monthStr).Value;

        }
        public static string RoundTenNum(int num)
        {
            if (num >= 10)
            {
                return num.ToString();
            }
            else
            {
                return ("0" + num);
            }
        }
        public static string RoundTenNum(string number)
        {
            var num = Convert.ToInt32(number);
            if (num >= 10)
            {
                return num.ToString();
            }
            else
            {
                return ("0" + num);
            }
        }
        public static DateTime ShamsiToMiladi(object fDate)
        {
            try
            {
                var fDateStr = fDate.ToString();
                if (string.IsNullOrWhiteSpace(fDateStr))
                    return DateTime.Now;

                PersianCalendar pc = new PersianCalendar();

                if (fDateStr.Split('/').Count() > 1)
                {
                    var year = fDateStr.Split('/')[0] + "";
                    if (year.Length < 3)
                    {
                        year = "13" + year;
                    }
                    var Hour = DateTime.Now.Hour;
                    var Minute = DateTime.Now.Minute;
                    var Second = DateTime.Now.Second;
                    var Millisecond = DateTime.Now.Millisecond;
                    return pc.ToDateTime(
                        Convert.ToInt32(year),
                        Convert.ToInt32(fDateStr.Split('/')[1]),
                        Convert.ToInt32(fDateStr.Split('/')[2]),
                        Hour, Minute, Second, Millisecond);
                }
                else
                {
                    fDateStr = fDateStr.Replace("/", "");

                    if (fDateStr.Length == 6)
                    {
                        fDateStr = "13" + fDateStr;
                    }
                    return pc.ToDateTime(
                        Convert.ToInt32(fDateStr.Substring(0, 4)),
                        Convert.ToInt32(fDateStr.Substring(4, 2)),
                        Convert.ToInt32(fDateStr.Substring(6, 2)),
                        0, 0, 0, 0);
                }


            }
            catch
            {
                return DateTime.Now;

            }


        }
        public static DateTime ShamsiToMiladi(object fDate, int hour, int min, int sec)
        {
            try
            {
                var fDateStr = fDate.ToString();
                if (string.IsNullOrWhiteSpace(fDateStr))
                    return DateTime.Now;

                PersianCalendar pc = new PersianCalendar();

                if (fDateStr.Split('/').Count() > 1)
                {
                    var year = fDateStr.Split('/')[0] + "";
                    if (year.Length < 3)
                    {
                        year = "13" + year;
                    }
                    return pc.ToDateTime(
                        Convert.ToInt32(year),
                        Convert.ToInt32(fDateStr.Split('/')[1]),
                        Convert.ToInt32(fDateStr.Split('/')[2]),
                        hour, min, sec, 0);
                }
                else
                {
                    fDateStr = fDateStr.Replace("/", "");

                    if (fDateStr.Length == 6)
                    {
                        fDateStr = "13" + fDateStr;
                    }
                    return pc.ToDateTime(
                        Convert.ToInt32(fDateStr.Substring(0, 4)),
                        Convert.ToInt32(fDateStr.Substring(4, 2)),
                        Convert.ToInt32(fDateStr.Substring(6, 2)),
                        hour, min, sec, 0);
                }


            }
            catch
            {
                return DateTime.Now;

            }


        }
    }
}