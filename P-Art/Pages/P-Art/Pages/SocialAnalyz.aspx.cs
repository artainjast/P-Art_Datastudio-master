using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Globalization;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class SocialAnalyz : System.Web.UI.Page
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

            Response.Redirect("/TwitterAnalyze/?" + url);



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] TwitterKeywordCountChart(string fromDate, string toDate)
        {

            PersianCalendar pc = new PersianCalendar();

            var fromDateSplit = fromDate.Split('/');
            var toDateSplit = toDate.Split('/');

            DateTime FromDateTime = new DateTime(int.Parse(fromDateSplit[0]), int.Parse(fromDateSplit[1]), int.Parse(fromDateSplit[2]), 0, 0, 0, pc);
            DateTime ToDateTime = new DateTime(int.Parse(toDateSplit[0]), int.Parse(toDateSplit[1]), int.Parse(toDateSplit[2]), 23, 59, 59, pc);



            List<ChartValue> KeyCountList = new List<ChartValue>();
            KeyCountList = (from k in _dbStatic.Tbl_SocialMediaPost
                            join b in _dbStatic.Tbl_SocialMediaKey on k.SocialMediaKeyID_FK equals b.SocialMediaKeyID
                            where b.ParminID_FK == ParminId && k.PostDate >= FromDateTime && k.PostDate <= ToDateTime
                            group b by b.Title into g
                            select new ChartValue
                            {
                                Name = g.Key,
                                Value = g.Count()
                            }).OrderByDescending(K => K.Value).ToList();


            return KeyCountList.ToArray();

        }


    }

}
