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
    /// Summary description for Part_Media_Static_GetStatic
    /// </summary>
    public class Part_Media_Static_GetStatic : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["p"] != null & context.Request["f"] != null & context.Request["t"] != null)
            {
                string fromDate = context.Request["f"].ToString();
                string toDate = context.Request["t"].ToString();
                int ParminId = Convert.ToInt32(context.Request["p"]);
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Media_All mediaList = new Media_All();
                long fromDateTimeIndex = Convert.ToInt64(fromDate.Replace("/", "") + "0000");
                long toDateTimeIndex = Convert.ToInt64(toDate.Replace("/", "") + "2400");
                DataSet ds = Tbl_News_General.GetMediaStatics(ParminId, fromDateTimeIndex, toDateTimeIndex);
                mediaList.NewsStaticChartList = ReportChartValue.GetFromDataRows(ds.Tables[0].Select());
                mediaList.VideoStaticChartList = ReportChartValue.GetFromDataRows(ds.Tables[1].Select());
                mediaList.AudioStaticChartList = ReportChartValue.GetFromDataRows(ds.Tables[2].Select());
                mediaList.SocialStaticChartList = ReportChartValue.GetFromDataRows(ds.Tables[3].Select());
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