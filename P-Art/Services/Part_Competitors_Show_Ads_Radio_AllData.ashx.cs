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
    /// Summary description for Part_Competitors_Show_Ads_Radio_AllData
    /// </summary>
    public class Part_Competitors_Show_Ads_Radio_AllData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            List<ChartValue> resutList = new List<ChartValue>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            List<ViewModel_Radio_General> allradios = new List<ViewModel_Radio_General>();
            List<Tbl_Radio_General> radios = (new Class_Competitors_Data()).GetCompetitorsShowAdsRadio(ParminId, fromDateIndex, toDateIndex);

            foreach (var v in radios)
            {
                ViewModel_Radio_General vid = new ViewModel_Radio_General();
                vid.AgName = v.AgName;
                vid.ParminID = v.ParminID;
                vid.radioList = radios.Where(i => i.ParminID == v.ParminID).ToList();
                if (!allradios.Any(i => i.ParminID == v.ParminID))
                    allradios.Add(vid);
            }
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(allradios));
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