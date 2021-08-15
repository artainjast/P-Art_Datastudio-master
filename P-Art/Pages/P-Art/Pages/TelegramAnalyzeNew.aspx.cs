using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Script.Services;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class TelegramAnalyzeNew : System.Web.UI.Page
    {
        long fromDateIndex = 0;
        long toDateIndex = 0;
        int fromDate = 0;
        int toDate = 0;
        Class_Zaman _clsZm = new Class_Zaman();
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        static int ParminId = 0;
        List<int?> UserPanelList = new List<int?>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!IsPostBack)
            {
                UserPanelList = Class_Layer.UserPanels();
                string UserPanelString = string.Empty;

                if (txt_fromDate.Text == "")
                    txt_fromDate.Text = _clsZm.Today();
                if (txt_toDate.Text == "")
                    txt_toDate.Text = _clsZm.Today();

                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }

                if (Request.QueryString["FromDate"] != null)
                {

                    fromDate = int.Parse(Request.QueryString["FromDate"].ToString());
                    txt_fromDate.Text = fromDate.ToString().Substring(0, 4) + "/" + fromDate.ToString().Substring(4, 2) + "/" + fromDate.ToString().Substring(6, 2);
                }
                else
                {
                    txt_fromDate.Text = _clsZm.Today();
                }
                if (Request.QueryString["ToDate"] != null)
                {
                    toDate = int.Parse(Request.QueryString["ToDate"].ToString());
                    txt_toDate.Text = toDate.ToString().Substring(0, 4) + "/" + toDate.ToString().Substring(4, 2) + "/" + toDate.ToString().Substring(6, 2);

                }
                else
                {
                    txt_toDate.Text = _clsZm.Today();

                }

                fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", "")) * 10000;
                toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", "")) * 10000 + 2500;

                UserPanelList = Class_Layer.UserPanels();
                var parmin = UserPanelList[0].Value + "";

                ParminId = GetStaticParmin(UserPanelList);

            }


        }

        public static int GetStaticParmin(List<int?> UserPanelList)
        {
            int ParminId = UserPanelList[0].Value;
            return ParminId;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] TelegramKeywordCountChart(string fromDate, string toDate)
        {
            long fromDateIndex = long.Parse(fromDate.Replace("/", "") + "0000");
            long toDateIndex = long.Parse(toDate.Replace("/", "") + "2500");

            List<ChartValue> KeyCountList = new List<ChartValue>();
            var KeyCount = from k in _dbStatic.Tbl_TLPMessage
                           where k.PanelID == ParminId && k.DateTimeIndex >= fromDateIndex && k.DateTimeIndex <= toDateIndex
                           group k by k.KeywordID into g
                           select new
                           {
                               KeyId = g.Key,
                               Count = g.Count()
                           };

            KeyCountList = (from a in KeyCount
                            join b in _dbStatic.Tbl_TLPKeywords on a.KeyId equals b.ID
                            select new ChartValue
                            {
                                Name = b.Title,
                                Value = a.Count
                            }).OrderByDescending(K => K.Value).ToList();

            return KeyCountList.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] TelegramChannelsCountChart(string fromDate, string toDate)
        {
            long fromDateIndex = long.Parse(fromDate.Replace("/", "") + "0000");
            long toDateIndex = long.Parse(toDate.Replace("/", "") + "2500");

            List<ChartValue> KeyCountList = new List<ChartValue>();


            var KeyCountList1 = (from k in _dbStatic.Tbl_TLPMessage
                                 where k.PanelID == ParminId && k.DateTimeIndex >= fromDateIndex && k.DateTimeIndex <= toDateIndex
                                 group k by k.ChannelID).ToList();


            foreach (var item in KeyCountList1)
            {
                KeyCountList.Add(new ChartValue {
                    Name = GetChannelName((int)item.Key),
                    Value = item.Count()
                } );
            }





            return KeyCountList.OrderByDescending(k => k.Value).Take(20).ToArray();
        }

        public static string GetChannelName(int ChannelID)
        {
            string ChannelName = _dbStatic.Tbl_TLPChannels.Where(C => C.ChannelID == ChannelID).Select(C => C.ChannelTitle).FirstOrDefault();
            return ChannelName;
        }


        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {


            string url = "";

            if (txt_fromDate.Text != "")
            {
                url = "fromDate=" + txt_fromDate.Text.Replace("/", "") + "&";
            }
            if (txt_toDate.Text != "")
            {
                url += "toDate=" + txt_toDate.Text.Replace("/", "") + "&";
            }


            url = url.Substring(0, url.Length - 1);

            Response.Redirect("/TelegramAnalyzeNew/?" + url);



        }
    }
}