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
    /// Summary description for Part_Competitors_Instagram_Mohtava_Like
    /// </summary>
    public class Part_Competitors_Instagram_Mohtava_Like : IHttpHandler
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
            long likeCount = 0;
            foreach (var l in like.data)
            {
                likeCount += l.Value;
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(likeCount));
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