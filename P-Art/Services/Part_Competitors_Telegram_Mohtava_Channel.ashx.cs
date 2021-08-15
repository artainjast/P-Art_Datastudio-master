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
    /// Summary description for Part_Competitors_Telegram_Mohtava_Channel
    /// </summary>
    public class Part_Competitors_Telegram_Mohtava_Channel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);
            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            ChartData view = (new Class_Competitors_Data()).GetCompetitorsTelegramChannelCount(ParminId, fromDateTimeIndex, toDateTimeIndex);
            long viewCount = 0;
            foreach (var l in view.data)
            {
                viewCount += l.Value;
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(viewCount));
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