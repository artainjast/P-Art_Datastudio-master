using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class HTMLNews : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["newsdate"] != null)
                {
                    hdfDate.Value = (Request.QueryString["newsdate"] + "").Trim();
                }
                else
                {
                    hdfDate.Value = Class_Static.GetFarsiDate(DateTime.Now);
                }
                if (Request.QueryString["parmin"] != null)
                {
                    hdfParmin.Value = Request.QueryString["parmin"];

                }
                else
                {
                    // بانک گردشگری
                    hdfParmin.Value = "536";
                }

                var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);
                ltNewsDate.Text = Class_Static.GetFarsiDate(seletedDate);
                ltNewsDateFull.Text = Class_Static.GetFarsiDateFull(seletedDate);
                LoadNews();
                LoadNimta();
                LoadVideo();

                rptNews.DataBind();
                rptNimta.DataBind();
                rptVideo.DataBind();

            }
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
        private void LoadNimta()
        {
            var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);
            var cal = Class_Static.GetFarsiDate(seletedDate);
            Class_Nimta _cls = new Class_Nimta();
            rptNimta.DataSource = _cls.GetNimtaByDate(cal);


        }
        Class_News _clsNews = new Class_News();
        private void LoadNews()
        {
            var parminIds = new List<int?>();
            foreach (var parm in hdfParmin.Value.Split(','))
            {
                parminIds.Add(Convert.ToInt32(parm));

            }
            var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);

            int RecordCount = 1000;
            var fromDate = Class_Static.GetIntFarsiDate(seletedDate);
            var toDate = fromDate;
            var strSearch = "";
            string newsIds = "";
            int siteId = 0;
            int time = 0;
            var UserHighlight = new List<string>();
            var result = _clsNews.GetAllNewsDataTable(RecordCount, 1, parminIds, null, true, UserHighlight, fromDate, toDate, strSearch, siteId, null, "", "", newsIds, "", false);

            var lstDuplicateCRC = new List<long>();


            var lstDic = new Dictionary<string, int>();

            var index = 0;
            var lstNews = new List<NewsType>();
            foreach (DataRow dr in result.Rows)
            {
                try
                {

                    var NewsTitleSel = Class_Static.ArabicAlpha(dr["NewsTitle"].ToString().ToLower().Trim());
                    char HalfSpace = (char)8204;
                    char space = (char)' ';
                    NewsTitleSel = NewsTitleSel.Replace(HalfSpace, space);
                    NewsTitleSel = Persia.PersianWord.ConvertToLatinNumber(NewsTitleSel);
                    var NewsLinkUrl = (dr["NewsLink"]);
                    var SiteIDSel = Convert.ToInt32(dr["SiteID"]);
                    var NewsDateIndex = Convert.ToInt64(dr["NewsDate"].ToString().Replace("/", ""));

                    var titleCRC = Math.Abs(NewsTitleSel.Trim().GetHashCode());



                    lstDic.Add(titleCRC + "" + SiteIDSel + "" + NewsDateIndex, SiteIDSel);

                    //  }
                    HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();

                    var currentKey = _clsKeyword.GetRssKeywordById(Convert.ToInt32(dr["GroupId"]));
                    var ls = new List<int?> { currentKey.PanelId };

                    var keywords = _clsKeyword.GetRssKeywordByPanelIds(ls);

                    lstNews.Add(new NewsType
                    {
                        NewsLink = dr["NewsLink"] + "",
                        SiteID = Convert.ToInt32(dr["SiteID"]),
                        NewsID = Convert.ToInt32(dr["NewsID"]),
                        GroupId = Convert.ToInt32(dr["GroupId"]),
                        NewsTitle = HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false), keywords),
                        NewsDate = dr["NewsDate"] + "",
                        NewsLead = HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false), keywords),
                        KeywordName = dr["KeywordName"] + "",
                        NewsBody = HighlightKeywords(currentKey, _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false), keywords),
                        SiteTitle = dr["SiteTitle"] + "",
                        NewsPicture = dr["NewsPicture"] + "",
                        GroupName = dr["GroupName"] + "",
                        CreateDate = Convert.ToDateTime(dr["CreateDate"]),
                        SiteType = Convert.ToInt32(dr["SiteType"]),
                        NewsTime = dr["NewsTime"] + "",



                    });


                    index++;

                }
                catch
                {

                    index++;
                    continue;
                }
            }
            var listGroupName = lstNews.GroupBy(t => t.GroupName).Select(g => g.First()).ToList();

            var str = "";
            foreach (var item in listGroupName)
            {
                str += "," + item.GroupName;
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                hdfGroups.Value = str.Substring(1);
            }
            rptNews.DataSource = lstNews.OrderBy(t => t.GroupName).ThenBy(t => t.KeywordName).ToList();


        }
        private void LoadVideo()
        {
            //var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);
            //var cal = Class_Static.GetFarsiDate(seletedDate);
            Class_Movies _cls = new Class_Movies();
            var parminIds = new List<int?>();
            foreach (var parm in hdfParmin.Value.Split(','))
            {
                parminIds.Add(Convert.ToInt32(parm));

            }

            var allVideos = _cls.GetAllMovie(100, 1, parminIds, null, "", null,(hdfDate.Value.Replace("/", "")));
            rptVideo.DataSource = allVideos;
        }

        Class_Keywords _clsKeyword = new Class_Keywords();

        public string HighlightKeywords(P_Art.Pages.P_Art.ModelNews.Tbl_RssKeywords currentKey, string txt, List<P_Art.Pages.P_Art.ModelNews.Tbl_RssKeywords> keywords)
        {

            string newsMerge = Class_Static.PersianAlpha(txt);

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
                key.KeywordName = Class_Static.PersianAlpha((key.KeywordName));
                if (newsMerge.IndexOf(" " + key.KeywordName + " ") > -1)
                {
                    if (!findKeywords.Any(t => t == Class_Static.PersianAlpha(key.KeywordName.Trim())))
                    {
                        findKeywords.Add(Class_Static.PersianAlpha(key.KeywordName.Trim()));
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
                newsMerge = newsMerge.Replace(item, "<span class='highlight'>" + item + "</span>");
            }

            return newsMerge.Trim();

        }
        public class NewsType
        {
            public int NewsID { get; set; }
            public int SiteID { get; set; }
            public int GroupId { get; set; }
            public string NewsTitle { get; set; }
            public string KeywordName { get; set; }
            public string NewsLead { get; set; }
            public string NewsBody { get; set; }
            public string NewsLink { get; set; }
            public string SiteTitle { get; set; }
            public string NewsPicture { get; set; }
            public string GroupName { get; set; }

            public string NewsDate { get; set; }

            public DateTime CreateDate { get; set; }

            public int SiteType { get; set; }

            public string NewsTime { get; set; }
        }
    }
}