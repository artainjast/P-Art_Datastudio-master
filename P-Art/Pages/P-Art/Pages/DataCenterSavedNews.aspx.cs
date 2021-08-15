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
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Services;
using Word = Microsoft.Office.Interop.Word;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class DataCenterSavedNews : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();

        Class_News _clsNews = new Class_News();
        Class_Zaman _clsZm = new Class_Zaman();
        Class_Sites _clsSite = new Class_Sites();
        HtmlRemoval _html = new HtmlRemoval();
        Class_User _user = new Class_User();
        Class_Keywords _clsKeyword = new Class_Keywords();
#pragma warning disable CS0169 // The field 'DataCenterSavedNews.dsAllData' is never used
        DataSet dsAllData;
#pragma warning restore CS0169 // The field 'DataCenterSavedNews.dsAllData' is never used
        Tbl_AgenceMembers agenceMembers = new Tbl_AgenceMembers();
        PersianCalendar persianCalendar = new PersianCalendar();

        Tbl_DataCenterNews news;

        Class_Panels _clsPanels = new Class_Panels();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            string kwords = "";
            Class_Layer.CheckSession();
            if (RouteData.Values["newsid"] != null)
            {
#pragma warning disable CS0219 // The variable 'isRead' is assigned but its value is never used
                bool isRead = false;
#pragma warning restore CS0219 // The variable 'isRead' is assigned but its value is never used
                if (Request.Url.AbsolutePath.ToLower().IndexOf("showblock") == -1)
                {
                    isRead = true;
                }
                else
                {
                    isRead = false;
                }
                //var currentUser = Class_Layer.CurrentUser();
                int newsId = int.Parse(RouteData.Values["newsid"].ToString());
                news = (from row in _db.Tbl_DataCenterNews where row.NewsID == newsId select row).FirstOrDefault();


                if (news != null)
                {
                    NewsIdHiddenField.Value = news.NewsID.ToString();

                    if (!IsPostBack)
                    {
                        NewsTitleText.Value = news.NewsTitle;
                        NewsLeadText.Value = news.NewsLead;
                        NewsBodyText.Value = news.NewsBody;
                    }
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
                    currentKey = _clsKeyword.GetRssKeywordById(Convert.ToInt32(news.KeywordId));

                    this.Title = (news.NewsTitle + "").Trim();

                    lblNewsTitle.Text = (news.NewsTitle);
                    lblNewsLead.InnerHtml = (news.NewsLead);
                    LblNewsBody.InnerHtml = (news.NewsBody);


                    lblNewsDate.Text = _clsZm.GetNewsDate(news.NewsDate);

                    try
                    {
                        int siteId = Convert.ToInt32(news.SiteID);
                        lblSource.Text = Class_Static.PersianAlpha(_clsSite.GetSiteById(siteId).SiteTitle);

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }

                    //lblNewsUser.Text = Class_Static.PersianAlpha(_user.GetDBUser(news.ArchiveByMemberID).UserName);

                    if (news.KeyIds == null)
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
                    lnk_news.HRef = news.NewsUrl;

                    if (news.NewsImageUrl == null)
                    {
                        img_post.ImageUrl = "/Pages/P-Art/Images/newsPreview.jpg";
                    }
                    else if (news.NewsImageUrl == "")
                    {
                        img_post.ImageUrl = "/Pages/P-Art/Images/newsPreview.jpg";
                    }
                    else
                    {
                        img_post.ImageUrl = news.NewsImageUrl;
                        System.Drawing.Image img = Class_Core.getUrlImage(news.NewsImageUrl);

                    }

                }
            }

            //if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            //{
            //    div_manage.Visible = true;
            //    ViewState["NewsId"] = RouteData.Values["newsid"];

            //}
            //else
            //{
            //    div_manage.Visible = false;
            //}
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            Class_News _cls = new Class_News();
            int newsId = int.Parse(RouteData.Values["newsid"].ToString());
            _cls.DeleteNews(newsId);
            Response.Redirect("~/news/Latest");
        }

        public string HighlightKeywords(Tbl_RssKeywords currentKey, string txt, List<Tbl_RssKeywords> keywords)
        {
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

                    item_Key = Class_Static.PersianAlpha((key.KeywordName)).ToLower() + "";

                    if (newsMerge.IndexOf(" " + item_Key + " ") > -1)
                    {
                        if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(item_Key.Trim())))
                        {
                            findKeywords.Add(Class_Static.PersianAlpha(item_Key.Trim()));
                        }

                    }

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


        protected void SaveNewsEditButton_click(object sender, EventArgs e)
        {
            Int64 CurrentDateTime = Convert.ToInt64(string.Format("{0}{1}{2}{3}{4}", persianCalendar.GetYear(DateTime.Now), persianCalendar.GetMonth(DateTime.Now),
               persianCalendar.GetDayOfMonth(DateTime.Now), persianCalendar.GetHour(DateTime.Now), persianCalendar.GetMinute(DateTime.Now)));
            var currentUser = HttpContext.Current.Session["CurrentUser"] as Tbl_AgenceMembers;


            Tbl_DataCenterNews UpdateDataCenterTable = new Tbl_DataCenterNews
            {
                NewsID = news.NewsID,
                SiteID = news.SiteID,
                ParminID = news.ParminID,
                NewsDate = news.NewsDate,
                NewsTime = news.NewsTime,
                NewsTitle = news.NewsTitle,
                NewsLead = NewsLeadText.Value,
                NewsBody = NewsBodyText.Value,
                NewsUrl = news.NewsUrl,
                NewsImageUrl = news.NewsImageUrl,
                CreateDate = news.CreateDate,
                KeywordId = news.KeywordId,
                GroupId = news.GroupId,
                SortOrder = news.SortOrder,
                NewsType = news.NewsType,
                NewsDateTimeIndex = news.NewsDateTimeIndex,
                KeyIds = news.KeyIds,
                ArchiveByMemberID = currentUser.MemberID,
                ArchiveDateTime = CurrentDateTime,
                IsChanged = true
            };
            var message = UpdateNewsInDataCenter(UpdateDataCenterTable);

        }


        [WebMethod]
        public static void DeleteDataCenterNews(string newsId)
        {
            int Id = Convert.ToInt32(newsId);
            try
            {
                _dbStatic.Tbl_DataCenterNews.Remove(_dbStatic.Tbl_DataCenterNews.Where(i => i.NewsID == Id).FirstOrDefault());
                _dbStatic.SaveChanges();
            }
            catch
            {

            }

        }
        public int CountDataCenterNewsById(int NewsId)
        {
            var rowCount = (from row in _db.Tbl_DataCenterNews
                            where row.NewsID == NewsId
                            select row).Count();
            return rowCount;
        }


        public string UpdateNewsInDataCenter(Tbl_DataCenterNews table)
        {
            string message = "";
            try
            {
                int userExist = CountDataCenterNewsById(table.NewsID);
                if (userExist == 0)
                {
                    table.NewsTitle = NewsTitleText.Value;
                    table.NewsLead = NewsLeadText.Value;
                    table.NewsBody = NewsBodyText.Value;
                    _db.Tbl_DataCenterNews.Add(table);
                    _db.SaveChanges();
                    message = "خبر با موفقیت درج شد";
                }
                else
                {
                    Tbl_DataCenterNews tableRow = _db.Tbl_DataCenterNews.First(i => i.NewsID == table.NewsID);

                    tableRow.NewsTitle = NewsTitleText.Value;
                    tableRow.NewsLead = NewsLeadText.Value;
                    tableRow.NewsBody = NewsBodyText.Value;
                    _db.SaveChanges();
                    message = "خبر با موفقیت ویرایش شد";
                }

            }
            catch
            {
                return "خطا در درج خبر";
            }
            return message;
        }
        protected void WordExport_click(object sender, EventArgs e)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);


            StringBuilder WordDocString = new StringBuilder();
            WordDocString.Append(news.NewsTitle + Environment.NewLine);
            WordDocString.Append(news.NewsLead + Environment.NewLine);
            WordDocString.Append(news.NewsBody + Environment.NewLine);
            string fileName = news.NewsTitle + ".doc";

            // You can add whatever you want to add as the HTML and it will be generated as Ms Word docs

            Response.AppendHeader("Content-Type", "application/msword");

            Response.AppendHeader("Content-disposition", "attachment; filename=" + fileName);

            Response.Write(WordDocString.ToString());

        }
       
    }
}