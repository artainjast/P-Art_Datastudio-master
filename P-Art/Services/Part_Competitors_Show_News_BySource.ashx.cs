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
    /// Summary description for Part_Competitors_Show_News_BySource
    /// </summary>
    public class Part_Competitors_Show_News_BySource : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            var values = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            List<ViewModel_News_BySource_General> allNews = new List<ViewModel_News_BySource_General>();


            List<Tbl_News_General> resutList = (new Class_Competitors_Data()).GetCompetitorsShowNewsByKeywordSource(ParminId, fromDateIndex, toDateIndex);

            foreach (var v in resutList)
            {
                ViewModel_News_BySource_General vid = new ViewModel_News_BySource_General();
                vid.Keyword = v.KeywordName;
                vid.KeywordID = v.KeywordId;
                vid.newsList = resutList.Where(i => i.KeywordId == v.KeywordId).ToList();
                if (!allNews.Any(i => i.KeywordID == v.KeywordId))
                    allNews.Add(vid);
            }
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(allNews));
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