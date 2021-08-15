using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class BultanPayeshMedia : System.Web.UI.Page
    {
        Class_Keywords _clsKeyword = new Class_Keywords();
        Class_News _clsNews = new Class_News();
        Class_BultanFiles _clsBultanFiles = new Class_BultanFiles();
        List<Tbl_RssKeywords> keywords;
        int PageCounter = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string htmlCover = "";
                string htmlBackCover = "";
                string htmlTelegramCover = "";
                string htmlTwitterCover = "";
                string htmlInstagramCover = "";
                string htmlFehrestNews = "";
                string htmlNews = "";
                string htmlTwitters = "";
                string htmlTelegrams = "";
                string htmlInstagram = "";
                var UserHighlight = new List<string>();
                var strSearch = "";
                int siteId = 0;
                List<Tbl_NewsRelate_Type> newsRelatedList = new List<Tbl_NewsRelate_Type>();
                List<Tbl_News_Type> newsList = new List<Tbl_News_Type>();
                List<Tbl_Twitter_Type> twitterList = new List<Tbl_Twitter_Type>();
                List<Tbl_Telegram_Type> telegramList = new List<Tbl_Telegram_Type>();
                List<Tbl_Instagram_Type> instagramList = new List<Tbl_Instagram_Type>();

                if (Request.QueryString["ArchiveId"] != null)
                {
                    hdfBultanArchiveID.Value = Request.QueryString["ArchiveId"] + "";
                    Tbl_BultanArchive archive = (new Class_BultanArchive()).GetBultanByArchiveId(Convert.ToInt32(hdfBultanArchiveID.Value));

                    htmlCover = LoadCover(archive);
                    htmlBackCover = LoadBackCover(archive);
                    #region BindData
                    var parminIds = new List<int?>();
                    {
                        parminIds.Add(Convert.ToInt32(archive.PanelId));
                    }
                    keywords = _clsKeyword.GetRssKeywordByPanelIds(parminIds);

                    string NewsIdsFinal = "";
                    string TwittersIdFinal = "";
                    string TelegramsIdFinal = "";
                    string InstagramIdFinal = "";
                    List<Tbl_BultanArchiveMedia> listMedia = (new Class_BultanArchiveMedia()).GeArchiveList(archive.ArchiveId);
                    List<Tbl_BultanArchiveMedia> listMediaNews = listMedia.Where(i => i.MediaType == 1).ToList();
                    List<Tbl_BultanArchiveMedia> listMediaTwitters = listMedia.Where(i => i.MediaType == 4).ToList();
                    List<Tbl_BultanArchiveMedia> listMediaTelegram = listMedia.Where(i => i.MediaType == 3).ToList();
                    List<Tbl_BultanArchiveMedia> listMediaInstagram = listMedia.Where(i => i.MediaType == 5).ToList();
                    for (int li = 0; li < listMediaNews.Count; li++)
                    {
                        try
                        {
                            NewsIdsFinal += listMediaNews[li].MediaId.ToString();
                            if (li != listMediaNews.Count - 1)
                                NewsIdsFinal += ",";
                        }
                        catch
                        {

                        }
                    }
                    for (int li = 0; li < listMediaTwitters.Count; li++)
                    {
                        try
                        {
                            TwittersIdFinal += listMediaTwitters[li].MediaId.ToString();
                            if (li != listMediaTwitters.Count - 1)
                                TwittersIdFinal += ",";
                        }
                        catch
                        {

                        }
                    }
                    for (int li = 0; li < listMediaTelegram.Count; li++)
                    {
                        try
                        {
                            TelegramsIdFinal += listMediaTelegram[li].MediaId.ToString();
                            if (li != listMediaTelegram.Count - 1)
                                TelegramsIdFinal += ",";
                        }
                        catch
                        {

                        }
                    }
                    for (int li = 0; li < listMediaInstagram.Count; li++)
                    {
                        try
                        {
                            InstagramIdFinal += listMediaInstagram[li].MediaId.ToString();
                            if (li != listMediaInstagram.Count - 1)
                                InstagramIdFinal += ",";
                        }
                        catch
                        {

                        }
                    }

                    #region BindNews
                    DataTable result;
                    if (archive.AllowRelated == true)
                    {
                        DataSet ds = _clsNews.GetAllNewsDataTableByRelatedProcedure(1000, 1, parminIds, null, true, UserHighlight, Convert.ToInt32(archive.FromDateIndex), Convert.ToInt32(archive.ToDateIndex), strSearch, siteId, null, "", "", NewsIdsFinal, "", false);
                        result = ds.Tables[0];
                        newsList = _clsNews.GetFromDataRowsBultanMedia(result.Select(), keywords);
                        newsRelatedList = Tbl_NewsRelate_Type.GetFromDataRows(ds.Tables[1].Select());
                        foreach (var nn in newsList)
                        {
                            string relateds = "";
                            foreach (var r in newsRelatedList.Where(i => i.NewsId == nn.NewsID).ToList())
                            {
                                relateds += relateds != string.Empty ? "," : string.Empty;
                                relateds += r.RelateNewsId;
                            }
                            nn.RelatedNewsStringIds = relateds;
                            nn.RelatedString = relateds;
                        }
                        newsList = LoadRelated(newsList);
                    }
                    else
                    {
                        result = _clsNews.GetAllNewsDataTableByNewsIdsBultanMedia(1000, 1, parminIds, null, true, UserHighlight, Convert.ToInt32(archive.FromDateIndex), Convert.ToInt32(archive.ToDateIndex), strSearch, siteId, null, "", "", NewsIdsFinal, "", false);
                        if (result != null)
                            newsList = _clsNews.GetFromDataRowsBultanMedia(result.Select(), keywords);
                        else newsList = new List<Tbl_News_Type>();
                    }
                    #endregion

                    #region BindTwitter
                    if (!string.IsNullOrEmpty(TwittersIdFinal))
                        twitterList = (new Class_SocialMediaPost()).GetPosts(TwittersIdFinal);
                    #endregion

                    #region BindTelegram
                    if (!string.IsNullOrEmpty(TelegramsIdFinal))
                        telegramList = (new Class_TLPMessages()).GetPosts(TelegramsIdFinal);
                    #endregion

                    #region BindInstagram
                    if (!string.IsNullOrEmpty(InstagramIdFinal))
                        instagramList = (new Class_InstagramPost()).GetPosts(InstagramIdFinal);
                    #endregion

                    #endregion
                    if (newsList.Count != 0)
                    {
                        htmlFehrestNews = LoadFehrest(archive, newsList);
                        htmlNews = LoadNews(archive, newsList);
                    }
                    htmlTwitters = LoadTwitter(archive, twitterList);
                    htmlTelegrams = LoadTelegrams(archive, telegramList);
                    htmlTelegramCover = LoadTelegramCover(archive);
                    htmlInstagramCover = LoadInstagramCover(archive);
                    htmlTwitterCover = LoadTwitterCover(archive);
                    htmlInstagram = LoadInstagrams(archive, instagramList);
                }
                if (Request.QueryString["ArchiveId"] != null)
                {
                    if (telegramList.Count == 0)
                    {
                        htmlTelegramCover = "";
                        htmlTelegrams = "";
                    }
                    if (twitterList.Count == 0)
                    {
                        htmlTwitterCover = "";
                        htmlTwitters = "";
                    }
                    if (instagramList.Count == 0)
                    {
                        htmlInstagram = "";
                        htmlInstagramCover = "";
                    }
                    if (newsList.Count == 0)
                    {
                        htmlFehrestNews = "";
                        htmlNews = "";
                    }
                    ltPostCoverHtml.Text = htmlCover;
                    ltPostHtml.Text = htmlFehrestNews + htmlNews + htmlTwitterCover +
                       htmlTwitters + htmlTelegramCover + htmlTelegrams + htmlInstagramCover + htmlInstagram + htmlBackCover;
                }
                else
                    ltPostHtml.Text = "";
            }
        }
        public string LoadCover(Tbl_BultanArchive report)
        {
            var html = "";
            string BultanJeldPath = "";
            try
            {
                string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
                string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
                string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
                try
                {
                    var selectedBultan = _clsBultanFiles.SelectBultanItem(report.ArchiveId);
                    BultanJeldPath = selectedBultan.BultanJeldPath;

                }
                catch
                {
                    BultanJeldPath = "/Styles/img/cover.jpg";
                }

                html = "<div class='page coverPage' style='background-image: url(" + BultanJeldPath + ");background-position: center;background-repeat: no-repeat;background-size: cover;'>"/* + "<img src='" + BultanJeldPath + "' alt='پایش مدیا' />"*/
                    + "<div class='cover-info'>" +
                    "<span class='parmin-title'>" + report.Name + "</span>" +
                    "<span class='parmin-date'>" + bultanCreateDate + "</span>"
                    + "</div>"
                    + "</div>";
            }
            catch
            {

            }
            return html;


        }
        public string LoadBackCover(Tbl_BultanArchive report)
        {
            var html = "";
            string BultanJeldPath = "";
            try
            {

                try
                {
                    var selectedBultan = _clsBultanFiles.SelectBultanItem(report.ArchiveId);
                    BultanJeldPath = selectedBultan.BultanPath;

                }
                catch
                {
                    BultanJeldPath = "/Styles/img/cover.jpg";
                }

                html = "<div class='page coverPage' style='background-image: url(" + BultanJeldPath +
                    ");background-position: center;background-repeat: no-repeat;background-size: cover;'></div>";

            }
            catch
            {

            }
            return html;


        }
        public string LoadTelegramCover(Tbl_BultanArchive report)
        {
            var html = "";
            string BultanJeldPath = "";
            try
            {
                string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
                string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
                string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
                try
                {
                    BultanJeldPath = "/Styles/img/telegram_cover.jpg"; ;
                }
                catch
                {
                    BultanJeldPath = "/Styles/img/telegram_cover.jpg";
                }

                html = "<div class='page coverPage' style='background-image: url(" + BultanJeldPath +
                   ");background-position: center;background-repeat: no-repeat;background-size: cover;'></div>";
                html = "<div class='page coverPage telegrammedia' style='background-image: url(" + BultanJeldPath +
                   ");background-position: center;background-repeat: no-repeat;background-size: cover;'>"
                    + "<div class='cover-info'>" +
                    "<span class='parmin-title'>بولتن شبکه اجتماعی تلگرام</span>" +
                    "<span class='parmin-title'>" + report.Name + "</span>" +
                    "<span class='parmin-date'>" + bultanCreateDate + "</span>"
                    + "</div>" + "</div>";
            }
            catch
            {

            }
            return html;


        }
        public string LoadTwitterCover(Tbl_BultanArchive report)
        {
            var html = "";
            string BultanJeldPath = "";
            try
            {
                string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
                string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
                string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
                try
                {
                    BultanJeldPath = "/Styles/img/twitter_cover.jpg"; ;
                }
                catch
                {
                    BultanJeldPath = "/Styles/img/twitter_cover.jpg";
                }
                html = "<div class='page coverPage socialmedia' style='background-image: url(" + BultanJeldPath +
                   ");background-position: center;background-repeat: no-repeat;background-size: cover;'>" + "<div class='cover-info'>" +
                    "<span class='parmin-title'>بولتن شبکه اجتماعی توییتر</span>" +
                    "<span class='parmin-title'>" + report.Name + "</span>" +
                    "<span class='parmin-date'>" + bultanCreateDate + "</span>"
                    + "</div>" + "</div>";
            }
            catch
            {

            }
            return html;


        }
        public string LoadInstagramCover(Tbl_BultanArchive report)
        {
            var html = "";
            string BultanJeldPath = "";
            try
            {
                string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
                string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
                string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
                try
                {
                    BultanJeldPath = "/Styles/img/instagram_cover.jpg"; ;
                }
                catch
                {
                    BultanJeldPath = "/Styles/img/instagram_cover.jpg";
                }
                html = "<div class='page coverPage instagrammedia' style='background-image: url(" + BultanJeldPath +
                   ");background-position: center;background-repeat: no-repeat;background-size: cover;'>" + "<div class='cover-info'>" +
                    "<span class='parmin-title'>بولتن شبکه اجتماعی اینستاگرام</span>" +
                    "<span class='parmin-title'>" + report.Name + "</span>" +
                    "<span class='parmin-date'>" + bultanCreateDate + "</span>"
                    + "</div>" + "</div>";
            }
            catch
            {

            }
            return html;


        }
        private string LoadFehrest(Tbl_BultanArchive report, List<Tbl_News_Type> lstNews)
        {
            var allowRelated = false;
            try { allowRelated = (bool)report.AllowRelated; } catch { allowRelated = false; }


            string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
            string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
            string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
            var html = "";
            var headerHtml = @" <header class='clearfix fehrest-header'>
                                                 <div class='header-container'>
                                                 <div class='right sarbarg-news'><img src='/Styles/img/news-heder.png' /></div>
                                                 <div class='center header-center'>
                                                     <div class='top-header'>
                                                        <span class='headerTitle'>فهرست بولتن</span> 
                                                        <span class='headerDate'>" + bultanCreateDate + @"<i class='fa fa-calendar-o'></i></span> 
                                                        </div>
                                                      <div class='bottom-header'>
                                                         <span class='headerBultanTitle'>" + report.Name + @"</span> 
                                                      </div>
                                                 </div> 
                                                </div>
                                 </header>";
            var beforeHtmlPageNews = "<ul class='main-fehrast'>";
            var afterHtmlPageNews = "</ul>";
            var htmlPageNews = "";
            var newsIndex = 0;
            var newsCounter = 0;
            int countNews = lstNews.Count;

            try
            {
                foreach (var news in lstNews)
                {
                    newsCounter++;
                    newsIndex++;
                    var relatedText = "";
                    if (allowRelated)
                    {
                        try
                        {
                            if (news.RelateListStrings != null)
                            {
                                foreach (var related in news.RelateListStrings)
                                {
                                    relatedText += "," + related.Split('$')[1];
                                }
                                if (!string.IsNullOrWhiteSpace(relatedText))
                                {
                                    relatedText = " " + "(" + relatedText.Substring(1) + ")";
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    if (newsIndex < 13)
                    {
                        htmlPageNews += "<li><div class='sitelogo'><img src='" + news.SiteLogo + "' /></div><div class='top-item'><span class='item-source'>" + news.SiteTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                            "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                        htmlPageNews += "<div class='middle-item' ><p class='item-lead'>" + news.NewsTitle + "</p></div>";
                        if (news.RelateListStrings != null)
                        {
                            if (news.RelateListStrings.Count > 0)
                                htmlPageNews += "<div class='bottom-item' ><span class='relation-title'>بازنشرها:</span><span class='item-relations'>" + news.RelateListSites + "</span></div></li>";
                            else htmlPageNews += "<div class='bottom-item' ></div></li>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='bottom-item' ></div></li>";
                        }
                        if (newsCounter == countNews)
                        {
                            PageCounter++;
                            var footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                            html += "<div class='page fehrestContainer'> " + headerHtml + beforeHtmlPageNews + htmlPageNews + afterHtmlPageNews + footerHtml + "</div>";
                        }
                    }
                    else
                    {
                        PageCounter++;
                        var footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                        html += "<div class='page fehrestContainer'> " + headerHtml + beforeHtmlPageNews + htmlPageNews + afterHtmlPageNews + footerHtml + "</div>";
                        htmlPageNews = "";
                        htmlPageNews += "<li><div class='sitelogo'><img src='" + news.SiteLogo + "' /></div><div class='top-item'><span class='item-source'>" + news.SiteTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                           "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                        htmlPageNews += "<div class='middle-item' ><p class='item-lead'>" + news.NewsTitle + "</p></div>";
                        if (news.RelateListStrings != null)
                        {
                            if (news.RelateListStrings.Count > 0)
                                htmlPageNews += "<div class='bottom-item' ><span class='relation-title'>بازنشرها:</span><span class='item-relations'>" + news.RelateListSites + "</span></div></li>";
                            else htmlPageNews += "<div class='bottom-item' ></div></li>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='bottom-item' ></div></li>";
                        }
                        newsIndex = 1;
                        if (newsCounter == countNews)
                        {
                            PageCounter++;
                            html += "<div class='page fehrestContainer'> " + headerHtml + beforeHtmlPageNews + htmlPageNews + afterHtmlPageNews + footerHtml + "</div>";
                        }
                    }
                }
            }
            catch
            {

            }
            return html;
        }
        private string LoadFehrest2(Tbl_BultanArchive report, List<Tbl_News_Type> lstNews)
        {
            string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
            string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));

            var MaxPageLength = 1700;
            int PageContentCounter = 0;
            var html = "";
            var headerHtml = @" <header class='clearfix fehrest-header'>
                                                 <div class='header-container'>
                                                 <div class='right'>
                                                     <div class='top-header'>
                                                        <span class='headerTitle'>فهرست بولتن</span> 
                                                        <span class='headerDate'>" + bultanNewsFromDate + " - " + bultanNewsToDate + @"</span> 
                                                      </div>
                                                      <div class='bottom-header'>
                                                         <span class='headerBultanTitle'>" + report.Name + @"</span> 
                                                      </div>
                                                 </div>   
                                                </div>
                                 </header>";

            string htmlPageNews = "";

            try
            {
                int sizeOfContent = 0;

                string footerHtml = "";
                foreach (var news in lstNews)
                {

                    string splitedNewsBody = "";
                    sizeOfContent = news.NewsTitle.Length;
                    PageContentCounter += sizeOfContent;
                    if (sizeOfContent < MaxPageLength)
                    {
                        if (PageContentCounter < MaxPageLength)
                        {
                            htmlPageNews += "<li><div class='sitelogo'><img src='" + news.SiteLogo + "' /></div><div class='top-item'><span class='item-source'>" + news.SiteTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                         "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                            htmlPageNews += "<div class='middle-item' ><p class='item-lead'>" + news.NewsTitle + "</p></div>";
                            htmlPageNews += "<div class='bottom-item' ><span class='relation-title'>بازنشرها:</span><span class='item-relations'>" + news.RelateListSites + "</span></div></li>";
                        }
                        else
                        {
                            htmlPageNews = "<ul class='main-fehrast'>" + htmlPageNews + "</ul>";
                            PageCounter++;
                            footerHtml = @"<footer><span>" + PageCounter + @"</span></footer>";
                            html += "<div class='page newsContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";

                            htmlPageNews = "";
                            htmlPageNews += "<li><div class='sitelogo'><img src='" + news.SiteLogo + "' /></div><div class='top-item'><span class='item-source'>" + news.SiteTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                          "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                            htmlPageNews += "<div class='middle-item' ><p class='item-lead'>" + news.NewsTitle + "</p></div>";
                            htmlPageNews += "<div class='bottom-item' ><span class='relation-title'>بازنشرها:</span><span class='item-relations'>" + news.RelateListSites + "</span></div></li>";
                            PageContentCounter = sizeOfContent;

                        }
                    }
                    else
                    {
                        var maxLength = MaxPageLength;
                        splitedNewsBody = news.NewsTitle.Substring(0, maxLength);
                        var counterMinus = 1;
                        var counterWhile = 0;
                        var findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                        while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                        {
                            if (counterWhile > 500)
                            {
                                break;
                            }
                            counterMinus++;
                            findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                            counterWhile++;
                        }
                        splitedNewsBody = news.NewsTitle.Substring(0, (maxLength - counterMinus) + 1);
                        var afterSplitedNewsBody = news.NewsTitle.Substring(maxLength - counterMinus + 1);


                        #region bind first page of body
                        htmlPageNews += "<li><div class='sitelogo'><img src='" + news.SiteLogo + "' /></div><div class='top-item'><span class='item-source'>" + news.SiteTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                         "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                        htmlPageNews += "<div class='middle-item' ><p class='item-lead'>" + news.NewsTitle + "</p></div>";
                        htmlPageNews += "<div class='bottom-item' ><span class='relation-title'>بازنشرها:</span><span class='item-relations'>" + news.RelateListSites + "</span></div></li>";
                        PageCounter++;
                        htmlPageNews = "<ul class='main-fehrast'>" + htmlPageNews + "</ul>";
                        footerHtml = @"<footer><span>" + PageCounter + @"</span></footer>";
                        html += "<div class='page newsContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                        #endregion

                        while (afterSplitedNewsBody.Length > MaxPageLength)
                        {
                            try
                            {
                                var afterSplitedNewsBody2 = afterSplitedNewsBody;

                                maxLength = afterSplitedNewsBody2.Length - (afterSplitedNewsBody2.Length - MaxPageLength);

                                splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength);
                                counterMinus = 1;

                                findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                counterWhile = 0;
                                while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                                {
                                    if (counterWhile > 500)
                                    {
                                        break;
                                    }
                                    counterMinus++;
                                    findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                    counterWhile++;
                                }
                                splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength - counterMinus + 1);
                                afterSplitedNewsBody = afterSplitedNewsBody2.Substring(maxLength - counterMinus + 1);

                                #region adding new page of body
                                htmlPageNews = "";
                                htmlPageNews += "<li><div class='sitelogo'><img src='" + news.SiteLogo + "' /></div><div class='top-item'><span class='item-source'>" + news.SiteTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                         "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                                htmlPageNews += "<div class='middle-item' ><p class='item-lead'>" + news.NewsTitle + "</p></div>";
                                htmlPageNews += "<div class='bottom-item' ><span class='relation-title'>بازنشرها:</span><span class='item-relations'>" + news.RelateListSites + "</span></div></li>";
                                PageCounter++;
                                htmlPageNews = "<ul class='main-fehrast'>" + htmlPageNews + "</ul>";
                                footerHtml = @"<footer><span>" + PageCounter + @"</span></footer>";
                                html += "<div class='page newsContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                                #endregion
                            }
                            catch
                            {

                            }
                        }
                    }

                }
            }
            catch
            {

            }

            return html;
        }
        private string LoadNews(Tbl_BultanArchive report, List<Tbl_News_Type> lstNews)
        {
            var allowRelated = false;
            try { allowRelated = (bool)report.AllowRelated; } catch { allowRelated = false; }


            string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
            string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
            string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));

            var MaxPageLength = 1900;
            var AddingPageLenghForOtherPage = 1000;
            var html = "";
            string relatedTitle = "اخبار مرتبط این خبر";
            var headerHtml = @" <header class='clearfix fehrest-header'>
                                                 <div class='header-container'>
                                                 <div class='right sarbarg-news'><img src='/Styles/img/news-heder.png' /></div>
                                                 <div class='center header-center'>
                                                     <div class='top-header'>
                                                        <span class='headerTitle'>بولتن مطبوعات و پایگاه های خبری</span> 
                                                        <span class='headerDate'>" + bultanCreateDate + @"<i class='fa fa-calendar-o'></i></span> 
                                                      </div>
                                                      <div class='bottom-header'>
                                                         <span class='headerBultanTitle'>" + report.Name + @"</span> 
                                                      </div>
                                                 </div> 
                                                </div>
                                 </header>";

            string htmlPageNews = "";

            try
            {
                int sizeOfContent = 0;

                string footerHtml = "";
                foreach (var news in lstNews)
                {
                    if (news.RelateListStrings == null)
                    {
                        relatedTitle = "";
                    }
                    else
                    {
                        if (news.RelateListStrings.Count == 0)
                            relatedTitle = "";
                    }


                    htmlPageNews = "";
                    string splitedNewsBody = "";
                    sizeOfContent = news.NewsBody.Length;

                    string newsPictureStr = "";
                    if (!string.IsNullOrEmpty(news.NewsPicture) && !news.NewsPicture.Contains("noimage"))
                        newsPictureStr = "<img class='newsbody-pic' src='" + news.NewsPicture + "' />";
                    int relatedCount = 0;


                    var relatedText = "";
                    if (allowRelated)
                    {
                        try
                        {
                            if (news.RelateListStrings != null)
                            {

                                try { relatedCount = news.RelateListStrings.Count; } catch { relatedCount = 0; }
                                foreach (var related in news.RelateListStrings)
                                {
                                    relatedText += "," + related.Split('$')[1];
                                }
                                if (!string.IsNullOrWhiteSpace(relatedText))
                                {
                                    relatedText = " " + "(" + relatedText.Substring(1) + ")";
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    //string testNews;
                    //if (news.NewsID == 13194982)
                    //    testNews = "";

                    var currentKey = keywords.FirstOrDefault(i => i.KeyId == news.KeywordId);


                    if (sizeOfContent < MaxPageLength)
                    {
                        string bodyContent = news.NewsBody;

                        htmlPageNews += "<div class='main-news'><div class='top-header'><div class='logosite'><img src='" + news.SiteLogo + "' /><div class='first-top' ><span class='sitetitle'>" +
                        news.SiteTitle + "</span><span class='key-name'>" + news.KeywordName + "</span><span class='keys-title'><i class='fa fa-key'></i>کلیدواژه ها:</span>" +
                        "</div><div class='second-top'><a href='" + news.NewsLink + "' class='news-title'>" + news.NewsTitle + "</a></div></div></div>";
                        if (!news.NewsPicture.Contains("noimage"))
                        {
                            htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + news.NewsLead + "</p></div><div class='lead-image'><img src='" + news.NewsPicture + "' /></div></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='middle-item'><div class='lead-noimg'><p class='item-lead'>" + news.NewsLead + "</p></div></div>";
                        }
                        if (report.AllowHighlight == true)
                        {
                            htmlPageNews += "<div class='third-item'><p class='item-body'>" + Class_Static.HighlightKeywordsBultanMedia(currentKey, CorrrectBody(bodyContent), keywords) + "</p></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='third-item'><p class='item-body'>" + CorrrectBody(bodyContent) + "</p></div>";
                        }
                        htmlPageNews += "<div class='four-item'><div class='item-rel'><span>" + relatedTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                      "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                        if (news.RelateListStrings != null)
                        {
                            if (news.RelateListStrings.Count > 0)
                                htmlPageNews += "<div class='item-rel-source'><span class='item-relations'>" + Class_Static.RemoveLastCharacter(news.RelateListSites) + "</span><i class='fa fa-bullhorn'></i><span class='rel-count'>" + relatedCount + "</span><span class='rel-title'>بازنشر:</span></div></div></div>";
                            else htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                        }
                        PageCounter++;
                        footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                        html += "<div class='page newsContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                    }
                    else
                    {
                        var maxLength = MaxPageLength;
                        splitedNewsBody = news.NewsBody.Substring(0, maxLength);
                        var counterMinus = 1;
                        var counterWhile = 0;
                        var findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                        while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                        {
                            if (counterWhile > 500)
                            {
                                break;
                            }
                            counterMinus++;
                            findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                            counterWhile++;
                        }
                        splitedNewsBody = news.NewsBody.Substring(0, (maxLength - counterMinus) + 1);
                        var afterSplitedNewsBody = news.NewsBody.Substring(maxLength - counterMinus + 1);


                        #region bind first page of body
                        htmlPageNews += "<div class='main-news'><div class='top-header'><div class='logosite'><img src='" + news.SiteLogo + "' /><div class='first-top' ><span class='sitetitle'>" +
news.SiteTitle + "</span><span class='key-name'>" + news.KeywordName + "</span><span class='keys-title'><i class='fa fa-key'></i>کلیدواژه ها:</span>" +
"</div><div class='second-top'><a href='" + news.NewsLink + "' class='news-title'>" + news.NewsTitle + "</a></div></div></div>";
                        if (!news.NewsPicture.Contains("noimage"))
                        {
                            htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + news.NewsLead + "</p></div><div class='lead-image'><img src='" + news.NewsPicture + "' /></div></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='middle-item'><div class='lead-noimg'><p class='item-lead'>" + news.NewsLead + "</p></div></div>";
                        }
                        if (report.AllowHighlight == true)
                        {
                            htmlPageNews += "<div class='third-item'><p class='item-body'>" + Class_Static.HighlightKeywordsBultanMedia(currentKey, CorrrectBody(splitedNewsBody), keywords) + "</p></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='third-item'><p class='item-body'>" + CorrrectBody(splitedNewsBody) + "</p></div>";
                        }
                        htmlPageNews += "<div class='third-item-sub'><span>ادامه خبر در صفحه بعد</span><i class='fa fa-angle-down'></i></div>";
                        htmlPageNews += "<div class='four-item'><div class='item-rel'><span>" + relatedTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                      "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                        if (news.RelateListStrings != null)
                        {
                            if (news.RelateListStrings.Count > 0)
                                htmlPageNews += "<div class='item-rel-source'><span class='item-relations'>" + Class_Static.RemoveLastCharacter(news.RelateListSites) + "</span><i class='fa fa-bullhorn'></i><span class='rel-count'>" + relatedCount + "</span><span class='rel-title'>بازنشر:</span></div></div></div>";
                            else htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                        }
                        PageCounter++;
                        footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                        html += "<div class='page newsContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                        #endregion

                        while (afterSplitedNewsBody.Length > (MaxPageLength + AddingPageLenghForOtherPage))
                        {
                            try
                            {
                                var afterSplitedNewsBody2 = afterSplitedNewsBody;

                                maxLength = afterSplitedNewsBody2.Length - (afterSplitedNewsBody2.Length - (MaxPageLength + AddingPageLenghForOtherPage));

                                splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength);
                                counterMinus = 1;

                                findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                counterWhile = 0;
                                while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                                {
                                    if (counterWhile > 500)
                                    {
                                        break;
                                    }
                                    counterMinus++;
                                    findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                    counterWhile++;
                                }
                                splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength - counterMinus + 1);
                                afterSplitedNewsBody = afterSplitedNewsBody2.Substring(maxLength - counterMinus + 1);

                                #region adding new page of body
                                htmlPageNews = "";
                                htmlPageNews += "<div class='main-news'><div class='top-header'><div class='logosite'><img src='" + news.SiteLogo + "' /><div class='first-top' ><span class='sitetitle'>" +
 news.SiteTitle + "</span><span class='key-name'>" + news.KeywordName + "</span><span class='keys-title'><i class='fa fa-key'></i>کلیدواژه ها:</span>" +
 "</div><div class='second-top'><a href='" + news.NewsLink + "' class='news-title'>" + news.NewsTitle + "</a></div></div></div>";
                                if (report.AllowHighlight == true)
                                {
                                    htmlPageNews += "<div class='third-item'><p class='item-body'>" + Class_Static.HighlightKeywordsBultanMedia(currentKey, CorrrectBody(splitedNewsBody), keywords) + "</p></div>";
                                }
                                else
                                {
                                    htmlPageNews += "<div class='third-item'><p class='item-body'>" + CorrrectBody(splitedNewsBody) + "</p></div>";
                                }
                                htmlPageNews += "<div class='third-item-sub'><span>ادامه خبر در صفحه بعد</span><i class='fa fa-angle-down'></i></div>";
                                htmlPageNews += "<div class='four-item'><div class='item-rel'><span>" + relatedTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                              "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                                if (news.RelateListStrings != null)
                                {
                                    if (news.RelateListStrings.Count > 0)
                                        htmlPageNews += "<div class='item-rel-source'><span class='item-relations'>" + Class_Static.RemoveLastCharacter(news.RelateListSites) + "</span><i class='fa fa-bullhorn'></i><span class='rel-count'>" + relatedCount + "</span><span class='rel-title'>بازنشر:</span></div></div></div>";
                                    else htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                                }
                                else
                                {
                                    htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                                }
                                PageCounter++;
                                footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                                html += "<div class='page newsContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                                #endregion
                            }
                            catch
                            {

                            }
                        }

                        #region remainBody
                        htmlPageNews = "";
                        htmlPageNews += "<div class='main-news'><div class='top-header'><div class='logosite'><img src='" + news.SiteLogo + "' /><div class='first-top' ><span class='sitetitle'>" +
 news.SiteTitle + "</span><span class='key-name'>" + news.KeywordName + "</span><span class='keys-title'><i class='fa fa-key'></i>کلیدواژه ها:</span>" +
 "</div><div class='second-top'><a href='" + news.NewsLink + "' class='news-title'>" + news.NewsTitle + "</a></div></div></div>";
                        if (report.AllowHighlight == true)
                        {
                            htmlPageNews += "<div class='third-item'><p class='item-body'>" + Class_Static.HighlightKeywordsBultanMedia(currentKey, CorrrectBody(afterSplitedNewsBody), keywords) + "</p></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='third-item'><p class='item-body'>" + CorrrectBody(afterSplitedNewsBody) + "</p></div>";
                        }
                        htmlPageNews += "<div class='four-item'><div class='item-rel'><span>" + relatedTitle + "</span><i class='fa fa-calendar'></i><span class='item-date'>" + news.NewsDate +
                      "</span><span class='seperator'>|</span><span class='item-time'>" + news.NewsTime + "</span></div>";
                        if (news.RelateListStrings != null)
                        {
                            if (news.RelateListStrings.Count > 0)
                                htmlPageNews += "<div class='item-rel-source'><span class='item-relations'>" + Class_Static.RemoveLastCharacter(news.RelateListSites) + "</span><i class='fa fa-bullhorn'></i><span class='rel-count'>" + relatedCount + "</span><span class='rel-title'>بازنشر:</span></div></div></div>";
                            else htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='item-rel-source'></div></div></div>";
                        }
                        PageCounter++;
                        footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                        html += "<div class='page newsContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                        #endregion
                    }

                }
            }
            catch
            {

            }

            return html;
        }
        private string LoadTwitter(Tbl_BultanArchive report, List<Tbl_Twitter_Type> lstTwitter)
        {
            string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
            string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
            string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
            // var MaxPageLength = 1800;
            var AddingPageLenghForOtherPage = 750;
            var html = "";

            var headerHtml = @" <header class='clearfix fehrest-header'>
                                                 <div class='header-container'>
                                                 <div class='right sarbarg-news'><img src='/Styles/img/tw-heder.png' /></div>
                                                 <div class='center header-center'>
                                                     <div class='top-header'>
                                                        <span class='headerTitle'>بولتن شبکه اجتماعی توییتر</span> 
                                                        <span class='headerDate'>" + bultanCreateDate + @"<i class='fa fa-calendar-o'></i></span> 
                                                      </div>
                                                      <div class='bottom-header'>
                                                         <span class='headerBultanTitle'>" + report.Name + @"</span> 
                                                      </div>
                                                 </div> 
                                                </div>
                                 </header>";
            string htmlPageNews = "";

            try
            {
                int sizeOfContent = 0;
                int checkSizeOfSomeCOntent = 0;
                int listCount = lstTwitter.Count;
                int listIndex = 0;
                string footerHtml = "";

                foreach (var news in lstTwitter)
                {
                    string classCssNewsValue = "";
                    if (news.NewsValue == 0)
                        classCssNewsValue = "newsvalue-0";
                    else if (news.NewsValue == 1)
                        classCssNewsValue = "newsvalue-1";
                    else if (news.NewsValue == 2)
                        classCssNewsValue = "newsvalue-2";
                    else if (news.NewsValue == 3)
                        classCssNewsValue = "newsvalue-3";
                    else if (news.NewsValue == 4)
                        classCssNewsValue = "newsvalue-4";

                    sizeOfContent = news.Text.Length;
                    checkSizeOfSomeCOntent += sizeOfContent;
                    if (sizeOfContent < AddingPageLenghForOtherPage)
                    {
                        if (checkSizeOfSomeCOntent < AddingPageLenghForOtherPage)
                        {
                            // htmlPageNews += "";
                            htmlPageNews += "<div class='main-twits'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/twitter512.png' data-src='" + news.UserProfileImageUrl +
                                "' /></div><div class='first-top' ><span class='sitetitle'>" +
                            news.UserName + "</span><i class='fa fa-user-plus'></i><span class='user-id'>" + news.UserID +
                            "</span></div><div class='second-top'><span class='news-title'>" + news.UserScreenName + "</span></div></div>";
                            if (report.AllowHighlight == true)
                            {
                                htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + Class_Static.HighLight(news.Text, news.Keyword) + "</p></div><div class='lead-image'><img src='" + news.MediaUrl + "' /></div></div>";
                            }
                            else
                            {
                                htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + news.Text + "</p></div><div class='lead-image'><img src='" + news.MediaUrl + "' /></div></div>";
                            }
                            htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + news.Date +
                            "</span><span class='seperator'>|</span><span class='item-time'>" + news.Time +
                            "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                            "</span><i class='fa fa-heart'></i><span class='like-count'>" + news.FavoriteCount +
                            "</span><i class='fa fa-comment'></i><span class='comment-count'>" + news.QuoteCount +
                            "</span><i class='fa fa-retweet'></i><span class='retweet-count'>" + news.RetweetCount + "</span></div></div>";
                            if (listIndex == listCount - 1)
                            {
                                PageCounter++;
                                footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                                html += "<div class='page newsContainer twitterpage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                                checkSizeOfSomeCOntent = 0;
                                htmlPageNews = "";
                            }
                        }
                        else
                        {

                            PageCounter++;
                            footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                            html += "<div class='page newsContainer twitterpage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                            checkSizeOfSomeCOntent = sizeOfContent;
                            htmlPageNews = "";
                            htmlPageNews += "<div class='main-twits'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/twitter512.png' data-src='" + news.UserProfileImageUrl +
                                "' /></div><div class='first-top' ><span class='sitetitle'>" +
                            news.UserName + "</span><i class='fa fa-user-plus'></i><span class='user-id'>" + news.UserID +
                            "</span></div><div class='second-top'><span class='news-title'>" + news.UserScreenName + "</span></div></div>";
                            if (report.AllowHighlight == true)
                            {
                                htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + Class_Static.HighLight(news.Text, news.Keyword) + "</p></div><div class='lead-image'><img src='" + news.MediaUrl + "' /></div></div>";
                            }
                            else
                            {
                                htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + news.Text + "</p></div><div class='lead-image'><img src='" + news.MediaUrl + "' /></div></div>";
                            }
                            htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + news.Date +
                            "</span><span class='seperator'>|</span><span class='item-time'>" + news.Time +
                            "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                            "</span><i class='fa fa-heart'></i><span class='like-count'>" + news.FavoriteCount +
                            "</span><i class='fa fa-comment'></i><span class='comment-count'>" + news.QuoteCount +
                            "</span><i class='fa fa-retweet'></i><span class='retweet-count'>" + news.RetweetCount + "</span></div></div>";
                            if (listIndex == listCount - 1)
                            {
                                PageCounter++;
                                footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                                html += "<div class='page newsContainer twitterpage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                                checkSizeOfSomeCOntent = 0;
                                htmlPageNews = "";
                            }
                        }
                    }
                    else
                    {
                        htmlPageNews = "";
                        htmlPageNews += "<div class='main-twits'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/twitter512.png' data-src='" + news.UserProfileImageUrl +
                            "' /></div><div class='first-top' ><span class='sitetitle'>" +
                        news.UserName + "</span><i class='fa fa-user-plus'></i><span class='user-id'>" + news.UserID +
                        "</span></div><div class='second-top'><span class='news-title'>" + news.UserScreenName + "</span></div></div>";
                        if (report.AllowHighlight == true)
                        {
                            htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + Class_Static.HighLight(news.Text, news.Keyword) + "</p></div><div class='lead-image'><img src='" + news.MediaUrl + "' /></div></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='middle-item'><div class='lead'><p class='item-lead'>" + news.Text + "</p></div><div class='lead-image'><img src='" + news.MediaUrl + "' /></div></div>";
                        }
                        htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + news.Date +
                        "</span><span class='seperator'>|</span><span class='item-time'>" + news.Time +
                        "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                        "</span><i class='fa fa-heart'></i><span class='like-count'>" + news.FavoriteCount +
                        "</span><i class='fa fa-comment'></i><span class='comment-count'>" + news.QuoteCount +
                        "</span><i class='fa fa-retweet'></i><span class='retweet-count'>" + news.RetweetCount + "</span></div></div>";
                        PageCounter++;
                        footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                        html += "<div class='page newsContainer twitterpage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                    }

                    listIndex++;
                }
            }
            catch
            {

            }

            return html;
        }
        private string LoadTelegrams(Tbl_BultanArchive report, List<Tbl_Telegram_Type> lstTelegrams)
        {
            string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
            string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
            string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
            int index = 0;
            var MaxPageLength = 1000;
            int PageContentCounter = 0;
            var html = "";

            var headerHtml = @" <header class='clearfix fehrest-header'>
                                                 <div class='header-container'>
                                                 <div class='right sarbarg-news'><img src='/Styles/img/tele-heder.png' /></div>
                                                 <div class='center header-center'>
                                                     <div class='top-header'>
                                                        <span class='headerTitle'>بولتن پیام رسان تلگرام</span> 
                                                        <span class='headerDate'>" + bultanCreateDate + @"<i class='fa fa-calendar-o'></i></span> 
                                                        </div>
                                                      <div class='bottom-header'>
                                                         <span class='headerBultanTitle'>" + report.Name + @"</span> 
                                                      </div>
                                                 </div> 
                                                </div>
                                 </header>";

            string htmlPageNews = "";

            try
            {
                int sizeOfContent = 0;

                string footerHtml = "";
                foreach (var news in lstTelegrams)
                {
                    string classCssNewsValue = "";
                    if (news.NewsValue == 0)
                        classCssNewsValue = "newsvalue-0";
                    else if (news.NewsValue == 1)
                        classCssNewsValue = "newsvalue-1";
                    else if (news.NewsValue == 2)
                        classCssNewsValue = "newsvalue-2";
                    else if (news.NewsValue == 3)
                        classCssNewsValue = "newsvalue-3";
                    else if (news.NewsValue == 4)
                        classCssNewsValue = "newsvalue-4";
                    string splitedNewsBody = "";
                    sizeOfContent = news.MessageText.Length;
                    PageContentCounter += sizeOfContent;
                    index++;
                    if (sizeOfContent < MaxPageLength)
                    {
                        if (PageContentCounter < MaxPageLength)
                        {
                            htmlPageNews += "<div class='main-telegram'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/telegram512.png' data-src='/Styles/img/telegram512.png' /></div><div class='first-top' ><span class='sitetitle'>" +
                           news.Username + "</span><i class='fa fa-user-plus'></i><span class='user-id'>" + news.PostID +
                           "</span></div><div class='second-top'><span class='news-title'>" + news.Channel + "</span></div></div>";
                            if (report.AllowHighlight == true)
                            {
                                htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + Class_Static.HighLight(news.MessageText, news.Keyword) + "</p></div></div>";
                            }
                            else
                            {
                                htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + news.MessageText + "</p></div></div>";
                            }
                            htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + news.MessageDate +
                            "</span><span class='seperator'>|</span><span class='item-time'>" + news.MessageTime +
                            "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                            "</span><i class='fa fa-eye'></i><span class='like-count'>" + news.ViewCount +
                            "</span></div></div>";

                            if (index == lstTelegrams.Count)
                            {
                                PageCounter++;
                                footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                                html += "<div class='page newsContainer telegrampage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                            }
                        }
                        else
                        {
                            PageCounter++;
                            footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                            html += "<div class='page newsContainer telegrampage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";



                            htmlPageNews = "";
                            htmlPageNews += "<div class='main-telegram'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/telegram512.png' data-src='/Styles/img/telegram512.png' /></div><div class='first-top' ><span class='sitetitle'>" +
                           news.Username + "</span><i class='fa fa-user-plus'></i><span class='user-id'>" + news.PostID +
                           "</span></div><div class='second-top'><span class='news-title'>" + news.Channel + "</span></div></div>";
                            if (report.AllowHighlight == true)
                            {
                                htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + Class_Static.HighLight(news.MessageText, news.Keyword) + "</p></div></div>";
                            }
                            else
                            {
                                htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + news.MessageText + "</p></div></div>";
                            }
                            htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + news.MessageDate +
                            "</span><span class='seperator'>|</span><span class='item-time'>" + news.MessageTime +
                            "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                            "</span><i class='fa fa-eye'></i><span class='like-count'>" + news.ViewCount +
                            "</span></div></div>";
                            PageContentCounter = sizeOfContent;

                        }
                    }
                    else
                    {
                        var maxLength = MaxPageLength;
                        splitedNewsBody = news.MessageText.Substring(0, maxLength);
                        var counterMinus = 1;
                        var counterWhile = 0;
                        var findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                        while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                        {
                            if (counterWhile > 300)
                            {
                                break;
                            }
                            counterMinus++;
                            findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                            counterWhile++;
                        }
                        splitedNewsBody = news.MessageText.Substring(0, (maxLength - counterMinus) + 1);
                        var afterSplitedNewsBody = news.MessageText.Substring(maxLength - counterMinus + 1);


                        #region bind first page of body
                        htmlPageNews += "<div class='main-telegram'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/telegram512.png' data-src='/Styles/img/telegram512.png' /></div><div class='first-top' ><span class='sitetitle'>" +
                       news.Username + "</span><i class='fa fa-user-plus'></i><span class='user-id'>" + news.PostID +
                       "</span></div><div class='second-top'><span class='news-title'>" + news.Channel + "</span></div></div>";
                        if (report.AllowHighlight == true)
                        {
                            htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + Class_Static.HighLight(splitedNewsBody, news.Keyword) + "</p></div></div>";
                        }
                        else
                        {
                            htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + splitedNewsBody + "</p></div></div>";
                        }
                        htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + news.MessageDate +
                        "</span><span class='seperator'>|</span><span class='item-time'>" + news.MessageTime +
                        "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                        "</span><i class='fa fa-eye'></i><span class='like-count'>" + news.ViewCount +
                        "</span></div></div>";
                        PageCounter++;
                        footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                        html += "<div class='page newsContainer telegrampage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                        #endregion

                        while (afterSplitedNewsBody.Length > MaxPageLength)
                        {
                            try
                            {
                                var afterSplitedNewsBody2 = afterSplitedNewsBody;

                                maxLength = afterSplitedNewsBody2.Length - (afterSplitedNewsBody2.Length - MaxPageLength);

                                splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength);
                                counterMinus = 1;

                                findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                counterWhile = 0;
                                while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                                {
                                    if (counterWhile > 300)
                                    {
                                        break;
                                    }
                                    counterMinus++;
                                    findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                    counterWhile++;
                                }
                                splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength - counterMinus + 1);
                                afterSplitedNewsBody = afterSplitedNewsBody2.Substring(maxLength - counterMinus + 1);

                                #region adding new page of body
                                htmlPageNews = "";
                                htmlPageNews += "<div class='main-telegram'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/telegram512.png' data-src='/Styles/img/telegram512.png' /></div><div class='first-top' ><span class='sitetitle'>" +
                      news.Username + "</span><i class='fa fa-user-plus'></i><span class='user-id'>" + news.PostID +
                      "</span></div><div class='second-top'><span class='news-title'>" + news.Channel + "</span></div></div>";
                                if (report.AllowHighlight == true)
                                {
                                    htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + Class_Static.HighLight(splitedNewsBody, news.Keyword) + "</p></div></div>";
                                }
                                else
                                {
                                    htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + splitedNewsBody + "</p></div></div>";
                                }
                                htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + news.MessageDate +
                                "</span><span class='seperator'>|</span><span class='item-time'>" + news.MessageTime +
                                "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                                "</span><i class='fa fa-eye'></i><span class='like-count'>" + news.ViewCount +
                                "</span></div></div>";
                                PageCounter++;
                                footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                                html += "<div class='page newsContainer telegrampage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
                                #endregion
                            }
                            catch
                            {

                            }
                        }
                    }

                }
            }
            catch
            {

            }

            return html;
        }
        private string LoadInstagrams(Tbl_BultanArchive report, List<Tbl_Instagram_Type> lstInstagrams)
        {
            string bultanNewsFromDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.FromDateIndex));
            string bultanNewsToDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.ToDateIndex));
            string bultanCreateDate = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(report.NewsDateIndex));
            var MaxPageLength = 100;
            int PageContentCounter = 0;
            var html = "";

            var headerHtml = @" <header class='clearfix fehrest-header'>
                                                 <div class='header-container'>
                                                 <div class='right sarbarg-news'><img src='/Styles/img/insta-heder.png' /></div>
                                                 <div class='center header-center'>
                                                     <div class='top-header'>
                                                        <span class='headerTitle'>بولتن شبکه اجتماعی اینستاگرام</span> 
                                                        <span class='headerDate'>" + bultanCreateDate + @"<i class='fa fa-calendar-o'></i></span> 
                                                      </div>
                                                      <div class='bottom-header'>
                                                         <span class='headerBultanTitle'>" + report.Name + @"</span> 
                                                      </div>
                                                 </div> 
                                                </div>
                                 </header>";
            string htmlPageNews = "";

            try
            {
                string footerHtml = "";
                foreach (var news in lstInstagrams)
                {
                    string classCssNewsValue = "";
                    if (news.NewsValue == 0)
                        classCssNewsValue = "newsvalue-0";
                    else if (news.NewsValue == 1)
                        classCssNewsValue = "newsvalue-1";
                    else if (news.NewsValue == 2)
                        classCssNewsValue = "newsvalue-2";
                    else if (news.NewsValue == 3)
                        classCssNewsValue = "newsvalue-3";
                    else if (news.NewsValue == 4)
                        classCssNewsValue = "newsvalue-4";

                    htmlPageNews = "";
                    htmlPageNews += "<div class='main-instagram'><div class='top-header'><div class='logosite'><img class='lazy " + classCssNewsValue + "' src='/Styles/img/insta-header-icon.png' data-src='" + news.ProfilePicUrl + "'/></div><div class='first-top' ><span class='sitetitle'>" +
                   news.UserName + "</span><div class='feature-icon'><span class='comment-count'>" + news.CommentsCount + "</span><i class='fa fa-comment'></i><span class='like-count'>" + news.LikeCount +
                   "</span><i class='fa fa-heart'></i></div></div><div class='second-top'><span class='news-title'>" + news.FullName + "</span></div></div>";
                    if (report.AllowHighlight == true)
                    {
                        htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + Class_Static.HighLight(news.CaptionText, news.Keyword) + "</p></div><div class='post-pic'><img src='" + news.DisplayUrl + "' /></div> </div>";
                    }
                    else
                    {
                        htmlPageNews += "<div class='middle-item'><div class='message'><p class='item-message'>" + news.CaptionText + "</p></div><div class='post-pic'><img src='" + news.DisplayUrl + "' /></div> </div>";
                    }
                    htmlPageNews += "<div class='third-item'><i class='fa fa-calendar'></i><span class='item-date'>" + Class_Static.ConvertIndexDateTimeToDateString(news.DateTimeIndex) +
                    "</span><span class='seperator'>|</span><span class='item-time'>" + Class_Static.ConvertIndexDateTimeToTimeString(news.DateTimeIndex) +
                    "</span><i class='fa fa-key'></i><span class='key-name'>کلیدواژه ها:</span><span class='key-title'>" + news.Keyword +
                    "</span></div></div>";
                    PageCounter++;
                    footerHtml = @"<footer><div class='footer-sarbarg'><hr><span>" + PageCounter + @"</span></div></footer>";
                    html += "<div class='page newsContainer instagrampage'> " + headerHtml + htmlPageNews + footerHtml + "</div>";

                }
            }
            catch
            {

            }

            return html;
        }

        public static List<Tbl_News_Type> LoadRelated(List<Tbl_News_Type> NewsList)
        {
            DataSet ds = null;
            List<Tbl_News_Type> compiledList = new List<Tbl_News_Type>();

            try
            {
                foreach (var nn in NewsList)
                {

                    nn.RelateListStrings = new List<string>();

                    List<int> newsRelatedIdList = new List<int>();
                    if (nn.RelatedString != null && nn.RelatedString != "")
                        if (nn.RelatedString.Contains(","))
                        {
                            foreach (var i in nn.RelatedString.Split(','))
                            {
                                newsRelatedIdList.Add(Convert.ToInt32(i));
                                try
                                {
                                    string siteTitle = Class_News.GetNewsSiteTitle(Convert.ToInt32(i)); //NewsList.First(j => j.NewsID == Convert.ToInt32(i)).SiteTitle;
                                    string newsTitle = Class_News.GetNewsTitle(Convert.ToInt32(i));//NewsList.First(j => j.NewsID == Convert.ToInt32(i)).NewsTitle;;
                                    nn.RelateListStrings.Add(i + "$" + siteTitle + "$" + newsTitle);
                                    nn.RelateListSites += siteTitle + ",";
                                }
                                catch { continue; }
                            }
                        }
                        else
                        {
                            newsRelatedIdList.Add(Convert.ToInt32(nn.RelatedString));
                            try
                            {
                                string siteTitle = Class_News.GetNewsSiteTitle(Convert.ToInt32(nn.RelatedString));
                                string newsTitle = Class_News.GetNewsTitle(Convert.ToInt32(nn.RelatedString));
                                //string siteTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(nn.RelatedString)).SiteTitle;
                                //string newsTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(nn.RelatedString)).NewsTitle;
                                nn.RelateListStrings.Add(nn.RelatedString + "$" + siteTitle + "$" + newsTitle);
                                nn.RelateListSites += siteTitle + ",";
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    nn.RelateListIds = newsRelatedIdList;
                    compiledList.Add(nn);

                }
            }
            catch (Exception ex) { }
            return compiledList;
        }
        public string CorrrectBody(string body)
        {
            string bodyContent = "";
            string[] contentBodySplited = null;
            if (body.Contains("."))
                contentBodySplited = body.Split('.');
            else if (body.Contains("."))
                contentBodySplited = body.Split('.');
            else if (body.Contains(";"))
                contentBodySplited = body.Split(';');
            else if (body.Contains(","))
                contentBodySplited = body.Split(',');
            else if (body.Contains("،"))
                contentBodySplited = body.Split('،');
            else if (body.Contains("."))
                contentBodySplited = body.Split('.');
            else bodyContent = body;

            if (contentBodySplited != null)
            {
                foreach (var b in contentBodySplited)
                {
                    if (b.Trim().Length > 200)
                        bodyContent += "  " + b.Trim() + ". </br>";
                    else bodyContent += "  " + b.Trim() + ". ";
                }
            }
            return bodyContent;
        }

    }
}