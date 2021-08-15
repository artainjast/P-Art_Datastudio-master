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
using System.Web.Services;
using System.Threading;
using System.Web.Script.Services;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class LiveNews : System.Web.UI.Page
    {
        [ThemeableAttribute(false)]
        public virtual string GroupName { get; set; }

        private static DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        List<LiveNews_Type> DomesticNewsList = new List<LiveNews_Type>();
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

        Class_News _clsNews = new Class_News();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
        List<Tbl_News_Type> GroupNewsList = new List<Tbl_News_Type>();
        List<Tbl_RssKeywords> keywordList = new List<Tbl_RssKeywords>();
        List<Tbl_RssKeywords> keywordGroupList = new List<Tbl_RssKeywords>();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        //  List<Tbl_News_Type> allNewsList = new List<Tbl_News_Type>();
        private int RecordCount = 10000;
#pragma warning disable CS0414 // The field 'LiveNews.LiveNewsFlag' is assigned but its value is never used
        static bool LiveNewsFlag = false;
#pragma warning restore CS0414 // The field 'LiveNews.LiveNewsFlag' is assigned but its value is never used

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
                LoadNewsSource();
                LoadData(0);
                DateTime dt = DateTime.Now.AddDays(-1);
                string date = _clsZm.MiladiToShamsi(dt.ToShortDateString());
                date = date.Substring(0, 10).Replace("/", "");
               
                UserPanelList = Class_Layer.UserPanels();
                var parmin = UserPanelList[0].Value + "";
                NewsIdParminId.Value = parmin;
            }
        }

        public string IsSelectedItem(object isSelected)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(isSelected.ToString()))
                    return "";

                var res = Convert.ToBoolean(isSelected);
                if (!res)
                    return "";
                else
                    return "checked";
            }
            catch
            {
                return "";
            }
        }
        public string GetNewsSite(int siteId)
        {
            try
            {

                Class_Sites cls = new Class_Sites();
                //return "";
                return cls.GetSiteById(siteId).SiteTitle;
            }
            catch
            {
                return "";
            }

        }
        public string GetNewsDate(string NewsDate)
        {
            try
            {
                PersianDate pDate = PersianDate.Parse(NewsDate);

                return pDate.ToString("D");
            }
            catch
            {
                return "";
            }
        }
        public string IsRead(bool IsRead)
        {
            try
            {

                if (IsRead == false)
                {
                    return "<figcaption>جدید</figcaption>";
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }

        }
        public bool IsSelection(string newsId)
        {

            return false;

#pragma warning disable CS0162 // Unreachable code detected
            if (Session["NewsSelection"] == null)
#pragma warning restore CS0162 // Unreachable code detected
            {
                return true;

            }


            if (Session["NewsSelection"].ToString().IndexOf("," + newsId.ToString() + ",") > -1)
            {
                return false;
            }
            else
            {
                return true;
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
        public static string ChangeIcon(string sitetype)
        {

            if (sitetype == "1")
                return "fas fa-rss-square";
            else
                return "far fa-newspaper";

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


        protected void KeywordsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            HtmlGenericControl _div = e.Item.FindControl("KeywordGroup") as HtmlGenericControl;
            if (_div == null) return;
            CheckBox cbx = e.Item.FindControl("SelectCheckBox") as CheckBox;
            if (cbx != null)
            {
                cbx.Attributes.Add("onclick", "sortArticleIndex1();");
            }
            HtmlGenericControl color_span = e.Item.FindControl("CheckBoxColor") as HtmlGenericControl;

            HiddenField fld_color = e.Item.FindControl("KeywordHiddenFieldColor") as HiddenField;
            color_span.Style.Add("background-color", fld_color.Value.Trim());



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
        public override void VerifyRenderingInServerForm(Control control)
        {


        }

        public string mirrorDate(string NewsDate)
        {
            var date = NewsDate.Split('/');

            var result = date[2] + "/" + date[1] + "/" + date[0];
            return result;
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


        private void LoadData(int siteType)
        {

            // return;
            string strSearch = "";
            DomesticNewsList.Clear();
            List<Tbl_News_Type> GroupNewsList = new List<Tbl_News_Type>();
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
                    DomesticNewsList = (from news in _db.LiveTvNewsListView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new LiveNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            NewsLead = news.NewsLead,
                                            CreateDate = news.CreateDate,
                                            KeywordId = news.KeywordId,
                                            NewsType = news.NewsType,
                                            KeyIds = news.KeyIds,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
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

            else if (diffrentDt.Days > 0 && diffrentDt.Days < 6)
            {
                List<LiveNews_Type> DomesticNewsView = new List<LiveNews_Type>();
                if (fromDateTime != 0 && toDateTime != 0)
                {
                    DomesticNewsList = (from news in _db.LiveTvNewsListView
                                        where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime
                                        select new LiveNews_Type
                                        {
                                            NewsID = news.NewsID,
                                            ParminId = news.ParminId,
                                            SiteID = news.SiteID,
                                            NewsDate = news.NewsDate,
                                            NewsTime = news.NewsTime,
                                            NewsTitle = news.NewsTitle,
                                            NewsLead = news.NewsLead,
                                            CreateDate = news.CreateDate,
                                            KeywordId = news.KeywordId,
                                            NewsType = news.NewsType,
                                            KeyIds = news.KeyIds,
                                            NewsDateTimeIndex = news.NewsDateTimeIndex,
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

            // check Search Parameters 

            if (siteId != 0)
            {
                DomesticNewsList = DomesticNewsList.Where(n => n.SiteID == siteId).Select(n => n).ToList();
            }

            if (!string.IsNullOrEmpty(strSearch))
            {
                strSearch = Class_Static.ArabicAlpha(strSearch);



                List<int> LiveNewsTVIdList = new List<int>();
                List<int> SearchResultNewsId = new List<int>();

                LiveNewsTVIdList = DomesticNewsList.Select(n => n.NewsID).ToList();

                SearchResultNewsId = SearchPhraseInNews(LiveNewsTVIdList, strSearch);

                DomesticNewsList = DomesticNewsList.Where(n => SearchResultNewsId.Contains(n.NewsID)).Select(n => n).ToList();
            }


            news_list.DataSource = DomesticNewsList.OrderByDescending(n => n.NewsDateTimeIndex);
            news_list.DataBind();


            var keyWords = keywordList.GroupBy(t => t.KeyId).Select(g => g.First()).ToList().Where(t => DomesticNewsList.Any(n => n.KeywordId == t.KeyId)).ToList();

            var parminIds = UserPanelList;// (Class_Layer.UserPanels());


            rpt_Groups.DataSource = keyWords;
            rpt_Groups.DataBind();


            var allKeyword = _db.Tbl_RssKeywords.Where(k => parminIds.Contains(k.PanelId) && k.Active == true).ToList();

            KeywordsRepeater.DataSource = allKeyword;
            KeywordsRepeater.DataBind();


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

        private List<int> SearchPhraseInNews(List<int> newsIds, string searchText)
        {
            List<int> result = new List<int>();
            string str1 = "";
            string str2 = "";
            string str3 = "";

            if (searchText.Contains("|"))
            {
                var SearchParameterList = searchText.Split('|');


                if (SearchParameterList.Count() == 2)
                {
                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    List<int> FirstSearchResult = new List<int>();

                    FirstSearchResult = _db.Tbl_News.Where(n => newsIds.Contains(n.NewsID) && (n.NewsTitle.Contains(str1) || n.NewsLead.Contains(str1) || n.NewsBody.Contains(str1))).Select(n => n.NewsID).ToList();
                    result = _db.Tbl_News.Where(n => FirstSearchResult.Contains(n.NewsID) && (n.NewsTitle.Contains(str2) || n.NewsLead.Contains(str2) || n.NewsBody.Contains(str2))).Select(n => n.NewsID).ToList();


                }
                else if (SearchParameterList.Count() == 3)
                {

                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    str3 = SearchParameterList[2];


                    List<int> FirstSearchResult = new List<int>();
                    List<int> SecondSearchResult = new List<int>();

                    FirstSearchResult = _db.Tbl_News.Where(n => newsIds.Contains(n.NewsID) && (n.NewsTitle.Contains(str1) || n.NewsLead.Contains(str1) || n.NewsBody.Contains(str1))).Select(n => n.NewsID).ToList();
                    SecondSearchResult = _db.Tbl_News.Where(n => FirstSearchResult.Contains(n.NewsID) && (n.NewsTitle.Contains(str2) || n.NewsLead.Contains(str2) || n.NewsBody.Contains(str2))).Select(n => n.NewsID).ToList();
                    result = _db.Tbl_News.Where(n => SecondSearchResult.Contains(n.NewsID) && (n.NewsTitle.Contains(str3) || n.NewsLead.Contains(str3) || n.NewsBody.Contains(str3))).Select(n => n.NewsID).ToList();

                }

            }
            else
            {
                result = _db.Tbl_News.Where(n => newsIds.Contains(n.NewsID) && (n.NewsTitle.Contains(searchText) || n.NewsLead.Contains(searchText) || n.NewsBody.Contains(searchText))).Select(n => n.NewsID).ToList();
            }

            return result;
        }

        private List<int> GenerateRelatedList(int newsId, List<Tbl_NewsRelate> RelatedTable)
        {
            List<int> Result = new List<int>();
            foreach (var item in RelatedTable.Where(n => n.NewsId == newsId).Select(r => r.RelateNewsId))
            {
                if (item != null)
                {
                    Result.Add((int)item);
                }

            }
            return Result;
        }
        private string GenerateListToString(List<int> List)
        {
            StringBuilder Result = new StringBuilder();
            if (List.Count > 0)
            {
                foreach (var item in List)
                {
                    Result.Append(item + ",");
                }
                return Result.ToString().Substring(0, Result.Length - 1);
            }
            else
            {
                return "";
            }
        }

        protected void news_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            HtmlGenericControl _div = e.Item.FindControl("post") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;

            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;

            //   PlaceHolder pc_DelNews = e.Item.FindControl("pc_DelNews") as PlaceHolder;

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
            if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            {
                //  pc_DelNews.Visible = true;
                //

            }
            else
            {
                //   pc_DelNews.Visible = false;
            }



            // news Index
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



            //if (fld_isSelected.Value == "True")
            //{
            //    check.Checked = true;
            //}
            //else
            //{
            //check.Checked = false;
            //}
            //  ClientScript.RegisterStartupScript(GetType(), "retrieveRelatedData", "retrieveRelatedData(" + fld_newsId + "," + allNewsList + ");", true);

            //_div.Style.Add("background-color", fld_color.Value.Trim());

            HtmlGenericControl _Color_span = e.Item.FindControl("ColorSpan") as HtmlGenericControl;
            if (_Color_span == null) return;
            _Color_span.Style.Add("background-color", fld_color.Value.Trim());
        }
        protected void rptGroupNewKeyword_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (GroupNewsList == null || GroupNewsList.Count == 0)
            {
                GroupNewsList = (List<Tbl_News_Type>)Session["GroupNewsList"];

            }
            Tbl_RssKeywords data = (Tbl_RssKeywords)e.Item.DataItem;
            Repeater rptGroupNewsList = e.Item.FindControl("rptGroupNewsList") as Repeater;
            if (data != null)
            {
                if (GroupNewsList.Count != 0)
                {

                    rptGroupNewsList.DataSource = GroupNewsList.Where(n => n.NewsKeyGroupsOrder == data.GroupOrder).OrderBy(t => t.OrderItem).ThenByDescending(d => d.NewsDateIndex).ThenByDescending(d => d.NewsTime).ToList();
                    rptGroupNewsList.DataBind();
                }
            }
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

            Response.Redirect("/LiveNews/?" + url);



        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static LiveNewsClassType[] ShowLiveNews(string NewsIds)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            List<LiveNewsClassType> LiveNewsList = new List<LiveNewsClassType>();
            Class_Zaman DateTimeStaticClass = new Class_Zaman();

            LiveNewsFlag = true;

            if (!string.IsNullOrEmpty(NewsIds))
            {
                try
                {
                    NewsIds = NewsIds.Replace(",,", ",");
                    NewsIds = NewsIds.Replace(",undefined,", ",");
                    NewsIds = NewsIds.Replace(",,", ",");


                    if (NewsIds.Substring(0, 1) == ",") NewsIds = NewsIds.Substring(1, NewsIds.Length - 1);
                    if (NewsIds.Substring(NewsIds.Length - 1, 1) == ",") NewsIds = NewsIds.Substring(0, NewsIds.Length - 1);

                    NewsIds = NewsIds.Replace(",,", ",");

                    List<int> NewsIdList = new List<int>();

                    foreach (var n in NewsIds.Split(','))
                    {
                        try
                        {
                            NewsIdList.Add(int.Parse(n));
                        }
                        catch
                        {

                        }
                    }
                    
                    List<LiveTvNewsListView> SelectedLiveNews = db.LiveTvNewsListView.Where(n => NewsIdList.Contains(n.NewsID)).OrderBy(n => n.NewsDateTimeIndex).ToList();


                    foreach (var News in SelectedLiveNews)
                    {
                        LiveNewsList.Add(new LiveNewsClassType
                        {
                            MetaData = "📆 " + Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha(DateTimeStaticClass.GetNewsDate(News.NewsDate) + "\t  🕘 ساعت: " + News.NewsTime)),
                            Title = Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha("🔸 " + News.NewsTitle)),
                            Lead = Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha("🔹 " + News.NewsLead)),
                            SiteName = Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha("📰 نام منبع: " + News.SiteTitle))
                            
                        });
                    }

                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                { }

                
            }

            return LiveNewsList.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static LiveNewsClassType[] ShowLiveNewsByKeyIDs(string parmin, string KeyIds)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            List<LiveNewsClassType> LiveNewsList = new List<LiveNewsClassType>();
            Class_Zaman DateTimeStaticClass = new Class_Zaman();

            LiveNewsFlag = true;

            if (!string.IsNullOrEmpty(KeyIds))
            {
                try
                {
                    KeyIds = KeyIds.Replace(",,", ",");
                    KeyIds = KeyIds.Replace(",undefined,", ",");
                    KeyIds = KeyIds.Replace(",,", ",");


                    if (KeyIds.Substring(0, 1) == ",") KeyIds = KeyIds.Substring(1, KeyIds.Length - 1);
                    if (KeyIds.Substring(KeyIds.Length - 1, 1) == ",") KeyIds = KeyIds.Substring(0, KeyIds.Length - 1);

                    KeyIds = KeyIds.Replace(",,", ",");

                    List<string> keyIdList = new List<string>();

                    foreach (var k in KeyIds.Split(','))
                    {
                        try
                        {
                            keyIdList.Add(k);
                        }
                        catch
                        {

                        }
                    }
                    long CurrentDate = long.Parse(DateTimeStaticClass.Today().Replace("/", "") + "0000");
                    int Parmin = int.Parse(parmin);
                    List<LiveTvNewsListView> SelectedLiveNews = new List<LiveTvNewsListView>();
                    foreach (var keyID in keyIdList)
                    {
                        SelectedLiveNews.AddRange(db.LiveTvNewsListView.Where(k => k.ParminId == Parmin && k.NewsDateTimeIndex >= CurrentDate && k.KeyIds.Contains(keyID)).ToList());
                    }
                                     
                    
                    foreach (var News in SelectedLiveNews.Distinct().OrderByDescending(n => n.NewsDateTimeIndex).Take(20).OrderBy(n => n.NewsDateTimeIndex))
                    {
                        LiveNewsList.Add(new LiveNewsClassType
                        {
                            MetaData = "📆 " + Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha(DateTimeStaticClass.GetNewsDate(News.NewsDate) + "\t  🕘 ساعت: " + News.NewsTime)),
                            Title = Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha("🔸 " + News.NewsTitle)),
                            Lead = Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha("🔹 " + News.NewsLead)),
                            SiteName = Class_Static.EnglishToPersianNumber(Class_Static.PersianAlpha("📰 نام منبع: " + News.SiteTitle))

                        });
                    }


                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                { }


            }

            return LiveNewsList.ToArray();

        }



    }

    [Serializable]
    public class LiveNewsClassType {
        public string MetaData { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string SiteName { get; set; }
    }

    [Serializable]
    public class Keyword {
        public int KeywordID { get; set; }
        public string KeywordTitle { get; set; }
    }
}