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
    /// Summary description for Part_MediaAnalyze_GetTableNews
    /// </summary>
    public class Part_MediaAnalyze_GetTableNews : IHttpHandler
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

                DataSet ds = Tbl_News_General.GetTableNews(ParminId, fromDateTimeIndex, toDateTimeIndex, keyword);
                AllNews_HighSource mediaList = new AllNews_HighSource();
                mediaList.NewsCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[0].Select());
                mediaList.NewspaperCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[1].Select());
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