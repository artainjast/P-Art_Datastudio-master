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
    /// Summary description for Part_Media_Analyze_GetImportant_SugiriNews
    /// </summary>
    public class Part_Media_Analyze_GetImportant_SugiriNews : IHttpHandler
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
                long fromDateTimeIndex = Convert.ToInt64(fromDate.Replace("/", "") + "0000");
                long toDateTimeIndex = Convert.ToInt64(toDate.Replace("/", "") + "2400");

                DataSet ds = Tbl_News_General.GetImportantSugiriNews(ParminId, fromDateTimeIndex, toDateTimeIndex, keyword);
                News_AllSugiri mediaList = new News_AllSugiri();
                mediaList.AllSugiriNewsCountList = Tbl_News_SugiriAllType.GetFromDataRows(ds.Tables[0].Select());
                mediaList.PosetiveNewsCountList = Tbl_News_General.GetFromDataRows(ds.Tables[1].Select());
                mediaList.NegativeNewsCountList = Tbl_News_General.GetFromDataRows(ds.Tables[2].Select());
                List<ReportChartValue> valuesPosetiveList = new List<ReportChartValue>();
                List<ReportChartValue> valuesNegativeList = new List<ReportChartValue>();
                int pindex = 0;
                int nindex = 0;
                List<Tbl_News_SugiriAllType> PosSugiriNewsCountList = mediaList.AllSugiriNewsCountList.OrderByDescending(i => i.Posetive).ToList();
                List<Tbl_News_SugiriAllType> NegSugiriNewsCountList = mediaList.AllSugiriNewsCountList.OrderByDescending(i => i.Negative).ToList();
                foreach (var item in PosSugiriNewsCountList)
                {
                    if (pindex < 5)
                    {
                        ReportChartValue chartValue = new ReportChartValue();
                        chartValue.Name = item.SourceNews;
                        chartValue.Value = item.Common;
                        chartValue.ThirdValue = item.Negative;
                        chartValue.SecondValue = item.Posetive;
                        valuesPosetiveList.Add(chartValue);
                    }
                    pindex++;
                }
                foreach (var item in NegSugiriNewsCountList)
                {
                    if (nindex < 5)
                    {
                        ReportChartValue chartValue = new ReportChartValue();
                        chartValue.Name = item.SourceNews;
                        chartValue.Value = item.Common;
                        chartValue.ThirdValue = item.Negative;
                        chartValue.SecondValue = item.Posetive;
                        valuesNegativeList.Add(chartValue);
                    }
                    nindex++;
                }
                mediaList.PosetiveNewsChartList = valuesPosetiveList;
                mediaList.NegativeNewsChartList = valuesNegativeList;
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