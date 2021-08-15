using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{

    public partial class HtmlSocialNews : System.Web.UI.Page
    {
        List<Class_SocialMediaPost> CompiledPostsList = new List<Class_SocialMediaPost>();
        public static int currentPage = 0;
        public static string DiffrentDate(object ddate, string sitetype, string newstime, string newsDateStr)
        {
            Class_Zaman zm = new Class_Zaman();
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            var newsDtTime = new DateTime();
            if (string.IsNullOrWhiteSpace(newsDateStr))
            {
                newsDtTime = Convert.ToDateTime(ddate);
            }
            else
            {
                newsDtTime = Class_Static.ConvertIntFarsiDate(newsDateStr);
            }

            if (sitetype == "2")
            {
                return Persia.Calendar.ConvertToPersian(newsDtTime).ToString();

            }
            var dt = new DateTime();
            if (!string.IsNullOrWhiteSpace(newstime))
            {
                try
                {
                    var newsDate = Convert.ToDateTime(newsDtTime);
                    newstime = Class_Static.GetAbsoluteTime(newstime);
                    var newstimeSpil = newstime.Split(':');
                    dt = new DateTime(newsDate.Year, newsDate.Month, newsDate.Day, Convert.ToInt32(newstimeSpil[0]), Convert.ToInt32(newstimeSpil[1]), 0);
                    //  return Class_Static.GetOnTimeDate(dateTime);
                }
                catch
                {
                    dt = (newsDtTime);
                    //return Class_Static.GetOnTimeDate();



                }

            }
            else
            {
                // return Class_Static.GetOnTimeDate(Convert.ToDateTime(ddate));
                dt = Convert.ToDateTime(newsDtTime);
            }


            return Class_Static.GetOnTimeDate(dt);


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var chartHtml = "";
                if (Request.QueryString["ArchiveId"] != null)
                {

                    hdfBultanArchiveID.Value = Request.QueryString["ArchiveId"] + "";
                }
                Class_SocialMediaBultan report = (new Class_SocialMediaBultan()).GetReport(Convert.ToInt32(hdfBultanArchiveID.Value));

                Class_SocialMediaBultan archive = new Class_SocialMediaBultan();
                hdfAllowChart.Value = report.AllowChart.ToString();
                if (hdfAllowChart.Value.ToLower() == "true")
                chartHtml = LoadChart(Convert.ToInt32(hdfBultanArchiveID.Value));
                ltPostHtml.Text = LoadCover(report) + chartHtml + LoadPost(report);

            }
        }

        private string LoadChart(int ArchiveId)
        {


            var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
            string html = "<div class='page coverPage'>";
            html += "<div id='chart1' height=400></div>";
            html += "<div id='keys-result'>جدول توزیع فراوانی کاربران فعال در شبکه اجتماعی توئیتر<table class='table-report3' style='display:none;margin-bottom:20px'><thead><tr><th> كاربران </th><th> تعداد </th></tr></thead><tbody></tbody></table></div>";

            html += footerHtml + "</div>";

            return html;
        }


        Class_Ado _clsAdo = new Class_Ado();
        public static int ArchiveId = 0;
        private string LoadPost(Class_SocialMediaBultan report)
        {

            if (report != null)
            {
                GetPosts(report);
            }
            var MaxPageLength = 3600;
            var html = "";
            var headerHtml = @"<header><span>" + "بولتن شبکه های اجتماعی" + @"</span></header>";

            var topContentHtml = "<div class='page coverPage'><div class='PageContainer' >" +
                    headerHtml + "";

            var htmlNews = "";
            List<string> htmlNewsList = new List<string>();
            int index = 0;
            foreach (var posts in CompiledPostsList)
            {
                index++;
                if (htmlNews.Length > MaxPageLength)
                {



                    string year = posts.PosteDateTimeIndex.Substring(0, 4);
                    string month = posts.PosteDateTimeIndex.Substring(4, 2);
                    string day = posts.PosteDateTimeIndex.Substring(6, 2);
                    string hour = posts.PosteDateTimeIndex.Substring(8, 2);
                    string minute = posts.PosteDateTimeIndex.Substring(10, 2);

                    htmlNewsList.Add(htmlNews);
                    htmlNews = "";
                    //if (posts.NewsValue == 1)
                    //{
                    //    htmlNews += "<div class='postSection1'>" +
                    //        "<div class='postHeader'><h4><i class='fa fa-twitter'></i>" + posts.UserName + "</h4></div>" +
                    //    "<div class='postTitleSection'><span class='newsindex'>" +
                    //       index + "-</span><a href='" + posts.LinkUrl + "'" +
                    //    " target='_blank' >" + posts.Text + "</a></div>" +
                    //    " <div class='dateTime' >" + year + "/" + month + "/" + day + " " + hour + ":" + minute + "</div> " +
                    //     " <div class='icons' ><i class='fa fa-retweet'></i>" + posts.RetweetCount + " <i class='fa fa-thumbs-up'></i>" + posts.LikeCount + " <i class='fa fa-comments'></i>" + posts.CommentCount + "</div> " +
                    //    "</div>";
                    ////}

                    //else if (posts.NewsValue == 2)
                    //{

                        //htmlNews += "<div class='postSection2'>" +
                        //    "<div class='postHeader'><h4><i class='fa fa-twitter'></i>" + posts.UserName + "</h4></div>" +
                        //"<div class='postTitleSection'><span class='newsindex'>" +
                        //   index + "-</span><a href='" + posts.LinkUrl + "'" +
                        //" target='_blank' >" + posts.Text + "</a></div>" +
                        //" <div class='dateTime' >" + year + "/" + month + "/" + day + " " + hour + ":" + minute + "</div> " +
                        // " <div class='icons' ><i class='fa fa-retweet'></i>" + posts.RetweetCount + " <i class='fa fa-thumbs-up'></i>" + posts.LikeCount + " <i class='fa fa-comments'></i>" + posts.CommentCount + "</div> " +
                        //"</div>";
                    //}
                    //else if (posts.NewsValue == 0)
                    //{

                    htmlNews += "<div class='postSection'>" +
                        "<div class='postHeader'><h4><i class='fa fa-twitter'></i>" + posts.UserName + "</h4></div>" +
                    "<div class='postTitleSection'><span class='newsindex'>" +
                       index + "-</span><a href='" + posts.LinkUrl + "'" +
                    " target='_blank' >" + posts.Text + "</a></div>" +
                    " <div class='dateTime' >" + year + "/" + month + "/" + day + " " + hour + ":" + minute + "</div> " +
                     " <div class='icons' ><i class='fa fa-retweet'></i>" + posts.RetweetCount + " <i class='fa fa-thumbs-up'></i>" + posts.LikeCount + " <i class='fa fa-comments'></i>" + posts.CommentCount + "</div> " +
                    "</div>";
                    //}
                }
                else
                {
                    string year = posts.PosteDateTimeIndex.Substring(0, 4);
                    string month = posts.PosteDateTimeIndex.Substring(4, 2);
                    string day = posts.PosteDateTimeIndex.Substring(6, 2);
                    string hour = posts.PosteDateTimeIndex.Substring(8, 2);
                    string minute = posts.PosteDateTimeIndex.Substring(10, 2);
                    //if (posts.NewsValue == 0)
                    //{
                    htmlNews += "<div class='postSection'>" +
          "<div class='postHeader'><h4><i class='fa fa-twitter'></i>" + posts.UserName + "</h4></div>" +
      "<div class='postTitleSection'><span class='newsindex'>" +
         index + "-</span><a href='" + posts.LinkUrl + "'" +
      " target='_blank' >" + posts.Text + "</a></div>" +
      " <div class='dateTime' >" + year + "/" + month + "/" + day + " " + hour + ":" + minute + "</div> " +
       " <div class='icons' ><i class='fa fa-retweet'></i>" + posts.RetweetCount + " <i class='fa fa-thumbs-up'></i>" + posts.LikeCount + " <i class='fa fa-comments'></i>" + posts.CommentCount + "</div> " +
      "</div>";
                    //}
                    //else if (posts.NewsValue == 1)
                    //{
                   //     htmlNews += "<div class='postSection1'>" +
                   //    "<div class='postHeader'><h4><i class='fa fa-twitter'></i>" + posts.UserName + "</h4></div>" +
                   //"<div class='postTitleSection'><span class='newsindex'>" +
                   //   index + "-</span><a href='" + posts.LinkUrl + "'" +
                   //" target='_blank' >" + posts.Text + "</a></div>" +
                   //" <div class='dateTime' >" + year + "/" + month + "/" + day + " " + hour + ":" + minute + "</div> " +
                   // " <div class='icons' ><i class='fa fa-retweet'></i>" + posts.RetweetCount + " <i class='fa fa-thumbs-up'></i>" + posts.LikeCount + " <i class='fa fa-comments'></i>" + posts.CommentCount + "</div> " +
                   //"</div>";
                    //}
                    //else if (posts.NewsValue == 2)
                   // //{
                   //     htmlNews += "<div class='postSection2'>" +
                   //    "<div class='postHeader'><h4><i class='fa fa-twitter'></i>" + posts.UserName + "</h4></div>" +
                   //"<div class='postTitleSection'><span class='newsindex'>" +
                   //   index + "-</span><a href='" + posts.LinkUrl + "'" +
                   //" target='_blank' >" + posts.Text + "</a></div>" +
                   //" <div class='dateTime' >" + year + "/" + month + "/" + day + " " + hour + ":" + minute + "</div> " +
                   // " <div class='icons' ><i class='fa fa-retweet'></i>" + posts.RetweetCount + " <i class='fa fa-thumbs-up'></i>" + posts.LikeCount + " <i class='fa fa-comments'></i>" + posts.CommentCount + "</div> " +
                   //"</div>";
                   // //}
                }
                if (index == CompiledPostsList.Count)
                {
                    htmlNewsList.Add(htmlNews);
                    htmlNews = "";

                }

            }


            foreach (var item in htmlNewsList)
            {
                currentPage++;
                var footerHtml = @"<footer><span>" + currentPage + @"</span><h5>پایش مدیا - آژانس تخصصی روابط عمومی</h5></footer>";
                var bottomContentHtml = "" + footerHtml + "</div> </div>";
                html += topContentHtml + item + bottomContentHtml;
            }


          
            return html;
        }
        public string LoadCover(Class_SocialMediaBultan report)
        {
            var html = "";
            try
            {
                DateTime seletedDate;

                try
                {
                    seletedDate = PArt.Pages.P_Art.Repository.Class_Static.ShamsiToMiladi(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToDateString(report.
                  CreateDate.Trim()));
                }
                catch { seletedDate = PArt.Pages.P_Art.Repository.Class_Static.ShamsiToMiladi(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToDateString(report.CreateDate)); }
                var bultanNewsDate = PArt.Pages.P_Art.Repository.Class_Static.GetFarsiDateFull(seletedDate);
#pragma warning disable CS0219 // The variable 'BultanJeldPath' is assigned but its value is never used
                var BultanJeldPath = "";
#pragma warning restore CS0219 // The variable 'BultanJeldPath' is assigned but its value is never used
                try
                {
                    BultanJeldPath = "/Styles/img/jeld.jpg"; ;
                }
                catch
                {
                    BultanJeldPath = "/Styles/img/jeld.jpg";
                }

                //html = "<div class='page coverPage'><img class='coverimg'  src='" + BultanJeldPath + "' /><time>" +
                //    bultanNewsDate + "</time>" + "</div>";
                html = "<div class='page coverPage'><div class='social'>" +
                    "<i class='fa fa-twitter'>" + "</i> " +
                    "<h2>" + report.Title + "</h2> " +
                    "<div><h1>" + "در شبکه های اجتماعی" + "</h1></div>" +
                    "<time>" + bultanNewsDate + "</time>" +
                    "<img src='/Pages/P-Art/Images/payeshlogo.png' alt='پایش مدیا' />" +
                    "<span>پایش مدیا</span>" +
                    "<h5><a href='http://www.payeshmedia.ir'>" + "www.payeshmedia.ir" + "</a></h5>" +
                    "</div></div>";
            }
            catch
            {

            }
            return html;


        }
        public void GetPosts(Class_SocialMediaBultan report)
        {
            string cmd = "SELECT * FROM dbo.Tbl_SocialMediaPost  " +
               " WHERE SocialMediaPostID IN (" + report.SelectedPosts + ")";
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            CompiledPostsList = Class_SocialMediaPost.GetFromDataRows(ds.Tables[0].Select());
            CompiledPostsList = CompiledPostsList.OrderByDescending(i => i.PosteDateTimeIndex).ToList();
        }
        public class PostType
        {
            public int SocialMediaBultanID { get; set; }
            public int ParminID_FK { get; set; }
            public string Title { get; set; }
            public string CreateDate { get; set; }
            public int CreateUser_FK { get; set; }
            public string LastPDFPath { get; set; }
            public string LastWordPath { get; set; }
            public string SelectedPosts { get; set; }
            public int SocialPostId_FK { get; set; }
        }
    }
}