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
    public partial class InstagramPostShow : System.Web.UI.Page
    {

        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();

        Class_News _clsNews = new Class_News();


        Tbl_InstagramPosts post;

        Class_Panels _clsPanels = new Class_Panels();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";

        string VideoElement = "<video class=\"InstagramVideoElement\" playsinline=\"\" poster=\"#PosterImageUrl#\" preload=\"none\" type=\"video//mp4\" src=\"#InstagramVideoUrl#\" controls loop></video>";
        string ImageElement = "<img class=\"InstagramImageElement\" decoding=\"auto\" src=\"#PosterImageUrl#\">";

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
                post = (from row in _db.Tbl_InstagramPosts where row.Id == postId select row).FirstOrDefault();



                if (post != null)
                {
                    StringBuilder HtmlStringBuilder = new StringBuilder();
                    if (post.IsVideo !=null)
                    {
                        if (post.IsVideo == true)
                        {
                            media.InnerHtml = VideoElement.Replace("#PosterImageUrl#", post.DisplayUrl).Replace("#InstagramVideoUrl#",post.VideoUrl);
                        }
                        else
                        {
                            media.InnerHtml = ImageElement.Replace("#PosterImageUrl#", post.DisplayUrl);
                        }
                    }


                    
                    NewsIdHiddenField.Value = post.Id.ToString();
                    HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
                    LblNewsBody.InnerHtml = post.CaptionText.Replace("#"," #");
                    profilePic.Src = post.ProfilePicUrl;
                    fullName.InnerText = post.FullName;
                    lblNewsDate.Text = FixDateTimeString(post.DateTimeIndex.ToString());
                    UserLabel.Text = post.UserName;
                    KeywordTitle.Text = GetKeywordName((int)post.KeywordId);
                    InstaLink.HRef = post.PostUrl;
                    likesLabel.Text = post.LikeCount.ToString();
                    CommentsLabel.Text = post.CommentsCount.ToString();


                }
            }

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

        public string GetKeywordName(int KeyId)
        {
            string keyName = _db.Tbl_InstagramKeywords.Where(K => K.Id == KeyId).Select(k => k.Title).FirstOrDefault();
            return keyName;
        }

    }
}