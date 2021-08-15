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
using System.Text;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class SearchAllMedia : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<SearchAllMedia_Type> SearchResultList = new List<SearchAllMedia_Type>();
        List<int?> UserPanelList = new List<int?>();
        Class_Zaman _clsZm = new Class_Zaman();
#pragma warning disable CS0169 // The field 'SearchAllMedia.staticfromDateIndex' is never used
        static int staticfromDateIndex;
#pragma warning restore CS0169 // The field 'SearchAllMedia.staticfromDateIndex' is never used
#pragma warning disable CS0169 // The field 'SearchAllMedia.statictoDateIndex' is never used
        static int statictoDateIndex;
#pragma warning restore CS0169 // The field 'SearchAllMedia.statictoDateIndex' is never used
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        List<int> panelActivInstagramKeyIds = new List<int>();
        List<int> panelActivTwitterKeyIds = new List<int>();
        List<int> panelActivTelegramKeyIds = new List<int>();
        List<int> panelActivNewsKeyIds = new List<int>();

        bool SearchIncludeInstagram = false;
        bool SearchIncludeTwitter = false;
        bool SearchIncludeTelegram = false;
        bool SearchIncludeNews = false;
        bool SearchIncludeMovie = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            UserPanelList = Class_Layer.UserPanels();
            ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            panelActivInstagramKeyIds.AddRange(_db.Tbl_InstagramKeywords.Where(k => k.Active == true && k.PanelId == ParminTable.ParminID && ParminTable.AccessInstagram == true).Select(k => k.Id).ToList());
            panelActivTelegramKeyIds.AddRange(_db.Tbl_TLPKeywords.Where(k => k.Active == true && k.ParminId == ParminTable.ParminID && ParminTable.AccessTelegram == true).Select(k => k.ID).ToList());
            panelActivTwitterKeyIds.AddRange(_db.Tbl_TwitterKeywords.Where(k => k.Active == true && k.PanelID == ParminTable.ParminID && ParminTable.AccessTwitter == true).Select(k => k.ID).ToList());
            panelActivNewsKeyIds.AddRange(_db.Tbl_News.Where(k => k.Active == true && k.ParminId == ParminTable.ParminID && ParminTable.AccessNews == true).Select(k => k.NewsID).ToList());
            if (!IsPostBack)
            {
                string searchStrig = "";
                string keyIds = "";
                bool isFilter = false;


                if (Request.QueryString["keyword"] != null)
                {
                    searchStrig = Request.QueryString["keyword"].ToString().Replace("ي", "ی").Replace("ك", "ک");
                    txt_search.Text = searchStrig.Replace("|", "+").Trim();
                    isFilter = true;
                }

                long fromDateTime = long.Parse(_clsZm.Today().Replace("/", "") + "0000");
                long toDateTime = long.Parse(_clsZm.Today().Replace("/", "") + "2500");

                if (Request.QueryString["from"] != null)
                {
                    try
                    {
                        fromDateTime = long.Parse(Request.QueryString["from"].ToString());
                        isFilter = true;

                    }
                    catch
                    { }

                }
                if (Request.QueryString["to"] != null)
                {
                    try
                    {
                        toDateTime = long.Parse(Request.QueryString["to"].ToString());
                        isFilter = true;
                    }
                    catch
                    { }

                }

                if (Request.QueryString["tl"] != null)
                {
                    try
                    {
                        SearchIncludeTelegram = bool.Parse(Request.QueryString["tl"].ToString().Trim());
                        TelegramCheckBox.Checked = SearchIncludeTelegram;
                        isFilter = true;
                    }
                    catch
                    { }
                }

                if (Request.QueryString["tw"] != null)
                {
                    try
                    {
                        SearchIncludeTwitter = bool.Parse(Request.QueryString["tw"].ToString().Trim());
                        TwitterCheckBox.Checked = SearchIncludeTwitter;
                        isFilter = true;
                    }
                    catch
                    { }
                }
                if (Request.QueryString["in"] != null)
                {
                    try
                    {
                        SearchIncludeInstagram = bool.Parse(Request.QueryString["in"].ToString().Trim());
                        InstagramCheckBox.Checked = SearchIncludeTelegram;
                        isFilter = true;
                    }
                    catch
                    { }
                }
                if (Request.QueryString["mo"] != null)
                {
                    try
                    {
                        SearchIncludeMovie = bool.Parse(Request.QueryString["mo"].ToString().Trim());
                        MovieCheckBox.Checked = SearchIncludeMovie;
                        isFilter = true;
                    }
                    catch
                    { }
                }
                if (Request.QueryString["ne"] != null)
                {
                    try
                    {
                        SearchIncludeNews = bool.Parse(Request.QueryString["ne"].ToString().Trim());
                        NewsCheckBox.Checked = SearchIncludeNews;
                        isFilter = true;
                    }
                    catch
                    { }
                }


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

                txt_fromDate.Text = fromDateTime.ToString().Substring(0, 4) + "/" + fromDateTime.ToString().Substring(4, 2) + "/" + fromDateTime.ToString().Substring(6, 2);
                txt_toDate.Text = toDateTime.ToString().Substring(0, 4) + "/" + toDateTime.ToString().Substring(4, 2) + "/" + toDateTime.ToString().Substring(6, 2);

                string controlTime = "";
                if ((toDateTime / 100) % 100 > 24)
                {
                    controlTime = "";
                }
                else
                {
                    controlTime = toDateTime.ToString().Substring(8, 2) + ":";
                }
                if (string.IsNullOrEmpty(controlTime))
                {
                    txt_fromHour.Text = "";
                    txt_toHour.Text = "";
                }
                else
                {
                    controlTime += toDateTime.ToString().Substring(10, 2);
                    txt_toHour.Text = controlTime;
                    txt_fromHour.Text = fromDateTime.ToString().ToString().Substring(8, 2) + ":" + fromDateTime.ToString().Substring(10, 2);
                }

                List<int> Keys = new List<int>();
                foreach (var keySpil in keyIds.Split(','))
                {
                    try
                    {
                        Keys.Add(Convert.ToInt32(keySpil));
                    }
                    catch
                    {
                        continue;
                    }
                }

                //Class_Layer.CheckSession();
                UserPanelList = Class_Layer.UserPanels();
                var parmin = UserPanelList[0].Value + "";
                ParminId.Value = parmin;

                PrepareData(fromDateTime, toDateTime, searchStrig, isFilter, SearchIncludeNews, SearchIncludeMovie, SearchIncludeTelegram, SearchIncludeTwitter, SearchIncludeInstagram);

            }
        }


        private void PrepareData(long fromDateTimeIndex, long toDateTimeIndex, string searchString, bool isFilter, bool searchNews, bool searchMovie, bool searchTelegram, bool searchTwitter, bool searchInstagram)
        {
            if (string.IsNullOrEmpty(searchString))
                return;
            List<int> newsListId = new List<int>();
            List<int> movieListId = new List<int>();
            List<long> telegramListId = new List<long>();
            List<long> twitterListId = new List<long>();
            List<long> instagramListId = new List<long>();

            if (searchNews)
            {
                newsListId = (from news in _db.Tbl_News
                              where UserPanelList.Contains(news.ParminId) && news.NewsDateTimeIndex >= fromDateTimeIndex && news.NewsDateTimeIndex <= toDateTimeIndex
                              select news.NewsID).ToList();
            }

            if (searchInstagram)
            {
                instagramListId = (from Post in _db.Tbl_InstagramPosts
                                   where UserPanelList.Contains(Post.PanelId) && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex && Post.Active == true
                                   select Post.Id).ToList();
            }

            if (searchTelegram)
            {
                telegramListId = (from Massage in _db.Tbl_TLPMessage
                                  where UserPanelList.Contains(Massage.PanelID) && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                                  select Massage.ID).ToList();
            }

            if (searchTwitter)
            {
                twitterListId = (from Post in _db.Tbl_TwitterPost
                                 where UserPanelList.Contains(Post.PanelID) && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex && Post.Active == true
                                 select Post.ID).ToList();
            }

            if (searchMovie)
            {
                string fromDateString = fromDateTimeIndex.ToString().Substring(0, 8);
                string toDateString = toDateTimeIndex.ToString().Substring(0, 8);

                movieListId = (from video in _db.Tbl_Movies
                               join relate in _db.Tbl_Relation_MovieParminPanel on video.MovieID equals relate.movieId
                               where UserPanelList.Contains(relate.ParminPanelId) && video.VideoDateIndex.CompareTo(fromDateString) >= 0 && video.VideoDateIndex.CompareTo(toDateString) <= 0
                               select video.MovieID).ToList();
            }


            if (newsListId.Count > 0)
            { SearchResultList.AddRange(SearchPhraseInNews(newsListId, searchString)); }

            if (movieListId.Count > 0)
                SearchResultList.AddRange(SearchPhraseInMovie(movieListId, searchString));

            if (telegramListId.Count > 0)
                SearchResultList.AddRange(SearchPhraseInTelegram(telegramListId, searchString));

            if (twitterListId.Count > 0)
                SearchResultList.AddRange(SearchPhraseInTwitter(twitterListId, searchString));

            if (instagramListId.Count > 0)
                SearchResultList.AddRange(SearchPhraseInInstagram(instagramListId, searchString));

            //Session.Add("AllMediaSearchList", SearchResultList);

            NewsCheckBox.Checked = searchNews;
            MovieCheckBox.Checked = searchMovie;
            TwitterCheckBox.Checked = searchTwitter;
            TelegramCheckBox.Checked = searchTelegram;
            InstagramCheckBox.Checked = searchInstagram;


            SearchAllMediaRepeater.DataSource = SearchResultList.OrderByDescending(n => n.DateTimeIndex);
            SearchAllMediaRepeater.DataBind();
        }


        private List<SearchAllMedia_Type> SearchPhraseInInstagram(List<long> InstagramIds, string searchText)
        {
            var PersianSearchText = searchText.Replace("ي", "ی").Replace("ك", "ک");
            List<long> result = new List<long>();
            string str1 = "";
            string str2 = "";
            string str3 = "";



            if (PersianSearchText.Contains("|"))
            {
                var SearchParameterList = PersianSearchText.Split('|');


                if (SearchParameterList.Count() == 2)
                {
                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];

                    result = _db.Tbl_InstagramPosts.Where(n => panelActivInstagramKeyIds.Contains(n.KeywordId) && InstagramIds.Contains(n.Id) && n.CaptionText.Contains(str1) && n.CaptionText.Contains(str2)).Select(n => n.Id).ToList();

                }
                else if (SearchParameterList.Count() == 3)
                {

                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    str3 = SearchParameterList[2];


                    result = _db.Tbl_InstagramPosts.Where(n => panelActivInstagramKeyIds.Contains(n.KeywordId) && InstagramIds.Contains(n.Id) && n.CaptionText.Contains(str1) && n.CaptionText.Contains(str2) && n.CaptionText.Contains(str3)).Select(n => n.Id).ToList();

                }

            }
            else
            {
                result = _db.Tbl_InstagramPosts.Where(n => panelActivInstagramKeyIds.Contains(n.KeywordId) && InstagramIds.Contains(n.Id) && n.CaptionText.Contains(PersianSearchText)).Select(n => n.Id).ToList();
            }

            var TelegramList = _db.Tbl_InstagramPosts.Where(n => result.Contains(n.Id)).ToList();
            List<SearchAllMedia_Type> ResultList = new List<SearchAllMedia_Type>();
            foreach (var n in TelegramList)
            {
                ResultList.Add(new SearchAllMedia_Type
                {
                    id = n.Id,
                    DateTimeIndex = n.DateTimeIndex,
                    Description = "",
                    Keywords = n.KeywordId.ToString(),
                    MediaType = "اینستاگرام",
                    MediaUrl = n.DisplayUrl,
                    Reference = n.FullName,
                    Title = n.CaptionText,
                    Url = n.PostUrl
                });
            }

            return ResultList;
        }
        private List<SearchAllMedia_Type> SearchPhraseInTelegram(List<long> TelegramIds, string searchText)
        {
            var PersianSearchText = searchText.Replace("ي", "ی").Replace("ك", "ک");
            List<long> result = new List<long>();
            string str1 = "";
            string str2 = "";
            string str3 = "";

            if (PersianSearchText.Contains("|"))
            {
                var SearchParameterList = PersianSearchText.Split('|');


                if (SearchParameterList.Count() == 2)
                {
                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];

                    result = _db.Tbl_TLPMessage.Where(n => panelActivTelegramKeyIds.Contains(n.KeywordID) && TelegramIds.Contains(n.ID) && n.MessageText.Contains(str1) && n.MessageText.Contains(str2)).Select(n => n.ID).ToList();

                }
                else if (SearchParameterList.Count() == 3)
                {

                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    str3 = SearchParameterList[2];

                    result = _db.Tbl_TLPMessage.Where(n => panelActivTelegramKeyIds.Contains(n.KeywordID) && TelegramIds.Contains(n.ID) && n.MessageText.Contains(str1) && n.MessageText.Contains(str2) && n.MessageText.Contains(str3)).Select(n => n.ID).ToList();

                }

            }
            else
            {
                result = _db.Tbl_TLPMessage.Where(n => panelActivTelegramKeyIds.Contains(n.KeywordID) && TelegramIds.Contains(n.ID) && n.MessageText.Contains(PersianSearchText)).Select(n => n.ID).ToList();
            }

            var TelegramList = _db.Tbl_TLPMessage.Where(n => result.Contains(n.ID)).ToList();
            List<SearchAllMedia_Type> ResultList = new List<SearchAllMedia_Type>();
            foreach (var n in TelegramList)
            {
                ResultList.Add(new SearchAllMedia_Type
                {
                    id = n.ID,
                    DateTimeIndex = n.DateTimeIndex ?? 0,
                    Description = "",
                    Keywords = n.KeywordID.ToString(),
                    MediaType = "تلگرام",
                    MediaUrl = n.MediaID.ToString(),
                    Reference = n.ChannelID.ToString(),
                    Title = n.MessageText,
                    Url = ""
                });
            }
            return ResultList;
        }


        private List<SearchAllMedia_Type> SearchPhraseInTwitter(List<long> TwitterIds, string searchText)
        {
            var PersianSearchText = searchText.Replace("ي", "ی").Replace("ك", "ک");
            List<long> result = new List<long>();
            string str1 = "";
            string str2 = "";
            string str3 = "";

            if (PersianSearchText.Contains("|"))
            {
                var SearchParameterList = PersianSearchText.Split('|');


                if (SearchParameterList.Count() == 2)
                {
                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];

                    result = _db.Tbl_TwitterPost.Where(n => panelActivTwitterKeyIds.Contains(n.KeywordID) && TwitterIds.Contains(n.ID) && n.Text.Contains(str1) && n.Text.Contains(str2)).Select(n => n.ID).ToList();

                }
                else if (SearchParameterList.Count() == 3)
                {

                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    str3 = SearchParameterList[2];


                    result = _db.Tbl_TwitterPost.Where(n => panelActivTwitterKeyIds.Contains(n.KeywordID) && TwitterIds.Contains(n.ID) && n.Text.Contains(str1) && n.Text.Contains(str2) && n.Text.Contains(str3)).Select(n => n.ID).ToList();

                }

            }
            else
            {
                result = _db.Tbl_TwitterPost.Where(n => panelActivTwitterKeyIds.Contains(n.KeywordID) && TwitterIds.Contains(n.ID) && n.Text.Contains(PersianSearchText)).Select(n => n.ID).ToList();
            }

            var TwitterList = _db.Tbl_TwitterPost.Where(n => result.Contains(n.ID)).ToList();
            List<SearchAllMedia_Type> ResultList = new List<SearchAllMedia_Type>();
            foreach (var n in TwitterList)
            {
                ResultList.Add(new SearchAllMedia_Type
                {
                    id = n.ID,
                    DateTimeIndex = n.DateTimeIndex,
                    Description = "",
                    Keywords = n.KeywordID.ToString(),
                    MediaType = "توییتر",
                    MediaUrl = n.MediaUrl.ToString(),
                    Reference = n.UserScreenName.ToString(),
                    Title = n.Text,
                    Url = ""
                });
            }

            return ResultList;
        }
        private List<SearchAllMedia_Type> SearchPhraseInMovie(List<int> MovieIds, string searchText)
        {
            var NewSearchText = searchText.Replace("ی", "ي").Replace("ك", "ک");

            List<int> result = new List<int>();
            string str1 = "";
            string str2 = "";
            string str3 = "";



            if (searchText.Contains("|"))
            {
                var SearchParameterList = NewSearchText.Split('|');


                if (SearchParameterList.Count() == 2)
                {
                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];

                    result = _db.Tbl_Movies.Where(n => MovieIds.Contains(n.MovieID) && n.Title.Contains(str1) && n.Title.Contains(str2)).Select(n => n.MovieID).ToList();

                }
                else if (SearchParameterList.Count() == 3)
                {

                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    str3 = SearchParameterList[2];


                    result = _db.Tbl_Movies.Where(n => MovieIds.Contains(n.MovieID) && n.Title.Contains(str1) && n.Title.Contains(str2) && n.Title.Contains(str3)).Select(n => n.MovieID).ToList();

                }

            }
            else
            {
                result = _db.Tbl_Movies.Where(n => MovieIds.Contains(n.MovieID) && n.Title.Contains(NewSearchText)).Select(n => n.MovieID).ToList();
            }

            var MovieList = _db.Tbl_Movies.Where(n => result.Contains(n.MovieID)).ToList();
            List<SearchAllMedia_Type> ResultList = new List<SearchAllMedia_Type>();
            foreach (var n in MovieList)
            {
                ResultList.Add(new SearchAllMedia_Type
                {
                    id = n.MovieID,
                    DateTimeIndex = long.Parse(n.VideoDateIndex + n.PlayTime.Replace(":", "")),
                    Description = "",
                    Keywords = "",
                    MediaType = "ویدیو",
                    MediaUrl = n.VideoPath.ToString(),
                    Reference = n.NetworkName.ToString(),
                    Title = n.Title,
                    Url = ""
                });
            }

            return ResultList;
        }
        private List<SearchAllMedia_Type> SearchPhraseInNews(List<int> newsIds, string searchText)
        {
            var arabicStrSearch = Class_Static.ArabicAlpha(searchText);

            List<int> result = new List<int>();
            string str1 = "";
            string str2 = "";
            string str3 = "";

            if (arabicStrSearch.Contains("|"))
            {
                var SearchParameterList = arabicStrSearch.Split('|');


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
                result = _db.Tbl_News.Where(n => newsIds.Contains(n.NewsID) && (n.NewsTitle.Contains(arabicStrSearch) || n.NewsLead.Contains(arabicStrSearch) || n.NewsBody.Contains(arabicStrSearch))).Select(n => n.NewsID).ToList();
            }

            var NewsList = _db.Tbl_News.Where(n => result.Contains(n.NewsID)).Select(n => new {
                NewsID = n.NewsID,
                NewsDateTimeIndex = n.NewsDateTimeIndex,
                KeyIds = n.KeyIds,
                NewsPicture = n.NewsPicture,
                SiteID = n.SiteID,
                NewsTitle = n.NewsTitle,
                NewsLink = n.NewsLink

            }).ToList();
            List<SearchAllMedia_Type> ResultList = new List<SearchAllMedia_Type>();
            foreach (var n in NewsList)
            {
                ResultList.Add(new SearchAllMedia_Type
                {
                    id = n.NewsID,
                    DateTimeIndex = n.NewsDateTimeIndex ?? 0,
                    Description = "",
                    Keywords = n.KeyIds,
                    MediaType = "خبر",
                    MediaUrl = n.NewsPicture,
                    Reference = n.SiteID.ToString(),
                    Title = n.NewsTitle,
                    Url = n.NewsLink,
                    
                });
            }

            return ResultList;

        }

        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            try
            {
                SearchIncludeInstagram = InstagramCheckBox.Checked;
                SearchIncludeTwitter = TwitterCheckBox.Checked;
                SearchIncludeTelegram = TelegramCheckBox.Checked;
                SearchIncludeNews = NewsCheckBox.Checked;
                SearchIncludeMovie = MovieCheckBox.Checked;


                string url = "";

                if (txt_fromDate.Text != "")
                {
                    url = "from=" + txt_fromDate.Text.Replace("/", "");

                    if (txt_fromHour.Text != "")
                    {
                        url += Server.HtmlEncode(txt_fromHour.Text.Trim().Replace(":", "")) + "&";
                    }
                    else
                    {
                        url += "0000&";
                    }

                }


                if (txt_toDate.Text != "")
                {
                    url += "to=" + txt_toDate.Text.Replace("/", "");

                    if (txt_fromHour.Text != "")
                    {
                        url += Server.HtmlEncode(txt_toHour.Text.Trim().Replace(":", "")) + "&";
                    }
                    else
                    {
                        url += "2500&";
                    }

                }


                if (txt_search.Text.Trim() != "")
                {
                    url += "keyword=" + Server.HtmlEncode(txt_search.Text.Trim().Replace("+", "|")) + "&";
                }

                if (SearchIncludeNews)
                {
                    url += "ne=true&";
                }

                if (SearchIncludeMovie)
                {
                    url += "mo=true&";
                }

                if (SearchIncludeTelegram)
                {
                    url += "tl=true&";
                }

                if (SearchIncludeTwitter)
                {
                    url += "tw=true&";
                }

                if (SearchIncludeInstagram)
                {
                    url += "in=true&";
                }

                url = url.Substring(0, url.Length - 1);
                Response.Redirect("/SearchAllMedia/?" + url);
            }
            catch { }
        }
        public string FixDateTimeString(string input)
        {
            StringBuilder result = new StringBuilder();

            result.Append(input.Substring(8, 2));
            result.Append(":");
            result.Append(input.Substring(10, 2));
            result.Append(" ⏰ ");


            result.Append(input.Substring(0, 4));
            result.Append("/");
            result.Append(input.Substring(4, 2));
            result.Append("/");
            result.Append(input.Substring(6, 2));
            result.Append("  📆 ");

            return result.ToString();
        }

        public string FixItemShowNewsUrl(string id, string MediaType)
        {
            switch (MediaType)
            {
                case "خبر":
                    return "/ShowNews/" + id;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "توییتر":
                    return "/TwitterPostShow/" + id;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "اینستاگرام":
                    return "/InstagramPostShow/" + id;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "تلگرام":
                    return "/TelegramMessageShow/" + id;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "ویدیو":
                    return "/MovieShow/" + id;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                default:
                    return "";
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected

            }
        }

        public string GetMediaTypeLogo(string MediaType)
        {
            switch (MediaType)
            {
                case "خبر":
                    return "<i class=\"far fa-newspaper fa-2x Purple\"></i>";
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "توییتر":
                    return "<i class=\"fab fa-twitter fa-2x twitterBlue\"></i>";
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "اینستاگرام":
                    return "<i class=\"fab fa-instagram fa-2x instagramMaroon\"></i>";
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "تلگرام":
                    return "<i class=\"fab fa-telegram fa-2x telegramBlue\"></i>";
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                case "ویدیو":
                    return "<i class=\"far fa-play-circle fa-2x orange\"></i>";
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected
                default:
                    return MediaType;
#pragma warning disable CS0162 // Unreachable code detected
                    break;
#pragma warning restore CS0162 // Unreachable code detected

            }
        }
    }
}
