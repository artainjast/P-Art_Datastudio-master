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

namespace P_Art.Pages.P_Art.Pages
{
    public partial class DataCenterNewsArchive : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<Tbl_DataCenterNews> dataCenterNews = new List<Tbl_DataCenterNews>();
        List<int?> UserPanelList = new List<int?>();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            UserPanelList = Class_Layer.UserPanels();
            var parmin = UserPanelList[0].Value + "";
            NewsIdParminId.Value = parmin;
            dataCenterNews = (from news in _db.Tbl_DataCenterNews
                              where UserPanelList.Contains(news.ParminID)
                              select news).ToList();
            dataCenterNewsArchiveRepeater.DataSource = dataCenterNews;
            dataCenterNewsArchiveRepeater.DataBind();

        }

        public static string DiffrentDate(object ddate, string sitetype, string newstime, string newsDateStr)
        {
            try
            {
                Class_Zaman zm = new Class_Zaman();
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                var newsDtTime = new DateTime();
                if (string.IsNullOrWhiteSpace(newsDateStr))
                {
                    newsDtTime = Convert.ToDateTime(ddate);
                }
                else
                {
                    newsDtTime = Class_Static.ConvertIntFarsiDate(newsDateStr);
                }

                if (sitetype == "2")
                {
                    return Persia.Calendar.ConvertToPersian(newsDtTime).ToString();

                }
                var dt = new DateTime();
                if (!string.IsNullOrWhiteSpace(newstime))
                {
                    try
                    {
                        var newsDate = Convert.ToDateTime(newsDtTime);
                        newstime = Class_Static.GetAbsoluteTime(newstime);
                        var newstimeSpil = newstime.Split(':');
                        dt = new DateTime(newsDate.Year, newsDate.Month, newsDate.Day, Convert.ToInt32(newstimeSpil[0]), Convert.ToInt32(newstimeSpil[1]), 0);
                    }
                    catch
                    {
                        dt = (newsDtTime);
                    }
                }
                else
                {
                    dt = Convert.ToDateTime(newsDtTime);
                }
                return Class_Static.GetOnTimeDate(dt);
            }
            catch
            {
                return "";
            }
        }

        [WebMethod]
        public static int SaveDataCenterPackArchive(string fromDate, string toDate, string parmin, string bultanTitle, string SelectedNews)
        {

            Tbl_BultanArchive table = _dbStatic.Tbl_BultanArchive.Add(
                 new Tbl_BultanArchive
                 {
                     FromDateIndex = fromDate,
                     ToDateIndex = toDate,
                     PanelId = string.IsNullOrWhiteSpace(parmin) ? Convert.ToInt32(parmin) : 0,
                     Name = bultanTitle,
                     SelectedNews = SelectedNews
                 }
                 );
            _dbStatic.SaveChanges();

            return table.ArchiveId;
        }


    }
}