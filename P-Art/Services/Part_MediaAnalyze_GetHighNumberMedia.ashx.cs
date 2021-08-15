using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace P_Art.Services
{
    /// <summary>
    /// Summary description for Part_MediaAnalyze_GetHighNumberMedia
    /// </summary>
    public class Part_MediaAnalyze_GetHighNumberMedia : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["p"] != null & context.Request["f"] != null & context.Request["t"] != null)
            {
                string fromDate = context.Request["f"].ToString();
                string toDate = context.Request["t"].ToString();
                int ParminId = Convert.ToInt32(context.Request["p"]);
                string fromTime = "0000";
                string toTime = "2400";
                string keyword = "";
                if (context.Request["k"] != null)
                    keyword = context.Request["k"].ToString();
                keyword = Class_Static.ArabicAlpha(keyword);
                if (context.Request["ft"] != null)
                    if (context.Request["ft"].ToString() != string.Empty)
                        fromTime = context.Request["ft"].ToString().Replace(":", "");
                if (context.Request["tt"] != null)
                    if (context.Request["tt"].ToString() != string.Empty)
                        toTime = context.Request["tt"].ToString().Replace(":", "");
                long fromDateTimeIndex = Convert.ToInt64(fromDate.Replace("/", "") + fromTime);
                long toDateTimeIndex = Convert.ToInt64(toDate.Replace("/", "") + toTime);

                DataSet ds = Tbl_News_General.GetHighNumberMedia(ParminId, fromDateTimeIndex, toDateTimeIndex , keyword);
                AllMedia_HighSource mediaList = new AllMedia_HighSource();
                mediaList.AllMediaCount = Tbl_Media_CountType.GetFromDataRow(ds.Tables[0].Select());
                mediaList.NewsCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[1].Select());
                mediaList.NewsPaperCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[2].Select());
                mediaList.TelegramCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[3].Select());
                mediaList.TwitterCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[4].Select());
                List<ReportChartValue> valuesList = new List<ReportChartValue>();
                ReportChartValue chartValue = new ReportChartValue();
                chartValue.Name = "خبرگزاری ها";
                chartValue.Value = mediaList.AllMediaCount.NewsCount;
                valuesList.Add(chartValue);
                chartValue = new ReportChartValue();
                chartValue.Name = "روزنامه ها";
                chartValue.Value = mediaList.AllMediaCount.NewspaperCount;
                valuesList.Add(chartValue);
                chartValue = new ReportChartValue();
                chartValue.Name = "تلگرام";
                chartValue.Value = mediaList.AllMediaCount.TelegramCount;
                valuesList.Add(chartValue);
                chartValue = new ReportChartValue();
                chartValue.Name = "توییتر";
                chartValue.Value = mediaList.AllMediaCount.TwitterCount;
                valuesList.Add(chartValue);
                chartValue = new ReportChartValue();
                chartValue.Name = "صدا و سیما";
                chartValue.Value = mediaList.AllMediaCount.VideoCount;
                valuesList.Add(chartValue);
                mediaList.MediaChartList = valuesList;
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                context.Response.Write(jsonSerializer.Serialize(mediaList));
            }
            else context.Response.Write("");
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