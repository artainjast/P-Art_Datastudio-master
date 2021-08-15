using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class ShowBultanNewsItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["newsid"] != null)
                {
                    try
                    {

                        LoadNewsItem(Convert.ToInt32(Request.QueryString["newsId"]));
                    }
                    catch { }
                }
            }
        }

        Class_News _clsNews = new Class_News();
        Class_Keywords _clsKeyword = new Class_Keywords();
        HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
        Class_Sites _clsSite = new Class_Sites();
        public void LoadNewsItem(int newsId)
        {
            var newsItem = _clsNews.GetNewsById(newsId);


            try
            {
                if (string.IsNullOrWhiteSpace(newsItem.NewsLead))
                {
                    newsItem.NewsLead = (newsItem.NewsBody).Split('.').FirstOrDefault() + ".";

                }
            }
            catch
            {

            }

            try
            {
                var currentKey = _clsKeyword.GetRssKeywordById(Convert.ToInt32(newsItem.KeywordId));

                var parminIds = new List<int?>();

                parminIds.Add(currentKey.PanelId);
                var keywords = _clsKeyword.GetRssKeywordByPanelIds(parminIds);




                newsItem.NewsTitle = Class_Static.HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(newsItem.NewsTitle, false), keywords);
                newsItem.NewsLead = Class_Static.HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(newsItem.NewsLead, false), keywords);
                newsItem.NewsBody = Class_Static.HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(newsItem.NewsBody, false), keywords);
            }
            catch
            {

            }

            try
            {
                newsItem.NewsLead = Class_Static.PrepareNewsLead(newsItem.NewsLead);
                newsItem.NewsBody = Class_Static.PrepareNewsBody(newsItem.NewsBody);
            }
            catch
            {

            }

            var site = _clsSite.GetSiteById(newsItem.SiteID);

            try
            {

                site.Logo = (site.Logo + "").ToLower().Replace("c:\\bultanforms\\logos\\", "http://media.e-sepaar.net/logo/");
                if (!Class_Static.UrlExists(site.Logo))
                {
                    site.Logo = "http://media.e-sepaar.net/logo/nologo.jpg";
                }

            }
            catch
            {

            }

            var html = "";

            var newsLinkHtml = "";
            if (!string.IsNullOrWhiteSpace(newsItem.NewsLink))
            {
                newsLinkHtml = @"  <div class='newsLink'>
                                    <a href='" + newsItem.NewsLink + @"'>
                                       شاهد خبر</a>
                                </div>";
            }
            var newsTimeTag = "";
            var pictureHtml = "";
            if (site.SiteType == 1)
            {
                newsTimeTag += @" <div class='newsTime'>
                                     " + newsItem.NewsTime + @"
                                </div> ";

            }
            if (Class_Static.UrlExists(newsItem.NewsPicture))
            {
                pictureHtml = @"  <div class='newsPicture'>
                                    <a>
                                        <img src='" + (newsItem.NewsPicture) + @"' /></a>
                                </div>";
            }


            //ثبت قسمت اول
            var htmlSingleNews = @"



                                                            <div class='newsItem clearfix'  data-id='" + newsItem.NewsID + @"'  id='news_" + newsItem.NewsID + @"'>

                                                                <div class='right newsTools' style=''>

                           

                                                          
                            <div class='siteLogo'><a><img src='" + (site.Logo) + @"'/></a></div>
                                                            <div class='siteTitle'>" + Class_Static.PersianAlpha(site.SiteTitle) + @"</div>
                             " + newsTimeTag + @"
                            
                              " + newsLinkHtml + @"
                             

                            </div>

                                                        <div class='right newsDetails' style=''>   
                                                            <div class='newsTitle'><a href = '" + (newsItem.NewsLink) + @"' target='_blank'>" + Class_Static.PersianAlpha(newsItem.NewsTitle) + @"</a></div>

                                                            <div class='newsLead'>" + (newsItem.NewsLead) + @"</div>
" + pictureHtml + @"
                                                            <div class='newsBody'>" + (newsItem.NewsBody) + @"</div>
                                                          </div>
                                                        </div>  ";

            var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'>نمایش خبر</span></div>   
                                                  
                                      <div class='left'>    <span class='headerBultanDate'></span></div>
                                    </header>"; var footerHtml = @"<footer><span>" + 1 + @"</span></footer>";
            if (!string.IsNullOrWhiteSpace(htmlSingleNews))
            {
                html += "<div class='page pageContainer'>" + headerHtml + htmlSingleNews + footerHtml + "</div>";

            }

            ltNews.Text = html;
            //   throw new NotImplementedException();
        }
    }
}