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
    /// Summary description for Part_Competitors_Show_Ads_RadioVideo_AllData
    /// </summary>
    public class Part_Competitors_Show_Ads_RadioVideo_AllData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);

            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            ViewModel_RadioVideo ResultSeriesList = new ViewModel_RadioVideo();
            List<Tbl_Video_General> videos = (new Class_Competitors_Data()).GetCompetitorsShowAdsVideo(ParminId, fromDateIndex, toDateIndex);
            List<Tbl_Radio_General> radios = (new Class_Competitors_Data()).GetCompetitorsShowAdsRadio(ParminId, fromDateIndex, toDateIndex);
            //foreach (var v in videos)
            //{
            //    ChartValue newValue = new ChartValue();
            //    if (radios.Any(i => i.Name == v.Name))
            //    {
            //        newValue.Name = v.Name;
            //        long radioValue = 0;
            //        ChartValue radio = radios.FirstOrDefault(j => j.Name == v.Name);
            //        if (radio != null)
            //            radioValue = radio.Value;
            //        newValue.Value = v.Value + radioValue;
            //        ResultSeriesList.Add(newValue);
            //    }
            //}
            //foreach (var rad in radios)
            //{
            //    if (!ResultSeriesList.Any(i => i.Name == rad.Name))
            //    {
            //        ChartValue newValue = new ChartValue();
            //        newValue.Name = rad.Name;
            //        newValue.Value = rad.Value;
            //        ResultSeriesList.Add(newValue);
            //    }
            //}
            //foreach (var vid in videos)
            //{
            //    if (!ResultSeriesList.Any(i => i.Name == vid.Name))
            //    {
            //        ChartValue newValue = new ChartValue();
            //        newValue.Name = vid.Name;
            //        newValue.Value = vid.Value;
            //        ResultSeriesList.Add(newValue);
            //    }
            //}
            ResultSeriesList.radioList = radios;
            ResultSeriesList.videoList = videos;
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(ResultSeriesList));
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