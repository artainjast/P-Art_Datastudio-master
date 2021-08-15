using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using PArt.Core;
using System.Web.Services;
using System.Text;

namespace P_Art
{
    public partial class HTMLDataCenterPack : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<Tbl_DataCenterNews> dataCenterNews = new List<Tbl_DataCenterNews>();
        List<int?> UserPanelList = new List<int?>();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
        int ArchiveId;
        Tbl_BultanArchive bultanArchive;
        List<int> newsIds = new List<int>();
        StringBuilder HTMLBodyOfNews = new StringBuilder();
        StringBuilder HTMLIndexOfNews = new StringBuilder();
        int pageSize = 2500;
        int pageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!string.IsNullOrWhiteSpace(Request.QueryString["ArchiveId"]))
            {
                ArchiveId = Convert.ToInt32(Request.QueryString["ArchiveId"]);
                bultanArchive = _db.Tbl_BultanArchive.Where(Bultan => Bultan.ArchiveId == ArchiveId).FirstOrDefault();
                string[] newsIdsString = bultanArchive.SelectedNews.Split(',');
                if (bultanArchive.PanelId != 0)
                {
                    CurrentUserLabel.InnerText = string.Empty;
                    CurrentUserLabel.InnerText = "بسته خبری  ";
                    int parminId = Convert.ToInt32(bultanArchive.PanelId);
                    CurrentUserLabel.InnerText += (new Class_Panels()).GetParminById(parminId).AgName;
                }
                foreach (string newsId in newsIdsString)
                {
                    if (!string.IsNullOrWhiteSpace(newsId))
                    {
                        try
                        {
                            newsIds.Add(Convert.ToInt32(newsId));
                        }
                        catch
                        {
                            continue;
                        }
                    }

                }

                foreach (var newsid in newsIds)
                {
                    dataCenterNews.Add(_db.Tbl_DataCenterNews.Where(news => news.NewsID == newsid).FirstOrDefault());
                }
                HTMLIndexOfNews.Append("<div class='page A4 persian pageCover'><div class='result-title'>");
                foreach (var news in dataCenterNews)
                {
                    HTMLIndexOfNews.Append("<a class='indexStyle' href='#id" + news.NewsID + "'>" + news.NewsTitle + "</a><br/>");
                }
                HTMLIndexOfNews.Append("</div></div><br />");

                foreach (var news in dataCenterNews)
                {
                    HTMLBodyOfNews.Append("<div class='page A4 persian pageCover'><div class='result-title'>");
                    HTMLBodyOfNews.Append("<span class='title' id='id" + news.NewsID + "'>" + news.NewsTitle + "</span><div class='newsBody'>");
                    if (!string.IsNullOrWhiteSpace(news.NewsImageUrl))
                    {
                        HTMLBodyOfNews.Append("<img class='image' src='" + news.NewsImageUrl + "' />");
                    }


                    string TextBody = SplitedText(news.NewsBody);
                    int pageCount = TextBody.Count() / pageSize;
                    int lastPageCount = TextBody.Count() % pageSize;
                    List<string> pagingString = new List<string>();
                    string remaind = "";
                    string substring = "";
                    int indexOfDot = 0;

                    for (int i = 0; i <= pageCount; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(news.NewsImageUrl))
                        {
                            pageSize = 2000;
                        }

                        if (i == pageCount)
                        {
                            substring = remaind + TextBody.Substring(i * pageSize, lastPageCount);
                        }
                        else
                        {
                            substring = remaind + TextBody.Substring(i * pageSize, pageSize);
                        }
                        indexOfDot = substring.LastIndexOf('.');
                        remaind = substring.Substring(indexOfDot + 1);
                        substring = substring.Substring(0, indexOfDot + 1);
                        pagingString.Add(substring);
                        pageSize = 2500;
                    }


                    int index = 0;
                    foreach (string page in pagingString)
                    {
                        pageIndex ++;
                        if (index == 0)
                        {
                            HTMLBodyOfNews.Append(page);
                            HTMLBodyOfNews.Append("</div></div>");
                            HTMLBodyOfNews.Append("<span class='pageNumber'>" + pageIndex + "</span>");
                            HTMLBodyOfNews.Append("</div><br />");
                        }
                        else
                        {
                            HTMLBodyOfNews.Append("<div class='page A4 persian pageCover'><div class='result-title'>");
                            HTMLBodyOfNews.Append(page);
                            HTMLBodyOfNews.Append("</div></div>");
                            HTMLBodyOfNews.Append("<span class='pageNumber'>" + pageIndex + "</span>");
                            HTMLBodyOfNews.Append("</div><br />");
                        }
                        index++;
                    }

                }

                DataCenterPackBody.InnerHtml = HTMLBodyOfNews.ToString();
                DataCenterPackIndex.InnerHtml = HTMLIndexOfNews.ToString();
            }
        }


        public string SplitedText(string txt)
        {
            var str = "";
            var continueKeys = new string[] { ".", };
            foreach (var strings in (txt + "").Split('.'))
            {

                if (!string.IsNullOrWhiteSpace(strings))
                {

                    if (continueKeys.Any(t => t == strings.Trim()))
                    {
                        str += continueKeys;
                    }
                    else
                    {
                        if (strings.Length < 150)
                        {
                            str += strings + " . ";

                        }
                        else
                        {
                            str += strings + " . <br/>";
                        }

                    }
                }
            }

            return str;
        }
    }
}