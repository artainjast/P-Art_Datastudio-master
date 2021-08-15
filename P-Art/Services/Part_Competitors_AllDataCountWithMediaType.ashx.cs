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
using System.Web.Script.Serialization;

namespace P_Art.Services
{
    /// <summary>
    /// Summary description for Part_Competitors_AllDataCountWithMediaType
    /// </summary>
    public class Part_Competitors_AllDataCountWithMediaType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();

            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            //var UserPanelList = Class_Layer.UserPanels();
            //var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            ChartData news = (new Class_Competitors_Data()).GetCompetitorsNews(ParminId, fromDateTimeIndex, toDateTimeIndex, 1);
            ChartData newspaper = (new Class_Competitors_Data()).GetCompetitorsNews(ParminId, fromDateTimeIndex, toDateTimeIndex, 2);
            ChartData twitter = (new Class_Competitors_Data()).GetCompetitorsTwitter(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData telegram = (new Class_Competitors_Data()).GetCompetitorsTelegram(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData instagram = (new Class_Competitors_Data()).GetCompetitorsInstagram(ParminId, fromDateTimeIndex, toDateTimeIndex);

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
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(values));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}