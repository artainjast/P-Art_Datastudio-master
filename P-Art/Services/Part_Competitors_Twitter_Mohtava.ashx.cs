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
    /// Summary description for Part_Competitors_Twitter_Mohtava
    /// </summary>
    public class Part_Competitors_Twitter_Mohtava : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            var values = new List<ChartValue_NewData>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

            ChartData favorite = (new Class_Competitors_Data()).GetCompetitorsTwitterFavorite(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData reply = (new Class_Competitors_Data()).GetCompetitorsTwitterReply(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData retwitte = (new Class_Competitors_Data()).GetCompetitorsTwitterRetwitte(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData picture = (new Class_Competitors_Data()).GetCompetitorsTwitterPicture(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData text = (new Class_Competitors_Data()).GetCompetitorsTwitterText(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData allContent = (new Class_Competitors_Data()).GetCompetitorsTwitterAll(ParminId, fromDateTimeIndex, toDateTimeIndex);

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