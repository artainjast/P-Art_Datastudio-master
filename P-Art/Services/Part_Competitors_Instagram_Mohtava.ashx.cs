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
    /// Summary description for Part_Competitors_Instagram_Mohtava
    /// </summary>
    public class Part_Competitors_Instagram_Mohtava : IHttpHandler
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

            ChartData like = (new Class_Competitors_Data()).GetCompetitorsInstagramLike(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData comment = (new Class_Competitors_Data()).GetCompetitorsInstagramComment(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData video = (new Class_Competitors_Data()).GetCompetitorsInstagramVideo(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData picture = (new Class_Competitors_Data()).GetCompetitorsInstagramPicture(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData content = (new Class_Competitors_Data()).GetCompetitorsInstagramContent(ParminId, fromDateTimeIndex, toDateTimeIndex);

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