using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using FarsiLibrary.Utils;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Data.OleDb;
using P_Art.Pages.P_Art.ModelNews;
using System.Globalization;
using System.Data.SqlClient;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class GroupedNews : System.Web.UI.Page
    {
        [ThemeableAttribute(false)]
        public virtual string GroupName { get; set; }

        private static DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        List<DomesticNews_Type> DomesticNewsList = new List<DomesticNews_Type>();
        Class_News _clsNews = new Class_News();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
        List<Tbl_RssKeywords> keywordList = new List<Tbl_RssKeywords>();
        List<Tbl_RssKeywords> keywordGroupList = new List<Tbl_RssKeywords>();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        //  List<Tbl_News_Type> allNewsList = new List<Tbl_News_Type>();
        private int RecordCount = 10000;
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!IsPostBack)
            {
                UserPanelList = Class_Layer.UserPanels();
                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }
                LoadData(0);
                LoadUserData();
                LoadNewsSource();

                LoadTemplate();
                DateTime dt = DateTime.Now.AddDays(-1);
                string date = _clsZm.MiladiToShamsi(dt.ToShortDateString());
                date = date.Substring(0, 10).Replace("/", "");

                var parmin = UserPanelList[0].Value + "";// (Class_Layer.UserPanels()[0].Value) + "";

                //  btn_generateGroupHtml.CommandArgument = parmin;
                btn_generateGroupHtml.Attributes.Add("data-parmin", parmin);

            }
        }
        private void LoadData(int siteType)
        {
            DomesticNewsList.Clear();

            // return;
            string strSearch = "";

            DataTable result = new DataTable();
            int fromDate = int.Parse(_clsZm.Today().Replace("/", ""));
            int toDate = fromDate;
            int siteId = 0;
            int time = 0;
            int today = 0;
#pragma warning disable CS0219 // The variable 'fromTimeZone' is assigned but its value is never used
            string fromTimeZone = "";
#pragma warning restore CS0219 // The variable 'fromTimeZone' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'toTimeZone' is assigned but its value is never used
            string toTimeZone = "";
#pragma warning restore CS0219 // The variable 'toTimeZone' is assigned but its value is never used
            Int64 fromDateTime = 0;
            Int64 toDateTime = 0;


            string newsIds = "";
            if (Request.QueryString["ftime"] != null)
            {
                txt_fromHour.Text = Request.QueryString["ftime"].ToString().Replace("-", ":");
            }
            if (Request.QueryString["ttime"] != null)
            {
                txt_toHour.Text = Request.QueryString["ttime"].ToString().Replace("-", ":");
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

            if (Request.QueryString["SiteId"] != null)
            {
                siteId = int.Parse(Request.QueryString["SiteId"].ToString());
                drp_NewsSource.SelectedValue = siteId.ToString();
            }
            if (Request.QueryString["time"] != null)
            {
                time = int.Parse(Request.QueryString["time"].ToString());

            }
            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                txt_search.Text = strSearch.Replace("|", "+");

            }
            if (Request.QueryString["recordcount"] != null)
            {
                RecordCount = int.Parse(Server.HtmlDecode(Request.QueryString["recordcount"].ToString()));
            }

            if (drp_NewsSource.SelectedValue == "-1")
            {
                siteId = -1;
            }
            else if (drp_NewsSource.SelectedValue == "-2")
            {
                siteId = -2;
            }
            Class_Keywords _clsKeyword = new Class_Keywords();
            var keywords = new List<Tbl_RssKeywords>();
            keywords = _clsKeyword.GetRssKeywordByPanelIds(Class_Layer.UserPanels());
            keywordList = keywords;

            if (Request.QueryString["bultanarchive"] != null)
            {
                Class_BultanArchive _clsBultan = new Class_BultanArchive();
                var archive = _clsBultan.GetBultanById(int.Parse(Request.QueryString["bultanarchive"]));
                if (archive != null)
                {
                    if (archive.SelectedNews != null)
                    {
                        if (archive.SelectedNews != "")
                        {
                            newsIds = archive.SelectedNews;
                        }
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(txt_fromDate.Text.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_fromHour.Text.Trim()))
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Text.Trim().Replace("/", "") + "0000");
                }
                else
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Text.Trim().Replace("/", "") + txt_fromHour.Text.Trim().Replace(":", ""));
                }

            }

            if (!string.IsNullOrWhiteSpace(txt_toDate.Text.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_toHour.Text.Trim()))
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Text.Trim().Replace("/", "") + "2400");
                }
                else
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Text.Trim().Replace("/", "") + txt_toHour.Text.Trim().Replace(":", ""));
                }

            }



            UserPanelList = Class_Layer.UserPanels();
            var parmin = UserPanelList[0].Value + "";
            DateTime fromDt = new DateTime(fromDate / 10000, (fromDate / 100) % 100, fromDate % 100, pc);
            TimeSpan diffrentDt = DateTime.Now.Subtract(fromDt);

            today = pc.GetYear(DateTime.Now) * 10000 + pc.GetMonth(DateTime.Now) * 100 + pc.GetDayOfMonth(DateTime.Now);

            if (diffrentDt.Days == 0)
            {
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.DomesticNewsTodayView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new DomesticNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            CreateDate = news.CreateDate,
                                            NewsLink = news.NewsLink,
                                            NewsDateIndex = news.NewsDateIndex,
                                            KeywordId = news.KeywordId,
                                            GroupId = news.GroupId,
                                            NewsLinkCRC = news.NewsLinkCRC,
                                            IsSelected = news.IsSelected,
                                            NewsType = news.NewsType,
                                            NewsTitleCRC = news.NewsTitleCRC,
                                            IsFeederNews = news.IsFeederNews,
                                            NewsGroupOrder = news.NewsGroupOrder,
                                            KeyIds = news.KeyIds,
                                            NewsTypeShow = news.NewsTypeShow,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
                                            SortOrder = news.SortOrder,
                                            NewsValue = news.NewsValue,
                                            SiteTitle = news.SiteTitle,
                                            SiteType = news.SiteType,
                                            KeywordName = news.KeywordName,
                                            GroupName = news.GroupName,
                                            Color = news.Color,
                                            GroupOrder = news.GroupOrder,
                                            OrderItem = news.OrderItem
                                        }).ToList();
                }
            }
            else if (diffrentDt.Days == 1)
            {
                List<DomesticNewsFromTwoDaysAgoView> DomesticNewsFromTwoDaysAgoView = new List<DomesticNewsFromTwoDaysAgoView>();
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.DomesticNewsFromTwoDaysAgoView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new DomesticNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            CreateDate = news.CreateDate,
                                            NewsLink = news.NewsLink,
                                            NewsDateIndex = news.NewsDateIndex,
                                            KeywordId = news.KeywordId,
                                            GroupId = news.GroupId,
                                            NewsLinkCRC = news.NewsLinkCRC,
                                            IsSelected = news.IsSelected,
                                            NewsType = news.NewsType,
                                            NewsTitleCRC = news.NewsTitleCRC,
                                            IsFeederNews = news.IsFeederNews,
                                            NewsGroupOrder = news.NewsGroupOrder,
                                            KeyIds = news.KeyIds,
                                            NewsTypeShow = news.NewsTypeShow,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
                                            SortOrder = news.SortOrder,
                                            NewsValue = news.NewsValue,
                                            SiteTitle = news.SiteTitle,
                                            SiteType = news.SiteType,
                                            KeywordName = news.KeywordName,
                                            GroupName = news.GroupName,
                                            Color = news.Color,
                                            GroupOrder = news.GroupOrder,
                                            OrderItem = news.OrderItem
                                        }).ToList();
                }
            }
            else if (diffrentDt.Days > 1 && diffrentDt.Days <= 5)
            {
                List<DomesticNewsFromFiveDaysAgoView> DomesticNewsFromFiveDaysAgoView = new List<DomesticNewsFromFiveDaysAgoView>();
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.DomesticNewsFromFiveDaysAgoView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new DomesticNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            CreateDate = news.CreateDate,
                                            NewsLink = news.NewsLink,
                                            NewsDateIndex = news.NewsDateIndex,
                                            KeywordId = news.KeywordId,
                                            GroupId = news.GroupId,
                                            NewsLinkCRC = news.NewsLinkCRC,
                                            IsSelected = news.IsSelected,
                                            NewsType = news.NewsType,
                                            NewsTitleCRC = news.NewsTitleCRC,
                                            IsFeederNews = news.IsFeederNews,
                                            NewsGroupOrder = news.NewsGroupOrder,
                                            KeyIds = news.KeyIds,
                                            NewsTypeShow = news.NewsTypeShow,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
                                            SortOrder = news.SortOrder,
                                            NewsValue = news.NewsValue,
                                            SiteTitle = news.SiteTitle,
                                            SiteType = news.SiteType,
                                            KeywordName = news.KeywordName,
                                            GroupName = news.GroupName,
                                            Color = news.Color,
                                            GroupOrder = news.GroupOrder,
                                            OrderItem = news.OrderItem
                                        }).ToList();
                }
            }
            else if (diffrentDt.Days > 5 && diffrentDt.Days <= 10)
            {
                List<DomesticNewsFromTenDaysAgoView> DomesticNewsFromTenDaysAgoView = new List<DomesticNewsFromTenDaysAgoView>();
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.DomesticNewsFromTenDaysAgoView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new DomesticNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            CreateDate = news.CreateDate,
                                            NewsLink = news.NewsLink,
                                            NewsDateIndex = news.NewsDateIndex,
                                            KeywordId = news.KeywordId,
                                            GroupId = news.GroupId,
                                            NewsLinkCRC = news.NewsLinkCRC,
                                            IsSelected = news.IsSelected,
                                            NewsType = news.NewsType,
                                            NewsTitleCRC = news.NewsTitleCRC,
                                            IsFeederNews = news.IsFeederNews,
                                            NewsGroupOrder = news.NewsGroupOrder,
                                            KeyIds = news.KeyIds,
                                            NewsTypeShow = news.NewsTypeShow,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
                                            SortOrder = news.SortOrder,
                                            NewsValue = news.NewsValue,
                                            SiteTitle = news.SiteTitle,
                                            SiteType = news.SiteType,
                                            KeywordName = news.KeywordName,
                                            GroupName = news.GroupName,
                                            Color = news.Color,
                                            GroupOrder = news.GroupOrder,
                                            OrderItem = news.OrderItem
                                        }).ToList();
                }
            }
            else if (diffrentDt.Days > 10 && diffrentDt.Days <= 31)
            {
                List<DomesticNewsFromOneMonthAgoView> DomesticNewsFromOneMonthAgoView = new List<DomesticNewsFromOneMonthAgoView>();
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.DomesticNewsFromOneMonthAgoView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new DomesticNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            CreateDate = news.CreateDate,
                                            NewsLink = news.NewsLink,
                                            NewsDateIndex = news.NewsDateIndex,
                                            KeywordId = news.KeywordId,
                                            GroupId = news.GroupId,
                                            NewsLinkCRC = news.NewsLinkCRC,
                                            IsSelected = news.IsSelected,
                                            NewsType = news.NewsType,
                                            NewsTitleCRC = news.NewsTitleCRC,
                                            IsFeederNews = news.IsFeederNews,
                                            NewsGroupOrder = news.NewsGroupOrder,
                                            KeyIds = news.KeyIds,
                                            NewsTypeShow = news.NewsTypeShow,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
                                            SortOrder = news.SortOrder,
                                            NewsValue = news.NewsValue,
                                            SiteTitle = news.SiteTitle,
                                            SiteType = news.SiteType,
                                            KeywordName = news.KeywordName,
                                            GroupName = news.GroupName,
                                            Color = news.Color,
                                            GroupOrder = news.GroupOrder,
                                            OrderItem = news.OrderItem
                                        }).ToList();
                }
            }
            else if (diffrentDt.Days > 31 && diffrentDt.Days <= 95)
            {
                List<DomesticNewsFromThreeMonthAgoView> DomesticNewsFromThreeMonthAgoView = new List<DomesticNewsFromThreeMonthAgoView>();
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.DomesticNewsFromThreeMonthAgoView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new DomesticNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            CreateDate = news.CreateDate,
                                            NewsLink = news.NewsLink,
                                            NewsDateIndex = news.NewsDateIndex,
                                            KeywordId = news.KeywordId,
                                            GroupId = news.GroupId,
                                            NewsLinkCRC = news.NewsLinkCRC,
                                            IsSelected = news.IsSelected,
                                            NewsType = news.NewsType,
                                            NewsTitleCRC = news.NewsTitleCRC,
                                            IsFeederNews = news.IsFeederNews,
                                            NewsGroupOrder = news.NewsGroupOrder,
                                            KeyIds = news.KeyIds,
                                            NewsTypeShow = news.NewsTypeShow,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
                                            SortOrder = news.SortOrder,
                                            NewsValue = news.NewsValue,
                                            SiteTitle = news.SiteTitle,
                                            SiteType = news.SiteType,
                                            KeywordName = news.KeywordName,
                                            GroupName = news.GroupName,
                                            Color = news.Color,
                                            GroupOrder = news.GroupOrder,
                                            OrderItem = news.OrderItem
                                        }).ToList();
                }
            }
            else
            {
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.DomesticNewsView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new DomesticNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            CreateDate = news.CreateDate,
                                            NewsLink = news.NewsLink,
                                            NewsDateIndex = news.NewsDateIndex,
                                            KeywordId = news.KeywordId,
                                            GroupId = news.GroupId,
                                            NewsLinkCRC = news.NewsLinkCRC,
                                            IsSelected = news.IsSelected,
                                            NewsType = news.NewsType,
                                            NewsTitleCRC = news.NewsTitleCRC,
                                            IsFeederNews = news.IsFeederNews,
                                            NewsGroupOrder = news.NewsGroupOrder,
                                            KeyIds = news.KeyIds,
                                            NewsTypeShow = news.NewsTypeShow,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
                                            SortOrder = news.SortOrder,
                                            NewsValue = news.NewsValue,
                                            SiteTitle = news.SiteTitle,
                                            SiteType = news.SiteType,
                                            KeywordName = news.KeywordName,
                                            GroupName = news.GroupName,
                                            Color = news.Color,
                                            GroupOrder = news.GroupOrder,
                                            OrderItem = news.OrderItem
                                        }).ToList();
                }
            }


            if (DomesticNewsList.Count == 0)
            {
                Session["LastNewsId"] = "0";
            }
            else
            {

                Session["LastNewsId"] = DomesticNewsList.FirstOrDefault().NewsID;
            }


            LoadGroups(DomesticNewsList);

        }

        private void LoadGroups(List<DomesticNews_Type> dt)
        {

            Class_Keywords _cls = new Class_Keywords();

            var keyWords = keywordList.GroupBy(t => t.KeyId).Select(g => g.First()).ToList().Where(t => dt.Any(n => n.KeywordId == t.KeyId)).ToList();

            var parminIds = UserPanelList;// (Class_Layer.UserPanels());


            rpt_Groups.DataSource = keyWords;
            rpt_Groups.DataBind();



            var keyGroups = keywordList.GroupBy(k => k.GroupName).Select(k => k.FirstOrDefault()).OrderBy(k => k.GroupOrder).ToList();



            rptGroupNewKeyword.DataSource = keyGroups;
            rptGroupNewKeyword.DataBind();



            rbtGroups.Items.Clear();
            foreach (var item in keyGroups)
            {
                if (string.IsNullOrWhiteSpace(item.GroupName)) continue;

                rbtGroups.Items.Add(new ListItem()
                {
                    Text = "(" + item.GroupOrder + ")" + item.GroupName,
                    Value = item.GroupOrder + ""
                });
            }

        }


        private void LoadNewsSource()
        {
            drp_NewsSource.Items.Clear();
            ListItem newItem = new ListItem();
            newItem.Text = "کلیه منابع";
            newItem.Value = "0";

            drp_NewsSource.Items.Add(newItem);

            newItem = new ListItem();
            newItem.Text = "کلیه خبرگزاری ها";
            newItem.Value = "-1";
            drp_NewsSource.Items.Add(newItem);

            newItem = new ListItem();
            newItem.Text = "کلیه روزنامه ها";
            newItem.Value = "-2";
            drp_NewsSource.Items.Add(newItem);


            Class_Sites _clsSite = new Class_Sites();
            Class_Ado _clsAdo = new Class_Ado();

            UserPanelList = Class_Layer.UserPanels();
            var parmin = UserPanelList[0].Value + "";

            var result = _db.GetSitesFromParmin(int.Parse(parmin)).ToList();
            ;
            foreach (var item in result)
            {
                newItem = new ListItem();
                newItem.Text = item.SiteTitle.Trim();
                newItem.Value = item.SiteID.ToString();
                drp_NewsSource.Items.Add(newItem);
            }

        }
        private void LoadUserData()
        {
            var currentUser = Class_Layer.CurrentUser();
            //Load ResourceSortingOrder

            if (!string.IsNullOrWhiteSpace(currentUser.ResourceSortingOrder))
            {
                List<int> siteIds = new List<int>();
                foreach (string site in currentUser.ResourceSortingOrder.Split(','))
                {
                    if (site == "") continue;
                    try
                    {
                        siteIds.Add(int.Parse(site));
                    }
                    catch
                    {
                        continue;
                    }
                }
                hdfUserCustomSort.Value = currentUser.ResourceSortingOrder;
                var siteData = _clsSite.SelectResourceSortingOrder(siteIds);
                rptSelectedSiteSort.DataSource = siteData;
                rptSelectedSiteSort.DataBind();
            }


            hdfUserID.Value = currentUser.MemberID + "";
        }
        private void LoadTemplate()
        {
            Class_Panels _cls = new Class_Panels();
            List<int> ids = new List<int>();
            ListItem newItem = new ListItem();
            var parmin = _cls.GetParminById(int.Parse(UserPanelList[0].Value.ToString()));
            if (parmin.BultanId == null)
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = "قالب جدید";
                newItem1.Value = "58";
                drp_template.Items.Add(newItem);


                newItem.Text = "قالب اصلی";
                newItem.Value = "40";
                drp_template.Items.Add(newItem);
                return;
            }
            else
            {
                foreach (var id in parmin.BultanId.Split(','))
                {
                    ids.Add(int.Parse(id.ToString()));
                }
                var files = _cls.GetBultanFiles(ids);
                foreach (var file in files)
                {
                    newItem = new ListItem();
                    newItem.Text = file.Title;
                    newItem.Value = file.BultanID.ToString();
                    drp_template.Items.Add(newItem);
                }
            }
        }
        protected void rpt_Groups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            HtmlGenericControl _div = e.Item.FindControl("group_item") as HtmlGenericControl;
            if (_div == null) return;
            CheckBox cbx = e.Item.FindControl("check_selected_group") as CheckBox;
            if (cbx != null)
            {
                cbx.Attributes.Add("onclick", "sortArticleIndex1();");
            }
            HtmlGenericControl color_span = e.Item.FindControl("color_span") as HtmlGenericControl;

            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            color_span.Style.Add("background-color", fld_color.Value.Trim());



        }
        public static string ChangeIcon(string sitetype)
        {

            if (sitetype == "1")
                return "fas fa-rss-square";
            else
                return "far fa-newspaper";

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
                        //  return Class_Static.GetOnTimeDate(dateTime);
                    }
                    catch
                    {
                        dt = (newsDtTime);
                        //return Class_Static.GetOnTimeDate();



                    }

                }
                else
                {
                    // return Class_Static.GetOnTimeDate(Convert.ToDateTime(ddate));
                    dt = Convert.ToDateTime(newsDtTime);
                }


                return Class_Static.GetOnTimeDate(dt);
            }
            catch
            {
                return "";

            }


        }

        protected void rptGroupNewKeyword_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Tbl_RssKeywords data = (Tbl_RssKeywords)e.Item.DataItem;
            Repeater rptGroupNewsList = e.Item.FindControl("rptGroupNewsList") as Repeater;
            if (data != null)
            {
                if (DomesticNewsList.Count != 0)
                {
                    List<Tbl_RssKeywords> keys = (new Class_News()).GetKeywords(data.GroupName);
                    List<int> keyIds = new List<int>();
                    foreach (var ii in keys)
                    {
                        keyIds.Add(ii.KeyId);
                    }
                    rptGroupNewsList.DataSource = DomesticNewsList.Where(i => i.GroupOrder == data.GroupOrder).OrderBy(t => t.OrderItem).ThenByDescending(d => d.NewsDateIndex).ThenByDescending(d => d.NewsTime).ToList();
                    rptGroupNewsList.DataBind();
                }
            }
        }
        protected void rptGroupNewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;
            DomesticNews_Type newsData = (DomesticNews_Type)e.Item.DataItem;

            //var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                var res = GenerateTags(keywordList, newsData.NewsDateIndex + "", newsData.KeyIds);
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }

            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;


            TextBox txtOrder = e.Item.FindControl("txt_row_index") as TextBox;

            var currentUser = Class_Layer.CurrentUser();

            if (currentUser.AllowSaveNews == false)
            {
                check.Checked = false;
            }
            else if (currentUser.SavedNewsIds != null && currentUser.SavedNewsIds.Contains("," + fld_newsId.Value + ","))
            {
                check.Checked = true;
            }
            else
            {
                check.Checked = false;
            }

            try
            {

                if (!string.IsNullOrWhiteSpace(currentUser.SavedOrderIds))
                {
                    var orderIndex = currentUser.SavedOrderIds.IndexOf("," + fld_newsId.Value + ":");
                    if (orderIndex > -1)
                    {
                        var orderIndex2 = currentUser.SavedOrderIds.Substring(orderIndex + 1).IndexOf(",");
                        txtOrder.Text = currentUser.SavedOrderIds.Substring(orderIndex + 1, orderIndex2).Split(':')[1];
                    }
                    else
                    {
                        txtOrder.Text = "";
                    }
                }
                else
                {
                    txtOrder.Text = "";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }

            HtmlGenericControl _Color_span = e.Item.FindControl("ColorSpan") as HtmlGenericControl;
            if (_Color_span == null) return;
            _Color_span.Style.Add("background-color", fld_color.Value.Trim());
        }

        private Tuple<string, string> GenerateTags(List<Tbl_RssKeywords> keywords, string newsDateIndex, string keyIds)
        {

            string findKeywords = "";

            if (string.IsNullOrWhiteSpace(keyIds))
                return new Tuple<string, string>("", keyIds);

            var finalKeyIds = "";
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    var selKeyId = Convert.ToInt32(keySpil);
                    var key = keywords.FirstOrDefault(t => t.KeyId == selKeyId);
                    if (key == null) continue;

                    finalKeyIds += "," + key.KeyId + ",";

                    findKeywords += "<a data-keyid='" + key.KeyId + "' data-color='" + key.Color + "' data-text='" + key.KeywordName + "' title='جهت نمایش موارد مشابه این کلید واژه کلیک کنید' href='/NewsList/?fromDate=" + newsDateIndex + "&toDate=" + newsDateIndex + "&keyword=" + Server.HtmlEncode(key.KeywordName.Replace("+", "&")) + "&recordCount=10000000' target='_blank'>" + key.KeywordName + "</a>";
                }
                catch
                {
                    continue;
                }
            }


            return new Tuple<string, string>(Class_Static.PersianAlpha(findKeywords), finalKeyIds);
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
            if (drp_NewsSource.SelectedItem.Value != "0")
            {
                url += "SiteId=" + drp_NewsSource.SelectedItem.Value + "&";
            }
            if (txt_search.Text.Trim() != "")
            {
                url += "keyword=" + Server.HtmlEncode(txt_search.Text.Trim().Replace("+", "|")) + "&";
            }
            if (txt_fromHour.Text != "" && txt_toHour.Text != "")
            {
                url += "ftime=" + Server.HtmlEncode(txt_fromHour.Text.Trim().Replace(":", "-")) + "&";
                url += "ttime=" + Server.HtmlEncode(txt_toHour.Text.Trim().Replace(":", "-")) + "&";
            }
            url += "recordCount=10000000" + "&";
            //if (txt_fromHour.Text != "00:00")
            //{
            //    url += "fromtimezone=" + txt_fromHour.Text + "&";
            //}
            //if (txt_toHour.Text != "00:00")
            //{
            //    url += "totimezone=" + txt_toHour.Text + "&";
            //}
            url = url.Substring(0, url.Length - 1);

            Response.Redirect("/NewsList/?" + url);



        }
        public string SetCustomSort(string siteId)
        {
            if (!string.IsNullOrWhiteSpace(hdfUserCustomSort.Value))
            {
                var keyId = Convert.ToInt32(siteId);
                List<int> siteIds = new List<int>();

                foreach (string site in hdfUserCustomSort.Value.Split(','))
                {
                    if (site == "") continue;
                    try
                    {
                        siteIds.Add(int.Parse(site));
                    }
                    catch
                    {
                        continue;
                    }
                }
                //  var sel = siteIds.FirstOrDefault(t => t == keyId);
                if (!siteIds.Any(t => t == keyId))
                {
                    return "1000";
                }
                else
                {
                    return siteIds.IndexOf(keyId) + "";
                }
            }
            else
            {
                return "1000";
            }
        }
        public string GetNewsFullDateIndex(string newsDate, string createDate, string newsTime, string siteType)
        {
            if (siteType == "2")
            {
                //return zm.MiladiToShamsi(ddate.ToString()).Substring(0, 10);
                newsTime = "0000";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(newsTime))
                {
                    newsTime = "0000";
                }
                else
                {
                    newsTime = Class_Static.GetAbsoluteTime(newsTime).Replace(":", "");
                }
            }
            var dateIndex = "";
            if (string.IsNullOrWhiteSpace(newsDate))
            {
                var dt = DateTime.Parse(createDate);
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                dateIndex = pc.GetYear(dt) + "" + Class_Static.RoundTenNum(pc.GetMonth(dt)) + "" + Class_Static.RoundTenNum(pc.GetDayOfMonth(dt));


            }
            else
            {
                dateIndex = newsDate.Replace("/", "");
            }
            return dateIndex + "" + newsTime;
        }
        public static string NewsRateOpacity(object newsValue, string MustValue)
        {
            if (newsValue == null)
            {
                if (MustValue == "0")
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.1";
                }
            }
            else
            {
                if (newsValue.ToString() == MustValue)
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.1";
                }
            }
        }
        public string mirrorDate(string NewsDate)
        {
            var date = NewsDate.Split('/');

            var result = date[2] + "/" + date[1] + "/" + date[0];
            return result;
        }
    }
}