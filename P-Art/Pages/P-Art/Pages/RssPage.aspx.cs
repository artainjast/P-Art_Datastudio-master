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
using System.Xml;
using System.ServiceModel.Syndication;
using System.Net;
using static PArt.Pages.P_Art.Repository.Class_Static;
using System.Text.RegularExpressions;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class RssPage : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _dbDDn = new DB_NewsCenterEntities();
        Class_Zaman _clsZm = new Class_Zaman();
        List<int?> UserPanelList = new List<int?>();
        int memberId = 0;
        int userPanelId = 0;
        string strSearch = "";
        List<ModelNews.Tbl_Sites> SiteList;
        int pageSize = 25;
        int pageIndex = 1;
        int siteType = 0;
        int fromDate = 0;
        int toDate = 0;
        int time = 0;
        Int64 fromDateTime = 0;
        Int64 toDateTime = 0;
        PagingRSSNewsList_Type pagingNews = new PagingRSSNewsList_Type();
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            if (!IsPostBack)
            {

                memberId = Class_Layer.CurrentUser().MemberID;

                userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
                SiteList = _dbDDn.Tbl_Sites.ToList();
                LoadData();

                Class_Keywords _clsKeyword = new Class_Keywords();
                var keywordsList = new List<Tbl_RssKeywords>();
                keywordsList = _clsKeyword.GetRssKeywordByPanelIds(Class_Layer.UserPanels());

                PrepareNews(fromDateTime, toDateTime, strSearch, pageSize, pageIndex, siteType, keywordsList);

                GeneratePaginationButton(pagingNews.TotalNewsCount, pageSize, pageIndex);

                BindGrid(pagingNews);
            }
        }
        private void LoadData()
        {
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
                txt_search.Text = strSearch;
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
        private void PrepareNews(long fromDateTimeIndex, long toDateTimeIndex, string searchString, int pageSize, int pageIndex, int SiteType, List<Tbl_RssKeywords> keywordsList)
        {
            List<int> newsIdtList = new List<int>();
            List<int> newsIdResultList = new List<int>();

            List<int> siteIds = new List<int>();

            PagingRSSNewsList_Type Result = new PagingRSSNewsList_Type();


            List<PagingRssNewsDetails_Type> query = new List<PagingRssNewsDetails_Type>();
            //List<Tbl_Rss> rssList = _dbDDn.Tbl_Rss.ToList();

            //foreach (var rss in rssList)
            //{
            List<PagingRssNewsDetails_Type> listItem = ReadNews(strSearch, fromDateTimeIndex, toDateTimeIndex);

            query.AddRange(listItem);
            //}
            List<PagingRssNewsDetails_Type> combined = new List<PagingRssNewsDetails_Type>();
            if (!string.IsNullOrEmpty(searchString.Trim()))
            {
                searchString = Class_Static.ArabicAlpha(searchString);

#pragma warning disable CS0219 // The variable 'str1' is assigned but its value is never used
                string str1 = "";
#pragma warning restore CS0219 // The variable 'str1' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'str2' is assigned but its value is never used
                string str2 = "";
#pragma warning restore CS0219 // The variable 'str2' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'str3' is assigned but its value is never used
                string str3 = "";
#pragma warning restore CS0219 // The variable 'str3' is assigned but its value is never used

                foreach (var sn in query)
                {
                    string merge = sn.Title + " " + sn.Lead + " " + sn.Body;
                    merge = merge.Replace("-", " ");
                    merge = merge.Replace(".", " . ");
                    merge = merge.Replace(":", " : ");
                    merge = merge.Replace("?", " ? ");
                    merge = merge.Replace("!", " ! ");
                    merge = merge.Replace("،", " ، ");
                    merge = merge.Replace(",", " , ");
                    merge = merge.Replace("»", " » ");
                    merge = merge.Replace("«", " « ");
                    merge = merge.Replace("(", " ( ");
                    merge = merge.Replace(")", " ) ");
                    merge = merge.Replace("}", " } ");
                    merge = merge.Replace("{", " { ");
                    merge = merge.Replace("*", " * ");
                    merge = merge.Replace("<", " < ");
                    merge = merge.Replace(">", " > ");
                    merge = merge.Replace("/", " / ");

                    merge = NormalText(merge);

                    merge = Class_Static.ArabicAlpha(merge);

                    if (CheckBlocks(merge, searchString) == true)
                    {
                        sn.Title = HighLightKeywordsRssNews(sn.Title, keywordsList);
                        combined.Add(sn);
                    }

                }

                //query = query.Where(n => (n.Title.Contains(searchString))).ToList();
                //combined.AddRange(query);

            }
            else
            {
                #region check keywords
                foreach (var k in keywordsList)
                {
                    if (k.KeywordName.Contains("+"))
                    {
                        foreach (var n in query)
                        {
                            string merge = n.Title + " " + n.Lead + " " + n.Body;
                            merge = merge.Replace("-", " ");
                            merge = merge.Replace(".", " . ");
                            merge = merge.Replace(":", " : ");
                            merge = merge.Replace("?", " ? ");
                            merge = merge.Replace("!", " ! ");
                            merge = merge.Replace("،", " ، ");
                            merge = merge.Replace(",", " , ");
                            merge = merge.Replace("»", " » ");
                            merge = merge.Replace("«", " « ");
                            merge = merge.Replace("(", " ( ");
                            merge = merge.Replace(")", " ) ");
                            merge = merge.Replace("}", " } ");
                            merge = merge.Replace("{", " { ");
                            merge = merge.Replace("*", " * ");
                            merge = merge.Replace("<", " < ");
                            merge = merge.Replace(">", " > ");
                            merge = merge.Replace("/", " / ");

                            merge = NormalText(merge);

                            merge = Class_Static.ArabicAlpha(merge);

                            if (CheckBlocks(merge, Class_Static.ArabicAlpha(k.KeywordName.Split('+')[0])) == true &&
                                CheckBlocks(merge, Class_Static.ArabicAlpha(k.KeywordName.Split('+')[1])) == true)
                            {
                                if (!combined.Any(s => s.id == n.id))
                                    combined.Add(n);
                            }
                        }
                        //combined.AddRange(query.Where(n => (n.Title.Contains(Class_Static.ArabicAlpha(k.KeywordName).Split('+')[0])) && (n.Title.Contains(Class_Static.ArabicAlpha(k.KeywordName).Split('+')[1]))).ToList());
                    }
                    else
                    {
                        foreach (var n in query)
                        {
                            string merge = n.Title + " " + n.Lead + " " + n.Body;
                            merge = merge.Replace("-", " ");
                            merge = merge.Replace(".", " . ");
                            merge = merge.Replace(":", " : ");
                            merge = merge.Replace("?", " ? ");
                            merge = merge.Replace("!", " ! ");
                            merge = merge.Replace("،", " ، ");
                            merge = merge.Replace(",", " , ");
                            merge = merge.Replace("»", " » ");
                            merge = merge.Replace("«", " « ");
                            merge = merge.Replace("(", " ( ");
                            merge = merge.Replace(")", " ) ");
                            merge = merge.Replace("}", " } ");
                            merge = merge.Replace("{", " { ");
                            merge = merge.Replace("*", " * ");
                            merge = merge.Replace("<", " < ");
                            merge = merge.Replace(">", " > ");
                            merge = merge.Replace("/", " / ");

                            merge = NormalText(merge);

                            merge = Class_Static.ArabicAlpha(merge);

                            if (CheckBlocks(merge, Class_Static.ArabicAlpha(k.KeywordName)) == true)
                            {
                                if (!combined.Any(s => s.id == n.id))
                                {
                                    n.Title = HighLightKeywordsRssNews(n.Title, keywordsList);
                                    combined.Add(n);
                                }
                            }


                        }
                        //combined.AddRange(query.Where(n => (n.Title.Contains(Class_Static.ArabicAlpha(k.KeywordName)))).ToList());
                    }
                }
                #endregion
            }

            combined = combined.DistinctBy(note => note.id).ToList();

            pagingNews.TotalNewsCount = combined.Count();
            pagingNews.NewsList = combined
                .OrderByDescending(n => n.DateTimeIndex)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .Select(n => new PagingRssNewsDetails_Type
                {
                    id = n.id,
                    Title = n.Title,
                    DateTimeIndex = n.DateTimeIndex,
                    SiteID = n.SiteID,
                    SiteName = n.SiteName,
                    Date = n.Date,
                    Time = n.Time,
                    SourceLink = n.SourceLink,
                    SiteType = n.SiteType,
                    Lead = n.Lead,
                    Body = n.Body,
                    DateTimeString = n.DateTimeString,
                    NewsType = n.NewsType,
                    NewsValue = n.NewsValue
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

            Response.Redirect("/RssNewsList/?" + url);
        }
        private string generatePaginationLink(int index)
        {

            string url = "";

            url += "size=" + Server.HtmlEncode(pageSize.ToString()) + "&";

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";
            url += "st=" + Server.HtmlEncode(siteType.ToString()) + "&";
            url += "keyword=" + Server.HtmlEncode(strSearch.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            return "/RssNewsList/?" + url;

        }
        private void BindGrid(PagingRSSNewsList_Type pagingNews)
        {
            if (siteType != 0)
                pagingNews.NewsList = pagingNews.NewsList.Where(i => i.SiteType == siteType).ToList();
            pagingGridRepeater.DataSource = pagingNews.NewsList;
            pagingGridRepeater.DataBind();
        }
        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            int index = 1;
            generateUrl(index);
        }

        public static string ChangeIcon(string sitetype)
        {

            if (sitetype == "1")
                return "fas fa-rss-square";
            else
                return "far fa-newspaper";

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
        public List<PagingRssNewsDetails_Type> ReadRssFeed(string url, int siteId, string search)
        {
            ModelNews.Tbl_Sites site = SiteList.SingleOrDefault(i => i.SiteID == siteId);
            List<PagingRssNewsDetails_Type> news = new List<PagingRssNewsDetails_Type>();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            try
            {
                XmlReader reader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    try
                    {
                        PagingRssNewsDetails_Type type = new PagingRssNewsDetails_Type();
                        type.id = Convert.ToInt32(item.Id);
                        type.Title = item.Title.Text;
                        type.Lead = item.Summary.Text;
                        type.SiteID = site.SiteID;
                        type.SiteName = site.SiteTitle;
                        type.SiteType = (int)site.SiteType;
                        //DateTime date = Convert.ToDateTime(item.PublishDate);
                        type.Date = _clsZm.MiladiToShamsi(item.PublishDate.Year + "/" + item.PublishDate.Month + "/" + item.PublishDate.Day).Split(' ')[0];
                        type.Time = item.PublishDate.Hour + ":" + item.PublishDate.Minute;
                        type.DateTimeIndex = Convert.ToInt64(type.Date.Replace("/", "") + type.Time.Replace(":", ""));
                        type.DateTimeString = type.Date + " " + type.Time;
                        type.SourceLink = item.Links[0].Uri.AbsoluteUri.ToString();
                        if (type.Title.Contains(search) || type.Lead.Contains(search))
                            news.Add(type);
                    }
                    catch { continue; }
                }
            }
            catch { }
            return news;
        }
        public List<PagingRssNewsDetails_Type> ReadNews(string search, long fromDatetimeIndex, long toDatetimeIndex)
        {
            //
            List<PagingRssNewsDetails_Type> news = new List<PagingRssNewsDetails_Type>();
            try
            {
                _dbDDn = new DB_NewsCenterEntities();
                var allNews = _dbDDn.Tbl_News_Rss.Where(i => i.NewsDateTimeIndex > fromDatetimeIndex && i.NewsDateTimeIndex < toDatetimeIndex).ToList();
                foreach (var item in allNews)
                {
                    try
                    {
                        ModelNews.Tbl_Sites site = SiteList.SingleOrDefault(i => i.SiteID == item.SiteId);
                        PagingRssNewsDetails_Type type = new PagingRssNewsDetails_Type();
                        type.id = Convert.ToInt32(item.NewsId);
                        type.Title = item.NewsTitle;
                        type.Lead = item.NewsLead;
                        type.SiteID = item.SiteId;
                        type.SiteName = site.SiteTitle;
                        type.SiteType = (int)item.SiteType;
                        //DateTime date = Convert.ToDateTime(item.PublishDate);
                        type.Date = item.NewsDate;
                        type.Time = item.NewsTime;
                        type.DateTimeIndex = item.NewsDateTimeIndex;
                        type.DateTimeString = type.Date + " " + type.Time;
                        type.SourceLink = item.SourceLink;
                        if (type.Title.Contains(search) || type.Lead.Contains(search))
                            news.Add(type);
                    }
                    catch { continue; }
                }
            }
            catch { }
            return news;
        }
        public List<PagingRssNewsDetails_Type> ReadRssHandle(string url, int siteId)
        {
            ModelNews.Tbl_Sites site = SiteList.SingleOrDefault(i => i.SiteID == siteId);
            List<PagingRssNewsDetails_Type> news = new List<PagingRssNewsDetails_Type>();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            try
            {

                {
                    var lst = new List<Type_Rss>();
                    //doc = htmlWeb.Load(RssUrl);
                    var Rssdata = new MyWebClient().DownloadString(url);
                    Rssdata = Rssdata.Substring(Rssdata.IndexOf("<item>"));
                    Rssdata = Rssdata.Substring(Rssdata.IndexOf("<link>"));

                    try
                    {
                        var nodes = Rssdata.Split(new string[] { "<link>" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var item in nodes)
                        {

                            try
                            {
                                var dr = new Type_Rss();

                                dr.Link = HttpUtility.UrlPathEncode(item.Substring(0, item.IndexOf("</link>")));
                                dr.SiteId = siteId;
                                lst.Add(dr);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }

                    catch
                    {

                    }
                }



















            }
            catch { }
            return news;
        }
        public static string NormalText(string strin)
        {
            strin = Class_Static.ArabicAlpha(strin);
            string html = strin;
            string result = StripTagsRegex(html).Trim();
            //string result = HtmlStrip(html).Trim();


            result = result.Replace('۰', '0');
            result = result.Replace('۱', '1');
            result = result.Replace('۲', '2');
            result = result.Replace('۳', '3');
            result = result.Replace('۴', '4');
            result = result.Replace('۵', '5');
            result = result.Replace('۶', '6');
            result = result.Replace('۷', '7');
            result = result.Replace('۸', '8');
            result = result.Replace('۹', '9');



            result = result.Replace("\r", " ").Replace("\n", " ");
            result = Regex.Replace(result, @"\s+", " ");
            result = result.ToString().Replace("'", "");
            string regex = "&(.*?);";
            RegexOptions options = (RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Regex reg = new Regex(regex, options);

            result = reg.Replace(result, " ");

            char HalfSpace = (char)8204;
            char space = (char)' ';
            result = result.Replace(HalfSpace, space);
            System.Text.RegularExpressions.Regex reegex = new System.Text.RegularExpressions.Regex(string.Format("\\{0}.*?\\{1}", "{", "}"));
            result = reegex.Replace(result, string.Empty);

            return result;
        }
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        public static bool CheckBlocks(string newsBody, string currentKey)
        {
            if (newsBody.IndexOf(" " + currentKey + " ") > -1)
                return true;
            else return false;
        }
        [WebMethod]
        public static PagingNewMediaNewsDetails_Type DetailShowNews(string NewsID)
        {
            PagingNewMediaNewsDetails_Type News = new PagingNewMediaNewsDetails_Type();

            try
            {
                int id = Convert.ToInt32(NewsID);

                DB_NewsCenterEntities _dbDDn = new DB_NewsCenterEntities();
                int userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
                var keywordPanelList = _dbDDn.Tbl_RssKeywords.Where(i => i.PanelId == userPanelId).ToList();

                News = _dbDDn.Tbl_News_Rss.Where(n => n.NewsId == id).Select(n => new PagingNewMediaNewsDetails_Type
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

                News.Body = Class_Static.EnglishToPersianNumber(News.Body);

                News.Body = HighLightKeywordsRssNews(News.Body, keywordPanelList);
                News.Title = HighLightKeywordsRssNews(News.Title, keywordPanelList);

                News.Body = News.Body.Replace("ي", "ی").Replace("ك", "ک") + " ";

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return null;
            }

            return News;
        }
        public static string HighLightKeywordsRssNews(string input, List<Tbl_RssKeywords> keywords)
        {
           
            input = input.Replace("-", "");
            input = input.Replace(".", "");
            input = input.Replace(":", "");
            input = input.Replace("?", "");
            input = input.Replace("!", "");
            input = input.Replace("،", "");
            input = input.Replace(",", "");
            input = input.Replace("»", "");
            input = input.Replace("«", "");
            input = input.Replace("(", "");
            input = input.Replace(")", "");
            input = input.Replace("}", "");
            input = input.Replace("{", "");
            input = input.Replace("*", "");
            input = input.Replace("<", "");
            input = input.Replace(">", "");
            input = input.Replace("/", "");

            var splitedWords = input.Split(' ');

            foreach (var k in keywords)
            {
                foreach (var s in splitedWords)
                {
                    if (k.KeywordName.IndexOf("+") > -1)
                    {
                        foreach (var kk in k.KeywordName.Split('+'))
                        {
                            if (kk == s)
                                input = input.Replace(kk, "<b style='color:#F00'>" + kk + "</b>");
                        }
                    }
                    else
                    {
                        if (k.KeywordName == s)
                            input = input.Replace(k.KeywordName, "<b style='color:#F00'>" + k.KeywordName + "</b>");
                    }

                }

            }


            return input;
        }
    }
}