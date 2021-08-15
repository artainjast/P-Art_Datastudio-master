using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Core;
using System.Web.Services;
using P_Art.Pages.P_Art.Repository;

using P_Art.Pages.P_Art.ModelNews;
using PArt.Pages.P_Art.Repository;
using System.Data;
using System.Web.Script.Services;
using System.IO;
using ReportBuilder;
using System.Data.SqlClient;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string[] CalculateDate(string fromDate, string ToDate, int days)
        {
            string[] results = new string[2];
            Class_Zaman _zm = new Class_Zaman();

            if (days == 0)
            {
                results[0] = _zm.Today();
                results[1] = _zm.Today();
            }
            else
            {
                fromDate = _zm.Today();
                results[0] = _zm.AddDay(fromDate, days).Substring(0, 10);
                results[1] = _zm.Today();
            }

            return results;

        }
        [WebMethod]
        public static string GetRelativeData(string newsid)
        {
            return "";
        }
        [WebMethod]
        public static bool UpdateUserSortingOrder(string userId, string siteIds)
        {
            Class_User _clsUser = new Class_User();
            var res = _clsUser.UpdateUserSortOrder(Convert.ToInt32(userId), siteIds);
            if (res == null)
                return false;

            HttpContext.Current.Session["CurrentUser"] = res;


            return true;
        }
        [WebMethod]
        public static string[] GenerateReport(string NewsIds, string fromDate, string toDate, string AllowNewsPaper, string AllowCharts, string Cinema, string ExportType, string AllowGozideh, string AllowMashrooh, string NewsType, string name, string AddArchive, string bultanid, string allowHighlight, string allowRelated, string fullContentBultan)
        {
            try
            {
                NewsIds = NewsIds.Replace(",,", ",");
                NewsIds = NewsIds.Replace(",undefined,", ",");
                NewsIds = NewsIds.Replace(",,", ",");
                if (NewsIds == ",") return null;



                if (NewsIds.Substring(0, 1) == ",") NewsIds = NewsIds.Substring(1, NewsIds.Length - 1);
                if (NewsIds.Substring(NewsIds.Length - 1, 1) == ",") NewsIds = NewsIds.Substring(0, NewsIds.Length - 1);

                NewsIds = NewsIds.Replace(",,", ",");

                var NewsIdsFinal = "";

                var lstNewsDic = new Dictionary<int, int>();
                foreach (var n in NewsIds.Split(','))
                {

                    if (string.IsNullOrWhiteSpace(n)) continue;

                    var nVal = Convert.ToInt32(n.Split(';')[0]);
                    var nOrder = Convert.ToInt32(n.Split(';')[1]);

                    if (lstNewsDic.Any(t => t.Key == nVal))
                    {
                        //اگر خبری با همین مشخصه اولیت بالاتر یعنی اول تر بود آپدیت کن
                        if (lstNewsDic.FirstOrDefault(t => t.Key == nVal).Value == 1000 && nOrder != 1000)
                        {
                            lstNewsDic.Remove(nVal);
                            lstNewsDic.Add(nVal, nOrder);
                        }
                        continue;
                    }
                    lstNewsDic.Add(nVal, nOrder);
                }

                foreach (var item in lstNewsDic.OrderBy(t => t.Value).ToList())
                {
                    NewsIdsFinal += "," + item.Key + ";" + item.Value;
                }
                if (!string.IsNullOrWhiteSpace(NewsIdsFinal))
                {
                    NewsIdsFinal = NewsIdsFinal.Substring(1);
                }

                NewsIds = NewsIdsFinal;

                HttpContext.Current.Session["NewsIds"] = "," + NewsIds + ",";
                DB_NewsCenterEntities db = new DB_NewsCenterEntities();

                var CurrentUser = Class_Layer.CurrentUser();


                string afterNewsSelected = "";

                bool allowSaveSetting = true;
                if (CurrentUser.AllowSaveNews != null)
                {
                    if (CurrentUser.AllowSaveNews == false)
                    {
                        allowSaveSetting = false;
                    }

                }
                for (int i = 0; i <= NewsIds.Split(',').Count() - 1; i++)
                {
                    if (NewsIds.Split(',')[i] == "") continue;

                    if (allowSaveSetting == true) db.Database.ExecuteSqlCommand("update tbl_news set SortOrder=" + NewsIds.Split(',')[i].Split(';')[1] + " where newsid =" + NewsIds.Split(',')[i].Split(';')[0]);

                    afterNewsSelected += NewsIds.Split(',')[i].Split(';')[0] + ",";
                }

                afterNewsSelected = afterNewsSelected.Substring(0, afterNewsSelected.Length - 1);
                NewsIds = afterNewsSelected;
                bool allowNimta = bool.Parse(AllowNewsPaper);
                bool allowChart = bool.Parse(AllowCharts);
                bool allowCinema = bool.Parse(Cinema);

                var report = new SepaarReport();

                Class_Panels _clsPanel = new Class_Panels();

                report.AllowJarayed = true;
                report.AllowKeys = allowChart;
                report.AllowKhabarGozari = true;
                report.AllowNewsSource = allowChart;
                report.AllowNimta = allowNimta;
                report.AllowPeople = true;
                report.AllowRelate = true;
                report.AllowTV = allowCinema;
                report.ReportTitle = name;
                report.AllowHighlight = bool.Parse(allowHighlight);
                report.AllowRelate = bool.Parse(allowRelated);
                report.FullContentBultan = Convert.ToBoolean(fullContentBultan);

                int panelId = 0;
                try
                {


                    panelId = int.Parse(Class_Layer.UserPanels()[0].ToString());
                }
                catch
                {

                }
                report.ParminIDs = panelId + "";
                report.BultanId = int.Parse(bultanid);


                //if (bool.Parse(AllowGozideh) == true)
                //{
                //    report.ExportGozidehPath = _clsPanel.GetParminById(int.Parse(HttpContext.Current.Session["CurrentDB"].ToString())).ExportGozideh;

                //}
                //if (bool.Parse(AllowMashrooh) == true)
                //{
                //    report.ExportMashroohPath = _clsPanel.GetParminById(int.Parse(HttpContext.Current.Session["CurrentDB"].ToString())).ExportMashrooh;

                //}
                if (fromDate != "")
                {
                    report.DateFrom = long.Parse(fromDate.Replace("/", ""));
                    report.DateTo = long.Parse(toDate.Replace("/", ""));
                }
                report.FileName = Guid.NewGuid() + ".pdf";
                report.KeywordsId = "0";
                report.DistrictIds = "0";


                List<string> st = new List<string>();
                if (report.ExportType == "pdf")
                {
                    report.FileName = Guid.NewGuid() + ".pdf";
                }
                else if (report.ExportType == "word")
                {
                    report.FileName = Guid.NewGuid() + ".rtf";
                }

                st.Add(HttpContext.Current.Server.MapPath(".") + "\\pdf\\" + report.FileName);

                var maxLength = _clsPanel.GetBultanPathById(report.BultanId);
                if (maxLength.MaxCharecterPerPage != null)
                {
                    report.MaxLimitCharecters = maxLength.MaxCharecterPerPage;
                }
                if (report.BultanId == 40)
                {
                    report.ReportPath = _clsPanel.GetBultanPathById(40).BultanPath;
                    report.pageIndexNimta = 1;
                    report.pageIndexKeys = 2;
                    report.pageIndexChart1 = 3;
                    report.pageIndexChart2 = 4;
                    report.pageIndexChart3 = 5;
                    report.pageIndexTV = 6;
                    report.pageIndexJarayed = 8;
                    report.pageIndexKhabarGozari = 9;
                    report.pageIndexPeople = 10;
                    report.pageIndexList = 7;
                }
                else
                {
                    var bultanFile = _clsPanel.GetBultanPathById(report.BultanId);
                    if (bultanFile.pageIndexNimta == null) bultanFile.pageIndexNimta = 1;
                    if (bultanFile.pageIndexKeys == null) bultanFile.pageIndexKeys = 2;
                    if (bultanFile.pageIndexChart1 == null) bultanFile.pageIndexChart1 = 3;
                    if (bultanFile.pageIndexChart2 == null) bultanFile.pageIndexChart2 = 4;
                    if (bultanFile.pageIndexChart3 == null) bultanFile.pageIndexChart3 = 5;
                    if (bultanFile.pageIndexTV == null) bultanFile.pageIndexTV = 6;
                    if (bultanFile.pageIndexJarayed == null) bultanFile.pageIndexJarayed = 8;
                    if (bultanFile.pageIndexKhabarGozari == null) bultanFile.pageIndexKhabarGozari = 9;
                    if (bultanFile.pageIndexPeople == null) bultanFile.pageIndexPeople = 10;
                    if (bultanFile.pageIndexList == null) bultanFile.pageIndexList = 7;


                    report.ReportPath = bultanFile.BultanPath;
                    report.pageIndexNimta = int.Parse(bultanFile.pageIndexNimta.ToString());
                    report.pageIndexKeys = int.Parse(bultanFile.pageIndexKeys.ToString()); ;
                    report.pageIndexChart1 = int.Parse(bultanFile.pageIndexChart1.ToString());
                    report.pageIndexChart2 = int.Parse(bultanFile.pageIndexChart2.ToString());
                    report.pageIndexChart3 = int.Parse(bultanFile.pageIndexChart3.ToString());
                    report.pageIndexTV = int.Parse(bultanFile.pageIndexTV.ToString());
                    report.pageIndexJarayed = int.Parse(bultanFile.pageIndexJarayed.ToString());
                    report.pageIndexKhabarGozari = int.Parse(bultanFile.pageIndexKhabarGozari.ToString());
                    report.pageIndexPeople = int.Parse(bultanFile.pageIndexPeople.ToString());
                    report.pageIndexList = int.Parse(bultanFile.pageIndexList.ToString());

                }

                report.NewsType = int.Parse(NewsType);
                report.ExportPaths = st;
                report.NewsIds = NewsIds;

                bool result = report.GenerateReport();

                string[] results = new string[2];

                if (result == true)
                {
                    results[0] = report.FileName;
                    if (panelId > 0)
                    {


                        string DirectoryPath = HttpContext.Current.Server.MapPath("~/BultanArchive/" + DateTime.Now.Year + DateTime.Now.Month);

                        if (Directory.Exists(DirectoryPath) == false) Directory.CreateDirectory(DirectoryPath);

                        string fileName = Guid.NewGuid().ToString().Replace("-", "") + ".pdf";
                        DirectoryPath += "\\" + report.FileName;

                        File.Copy(HttpContext.Current.Server.MapPath(".") + "\\pdf\\" + report.FileName, DirectoryPath);
                        Class_BultanArchive _clsBultan = new Class_BultanArchive();
                        if (AddArchive == "true")
                        {
                            _clsBultan.InsertArchive(report.DateFrom, panelId, DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "\\" + report.FileName, name, NewsIds);
                        }
                        else
                        {


                            var lastBultan = _clsBultan.GeLastArchive(panelId, report.DateFrom);
                            if (lastBultan == null)
                            {
                                _clsBultan.InsertArchive(report.DateFrom, panelId, DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "\\" + report.FileName, name, NewsIds);
                            }
                            else
                            {
                                _clsBultan.UpdateArchive(lastBultan.ArchiveId, DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "\\" + report.FileName, name, NewsIds);
                            }
                        }

                    }
                    results[1] = report.FileSize;
                    try
                    {
                        var currentUser = (Tbl_AgenceMembers)HttpContext.Current.Session["CurrentUser"];

                        //  var user = db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == userId);
                        var parminId = Convert.ToInt32(currentUser.ParminIds.Split(',')[0]);
                        var parmin = db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == parminId);
                        if (parmin.hdParmin == true)
                        {

                        }
                        else
                        {
                            //insert user panel bultan log
                            var bultanLog = new Tbl_BultanLog();
                            bultanLog.BultanPath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "//" + report.FileName;
                            bultanLog.BultanTitle = name;
                            bultanLog.Datetime = DateTime.Now;
                            bultanLog.ParminIDs = currentUser.ParminIds;
                            bultanLog.UserID = currentUser.MemberID;
                            db.Tbl_BultanLog.Add(bultanLog);
                            db.SaveChanges();
                        }



                    }
                    catch
                    {

                    }

                    return results;
                }
                else
                {

                    return null;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return null;
            }
        }
        [WebMethod]
        public static string[] GetMovieById(string MovieId)
        {
            string[] results = new string[11];


            Class_Movies _cls = new Class_Movies();
            var query = _cls.GetMovieById(int.Parse(MovieId), Class_Layer.UserPanels());
            results[0] = query.Title;
            results[1] = query.VideoDate;
            results[2] = query.VideoTime;
            results[3] = query.ViewCount.ToString();
            results[4] = query.ProgramTime;
            results[5] = query.ProgramName;
            results[6] = query.PlayTime;
            results[7] = query.NetworkName;
            results[8] = query.MovieID.ToString();
            results[9] = query.VideoPath;
            results[10] = query.PosterPath;
            return results;



        }


        [WebMethod]
        public static string[] GetRadioById(string SoundId)
        {
            string[] results = new string[11];


            Class_Sound _cls = new Class_Sound();
            var query = _cls.GetRadioById(int.Parse(SoundId), Class_Layer.UserPanels());
            results[0] = query.Title;
            results[1] = query.DDate;
            results[2] = query.TTime;
            results[3] = query.ViewCount.ToString();
            results[4] = query.SourceLength;
            results[5] = query.Source;
            results[6] = query.SourcePath;
            return results;



        }

        [WebMethod]
        public static void AddSelectionNews(string NewsId)
        {

            if (HttpContext.Current.Session["NewsSelection"] == null)
            {
                HttpContext.Current.Session["NewsSelection"] = ",";
            }

            string NewsSelection = HttpContext.Current.Session["NewsSelection"].ToString();

            NewsSelection += NewsId + ",";

            HttpContext.Current.Session["NewsSelection"] = NewsSelection;

        }

        [WebMethod]
        public static void Switch(string PanelId)
        {
            HttpContext.Current.Session["CurrentDB"] = PanelId;


        }
        [WebMethod]
        public static string GetLastPanelNews(string panelId)
        {
            var _clsNews = new Class_News();
            var PanelIds = new List<int?>();
            PanelIds.Add(int.Parse(panelId));
            var text = new List<string>();

            var news = _clsNews.GetAllNewsDataTable(1, 5, PanelIds, null, false, text, null, null, "", 0, null, "", "", "", "", false);

            var strNews = "";
            foreach (DataRow item in news.Rows)
            {
                strNews += item["NewsTitle"] + " | ";
            }

            return strNews;
        }

        [WebMethod]
        public static string[] MonitorNews()
        {
            return null;
#pragma warning disable CS0162 // Unreachable code detected
            if (HttpContext.Current.Session["CurrentDB"] == null) return null;
#pragma warning restore CS0162 // Unreachable code detected
            if (HttpContext.Current.Session["LastNewsId"] == null) return null;

            var lastNews = HttpContext.Current.Session["LastNewsId"].ToString();
            //lastNews = "292271";
            Class_News _cls = new Class_News();
            var result = _cls.GetMonitorinNews(Class_Layer.UserPanels(), int.Parse(lastNews));

            if (result.Count() == 0) return null;

            string[] CnResult = new string[result.Count()];


            for (int i = 0; i <= result.Count() - 1; i++)
            {
                CnResult[i] = result[i].NewsID.ToString() + "*SPLIT*" + result[i].NewsTitle + "*SPLIT*" + result[i].NewsPicture + "*SPLIT*" + GetNewsLead(result[i].NewsLead);

            }
            HttpContext.Current.Session["LastNewsId"] = result[0].NewsID.ToString();
            return CnResult;

        }

        [WebMethod]
        public static void SendMail(string NewsTitle, string NewsBody, string Speed, string Source)
        {
            Class_Core _cls = new Class_Core();
            _cls.SendMailMessage("info@artreport.ir", "mkh_fx@yahoo.com", "", "", "موج خبر", "تست");
        }
        private static string GetNewsLead(string NewsLead)
        {
            try
            {
                if (NewsLead.Length >= 300)
                {
                    return NewsLead.Substring(0, 300) + " ...";
                }
                else
                {
                    return NewsLead;
                }
            }
            catch
            {
                return "";
            }
        }

        [WebMethod]
        public static void DeleteNews(string NewsId)
        {
            Class_News cls = new Class_News();
            cls.DeleteNews(int.Parse(NewsId));
        }
        [WebMethod]
        public static string DeActiveNews(string NewsId)
        {
            Class_News cls = new Class_News();
            var res = cls.DeActiveNews(int.Parse(NewsId));
            return res.ToString().ToLower();
        }

        [WebMethod]
        public static string[] GetAgent(string agentId)
        {
            string[] agent = new string[6];
            agent[0] = "0";
            agent[1] = "حسین آذین";
            agent[2] = "حوزه انتخابیه : کرمان (رفسنجان)";
            agent[3] = "azin.jpg";
            agent[4] = "1";

            return agent;
        }

        [WebMethod]
        public static string[] GetAgentNews(string agentId)
        {
            string[] news = new string[10];
            news[0] = "";
            news[1] = "";
            news[2] = "";
            news[3] = "";
            news[4] = "";
            news[5] = "";
            news[6] = "";

            return news;
        }

        [WebMethod]
        public static string[] GetLastNews(string lastRow, string lastRowOtherNews, string showType, string fromDate, string toDate, string TvSourceType, string KeysToShow)
        {


            string panels = "";
            if (HttpContext.Current.Session["CurrentDB"] == null)
            {
                panels = Class_Layer.CurrentUser().ParminIds.Split(',')[0];
            }
            else
            {
                panels = HttpContext.Current.Session["CurrentDB"].ToString();
            }

            List<int?> arryPanels = new List<int?>();
            foreach (string panel in panels.Split(','))
            {
                arryPanels.Add(int.Parse(panel));

            }
            var sourceTv = false;
            if (TvSourceType == "2")
            { sourceTv = true; }

            DataTable ListNews = new DataTable();
            Class_News _clsNews = new Class_News();
            if (HttpContext.Current.Session["TvList"] == null)
            {

                ListNews = _clsNews.GetAllNewsDataTable(200, 1, arryPanels, null, false, null, null, null, "", null, true, "", "", "", KeysToShow, sourceTv);
                HttpContext.Current.Session["TvList"] = ListNews;


            }
            else
            {
                ListNews = (DataTable)HttpContext.Current.Session["TvList"];
            }

            DataRow currentRow = ListNews.Rows[int.Parse(lastRow)];

            string[] result = new string[14];
            result[0] = currentRow["NewsId"].ToString();
            result[1] = currentRow["NewsTitle"].ToString();
            result[2] = currentRow["NewsLead"].ToString();
            result[3] = currentRow["NewsPicture"].ToString();
            result[4] = currentRow["SiteTitle"].ToString();


            if (currentRow["CreateDate"] != null)
            {
                DateTime createDate = DateTime.Parse(currentRow["CreateDate"].ToString());
                currentRow["NewsDate"] += " " + createDate.Hour + ":" + createDate.Minute;

            }
            result[5] = currentRow["NewsDate"].ToString();
            result[12] = currentRow["NewsValue"].ToString();

            if (int.Parse(lastRow) == (ListNews.Rows.Count - 1))
            {

                HttpContext.Current.Session["TvList"] = null;
                throw new Exception("reset1");
            }

            if (showType == "2")
            {
                DataTable OtherNews = new DataTable();
                if (HttpContext.Current.Session["OtherList"] == null)
                {
                    arryPanels.Clear();
                    arryPanels.Add(526);

                    OtherNews = _clsNews.GetAllNewsDataTable(200, 1, arryPanels, null, false, null, null, null, "", null, true, "", "", "", KeysToShow, sourceTv);
                    HttpContext.Current.Session["OtherList"] = OtherNews;

                }
                else
                {
                    OtherNews = (DataTable)HttpContext.Current.Session["OtherList"];
                }

                //currentRow = OtherNews.Rows[int.Parse(lastRowOtherNews)];
                //result[6] = currentRow["NewsId"].ToString();
                // result[7] = currentRow["NewsTitle"].ToString();
                // result[8] = currentRow["NewsLead"].ToString();
                //result[9] = currentRow["NewsPicture"].ToString();
                //result[10] = currentRow["SiteTitle"].ToString();
                //result[13] = currentRow["NewsValue"].ToString();

                //if (currentRow["CreateDate"] != null)
                //{
                //    DateTime createDate = DateTime.Parse(currentRow["CreateDate"].ToString());

                //currentRow["NewsDate"] += " " + createDate.Hour + ":" + createDate.Minute;

                //}
                //result[11] = currentRow["NewsDate"].ToString();

                if (int.Parse(lastRowOtherNews) == (OtherNews.Rows.Count - 1))
                {

                    HttpContext.Current.Session["OtherList"] = null;
                    throw new Exception("reset2");
                }
            }
            return result;
        }


        [WebMethod]
        public static void ResetTV()
        {
            HttpContext.Current.Session["TvList"] = null;
        }


        [WebMethod]
        public static string[] AnalyzWords(string word, string fromDate, string toDate, string sourceType, string index)
        {
            long dateFrom = 0;
            long dateTo= 0;
            Class_News _clsNews = new Class_News();
            dateFrom = long.Parse(fromDate.Replace("/", ""));
            dateTo = long.Parse(toDate.Replace("/", ""));
            int SourceType = int.Parse(sourceType);
            
            var strPanels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                strPanels += item + ",";
            }
            strPanels = strPanels.Substring(0, strPanels.Length - 1);
            var analyz = _clsNews.GetAnalyzWord(word, strPanels, dateFrom, dateTo, SourceType);

            string[] result = new string[4];
            try
            {


                result[0] = analyz[0].ToString();
                result[1] = analyz[1].ToString();
                result[2] = analyz[2].ToString();
                result[3] = index;
            }
            catch
            {

            }
            return result;

        }


        [WebMethod]
        public static void SaveKeywords(string keywords)
        {


            try
            {
                var panels = "";
                if (HttpContext.Current.Session["CurrentDB"] == null)
                {
                    panels = Class_Layer.CurrentUser().ParminIds.Split(',')[0];
                }
                else
                {
                    panels = HttpContext.Current.Session["CurrentDB"].ToString();
                }

                Class_Panels _cls = new Class_Panels();
                _cls.UpdateKeywordAnalyz(int.Parse(panels), keywords);
            }
            catch
            {
                return;
            }

        }

        [WebMethod]
        public static string GetKeywords()
        {

            try
            {
                var panels = "";
                if (HttpContext.Current.Session["CurrentDB"] == null)
                {
                    panels = Class_Layer.CurrentUser().ParminIds.Split(',')[0];
                }
                else
                {
                    panels = HttpContext.Current.Session["CurrentDB"].ToString();
                }

                Class_Panels _cls = new Class_Panels();
                return _cls.GetkeywordAnalyz(int.Parse(panels));
            }
            catch
            {
                return "";
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] AnalyzKhabargozari(string fromDate, string toDate)
        {
            Class_News _clsNews = new Class_News();

            long fDate = long.Parse(fromDate.Replace("/", ""));
            long tDate = long.Parse(toDate.Replace("/", ""));

            var result1 = _clsNews.GetNewsCountBySiteType(Class_Layer.UserPanels()[0].ToString(), fDate, tDate, "1");
            var result2 = _clsNews.GetNewsCountBySiteType(Class_Layer.UserPanels()[0].ToString(), fDate, tDate, "2");


            List<ChartValue> values = new List<ChartValue>();
            values.Add(new ChartValue { Name = "خبرگزاری", Value = result1 });
            values.Add(new ChartValue { Name = "جراید", Value = result2 });

            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] KhabargozariChart(string fromDate, string toDate)
        {
            Class_News _clsNews = new Class_News();

            long fDate = long.Parse(fromDate.Replace("/", ""));
            long tDate = long.Parse(toDate.Replace("/", ""));

            return _clsNews.AnalyzNewsSource(Class_Layer.UserAllPanels(), fDate, tDate, 1).ToArray();

        }


        [WebMethod]
        public static void SetNewsValue(string NewsId, string value)
        {
            Class_News _cls = new Class_News();
            _cls.UpdateNewsValue(int.Parse(NewsId), int.Parse(value));

        }

        [WebMethod]
        public static void SetNewsValue1(string NewsId, string value)
        {
            Class_News _cls = new Class_News();
            _cls.UpdateNewsValue1(int.Parse(NewsId), int.Parse(value));

        }


        [WebMethod]
        public static void SetTvAllow(string newsId, string value)
        {
            Class_News _clsNews = new Class_News();
            _clsNews.SetTvAllow(newsId, value);

        }

        [WebMethod]
        public static void SetNewsSelect(string newsId, string value)
        {
            Class_Ado _clsAdo = new Class_Ado();

            if (Class_Layer.CurrentUser().AllowSaveNews != null)
            {
                if (Class_Layer.CurrentUser().AllowSaveNews == false)
                {
                    return;
                }

            }
            if (value == "true")
            {


                _clsAdo.ExecuteCommand("update tbl_news set IsSelected=1 where NewsId =" + newsId);
            }
            else
            {
                _clsAdo.ExecuteCommand("update tbl_news set IsSelected=0 where NewsId =" + newsId);
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] AnalyzChartKhabargozari(string fromDate, string toDate, string type)
        {
            Class_Ado _clsAdo = new Class_Ado();



            string query = "";

            if (type == "1")
            {
                query = @"SELECT     SiteID, COUNT(SiteID) AS CCount,
                          (SELECT     TOP (1) SiteTitle
                             FROM         Tbl_Sites
                             WHERE     (SiteID = tbl.SiteID)) AS SiteTitle
                            FROM         Tbl_News AS tbl
                            WHERE     (NewsID IN
                                                      (SELECT     NewsId
                                                         FROM         Tbl_Relation_NewsParminPanel
                                                         WHERE     (ParminPanelId IN ({2})) AND (NewsDateIndex BETWEEN {0} AND {1}))) AND (SiteID IN
                                                      (SELECT     SiteID
                                                         FROM         Tbl_Sites AS Tbl_Sites_1
                                                         WHERE     (SiteType = 1)))
                            GROUP BY SiteID
                            ORDER BY SiteTitle";
            }
            else
            {
                query = @"SELECT     SiteID, COUNT(SiteID) AS CCount,
                          (SELECT     TOP (1) SiteTitle
                             FROM         Tbl_Sites
                             WHERE     (SiteID = tbl.SiteID)) AS SiteTitle
                            FROM         Tbl_News AS tbl
                            WHERE     (NewsID IN
                                                      (SELECT     NewsId
                                                         FROM         Tbl_Relation_NewsParminPanel
                                                         WHERE     (ParminPanelId IN ({2})) AND (NewsDateIndex BETWEEN {0} AND {1}))) AND (SiteID IN
                                                      (SELECT     SiteID
                                                         FROM         Tbl_Sites AS Tbl_Sites_1
                                                         WHERE     (SiteType = 2)))
                            GROUP BY SiteID
                            ORDER BY SiteTitle";

            }
            string panels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                panels += item.Value + ",";
            }
            panels = panels.Substring(0, panels.Length - 1);

            query = query.Replace("{0}", "'" + fromDate.Replace("/", "") + "'");
            query = query.Replace("{1}", "'" + toDate.Replace("/", "") + "'");
            query = query.Replace("{2}", panels);

            DataTable dtResult = _clsAdo.FillDataTable(query);


            List<ChartValue> values = new List<ChartValue>();

            foreach (DataRow row in dtResult.Rows)
            {
                values.Add(new ChartValue { Name = row["SiteTitle"].ToString(), Value = int.Parse(row["CCount"].ToString()) });
            }


            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] AnalyzNewsValue(string fromDate, string toDate)
        {
            Class_Ado _clsAdo = new Class_Ado();



            string query = @"select NewsValue,COUNT(*) as CCount from Tbl_News 
                            where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({2}) and NewsDateIndex between {0} and {1})
                            group by NewsValue";

            string panels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                panels += item.Value + ",";
            }
            panels = panels.Substring(0, panels.Length - 1);

            query = query.Replace("{0}", "'" + fromDate.Replace("/", "") + "'");
            query = query.Replace("{1}", "'" + toDate.Replace("/", "") + "'");
            query = query.Replace("{2}", panels);

            DataTable dtResult = _clsAdo.FillDataTable(query);


            List<ChartValue> values = new List<ChartValue>();

            foreach (DataRow row in dtResult.Rows)
            {
                if (row["NewsValue"].ToString() == "")
                {


                    values.Add(new ChartValue { Name = "خنثی", Value = int.Parse(row["CCount"].ToString()) });
                }
                else if (row["NewsValue"].ToString() == "1")
                {
                    values.Add(new ChartValue { Name = "مثبت", Value = int.Parse(row["CCount"].ToString()) });
                }
                else if (row["NewsValue"].ToString() == "2")
                {
                    values.Add(new ChartValue { Name = "منفی", Value = int.Parse(row["CCount"].ToString()) });
                }
            }


            return values.ToArray();
        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] AnalyzNewsValueSocial(string fromDate, string toDate)
        {
            Class_Ado _clsAdo = new Class_Ado();



            string query = @"select NewsValue,COUNT(*) as CCount from (select NewsValue from Tbl_SocialMediaPost  inner join Tbl_SocialMediaKey on Tbl_SocialMediaPost.SocialMediaKeyID_FK=Tbl_SocialMediaKey.SocialMediaKeyID  where Tbl_SocialMediaKey.ParminID_FK in  ({2}) and Tbl_SocialMediaPost.PosteDateIndex between {0} and {1}) as tbl
                            group by NewsValue";

            string panels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                panels += item.Value + ",";
            }
            panels = panels.Substring(0, panels.Length - 1);

            query = query.Replace("{0}", "'" + fromDate.Replace("/", "") + "'");
            query = query.Replace("{1}", "'" + toDate.Replace("/", "") + "'");
            query = query.Replace("{2}", panels);

            DataTable dtResult = _clsAdo.FillDataTable(query);


            List<ChartValue> values = new List<ChartValue>();

            foreach (DataRow row in dtResult.Rows)
            {
                if (row["NewsValue"].ToString() == "")
                {


                    values.Add(new ChartValue { Name = "خنثی", Value = int.Parse(row["CCount"].ToString()) });
                }
                else if (row["NewsValue"].ToString() == "1")
                {
                    values.Add(new ChartValue { Name = "مثبت", Value = int.Parse(row["CCount"].ToString()) });
                }
                else if (row["NewsValue"].ToString() == "2")
                {
                    values.Add(new ChartValue { Name = "منفی", Value = int.Parse(row["CCount"].ToString()) });
                }
            }


            return values.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] AnalyzUsersValueSocial(string fromDate, string toDate)
        {
            Class_Ado _clsAdo = new Class_Ado();



            string query = @"select top 20 UserName,COUNT(UserName) as CCount from (select UserName from Tbl_SocialMediaPost  inner join Tbl_SocialMediaKey on Tbl_SocialMediaPost.SocialMediaKeyID_FK=Tbl_SocialMediaKey.SocialMediaKeyID  where Tbl_SocialMediaKey.ParminID_FK in  ({2}) and Tbl_SocialMediaPost.PosteDateIndex between {0} and {1}) as tbl
                            GROUP BY UserName order by COUNT(UserName) desc";

            string panels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                panels += item.Value + ",";
            }
            panels = panels.Substring(0, panels.Length - 1);

            query = query.Replace("{0}", "'" + fromDate.Replace("/", "") + "'");
            query = query.Replace("{1}", "'" + toDate.Replace("/", "") + "'");
            query = query.Replace("{2}", panels);

            DataTable dtResult = _clsAdo.FillDataTable(query);


            List<ChartValue> values = new List<ChartValue>();

            foreach (DataRow row in dtResult.Rows)
            {
                values.Add(new ChartValue { Name = row["UserName"].ToString(), Value = int.Parse(row["CCount"].ToString()) });
            }


            return values.ToArray();
            }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] ChartBoultanSocial(int ArchiveId)
        {
            Class_Ado _clsAdo = new Class_Ado();
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
            };
            DataSet ds = Class_Ado.ExecuteDataset("", "p_News_boultan_GetChartSocialdata",
                CommandType.StoredProcedure, sqlParams);

            DataTable dtResult = ds.Tables[0];
            List<ChartValue> values = new List<ChartValue>();
            foreach (DataRow row in dtResult.Rows)
            {

                values.Add(new ChartValue { Name = row["UserName"].ToString(), Value = int.Parse(row["NewsCount"].ToString()) });
            }
            return values.ToArray();
        }


        [WebMethod]
        public static string[] AnalyzWordsSocial(string word, string fromDate, string toDate, string sourceType, string index)
        {

            Class_News _clsNews = new Class_News();
            long dateFrom = long.Parse(fromDate.Replace("/", ""));
            long dateTo = long.Parse(toDate.Replace("/", ""));
            int SourceType = int.Parse(sourceType);
            var strPanels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                strPanels += item + ",";
            }
            strPanels = strPanels.Substring(0, strPanels.Length - 1);
            var analyz = _clsNews.GetAnalyzWordSocial(word, strPanels, dateFrom, dateTo, SourceType);

            string[] result = new string[1];
            try
            {


                result[0] = analyz[0].ToString();
                //result[1] = analyz[1].ToString();
                //result[2] = analyz[2].ToString();
               // result[1] = index;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            return result;

        }

        [WebMethod]
        public static ChartValue[] AnalyzUsersSocial(string fromDate, string toDate)
        {

            Class_News _clsNews = new Class_News();
            long dateFrom = long.Parse(fromDate.Replace("/", ""));
            long dateTo = long.Parse(toDate.Replace("/", ""));
           // int SourceType = int.Parse(sourceType);
            var strPanels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                strPanels += item + ",";
            }
            strPanels = strPanels.Substring(0, strPanels.Length - 1);
            var analyz = _clsNews.GetAnalyzUsersSocial(strPanels, dateFrom, dateTo);

           
            return analyz.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] ChartNewsValue(string fromDate, string toDate, string type, string newsValue)
        {
            Class_Ado _clsAdo = new Class_Ado();



            string query = @"select * from (SELECT     SiteID, SiteTitle,
                          (SELECT     COUNT(*) AS CCount
                             FROM         Tbl_News
                             WHERE     (SiteID = tbl.SiteID) AND (NewsID IN
                                                                                   (SELECT     NewsId
                                                                                      FROM         Tbl_Relation_NewsParminPanel
                                                                                      WHERE     (ParminPanelId IN ({4})) AND (NewsDateIndex BETWEEN {0} AND {1}))) AND (NewsValue {3} )) AS CCount
                            FROM         Tbl_Sites AS tbl
                            WHERE     (SiteType = {2})) as tbl where CCount > 0 order by SiteTitle";

            string panels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                panels += item.Value + ",";
            }
            panels = panels.Substring(0, panels.Length - 1);
            query = query.Replace("{0}", "'" + fromDate.Replace("/", "") + "'");
            query = query.Replace("{1}", "'" + toDate.Replace("/", "") + "'");
            query = query.Replace("{2}", type);
            query = query.Replace("{3}", newsValue);
            query = query.Replace("{4}", panels);
            DataTable dtResult = _clsAdo.FillDataTable(query);


            List<ChartValue> values = new List<ChartValue>();

            foreach (DataRow row in dtResult.Rows)
            {


                values.Add(new ChartValue { Name = row["SiteTitle"].ToString(), Value = int.Parse(row["CCount"].ToString()) });

            }


            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] AnalyzOstanpr(string fromDate, string toDate)
        {
            Class_Ado _clsAdo = new Class_Ado();



            string query = @"select 'اردبیل' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اردبیل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%بیله سوار%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%پارس آباد%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خلخال %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مشکین شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نیر %')
                            union all
                            select 'اصفهان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اصفهان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%آران و بیگدل%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%اردستان%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چادگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خمینی شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خوانسار %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سمیرم %'   or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شهر رضا %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فردین %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فلاورجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کاشان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مبرکه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نجف آباد %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نطنز %')
                            union all
                            select 'البرز' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% البرز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%بیله سوار%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خلخال %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%  آسارا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اشتهارد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هشتگرد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهسار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چهارباغ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طالقان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جوستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نظرآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تنکمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ساوجبلاغ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فردیس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهرشهر %')
                            union all
                            select 'ایلام' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایلام %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایوان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دره شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ده لران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%  شیروان %')
                            union all
                            select 'آذربایجان شرقی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آذربایجان شرقی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آذرشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسکو %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%  بستان آباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تبریز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جلفا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سراب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شبستر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% عجب شیر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مراغه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مرند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ملکان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% میانه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ورزقان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هریس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هشترود %' )
                            union all
                            select 'آذربایجان غربی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آذربایجان غربی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اشنویه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بوکان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پیرانشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چالدران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خوی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سردشت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سلماس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شاهین دژ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماکو %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهاباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% میاندوآب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نقده %' )
                            union all
                            select 'بوشهر' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بوشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تنگستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دشتستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دشتی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دیلم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گنگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گناوه %' )
                            union all
                            select 'تهران' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تهران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسلامشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پاکدشت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دماوند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رباط کریم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شمیرانات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شهریار %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فیروزکوه %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ورامین %')
                            union all
                            select 'چهارمحال و بختیاری' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چهارمحال %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اردل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بروجن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شهرکرد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فارسان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهرنگ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لردگان %' )
                            union all
                            select 'خراسان جنوبی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خراسان جنوبی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بیرجند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% درمیان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سرایان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سربیشه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فردوس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قائنات %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نهبندان %')
                            union all
                            select 'خراسان رضوی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خراسان رضوی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بردسکن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تایباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تربت جم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تربت حیدریه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چناران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خلیل آباد %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% درگز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رشتخوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سبزوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% درگز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رشتخوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سبزوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سرخس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فریمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قوچان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کاشمر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کلات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گناباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مشهد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مه ولات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نیشابور %')
                            union all
                            select 'خراسان شمالی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خراسان شمالی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسفراین %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جاجرم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شیروان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فاروج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سملقان %')
                            union all
                            select 'خوزستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خوزستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آبادان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% امیدیه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اندیمشک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اهواز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایذه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماغ ملک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماهشهر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بهبهان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمشهر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دزفول %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دشت آزادگان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زامشیر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شادگان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شوش %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شوشتر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گنوند %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مسجد سلیمان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هندیجان %')
                            union all
                            select 'زنجان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زنجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ابهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایجرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خدابنده %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمدره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طارم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماه نشان %')
                            union all
                            select 'سمنان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زنجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ابهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایجرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خدابنده %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمدره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سمنان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سمنان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شاهرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گرمسار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهدی شهر %')
                            union all
                            select 'سیستان و بلوچستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سیستان و بلوچستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایرانشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چابهار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خاش %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زاهدان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زهک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سراوان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سرباز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کنارک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نیک شهر %')
                            union all
                            select ' فارس ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فارس %')
                            union all
                            select ' قزوین ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قزوین %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آبیک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بوئین زهرا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تاکستان %')
                            union all
                            select ' قم ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قم %' )
                            union all
                            select ' کردستان ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کردستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بانه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بیجار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دیواندره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سروآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سقز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سنندج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قروه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کامیاران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مریوان %')
                            union all
                            select ' کرمان ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بردسیر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جیرفت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رفسنجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودبار جنوب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زرند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سیرجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% عنبرآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهبنان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کهنوج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% منوجان %')
                            union all
                            select ' کرمانشاه ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرمانشاه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسلام آباد غرب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پاوه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جوانرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلاهو %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% روانسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سنقر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کنگاور %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گیلان غرب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هرسین %')
                            union all
                            select ' کهگیلویه و بویراحمد ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بویراحمد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بهمئی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گچساران %')
                            union all
                            select 'گلستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گلستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آزادشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ترکمن %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رامیان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% علی آباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کلاکه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گرگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گنبد کاووس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مراوه تپه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مینودشت %')
                            union all
                            select 'گیلان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گیلان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آستارا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% املش %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بندر انزلی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رشت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رضوانشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودبار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سیاهکل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شفت %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% صومعه سرا %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طوالش %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فومن %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لاهیجان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لنگرود %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماسال %')
                            union all
                            select 'لرستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لرستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ازنا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% الیگودرز %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بروجرد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پل دختر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمدره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دورود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلفان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهدشت %')
                            union all
                            select 'مازندران' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مازندران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تنگابن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جویبار %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چالوس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رامسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ساری %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سوداکوه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قائم شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گلوگاه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% محمودآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نوشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بابل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بابلسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بهشهر %')
                            union all
                            select 'مرکزی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مرکزی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آشتیان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اراک %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تفرش %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خمین %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ساوه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شازند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کمیجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% محلات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلیجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زرندیه %' )
                            union all
                            select 'هرمزگان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هرمزگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ابوموسی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بستک %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بندرعباس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بندرلنگه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جاسک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جاچی آباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قشم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گاوبندی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% میانب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودان %' )
                            union all
                            select 'همدان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% همدان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسدآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تویسرکان %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رزن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ملایر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نهاوند %')
                            union all
                            select 'یزد' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% یزد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اردکان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بافق %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تفت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خاتم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% صدوق %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طبس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهریز %')


                            ";

            string panels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                panels += item.Value + ",";
            }
            panels = panels.Substring(0, panels.Length - 1);
            query = query.Replace("{1}", "'" + fromDate.Replace("/", "") + "'");
            query = query.Replace("{2}", "'" + toDate.Replace("/", "") + "'");
            query = query.Replace("{3}", panels);
            DataTable dtResult = _clsAdo.FillDataTable(query);


            List<ChartValue> values = new List<ChartValue>();

            foreach (DataRow row in dtResult.Rows)
            {


                values.Add(new ChartValue { Name = row["CityName"].ToString(), Value = int.Parse(row["CCount"].ToString()) });

            }


            return values.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] AnalyzOstan(string fromDate, string toDate)
        {
            Class_Ado _clsAdo = new Class_Ado();



            string query = @"select 'اردبیل' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اردبیل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%بیله سوار%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%پارس آباد%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خلخال %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مشکین شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نیر %')
                            union all
                            select 'اصفهان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اصفهان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%آران و بیگدل%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%اردستان%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چادگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خمینی شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خوانسار %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سمیرم %'   or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شهر رضا %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فردین %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فلاورجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کاشان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مبرکه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نجف آباد %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نطنز %')
                            union all
                            select 'البرز' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% البرز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%بیله سوار%' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خلخال %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%  آسارا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اشتهارد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هشتگرد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهسار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چهارباغ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طالقان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جوستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نظرآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تنکمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ساوجبلاغ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فردیس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهرشهر %')
                            union all
                            select 'ایلام' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایلام %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایوان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دره شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ده لران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%  شیروان %')
                            union all
                            select 'آذربایجان شرقی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آذربایجان شرقی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آذرشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسکو %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '%  بستان آباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تبریز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جلفا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سراب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شبستر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% عجب شیر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مراغه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مرند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ملکان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% میانه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ورزقان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هریس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هشترود %' )
                            union all
                            select 'آذربایجان غربی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آذربایجان غربی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اشنویه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بوکان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پیرانشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چالدران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خوی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سردشت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سلماس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شاهین دژ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماکو %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهاباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% میاندوآب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نقده %' )
                            union all
                            select 'بوشهر' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بوشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تنگستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دشتستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دشتی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دیلم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گنگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گناوه %' )
                            union all
                            select 'تهران' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تهران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسلامشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پاکدشت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دماوند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رباط کریم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شمیرانات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شهریار %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فیروزکوه %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ورامین %')
                            union all
                            select 'چهارمحال و بختیاری' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چهارمحال %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اردل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بروجن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شهرکرد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فارسان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهرنگ %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لردگان %' )
                            union all
                            select 'خراسان جنوبی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خراسان جنوبی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بیرجند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% درمیان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سرایان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سربیشه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فردوس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قائنات %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نهبندان %')
                            union all
                            select 'خراسان رضوی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خراسان رضوی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بردسکن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تایباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تربت جم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تربت حیدریه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چناران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خلیل آباد %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% درگز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رشتخوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سبزوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% درگز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رشتخوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سبزوار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سرخس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فریمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قوچان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کاشمر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کلات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گناباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مشهد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مه ولات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نیشابور %')
                            union all
                            select 'خراسان شمالی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خراسان شمالی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسفراین %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جاجرم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شیروان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فاروج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سملقان %')
                            union all
                            select 'خوزستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خوزستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آبادان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% امیدیه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اندیمشک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اهواز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایذه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماغ ملک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماهشهر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بهبهان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمشهر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دزفول %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دشت آزادگان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زامشیر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شادگان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شوش %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شوشتر %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گنوند %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مسجد سلیمان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هندیجان %')
                            union all
                            select 'زنجان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زنجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ابهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایجرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خدابنده %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمدره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طارم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماه نشان %')
                            union all
                            select 'سمنان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زنجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ابهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایجرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خدابنده %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمدره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سمنان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سمنان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شاهرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گرمسار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهدی شهر %')
                            union all
                            select 'سیستان و بلوچستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سیستان و بلوچستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ایرانشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چابهار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خاش %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زاهدان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زهک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سراوان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سرباز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کنارک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نیک شهر %')
                            union all
                            select ' فارس ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فارس %')
                            union all
                            select ' قزوین ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قزوین %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آبیک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بوئین زهرا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تاکستان %')
                            union all
                            select ' قم ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قم %' )
                            union all
                            select ' کردستان ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کردستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بانه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بیجار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دیواندره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سروآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سقز %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سنندج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قروه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کامیاران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مریوان %')
                            union all
                            select ' کرمان ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بردسیر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جیرفت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رفسنجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودبار جنوب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زرند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سیرجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% عنبرآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهبنان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کهنوج %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% منوجان %')
                            union all
                            select ' کرمانشاه ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرمان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کرمانشاه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسلام آباد غرب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پاوه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جوانرود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلاهو %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% روانسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سنقر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کنگاور %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گیلان غرب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هرسین %')
                            union all
                            select ' کهگیلویه و بویراحمد ' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بویراحمد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بهمئی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گچساران %')
                            union all
                            select 'گلستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گلستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آزادشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ترکمن %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رامیان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% علی آباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کلاکه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گرگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گنبد کاووس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مراوه تپه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مینودشت %')
                            union all
                            select 'گیلان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گیلان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آستارا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% املش %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بندر انزلی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رشت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رضوانشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودبار %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سیاهکل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شفت %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% صومعه سرا %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طوالش %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% فومن %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لاهیجان %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لنگرود %'  or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ماسال %')
                            union all
                            select 'لرستان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% لرستان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ازنا %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% الیگودرز %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بروجرد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% پل دختر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خرمدره %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دورود %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلفان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کوهدشت %')
                            union all
                            select 'مازندران' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مازندران %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تنگابن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جویبار %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% چالوس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رامسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ساری %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% سوداکوه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قائم شهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گلوگاه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% محمودآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نوشهر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بابل %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بابلسر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بهشهر %')
                            union all
                            select 'مرکزی' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مرکزی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% آشتیان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اراک %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تفرش %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خمین %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ساوه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% شازند %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% کمیجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% محلات %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% دلیجان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% زرندیه %' )
                            union all
                            select 'هرمزگان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% هرمزگان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ابوموسی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بستک %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بندرعباس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بندرلنگه %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جاسک %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% جاچی آباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% قشم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% گاوبندی %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% میانب %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رودان %' )
                            union all
                            select 'همدان' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% همدان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اسدآباد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تویسرکان %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% رزن %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% ملایر %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% نهاوند %')
                            union all
                            select 'یزد' as CityName,COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId in ({3}) and NewsDateIndex between {1} and {2}) and NewsTitle+'-' + NewsLead  +'-' + NewsBody like '%روابط عمومی%' and (NewsTitle +'-' + NewsLead +'-' + NewsBody like '% یزد %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% اردکان %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% بافق %'or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% تفت %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% خاتم %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% صدوق %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% طبس %' or NewsTitle +'-' + NewsLead +'-' + NewsBody like '% مهریز %')


                            ";

            string panels = "";
            foreach (var item in Class_Layer.UserPanels())
            {
                panels += item.Value + ",";
            }
            panels = panels.Substring(0, panels.Length - 1);
            query = query.Replace("{1}", "'" + fromDate.Replace("/", "") + "'");
            query = query.Replace("{2}", "'" + toDate.Replace("/", "") + "'");
            query = query.Replace("{3}", panels);
            DataTable dtResult = _clsAdo.FillDataTable(query);


            List<ChartValue> values = new List<ChartValue>();

            foreach (DataRow row in dtResult.Rows)
            {


                values.Add(new ChartValue { Name = row["CityName"].ToString(), Value = int.Parse(row["CCount"].ToString()) });

            }


            return values.ToArray();
        }


        [WebMethod]
        public static void SetCategoryIndex(string catId, string catIndex)
        {
            return;
#pragma warning disable CS0162 // Unreachable code detected
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
#pragma warning restore CS0162 // Unreachable code detected
            db.Database.ExecuteSqlCommand("update Tbl_RssKeywords set OrderItem=" + catIndex + " where KeyId=" + catId);
        }



        [WebMethod]
        public static void SetCategoryIndex1(string catId, string catIndex)
        {
            return;
#pragma warning disable CS0162 // Unreachable code detected
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
#pragma warning restore CS0162 // Unreachable code detected
            db.Database.ExecuteSqlCommand("update Tbl_SocialMediaKey set OrderNumber=" + catIndex + " where SocialMediaKeyID=" + catId);
        }


        //[WebMethod]
        //public static int SetBultanArchive(string fromDate, string toDate, string parmin, string bultanTitle, string SelectedNews)
        //{
        //    try
        //    {
        //        Class_BultanArchive archive = new Class_BultanArchive();
        //        string str = "";
        //        SelectedNews = SelectedNews.Replace(",,", ",");
        //        SelectedNews = SelectedNews.Replace(",undefined,", ",");
        //        SelectedNews = SelectedNews.Replace(",,", ",");
        //        if (SelectedNews.Substring(0, 1) == ",")
        //        {
        //            SelectedNews = SelectedNews.Substring(1, SelectedNews.Length - 1);
        //        }
        //        if (SelectedNews.Substring(SelectedNews.Length - 1, 1) == ",")
        //        {
        //            SelectedNews = SelectedNews.Substring(0, SelectedNews.Length - 1);
        //        }
        //        SelectedNews = SelectedNews.Replace(",,", ",");
        //        Dictionary<int, int> source = new Dictionary<int, int>();
        //        char[] separator = new char[] { ',' };
        //        foreach (string str2 in SelectedNews.Split(separator))
        //        {
        //            int nVal;
        //            if (!string.IsNullOrWhiteSpace(str2))
        //            {
        //                char[] chArray2 = new char[] { ';' };
        //                nVal = Convert.ToInt32(str2.Split(chArray2)[0]);
        //                char[] chArray3 = new char[] { ';' };
        //                int num2 = Convert.ToInt32(str2.Split(chArray3)[1]);
        //                if (source.Any<KeyValuePair<int, int>>(t => t.Key == nVal))
        //                {
        //                    if ((source.FirstOrDefault<KeyValuePair<int, int>>(t => (t.Key == nVal)).Value == 0x3e8) && (num2 != 0x3e8))
        //                    {
        //                        source.Remove(nVal);
        //                        source.Add(nVal, num2);
        //                    }
        //                }
        //                else
        //                {
        //                    source.Add(nVal, num2);
        //                }
        //            }
        //        }
        //        foreach (KeyValuePair<int, int> pair2 in (from t in source
        //                                                  orderby t.Value
        //                                                  select t).ToList<KeyValuePair<int, int>>())
        //        {
        //            str = str + "," + pair2.Key;
        //        }
        //        if (!string.IsNullOrWhiteSpace(str))
        //        {
        //            str = str.Substring(1);
        //        }
        //        return archive.InsertArchive(Convert.ToInt64(Class_Static.ShamisiWithoutSlash(fromDate)), Convert.ToInt32(parmin), "HTML", bultanTitle, str).ArchiveId;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}


        [WebMethod]
        public static bool UpdateGroupOrderNews(string NewsId, string GroupOrder)
        {
            try
            {
                //        SqlParameter[] sqlParams = {
                //        new SqlParameter("@" + "NewsID",Convert.ToInt32(NewsId)),
                //        new SqlParameter("@" + "GroupOrder",Convert.ToInt32(GroupOrder))
                //};
                //        Convert.ToInt32(Class_Ado.ExecuteNonQuery("", "p_News_GroupOrder_Update", CommandType.StoredProcedure, sqlParams));
                DB_NewsCenterEntities db = new DB_NewsCenterEntities();
                var newsIdInt = Convert.ToInt32(NewsId);
                var newsItem = db.Tbl_News.FirstOrDefault(t => t.NewsID == newsIdInt);
                newsItem.NewsGroupOrder = Convert.ToInt32(GroupOrder);

                db.SaveChanges();

                return true;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return false;
            }
        }

        [WebMethod]
        public static int SetBultanArchive(string fromDate, string toDate, string parmin, string bultanTitle, string SelectedNews)
        {
            try
            {
                Class_BultanArchive archive = new Class_BultanArchive();
                string str = "";
                SelectedNews = SelectedNews.Replace(",,", ",");
                SelectedNews = SelectedNews.Replace(",undefined,", ",");
                SelectedNews = SelectedNews.Replace(",,", ",");
                if (SelectedNews.Substring(0, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(1, SelectedNews.Length - 1);
                }
                if (SelectedNews.Substring(SelectedNews.Length - 1, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(0, SelectedNews.Length - 1);
                }
                SelectedNews = SelectedNews.Replace(",,", ",");
                Dictionary<int, int> source = new Dictionary<int, int>();
                char[] separator = new char[] { ',' };
                foreach (string str2 in SelectedNews.Split(separator))
                {
                    int nVal;
                    if (!string.IsNullOrWhiteSpace(str2))
                    {
                        char[] chArray2 = new char[] { ';' };
                        nVal = Convert.ToInt32(str2.Split(chArray2)[0]);
                        char[] chArray3 = new char[] { ';' };
                        int num2 = Convert.ToInt32(str2.Split(chArray3)[1]);
                        if (source.Any<KeyValuePair<int, int>>(t => t.Key == nVal))
                        {
                            if ((source.FirstOrDefault<KeyValuePair<int, int>>(t => (t.Key == nVal)).Value == 0x3e8) && (num2 != 0x3e8))
                            {
                                source.Remove(nVal);
                                source.Add(nVal, num2);
                            }
                        }
                        else
                        {
                            source.Add(nVal, num2);
                        }
                    }
                }
                foreach (KeyValuePair<int, int> pair2 in (from t in source
                                                          orderby t.Value
                                                          select t).ToList<KeyValuePair<int, int>>())
                {
                    str = str + "," + pair2.Key;
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    str = str.Substring(1);
                }
                return archive.InsertArchive(Convert.ToInt64(PArt.Pages.P_Art.Repository.Class_Static.ShamisiWithoutSlash(fromDate)), Convert.ToInt32(parmin), "HTML", PArt.Pages.P_Art.Repository.Class_Static.ConvertToLatinNumberSam(bultanTitle), str).ArchiveId;
            }
            catch
            {
                return 0;
            }
        }
        [WebMethod]
        public static int SetBultanArchive(string fromDate, string toDate, string parmin, string bultanTitle, string SelectedNews,
            string fromTime, string toTime, bool allowNewspaper, bool galleryNewspaper, bool arz, bool sima, bool highLight,
            bool allowGroup, bool related, int selectedBultan, bool isArchive, bool chart, bool jeld, byte BultanType, string linkUrl)
        {
            try
            {
                fromDate = fromDate.Replace("/", "");
                toDate = toDate.Replace("/", "");
                fromTime = fromTime.Replace(":", "");
                toTime = toTime.Replace(":", "");

                Class_BultanArchive archive = new Class_BultanArchive();
                string str = "";
                SelectedNews = SelectedNews.Replace(",,", ",");
                SelectedNews = SelectedNews.Replace(",undefined,", ",");
                SelectedNews = SelectedNews.Replace(";undefined,", ";1000,");
                SelectedNews = SelectedNews.Replace(",,", ",");
                if (SelectedNews.Substring(0, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(1, SelectedNews.Length - 1);
                }
                if (SelectedNews.Substring(SelectedNews.Length - 1, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(0, SelectedNews.Length - 1);
                }
                SelectedNews = SelectedNews.Replace(",,", ",");
                Dictionary<int, int> source = new Dictionary<int, int>();
                char[] separator = new char[] { ',' };
                foreach (string str2 in SelectedNews.Split(separator))
                {
                    int nVal;
                    if (!string.IsNullOrWhiteSpace(str2))
                    {
                        char[] chArray2 = new char[] { ';' };
                        nVal = Convert.ToInt32(str2.Split(chArray2)[0]);
                        char[] chArray3 = new char[] { ';' };
                        int num2 = Convert.ToInt32(str2.Split(chArray3)[1]);
                        if (source.Any<KeyValuePair<int, int>>(t => t.Key == nVal))
                        {
                            if ((source.FirstOrDefault<KeyValuePair<int, int>>(t => (t.Key == nVal)).Value == 0x3e8) && (num2 != 0x3e8))
                            {
                                source.Remove(nVal);
                                source.Add(nVal, num2);
                            }
                        }
                        else
                        {
                            source.Add(nVal, num2);
                        }
                    }
                }
                foreach (KeyValuePair<int, int> pair2 in (from t in source
                                                          orderby t.Value
                                                          select t).ToList<KeyValuePair<int, int>>())
                {
                    str = str + "," + pair2.Key;
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    str = str.Substring(1);
                }
                int result = archive.InsertArchive(Convert.ToInt64(PArt.Pages.P_Art.Repository.Class_Static.ShamisiWithoutSlash(fromDate)),
                    Convert.ToInt32(parmin), linkUrl, PArt.Pages.P_Art.Repository.Class_Static.ConvertToLatinNumberSam(bultanTitle), str, fromDate, toDate, fromTime, toTime, allowNewspaper, galleryNewspaper,
                    arz, sima, highLight, allowGroup, related, selectedBultan, isArchive, chart, jeld, BultanType);
                return result;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return 0;
            }
        }
        [WebMethod]
        public static int SetBultanInternationalArchive(string fromDate, string toDate, string parmin, string bultanTitle, bool arz, bool sima, bool allowGroup, string SelectedNews,
           string fromTime, string toTime, bool highLight,
            bool jeld, byte BultanType, string linkUrl)
        {
            try
            {
                fromDate = fromDate.Replace("/", "");
                toDate = toDate.Replace("/", "");
                fromTime = fromTime.Replace(":", "");
                toTime = toTime.Replace(":", "");

                Class_BultanArchive archive = new Class_BultanArchive();
                string str = "";
                SelectedNews = SelectedNews.Replace(",,", ",");
                SelectedNews = SelectedNews.Replace(",undefined,", ",");
                SelectedNews = SelectedNews.Replace(",,", ",");
                if (SelectedNews.Substring(0, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(1, SelectedNews.Length - 1);
                }
                if (SelectedNews.Substring(SelectedNews.Length - 1, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(0, SelectedNews.Length - 1);
                }
                SelectedNews = SelectedNews.Replace(",,", ",");
                Dictionary<int, int> source = new Dictionary<int, int>();
                char[] separator = new char[] { ',' };
                foreach (string str2 in SelectedNews.Split(separator))
                {
                    int nVal;
                    if (!string.IsNullOrWhiteSpace(str2))
                    {
                        char[] chArray2 = new char[] { ';' };
                        nVal = Convert.ToInt32(str2.Split(chArray2)[0]);
                        char[] chArray3 = new char[] { ';' };
                        int num2 = Convert.ToInt32(str2.Split(chArray3)[1]);
                        if (source.Any<KeyValuePair<int, int>>(t => t.Key == nVal))
                        {
                            if ((source.FirstOrDefault<KeyValuePair<int, int>>(t => (t.Key == nVal)).Value == 0x3e8) && (num2 != 0x3e8))
                            {
                                source.Remove(nVal);
                                source.Add(nVal, num2);
                            }
                        }
                        else
                        {
                            source.Add(nVal, num2);
                        }
                    }
                }
                foreach (KeyValuePair<int, int> pair2 in (from t in source
                                                          orderby t.Value
                                                          select t).ToList<KeyValuePair<int, int>>())
                {
                    str = str + "," + pair2.Key;
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    str = str.Substring(1);
                }
                int result = archive.InsertArchive(Convert.ToInt64(PArt.Pages.P_Art.Repository.Class_Static.ShamisiWithoutSlash(fromDate)),
                    Convert.ToInt32(parmin), linkUrl, PArt.Pages.P_Art.Repository.Class_Static.ConvertToLatinNumberSam(bultanTitle), str, fromDate, toDate, fromTime, toTime, false, false, false, highLight, jeld, BultanType);
                return result;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return 0;
            }
        }

                [WebMethod]
        public static int SetBultanInternationalArchive1(string fromDate, string toDate, string parmin, string bultanTitle, bool arz, bool sima, bool allowGroup, string SelectedNews,
           string fromTime, string toTime, bool highLight,
             byte BultanType, string linkUrl)
        {
            try
            {
                fromDate = fromDate.Replace("/", "");
                toDate = toDate.Replace("/", "");
                fromTime = fromTime.Replace(":", "");
                toTime = toTime.Replace(":", "");

                Class_BultanArchive archive = new Class_BultanArchive();
                string str = "";
                SelectedNews = SelectedNews.Replace(",,", ",");
                SelectedNews = SelectedNews.Replace(",undefined,", ",");
                SelectedNews = SelectedNews.Replace(",,", ",");
                if (SelectedNews.Substring(0, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(1, SelectedNews.Length - 1);
                }
                if (SelectedNews.Substring(SelectedNews.Length - 1, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(0, SelectedNews.Length - 1);
                }
                SelectedNews = SelectedNews.Replace(",,", ",");
                Dictionary<int, int> source = new Dictionary<int, int>();
                char[] separator = new char[] { ',' };
                foreach (string str2 in SelectedNews.Split(separator))
                {
                    int nVal;
                    if (!string.IsNullOrWhiteSpace(str2))
                    {
                        char[] chArray2 = new char[] { ';' };
                        nVal = Convert.ToInt32(str2.Split(chArray2)[0]);
                        char[] chArray3 = new char[] { ';' };
                        int num2 = Convert.ToInt32(str2.Split(chArray3)[1]);
                        if (source.Any<KeyValuePair<int, int>>(t => t.Key == nVal))
                        {
                            if ((source.FirstOrDefault<KeyValuePair<int, int>>(t => (t.Key == nVal)).Value == 0x3e8) && (num2 != 0x3e8))
                            {
                                source.Remove(nVal);
                                source.Add(nVal, num2);
                            }
                        }
                        else
                        {
                            source.Add(nVal, num2);
                        }
                    }
                }
                foreach (KeyValuePair<int, int> pair2 in (from t in source
                                                          orderby t.Value
                                                          select t).ToList<KeyValuePair<int, int>>())
                {
                    str = str + "," + pair2.Key;
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    str = str.Substring(1);
                }
                int result = archive.InsertArchive(Convert.ToInt64(PArt.Pages.P_Art.Repository.Class_Static.ShamisiWithoutSlash(fromDate)),
                    Convert.ToInt32(parmin), linkUrl, PArt.Pages.P_Art.Repository.Class_Static.ConvertToLatinNumberSam(bultanTitle), str, fromDate, toDate, fromTime, toTime, false, false, false, highLight, BultanType);
                return result;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return 0;
            }
        }


        [WebMethod]
        public static int SetBultanSocialArchive(string fromDate, string toDate, string parmin, string bultanTitle, string SelectedNews,bool chart, 
   string linkUrl)
        {
            try
            {
                fromDate = fromDate.Replace("/", "");
                toDate = toDate.Replace("/", "");
                
                Class_BultanArchive archive = new Class_BultanArchive();
                string str = "";
                SelectedNews = SelectedNews.Replace(",,", ",");
                SelectedNews = SelectedNews.Replace(",undefined,", ",");
                SelectedNews = SelectedNews.Replace(",,", ",");
                if (SelectedNews.Substring(0, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(1, SelectedNews.Length - 1);
                }
                if (SelectedNews.Substring(SelectedNews.Length - 1, 1) == ",")
                {
                    SelectedNews = SelectedNews.Substring(0, SelectedNews.Length - 1);
                }
                SelectedNews = SelectedNews.Replace(",,", ",");
                Dictionary<int, int> source = new Dictionary<int, int>();
                char[] separator = new char[] { ',' };
                foreach (string str2 in SelectedNews.Split(separator))
                {
                    int nVal;
                    if (!string.IsNullOrWhiteSpace(str2))
                    {
                        char[] chArray2 = new char[] { ';' };
                        nVal = Convert.ToInt32(str2.Split(chArray2)[0]);
                        char[] chArray3 = new char[] { ';' };
                        int num2 = Convert.ToInt32(str2.Split(chArray3)[1]);
                        if (source.Any<KeyValuePair<int, int>>(t => t.Key == nVal))
                        {
                            if ((source.FirstOrDefault<KeyValuePair<int, int>>(t => (t.Key == nVal)).Value == 0x3e8) && (num2 != 0x3e8))
                            {
                                source.Remove(nVal);
                                source.Add(nVal, num2);
                            }
                        }
                        else
                        {
                            source.Add(nVal, num2);
                        }
                    }
                }
                foreach (KeyValuePair<int, int> pair2 in (from t in source
                                                          orderby t.Value
                                                          select t).ToList<KeyValuePair<int, int>>())
                {
                    str = str + "," + pair2.Key;
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    str = str.Substring(1);
                }



               
              

                int result = archive.InsertSocialArchive(Convert.ToInt64(PArt.Pages.P_Art.Repository.Class_Static.ShamisiWithoutSlash(fromDate)),
                    Convert.ToInt32(parmin), linkUrl, bultanTitle, str,chart);
                return result;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return 0;
            }
        }


        [WebMethod]
        public static void SetBultanArchiveLink(string bultanArchiveId, string link)
        {
            Class_BultanArchive archive = new Class_BultanArchive();
            //string shorturl = PArtCore.Class.Class_Static.GoogleShortenLink(link);

            archive.UpdateArchiveLink(Convert.ToInt32(bultanArchiveId), (link));
        }

        //[WebMethod]
        //public static void DeleteNews(int newsID)
        //{
        //    Class_News _cls = new Class_News();

        //    _cls.DeleteNews(newsID);

        //}
        [WebMethod]
        public static bool DeleteBultanArchive(int ArchiveId, int NewsId)
        {
            try
            {
                Class_BultanArchive archive = new Class_BultanArchive();
                archive.DeleteBultan(ArchiveId, NewsId);
                return true;
            }
            catch { return false; }
        }
        [WebMethod]
        public static bool UpdateBultanArchiveIds(int bultanId, string newsIds)
        {
            var list = new Dictionary<int, int>();
            try
            {
                foreach (var str0 in newsIds.Split(';'))
                {
                    if (string.IsNullOrWhiteSpace(str0)) continue;
                    if (str0 == ";") continue;

                    var fld_newsId = Convert.ToInt32(str0.Split(':')[0]);
                    var txt_row_index = Convert.ToInt32(str0.Split(':')[1]);
                    list.Add(Convert.ToInt32(fld_newsId), Convert.ToInt32(txt_row_index));

                }
                var str = "";
                foreach (var item in list.OrderBy(t => t.Value))
                {


                    str += "," + item.Key + "";
                }
                if (!string.IsNullOrWhiteSpace(str))
                {
                    str = str.Substring(1);
                }
                if (!string.IsNullOrWhiteSpace(str))
                {

                    new Class_BultanArchive().UpdateBultanArchiveNews(bultanId, str);
                }
                return true;
            }
            catch { return false; }
        }
        [WebMethod]
        public static bool UpdateNewsOrders(string newsIds)
        {
            var list = new Dictionary<int, int>();
            try
            {
                foreach (var str0 in newsIds.Split(';'))
                {
                    if (string.IsNullOrWhiteSpace(str0)) continue;
                    if (str0 == ";") continue;

                    var fld_newsId = Convert.ToInt32(str0.Split(':')[0]);
                    var txt_row_index = Convert.ToInt32(str0.Split(':')[1]);
                    new Class_News().UpdateNewsOrder(fld_newsId, txt_row_index);

                }
                return true;
            }
            catch { return false; }
        }

        [WebMethod]
        public static bool UpdateInternationalNewsOrders(string newsIds)
        {
            var list = new Dictionary<int, int>();
            try
            {
                foreach (var str0 in newsIds.Split(';'))
                {
                    if (string.IsNullOrWhiteSpace(str0)) continue;
                    if (str0 == ";") continue;

                    var fld_newsId = Convert.ToInt32(str0.Split(':')[0]);
                    var txt_row_index = Convert.ToInt32(str0.Split(':')[1]);
                    new Class_News().UpdateNewsOrder(fld_newsId, txt_row_index);

                }
                return true;
            }
            catch { return false; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] ChartNewsSubjectValue(int type)
        {
            Class_Ado _clsAdo = new Class_Ado();
            List<Tbl_News_Type> allnews = (List<Tbl_News_Type>)HttpContext.Current.Session["AllNewsList"];

            List<Tbl_News_Type> compiledNews = (List<Tbl_News_Type>)HttpContext.Current.Session["CompiledNewsList"];
            HttpContext.Current.Session.Add("AllNewsList", allnews);
            HttpContext.Current.Session.Add("CompiledNewsList", compiledNews);

            List<ChartValue> values = new List<ChartValue>();

            foreach (Tbl_News_Type row in compiledNews)
            {
                int countKhabargozari = 0;
                int countRoozname = 0;
                if (row.SiteType == 1)
                    countKhabargozari++;
                else if (row.SiteType == 2)
                    countRoozname++;
                foreach (Tbl_News_Type item in allnews.Where(i => row.RelateListIds.Contains(i.NewsID)))
                {
                    if (item.SiteType == 1)
                        countKhabargozari++;
                    else if (item.SiteType == 2)
                        countRoozname++;
                }
                if (type == 1)
                    values.Add(new ChartValue { Name = row.NewsTitle, Value = countKhabargozari });
                else if (type == 2) values.Add(new ChartValue { Name = row.NewsTitle, Value = countRoozname });

            }


            return values.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ChartValue[] ChartNewsSubjectNewsValue(int type)
        {
            Class_Ado _clsAdo = new Class_Ado();
            List<Tbl_News_Type> allnews = (List<Tbl_News_Type>)HttpContext.Current.Session["AllNewsList"];

            List<Tbl_News_Type> compiledNews = (List<Tbl_News_Type>)HttpContext.Current.Session["CompiledNewsList"];


            List<ChartValue> values = new List<ChartValue>();

            foreach (Tbl_News_Type row in compiledNews)
            {
                
                int countAll = 0;
                int countMosbat = 0;
                int countManfi = 0;
                int countKhonsa = 0;

                countAll++;

                if (row.NewsValue == "1")
                    countMosbat++;
                else if (row.NewsValue == "2")
                    countManfi++;
                else if (row.NewsValue == "")
                    countKhonsa++;

                
                foreach (Tbl_News_Type item in allnews.Where(i => row.RelateListIds.Contains(i.NewsID)))
                {
                    countAll++;

                    if (row.NewsValue == "1")
                        countMosbat++;
                    else if (row.NewsValue == "2")
                        countManfi++;
                    else if (row.NewsValue == "")
                        countKhonsa++;
                }


                if (type == 1)
                {
                    values.Add(new ChartValue { Name = row.NewsTitle, Value = countMosbat });
                }
                else if (type == 2)
                {
                    values.Add(new ChartValue { Name = row.NewsTitle, Value = countManfi });
                }
                else if (type == 3)
                {
                    values.Add(new ChartValue { Name = row.NewsTitle, Value = countKhonsa });
                }
                //if (type == 1)
                //{
                //    values.Add(new ChartValue { Name = row.NewsTitle, Value = Convert.ToInt64(Math.Round(Convert.ToDecimal((countMosbat * 100) / countAll),0)) });
                //}
                //else if (type == 2)
                //{ values.Add(new ChartValue { Name = row.NewsTitle, Value = Convert.ToInt64(Math.Round(Convert.ToDecimal((countManfi * 100) / countAll), 0)) }); }
                //else if (type == 3)
                //{ values.Add(new ChartValue { Name = row.NewsTitle, Value = Convert.ToInt64(Math.Round(Convert.ToDecimal((countKhonsa * 100) / countAll), 0)) }); }

            }


            return values.ToArray();
        }


        public class ReportChartValue
        {
            public string Name { get; set; }
            public decimal Value { get; set; }
            public decimal SecondValue { get; set; }

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ReportChartValue[] ChartBoultanSiteType(int ArchiveId)
        {
            Class_Ado _clsAdo = new Class_Ado();
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
            };
            DataSet ds = Class_Ado.ExecuteDataset("", "p_News_boultan_GetChartdata",
                CommandType.StoredProcedure, sqlParams);

            DataTable dtResult = ds.Tables[0];
            List<ReportChartValue> values = new List<ReportChartValue>();
            foreach (DataRow row in dtResult.Rows)
            {
                string siteTypeTitle = "";
                if (row["SiteType"].ToString() == "1")
                    siteTypeTitle = "خبرگزاری";
                else if (row["SiteType"].ToString() == "2")
                    siteTypeTitle = "روزنامه";
                else if (row["SiteType"].ToString() == "3")
                    siteTypeTitle = "منابع فارسی بین الملل";
                else if (row["SiteType"].ToString() == "4")
                    siteTypeTitle = "منابع غیر فارسی خارجی";
                values.Add(new ReportChartValue { Name = siteTypeTitle, Value = Math.Round(decimal.Parse(row["NewsCount"].ToString()), 0) });
            }
            return values.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ReportChartValue[] ChartBoultanNews(int ArchiveId)
        {
            Class_Ado _clsAdo = new Class_Ado();
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
            };
            DataSet ds = Class_Ado.ExecuteDataset("", "p_News_boultan_GetChartdata",
                CommandType.StoredProcedure, sqlParams);

            DataTable dtResult = ds.Tables[1];
            List<ReportChartValue> values = new List<ReportChartValue>();
            foreach (DataRow row in dtResult.Rows)
            {
                values.Add(new ReportChartValue { Name = row["SiteTitle"].ToString(), Value = Math.Round(decimal.Parse(row["NewsCount"].ToString()), 0) });
            }
            return values.ToArray();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static ReportChartValue[] ChartBoultanNewsPaper(int ArchiveId)
        {
            Class_Ado _clsAdo = new Class_Ado();
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
            };
            DataSet ds = Class_Ado.ExecuteDataset("", "p_News_boultan_GetChartdata",
                CommandType.StoredProcedure, sqlParams);

            DataTable dtResult = ds.Tables[2];
            List<ReportChartValue> values = new List<ReportChartValue>();
            foreach (DataRow row in dtResult.Rows)
            {

                values.Add(new ReportChartValue { Name = row["SiteTitle"].ToString(), Value = Math.Round(decimal.Parse(row["NewsCount"].ToString()), 0) });
            }
            return values.ToArray();
        }
    }
}