using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNewMeda;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System.Text;
using System.Globalization;
using System.Web.Services;
using HtmlAgilityPack;
using System.Data;
using P_Art.Pages.P_Art.ModelNews;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class NewMediaNewsList : System.Web.UI.Page
    {
        private static DB_RubikaEntities _dbRubika = new DB_RubikaEntities();
        private static DB_NewsCenterEntities _dbDDn = new DB_NewsCenterEntities();
        Class_Zaman _clsZm = new Class_Zaman();
        // public Tbl_Parmin ParminTable = new Tbl_Parmin();
        List<int?> UserPanelList = new List<int?>();
        int memberId = 0;
        int userPanelId = 0;

        string strSearch = "";

        int fromDate = 0;
        int toDate = 0;
        int pageSize = 25;
        int pageIndex = 1;
        int siteGroup = 0;
        int siteType = 0;
        PagingNewMediaNewsList_Type pagingNews = new PagingNewMediaNewsList_Type();

        int time = 0;
        Int64 fromDateTime = 0;
        Int64 toDateTime = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            if (!IsPostBack)
            {

                memberId = Class_Layer.CurrentUser().MemberID;

                userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

                LoadData();

                PrepareNews(fromDateTime, toDateTime, strSearch, pageSize, pageIndex, siteGroup , siteType);

                GeneratePaginationButton(pagingNews.TotalNewsCount, pageSize, pageIndex);

                LoadTemplate();

                GetCompletedData();



                GetSaveAndBultanFlag();

                GenerateNewsList(pagingNews);

            }
        }
        private void LoadData()
        {
            // return;

            fromDate = int.Parse(_clsZm.Today().Replace("/", ""));
            toDate = fromDate;

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


            if (Request.QueryString["time"] != null)
            {
                time = int.Parse(Request.QueryString["time"].ToString());

            }
            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                //////////////// //    txt_search.Text = strSearch.Replace("|", "+");

            }

            //////////////if (Request.QueryString["st"] != null)
            //////////////{
            //////////////    storageTypeDropDownList.SelectedValue = Server.HtmlDecode(Request.QueryString["st"].ToString());
            //////////////    StorageType = Convert.ToInt32(storageTypeDropDownList.SelectedValue);
            //////////////}
            ///
            if (Request.QueryString["g"] != null)
            {
                ddlSiteGroup.SelectedValue = Server.HtmlDecode(Request.QueryString["g"].ToString());
                siteGroup = Convert.ToInt32(ddlSiteGroup.SelectedValue);
            }
            if (Request.QueryString["st"] != null)
            {
                ddlSiteType.SelectedValue = Server.HtmlDecode(Request.QueryString["st"].ToString());
                siteType = Convert.ToInt32(ddlSiteType.SelectedValue);
            }


            if (Request.QueryString["index"] != null)
            {
                PageIndexHiddenField.Value = Server.HtmlDecode(Request.QueryString["index"].ToString());
                pageIndex = int.Parse(PageIndexHiddenField.Value);
            }


            if (Request.QueryString["size"] != null)
            {
                PageSizeDropDownList.SelectedValue = Server.HtmlDecode(Request.QueryString["size"].ToString());
                pageSize = int.Parse(PageSizeDropDownList.SelectedValue) < 100 ? int.Parse(PageSizeDropDownList.SelectedValue) : 100;
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

        }

        private void PrepareNews(long fromDateTimeIndex, long toDateTimeIndex, string searchString, int pageSize, int pageIndex, int SiteGroup, int SiteType)
        {

            List<int> newsIdtList = new List<int>();
            List<int> newsIdResultList = new List<int>();

            List<int> siteIds = new List<int>();
            if (SiteType != 0)
                siteIds = _dbRubika.Tbl_Sites.Where(i=>i.SiteType == SiteType).Select(n => n.SiteId).Distinct().ToList();

            PagingNewMediaNewsList_Type Result = new PagingNewMediaNewsList_Type();
            IQueryable<ModelNewMeda.Tbl_News> query;
            if (SiteType != 0)
            {
                if (SiteGroup == 0)
                    query = _dbRubika.Tbl_News.Where(n => n.NewsDateTimeIndex >= fromDateTimeIndex && n.NewsDateTimeIndex <= toDateTimeIndex && siteIds.Contains(n.SiteId)).Select(n => n);
                else query = _dbRubika.Tbl_News.Where(n => n.NewsDateTimeIndex >= fromDateTimeIndex && n.NewsDateTimeIndex <= toDateTimeIndex && n.GroupId == SiteGroup && siteIds.Contains(n.SiteId)).Select(n => n);
            }
            else
            {
                if (SiteGroup == 0)
                    query = _dbRubika.Tbl_News.Where(n => n.NewsDateTimeIndex >= fromDateTimeIndex && n.NewsDateTimeIndex <= toDateTimeIndex).Select(n => n);
                else query = _dbRubika.Tbl_News.Where(n => n.NewsDateTimeIndex >= fromDateTimeIndex && n.NewsDateTimeIndex <= toDateTimeIndex && n.GroupId == SiteGroup).Select(n => n);
            }
            IQueryable<Tbl_NewsGroups> queryNewsGroup = _dbRubika.Tbl_NewsGroups.Select(n => n);

            if (!string.IsNullOrEmpty(searchString.Trim()))
            {
                searchString = Class_Static.ArabicAlpha(searchString);

                string str1 = "";
                string str2 = "";
                string str3 = "";


                if (searchString.Contains("|"))
                {
                    var SearchParameterList = searchString.Split('|');


                    if (SearchParameterList.Count() == 2)
                    {
                        str1 = SearchParameterList[0];
                        str2 = SearchParameterList[1];

                        query = query.Where(n =>
                        (n.NewsTitle.Contains(str1) || n.NewsLead.Contains(str1) || n.NewsBody.Contains(str1)) &&
                        (n.NewsTitle.Contains(str2) || n.NewsLead.Contains(str2) || n.NewsBody.Contains(str2)));

                    }
                    else if (SearchParameterList.Count() == 3)
                    {

                        str1 = SearchParameterList[0];
                        str2 = SearchParameterList[1];
                        str3 = SearchParameterList[2];


                        query = query.Where(n =>
                        (n.NewsTitle.Contains(str1) || n.NewsLead.Contains(str1) || n.NewsBody.Contains(str1)) &&
                        (n.NewsTitle.Contains(str2) || n.NewsLead.Contains(str2) || n.NewsBody.Contains(str2)) &&
                        (n.NewsTitle.Contains(str3) || n.NewsLead.Contains(str3) || n.NewsBody.Contains(str3))
                        );

                    }

                }
                else
                {
                    query = query.Where(n => (n.NewsTitle.Contains(searchString) || n.NewsLead.Contains(searchString) || n.NewsBody.Contains(searchString)));
                }
            }

            pagingNews.TotalNewsCount = query.Count();
            pagingNews.NewsList = query
                .OrderByDescending(n => n.NewsDateTimeIndex)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .Select(n => new PagingNewMediaNewsItem_Type
                {
                    id = n.NewsId,
                    Title = n.NewsTitle,
                    DateTimeIndex = n.NewsDateTimeIndex,
                    KeyTitles = "",
                    SiteID = n.SiteId,
                    SiteName = "",
                    GroupId = n.GroupId,
                    Date = "",
                    Time = "",
                    GroupTitle = queryNewsGroup.FirstOrDefault(i => i.GroupId == n.GroupId).GroupTitle,
                    Url = n.NewsOrginalLink,
                    ViewCount = n.ViewCount ?? 0
                }).ToList();

        }
        public string splitDate(string dateTimeIndex)
        {
            string year = dateTimeIndex.ToString().Substring(0, 4);
            string month = dateTimeIndex.ToString().Substring(4, 2);
            string day = dateTimeIndex.ToString().Substring(6, 2);
            return year + "/" + month + "/" + day;
        }
        public string splitTime(string dateTimeIndex)
        {
            string hour = dateTimeIndex.ToString().Substring(8, 2);
            string min = dateTimeIndex.ToString().Substring(10, 2);
            return hour + ":" + min;
        }
        private void GeneratePaginationButton(int totalCount, int pageSize, int index)
        {
            var remind = (totalCount % pageSize) > 0 ? 1 : 0;

            int tab = totalCount / pageSize + remind;

            int rangeStart = 1;
            int rangeEnd = tab;

            StringBuilder PaginationHTML = new StringBuilder();

            PaginationHTML.AppendLine("<div class=\"pagination\">");

            if (tab > 10 && index > 5)
            {
                PaginationHTML.Append($"<a href=\"{generatePaginationLink(1)}\">&laquo;</a>  ");
            }

            if (tab <= 10)
            {
                for (int i = rangeStart; i <= rangeEnd; i++)
                {
                    if (index == i)
                    {
                        PaginationHTML.Append($"<a class=\"active\"   href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                    }
                    else
                    {
                        PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                    }

                }
            }
            else
            {
                if (index < 6)
                {
                    rangeStart = 1;
                    rangeEnd = 10;

                    for (int i = rangeStart; i <= rangeEnd; i++)
                    {
                        if (index == i)
                        {
                            PaginationHTML.Append($"<a class=\"active\"  href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                        else
                        {
                            PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }

                    }

                }
                else if (index > tab - 6)
                {
                    rangeStart = tab - 10;
                    rangeEnd = tab;

                    for (int i = rangeStart; i <= rangeEnd; i++)
                    {
                        if (index == i)
                        {
                            PaginationHTML.Append($"<a  class=\"active\" href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                        else
                        {
                            PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                    }
                }
                else
                {
                    rangeStart = index - 4;
                    rangeEnd = index + 5;

                    for (int i = rangeStart; i <= rangeEnd; i++)
                    {
                        if (index == i)
                        {
                            PaginationHTML.Append($"<a  class=\"active\" href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                        else
                        {
                            PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                    }
                }
            }

            if (tab > 10 && index < tab - 5)
            {
                PaginationHTML.Append($"<a href=\"{generatePaginationLink(tab)}\">&raquo;</a>  ");
            }

            PaginationHTML.AppendLine("</div>");
            PaginationHTML.AppendLine($"<span class=\"PagingTotalCount\">صفحه {index} از {tab} </span>");
            PaginationHTML.AppendLine($"<span class=\"PagingTotalCount\">تعداد اخبار: {totalCount}  </span>");

            topPagination.InnerHtml = PaginationHTML.ToString();
            buttomPagination.InnerHtml = PaginationHTML.ToString();

        }

        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            int index = 1;
            generateUrl(index);
        }

        private void generateUrl(int index)
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

            if (txt_search.Text.Trim() != "")
            {
                url += "keyword=" + Server.HtmlEncode(txt_search.Text.Trim().Replace("+", "|")) + "&";
            }
            if (txt_fromHour.Text != "" && txt_toHour.Text != "")
            {
                url += "ftime=" + Server.HtmlEncode(txt_fromHour.Text.Trim().Replace(":", "-")) + "&";
                url += "ttime=" + Server.HtmlEncode(txt_toHour.Text.Trim().Replace(":", "-")) + "&";
            }

            //if (storageTypeDropDownList.SelectedItem.Value != null)
            //{
            //    url += "st=" + Server.HtmlEncode(storageTypeDropDownList.SelectedItem.Value) + "&";
            //}
            if (ddlSiteGroup.SelectedItem.Value != null)
            {
                url += "g=" + Server.HtmlEncode(ddlSiteGroup.SelectedItem.Value) + "&";
            }
            if (PageSizeDropDownList.SelectedItem.Value != null)
            {
                url += "size=" + Server.HtmlEncode(PageSizeDropDownList.SelectedItem.Value) + "&";
            }
            if (ddlSiteType.SelectedItem.Value != null)
            {
                url += "st=" + Server.HtmlEncode(ddlSiteType.SelectedItem.Value) + "&";
            }
            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            Response.Redirect("/NewMediaNewsList/?" + url);


        }

        private string generatePaginationLink(int index)
        {

            string url = "";

            url = "fromDate=" + fromDate.ToString() + "&";
            url += "toDate=" + toDate.ToString() + "&";
            //////////////////if (!string.IsNullOrEmpty(strSearch))
            //////////////////{
            //////////////////    url += "keyword=" + Server.HtmlEncode(strSearch) + "&";
            //////////////////}

            if (txt_fromHour.Text != "" && txt_toHour.Text != "")
            {
                url += "ftime=" + Server.HtmlEncode(txt_fromHour.Text.Trim().Replace(":", "-")) + "&";
                url += "ttime=" + Server.HtmlEncode(txt_toHour.Text.Trim().Replace(":", "-")) + "&";
            }
            if (ddlSiteGroup.SelectedItem.Value != null)
            {
                url += "g=" + Server.HtmlEncode(ddlSiteGroup.SelectedItem.Value) + "&";
            }
            if (ddlSiteGroup.SelectedItem.Value != null)
            {
                url += "st=" + Server.HtmlEncode(ddlSiteType.SelectedItem.Value) + "&";
            }
            url += "size=" + Server.HtmlEncode(pageSize.ToString()) + "&";

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            return "/NewMediaNewsList/?" + url;

        }

        private void GenerateNewsList(PagingNewMediaNewsList_Type pagingNews)
        {
            if (siteType != 0)
                pagingNews.NewsList = pagingNews.NewsList.Where(i => i.SiteType == siteType).ToList();
            pagingGridRepeater.DataSource = pagingNews.NewsList;
            pagingGridRepeater.DataBind();
        }

        private void GetCompletedData()
        {
            var siteIds = pagingNews.NewsList.Select(n => n.SiteID).Distinct().ToList();
            var sites = _dbRubika.Tbl_Sites.Where(s => siteIds.Contains(s.SiteId)).ToList();

            foreach (var item in pagingNews.NewsList)
            {
                item.SiteName = sites.Where(s => s.SiteId == item.SiteID).Select(s => s.SiteTitle).FirstOrDefault().Trim().Replace("ي", "ی").Replace("ك", "ک");
                //item.SiteType = sites.Where(s => s.SiteID == item.SiteID).Select(s => s.SiteType).FirstOrDefault() ?? 0;
                item.Title = item.Title.Trim().Replace("ي", "ی").Replace("ك", "ک");
                try { item.SiteType = (int)sites.SingleOrDefault(i => i.SiteId == item.SiteID).SiteType; }
                catch
                {
                    item.SiteType = 0;
                }
                //item.DateTimeString = DiffrentDate(item.SiteType.ToString(), item.Time, item.Date);

                if (string.IsNullOrEmpty(item.Url))
                {
                    item.UrlDisplayControl = "hide";
                }

            }
        }

        private void GetSaveAndBultanFlag()
        {
            foreach (var item in pagingNews.NewsList)
            {
                //if (NewsIdsWidthBultanFlag.Contains(item.id))
                //{
                //    item.BultanCheckBox = "checked";
                //}

                //if (NewsIdsWidthSaveFlag.Contains(item.id))
                //{
                //    item.SaveCheckBox = "checked";
                //}

            }
        }

        public static string NewsRateOpacity(object newsValue, string MustValue)
        {
            if (newsValue.ToString() == "")
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

        private static void UpdateViewCount(int NewsId)
        {
            var news = _dbRubika.Tbl_News.First(n => n.NewsId == NewsId);
            news.ViewCount = news.ViewCount + 1 ?? 1;
            _dbRubika.Entry(news).State = EntityState.Modified;
            _dbRubika.SaveChanges();
        }

        [WebMethod]
        public static PagingNewMediaNewsDetails_Type DetailShowNews(string NewsID)
        {
            PagingNewMediaNewsDetails_Type News = new PagingNewMediaNewsDetails_Type();

            try
            {
                int id = Convert.ToInt32(NewsID);



                News = _dbRubika.Tbl_News.Where(n => n.NewsId == id).Select(n => new PagingNewMediaNewsDetails_Type
                {

                    id = n.NewsId,
                    Title = n.NewsTitle,
                    Lead = n.NewsLead,
                    Body = n.NewsBody,
                    SiteID = n.SiteId,
                    SiteName = "",
                    KeyTitles = "",
                    DateTimeIndex = n.NewsDateTimeIndex,
                    DateTimeString = ""

                }).FirstOrDefault();


                if (string.IsNullOrEmpty(News.Body))
                {
                    News.Body = News.Lead;
                }

                News.Body = AdjucstText(News.Body).Replace("ي", "ی").Replace("ك", "ک") + " ";

                News.Body = Class_Static.EnglishToPersianNumber(News.Body);

                // update view Count
                UpdateViewCount(id);

            }
            catch (Exception)
            {
                return null;
            }

            return News;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="bultanTitle"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="allowNewspaper"></param>
        /// <param name="galleryNewspaper"></param>
        /// <param name="arz"></param>
        /// <param name="sima"></param>
        /// <param name="highLight"></param>
        /// <param name="allowGroup"></param>
        /// <param name="related"></param>
        /// <param name="selectedBultan"></param>
        /// <param name="isArchive"></param>
        /// <param name="chart"></param>
        /// <param name="jeld"></param>
        /// <param name="BultanType"></param>
        /// <param name="linkUrl"></param>
        /// <returns></returns>
        [WebMethod]
        public static int SetBultanArchive(string fromDate, string toDate, string bultanTitle, string fromTime, string toTime,
            bool allowNewspaper, bool galleryNewspaper, bool arz, bool sima, bool highLight, bool allowGroup, bool related,
            int selectedBultan, bool isArchive, bool chart, bool jeld, byte BultanType, string linkUrl)
        {
            try
            {
                var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;

                fromDate = fromDate.Replace("/", "");
                toDate = toDate.Replace("/", "");
                fromTime = fromTime.Replace(":", "");
                toTime = toTime.Replace(":", "");


                long fromDateTime = Convert.ToInt64(fromDate + (string.IsNullOrEmpty(fromTime) ? "0000" : fromTime));
                long toDateTime = Convert.ToInt64(toDate + (string.IsNullOrEmpty(toTime) ? "2500" : toTime));

                List<long> AllNewsInSelectedTime = _dbRubika.Tbl_News
                    .Where(n => n.NewsDateTimeIndex >= fromDateTime && n.NewsDateTimeIndex <= toDateTime)
                    .Select(n => n.NewsId).ToList();


                Class_BultanArchive archive = new Class_BultanArchive();

                StringBuilder str = new StringBuilder();

                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

                var NewsList = _dbDDn.Tbl_MemberNewsSelectionForBultan
                        .Where(n => n.PanelID == userPanelId && n.MemberID == memberId && AllNewsInSelectedTime.Contains(n.NewsID))
                        .Select(n => n.NewsID).ToList();

                foreach (var item in NewsList)
                {
                    str.Append(item.ToString() + ",");
                }


                int result = archive.InsertArchive(Convert.ToInt64(PArt.Pages.P_Art.Repository.Class_Static.ShamisiWithoutSlash(fromDate)),
                    parmin, linkUrl, Class_Static.ConvertToLatinNumberSam(bultanTitle), str.ToString().Substring(0, str.Length - 1), fromDate, toDate, fromTime, toTime, allowNewspaper,
                    galleryNewspaper, arz, sima, highLight, allowGroup, related, selectedBultan, isArchive, chart, jeld, BultanType);
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
        public static long AddToInbox(long MediaId, int MediaType)
        {
            try
            {
                var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;
                StringBuilder str = new StringBuilder();

                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
                var inboxList = _dbDDn.Tbl_Inbox.Where(b => b.MemberId == memberId && b.PanelId == userPanelId).ToList();
                var inbox = inboxList.SingleOrDefault(b => b.MediaId == MediaId && b.MediaType == MediaType &&
                b.MemberId == memberId && b.PanelId == userPanelId);
                if (inbox == null)
                {
                    inbox = new Tbl_Inbox();
                    inbox.MediaId = MediaId;
                    inbox.MediaType = MediaType;
                    inbox.PanelId = userPanelId;
                    inbox.MemberId = memberId;
                    inbox.Priority = inboxList.Count + 1;
                    _dbDDn.Tbl_Inbox.Add(inbox);
                    _dbDDn.SaveChanges();
                }
                return inbox.InboxId;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return 0;
            }
        }

        public static string ChangeIcon(string sitetype)
        {

            if (sitetype == "1")
                return "fas fa-rss-square";
            else
                return "far fa-newspaper";

        }

        public static string CheckSeenOrNot(int viewCount)
        {
            if (viewCount > 0)
            {
                return "fas fa-folder-open opacity50";
            }
            else
            {
                return "fas fa-folder";
            }
        }

        public static string DiffrentDate(string siteType, string newsTime, string newsDate)
        {
            try
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();


                if (siteType == "2")
                {
                    return newsDate;

                }
                PersianCalendar p = new PersianCalendar();
                string[] parts = newsDate.Split('/', '-');

                var TimeParts = newsTime.Trim().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                DateTime dateTime = p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(TimeParts[0]), Convert.ToInt32(TimeParts[1]), 0, 0);

                return Class_Static.GetOnTimeDate(dateTime);
            }
            catch
            {
                return newsDate + " - " + newsTime;

            }


        }
        public static string GetCheckBoxCheckedAttribute(bool flag)
        {
            if (flag)
            {
                return "checked";
            }
            else
            {
                return "";
            }
        }

        private void LoadTemplate()
        {
            Class_Panels _cls = new Class_Panels();
            List<int> ids = new List<int>();
            ListItem newItem = new ListItem();
            var parmin = _cls.GetParminById(userPanelId);
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
        private static string AdjucstText(string inputText)
        {
            HtmlNode txtHtml = HtmlNode.CreateNode(inputText);
            inputText = Class_Static.PersianAlpha(Class_Static.GetAbsoulateTextFromHtmlNode(txtHtml));
            inputText += "    ";

            StringBuilder ModifiedText = new StringBuilder();

            ModifiedText.Append(inputText[0]);
            bool NewLineFlag = false;
            try
            {
                for (int i = 1; i < inputText.Length; i++)
                {
                    if (char.IsDigit(inputText[i - 1]) && char.IsPunctuation(inputText[i]) && char.IsDigit(inputText[i + 1]))
                    {
                        ModifiedText.Append(inputText[i]);
                        continue;
                    }



                    if (char.IsPunctuation(inputText[i]))
                    {
                        if (i + 3 < inputText.Length)
                        {
                            if (char.IsPunctuation(inputText[i + 1]) && char.IsPunctuation(inputText[i + 2]))
                            {
                                ModifiedText.Append(inputText[i]);
                                ModifiedText.Append(inputText[i + 1]);
                                ModifiedText.Append(inputText[i + 2]);
                                i += 2;
                                continue;
                            }
                            else
                            {
                                ModifiedText.Append($" {inputText[i]} ");
                                if (NewLineFlag && inputText[i] == '.')
                                {
                                    ModifiedText.Append("<br />");
                                    NewLineFlag = false;
                                }
                            }
                        }
                        else
                        {
                            ModifiedText.Append($" {inputText[i]} ");
                            if (NewLineFlag && inputText[i] == '.')
                            {
                                ModifiedText.Append("<br />");
                                NewLineFlag = false;
                            }
                        }


                    }
                    else
                    {
                        ModifiedText.Append(inputText[i]);
                    }

                    if (i % 400 == 0)
                    {
                        NewLineFlag = true;
                    }
                }


            }
            catch (Exception)
            {
            }

            return string.IsNullOrEmpty(ModifiedText.ToString()) ? inputText : ModifiedText.ToString();
        }
        protected void ClearAllBultanSelectionButton_Click(object sender, EventArgs e)
        {
            memberId = Class_Layer.CurrentUser().MemberID;
            userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

            var RemoveItemList = _dbDDn.Tbl_MemberNewsSelectionForBultan.Where(n => n.MemberID == memberId && n.PanelID == userPanelId).ToList();
            foreach (var item in RemoveItemList)
            {
                _dbDDn.Tbl_MemberNewsSelectionForBultan.Remove(item);
            }
            _dbDDn.SaveChanges();
        }
    }
}