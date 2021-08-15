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
    public partial class ExportBultanStimul : System.Web.UI.Page
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

                ShowReport(lstSeletedNews, true, false, false, false, false);

            }
        }

        Class_News _clsNews = new Class_News();

        private void ShowReport(List<NewsSelectClass> lstSeletedNews, bool NewsPaper, bool isRelate, bool isHighlight, bool chart, bool IsTvRadio)
        {
            var AllNews = _clsNews.GetAllNewsIds(lstSeletedNews.Select(t => t.NewsID).ToList());

            //roojeld
            BindRuJeld();
            //fehrest
            BindFehrest(lstSeletedNews, AllNews);

            //roozname
            BindRoozname();
            //news
            BindNews();


          
         
         
        }
        private void CreateMasterPDF(List<NewsSelectClass> lstSeletedNews, bool NewsPaper, bool isRelate, bool isHighlight, bool chart, bool IsTvRadio)
        {

            var AllNews = _clsNews.GetAllNewsIds(lstSeletedNews.Select(t => t.NewsID).ToList());

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

        private void BindFehrest(List<NewsSelectClass> lstSeletedNews, List<Tbl_News> allNews)
        {
            //var html = "";
            //var groupByMasterTag = lstSeletedNews.GroupBy(t => t.NewsMasterTagID).Select(t=>t.FirstOrDefault()).OrderByDescending(t => t.NewsMasterTagID).ToList();
           

            //foreach (var item in groupByMasterTag)
            //{
            //    if (item.NewsMasterTagID == 0)
            //    {
            //        html += "<h2>دیگر اخبار</h2>";
            //        var lstTag = lstSeletedNews.Where(t => t.NewsMasterTagID == item.NewsMasterTagID);
            //        html += "<ul>";
            //        foreach (var news in lstTag)
            //        {
            //            html += "<li>" + allNews.FirstOrDefault(t => t.NewsID == news.NewsID).NewsTitle + "</li>";

            //        }
            //        html += "</ul>";
            //    }
            //    else
            //    {
            //        html += "<h2>" + item.NewsMasterTagTitle + "</h2>";
            //        var lstTag = lstSeletedNews.Where(t => t.NewsMasterTagID == item.NewsMasterTagID);
            //        html += "<ul>";
            //        foreach (var news in lstTag)
            //        {
            //            html += "<li>" + allNews.FirstOrDefault(t => t.NewsID == news.NewsID).NewsTitle + "</li>";

            //        }
            //        html += "</ul>";
            //    }
            //}
            //ltNewsFehrest.Text = html;
        }

        private void BindRuJeld()
        {

        }
    }
}