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
    public partial class Service_Competitor : System.Web.UI.Page
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue_NewData[] Competitors_AllDataCountWithMediaType(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData news = (new Class_Competitors_Data()).GetCompetitorsNews(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex, 1);
            ChartData newspaper = (new Class_Competitors_Data()).GetCompetitorsNews(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex, 2);
            ChartData twitter = (new Class_Competitors_Data()).GetCompetitorsTwitter(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData telegram = (new Class_Competitors_Data()).GetCompetitorsTelegram(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData instagram = (new Class_Competitors_Data()).GetCompetitorsInstagram(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);

            List<string> categories = new List<string>();
            categories.Add("سایت های خبری");
            categories.Add("مطیوعات");
            categories.Add("تلگرام");
            categories.Add("توییتر");
            categories.Add("اینستاگرام");



            List<Media_Keywords_Serie> seriesList = new List<Media_Keywords_Serie>();
            foreach (var n in news.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                newseri.SerieName = n.Name;
                newseriValue.News = n.Value;
                newseriValue.Newspaper = 0;
                newseriValue.Telegram = 0;
                newseriValue.Twitter = 0;
                newseriValue.Instagram = 0;
                newseri.Values = newseriValue;

                seriesList.Add(newseri);
            }
            foreach (var n in newspaper.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Newspaper = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = n.Value;
                    newseriValue.Telegram = 0;
                    newseriValue.Twitter = 0;
                    newseriValue.Instagram = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in twitter.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Twitter = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = 0;
                    newseriValue.Telegram = 0;
                    newseriValue.Twitter = n.Value;
                    newseriValue.Instagram = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in telegram.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Telegram = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = 0;
                    newseriValue.Telegram = n.Value;
                    newseriValue.Twitter = 0;
                    newseriValue.Instagram = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in instagram.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Instagram = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = 0;
                    newseriValue.Telegram = 0;
                    newseriValue.Twitter = 0;
                    newseriValue.Instagram = n.Value;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }

            List<Json_ChartSerie> ResultSeriesList = new List<Json_ChartSerie>();
            foreach (var s in seriesList)
            {
                Json_ChartSerie item = new Json_ChartSerie();


                Json_ChartSerieData itemdata = new Json_ChartSerieData();
                List<Json_ChartSerieData> itemDataList = new List<Json_ChartSerieData>();
                itemdata.Value = s.Values.News;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Newspaper;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Telegram;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Twitter;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Instagram;
                itemDataList.Add(itemdata);


                item.Name = s.SerieName;
                item.Values = itemDataList;
                ResultSeriesList.Add(item);
            }
            foreach (var r in ResultSeriesList)
            {
                ChartValue_NewData data = new ChartValue_NewData();
                List<object> obj = new List<object>();
                data.name = r.Name;
                foreach (var v in r.Values)
                {
                    obj.Add(v.Value);

                }
                data.data = obj;
                resutList.Add(data);
            }
            //values.Categories = categories;
            values = resutList;
            return values.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] Competitors_AllDataCount(string fromDate, string toDate)
        {
            List<ChartValue> resutList = new List<ChartValue>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData news = (new Class_Competitors_Data()).GetCompetitorsNews(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex, 1);
            ChartData newspaper = (new Class_Competitors_Data()).GetCompetitorsNews(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex, 2);
            ChartData twitter = (new Class_Competitors_Data()).GetCompetitorsTwitter(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData telegram = (new Class_Competitors_Data()).GetCompetitorsTelegram(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData instagram = (new Class_Competitors_Data()).GetCompetitorsInstagram(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            List<Media_Keywords_Serie> seriesList = new List<Media_Keywords_Serie>();
            foreach (var n in news.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                newseri.SerieName = n.Name;
                newseriValue.News = n.Value;
                newseriValue.Newspaper = 0;
                newseriValue.Telegram = 0;
                newseriValue.Twitter = 0;
                newseriValue.Instagram = 0;
                newseri.Values = newseriValue;

                seriesList.Add(newseri);
            }
            foreach (var n in newspaper.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Newspaper = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = n.Value;
                    newseriValue.Telegram = 0;
                    newseriValue.Twitter = 0;
                    newseriValue.Instagram = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in twitter.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Twitter = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = 0;
                    newseriValue.Telegram = 0;
                    newseriValue.Twitter = n.Value;
                    newseriValue.Instagram = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in telegram.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Telegram = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = 0;
                    newseriValue.Telegram = n.Value;
                    newseriValue.Twitter = 0;
                    newseriValue.Instagram = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in instagram.data)
            {
                Media_Keywords_Serie newseri = new Media_Keywords_Serie();
                Media_Keywords_Value newseriValue = new Media_Keywords_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Instagram = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.News = 0;
                    newseriValue.Newspaper = 0;
                    newseriValue.Telegram = 0;
                    newseriValue.Twitter = 0;
                    newseriValue.Instagram = n.Value;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }

            List<ChartValue> ResultSeriesList = new List<ChartValue>();
            foreach (var s in seriesList)
            {
                ChartValue item = new ChartValue();


                Json_ChartSerieData itemdata = new Json_ChartSerieData();
                List<Json_ChartSerieData> itemDataList = new List<Json_ChartSerieData>();
                itemdata.Value = s.Values.News;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Newspaper;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Telegram;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Twitter;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Instagram;
                itemDataList.Add(itemdata);


                item.Name = s.SerieName;
                item.Value = s.Values.News + s.Values.Newspaper + s.Values.Telegram + s.Values.Twitter + s.Values.Instagram;
                ResultSeriesList.Add(item);
            }
            return ResultSeriesList.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] Competitors_Ads_RadioVideo_AllData(string fromDate, string toDate)
        {
            List<ChartValue> resutList = new List<ChartValue>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            List<ChartValue> ResultSeriesList = new List<ChartValue>();
            List<ChartValue> videos = (new Class_Competitors_Data()).GetCompetitorsAdsVideo(ParminTable.ParminID, fromDateIndex, toDateIndex);
            List<ChartValue> radios = (new Class_Competitors_Data()).GetCompetitorsAdsRadio(ParminTable.ParminID, fromDateIndex, toDateIndex);
            foreach (var v in videos)
            {
                ChartValue newValue = new ChartValue();
                if (radios.Any(i => i.Name == v.Name))
                {
                    newValue.Name = v.Name;
                    long radioValue = 0;
                    ChartValue radio = radios.FirstOrDefault(j => j.Name == v.Name);
                    if (radio != null)
                        radioValue = radio.Value;
                    newValue.Value = v.Value + radioValue;
                    ResultSeriesList.Add(newValue);
                }
            }
            foreach (var rad in radios)
            {
                if (!ResultSeriesList.Any(i => i.Name == rad.Name))
                {
                    ChartValue newValue = new ChartValue();
                    newValue.Name = rad.Name;
                    newValue.Value = rad.Value;
                    ResultSeriesList.Add(newValue);
                }
            }
            foreach (var vid in videos)
            {
                if (!ResultSeriesList.Any(i => i.Name == vid.Name))
                {
                    ChartValue newValue = new ChartValue();
                    newValue.Name = vid.Name;
                    newValue.Value = vid.Value;
                    ResultSeriesList.Add(newValue);
                }
            }
            return ResultSeriesList.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] Competitors_Ads_Radio_AllData(string fromDate, string toDate)
        {
            List<ChartValue> resutList = new List<ChartValue>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            List<ChartValue> radios = (new Class_Competitors_Data()).GetCompetitorsAdsRadio(ParminTable.ParminID, fromDateIndex, toDateIndex);
            return radios.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] Competitors_Ads_Video_AllData(string fromDate, string toDate)
        {
            List<ChartValue> resutList = new List<ChartValue>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            List<ChartValue> videos = (new Class_Competitors_Data()).GetCompetitorsAdsVideo(ParminTable.ParminID, fromDateIndex, toDateIndex);
            return videos.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] Competitors_Ads_Advertise_ByType(string fromDate, string toDate , int type)
        {
            List<ChartValue> resutList = new List<ChartValue>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400 ;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            List<ChartValue> videos = (new Class_Competitors_Data()).GetCompetitorsAdsAdvertise(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex, type);
            return videos.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Campain_By_Brand[] Competitors_Ads_Advertise_Campain(string fromDate, string toDate)
        {
            List<Campain_By_Brand> resutList = new List<Campain_By_Brand>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            List<Campain_Type> camp = (new Class_Competitors_Data()).GetCompetitorsAdsCampain(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);



            List<Campain_By_Brand> brands = new List<Campain_By_Brand>();
            List<Campain_Type> newcampList;
            foreach (var cmp in camp)
            {
                // Campain_Type newcamp = new Campain_Type();
                if (!brands.Any(i => i.BrandId == cmp.BrandId))
                {
                    Campain_By_Brand brnd = new Campain_By_Brand();
                    brnd.BrandId = cmp.BrandId;
                    brnd.Brand = cmp.Brandtitle;
                    brands.Add(brnd);
                }
            }
            foreach (var brnd in brands)
            {
                newcampList = new List<Campain_Type>();
                newcampList = camp.Where(b => b.BrandId == brnd.BrandId).ToList();
                brnd.campains = newcampList;
            }


            return brands.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue_NewData[] Competitors_Instagram_Mohtava(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData like = (new Class_Competitors_Data()).GetCompetitorsInstagramLike(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData comment = (new Class_Competitors_Data()).GetCompetitorsInstagramComment(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData video = (new Class_Competitors_Data()).GetCompetitorsInstagramVideo(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData picture = (new Class_Competitors_Data()).GetCompetitorsInstagramPicture(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData content = (new Class_Competitors_Data()).GetCompetitorsInstagramContent(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);

            List<string> categories = new List<string>();
            categories.Add("لایک");
            categories.Add("کامنت");
            categories.Add("ویدیو");
            categories.Add("عکس");
            categories.Add("محتوا");



            List<Instagram_Serie> seriesList = new List<Instagram_Serie>();
            foreach (var n in like.data)
            {
                Instagram_Serie newseri = new Instagram_Serie();
                Instagram_Value newseriValue = new Instagram_Value();
                newseri.SerieName = n.Name;
                newseriValue.Like = n.Value;
                newseriValue.Comment = 0;
                newseriValue.Video = 0;
                newseriValue.Picture = 0;
                newseriValue.Content = 0;
                newseri.Values = newseriValue;

                seriesList.Add(newseri);
            }
            foreach (var n in comment.data)
            {
                Instagram_Serie newseri = new Instagram_Serie();
                Instagram_Value newseriValue = new Instagram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Comment = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Like = 0;
                    newseriValue.Comment = n.Value;
                    newseriValue.Video = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Content = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in video.data)
            {
                Instagram_Serie newseri = new Instagram_Serie();
                Instagram_Value newseriValue = new Instagram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Video = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Like = 0;
                    newseriValue.Comment = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Video = n.Value;
                    newseriValue.Content = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in picture.data)
            {
                Instagram_Serie newseri = new Instagram_Serie();
                Instagram_Value newseriValue = new Instagram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Picture = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Like = 0;
                    newseriValue.Comment = 0;
                    newseriValue.Picture = n.Value;
                    newseriValue.Video = 0;
                    newseriValue.Content = 0;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in content.data)
            {
                Instagram_Serie newseri = new Instagram_Serie();
                Instagram_Value newseriValue = new Instagram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Content = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Like = 0;
                    newseriValue.Comment = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Video = 0;
                    newseriValue.Content = n.Value;

                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }

            List<Json_ChartSerie> ResultSeriesList = new List<Json_ChartSerie>();
            foreach (var s in seriesList)
            {
                Json_ChartSerie item = new Json_ChartSerie();


                Json_ChartSerieData itemdata = new Json_ChartSerieData();
                List<Json_ChartSerieData> itemDataList = new List<Json_ChartSerieData>();
                itemdata.Value = s.Values.Like;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Comment;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Video;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Picture;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Content;
                itemDataList.Add(itemdata);


                item.Name = s.SerieName;
                item.Values = itemDataList;
                ResultSeriesList.Add(item);
            }
            foreach (var r in ResultSeriesList)
            {
                ChartValue_NewData data = new ChartValue_NewData();
                List<object> obj = new List<object>();
                data.name = r.Name;
                foreach (var v in r.Values)
                {
                    obj.Add(v.Value);

                }
                data.data = obj;
                resutList.Add(data);
            }
            //values.Categories = categories;
            values = resutList;
            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Instagram_Mohtava_Like(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData like = (new Class_Competitors_Data()).GetCompetitorsInstagramLike(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long likeCount = 0;
            foreach (var l in like.data)
            {
                likeCount += l.Value;
            }
            return likeCount;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Instagram_Mohtava_Comment(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData comment = (new Class_Competitors_Data()).GetCompetitorsInstagramComment(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long count = 0;
            foreach (var l in comment.data)
            {
                count += l.Value;
            }
            return count;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Instagram_Mohtava_Content(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData content = (new Class_Competitors_Data()).GetCompetitorsInstagramContent(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long count = 0;
            foreach (var l in content.data)
            {
                count += l.Value;
            }
            return count;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue_NewData[] Competitors_Telegram_Mohtava(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTelegramView(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData channel = (new Class_Competitors_Data()).GetCompetitorsTelegramChannelCount(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData video = (new Class_Competitors_Data()).GetCompetitorsTelegramVideo(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData picture = (new Class_Competitors_Data()).GetCompetitorsTelegramPicture(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData text = (new Class_Competitors_Data()).GetCompetitorsTelegramText(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData allContent = (new Class_Competitors_Data()).GetCompetitorsTelegramAll(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);

            List<string> categories = new List<string>();
            categories.Add("بازدید");
            categories.Add("کانال");
            categories.Add("ویدیو");
            categories.Add("عکس");
            categories.Add("متن");
            categories.Add("کل محتوا");


            List<Telegram_Serie> seriesList = new List<Telegram_Serie>();
            foreach (var n in view.data)
            {
                Telegram_Serie newseri = new Telegram_Serie();
                Telegram_Value newseriValue = new Telegram_Value();
                newseri.SerieName = n.Name;
                newseriValue.View = n.Value;
                newseriValue.Channel = 0;
                newseriValue.Video = 0;
                newseriValue.Picture = 0;
                newseriValue.Text = 0;
                newseriValue.All = 0;
                newseri.Values = newseriValue;

                seriesList.Add(newseri);
            }
            foreach (var n in channel.data)
            {
                Telegram_Serie newseri = new Telegram_Serie();
                Telegram_Value newseriValue = new Telegram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Channel = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.View = 0;
                    newseriValue.Channel = n.Value;
                    newseriValue.Video = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Text = 0;
                    newseriValue.All = 0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in video.data)
            {
                Telegram_Serie newseri = new Telegram_Serie();
                Telegram_Value newseriValue = new Telegram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Video = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.View = 0;
                    newseriValue.Channel = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Video = n.Value;
                    newseriValue.Text = 0;
                    newseriValue.All = 0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in picture.data)
            {
                Telegram_Serie newseri = new Telegram_Serie();
                Telegram_Value newseriValue = new Telegram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Picture = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.View = 0;
                    newseriValue.Channel = 0;
                    newseriValue.Picture = n.Value;
                    newseriValue.Video = 0;
                    newseriValue.Text = 0;
                    newseriValue.All = 0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in text.data)
            {
                Telegram_Serie newseri = new Telegram_Serie();
                Telegram_Value newseriValue = new Telegram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Text = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.View = 0;
                    newseriValue.Channel = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Video = 0;
                    newseriValue.Text = n.Value;
                    newseriValue.All =0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }

            foreach (var n in allContent.data)
            {
                Telegram_Serie newseri = new Telegram_Serie();
                Telegram_Value newseriValue = new Telegram_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.All = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.View = 0;
                    newseriValue.Channel = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Video = 0;
                    newseriValue.Text = 0;
                    newseriValue.All = n.Value;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }

            List<Json_ChartSerie> ResultSeriesList = new List<Json_ChartSerie>();
            foreach (var s in seriesList)
            {
                Json_ChartSerie item = new Json_ChartSerie();


                Json_ChartSerieData itemdata = new Json_ChartSerieData();
                List<Json_ChartSerieData> itemDataList = new List<Json_ChartSerieData>();
                itemdata.Value = s.Values.View;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Channel;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Video;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Picture;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Text;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.All;
                itemDataList.Add(itemdata);

                item.Name = s.SerieName;
                item.Values = itemDataList;
                ResultSeriesList.Add(item);
            }
            foreach (var r in ResultSeriesList)
            {
                ChartValue_NewData data = new ChartValue_NewData();
                List<object> obj = new List<object>();
                data.name = r.Name;
                foreach (var v in r.Values)
                {
                    obj.Add(v.Value);

                }
                data.data = obj;
                resutList.Add(data);
            }
            values = resutList;
            return values.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Telegram_Mohtava_View(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTelegramView(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long viewCount = 0;
            foreach (var l in view.data)
            {
                viewCount += l.Value;
            }
            return viewCount;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Telegram_Mohtava_Channel(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTelegramChannelCount(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long viewCount = 0;
            foreach (var l in view.data)
            {
                viewCount += l.Value;
            }
            return viewCount;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Telegram_Mohtava_AllContent(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTelegramAll(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long viewCount = 0;
            foreach (var l in view.data)
            {
                viewCount += l.Value;
            }
            return viewCount;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue_NewData[] Competitors_Twitter_Mohtava(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData favorite = (new Class_Competitors_Data()).GetCompetitorsTwitterFavorite(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData reply = (new Class_Competitors_Data()).GetCompetitorsTwitterReply(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData retwitte = (new Class_Competitors_Data()).GetCompetitorsTwitterRetwitte(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData picture = (new Class_Competitors_Data()).GetCompetitorsTwitterPicture(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData text = (new Class_Competitors_Data()).GetCompetitorsTwitterText(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData allContent = (new Class_Competitors_Data()).GetCompetitorsTwitterAll(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);

            List<string> categories = new List<string>();
            categories.Add("لایک");
            categories.Add("کامنت");
            categories.Add("ریتوییت");
            categories.Add("عکس");
            categories.Add("متن");
            categories.Add("کل محتوا");


            List<Twitter_Serie> seriesList = new List<Twitter_Serie>();
            foreach (var n in favorite.data)
            {
                Twitter_Serie newseri = new Twitter_Serie();
                Twitter_Value newseriValue = new Twitter_Value();
                newseri.SerieName = n.Name;
                newseriValue.Favorite = n.Value;
                newseriValue.Reply = 0;
                newseriValue.ReTwitte = 0;
                newseriValue.Picture = 0;
                newseriValue.Text = 0;
                newseriValue.All = 0;
                newseri.Values = newseriValue;

                seriesList.Add(newseri);
            }
            foreach (var n in reply.data)
            {
                Twitter_Serie newseri = new Twitter_Serie();
                Twitter_Value newseriValue = new Twitter_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Reply = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Favorite = 0;
                    newseriValue.Reply = n.Value;
                    newseriValue.ReTwitte = 0;
                    newseriValue.Picture = 0;
                    newseriValue.Text = 0;
                    newseriValue.All = 0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in retwitte.data)
            {
                Twitter_Serie newseri = new Twitter_Serie();
                Twitter_Value newseriValue = new Twitter_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.ReTwitte = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Favorite = 0;
                    newseriValue.Reply = 0;
                    newseriValue.Picture = 0;
                    newseriValue.ReTwitte = n.Value;
                    newseriValue.Text = 0;
                    newseriValue.All = 0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in picture.data)
            {
                Twitter_Serie newseri = new Twitter_Serie();
                Twitter_Value newseriValue = new Twitter_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Picture = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Favorite = 0;
                    newseriValue.Reply = 0;
                    newseriValue.Picture = n.Value;
                    newseriValue.ReTwitte = 0;
                    newseriValue.Text = 0;
                    newseriValue.All = 0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }
            foreach (var n in text.data)
            {
                Twitter_Serie newseri = new Twitter_Serie();
                Twitter_Value newseriValue = new Twitter_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.Text = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Favorite = 0;
                    newseriValue.Reply = 0;
                    newseriValue.Picture = 0;
                    newseriValue.ReTwitte = 0;
                    newseriValue.Text = n.Value;
                    newseriValue.All = 0;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }

            foreach (var n in allContent.data)
            {
                Twitter_Serie newseri = new Twitter_Serie();
                Twitter_Value newseriValue = new Twitter_Value();
                if (seriesList.Any(i => i.SerieName == n.Name))
                {
                    var findedSeri = seriesList.FirstOrDefault(i => i.SerieName == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Values.All = n.Value;
                    }
                }
                else
                {
                    newseri.SerieName = n.Name;
                    newseriValue.Favorite = 0;
                    newseriValue.Reply = 0;
                    newseriValue.Picture = 0;
                    newseriValue.ReTwitte = 0;
                    newseriValue.Text = 0;
                    newseriValue.All = n.Value;
                    newseri.Values = newseriValue;
                    seriesList.Add(newseri);
                }
            }

            List<Json_ChartSerie> ResultSeriesList = new List<Json_ChartSerie>();
            foreach (var s in seriesList)
            {
                Json_ChartSerie item = new Json_ChartSerie();


                Json_ChartSerieData itemdata = new Json_ChartSerieData();
                List<Json_ChartSerieData> itemDataList = new List<Json_ChartSerieData>();
                itemdata.Value = s.Values.Favorite;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Reply;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.ReTwitte;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Picture;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.Text;
                itemDataList.Add(itemdata);
                itemdata = new Json_ChartSerieData();
                itemdata.Value = s.Values.All;
                itemDataList.Add(itemdata);

                item.Name = s.SerieName;
                item.Values = itemDataList;
                ResultSeriesList.Add(item);
            }
            foreach (var r in ResultSeriesList)
            {
                ChartValue_NewData data = new ChartValue_NewData();
                List<object> obj = new List<object>();
                data.name = r.Name;
                foreach (var v in r.Values)
                {
                    obj.Add(v.Value);

                }
                data.data = obj;
                resutList.Add(data);
            }
            values = resutList;
            return values.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Twitter_Mohtava_Favorite(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTwitterFavorite(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long viewCount = 0;
            foreach (var l in view.data)
            {
                viewCount += l.Value;
            }
            return viewCount;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Twitter_Mohtava_Retwitte(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTwitterRetwitte(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long viewCount = 0;
            foreach (var l in view.data)
            {
                viewCount += l.Value;
            }
            return viewCount;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static long Competitors_Twitter_Mohtava_All(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return 0;
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTwitterAll(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            long viewCount = 0;
            foreach (var l in view.data)
            {
                viewCount += l.Value;
            }
            return viewCount;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] Competitors_SocialMedia_TopHashtag(string fromDate, string toDate)
        {
            var values = new List<ChartValue>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return values.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData insta = (new Class_Competitors_Data()).GetCompetitorsTwitterFavorite(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData twitter = (new Class_Competitors_Data()).GetCompetitorsTwitterReply(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);
            ChartData telegram = (new Class_Competitors_Data()).GetCompetitorsTwitterRetwitte(ParminTable.ParminID, fromDateTimeIndex, toDateTimeIndex);


            List<ChartValue> valueList = new List<ChartValue>();

            foreach (var n in insta.data)
            {
                ChartValue val = new ChartValue();
                val.Name = n.Name;
                val.Value = n.Value;
                valueList.Add(val);
            }
            foreach (var n in twitter.data)
            {
                ChartValue val = new ChartValue();
                if (valueList.Any(i => i.Name == n.Name))
                {
                    var findedSeri = valueList.FirstOrDefault(i => i.Name == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Value += n.Value;
                    }
                }
                else
                {
                    val.Name = n.Name;
                    val.Value = n.Value;
                    valueList.Add(val);
                }
            }
            foreach (var n in telegram.data)
            {
                ChartValue val = new ChartValue();
                if (valueList.Any(i => i.Name == n.Name))
                {
                    var findedSeri = valueList.FirstOrDefault(i => i.Name == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Value += n.Value;
                    }
                }
                else
                {
                    val.Name = n.Name;
                    val.Value = n.Value;
                    valueList.Add(val);
                }
            }

            
            return valueList.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartData[] Competitors_Abri_BySource(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartData> resutList = new List<ChartData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            List<ChartData> news = (new Class_Competitors_Data()).GetCompetitorsNewsByKeyword(ParminTable.ParminID, fromDateIndex, toDateIndex);

            //List<string> categories = new List<string>();
            //categories.Add("لایک");
            //categories.Add("کامنت");
            //categories.Add("ریتوییت");
            //categories.Add("عکس");
            //categories.Add("متن");
            //categories.Add("کل محتوا");


            //resutList = news.data;

            return news.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartData[] Competitors_News_BySource(string fromDate, string toDate)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartData> resutList = new List<ChartData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            if (!Class_Layer.CheckSession_Status())
            {

                HttpContext.Current.Response.Redirect("~/Welcome/");
                return resutList.ToArray();
            }
            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            List<ChartData> news = (new Class_Competitors_Data()).GetCompetitorsNewsByKeywordSource(ParminTable.ParminID, fromDateIndex, toDateIndex);

            List<string> categories = new List<string>();
            //categories.Add("لایک");
            //categories.Add("کامنت");
            //categories.Add("ریتوییت");
            //categories.Add("عکس");
            //categories.Add("متن");
            //categories.Add("کل محتوا");


            resutList = news;

            return resutList.ToArray();
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
                catch (Exception ex)
                {

                }
            }
            return dic;

        }
        public static string ShamsiBySlash(object fDate)
        {
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
        public static Tuple<int, string> GetDayWeekInMonthPosition(int day)
        {
            if (day < 8) return new Tuple<int, string>(1, "اول"); // هفته اول
            else if (day < 15) return new Tuple<int, string>(2, "دوم");// هفته دوم
            else if (day < 22) return new Tuple<int, string>(3, "سوم");// هفته سوم
            else return new Tuple<int, string>(4, "چهارم");// هفته چهارم

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
    }
}