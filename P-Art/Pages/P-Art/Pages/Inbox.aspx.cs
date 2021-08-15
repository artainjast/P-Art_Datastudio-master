using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
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
    public partial class Inbox : System.Web.UI.Page
    {
        //////private static DB_RubikaEntities _dbRubika = new DB_RubikaEntities();
        private static DB_NewsCenterEntities _dbDDn = new DB_NewsCenterEntities();
        Class_Zaman _clsZm = new Class_Zaman();
        PagingMediaItemList_Type pagingNews = new PagingMediaItemList_Type();
        List<PagingMediaItem_Type> newsListTypeMedia = new List<PagingMediaItem_Type>();
        List<PagingMediaItem_Type> newsGroupListTypeMedia = new List<PagingMediaItem_Type>();
        List<PagingMediaItem_Type> telegramListTypeMedia = new List<PagingMediaItem_Type>();
        List<PagingMediaItem_Type> twitterListTypeMedia = new List<PagingMediaItem_Type>();
        List<PagingMediaItem_Type> instagramListTypeMedia = new List<PagingMediaItem_Type>();
        List<ModelNews.Tbl_Inbox> queryInbox;
        List<int?> UserPanelList = new List<int?>();
        int memberId = 0;
        int userPanelId = 0;
        int pageSize = 25;
        int pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            if (!IsPostBack)
            {

                memberId = Class_Layer.CurrentUser().MemberID;

                userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
                queryInbox = _dbDDn.Tbl_Inbox.Where(n => n.MemberId == memberId && n.PanelId == userPanelId).ToList();
                LoadData();
                PrepareNews();
                PrepareInstagram();
                PrepareTelegram();
                PrepareTwitter();
                ///// PrepareNewsGroups();

                List<PagingMediaItem_Type> combined = new List<PagingMediaItem_Type>();
                combined.AddRange(newsListTypeMedia);
                combined.AddRange(newsGroupListTypeMedia);
                combined.AddRange(telegramListTypeMedia);
                combined.AddRange(twitterListTypeMedia);
                combined.AddRange(instagramListTypeMedia);


                pagingNews.TotalMediaCount = combined.Count();
                pagingNews.MediaList = combined
                    .OrderBy(n => n.Priority)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize)
                    .Select(n => new PagingMediaItem_Type
                    {
                        MediaId = n.MediaId,
                        MediaTitle = n.MediaTitle,
                        DateTimeIndex = (long)n.DateTimeIndex,
                        MediaSource = ""/*queryNewsGroup.FirstOrDefault(i => i.GroupId == n.GroupId).GroupTitle*/,
                        MediaSourceId = n.MediaSourceId,
                        MediaType = n.MediaType,
                        Date = "",
                        Time = "",
                        MediaUrl = n.MediaUrl,
                        Priority = n.Priority
                    }).ToList();


                GeneratePaginationButton(pagingNews.TotalMediaCount, pageSize, pageIndex);
                GetCompletedData();

                GenerateMediaList(pagingNews);

                LoadTemplate();
            }
        }
        private void LoadData()
        {
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
        }
        private void PrepareNews()
        {
            List<long> idList = queryInbox.Where(i => i.MediaType == 1).Select(n => n.MediaId).ToList();

            List<ModelNews.Tbl_News> query;
            query = _dbDDn.Tbl_News.Where(x => idList.Contains(x.NewsID)).ToList();
            newsListTypeMedia = query
                .OrderByDescending(n => n.NewsDateTimeIndex)
                .Select(n => new PagingMediaItem_Type
                {
                    MediaId = n.NewsID,
                    MediaTitle = n.NewsTitle,
                    DateTimeIndex = (long)n.NewsDateTimeIndex,
                    MediaSource = ""/*queryNewsGroup.FirstOrDefault(i => i.GroupId == n.GroupId).GroupTitle*/,
                    MediaSourceId = n.SiteID,
                    MediaType = 1,
                    Date = "",
                    Time = "",
                    MediaUrl = n.NewsLink
                }).ToList();
            foreach (var news in newsListTypeMedia)
            {
                try { news.Priority = (int)queryInbox.FirstOrDefault(i => i.MediaId == news.MediaId && i.MediaType == news.MediaType).Priority; }
                catch { news.Priority = 1; }
            }


        }
        private void PrepareTwitter()
        {
            List<long> idList = queryInbox.Where(i => i.MediaType == 4).Select(n => n.MediaId).ToList();

            List<ModelNews.Tbl_TwitterPost> query;
            query = _dbDDn.Tbl_TwitterPost.Where(x => idList.Contains(x.ID)).ToList();
            twitterListTypeMedia = query
                .OrderByDescending(n => n.DateTimeIndex)
                .Select(n => new PagingMediaItem_Type
                {
                    MediaId = n.ID,
                    MediaTitle = n.Text,
                    DateTimeIndex = (long)n.DateTimeIndex,
                    MediaSource = ""/*queryNewsGroup.FirstOrDefault(i => i.GroupId == n.GroupId).GroupTitle*/,
                    MediaSourceId = 0,
                    MediaType = 4,
                    Date = "",
                    Time = "",
                    MediaUrl = n.MediaUrl
                }).ToList();
            foreach (var news in twitterListTypeMedia)
            {
                try { news.Priority = (int)queryInbox.FirstOrDefault(i => i.MediaId == news.MediaId && i.MediaType == news.MediaType).Priority; }
                catch { news.Priority = 1; }
            }


        }
        private void PrepareTelegram()
        {
            List<long> idList = queryInbox.Where(i => i.MediaType == 3).Select(n => n.MediaId).ToList();

            List<ModelNews.Tbl_TLPMessage> query;
            query = _dbDDn.Tbl_TLPMessage.Where(x => idList.Contains(x.ID)).ToList();
            telegramListTypeMedia = query
                .OrderByDescending(n => n.DateTimeIndex)
                .Select(n => new PagingMediaItem_Type
                {
                    MediaId = n.ID,
                    MediaTitle = n.MessageText,
                    DateTimeIndex = (long)n.DateTimeIndex,
                    MediaSource = ""/*queryNewsGroup.FirstOrDefault(i => i.GroupId == n.GroupId).GroupTitle*/,
                    MediaSourceId = (int)n.ChannelID,
                    MediaType = 3,
                    Date = "",
                    Time = "",
                    MediaUrl = ""
                }).ToList();
            foreach (var news in telegramListTypeMedia)
            {
                try { news.Priority = (int)queryInbox.FirstOrDefault(i => i.MediaId == news.MediaId && i.MediaType == news.MediaType).Priority; }
                catch { news.Priority = 1; }
            }


        }
        private void PrepareInstagram()
        {
            List<long> idList = queryInbox.Where(i => i.MediaType == 5).Select(n => n.MediaId).ToList();

            List<ModelNews.Tbl_InstagramPosts> query;
            query = _dbDDn.Tbl_InstagramPosts.Where(x => idList.Contains(x.Id)).ToList();
            instagramListTypeMedia = query
                .OrderByDescending(n => n.DateTimeIndex)
                .Select(n => new PagingMediaItem_Type
                {
                    MediaId = n.Id,
                    MediaTitle = n.CaptionText,
                    DateTimeIndex = (long)n.DateTimeIndex,
                    MediaSource = ""/*queryNewsGroup.FirstOrDefault(i => i.GroupId == n.GroupId).GroupTitle*/,
                    MediaSourceId = 0,
                    MediaType = 5,
                    Date = "",
                    Time = "",
                    MediaUrl = n.PostUrl
                }).ToList();
            foreach (var news in instagramListTypeMedia)
            {
                try { news.Priority = (int)queryInbox.FirstOrDefault(i => i.MediaId == news.MediaId && i.MediaType == news.MediaType).Priority; }
                catch { news.Priority = 1; }
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
        private void generateUrl(int index)
        {
            string url = "";
            if (PageSizeDropDownList.SelectedItem.Value != null)
            {
                url += "size=" + Server.HtmlEncode(PageSizeDropDownList.SelectedItem.Value) + "&";
            }

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            Response.Redirect("/Inbox/?" + url);
        }
        private string generatePaginationLink(int index)
        {

            string url = "";

            url += "size=" + Server.HtmlEncode(pageSize.ToString()) + "&";

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            return "/Inbox/?" + url;

        }
        private void GenerateMediaList(PagingMediaItemList_Type pagingNews)
        {
            pagingGridRepeater.DataSource = pagingNews.MediaList;
            pagingGridRepeater.DataBind();
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
        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            int index = 1;
            generateUrl(index);
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
        private void GetCompletedData()
        {
            var siteIds = pagingNews.MediaList.Select(n => n.MediaSourceId).Distinct().ToList();
            //var sitesNewMedia = _dbRubika.Tbl_Sites.Where(s => siteIds.Contains(s.SiteId)).ToList();
            var sites = _dbDDn.Tbl_Sites.Where(s => siteIds.Contains(s.SiteID)).ToList();

            foreach (var item in pagingNews.MediaList)
            {
                if (item.MediaType == 1)
                {
                    item.MediaSource = sites.Where(s => s.SiteID == item.MediaSourceId).Select(s => s.SiteTitle).FirstOrDefault().Trim().Replace("ي", "ی").Replace("ك", "ک");
                }
                //////else if (item.MediaType == 2)
                //////{
                //////    item.MediaSource = sitesNewMedia.Where(s => s.SiteId == item.MediaSourceId).Select(s => s.SiteTitle).FirstOrDefault().Trim().Replace("ي", "ی").Replace("ك", "ک");
                //////}
                //item.SiteType = sites.Where(s => s.SiteID == item.SiteID).Select(s => s.SiteType).FirstOrDefault() ?? 0;
                item.MediaTitle = item.MediaTitle.Trim().Replace("ي", "ی").Replace("ك", "ک");
                //item.DateTimeString = DiffrentDate(item.SiteType.ToString(), item.Time, item.Date);

                if (string.IsNullOrEmpty(item.MediaUrl))
                {
                    item.UrlDisplayControl = "hide";
                }

            }
        }
        [WebMethod]
        public static long DeleteInbox(long MediaId, int MediaType)
        {
            try
            {
                var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;

                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;



                var itemToRemove = _dbDDn.Tbl_Inbox.SingleOrDefault(x => x.MediaId == MediaId && x.MediaType == MediaType &&
                x.PanelId == userPanelId && x.MemberId == memberId); //returns a single item.

                if (itemToRemove != null)
                {
                    _dbDDn.Tbl_Inbox.Remove(itemToRemove);
                    _dbDDn.SaveChanges();
                    return 1;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        [WebMethod]
        public static long DeleteAllInbox(string codes)
        {
            var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;

            var memberId = Class_Layer.CurrentUser().MemberID;
            var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
            try
            {
                foreach(var code in codes.Split('_'))
                {
                    long mediaId = Convert.ToInt64(code.Split('-')[0]);
                    int mediaType = Convert.ToInt32(code.Split('-')[1]);
                    var itemToRemove = _dbDDn.Tbl_Inbox.SingleOrDefault(x => x.MediaId == mediaId && x.MediaType == mediaType &&
             x.PanelId == userPanelId && x.MemberId == memberId); //returns a single item.

                    if (itemToRemove != null)
                    {
                        _dbDDn.Tbl_Inbox.Remove(itemToRemove);
                        _dbDDn.SaveChanges();
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        [WebMethod]
        public static int SetBultanArchiveMedia(string bultanTitle,
       bool allowNewspaper, bool galleryNewspaper, bool arz, bool sima, bool highLight, bool allowGroup, bool related,
       int selectedBultan, bool isArchive, bool chart, bool jeld, byte BultanType, string linkUrl)
        {
            try
            {
                Class_Zaman _clsZaman = new Class_Zaman();
                //string fromDate = _clsZaman.Today();
                //string toDate = _clsZaman.Today();
                var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;

                //fromDate = fromDate.Replace("/", "");
                //toDate = toDate.Replace("/", "");


                //long fromDateTime = Convert.ToInt64(fromDate + "0000");
                //long toDateTime = Convert.ToInt64(toDate + "2400");

                Class_BultanArchive archive = new Class_BultanArchive();
                Class_BultanArchiveMedia archiveMedia = new Class_BultanArchiveMedia();

                StringBuilder str = new StringBuilder();

                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

                List<Tbl_BultanSettings> settings = (new Class_BultanSetting()).GetList(userPanelId);

                List<Tbl_Inbox> MediaList = _dbDDn.Tbl_Inbox
                        .Where(n => n.PanelId == userPanelId && n.MemberId == memberId).OrderBy(i => i.Priority).ToList();

                List<Tbl_Inbox> listMediaNews = MediaList.Where(i => i.MediaType == 1).ToList();
                List<Tbl_Inbox> listMediaTwitters = MediaList.Where(i => i.MediaType == 4).ToList();
                List<Tbl_Inbox> listMediaTelegram = MediaList.Where(i => i.MediaType == 3).ToList();
                List<Tbl_Inbox> listMediaInstagram = MediaList.Where(i => i.MediaType == 5).ToList();
                List<int> newsIds = new List<int>();
                foreach (var i1 in listMediaNews)
                {
                    newsIds.Add(Convert.ToInt32(i1.MediaId));
                }
                List<Tbl_News> newsList = (new Class_News()).GetAllNewsIds(newsIds);

                List<long> twitterIds = new List<long>();
                foreach (var i1 in listMediaTwitters)
                {
                    twitterIds.Add(Convert.ToInt32(i1.MediaId));
                }
                List<Tbl_TwitterPost> twitterList = (new Class_Twitter()).GetAllTwiiterIds(twitterIds);

                List<long> telegramIds = new List<long>();
                foreach (var i1 in listMediaTelegram)
                {
                    telegramIds.Add(Convert.ToInt32(i1.MediaId));
                }
                List<v_TLP_Messages> telegramList = (new Class_TLPMessages()).GetMessages(telegramIds);


                List<long> instagramIds = new List<long>();
                foreach (var i1 in listMediaInstagram)
                {
                    instagramIds.Add(Convert.ToInt32(i1.MediaId));
                }
                List<Tbl_InstagramPosts> instaList = (new Class_InstagramPost()).GetAllIds(instagramIds);
                List<int> dateListIndex = new List<int>();
                foreach (var d in newsList)
                {
                    dateListIndex.Add(Convert.ToInt32(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexLongToIntString(d.NewsDateIndex.ToString())));
                }
                foreach (var d in twitterList)
                {

                    dateListIndex.Add(Convert.ToInt32(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexLongToIntString(d.DateTimeIndex.ToString())));
                }
                foreach (var d in telegramList)
                {
                    dateListIndex.Add(Convert.ToInt32(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexLongToIntString(d.DateTimeIndex.ToString())));
                }
                foreach (var d in instaList)
                {
                    dateListIndex.Add(Convert.ToInt32(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexLongToIntString(d.DateTimeIndex.ToString())));
                }

                int fromDateIndex = dateListIndex.OrderBy(p => p).FirstOrDefault();
                int toDateIndex = dateListIndex.OrderByDescending(p => p).FirstOrDefault();

                foreach (var item in MediaList)
                {
                    str.Append(item.MediaId.ToString() + ",");
                }


                int result = archive.InsertArchive(Convert.ToInt64(fromDateIndex),
                    parmin, linkUrl, Class_Static.ConvertToLatinNumberSam(bultanTitle), str.ToString().Substring(0, str.Length - 1), fromDateIndex.ToString(), toDateIndex.ToString(), "", "", allowNewspaper,
                    galleryNewspaper, arz, sima, highLight, allowGroup, related, selectedBultan, isArchive, chart, jeld, BultanType);

                int priority = 0;
                foreach (var item in MediaList)
                {
                    priority++;
                    archiveMedia.InsertArchive(result, item.MediaId, item.MediaType, priority);
                }

                InsertBultanFeature(result, userPanelId,settings);

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        protected void ClearAllButton_Click(object sender, EventArgs e)
        {
            memberId = Class_Layer.CurrentUser().MemberID;
            userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

            try
            {
                var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;

                var memberId = Class_Layer.CurrentUser().MemberID;
                var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
                //var itemToRemove = _dbDDn.Tbl_Inbox.SingleOrDefault(x => x.PanelId == userPanelId && x.MemberId == memberId); //returns a single item.

                //if (itemToRemove != null)
                //{
                var query = from c in _dbDDn.Tbl_Inbox
                            where c.PanelId == userPanelId && c.MemberId == memberId
                            select c;

                foreach (Tbl_Inbox itm in query)
                {
                    _dbDDn.Tbl_Inbox.Remove(itm);
                }

                _dbDDn.SaveChanges();
                Response.Redirect("/Inbox");
                //}
            }
            catch (Exception ex)
            {
            }
        }
        public static void InsertBultanFeature(int ArchieveId, int ParminId, List<Tbl_BultanSettings> settings)
        {
            if (settings.Any(i => i.SettingTitle == "all_top_news"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_news").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_news", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_top_news", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_news", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_top_radio"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_radio").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_radio", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_top_radio", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_radio", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_top_video"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_video").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_video", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_top_video", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_video", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_top_social"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_social").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_social", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_top_social", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_top_social", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_instagram"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_instagram").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_instagram", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_instagram", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_instagram", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_twitter"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_twitter").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_twitter", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_twitter", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_twitter", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_telegram"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_telegram").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_telegram", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_telegram", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_telegram", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_website"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_website").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_website", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_website", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_website", "0");
            }

            if (settings.Any(i => i.SettingTitle == "all_newspaper"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "all_newspaper").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_newspaper", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "all_newspaper", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "all_newspaper", "0");
            }

            if (settings.Any(i => i.SettingTitle == "social_count_day"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "social_count_day").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "social_count_day", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "social_count_day", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "social_count_day", "0");
            }

            if (settings.Any(i => i.SettingTitle == "tafkik_news_online"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "tafkik_news_online").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "tafkik_news_online", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "tafkik_news_online", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "tafkik_news_online", "0");
            }


            if (settings.Any(i => i.SettingTitle == "tafkik_social"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "tafkik_social").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "tafkik_social", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "tafkik_social", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "tafkik_social", "0");
            }


            if (settings.Any(i => i.SettingTitle == "tafkik_tv"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "tafkik_tv").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "tafkik_tv", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "tafkik_tv", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "tafkik_tv", "0");
            }


            if (settings.Any(i => i.SettingTitle == "top_hashtag"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "top_hashtag").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "top_hashtag", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "top_hashtag", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "top_hashtag", "0");
            }

            if (settings.Any(i => i.SettingTitle == "jensiat"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "jensiat").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "jensiat", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "jensiat", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "jensiat", "0");
            }


            if (settings.Any(i => i.SettingTitle == "news_mosbat_manfi"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "news_mosbat_manfi").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "news_mosbat_manfi", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "news_mosbat_manfi", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "news_mosbat_manfi", "0");
            }


            if (settings.Any(i => i.SettingTitle == "top_twitter"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "top_twitter").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "top_twitter", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "top_twitter", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "top_twitter", "0");
            }

            if (settings.Any(i => i.SettingTitle == "sugiri_webnewspaper_mosbat"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "sugiri_webnewspaper_mosbat").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "sugiri_webnewspaper_mosbat", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "sugiri_webnewspaper_mosbat", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "sugiri_webnewspaper_mosbat", "0");
            }


            if (settings.Any(i => i.SettingTitle == "sugiri_webnewspaper_manfi"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "sugiri_webnewspaper_manfi").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "sugiri_webnewspaper_manfi", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "sugiri_webnewspaper_manfi", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "sugiri_webnewspaper_manfi", "0");
            }


            if (settings.Any(i => i.SettingTitle == "cloud_chart_twitter"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "cloud_chart_twitter").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "cloud_chart_twitter", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "cloud_chart_twitter", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "cloud_chart_twitter", "0");
            }


            if (settings.Any(i => i.SettingTitle == "cloud_chart_news"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "cloud_chart_news").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "cloud_chart_news", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "cloud_chart_news", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "cloud_chart_news", "0");
            }


            if (settings.Any(i => i.SettingTitle == "map_twitter"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "map_twitter").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "map_twitter", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "map_twitter", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "map_twitter", "0");
            }


            if (settings.Any(i => i.SettingTitle == "map_telegram"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "map_telegram").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "map_telegram", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "map_telegram", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "map_telegram", "0");
            }


            if (settings.Any(i => i.SettingTitle == "map_instagram"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "map_instagram").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "map_instagram", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "map_instagram", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "map_instagram", "0");
            }


            if (settings.Any(i => i.SettingTitle == "news_bohransaz_mosbat"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "news_bohransaz_mosbat").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "news_bohransaz_mosbat", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "news_bohransaz_mosbat", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "news_bohransaz_mosbat", "0");
            }


            if (settings.Any(i => i.SettingTitle == "news_bohransaz_manfi"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "news_bohransaz_manfi").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "news_bohransaz_manfi", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "news_bohransaz_manfi", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "news_bohransaz_manfi", "0");
            }


            if (settings.Any(i => i.SettingTitle == "newspaper"))
            {
                string value = settings.FirstOrDefault(i => i.SettingTitle == "newspaper").SettingValue;

                (new Class_BultanArchiveFeature()).Add(ArchieveId, "newspaper", value);
            }
            else
            {
                (new Class_BultanSetting()).Add(ParminId, "newspaper", "0");
                (new Class_BultanArchiveFeature()).Add(ArchieveId, "newspaper", "0");
            }

        }
        [WebMethod]
        public static long UpdatePriority(string input)
        {
            try
            {
                /// var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;
                if (input != string.Empty && input != null)
                {
                    input = input.Substring(0, input.Length - 1);
                    var items = input.Split(',');
                    var memberId = Class_Layer.CurrentUser().MemberID;
                    var userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

                    long MediaId = 0;
                    int MediaType = 0;
                    int Priority = 0;

                    foreach (var i in items)
                    {
                        MediaId = Convert.ToInt64(i.Split('-')[0]);
                        Priority = Convert.ToInt32(i.Split('-')[1]);
                        MediaType = Convert.ToInt32(i.Split('-')[2]);
                        Tbl_Inbox item = _dbDDn.Tbl_Inbox.SingleOrDefault(x => x.MediaId == MediaId && x.MediaType == MediaType &&
                        x.PanelId == userPanelId && x.MemberId == memberId); //returns a single item.

                        if (item != null)
                        {
                            item.Priority = Priority;
                            _dbDDn.SaveChanges();
                        }
                    }
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}