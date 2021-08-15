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
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ReportBuilder;
using System.Data.SqlClient;

namespace P_Art
{
    public partial class TimelineReport : System.Web.UI.Page
    {
        Class_Ado _clsAdo = new Class_Ado();
        Class_News _clsNews = new Class_News();
        Class_Keywords _clsKeyword = new Class_Keywords();
        HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
        Class_Panels _clsParmin = new Class_Panels();
        Class_BultanFiles _clsBultanFiles = new Class_BultanFiles();
        public static int currentPage = 0;
        public static int ArchiveId = 0;
        List<Tbl_News_Type> AllNewsList = new List<Tbl_News_Type>();
        List<Tbl_News_Type> CompiledNewsList = new List<Tbl_News_Type>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ArchiveId"] != null)
                {
                    ArchiveId = Convert.ToInt32(Request.QueryString["ArchiveId"]);
                }
                Class_TimeLineReportArchive report = (new Class_TimeLineReportArchive()).GetReport(ArchiveId);
                if (report != null)
                {
                    GetNews(report);
                    var htmlCover = "";
                    var htmlAboutPayesh = "";
                    var htmlFehrest = "";
                    var htmlNews = "";
                    var htmlTimeline = "";
                    var htmlFirstChart = "";
                    if (report.IsCover)
                        htmlCover = LoadCover(report);
                    if (report.IsAboutPayesh)
                        htmlAboutPayesh = LoadAboutPayesh(report);
                    htmlFehrest = LoadFehrest(report, CompiledNewsList);
                    htmlNews = LoadNewsBody(report, CompiledNewsList);
                    htmlTimeline = LoadTimeLine(report, AllNewsList, CompiledNewsList);
                    htmlFirstChart = LoadCharts1();
                    ltHtml.Text = htmlCover + htmlAboutPayesh + htmlFehrest + htmlNews + htmlTimeline + htmlFirstChart;
                }
            }
        }
        public string LoadCover(Class_TimeLineReportArchive report)
        {
            var html = "";
            try
            {
                DateTime seletedDate;

                try
                {
                    seletedDate = PArt.Pages.P_Art.Repository.Class_Static.ShamsiToMiladi(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToDateString(report.
                  ToDateTimeIndex));
                }
                catch { seletedDate = PArt.Pages.P_Art.Repository.Class_Static.ShamsiToMiladi(PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToDateString(report.FromDateTimeIndex)); }
                var bultanNewsDate = PArt.Pages.P_Art.Repository.Class_Static.GetFarsiDateFull(seletedDate);
                var BultanJeldPath = "";
                try
                {
                    var selectedBultan = _clsBultanFiles.SelectItem(report.BultanFileId);
                    BultanJeldPath = selectedBultan.BultanJeldPath;
                }
                catch
                {
                    BultanJeldPath = "/Styles/img/jeld.jpg";
                }
                //var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";

                html = "<div class='page coverPage'><h3 class='covertitle' >" + report.Title +
                    "</h3><img class='coverimg'  src='" + BultanJeldPath + "' /><time>" +
                    bultanNewsDate + "</time>" + "</div>";
            }
            catch
            {

            }
            return html;


        }
        public string LoadAboutPayesh(Class_TimeLineReportArchive report)
        {
            var html = "";
            try
            {

                var BultanAboutath = "http://media.e-sepaar.net/bultan/about.jpg";

                html = "<div class='page coverPage about-payesh'><img class='aboutimg'  src='" + BultanAboutath +
                    "' /><h3>درباره پایش مدیا</h3>" +
                    "<p>اطلاعات ، كليدي ترين نياز سازمان هاي توسعه يافته امروزي است ، اطلاعاتی كه  يكپارچه باشد، در هر زمان و هر مكان در دسترس باشد، در لحظه باشد و صحت داشته باشد. اما حجم اطلاعات رو به افزايش است و سازمان ها نيز زمان و منابع كافي براي مديريت آن ها را در اختيار ندارند. بنابراين انتظار مي رود كه ابزارهاي مناسبي در اختيار مديران و كاركنان سازمان ها باشد كه بتوانند بهره وري و كارايي فعاليت هايشان را افزايش دهند ، و تعاملات درون و برون سازماني خود را  تسهيل بخشند و سریعتر و دقیق تر تصمیم گیری کنند</p>" + "</div>";
            }
            catch
            {

            }
            return html;



        }
        public string LoadAboutProject(Class_TimeLineReportArchive report)
        {

            return "";
        }
        public void GetNews(Class_TimeLineReportArchive report)
        {
            List<NewsRelated_Type> newsIdWithRelated = new List<NewsRelated_Type>();

            string[] selectedNews = report.SelectedNews.Split('$');
            List<int> allNewsIds = new List<int>();
            List<int> allNewsSourceIds = new List<int>();
            string allsourceString = "";
            string allNewsString = "";
            foreach (var n in selectedNews)
            {
                NewsRelated_Type sourcnews = new NewsRelated_Type();
                string sourceNews = n.Split('-')[0];
                string[] relatedNewsIds = n.Split('-')[1].Split(',');

                allNewsIds.Add(Convert.ToInt32(sourceNews));
                allNewsSourceIds.Add(Convert.ToInt32(sourceNews));
                string relatedString = "";
                foreach (var r in relatedNewsIds)
                {
                    allNewsIds.Add(Convert.ToInt32(r));
                    relatedString += relatedString != string.Empty ? "," : string.Empty;
                    relatedString += r;
                }
                sourcnews.NewsId = Convert.ToInt32(sourceNews);
                sourcnews.RelatedString = relatedString;
                newsIdWithRelated.Add(sourcnews);


                allsourceString += allsourceString != string.Empty ? "," : string.Empty;
                allsourceString += Convert.ToInt32(sourceNews);
            }

            foreach (var id in allNewsIds)
            {
                allNewsString += allNewsString != string.Empty ? "," : string.Empty;
                allNewsString += Convert.ToInt32(id);
            }
            string cmd = "SELECT * FROM dbo.Tbl_News AS n INNER JOIN dbo.Tbl_Sites AS s ON s.SiteID = n.SiteID" +
                " INNER JOIN dbo.Tbl_RssKeywords AS k ON n.KeywordId=k.KeyId " +
               " WHERE NewsID IN (" + allNewsString + ")";
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            AllNewsList = Tbl_News_Type.GetFromDataRows(ds.Tables[0].Select());
            AllNewsList = AllNewsList.OrderByDescending(i => i.NewsDateIndex).ThenByDescending(j => j.NewsTime).ToList();
            foreach (Tbl_News_Type i in AllNewsList.Where(i => allNewsSourceIds.Contains(i.NewsID)).ToList())
            {
                List<int> relateIds = new List<int>();
                string newsRelatedIds = newsIdWithRelated.FirstOrDefault(j => j.NewsId == i.NewsID).RelatedString;
                string siteTitles = "";
                foreach (var s in newsRelatedIds.Split(','))
                {
                    siteTitles += siteTitles != string.Empty ? "<i class='fa fa-arrow-left' ></i>" : string.Empty;
                    siteTitles += Class_News.GetNewsSiteTitle(Convert.ToInt32(s));
                    relateIds.Add(Convert.ToInt32(s));
                }

                i.RelateListSites = siteTitles;
                i.RelateListIdsCount = newsRelatedIds.Split(',').Count();
                i.RelateListIds = relateIds;
                CompiledNewsList.Add(i);
            }
            CompiledNewsList = CompiledNewsList.OrderByDescending(i => i.RelateListIdsCount).ToList();

            Session.Add("AllNewsList", AllNewsList);
            Session.Add("CompiledNewsList", CompiledNewsList);

        }
        public string LoadFehrest(Class_TimeLineReportArchive report, List<Tbl_News_Type> newsList)
        {
            var html = "";
            var headerHtml = @"<header><span>" + "گزارش جریان خبری" + @"</span></header>";
            var topContentHtml = "<div class='page coverPage'><div class='PageContainer' >" +
           headerHtml + "<ul class='fehrest-body'>";
            try
            {
                int index = 0;
                int loop = 0;
                int allItemCount = newsList.Count;
                int AllRelatedCount = newsList.Sum(o => o.RelateListIdsCount);
                string head = "<li>جریان خبری" + "</li>";
                head += "<li>" +
                        "<div class='indexHeader'>ردیف</div>" +
                        "<div class='newsHeaderTitle'>موضوع</div>" +
                        "<div class='zaribHeader'>ضریب نفوذ</div>" +
                        "<div class='darsadHeader'>درصد نفوذ</div>" +
                        "<div class='clearfix'></div>" +
                        "</li>";

                List<string> contentArray = new List<string>();
                loop = allItemCount / 20;
                loop++;
                string itemHtml = "";
                int loopindex = 1;

                foreach (var news in newsList)
                {
                    index++;

                    int zaribNofuzCount = news.RelateListIdsCount;
                    double darsadnofuz = (Convert.ToDouble(zaribNofuzCount) / Convert.ToDouble(AllRelatedCount)) * 100;
                    itemHtml += "<li>" +
                        "<div class='index'>" + index + "</div>" +
                        "<div class='newsTitle'><i class='fa fa-square' ></i><h2>" + PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(news.NewsTitle, 130) + "<span>(" + news.SiteTitle + ")</span>" + "</h2>" + "<div class='relate'>" +
                        news.RelateListSites + "</div>" + "</div>" +
                        "<div class='zarib'>" + zaribNofuzCount + "</div>" +
                        "<div class='darsad'>" + Math.Round(darsadnofuz, 2) + "%" + "</div>" +
                        "<div class='clearfix'></div>" +
                        "</li>";
                    if (loopindex < loop)
                    {
                        if (loopindex * 20 == index)
                        {
                            itemHtml = "<li>جریان خبری" + "</li>" + "<li>" +
                                    "<div class='indexHeader'>ردیف</div>" +
                                    "<div class='newsHeaderTitle'>موضوع</div>" +
                                    "<div class='zaribHeader'>ضریب نفوذ</div>" +
                                    "<div class='darsadHeader'>درصد نفوذ</div>" +
                                    "<div class='clearfix'></div>" +
                                    "</li>" + itemHtml;
                            currentPage++;
                            var footerHtml = @"<footer><span>" + currentPage + @"</span><h5>پایش مدیا - آژانس تخصصی روابط عمومی</h5></footer>";
                            var bottomContentHtml = "</ul>" + footerHtml + "</div> </div>";
                            contentArray.Add(topContentHtml + itemHtml + bottomContentHtml);
                            itemHtml = string.Empty;
                            loopindex++;
                        }
                    }
                    else if (loopindex == loop)
                    {
                        if (loopindex * 20 == index)
                        {
                            itemHtml = "<li>جریان خبری" + "</li>" + "<li>" +
                                 "<div class='indexHeader'>ردیف</div>" +
                                 "<div class='newsHeaderTitle'>موضوع</div>" +
                                 "<div class='zaribHeader'>ضریب نفوذ</div>" +
                                 "<div class='darsadHeader'>درصد نفوذ</div>" +
                                 "<div class='clearfix'></div>" +
                                 "</li>" + itemHtml;
                            currentPage++;
                            var footerHtml = @"<footer><span>" + currentPage + @"</span><h5>پایش مدیا - آژانس تخصصی روابط عمومی</h5></footer>";
                            var bottomContentHtml = "</ul>" + footerHtml + "</div> </div>";
                            contentArray.Add(topContentHtml + itemHtml + bottomContentHtml);
                            itemHtml = string.Empty;
                            loopindex++;
                        }
                        else if (index == allItemCount)
                        {
                            itemHtml = "<li>جریان خبری" + "</li>" + "<li>" +
                                 "<div class='indexHeader'>ردیف</div>" +
                                 "<div class='newsHeaderTitle'>موضوع</div>" +
                                 "<div class='zaribHeader'>ضریب نفوذ</div>" +
                                 "<div class='darsadHeader'>درصد نفوذ</div>" +
                                 "<div class='clearfix'></div>" +
                                 "</li>" + itemHtml;
                            currentPage++;
                            var footerHtml = @"<footer><span>" + currentPage + @"</span><h5>پایش مدیا - آژانس تخصصی روابط عمومی</h5></footer>";
                            var bottomContentHtml = "</ul>" + footerHtml + "</div> </div>";
                            contentArray.Add(topContentHtml + itemHtml + bottomContentHtml);
                            itemHtml = string.Empty;
                            loopindex++;
                        }
                    }

                }
                foreach (string c in contentArray)
                    html += c;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            return html;
        }
        public string LoadNewsBody(Class_TimeLineReportArchive report, List<Tbl_News_Type> newsList)
        {
            var MaxPageLength = 8800;
            var html = "";
            var headerHtml = @"<header><span>" + "گزارش جریان خبری" + @"</span></header>";

            var topContentHtml = "<div class='page coverPage'><div class='PageContainer' >" +
                    headerHtml + "";

            var htmlNews = "";
            List<string> htmlNewsList = new List<string>();
            int index = 0;
            foreach (var news in newsList)
            {
                index++;
                if (htmlNews.Length > MaxPageLength)
                {
                    htmlNewsList.Add(htmlNews);
                    htmlNews = "";
                    htmlNews += "<div class='newsSection'><div class='newsTitleSection'><span class='newsindex'>" +
                       index + "</span><a href='" + news.NewsLink + "'" +
                    " target='_blank' >" + news.NewsTitle + "</a></div>" + "<div class='newsLeadSection' >" +
                    news.NewsLead + "</div>" + "</div>";
                }
                else
                {
                    htmlNews += "<div class='newsSection'><div class='newsTitleSection'><span class='newsindex'>" +
                    index + "</span><a href='" + news.NewsLink + "'" +
                    " target='_blank' >" + news.NewsTitle + "</a></div>" + "<div class='newsLeadSection' >" +
                    news.NewsLead + "</div>" + "</div>";
                }
                if (index == newsList.Count)
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
        public string LoadTimeLine(Class_TimeLineReportArchive report, List<Tbl_News_Type> allNewsList,
            List<Tbl_News_Type> compiledNewsList)
        {
            var MaxPageLength = 8200;
            var html = "";
            var headerHtml = @"<header><span>" + "نمودار جریان خبری" + @"</span></header>";
            var topContentHtml = "<div class='page coverPage'><div class='PageContainer' >" +
                    headerHtml + "";

            var htmlPerPage = "";

            var htmlItemNews = "";
            List<string> htmlNewsList = new List<string>();
            var topItemHtml = "<div class='divTree'><ul>";
            var bottomItemHtml = "</ul></div>";
            foreach (var source in compiledNewsList)
            {
                htmlPerPage = "<div class='source-news'><h2><b>1</b>" + source.NewsTitle + "</h2>" +
                    "<span>" + source.SiteTitle + "</span>" +
                    "</div><div class='clearfix'></div>";
                int flagCheckSource = 1;
                int RelateIndex = 1;
                List<Tbl_News_Type> relatedList = new List<Tbl_News_Type>();
                relatedList = allNewsList.Where(i => source.RelateListIds.Contains(i.NewsID)).OrderBy(i => i.NewsDateIndex).ThenBy(j => j.NewsTime).ToList();
                foreach (var relate in relatedList)
                {
                    if (htmlItemNews.Length > MaxPageLength)
                    {
                        RelateIndex++;
                        flagCheckSource = 0;
                        htmlNewsList.Add(topItemHtml + htmlItemNews + bottomItemHtml);
                        htmlItemNews = "";
                        htmlItemNews += "<li><div class='newsItemBody'><span class='node'></span>" +
                            "<div class='newsItemRelate'><b class='numberTree'>" + RelateIndex +
                            "</b><img class='siteimg' src='" + relate.SiteLogo + "' />" +
                            "<h2><img class='bullet' src='/Pages/P-Art/Images/bl.gif'>" +
                            "<a href ='' target='_blank'> " + relate.NewsTitle + " </a></h2>" +
                            "<span>" + relate.SiteTitle + "</span><span>" +
                            DiffrentDate(relate.CreateDate, relate.SiteType.ToString(), relate.NewsTime, relate.NewsDate) +
                            "</span></div><div><p>" + relate.NewsLead + "</p></div>" +
                            "</div><div style='height: 0px;' class='clearfix'></div></li>";
                    }
                    else
                    {
                        flagCheckSource++;
                        RelateIndex++;

                        htmlItemNews += "<li><div class='newsItemBody'><span class='node'></span>" +
                            "<div class='newsItemRelate'><b class='numberTree'>" + RelateIndex +
                            "</b><img class='siteimg' src='" + relate.SiteLogo + "' />" +
                            "<h2><img class='bullet' src='/Pages/P-Art/Images/bl.gif'>" +
                            "<a href ='' target='_blank'> " + relate.NewsTitle + " </a></h2>" +
                            "<span>" + relate.SiteTitle + "</span><span>" +
                            DiffrentDate(relate.CreateDate, relate.SiteType.ToString(), relate.NewsTime, relate.NewsDate) +
                            "</span></div><div><p>" + relate.NewsLead + "</p></div>" +
                            "</div><div style='height: 0px;' class='clearfix'></div></li>";
                    }
                    if (RelateIndex - 1 == relatedList.Count)
                    {
                        htmlNewsList.Add(topItemHtml + htmlItemNews + bottomItemHtml);
                        htmlItemNews = "";

                    }
                }

                foreach (var item in htmlNewsList)
                {
                    currentPage++;
                    var footerHtml = @"<footer><span>" + currentPage + @"</span><h5>پایش مدیا - آژانس تخصصی روابط عمومی</h5></footer>";
                    var bottomContentHtml = "" + footerHtml + "</div> </div>";
                    html += topContentHtml + htmlPerPage + item + bottomContentHtml;
                }
                htmlNewsList = new List<string>();

            }




            return html;
        }
        public string LoadCharts1()
        {
#pragma warning disable CS0219 // The variable 'MaxPageLength' is assigned but its value is never used
            var MaxPageLength = 8200;
#pragma warning restore CS0219 // The variable 'MaxPageLength' is assigned but its value is never used
            var html = "";
            var headerHtml = @"<header><span>" + "نمودار جریان خبری" + @"</span></header>";
            var topContentHtml = "<div class='page coverPage'><div class='PageContainer' >" +
                    headerHtml + "";

            var htmlPerPage = "";

            List<string> htmlNewsList = new List<string>();
            var topItemHtml = "<div id='chart1' style='max-height:1600px;'></div><div id='chart2' style='max-height:1600px;'></div>";
            var bottomItemHtml = "";
            htmlPerPage = topItemHtml + bottomItemHtml;
            currentPage++;
            var footerHtml = @"<footer><span>" + currentPage + @"</span><h5>پایش مدیا - آژانس تخصصی روابط عمومی</h5></footer>";
            var bottomContentHtml = "" + footerHtml + "</div> </div>";
            html += topContentHtml + htmlPerPage + bottomContentHtml;
            htmlNewsList = new List<string>();

            return html;
        }
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
                newsDtTime = PArt.Pages.P_Art.Repository.Class_Static.ConvertIntFarsiDate(newsDateStr);
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
                    newstime = PArt.Pages.P_Art.Repository.Class_Static.GetAbsoluteTime(newstime);
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


            return PArt.Pages.P_Art.Repository.Class_Static.GetOnTimeDate(dt);


        }
        private string CheckSiteLogo(string newspic)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newspic))
                {
                    newspic = @"C:\BultanForms\Logos\nologo.jpg";
                }
                return newspic;
            }
            catch
            {
                newspic = @"C:\BultanForms\Logos\nologo.jpg";
                return newspic;
            }

        }
        public string SplitedText(string txt)
        {
            var maxLength = 2500;
            var str = "";
            var continueKeys = new string[] { ".", };
            foreach (var strings in (txt + "").Split('.'))
            {
                if (str.Length > maxLength) continue;

                if (!string.IsNullOrWhiteSpace(strings))
                {

                    if (continueKeys.Any(t => t == strings.Trim()))
                    {
                        str += continueKeys;
                    }
                    else
                    {
                        if (strings.Length < 3)
                        {
                            str += strings;

                        }
                        else
                        {
                            str += strings + " . ";
                        }

                    }
                }
            }

            return str;
        }
        public class NewsRelated_Type
        {
            public int NewsId { get; set; }
            public string RelatedString { get; set; }
        }
    }
}