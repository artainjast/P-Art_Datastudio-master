using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System.Text;
using System.Globalization;
using System.Web.Services;
using HtmlAgilityPack;
using System.Data;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class DomesticNewsPaging : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        Class_Zaman _clsZm = new Class_Zaman();
        List<int> ActiveKeyword = new List<int>();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        List<int?> UserPanelList = new List<int?>();
        List<int> siteIdList = new List<int>();
        int memberId = 0;
        int userPanelId = 0;

        string strSearch = "";

        int siteId = 0;
        int fromDate = 0;
        int toDate = 0;
        int pageSize = 25;
        int pageIndex = 1;
        int StorageType = 1;

        PagingNewsList_Type pagingNews = new PagingNewsList_Type();

        int time = 0;
        Int64 fromDateTime = 0;
        Int64 toDateTime = 0;
        bool hasDeletedKeyValue = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            Class_Layer.CheckSession();

            if (!IsPostBack)
            {

                memberId = Class_Layer.CurrentUser().MemberID;

                userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
                hddParmin.Value = userPanelId.ToString();
                hddMember.Value = memberId.ToString();
                LoadNewsSource();

                LoadData();

                PrepareNews(fromDateTime, toDateTime, "", strSearch, pageSize, pageIndex, StorageType);

                GeneratePaginationButton(pagingNews.TotalNewsCount, pageSize, pageIndex);

                LoadTemplate();

                GetCompletedData();

                GetNewsListRelate();

                GetSaveAndBultanFlag();

                GenerateNewsList(pagingNews);

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
            if (Request.QueryString["SiteId"] != null)
            {
                siteId = int.Parse(Request.QueryString["SiteId"].ToString());
                if (siteId != 0)
                {
                    if (siteId == -1)
                    {
                        siteIdList.AddRange(_db.AllSitesView.Where(s => s.SiteType == 1).Select(s => s.SiteID).ToList());
                    }
                    else if (siteId == -2)
                    {
                        siteIdList.AddRange(_db.AllSitesView.Where(s => s.SiteType == 2).Select(s => s.SiteID).ToList());
                    }
                    else
                    {
                        siteIdList.Add(siteId);
                    }

                }

                drp_NewsSource.SelectedValue = siteId.ToString();
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
                txt_search.Text = strSearch.Replace("|", "+");

            }

            if (Request.QueryString["st"] != null)
            {
                storageTypeDropDownList.SelectedValue = Server.HtmlDecode(Request.QueryString["st"].ToString());
                StorageType = Convert.ToInt32(storageTypeDropDownList.SelectedValue);
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

            if (Request.QueryString["hdk"] != null)
            {
                hasDeletedKeyValue = true;
                try
                {
                    HasDeletedKeyCheckBox.Checked = true;
                }
                catch (Exception)
                { }
            }


        }

        private void PrepareNews(long fromDateTimeIndex, long toDateTimeIndex, string keyIds, string searchString, int pageSize, int pageIndex, int storageType)
        {

            List<int> newsIdtList = new List<int>();
            List<int> newsIdResultList = new List<int>();
            List<int> SiteIDs = new List<int>();


            ActiveKeyword.Clear();
            ActiveKeyword.AddRange(_db.Tbl_RssKeywords.Where(k => k.PanelId == userPanelId && k.Active == true).Select(k => k.KeyId).ToList());

            PagingNewsList_Type Result = new PagingNewsList_Type();

            IQueryable<Tbl_News> query = _db.Tbl_News.Where(n => n.ParminId == userPanelId && n.NewsDateTimeIndex >= fromDateTimeIndex && n.NewsDateTimeIndex <= toDateTimeIndex).Select(n => n);

            if (siteId != 0)
            {
                query = query.Where(n => siteIdList.Contains(n.SiteID));
            }

            if (!hasDeletedKeyValue)
            {
                query = query.Where(n => ActiveKeyword.Contains(n.KeywordId.Value));
            }

            if (storageType == 2)
            {
                var memberSavedNewsList = _db.Tbl_MemberNewsSaveStore.Where(n => n.PanelID == userPanelId && n.MemberID == memberId).Select(n => n.NewsID).ToList();
                query = query.Where(n => memberSavedNewsList.Contains(n.NewsID));
            }

            if (storageType == 3)
            {
                var memberNewsThatSelectedForBultanList = _db.Tbl_MemberNewsSelectionForBultan.Where(n => n.PanelID == userPanelId && n.MemberID == memberId).Select(n => n.NewsID).ToList();
                query = query.Where(n => memberNewsThatSelectedForBultanList.Contains(n.NewsID));
            }

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
                .Select(n => new PagingNewsItem_Type
                {
                    id = n.NewsID,
                    Title = n.NewsTitle,
                    Date = n.NewsDate,
                    Time = n.NewsTime,
                    DateTimeIndex = n.NewsDateTimeIndex ?? 0,
                    KeyIds = n.KeyIds,
                    KeyTitles = "",
                    NewsType = n.NewsType ?? 0,
                    NewsValue = n.NewsValue ?? 0,
                    RelatedNews = "",
                    SiteID = n.SiteID,
                    SiteName = "",
                    Url = n.NewsLink,
                    ViewCount = n.ViewCount ?? 0,
                    NewsLink = n.NewsLink,
                    SiteLogo = "",
                    NewsPicture = n.NewsPicture ,
                    NewsLead = n.NewsLead ,
                    CreateDate = n.CreateDate
                }).ToList();

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

            if (storageTypeDropDownList.SelectedItem.Value != null)
            {
                url += "st=" + Server.HtmlEncode(storageTypeDropDownList.SelectedItem.Value) + "&";
            }



            if (drp_NewsSource.SelectedItem.Value != "0")
            {
                url += "SiteId=" + drp_NewsSource.SelectedItem.Value + "&";
            }

            if (HasDeletedKeyCheckBox.Checked)
            {
                url += "hdk=1&";
            }

            if (PageSizeDropDownList.SelectedItem.Value != null)
            {
                url += "size=" + Server.HtmlEncode(PageSizeDropDownList.SelectedItem.Value) + "&";
            }

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            Response.Redirect("/PagingNewsList/?" + url);


        }

        private string generatePaginationLink(int index)
        {

            string url = "";

            url = "fromDate=" + fromDate.ToString() + "&";
            url += "toDate=" + toDate.ToString() + "&";
            if (!string.IsNullOrEmpty(strSearch))
            {
                url += "keyword=" + Server.HtmlEncode(strSearch) + "&";
            }

            if (txt_fromHour.Text != "" && txt_toHour.Text != "")
            {
                url += "ftime=" + Server.HtmlEncode(txt_fromHour.Text.Trim().Replace(":", "-")) + "&";
                url += "ttime=" + Server.HtmlEncode(txt_toHour.Text.Trim().Replace(":", "-")) + "&";
            }

            if (storageTypeDropDownList.SelectedItem.Value != null)
            {
                url += "st=" + Server.HtmlEncode(storageTypeDropDownList.SelectedItem.Value) + "&";
            }

            if (drp_NewsSource.SelectedItem.Value != "0")
            {
                url += "SiteId=" + drp_NewsSource.SelectedItem.Value + "&";
            }

            if (HasDeletedKeyCheckBox.Checked)
            {
                url += "hdk=1&";
            }

            url += "size=" + Server.HtmlEncode(pageSize.ToString()) + "&";

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            return "/PagingNewsList/?" + url;

        }

        private void GenerateNewsList(PagingNewsList_Type pagingNews)
        {
            pagingGridRepeater.DataSource = pagingNews.NewsList;
            pagingGridRepeater.DataBind();
        }

        private void GetCompletedData()
        {
            var siteIds = pagingNews.NewsList.Select(n => n.SiteID).Distinct().ToList();
            var sites = _db.Tbl_Sites.Where(s => siteIds.Contains(s.SiteID)).ToList();

            foreach (var item in pagingNews.NewsList)
            {
                item.SiteName = sites.Where(s => s.SiteID == item.SiteID).Select(s => s.SiteTitle).FirstOrDefault().Trim().Replace("ي", "ی").Replace("ك", "ک");

                item.SiteType = sites.Where(s => s.SiteID == item.SiteID).Select(s => s.SiteType).FirstOrDefault() ?? 0;
                item.Title = item.Title.Trim().Replace("ي", "ی").Replace("ك", "ک");
                item.SiteLogo = sites.Where(s => s.SiteID == item.SiteID).Select(s => s.Logo).FirstOrDefault();
                //item.DateTimeString = DiffrentDate(item.SiteType.ToString(), item.Time, item.Date);

                if (string.IsNullOrEmpty(item.Url))
                {
                    item.UrlDisplayControl = "hide";
                }

            }
        }

        private void GetSaveAndBultanFlag()
        {
            List<int> NewsIdsWidthBultanFlag = _db.Tbl_MemberNewsSelectionForBultan.Where(n => n.PanelID == userPanelId && n.MemberID == memberId).Select(n => n.NewsID).ToList();
            List<int> NewsIdsWidthSaveFlag = _db.Tbl_MemberNewsSaveStore.Where(n => n.PanelID == userPanelId && n.MemberID == memberId).Select(n => n.NewsID).ToList();

            foreach (var item in pagingNews.NewsList)
            {
                if (NewsIdsWidthBultanFlag.Contains(item.id))
                {
                    item.BultanCheckBox = "checked";
                }

                if (NewsIdsWidthSaveFlag.Contains(item.id))
                {
                    item.SaveCheckBox = "checked";
                }

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
                    return "opacity:0.3";
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
                    return "opacity:0.3";
                }
            }
        }

        private static void UpdateViewCount(int NewsId)
        {
            var news = _dbStatic.Tbl_News.First(n => n.NewsID == NewsId);
            news.ViewCount = news.ViewCount + 1 ?? 1;
            _dbStatic.Entry(news).State = EntityState.Modified;
            _dbStatic.SaveChanges();
        }

        [WebMethod]
        public static bool SelectAndUnSelectNews(string newsIds, bool check)
        {
            try
            {
                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

                var NewsIdsListString = newsIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                List<int> newsIdList = new List<int>();
                foreach (var newsId in NewsIdsListString)
                {
                    try
                    {
                        newsIdList.Add(Convert.ToInt32(newsId));
                    }
                    catch (Exception)
                    { }

                }

                if (check)
                {
                    foreach (var newsId in newsIdList)
                    {
                        _dbStatic.Tbl_MemberNewsSelectionForBultan.Add(new Tbl_MemberNewsSelectionForBultan
                        {
                            MemberID = memberId,
                            NewsID = newsId,
                            PanelID = userPanelId
                        });
                    }

                }
                else
                {
                    var items = _dbStatic.Tbl_MemberNewsSelectionForBultan.Where(n => n.PanelID == userPanelId && n.MemberID == memberId && newsIdList.Contains(n.NewsID)).ToList();
                    foreach (var item in items)
                    {
                        _dbStatic.Tbl_MemberNewsSelectionForBultan.Remove(item);
                    }

                }
                return _dbStatic.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public static PagingNewsDetails_Type DetailShowNews(string NewsID)
        {
            PagingNewsDetails_Type News = new PagingNewsDetails_Type();

            try
            {
                int id = Convert.ToInt32(NewsID);

                News = _dbStatic.Tbl_News.Where(n => n.NewsID == id).Select(n => new PagingNewsDetails_Type
                {
                    id = n.NewsID,
                    Title = n.NewsTitle,
                    Lead = n.NewsLead,
                    Body = n.NewsBody,
                    SiteID = n.SiteID,
                    SiteName = "",
                    NewsType = n.NewsType ?? 0,
                    NewsValue = n.NewsValue ?? 0,
                    KeyIds = n.KeyIds,
                    KeyTitles = "",
                    Date = n.NewsDate,
                    Time = n.NewsTime,
                    DateTimeIndex = n.NewsDateTimeIndex ?? 0,
                    DateTimeString = "",
                    RelatedNews = ""

                }).FirstOrDefault();

                List<int> KeyIdList = new List<int>();

                var keyIdStringList = News.KeyIds.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var key in keyIdStringList)
                {
                    KeyIdList.Add(Convert.ToInt32(key));
                }


                if (string.IsNullOrEmpty(News.Body))
                {
                    News.Body = News.Lead;
                }

                News.Body = AdjucstText(News.Body).Replace("ي", "ی").Replace("ك", "ک") + " ";

                var Keywords = _dbStatic.Tbl_RssKeywords.Where(k => KeyIdList.Contains(k.KeyId)).Select(k => k.KeywordName).ToList();
                List<string> KeywordList = new List<string>();
                List<string> UniqueKeywordList = new List<string>();

                News.KeyTitles = "<div class=\"TagContainer\">";
                foreach (var key in Keywords)
                {
                    News.KeyTitles += $"<span class=\"KeywordTag\"><i class=\"fas fa-key\"></i>{key.Replace("ي", "ی").Replace("ك", "ک")}</span>";

                    if (key.Contains("+"))
                    {
                        var newKey = key.Trim().Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var keyItem in newKey)
                        {
                            KeywordList.Add(keyItem.Replace("ي", "ی").Replace("ك", "ک"));
                        }
                    }
                    else
                    {
                        KeywordList.Add(key.Replace("ي", "ی").Replace("ك", "ک"));
                    }
                }

                News.KeyTitles += "</div>";

                UniqueKeywordList.AddRange(KeywordList.Distinct());

                foreach (var key in UniqueKeywordList.OrderBy(k => k.Length))
                {

                    News.Body = News.Body.Replace($" {key} ", $" <span class=\"highlight\">{key}</span> ");
                }



                News.Body = Class_Static.EnglishToPersianNumber(News.Body);

                //var site = _dbStatic.Tbl_Sites.Where(s => s.SiteID == News.SiteID).FirstOrDefault();

                //News.SiteName = site.SiteTitle.Replace("ي", "ی").Replace("ك", "ک");
                //News.SiteType = site.SiteType ?? 0;

                // update view Count
                UpdateViewCount(id);

            }
            catch (Exception)
            {
                return null;
            }

            return News;
        }

        [WebMethod]
        public static string GetRelatedNews(string RelatedNewsIds)
        {
            if (string.IsNullOrEmpty(RelatedNewsIds) || RelatedNewsIds == "undefined")
            {
                return "";
            }


            int memberId = Class_Layer.CurrentUser().MemberID;

            int userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

            List<int> NewsIdsList = new List<int>();
            var NewsIds = RelatedNewsIds.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var id in NewsIds)
            {
                NewsIdsList.Add(Convert.ToInt32(id));
            }

            var NewsList = _dbStatic.Tbl_News.Where(n => NewsIdsList.Contains(n.NewsID)).Select(n => new PagingNewsRelated_Type
            {
                id = n.NewsID,
                SiteID = n.SiteID,
                Title = n.NewsTitle,
                DateTimeIndex = n.NewsDateTimeIndex ?? 0,
                Date = n.NewsDate,
                Time = n.NewsTime
            }).ToList();

            var siteIds = NewsList.Select(n => n.SiteID).Distinct().ToList();
            var sites = _dbStatic.Tbl_Sites.Where(s => siteIds.Contains(s.SiteID)).ToList();


            List<int> NewsIdsWidthBultanFlag = _dbStatic.Tbl_MemberNewsSelectionForBultan.Where(n => n.PanelID == userPanelId && n.MemberID == memberId && NewsIdsList.Contains(n.NewsID)).Select(n => n.NewsID).ToList();

            foreach (var item in NewsList)
            {
                if (NewsIdsWidthBultanFlag.Contains(item.id))
                {
                    item.BultanCheckBox = "checked";
                }
                item.SiteName = sites.Where(s => s.SiteID == item.SiteID).Select(s => s.SiteTitle).FirstOrDefault().Trim().Replace("ي", "ی").Replace("ك", "ک");
                item.Title = item.Title.Trim().Replace("ي", "ی").Replace("ك", "ک");
            }

            StringBuilder result = new StringBuilder();
            int index = 1;
            foreach (var item in NewsList.OrderBy(n => n.DateTimeIndex))
            {
                result.Append("<div class=\"RelatedGridItem\">");

                result.Append($"<span class=\"Index\">{Class_Static.EnglishToPersianNumber((index++).ToString())}</span>");

                result.Append("<span class=\"Selection\">");

                result.Append($"<input id=\"NewsSelectCheckbox\" type=\"checkbox\" class=\"CheckBox\" data-id=\"{item.id}\" {item.BultanCheckBox} />");

                result.Append("</span>");

                result.Append("<span class=\"Title\">");

                result.Append($"<a target=\"_blank\" href=\"/ShowNews/{item.id}\">{Class_Static.EnglishToPersianNumber(item.Title)}</a>");

                result.Append("</span>");

                result.Append($"<span class=\"SiteTitle\">{item.SiteName}</span>");

                result.Append($"<span class=\"DateTime\">{Class_Static.EnglishToPersianNumber(item.Date)} - {Class_Static.EnglishToPersianNumber(item.Time)}</span>");

                result.Append("</div>");
            }



            return result.ToString();
        }

        [WebMethod]
        public static bool SaveNews(int newsID, bool check)
        {
            try
            {
                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;


                if (check)
                {
                    if (!_dbStatic.Tbl_MemberNewsSaveStore.Where(n => n.PanelID == userPanelId && n.MemberID == memberId && n.NewsID == newsID).Any())
                    {
                        _dbStatic.Tbl_MemberNewsSaveStore.Add(new Tbl_MemberNewsSaveStore
                        {
                            MemberID = memberId,
                            NewsID = newsID,
                            PanelID = userPanelId
                        });

                        _dbStatic.SaveChanges();
                    }

                }
                else if (!check)
                {
                    var item = _dbStatic.Tbl_MemberNewsSaveStore.Where(n => n.PanelID == userPanelId && n.MemberID == memberId && n.NewsID == newsID).FirstOrDefault();
                    _dbStatic.Tbl_MemberNewsSaveStore.Remove(item);

                    _dbStatic.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public static bool BultanMark(int newsID, bool check)
        {
            try
            {
                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;


                if (check)
                {
                    if (!_dbStatic.Tbl_MemberNewsSelectionForBultan.Where(n => n.PanelID == userPanelId && n.MemberID == memberId && n.NewsID == newsID).Any())
                    {
                        _dbStatic.Tbl_MemberNewsSelectionForBultan.Add(new Tbl_MemberNewsSelectionForBultan
                        {
                            MemberID = memberId,
                            NewsID = newsID,
                            PanelID = userPanelId
                        });

                        _dbStatic.SaveChanges();
                    }

                }
                else if (!check)
                {
                    var item = _dbStatic.Tbl_MemberNewsSelectionForBultan.Where(n => n.PanelID == userPanelId && n.MemberID == memberId && n.NewsID == newsID).FirstOrDefault();
                    _dbStatic.Tbl_MemberNewsSelectionForBultan.Remove(item);

                    _dbStatic.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
                DB_NewsCenterEntities _dbStaticNew = new DB_NewsCenterEntities();
                var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;

                fromDate = fromDate.Replace("/", "");
                toDate = toDate.Replace("/", "");
                fromTime = fromTime.Replace(":", "");
                toTime = toTime.Replace(":", "");


                long fromDateTime = Convert.ToInt64(fromDate + (string.IsNullOrEmpty(fromTime) ? "0000" : fromTime));
                long toDateTime = Convert.ToInt64(toDate + (string.IsNullOrEmpty(toTime) ? "2500" : toTime));

                List<int> AllNewsInSelectedTime = _dbStatic.Tbl_News
                    .Where(n => n.ParminId == parmin && n.NewsDateTimeIndex >= fromDateTime && n.NewsDateTimeIndex <= toDateTime)
                    .Select(n => n.NewsID).ToList();


                Class_BultanArchive archive = new Class_BultanArchive();

                StringBuilder str = new StringBuilder();

                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

                var NewsList = _dbStaticNew.Tbl_MemberNewsSelectionForBultan
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
            catch (Exception ex)
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
                return "fa fa-eye opacity50";
            }
            else
            {
                return "fa fa-eye-slash";
            }
        }
        public static string GetTextSeenOrNot(int viewCount)
        {
            if (viewCount > 0)
            {
                return "خوانده شده است";
            }
            else
            {
                return "خوانده نشده است";
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
        public void GetNewsListRelate()
        {
            try
            {
                List<int> RelatedId = new List<int>();
                List<int> NewsIds = pagingNews.NewsList.Select(n => n.id).ToList();
                List<int> AllRelatedNewsId = _db.Tbl_NewsRelate.Where(n => NewsIds.Contains(n.RelateNewsId.Value)).Select(n => n.NewsId.Value).Distinct().ToList();

                try
                {
                    AllRelatedNewsId.AddRange(_db.Tbl_NewsRelate.Where(n => NewsIds.Contains(n.NewsId.Value) || AllRelatedNewsId.Distinct().Contains(n.NewsId.Value)).Select(n => n.RelateNewsId.Value).Distinct().ToList());
                }
                catch (Exception)
                {

                }

                var RelatedTable = _db.Tbl_NewsRelate.Where(n => NewsIds.Contains(n.NewsId.Value) || NewsIds.Contains(n.RelateNewsId.Value) || AllRelatedNewsId.Contains(n.NewsId.Value) || AllRelatedNewsId.Contains(n.RelateNewsId.Value)).ToList();


                foreach (var item in pagingNews.NewsList)
                {
                    RelatedId.Clear();
                    try
                    {
                        try
                        {
                            RelatedId.AddRange(RelatedTable.Where(n => n.RelateNewsId == item.id).Select(n => n.NewsId.Value).ToList());
                        }
                        catch
                        { }

                        try
                        {
                            RelatedId.AddRange(RelatedTable.Where(n => n.NewsId == item.id || RelatedId.Contains(n.NewsId.Value)).Select(n => n.RelateNewsId.Value).ToList());
                        }
                        catch
                        { }




                    }
                    catch
                    {

                    }

                    if (RelatedId.Distinct().Count() > 0)
                    {
                        try
                        {
                            int sub = 0;
                            foreach (var Relate in RelatedId.Distinct())
                            {
                                if (Relate == item.id)
                                {
                                    sub++;
                                    continue;
                                }
                                item.RelatedNews += Relate.ToString() + ",";
                            }

                            item.RelatedNews = item.RelatedNews.Substring(0, item.RelatedNews.Length - 1);
                            item.RelatedCount = RelatedId.Distinct().Count() - sub;
                        }
                        catch
                        {

                        }

                    }


                }

            }
            catch { }

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

            var RemoveItemList = _db.Tbl_MemberNewsSelectionForBultan.Where(n => n.MemberID == memberId && n.PanelID == userPanelId).ToList();
            foreach (var item in RemoveItemList)
            {
                _db.Tbl_MemberNewsSelectionForBultan.Remove(item);
            }
            _db.SaveChanges();
        }
    }
}