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
    public partial class TelegramMessageShow : System.Web.UI.Page
    {

        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();

        Class_News _clsNews = new Class_News();


        Tbl_Telegram_Messages message;

        Class_Panels _clsPanels = new Class_Panels();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";


        protected void Page_Load(object sender, EventArgs e)
        {
#pragma warning disable CS0219 // The variable 'kwords' is assigned but its value is never used
            string kwords = "";
#pragma warning restore CS0219 // The variable 'kwords' is assigned but its value is never used
            Class_Layer.CheckSession();
            if (RouteData.Values["Id"] != null)
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
                int messageId = int.Parse(RouteData.Values["Id"].ToString());
                message = (from row in _db.Tbl_Telegram_Messages where row.Id == messageId select row).FirstOrDefault();


                if (message != null)
                {
                    NewsIdHiddenField.Value = message.Id.ToString();

#pragma warning disable CS0219 // The variable 'keyid' is assigned but its value is never used
                    var keyid = "";
#pragma warning restore CS0219 // The variable 'keyid' is assigned but its value is never used
                    HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();

                    LblNewsBody.InnerHtml = (message.Message_Text);
                    lblNewsDate.Text = message.DateTimeInsert.ToString();
                    ChannelLabel.Text = message.ChannelName.ToString();

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




    }
}