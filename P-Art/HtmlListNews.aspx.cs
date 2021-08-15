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
    public partial class HtmlListNews : System.Web.UI.Page
    {
        Class_Ado _clsAdo = new Class_Ado();
        Class_News _clsNews = new Class_News();
        Class_BultanArchive _clsBultanArchive = new Class_BultanArchive();
        Class_Keywords _clsKeyword = new Class_Keywords();
        HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
        Class_BultanFiles _clsBultanFiles = new Class_BultanFiles();
        public static int currentPage = 1;
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
        private string LoadFehrest(List<Tbl_News_Type> lstNews)
        {
            var allowRelated = false;
            if (hdfAllowrelated.Value != null)
                try { allowRelated = Convert.ToBoolean(hdfAllowrelated.Value.ToString()); } catch { allowRelated = false; }

            var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);
            var bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate);
            var MaxMenuLine = 28;
            var html = "";
            var listGroupName = lstNews.GroupBy(t => t.GroupOrder).Select(g => g.First()).OrderBy(t => t.GroupOrder).ToList();

            var headerHtml = @" <header class='clearfix'>
                                   <div class='right'><span class='headerTitle'>فهرست اخبار</span></div>   
                                   <div class='left'><span class='headerBultanDate'>" + bultanNewsDate + @"</span></div>
                                    </header>";
            var htmlPageNews = "";
            var LineContinued = 0;

            foreach (var item in listGroupName)
            {
                if (string.IsNullOrWhiteSpace(item.GroupName))
                {
                    try
                    {
                        item.GroupName = _clsKeyword.GetRssKeywordByGroupOrder(Convert.ToInt32(hdfParmin.Value.Split(',')[0]),
                      item.GroupOrder);
                    }
                    catch { }
                }
                try
                {
                    if (lstNews.Any(t => t.GroupOrder == item.GroupOrder))
                    {
                        htmlPageNews += "<div class='fehrestGroupRow clearfix'>" + item.GroupName + "</div>";
                    }
                    foreach (var news in lstNews.Where(t => t.GroupOrder == item.GroupOrder).ToList())
                    {
                        var relatedText = "";
                        if (allowRelated)
                        {
                            try
                            {
                                foreach (var related in news.RelateListStrings)
                                {
                                    relatedText += "," + related.Split('$')[1];
                                }
                                if (!string.IsNullOrWhiteSpace(relatedText))
                                {
                                    relatedText = " " + "(" + relatedText.Substring(1) + ")";
                                }
                            }
                            catch { }
                        }

                        var newsTimeTag = "";
                        if (news.SiteType == 1)
                        {
                            newsTimeTag += @" <span class='time'>" + news.NewsTime + @"</span>  ";
                        }
                        var htmlSingleNews = "";
                        var deleteStr = "";
                        if (HttpContext.Current.Session["CurrentUser"] != null)
                        {
                            deleteStr = " <a href='#' title='حذف خبر از بولتن' class='deleteNewsBooltan' onclick='DeleteNewsFromBooltanArchieve(" + hdfBultanArchiveID.Value + "," + news.NewsID + ")'  > x </a> ";
                        }
                        string newslink = "";
                        newslink = " href='" + news.NewsSiteLink + "'";
                        htmlSingleNews = @"<div class='fehrestRow clearfix'>
                             <div class='fehrestRowRight'> " + deleteStr +
                        @" <span class='circleSing'></span>                        
                            <a class='newsTitle' " + newslink + " data-newsid='" + news.NewsID + @"'>" + news.NewsTitle + " " + relatedText + @"</a></div>
                                <div class='fehrestRowLeft'>" + newsTimeTag + @"                         
                           <span class='siteTitle'>" + news.SiteTitle + @"</span>   </div>
                        </div> ";
                        if (news.NewsTitle.Length > 220)
                        {
                            LineContinued += 2;
                        }
                        else
                        {
                            LineContinued += 1;
                        }
                        if (LineContinued > MaxMenuLine)
                        {

                            LineContinued = 0;
                            var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                            html += "<div  class='page fehrestContainer'>" + headerHtml + htmlPageNews + footerHtml + "</div>";
                            htmlPageNews = htmlSingleNews;
                        }
                        else
                        {
                            htmlPageNews += htmlSingleNews;
                        }
                    }
                }
                catch { }
            }
            if (!string.IsNullOrWhiteSpace(htmlPageNews))
            {
                LineContinued = 0;
                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                html += "<div class='page fehrestContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";
            }
            return "<span id='fehrestContainer'></span>" + html;
        }
        private string LoadNews()
        {

            var parminIds = new List<int?>();
            foreach (var parm in hdfParmin.Value.Split(','))
            {
                parminIds.Add(Convert.ToInt32(parm));

            }

            var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);
            var bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate);


            int RecordCount = 1000;
            var fromDate = Class_Static.GetIntFarsiDate(seletedDate);
            var toDate = fromDate;
            var strSearch = "";
            string NewsIds = "";
            int siteId = 0;
#pragma warning disable CS0219 // The variable 'time' is assigned but its value is never used
            int time = 0;
#pragma warning restore CS0219 // The variable 'time' is assigned but its value is never used
            var UserHighlight = new List<string>();

            var NewsIdsFinal = "";
            if (!string.IsNullOrWhiteSpace(hdfBultanArchiveID.Value))
            {

                try
                {
                    NewsIdsFinal = _clsBultanArchive.GetBultanById(Convert.ToInt32(hdfBultanArchiveID.Value)).SelectedNews;
                }
                catch
                {

                }
            }
            else
            {

                NewsIds = hdfSelectedNews.Value;
            }
            var lstNewsIds = new List<int>();
            try
            {
                foreach (var spil in NewsIdsFinal.Split(','))
                {
                    if (string.IsNullOrWhiteSpace(spil)) continue;
                    if (spil == ",") continue;
                    lstNewsIds.Add(Convert.ToInt32(spil));
                }
            }
            catch { }

            // اگر خبری سلکت شده بود
            if (!string.IsNullOrWhiteSpace(NewsIds) && string.IsNullOrWhiteSpace(NewsIdsFinal))
            {
                NewsIds = NewsIds.Replace(",,", ",");
                NewsIds = NewsIds.Replace(",undefined,", ",");
                NewsIds = NewsIds.Replace(",,", ",");

                if (NewsIds.Substring(0, 1) == ",") NewsIds = NewsIds.Substring(1, NewsIds.Length - 1);
                if (NewsIds.Substring(NewsIds.Length - 1, 1) == ",") NewsIds = NewsIds.Substring(0, NewsIds.Length - 1);
                NewsIds = NewsIds.Replace(",,", ",");


                var lstNewsDic = new Dictionary<int, int>();
                foreach (var n in NewsIds.Split(','))
                {

                    if (string.IsNullOrWhiteSpace(n)) continue;

                    var nVal = Convert.ToInt32(n.Split(';')[0]);
                    var nOrder = Convert.ToInt32(n.Split(';')[1]);

                    if (lstNewsDic.Any(t => t.Key == nVal))
                    {
                        //اگر خبری با همین مشخصه اولیت بالاتر یعنی اول تر بود آپدیت کن
                        if (lstNewsDic.FirstOrDefault(t => t.Key == nVal).Value == 1000 && nOrder != 1000)
                        {
                            lstNewsDic.Remove(nVal);
                            lstNewsDic.Add(nVal, nOrder);
                        }
                        continue;
                    }
                    lstNewsDic.Add(nVal, nOrder);
                }

                foreach (var item in lstNewsDic.OrderBy(t => t.Value).ToList())
                {
                    NewsIdsFinal += "," + item.Key;
                }
                if (!string.IsNullOrWhiteSpace(NewsIdsFinal))
                {
                    NewsIdsFinal = NewsIdsFinal.Substring(1);
                }
            }

            var result = _clsNews.GetAllNewsDataTableByNewsIds(RecordCount, 1, parminIds, null, true, UserHighlight, fromDate, toDate, strSearch, siteId, null, "", "", NewsIdsFinal, "", false);


            var lstDuplicateCRC = new List<long>();


            var lstDic = new Dictionary<string, int>();

            var index = 0;
            var lstNews = new List<Tbl_News_Type>();

            List<Tbl_RssKeywords> keywords = null;
            keywords = _clsKeyword.GetRssKeywordByPanelIds(parminIds);

            int indexOrder = -1;
            char HalfSpace = (char)8204;
            char space = (char)' ';
            foreach (DataRow dr in result.Rows)
            {
                indexOrder++;

                try
                {

                    var NewsTitleSel = Class_Static.ArabicAlpha(dr["NewsTitle"].ToString().ToLower().Trim());

                    NewsTitleSel = NewsTitleSel.Replace(HalfSpace, space);
                    NewsTitleSel = Persia.PersianWord.ConvertToLatinNumber(NewsTitleSel);
                    var NewsLinkUrl = (dr["NewsLink"]);
                    var SiteIDSel = Convert.ToInt32(dr["SiteID"]);
                    var NewsDateIndex = Convert.ToInt64(dr["NewsDate"].ToString().Replace("/", ""));

                    var titleCRC = Math.Abs(NewsTitleSel.Trim().GetHashCode());
                    lstDic.Add(titleCRC + "" + SiteIDSel + "" + NewsDateIndex, SiteIDSel);
                    var keyId = Convert.ToInt32(dr["GroupId"]);
                    var currentKey = keywords.FirstOrDefault(i => i.KeyId == keyId);
                    try
                    {
                        if (string.IsNullOrWhiteSpace(dr["NewsLead"] + ""))
                        {
                            dr["NewsLead"] = (dr["NewsBody"] + "").Split('.').FirstOrDefault() + ".";

                        }
                    }
                    catch
                    {

                    }
                    lstNews.Add(new Tbl_News_Type
                    {
                        NewsSiteLink = (dr["NewsLink"] + "").StartsWith("http") ? (dr["NewsLink"]) + "" : "/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"],
                        NewsLink = "/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"],
                        UserIndexOrder = indexOrder,
                        SiteID = Convert.ToInt32(dr["SiteID"]),
                        NewsID = Convert.ToInt32(dr["NewsID"]),
                        GroupId = Convert.ToInt32(dr["GroupId"]),
                        KeywordID = Convert.ToInt32(dr["KeywordId"]),
                        NewsTitle = _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false),
                        NewsDate = dr["NewsDate"] + "",
                        NewsLead = _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false),
                        KeywordName = dr["KeywordName"] + "",
                        NewsBody = _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false),
                        SiteTitle = dr["SiteTitle"] + "",
                        NewsPicture = dr["NewsPicture"] + "",
                        GroupName = dr["GroupName"] + "",
                        CreateDate = (dr["CreateDate"] + ""),
                        SiteType = Convert.ToInt32(dr["SiteType"]),
                        NewsTime = dr["NewsTime"] + "",
                        SiteLogo = dr["Logo"] + "",
                        GroupOrder = Class_Static.ToNullableInt(dr["GroupOrder"] + ""),
                        NewsValue = (dr["NewsValue"] + ""),
                        NewsGroupOrder = Class_Static.ToNullableInt(dr["NewsGroupOrder"] + ""),
                        NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"])
                        //   OrderItem= dr["GroupOrder"] + "",
                    });


                    index++;

                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                    index++;
                    continue;
                }
            }

            lstNews = lstNews.OrderBy(d => lstNewsIds.IndexOf(d.NewsID)).ToList();

            lstNews = lstNews.GroupBy(test => test.NewsID).Select(grp => grp.First()).ToList();

            lstNews = Class_Static.GenerateNewsTags(lstNews, parminIds).ToList();

#pragma warning disable CS0219 // The variable 'allowRelated' is assigned but its value is never used
            var allowRelated = false;
#pragma warning restore CS0219 // The variable 'allowRelated' is assigned but its value is never used

            if (hdfBultanType.Value.ToString() != "3")
            {
                if (hdfAllowrelated.Value != null)
                {
                    if (hdfAllowrelated.Value.ToString().ToLower() == "true")
                    {
                        allowRelated = true;

                        lstNews = Class_Static.LoadRelatedNews(lstNews);
                    }
                }
            }
            if (hdfBultanType.Value.ToString() == "3")
            {
                allowRelated = true;
                //lstNews = LoadTamarkozRasaneyi(lstNews, NewsIdsFinal);
                lstNews = lstNews.OrderByDescending(t => t.RelatedString.Length).ToList();
            }
            foreach (var item in lstNews)
            {
                var currentKey = keywords.FirstOrDefault(i => i.KeyId == item.KeywordID); /*_clsKeyword.GetRssKeywordById(item.KeywordID);*/
                item.NewsTitle = hdfAllowHighlight.Value.ToLower() == "true" ? Class_Static.HighlightKeywords(currentKey, item.NewsTitle, keywords) : item.NewsTitle;
                item.NewsLead = hdfAllowHighlight.Value.ToLower() == "true" ? Class_Static.HighlightKeywords(currentKey, item.NewsLead, keywords) : item.NewsLead;
                item.NewsBody = hdfAllowHighlight.Value.ToLower() == "true" ? Class_Static.HighlightKeywords(currentKey, item.NewsBody, keywords) : item.NewsBody;
            }

            var html = "";
            //انجمن منتقدین
            if (parminIds.Any(t => t == 2230))
            {
                lstNews = lstNews.OrderBy(t => t.NewsDate).ToList();
            }
            html = LoadFehrest(lstNews);

            return html;
        }
        public string LoadJeld()
        {
            var jeld = true;
            try
            {
                if (Request.QueryString["jeld"] != null)
                {
                    jeld = Convert.ToBoolean(Request.QueryString["jeld"]);
                }
            }
            catch
            {

            }
            var html = "";
            if (!jeld) return html;
            try
            {
                DateTime seletedDate;
                try { seletedDate = Class_Static.ShamsiToMiladi(hdfToDate.Value); } catch { seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value); }
                var bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate);
                var BultanJeldPath = "";
                try
                {
                    var selectedBultan = _clsBultanFiles.SelectItem(Convert.ToInt32(hdfSelectedBultan.Value));
                    BultanJeldPath = selectedBultan.BultanJeldPath;
                }
                catch
                {
                    BultanJeldPath = "/Styles/img/jeld.jpg";
                }
                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";

                html = "<div class='page coverPage'><img  src='" + BultanJeldPath + "' /><time>" + bultanNewsDate + "</time>" + footerHtml + "</div>";


            }
            catch
            {

            }
            return html;


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ArchiveId"] != null)
                {
                    hdfBultanArchiveID.Value = Request.QueryString["ArchiveId"] + "";

                    Tbl_BultanArchive archive = (new Class_BultanArchive()).GetBultanByArchiveId(Convert.ToInt32(hdfBultanArchiveID.Value));
                    hdfDate.Value = archive.FromDateIndex;
                    hdfToDate.Value = archive.ToDateIndex;
                    hdfParmin.Value = archive.PanelId.ToString();
                    hdfSelectedBultan.Value = archive.SelectedBultan.ToString();
                    hdfSelectedNews.Value = archive.SelectedNews.ToString();
                    hdfAllowHighlight.Value = archive.AllowHighlight.ToString();
                    hdfAllowGroup.Value = archive.AllowGroup.ToString();
                    hdfGalleryNewspaper.Value = archive.AllowGalleryNewspaper.ToString();
                    hdfSima.Value = archive.AllowSima.ToString();
                    hdfArz.Value = archive.AllowArz.ToString();
                    hdfAllowrelated.Value = archive.AllowRelated.ToString();
                    hdfAllowNewspaper.Value = archive.AllowNewspaper.ToString();
                    try { hdfBultanType.Value = archive.BultanType.ToString(); } catch { hdfBultanType.Value = "2"; }
                    ltNewsHtml.Text = LoadJeld() + LoadNews();
                }
            }
        }
    }
}