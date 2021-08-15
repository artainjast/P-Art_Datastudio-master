using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNews;
using PArt.Core;
using System.Drawing;
using P_Art.Pages.P_Art.Repository;
using HtmlAgilityPack;
using System.Data;
using System.Text;

namespace PArt.Pages.P_Art.Pages
{
    public partial class ShowNews : System.Web.UI.Page
    {
        Class_News _clsNews = new Class_News();
        Class_Zaman _clsZm = new Class_Zaman();
        Class_Sites _clsSite = new Class_Sites();
        HtmlRemoval _html = new HtmlRemoval();
        Class_User _user = new Class_User();
        Class_Keywords _clsKeyword = new Class_Keywords();
#pragma warning disable CS0169 // The field 'ShowNews.dsAllData' is never used
        DataSet dsAllData;
#pragma warning restore CS0169 // The field 'ShowNews.dsAllData' is never used
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();


        protected void Page_Load(object sender, EventArgs e)
        {
            string kwords = "";
            Class_Layer.CheckSession();
            if (RouteData.Values["newsid"] != null)
            {
                bool isRead = false;
                if (Request.Url.AbsolutePath.ToLower().IndexOf("showblock") == -1)
                {
                    isRead = true;
                }
                else
                {
                    isRead = false;
                }
                Tbl_News news = _clsNews.GetNewsById(int.Parse(RouteData.Values["newsid"].ToString()), isRead);
                EditNewsButton.HRef = "/addnews?Id=" + news.NewsID;

                if (news != null)
                {
#pragma warning disable CS0219 // The variable 'keyid' is assigned but its value is never used
                    var keyid = "";
#pragma warning restore CS0219 // The variable 'keyid' is assigned but its value is never used
                    HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();

                    if (news.KeyIds != null && news.KeyIds != string.Empty)
                        kwords = news.KeyIds;
                    else
                        kwords = news.KeywordId.ToString();
                    var keywords = _clsKeyword.GetRssKeywordByPanelIds2(kwords);
                    Tbl_RssKeywords currentKey = new Tbl_RssKeywords();
                    try
                    {
                        currentKey = _clsKeyword.GetRssKeywordById(Convert.ToInt32(news.KeywordId));
                        this.Title = (news.NewsTitle + "").Trim();
                        news.NewsTitle = HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(news.NewsTitle + "", false), keywords);
                        news.NewsLead = HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(news.NewsLead + "", false), keywords);
                        news.NewsBody = HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(news.NewsBody + "", false), keywords);
                    }
                    catch
                    {
                        this.Title = (news.NewsTitle + "").Trim();
                        news.NewsTitle = news.NewsTitle;
                        news.NewsLead = news.NewsLead;
                        news.NewsBody = news.NewsBody;
                    }
                    lblNewsTitle.Text = (news.NewsTitle);

                    var bodyText = (news.NewsBody).Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    int sentencesLength = 0;
                    StringBuilder BodyAdjustedText = new StringBuilder();
                    foreach (var sentence in bodyText)
                    {
                        if (sentencesLength < 400)
                        {
                            sentencesLength += sentence.Length;
                            BodyAdjustedText.Append(sentence.Trim());
                            BodyAdjustedText.Append(". ");
                        }
                        else
                        {
                            sentencesLength = sentence.Length;
                            BodyAdjustedText.Append(sentence.Trim());
                            BodyAdjustedText.Append(". ");
                            BodyAdjustedText.Append("<br/>");
                        }
                    }

                    lblNewsLead.InnerHtml = (news.NewsLead);
                    LblNewsBody.InnerHtml = BodyAdjustedText.ToString();
                    lblNewsDate.Text = _clsZm.GetNewsDate(news.NewsDate);
                    try
                    {
                        lblSource.Text = Class_Static.PersianAlpha(_clsSite.GetSiteById(news.SiteID).SiteTitle);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    lblNewsUser.Text = Class_Static.PersianAlpha(_user.GetDBUser(news.CreateUser).UserName);

                    if (news.KeywordId == null)
                    {
                        divKeyword.Visible = false;
                    }
                    else
                    {


                        Class_Keywords _clsKeyword = new Class_Keywords();

                        string newsMerge = Class_Static.PersianAlpha(news.NewsTitle + " " + news.NewsLead + " " + news.NewsBody);

                        newsMerge = newsMerge.Replace("-", " ");
                        newsMerge = newsMerge.Replace(".", " . ");
                        newsMerge = newsMerge.Replace(":", " : ");
                        newsMerge = newsMerge.Replace("?", " ? ");
                        newsMerge = newsMerge.Replace("!", " ! ");
                        newsMerge = newsMerge.Replace("،", " ، ");
                        newsMerge = newsMerge.Replace(",", " , ");

                        newsMerge = " " + newsMerge + " ";
                        string findKeywords = "";
                        foreach (var key in keywords)
                        {
                            key.KeywordName = Class_Static.PersianAlpha((key.KeywordName));
                            if (newsMerge.IndexOf(" " + key.KeywordName + " ") > -1)
                            {
                                if (findKeywords.IndexOf(" " + key.KeywordName + " ") == -1)
                                {
                                    findKeywords += key.KeywordName + " / ";
                                }

                            }
                        }

                        if (kwords != null)
                        {
                            if (findKeywords.IndexOf(" " + currentKey.KeywordName + " ") == -1)
                            {
                                findKeywords += Class_Static.PersianAlpha(currentKey.KeywordName);
                            }

                        }

                        lblKeywordName.Text = Class_Static.PersianAlpha(findKeywords);
                        divKeyword.Visible = true;
                    }
                    lnk_news.HRef = news.NewsLink;

                    if (news.NewsPicture == null)
                    {
                        img_post.ImageUrl = "/Pages/P-Art/Images/newsPreview.jpg";
                    }
                    else if (news.NewsPicture == "")
                    {
                        img_post.ImageUrl = "/Pages/P-Art/Images/newsPreview.jpg";
                    }
                    else
                    {
                        img_post.ImageUrl = news.NewsPicture;
                        System.Drawing.Image img = Class_Core.getUrlImage(news.NewsPicture);

                        //try
                        //{
                        //    if (img.Width > img.Height)
                        //    {
                        //        //image was width
                        //        if (img.Width >= 500)
                        //        {
                        //            img_post.Width = 500;
                        //            img_post.Height = 320;
                        //        }
                        //    }
                        //    else if (img.Width < img.Height)
                        //    {
                        //        //image was heigh
                        //        if (img.Height >= 500)
                        //        {
                        //            img_post.Width = 400;
                        //            img_post.Height = 600;
                        //        }
                        //    }
                        //    else
                        //    {
                        //    }
                        //}
                        //catch
                        //{

                        //}
                    }

                    UpdateViewCount(news.NewsID);

                }
            }

            if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            {
                div_manage.Visible = true;
                ViewState["NewsId"] = RouteData.Values["newsid"];

            }
            else
            {
                div_manage.Visible = false;
            }
        }

        private void UpdateViewCount(int NewsId)
        {
            var news = _db.Tbl_News.First(n => n.NewsID == NewsId);
            news.ViewCount = news.ViewCount + 1 ?? 1;
            _db.Entry(news).State = EntityState.Modified;
            _db.SaveChanges();
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            Class_News _cls = new Class_News();
            int newsId = int.Parse(RouteData.Values["newsid"].ToString());
            _cls.DeleteNews(newsId);
            Response.Redirect("~/news/Latest");
        }
        //public string HighlightKeywords(Tbl_RssKeywords currentKey, string txt, List<Tbl_RssKeywords> keywords)
        //{
        //    if (string.IsNullOrWhiteSpace(txt))
        //    {
        //        return "";
        //    }
        //    txt = txt.Replace(@"http://www.talanews.com/fa/plugins/content/jumultithumb/img.php?src=Li4vLi4vLi4vaW1hZ2VzL3N0b3JpZXMvYmFua29fYmltZS9KQUhBTkdJUkkuanBnJmFtcDt3PTgwMCZhbXA7aD02MDAmYW1wO3E9MTAw", "");
        //    try
        //    {
        //        txt = txt.Replace("<br/>", "");
        //        txt = txt.Replace("<br>", "");
        //    }
        //    catch
        //    {

        //    }
        //    HtmlNode txtHtml = HtmlNode.CreateNode(txt);



        //    string newsMerge = Class_Static.PersianAlpha(Class_Static.GetAbsoulateTextFromHtmlNode(txtHtml));

        //    newsMerge = newsMerge.Replace("-", " ");
        //    newsMerge = newsMerge.Replace(".", " . ");
        //    newsMerge = newsMerge.Replace(":", " : ");
        //    newsMerge = newsMerge.Replace("?", " ? ");
        //    newsMerge = newsMerge.Replace("!", " ! ");
        //    newsMerge = newsMerge.Replace("،", " ، ");
        //    newsMerge = " " + newsMerge + " ";

        //    var findKeywords = new List<string>();
        //    foreach (var key in keywords)
        //    {
        //        foreach (var itemKey in key.KeywordName.Split('+'))
        //        {
        //            List<string> keys = new List<string>();
        //            var item_Key = Class_Static.PersianAlpha((itemKey)).ToLower();
        //            keys.Add(item_Key);
        //            if (newsMerge.IndexOf(" " + item_Key + " ") > -1 )
        //            {
        //                if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
        //                {
        //                    findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
        //                }

        //            }
        //        }
        //    }


        //    if (currentKey != null)
        //    {

        //        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(currentKey.KeywordName.Trim())))
        //        {
        //            findKeywords.Add(Class_Static.PersianAlpha(currentKey.KeywordName.Trim()));

        //        }

        //    }
        //    foreach (var item in findKeywords)
        //    {
        //        newsMerge = newsMerge.Replace(item, "<span class='highlight'>" + item + "</span>");
        //    }

        //    return newsMerge.Trim();

        //}
        public string HighlightKeywords(Tbl_RssKeywords currentKey, string txt, List<Tbl_RssKeywords> keywords)
        {
            //// if (string.IsNullOrWhiteSpace(txt))
            //// {
            ////     return "";
            //// }
            //// txt = txt.Replace(@"http://www.talanews.com/fa/plugins/content/jumultithumb/img.php?src=Li4vLi4vLi4vaW1hZ2VzL3N0b3JpZXMvYmFua29fYmltZS9KQUhBTkdJUkkuanBnJmFtcDt3PTgwMCZhbXA7aD02MDAmYW1wO3E9MTAw", "");
            //// try
            //// {
            ////     txt = txt.Replace("<br/>", "");
            ////     txt = txt.Replace("<br>", "");
            //// }
            //// catch
            //// {

            //// }
            //// HtmlNode txtHtml = HtmlNode.CreateNode(txt);



            //// string newsMerge = Class_Static.PersianAlpha(Class_Static.GetAbsoulateTextFromHtmlNode(txtHtml));

            //// newsMerge = newsMerge.Replace("-", " ");
            //// newsMerge = newsMerge.Replace(".", " . ");
            //// newsMerge = newsMerge.Replace(":", " : ");
            //// newsMerge = newsMerge.Replace("?", " ? ");
            //// newsMerge = newsMerge.Replace("!", " ! ");
            //// newsMerge = newsMerge.Replace("،", " ، ");
            //// newsMerge = " " + newsMerge + " ";

            //// var findKeywords = new List<string>();
            //// foreach (var key in keywords)
            //// {
            ////     foreach (var itemKey in key.KeywordName.Split('+'))
            ////     {
            ////         List<string> keys = new List<string>();
            ////         var item_Key = Class_Static.PersianAlpha((itemKey)).ToLower();
            ////         keys.Add(item_Key);
            ////         if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
            ////         {
            ////             if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
            ////             {
            ////                 findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
            ////             }

            ////         }
            ////     }
            //// }


            //// //if (currentKey != null)
            //// //{

            //// //    if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(currentKey.KeywordName.Trim())))
            //// //    {
            //// //        findKeywords.Add(Class_Static.PersianAlpha(currentKey.KeywordName.Trim()));

            //// //    }

            ////// }
            //// foreach (var item in keywords)
            //// {
            ////     newsMerge = newsMerge.Replace(Class_Static.PersianAlpha(item.KeywordName.ToLower()), "<span class='highlight'>" + Class_Static.PersianAlpha(item.KeywordName.ToLower()) + "</span>");
            //// }

            //// return newsMerge.Trim();

            var item_Key = "";
            if (string.IsNullOrWhiteSpace(txt))
            {
                return "";
            }
            txt = txt.Replace(@"http://www.talanews.com/fa/plugins/content/jumultithumb/img.php?src=Li4vLi4vLi4vaW1hZ2VzL3N0b3JpZXMvYmFua29fYmltZS9KQUhBTkdJUkkuanBnJmFtcDt3PTgwMCZhbXA7aD02MDAmYW1wO3E9MTAw", "");
            txt = txt.Replace("<br/>", "");
            txt = txt.Replace("<br>", "");
            HtmlNode txtHtml = HtmlNode.CreateNode(txt);
            string newsMerge = Class_Static.PersianAlpha(Class_Static.GetAbsoulateTextFromHtmlNode(txtHtml));

            newsMerge = newsMerge.Replace("-", " ");
            newsMerge = newsMerge.Replace(".", " . ");
            newsMerge = newsMerge.Replace(":", " : ");
            newsMerge = newsMerge.Replace("?", " ? ");
            newsMerge = newsMerge.Replace("!", " ! ");
            newsMerge = newsMerge.Replace("،", " ، ");
            newsMerge = " " + newsMerge + " ";

            var findKeywords = new List<string>();
            foreach (var key in keywords)
            {
                if (key.KeywordName.Contains('+'))
                {
                    //foreach (var itemKey in key.KeywordName)
                    //{

                    item_Key = Class_Static.PersianAlpha((key.KeywordName)).ToLower() + "";

                    if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                    {
                        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                        {
                            findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                        }

                    }
                    //}
                }
                else
                {
                    foreach (var itemKey in key.KeywordName.Split('+'))
                    {

                        item_Key = Class_Static.PersianAlpha((itemKey)).ToLower() + "";

                        if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                        {
                            if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                            {
                                findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                            }

                        }
                    }
                }



            }


            if (currentKey != null)
            {

                if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(currentKey.KeywordName.Trim())))
                {
                    findKeywords.Add(Class_Static.PersianAlpha(currentKey.KeywordName.Trim()));

                }

            }
            foreach (var item in findKeywords)
            {
                try
                {
                    var txthighlight = (item + "").Trim();
                    newsMerge = newsMerge.Replace(item, "<span class='highlight'>" + txthighlight + "</span>");
                }
                catch
                {

                }
            }

            return newsMerge.Trim();

        }
    }
}