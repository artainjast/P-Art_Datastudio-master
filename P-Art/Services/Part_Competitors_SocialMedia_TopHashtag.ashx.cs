﻿using System.Linq;
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
    /// Summary description for Part_Competitors_SocialMedia_TopHashtag
    /// </summary>
    public class Part_Competitors_SocialMedia_TopHashtag : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            var values = new List<ChartValue>();

            List<ChartValue_NewData> resutList = new List<ChartValue_NewData>();
            Class_News _clsNews = new Class_News();
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

            ChartData insta = (new Class_Competitors_Data()).GetCompetitorsTwitterFavorite(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData twitter = (new Class_Competitors_Data()).GetCompetitorsTwitterReply(ParminId, fromDateTimeIndex, toDateTimeIndex);
            ChartData telegram = (new Class_Competitors_Data()).GetCompetitorsTwitterRetwitte(ParminId, fromDateTimeIndex, toDateTimeIndex);


            List<ChartValue> valueList = new List<ChartValue>();

            foreach (var n in insta.data)
            {
                ChartValue val = new ChartValue();
                val.Name = n.Name;
                val.Value = n.Value;
                valueList.Add(val);
            }
            foreach (var n in twitter.data)
            {
                ChartValue val = new ChartValue();
                if (valueList.Any(i => i.Name == n.Name))
                {
                    var findedSeri = valueList.FirstOrDefault(i => i.Name == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Value += n.Value;
                    }
                }
                else
                {
                    val.Name = n.Name;
                    val.Value = n.Value;
                    valueList.Add(val);
                }
            }
            foreach (var n in telegram.data)
            {
                ChartValue val = new ChartValue();
                if (valueList.Any(i => i.Name == n.Name))
                {
                    var findedSeri = valueList.FirstOrDefault(i => i.Name == n.Name);
                    if (findedSeri != null)
                    {
                        findedSeri.Value += n.Value;
                    }
                }
                else
                {
                    val.Name = n.Name;
                    val.Value = n.Value;
                    valueList.Add(val);
                }
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(valueList));
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