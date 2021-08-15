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
    /// Summary description for Part_Competitors_Show_Telegram_Mohtava
    /// </summary>
    public class Part_Competitors_Show_Telegram_Mohtava : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string fromDate = context.Request["f"].ToString();
            string toDate = context.Request["t"].ToString();
            int ParminId = Convert.ToInt32(context.Request["p"]);
            var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
            var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

            var fromDateTimeIndex = fromDateIndex * 10000;
            var toDateTimeIndex = (toDateIndex * 10000) + 2400;

            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            List<ViewModel_Telegram_General> allTelegram = new List<ViewModel_Telegram_General>();

            List<Tbl_Telegram_General> telegrams = (new Class_Competitors_Data()).GetCompetitorsShowTelegram(ParminId, fromDateTimeIndex, toDateTimeIndex);
            foreach (var v in telegrams)
            {
                ViewModel_Telegram_General vid = new ViewModel_Telegram_General();
                vid.Keyword = v.keywordTitle;
                vid.KeywordID = v.KeywordID;
                vid.telegramList = telegrams.Where(i => i.KeywordID == v.KeywordID).ToList();
                if (!allTelegram.Any(i => i.KeywordID == v.KeywordID))
                    allTelegram.Add(vid);
            }
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(allTelegram));
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