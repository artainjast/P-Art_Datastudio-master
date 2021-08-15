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

namespace P_Art.Pages.P_Art.Pages
{
    public partial class SearchAllMediaPaging : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        Class_Zaman _clsZm = new Class_Zaman();
        List<int> panelActivKeyIds = new List<int>();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        List<int?> UserPanelList = new List<int?>();
        int memberId = 0;
        int userPanelId = 0;

        List<int> panelActivInstagramKeyIds = new List<int>();
        List<int> panelActivTwitterKeyIds = new List<int>();
        List<int> panelActivTelegramKeyIds = new List<int>();
        List<int> panelActivNewsKeyIds = new List<int>();

        bool SearchIncludeInstagram = false;
        bool SearchIncludeTwitter = false;
        bool SearchIncludeTelegram = false;
        bool SearchIncludeNews = false;
        bool SearchIncludeMovie = false;

        string strSearch = "";

        int fromDate = 0;
        int toDate = 0;
        int pageSize = 25;
        int pageIndex = 1;
#pragma warning disable CS0414 // The field 'SearchAllMediaPaging.StorageType' is assigned but its value is never used
        int StorageType = 1;
#pragma warning restore CS0414 // The field 'SearchAllMediaPaging.StorageType' is assigned but its value is never used

        bool isFirst = true;

        List<PagingSearchAllMediaItem_Type> tempPagingItems = new List<PagingSearchAllMediaItem_Type>();

        PagingSearchAllMediaList_Type pagingItems = new PagingSearchAllMediaList_Type();

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

                ParminTable = _db.Tbl_Parmin.Where(p => p.ParminID == userPanelId).FirstOrDefault();

                panelActivInstagramKeyIds.AddRange(_db.Tbl_InstagramKeywords.Where(k => k.Active == true && k.PanelId == userPanelId && ParminTable.AccessInstagram == true).Select(k => k.Id).ToList());
                panelActivTelegramKeyIds.AddRange(_db.Tbl_TLPKeywords.Where(k => k.Active == true && k.ParminId == userPanelId && ParminTable.AccessTelegram == true).Select(k => k.ID).ToList());
                panelActivTwitterKeyIds.AddRange(_db.Tbl_TwitterKeywords.Where(k => k.Active == true && k.PanelID == userPanelId && ParminTable.AccessTwitter == true).Select(k => k.ID).ToList());
                panelActivNewsKeyIds.AddRange(_db.Tbl_RssKeywords.Where(k => k.Active == true && k.PanelId == userPanelId && ParminTable.AccessNews == true).Select(k => k.KeyId).ToList());

                LoadData();

                PrepareData(fromDateTime, toDateTime, "", strSearch, pageSize, pageIndex, SearchIncludeNews, SearchIncludeMovie, SearchIncludeTelegram, SearchIncludeTwitter, SearchIncludeInstagram);

                GeneratePaginationButton(pagingItems.TotaItemsCount, pageSize, pageIndex);

                GetCompletedData();

                GenerateNewsList(pagingItems);

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


            if (Request.QueryString["tl"] != null)
            {
                try
                {
                    SearchIncludeTelegram = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["tl"].ToString().Trim()));
                    TelegramCheckBox.Checked = SearchIncludeTelegram;
                    isFirst = false;

                }
                catch
                { }
            }

            if (Request.QueryString["tw"] != null)
            {
                try
                {
                    SearchIncludeTwitter = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["tw"].ToString().Trim()));
                    TwitterCheckBox.Checked = SearchIncludeTwitter;
                    isFirst = false;
                }
                catch
                { }
            }
            if (Request.QueryString["in"] != null)
            {
                try
                {
                    SearchIncludeInstagram = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["in"].ToString().Trim()));
                    InstagramCheckBox.Checked = SearchIncludeTelegram;
                    isFirst = false;
                }
                catch
                { }
            }
            if (Request.QueryString["mo"] != null)
            {
                try
                {
                    SearchIncludeMovie = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["mo"].ToString().Trim()));
                    MovieCheckBox.Checked = SearchIncludeMovie;
                    isFirst = false;
                }
                catch
                { }
            }
            if (Request.QueryString["ne"] != null)
            {
                try
                {
                    SearchIncludeNews = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["ne"].ToString().Trim()));
                    NewsCheckBox.Checked = SearchIncludeNews;
                    isFirst = false;
                }
                catch
                { }
            }


            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                txt_search.Text = strSearch.Replace("|", "+");

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

            if (isFirst)
            {
                NewsCheckBox.Checked = true;
                InstagramCheckBox.Checked = true;
                MovieCheckBox.Checked = true;
                TelegramCheckBox.Checked = true;
                TwitterCheckBox.Checked = true;
            }

        }

        private void PrepareData(long fromDateTimeIndex, long toDateTimeIndex, string keyIds, string searchString, int pageSize, int pageIndex, bool searchNews, bool searchMovie, bool searchTelegram, bool searchTwitter, bool searchInstagram)
        {

            if (pageIndex != 1)
            {
                try
                {
                    if (Session["PagingSearchItemsResult"] != null)
                    {
                        tempPagingItems = (List<PagingSearchAllMediaItem_Type>)Session["PagingSearchItemsResult"];
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                }

            }

            if (pageIndex == 1 || (pageIndex != 1 && tempPagingItems.Count == 0))
            {
                #region News
                if (SearchIncludeNews)
                {
                    try
                    {
                        IQueryable<Tbl_News> queryNewsTable = _db.Tbl_News.Where(n => n.ParminId == userPanelId && n.NewsDateTimeIndex >= fromDateTimeIndex && n.NewsDateTimeIndex <= toDateTimeIndex).Select(n => n);
                        if (!string.IsNullOrEmpty(searchString.Trim()))
                        {
                            queryNewsTable = SearchNews(queryNewsTable, searchString);
                        }

                        tempPagingItems.AddRange(queryNewsTable.Select(n => new PagingSearchAllMediaItem_Type
                        {
                            Id = n.NewsID,
                            Date = n.NewsDate,
                            DateTimeIndex = n.NewsDateTimeIndex ?? 0,
                            Description = "",
                            MediaTypeId = 1,
                            MediaType = "خبر",
                            SiteId = n.SiteID,
                            ReferenceId = 0,
                            ReferenceTitle = "",
                            Time = n.NewsTime,
                            Title = n.NewsTitle,
                            OrginalUrl = n.NewsLink,

                        }).ToList());
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                }
                #endregion

                #region Twitter
                if (searchTwitter)
                {
                    try
                    {
                        IQueryable<Tbl_TwitterPost> queryTwitterTable = _db.Tbl_TwitterPost.Where(t => t.PanelID == userPanelId && panelActivTwitterKeyIds.Contains(t.KeywordID) && t.DateTimeIndex >= fromDateTimeIndex && t.DateTimeIndex <= toDateTimeIndex).Select(t => t);
                        if (!string.IsNullOrEmpty(searchString.Trim()))
                        {
                            queryTwitterTable = SearchTwitter(queryTwitterTable, searchString);
                        }

                        tempPagingItems.AddRange(queryTwitterTable.Select(n => new PagingSearchAllMediaItem_Type
                        {
                            Id = n.ID,
                            Date = n.Date,
                            DateTimeIndex = n.DateTimeIndex,
                            Description = "",
                            MediaTypeId = 2,
                            MediaType = "توییتر",
                            SiteId = 0,
                            ReferenceId = n.UserID,
                            ReferenceTitle = n.UserName ?? n.UserScreenName,
                            Time = n.Time,
                            Title = n.Text,
                            OrginalUrl = n.Url,

                        }).ToList());
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }

                }
                #endregion

                #region Instagram
                if (searchInstagram)
                {

                    try
                    {
                        IQueryable<Tbl_InstagramPosts> queryInstagramTable = _db.Tbl_InstagramPosts.Where(i => i.PanelId == userPanelId && panelActivInstagramKeyIds.Contains(i.KeywordId) && i.DateTimeIndex >= fromDateTimeIndex && i.DateTimeIndex <= toDateTimeIndex).Select(i => i);

                        if (!string.IsNullOrEmpty(searchString.Trim()))
                        {
                            queryInstagramTable = SearchInstagram(queryInstagramTable, searchString);
                        }


                        tempPagingItems.AddRange(queryInstagramTable.Select(n => new PagingSearchAllMediaItem_Type
                        {
                            Id = n.Id,
                            DateTimeIndex = n.DateTimeIndex,
                            Description = "",
                            MediaTypeId = 3,
                            MediaType = "اینستاگرام",
                            SiteId = 0,
                            ReferenceId = n.UserId,
                            ReferenceTitle = n.FullName ?? n.UserName,
                            Title = n.CaptionText,
                            OrginalUrl = n.PostUrl,


                        }).ToList());
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }

                }

                #endregion

                #region Telegram
                if (searchTelegram)
                {
                    try
                    {
                        IQueryable<Tbl_TLPMessage> queryTelegramTable = _db.Tbl_TLPMessage.Where(t => t.PanelID == userPanelId && panelActivTelegramKeyIds.Contains(t.KeywordID) && t.DateTimeIndex >= fromDateTimeIndex && t.DateTimeIndex <= toDateTimeIndex).Select(t => t);
                        if (!string.IsNullOrEmpty(searchString.Trim()))
                        {
                            queryTelegramTable = SearchTelegram(queryTelegramTable, searchString);
                        }

                        tempPagingItems.AddRange(queryTelegramTable.Select(n => new PagingSearchAllMediaItem_Type
                        {
                            Id = n.ID,
                            Date = n.MessageDate,
                            DateTimeIndex = n.DateTimeIndex ?? 0,
                            Description = "",
                            MediaTypeId = 4,
                            MediaType = "تلگرام",
                            SiteId = n.PostID.Value,
                            ReferenceId = n.ChannelID ?? 0,
                            ReferenceTitle = "",
                            Time = n.MessageTime,
                            Title = n.MessageText,


                        }).ToList());
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }

                }
                #endregion

                #region Movies
                if (searchMovie)
                {
                    try
                    {

                        string fromDateString = fromDateTimeIndex.ToString().Substring(0, 8);
                        string toDateString = toDateTimeIndex.ToString().Substring(0, 8);

                        IQueryable<Tbl_Movies> queryMoviesTable = from video in _db.Tbl_Movies
                                                                  join relate in _db.Tbl_Relation_MovieParminPanel on video.MovieID equals relate.movieId
                                                                  where relate.ParminPanelId == userPanelId && video.VideoDateIndex.CompareTo(fromDateString) >= 0 && video.VideoDateIndex.CompareTo(toDateString) <= 0
                                                                  select video;


                        if (!string.IsNullOrEmpty(searchString.Trim()))
                        {
                            queryMoviesTable = SearchMovies(queryMoviesTable, searchString);
                        }
                        tempPagingItems.AddRange(queryMoviesTable.Select(n => new PagingSearchAllMediaItem_Type
                        {
                            Id = n.MovieID,
                            Date = n.VideoDate,
                            DateTimeIndex = 0,
                            Description = "",
                            MediaTypeId = 5,
                            MediaType = "ویدیو",
                            SiteId = 0,
                            ReferenceId = 0,
                            ReferenceTitle = n.NetworkName + " | " + n.ProgramName,
                            Time = n.PlayTime,
                            Title = n.Title,
                            OrginalUrlVisibility = "hide",
                            PanelUrlVisibility = "hide"
                        }).ToList());

                        foreach (var item in tempPagingItems.Where(m => m.MediaTypeId == 5))
                        {
                            item.DateTimeIndex = Convert.ToInt64(item.Date.Replace("/", "") + item.Time.Replace(":", ""));
                        }
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    { }

                }
                #endregion

                Session.Remove("PagingSearchItemsResult");
                Session.Add("PagingSearchItemsResult", tempPagingItems);
            }


            pagingItems.ItemsList = tempPagingItems
                            .OrderByDescending(n => n.DateTimeIndex)
                            .Skip(pageSize * (pageIndex - 1))
                            .Take(pageSize)
                            .ToList();

            pagingItems.TotaItemsCount = tempPagingItems.Count();


        }


        private IQueryable<Tbl_News> SearchNews(IQueryable<Tbl_News> query, string searchPhrase)
        {
            if (!string.IsNullOrEmpty(searchPhrase.Trim()))
            {
                string searchString = Class_Static.ArabicAlpha(searchPhrase);

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

                        return query.Where(n =>
                        (n.NewsTitle.Contains(str1) || n.NewsLead.Contains(str1) || n.NewsBody.Contains(str1)) &&
                        (n.NewsTitle.Contains(str2) || n.NewsLead.Contains(str2) || n.NewsBody.Contains(str2)));

                    }
                    else
                    {

                        str1 = SearchParameterList[0];
                        str2 = SearchParameterList[1];
                        str3 = SearchParameterList[2];


                        return query.Where(n =>
                        (n.NewsTitle.Contains(str1) || n.NewsLead.Contains(str1) || n.NewsBody.Contains(str1)) &&
                        (n.NewsTitle.Contains(str2) || n.NewsLead.Contains(str2) || n.NewsBody.Contains(str2)) &&
                        (n.NewsTitle.Contains(str3) || n.NewsLead.Contains(str3) || n.NewsBody.Contains(str3))
                        );

                    }
                }
                else
                {
                    return query.Where(n => (n.NewsTitle.Contains(searchString) || n.NewsLead.Contains(searchString) || n.NewsBody.Contains(searchString)));
                }
            }

            else
            {
                return query;
            }
        }

        private IQueryable<Tbl_TwitterPost> SearchTwitter(IQueryable<Tbl_TwitterPost> query, string searchPhrase)
        {
            if (!string.IsNullOrEmpty(searchPhrase.Trim()))
            {
                string searchString = searchPhrase.Replace("ي", "ی").Replace("ك", "ک");

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

                        return query.Where(n => n.Text.Contains(str1) && n.Text.Contains(str2));

                    }
                    else
                    {

                        str1 = SearchParameterList[0];
                        str2 = SearchParameterList[1];
                        str3 = SearchParameterList[2];


                        return query.Where(n => n.Text.Contains(str1) && n.Text.Contains(str2) && n.Text.Contains(str3));

                    }
                }
                else
                {
                    return query.Where(n => (n.Text.Contains(searchString)));
                }
            }

            else
            {
                return query;
            }
        }

        private IQueryable<Tbl_InstagramPosts> SearchInstagram(IQueryable<Tbl_InstagramPosts> query, string searchPhrase)
        {
            if (!string.IsNullOrEmpty(searchPhrase.Trim()))
            {
                string searchString = searchPhrase.Replace("ي", "ی").Replace("ك", "ک");

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

                        return query.Where(n => n.CaptionText.Contains(str1) && n.CaptionText.Contains(str2));

                    }
                    else
                    {

                        str1 = SearchParameterList[0];
                        str2 = SearchParameterList[1];
                        str3 = SearchParameterList[2];


                        return query.Where(n => n.CaptionText.Contains(str1) && n.CaptionText.Contains(str2) && n.CaptionText.Contains(str3));

                    }
                }
                else
                {
                    return query.Where(n => (n.CaptionText.Contains(searchString)));
                }
            }

            else
            {
                return query;
            }
        }

        private IQueryable<Tbl_TLPMessage> SearchTelegram(IQueryable<Tbl_TLPMessage> query, string searchPhrase)
        {
            if (!string.IsNullOrEmpty(searchPhrase.Trim()))
            {
                string searchString = searchPhrase.Replace("ي", "ی").Replace("ك", "ک");

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

                        return query.Where(n => n.MessageText.Contains(str1) && n.MessageText.Contains(str2));

                    }
                    else
                    {

                        str1 = SearchParameterList[0];
                        str2 = SearchParameterList[1];
                        str3 = SearchParameterList[2];


                        return query.Where(n => n.MessageText.Contains(str1) && n.MessageText.Contains(str2) && n.MessageText.Contains(str3));

                    }
                }
                else
                {
                    return query.Where(n => (n.MessageText.Contains(searchString)));
                }
            }

            else
            {
                return query;
            }
        }

        private IQueryable<Tbl_Movies> SearchMovies(IQueryable<Tbl_Movies> query, string searchPhrase)
        {
            if (!string.IsNullOrEmpty(searchPhrase.Trim()))
            {
                string searchString = Class_Static.ArabicAlpha(searchPhrase);

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

                        return query.Where(n => n.Title.Contains(str1) && n.Title.Contains(str2));

                    }
                    else
                    {

                        str1 = SearchParameterList[0];
                        str2 = SearchParameterList[1];
                        str3 = SearchParameterList[2];


                        return query.Where(n => n.Title.Contains(str1) && n.Title.Contains(str2) && n.Title.Contains(str3));

                    }
                }
                else
                {
                    return query.Where(n => (n.Title.Contains(searchString)));
                }
            }

            else
            {
                return query;
            }
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
            if (!string.IsNullOrEmpty(txt_search.Text) && !string.IsNullOrEmpty(txt_fromDate.Text) && !string.IsNullOrEmpty(txt_toDate.Text))
            {
                int index = 1;
                generateUrl(index);
            }

        }

        private void generateUrl(int index)
        {

            SearchIncludeInstagram = InstagramCheckBox.Checked;
            SearchIncludeTwitter = TwitterCheckBox.Checked;
            SearchIncludeTelegram = TelegramCheckBox.Checked;
            SearchIncludeNews = NewsCheckBox.Checked;
            SearchIncludeMovie = MovieCheckBox.Checked;

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

            if (SearchIncludeNews)
            {
                url += "ne=1&";
            }

            if (SearchIncludeMovie)
            {
                url += "mo=1&";
            }

            if (SearchIncludeTelegram)
            {
                url += "tl=1&";
            }

            if (SearchIncludeTwitter)
            {
                url += "tw=1&";
            }

            if (SearchIncludeInstagram)
            {
                url += "in=1&";
            }


            if (PageSizeDropDownList.SelectedItem.Value != null)
            {
                url += "size=" + Server.HtmlEncode(PageSizeDropDownList.SelectedItem.Value) + "&";
            }

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            Response.Redirect("/SearchAllMediaPaging/?" + url);


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


            if (SearchIncludeNews)
            {
                url += "ne=1&";
            }

            if (SearchIncludeMovie)
            {
                url += "mo=1&";
            }

            if (SearchIncludeTelegram)
            {
                url += "tl=1&";
            }

            if (SearchIncludeTwitter)
            {
                url += "tw=1&";
            }

            if (SearchIncludeInstagram)
            {
                url += "in=1&";
            }

            url += "size=" + Server.HtmlEncode(pageSize.ToString()) + "&";

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            return "/SearchAllMediaPaging/?" + url;

        }

        private void GenerateNewsList(PagingSearchAllMediaList_Type pagingItem)
        {
            pagingGridRepeater.DataSource = pagingItem.ItemsList;
            pagingGridRepeater.DataBind();
        }

        private void GetCompletedData()
        {
            List<int> siteIds = new List<int>();
            List<Tbl_Sites> sites = new List<Tbl_Sites>();


            List<long> channelIds = new List<long>();
            List<Tbl_TLPChannels> channels = new List<Tbl_TLPChannels>();

            try
            {
                siteIds = pagingItems.ItemsList.Where(n => n.MediaTypeId == 1 && n.SiteId != 0).Select(n => n.SiteId).Distinct().ToList();
                sites = _db.Tbl_Sites.Where(s => siteIds.Contains(s.SiteID)).ToList();

            }
            catch { }


            try
            {
                channelIds = pagingItems.ItemsList.Where(t => t.MediaTypeId == 4 && t.ReferenceId != 0).Select(t => t.ReferenceId).ToList();
                channels = _db.Tbl_TLPChannels.Where(c => channelIds.Contains(c.ChannelID)).ToList();
            }
            catch { }



            foreach (var item in pagingItems.ItemsList)
            {
                if (item.MediaTypeId == 1)
                {
                    try
                    {
                        item.ReferenceTitle = sites.Where(s => s.SiteID == item.SiteId).Select(s => s.SiteTitle).FirstOrDefault().Trim().Replace("ي", "ی").Replace("ك", "ک");
                    }
                    catch (Exception)
                    {

                    }
                    

                    item.PanelUrl = $"/ShowNews/{item.Id}/";

                    if (string.IsNullOrEmpty(item.OrginalUrl))
                    {
                        item.OrginalUrlVisibility = "hide";
                    }
                }

                if (item.MediaTypeId == 2)
                {
                    item.PanelUrl = $"/TwitterPostShow/{item.Id}/";
                }

                item.Title = item.Title.Trim().Replace("ي", "ی").Replace("ك", "ک");

                if (item.MediaTypeId == 3)
                {
                    item.Date = item.DateTimeIndex.ToString().Substring(0, 4) + "/" + item.DateTimeIndex.ToString().Substring(4, 2) + "/" + item.DateTimeIndex.ToString().Substring(6, 2);
                    item.Time = item.DateTimeIndex.ToString().Substring(8, 2) + ":" + item.DateTimeIndex.ToString().Substring(10, 2);

                    item.PanelUrl = $"/InstagramPostShow/{item.Id}/";

                }

                if (item.MediaTypeId == 4)
                {
                    var userId = channels.Where(c => c.ChannelID == item.ReferenceId).Select(c => c.Username).FirstOrDefault();

                    try
                    {
                        item.ReferenceTitle = channels.Where(c => c.ChannelID == item.ReferenceId).Select(c => c.ChannelTitle).FirstOrDefault().Trim().Replace("ي", "ی").Replace("ك", "ک");
                    }
                    catch (Exception)
                    {
                        
                    }
                    

                    item.PanelUrl = $"/TelegramMessageShow/{item.Id}/";

                    if (!string.IsNullOrEmpty(userId))
                    {
                        item.OrginalUrl = $"https://t.me/{userId.Trim()}/{item.SiteId.ToString().Trim()}";
                        item.OrginalUrlVisibility = "";
                    }
                    else
                    {
                        item.OrginalUrlVisibility = "hdie";
                    }
                }


                //item.DateTimeString = DiffrentDate(item.SiteType.ToString(), item.Time, item.Date);


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


        public string GetMediaTypeLogo(int MediaTypeId)
        {
            switch (MediaTypeId)
            {
                case 1:
                    return "<i class=\"far fa-newspaper fa-lg Purple\"></i>";
                case 2:
                    return "<i class=\"fab fa-twitter fa-lg twitterBlue\"></i>";
                case 3:
                    return "<i class=\"fab fa-instagram fa-lg instagramMaroon\"></i>";
                case 4:
                    return "<i class=\"fab fa-telegram fa-lg telegramBlue\"></i>";
                case 5:
                    return "<i class=\"far fa-play-circle fa-lg orange\"></i>";
                default:
                    return "";
            }
        }


        [WebMethod]
        public static PagingItemDetails_Type DetailShowItem(long itemId, int typeID)
        {
            PagingItemDetails_Type item = new PagingItemDetails_Type();

            try
            {


                if (typeID == 1)
                {
                    item = _dbStatic.Tbl_News.Where(n => n.NewsID == itemId).Select(n => new PagingItemDetails_Type
                    {

                        Id = n.NewsID,
                        MediaTypeId = typeID,
                        Title = n.NewsTitle,
                        Lead = n.NewsLead,
                        Body = n.NewsBody,
                        KeyIds = n.KeyIds,
                        KeyTitles = "",
                        MediaUrl = n.NewsPicture,

                    }).FirstOrDefault();
                }
                if (typeID == 2)
                {
                    item = _dbStatic.Tbl_TwitterPost.Where(n => n.ID == itemId).Select(n => new PagingItemDetails_Type
                    {

                        Id = n.ID,
                        MediaTypeId = typeID,
                        Title = n.Text,
                        Lead = n.Text,
                        Body = n.Text,
                        keywordId = n.KeywordID,
                        KeyTitles = "",
                        MediaUrl = n.MediaUrl,

                    }).FirstOrDefault();
                }
                if (typeID == 3)
                {
                    item = _dbStatic.Tbl_InstagramPosts.Where(n => n.Id == itemId).Select(n => new PagingItemDetails_Type
                    {

                        Id = n.Id,
                        MediaTypeId = typeID,
                        Title = n.CaptionText,
                        Lead = n.CaptionText,
                        Body = n.CaptionText,
                        keywordId = n.KeywordId,
                        KeyTitles = "",
                        MediaUrl = n.DisplayUrl,

                    }).FirstOrDefault();
                }
                if (typeID == 4)
                {
                    item = (from telegram in _dbStatic.Tbl_TLPMessage
                            join channel in _dbStatic.Tbl_TLPChannels on telegram.ChannelID equals channel.ChannelID
                            where telegram.ID == itemId
                            select new PagingItemDetails_Type
                            {
                                Id = telegram.ID,
                                MediaTypeId = typeID,
                                Title = telegram.MessageText,
                                Lead = telegram.MessageText,
                                Body = telegram.MessageText,
                                keywordId = telegram.KeywordID,
                                KeyTitles = "",
                                MediaUrl = "",
                            }).FirstOrDefault();

                }

                if (typeID == 5)
                {
                    item = _dbStatic.Tbl_Movies.Where(m => m.MovieID == itemId).Select(n => new PagingItemDetails_Type
                    {

                        Id = n.MovieID,
                        MediaTypeId = typeID,
                        Title = n.Title,
                        Lead = n.Title,
                        Body = n.Title,
                        KeyIds = "",
                        KeyTitles = "",
                        MediaUrl = n.VideoPath,

                    }).FirstOrDefault();
                }




                if (string.IsNullOrEmpty(item.Body))
                {
                    item.Body = item.Lead;
                }

                item.Body = AdjucstText(item.Body).Replace("ي", "ی").Replace("ك", "ک") + " ";

                List<int> KeyIdList = new List<int>();
                if (typeID == 1)
                {
                    var keyIdStringList = item.KeyIds.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var key in keyIdStringList)
                    {
                        KeyIdList.Add(Convert.ToInt32(key));
                    }

                }

                List<string> Keywords = new List<string>();

                if (typeID != 5)
                {
                    if (typeID == 1)
                    {
                        Keywords = _dbStatic.Tbl_RssKeywords.Where(k => KeyIdList.Contains(k.KeyId)).Select(k => k.KeywordName).ToList();
                    }
                    if (typeID == 2)
                    {
                        Keywords = _dbStatic.Tbl_TwitterKeywords.Where(k => k.ID == item.keywordId).Select(k => k.Title).ToList();
                    }
                    if (typeID == 3)
                    {
                        Keywords = _dbStatic.Tbl_InstagramKeywords.Where(k => k.Id == item.keywordId).Select(k => k.Title).ToList();
                    }
                    if (typeID == 4)
                    {
                        Keywords = _dbStatic.Tbl_TLPKeywords.Where(k => k.ID == item.keywordId).Select(k => k.Title).ToList();
                    }

                    List<string> KeywordList = new List<string>();
                    List<string> UniqueKeywordList = new List<string>();

                    item.KeyTitles = "<div class=\"TagContainer\">";
                    foreach (var key in Keywords)
                    {
                        item.KeyTitles += $"<span class=\"KeywordTag\"><i class=\"fas fa-key\"></i>{key.Replace("ي", "ی").Replace("ك", "ک")}</span>";

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

                    item.KeyTitles += "</div>";

                    UniqueKeywordList.AddRange(KeywordList.Distinct());

                    foreach (var key in UniqueKeywordList.OrderBy(k => k.Length))
                    {

                        item.Body = item.Body.Replace($" {key} ", $" <span class=\"highlight\">{key}</span> ");
                    }

                }



                item.Body = Class_Static.EnglishToPersianNumber(item.Body);


            }
            catch (Exception)
            {
                return null;
            }

            return item;
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



    }
}