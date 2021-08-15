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
    /// Summary description for Part_Competitors_Ads_Advertise_Campain
    /// </summary>
    public class Part_Competitors_Ads_Advertise_Campain : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            List<Campain_By_Brand> resutList = new List<Campain_By_Brand>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            List<Campain_Type> camp = (new Class_Competitors_Data()).GetCompetitorsAdsCampain(ParminId, fromDateTimeIndex, toDateTimeIndex);

            List<Campain_By_Brand> brands = new List<Campain_By_Brand>();
            List<Campain_Type> newcampList;
            List<Campain_Type> newcampSubjectList = new List<Campain_Type>();
            foreach (var cmp in camp)
            {
                // Campain_Type newcamp = new Campain_Type();
                if (!brands.Any(i => i.BrandId == cmp.BrandId))
                {
                    Campain_By_Brand brnd = new Campain_By_Brand();
                    brnd.BrandId = cmp.BrandId;
                    brnd.Brand = cmp.Brandtitle;
                    brands.Add(brnd);
                }
            }
            foreach (var brnd in brands)
            {
                newcampList = new List<Campain_Type>();
                newcampList = camp.Where(b => b.BrandId == brnd.BrandId).ToList();
                brnd.campains = newcampList;
                foreach (var cmpsub in newcampList)
                {
                    Campain_Type newCmpSubj = new Campain_Type();
                    if (!newcampSubjectList.Any(i => i.Title == cmpsub.Title))
                    {
                        newcampSubjectList.Add(cmpsub);
                    }
                    
                }
                brnd.campainSubjects = newcampSubjectList;
                newcampSubjectList = new List<Campain_Type>();
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(brands));
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