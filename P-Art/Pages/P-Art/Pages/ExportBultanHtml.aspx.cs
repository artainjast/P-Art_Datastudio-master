using P_Art.Pages.P_Art.ModelNews;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class ExportBultanHtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var lstSeletedNews = new List<NewsSelectClass>();
                if (Session["NewsBultanSelected"] != null)
                {
                    lstSeletedNews = Session["NewsBultanSelected"] as List<NewsSelectClass>;
                }
                // Session.Add("NewsBultanSelected", lstSeletedNews);

                CreateMasterPDF(lstSeletedNews, true, false, false, false, false);

            }
        }
        Class_News _clsNews = new Class_News();
        private void CreateMasterPDF(List<NewsSelectClass> lstSeletedNews, bool NewsPaper, bool isRelate, bool isHighlight, bool chart, bool IsTvRadio)
        {
            var newsIDs = lstSeletedNews.Select(t => t.NewsID).ToList();
            if (newsIDs == null) return;
            var newsStr = "";
            foreach (var item in newsIDs)
            {
                newsStr += "," + item;
            }
            if (!string.IsNullOrWhiteSpace(newsStr))
            {
                newsStr = newsStr.Substring(1);
            }
            // var AllNews = _clsNews.GetAllNewsIds(lstSeletedNews.Select(t => t.NewsID).ToList());
            var AllNews = _clsNews.GetAllNewsByIds(newsStr);

            //roojeld
            BindRuJeld();
            //fehrest
            BindFehrest(lstSeletedNews, AllNews);

            //roozname
            BindRoozname();
            //news
            BindNews();
        }

        private void BindNews()
        {

        }

        private void BindRoozname()
        {

        }

        private void BindFehrest(List<NewsSelectClass> lstSeletedNews, DataTable allNews)
        {
            var html = "";
            var groupByMasterTag = lstSeletedNews.GroupBy(t => t.NewsMasterTagID).Select(t => t.FirstOrDefault()).OrderByDescending(t => t.NewsMasterTagID).ToList();

            var pageBreak = 0;
            var pageBreakMax = 38;
            var pagedCount = 0;
            foreach (var item in groupByMasterTag)
            {
                if (item.NewsMasterTagID == 0)
                {
                    html += "<h2>دیگر اخبار</h2>";
                    //
                    pageBreak += 4;

                    var lstTag = lstSeletedNews.Where(t => t.NewsMasterTagID == item.NewsMasterTagID);

                    foreach (var news in lstTag)
                    {
                        string searchExpression = "NewsID = " + news.NewsID;

                        var selectedNews = allNews.Select(searchExpression).FirstOrDefault();
                        if (selectedNews != null)
                        {
                            html += "<li>" + selectedNews["NewsTitle"].ToString() + " | " + selectedNews["SiteTitle"].ToString() + "</li>";



                        }
                        pageBreak += 1;

                        if (pageBreak >= pageBreakMax)
                        {
                            pagedCount++;

                            InsertFehrestHtml(html);
                            pageBreak = 0;
                            html = "";
                        }

                    }

                }
                else
                {
                    html += "<h2>" + item.NewsMasterTagTitle + "</h2>";
                    //
                    pageBreak += 4;


                    var lstTag = lstSeletedNews.Where(t => t.NewsMasterTagID == item.NewsMasterTagID);

                    foreach (var news in lstTag)
                    {
                        string searchExpression = "NewsID = " + news.NewsID;

                        var selectedNews = allNews.Select(searchExpression).FirstOrDefault();
                        if (selectedNews != null)
                        {
                            html += "<li>" + selectedNews["NewsTitle"].ToString() + " | " + selectedNews["SiteTitle"].ToString() + "</li>";

                        }
                        pageBreak += 1;
                        if (pageBreak >= pageBreakMax)
                        {
                            pagedCount++;

                            InsertFehrestHtml(html);
                            pageBreak = 0;
                            html = "";
                        }

                    }

                }
                if (pagedCount == 0 || !string.IsNullOrWhiteSpace(html))
                {
                    pagedCount++;
                    InsertFehrestHtml(html);
                    pageBreak = 0;
                    html = "";
                }
            }

        }
        private void InsertFehrestHtml(string html)
        {
            html = "<ul>" + html + "</ul>";
            ltNewsFehrest.Text += @"<div class='page fehrestDiv'>
                <div class='fehrest'>
                    <div class='clearfix'></div>
                    <div class='divHeader'></div>
                   " + html + @" 
                </div>

            </div>";
        }
        private void BindRuJeld()
        {

        }
    }
}