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
    public partial class TwitterPostShow : System.Web.UI.Page
    {

        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();

        Class_News _clsNews = new Class_News();


        Tbl_TwitterPost post;

        Class_Panels _clsPanels = new Class_Panels();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";


        protected void Page_Load(object sender, EventArgs e)
        {
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
                long postId = long.Parse(RouteData.Values["Id"].ToString());
                post = (from row in _db.Tbl_TwitterPost where row.ID == postId select row).FirstOrDefault();


                if (post != null)
                {
                    NewsIdHiddenField.Value = post.ID.ToString();

                    HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();

                    LblNewsBody.InnerHtml = (post.Text);
                    lblNewsDate.Text = post.Date + " - " + post.Time;
                    UserLabel.Text = post.UserName;
                    KeywordTitle.Text = GetKeywordName((int)post.KeywordID);
                    lnk_news.HRef = post.Url;

                }
            }

        }

        public string GetKeywordName(int KeyId)
        {
            string keyName = _db.Tbl_TwitterKeywords.Where(K => K.ID == KeyId).Select(k => k.Title).FirstOrDefault();
            return keyName;
        }

    }
}