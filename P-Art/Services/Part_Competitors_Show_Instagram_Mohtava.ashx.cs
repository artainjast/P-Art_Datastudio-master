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
    /// Summary description for Part_Competitors_Show_Instagram_Mohtava
    /// </summary>
    public class Part_Competitors_Show_Instagram_Mohtava : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            List<ViewModel_Instagram_General> allInstagram = new List<ViewModel_Instagram_General>();

            List<Tbl_Instagram_General> resutList = (new Class_Competitors_Data()).GetCompetitorsShowInstagram(ParminId, fromDateTimeIndex, toDateTimeIndex);

            foreach (var v in resutList)
            {
                ViewModel_Instagram_General vid = new ViewModel_Instagram_General();
                vid.Keyword = v.keywordTitle;
                vid.KeywordID = v.KeywordId;
                vid.instagramList = resutList.Where(i => i.KeywordId == v.KeywordId).ToList();
                if (!allInstagram.Any(i => i.KeywordID == v.KeywordId))
                    allInstagram.Add(vid);
            }
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(allInstagram));
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