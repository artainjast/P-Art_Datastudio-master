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
    /// Summary description for Part_Competitors_Telegram_Mohtava
    /// </summary>
    public class Part_Competitors_Telegram_Mohtava : IHttpHandler
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

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTelegramView(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData channel = (new Class_Competitors_Data()).GetCompetitorsTelegramChannelCount(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData video = (new Class_Competitors_Data()).GetCompetitorsTelegramVideo(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData picture = (new Class_Competitors_Data()).GetCompetitorsTelegramPicture(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData text = (new Class_Competitors_Data()).GetCompetitorsTelegramText(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData allContent = (new Class_Competitors_Data()).GetCompetitorsTelegramAll(ParminId, fromDateTimeIndex, toDateTimeIndex);

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
                    newseriValue.All = 0;
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