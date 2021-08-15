using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using FarsiLibrary.Utils;
using P_Art.Pages.P_Art.Repository;


using PArt.Core;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Data.OleDb;
using P_Art.Pages.P_Art.ModelNews;
using System.Globalization;
using System.Data.SqlClient;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class NewsFocus : System.Web.UI.Page
    {
        DataSet dsAllData;
#pragma warning disable CS0414 // The field 'NewsFocus.dsPanelData' is assigned but its value is never used
        DataSet dsPanelData = null;
#pragma warning restore CS0414 // The field 'NewsFocus.dsPanelData' is assigned but its value is never used
        List<int?> panelIds = new List<int?>();
        List<Tbl_News_Type> NewsList = new List<Tbl_News_Type>();
        List<Tbl_News_Type> NewsFocusList = new List<Tbl_News_Type>();
        List<Tbl_News_Type.Tbl_Panel_Type> panel = new List<Tbl_News_Type.Tbl_Panel_Type>();

        public string SetCustomSort(string siteId)
        {
            if (!string.IsNullOrWhiteSpace(hdfUserCustomSort.Value))
            {
                var keyId = Convert.ToInt32(siteId);
                List<int> siteIds = new List<int>();

                foreach (string site in hdfUserCustomSort.Value.Split(','))
                {
                    if (site == "") continue;
                    try
                    {
                        siteIds.Add(int.Parse(site));
                    }
                    catch
                    {
                        continue;
                    }
                }
                //  var sel = siteIds.FirstOrDefault(t => t == keyId);
                if (!siteIds.Any(t => t == keyId))
                {
                    return "1000";
                }
                else
                {
                    return siteIds.IndexOf(keyId) + "";
                }
            }
            else
            {
                return "1000";
            }
        }
        public static string DiffrentDate(object ddate, string sitetype, string newstime, string newsDateStr)
        {
            try
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
            catch
            {
                return "";

            }


        }
        public static string NewsRateOpacity(object newsValue, string MustValue)
        {
            if (newsValue.ToString() == "")
            {
                if (MustValue == "0")
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.1";
                }
            }
            else
            {
                if (newsValue.ToString() == MustValue)
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.1";
                }
            }
        }

        public static List<Tbl_News_Type> LoadRelatedNews(List<Tbl_News_Type> GroupNewsList)
        {

            int MaxCharSize = 250;

            int ComparePercent = 45;

            List<Tbl_News_Type> compiledNewsList = new List<Tbl_News_Type>();
            List<Tbl_News_Type> newsList1 = GroupNewsList;
            List<Tbl_News_Type> newsList2 = newsList1;
            var allNewsList = newsList1;
            var listDup = new List<int>();
            for (int f = 0; f < newsList1.Count; f++)
            {
                // اگر خبر قبلا مرتبط خبری شده بود دیگر خبر را بررسی نکن
                if (listDup.Any(t => t == newsList1[f].NewsID)) continue;
                string first1;
                if (newsList1[f].NewsLead != string.Empty)
                    if (newsList1[f].NewsLead.Length > MaxCharSize)
                    {
                        string str = newsList1[f].NewsLead.Substring(0, MaxCharSize);
                        first1 =Class_News.SpaceToWord(newsList1[f].NewsTitle + " " + str);
                    }
                    else
                    {
                        string str = string.Empty;
                        if (newsList1[f].NewsBody.Length > MaxCharSize)
                            str = newsList1[f].NewsBody.Substring(0, MaxCharSize);
                        else str = newsList1[f].NewsBody;
                        first1 = Class_News.SpaceToWord(newsList1[f].NewsTitle + " " + str);
                    }
                else
                {
                    int charLocation = newsList1[f].NewsBody.IndexOf(".", StringComparison.Ordinal);

                    //if (charLocation > 0)
                    //{
                    if (newsList1[f].NewsBody.Length > MaxCharSize)
                        first1 = Class_News.SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody.Substring(0, MaxCharSize));
                    else
                        first1 = Class_News.SpaceToWord(newsList1[f].NewsTitle + " " + newsList1[f].NewsBody);
                    //}
                    //else first1 = SpaceToWord(newsList1[f].NewsTitle);

                }
                string first2 = Class_News.removeIligalCharacter(first1);
                var firstList = first2.Split(new string[] { " " },
                      StringSplitOptions.RemoveEmptyEntries).ToList();
                var firstListTemp = new List<string>();
                foreach (var s in firstList)
                {
                    if (Class_News.IsContainPrepositionPersianWord(s) == false)
                    {
                        firstListTemp.Add(s);
                    }

                }
                for (int g = 0; g < newsList2.Count; g++)
                {
                    if (listDup.Any(t => t == newsList2[g].NewsID)) continue;
                    string second1;
                    if (newsList2[g].NewsLead != string.Empty)
                        if (newsList2[g].NewsLead.Length > MaxCharSize)
                        {
                            string str = newsList2[g].NewsLead.Substring(0, MaxCharSize);
                            second1 = Class_News.SpaceToWord(newsList2[g].NewsTitle + " " + str);
                        }
                        else
                        {
                            string str = string.Empty;
                            if (newsList2[g].NewsBody.Length > MaxCharSize)
                                str = newsList2[g].NewsBody.Substring(0, MaxCharSize);
                            else
                                str = newsList2[g].NewsLead;
                            second1 = Class_News.SpaceToWord(newsList2[g].NewsTitle + " " + str);
                        }
                    else
                    {
                        int charLocation = newsList2[g].NewsBody.IndexOf(".", StringComparison.Ordinal);

                        //if (charLocation > 0)
                        //{
                        if (newsList2[g].NewsBody.Length > MaxCharSize)
                            second1 = Class_News.SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody.Substring(0, MaxCharSize));
                        else second1 = Class_News.SpaceToWord(newsList2[g].NewsTitle + " " + newsList2[g].NewsBody);
                        //}
                        //else second1 = SpaceToWord(newsList2[g].NewsTitle);

                    }
                    string second2 = Class_News.removeIligalCharacter(second1);
                    var secondList = second2.Split(new string[] { " " },
                        StringSplitOptions.RemoveEmptyEntries).ToList();
                    var secondListTemp = new List<string>();
                    foreach (var h in secondList)
                    {
                        if (Class_News.IsContainPrepositionPersianWord(h) != true)
                        {
                            secondListTemp.Add(h);

                        }

                    }
                    // secondList= secondListTemp;

                    int firstLength = firstListTemp.Count;
                    int secondLength = secondListTemp.Count;
                    int found = 0;
                    double relatedPercent = 0;

                    //compiledNewsList = newsList1;
                    if (newsList1[f].NewsID != newsList2[g].NewsID)
                    {


                        for (int j = 0; j < secondLength; j++)
                        {
                            if (firstListTemp.Any(t => t == secondListTemp[j]))
                                found++;
                        }

                        if (found > 0)
                        {
                            relatedPercent = (found * 100) / secondLength;
                        }
                        if (relatedPercent >= ComparePercent)
                        {
                            listDup.Add(newsList2[g].NewsID);
                            if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                            {
                                var RELATE = compiledNewsList.
                                      FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                      .RelateListIds;

                                var RELATE_Strings = compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListStrings;

                                if (RELATE == null)
                                    RELATE = new List<int>();

                                if (RELATE_Strings == null)
                                    RELATE_Strings = new List<string>();

                                RELATE.Add(newsList2[g].NewsID);

                                RELATE_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);

                                compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListIds = RELATE;

                                compiledNewsList.
                                    FirstOrDefault(t => t.NewsID == newsList1[f].NewsID)
                                    .RelateListStrings = RELATE_Strings;
                            }
                            else
                            {

                                var news = newsList1[f];
                                // news.NewsID = newsList1[f].NewsID;
                                //  news.NewsTitle = newsList1[f].NewsTitle;
                                // news.NewsLead = newsList1[f].NewsLead;
                                //  news.NewsBody = newsList1[f].NewsBody;
                                //  news.NewsDateIndex = newsList1[f].NewsDateIndex;

                                var REl = new List<int>();
                                REl.Add(newsList2[g].NewsID);

                                var REl_Strings = new List<string>();
                                //REl_Strings.Add(newsList2[g].SiteTitle);
                                REl_Strings.Add(newsList2[g].NewsID + "$" + newsList2[g].SiteTitle + "$" + newsList2[g].NewsTitle);


                                news.RelateListIds = REl;
                                news.RelateListStrings = REl_Strings;



                                compiledNewsList.Add(news);
                            }
                        }
                        else
                        {
                            if (compiledNewsList.Any(t => t.NewsID == newsList1[f].NewsID))
                            {


                            }
                            else
                            {
                                var news = newsList1[f];

                                compiledNewsList.Add(news);
                            }
                        }
                    }

                }
            }
            allNewsList = allNewsList.Where(i => listDup.Contains(i.NewsID)).ToList();

            //compiledNewsList = compiledNewsList.OrderBy(d => d.SortOrder).ThenBy(d => d.NewsDateIndex).ThenBy(d => d.NewsTime).ToList();
            List<Tbl_News_Type> finalList = new List<Tbl_News_Type>();
            finalList = compiledNewsList;
            foreach (var i in compiledNewsList.ToList())
            {
                if (listDup.Any(t => t == i.NewsID))
                {
                    var find = finalList.Find(j => j.NewsID == i.NewsID);
                    try
                    {
                        // var dupped = finalList.FirstOrDefault(t => t.NewsID == find.NewsID);
                        foreach (var item in finalList)
                        {
                            if (item.NewsID != find.NewsID && item.RelateListIds.Any(t => t == find.NewsID))
                            {
                                if (find.RelateListIds.Count > 0)
                                {
                                    var oldRelate = item.RelateListIds;
                                    var newsRelate = oldRelate;
                                    foreach (var item0 in find.RelateListIds)
                                    {
                                        if (!newsRelate.Any(t => t == item0))
                                        {
                                            newsRelate.Add(item0);
                                        }
                                    }
                                    var oldRelateStr = item.RelateListStrings;
                                    var newsRelateStr = oldRelateStr;
                                    foreach (var item0 in find.RelateListStrings)
                                    {
                                        if (!newsRelateStr.Any(t => t == item0))
                                        {
                                            newsRelateStr.Add(item0);
                                        }
                                    }
                                    finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListIds = newsRelate;
                                    finalList.FirstOrDefault(t => t.NewsID == item.NewsID).RelateListStrings = newsRelateStr;
                                }

                            }

                        }
                        finalList.Remove(find);
                    }
                    catch { continue; }

                }
            }
            return finalList;
        }

        public string GetNewsFullDateIndex(string newsDate, string createDate, string newsTime, string siteType)
        {
            if (siteType == "2")
            {
                //return zm.MiladiToShamsi(ddate.ToString()).Substring(0, 10);
                newsTime = "0000";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(newsTime))
                {
                    newsTime = "0000";
                }
                else
                {
                    newsTime = Class_Static.GetAbsoluteTime(newsTime).Replace(":", "");
                }
            }
            var dateIndex = "";
            if (string.IsNullOrWhiteSpace(newsDate))
            {
                var dt = DateTime.Parse(createDate);
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                dateIndex = pc.GetYear(dt) + "" + Class_Static.RoundTenNum(pc.GetMonth(dt)) + "" + Class_Static.RoundTenNum(pc.GetDayOfMonth(dt));


            }
            else
            {
                dateIndex = newsDate.Replace("/", "");
            }
            return dateIndex + "" + newsTime;
        }
        private void prepareData(long fromDate, long toDate, string Search = "")
        {
            Search = Class_Static.ArabicAlpha(Search);
            string cmdSearch = "";
            string cmdTitle = "";
            string cmdLead = "";
            string cmdBody = "";
            if (Search != string.Empty && Search != null)
                if (Search.Contains("+"))
                {
                    cmdSearch = " AND (";
                    int totalCount = Search.Split('+').Count();
                    int count = 0;
                    cmdTitle = "(";
                    cmdLead = " (";
                    cmdBody = " (";
                    foreach (var i in Search.Split('+'))
                    {
                        count++;
                        if (totalCount != count)
                        {
                            cmdTitle += " dbo.Tbl_News.NewsTitle LIKE N'% " + i + " %' AND ";
                            cmdLead += " dbo.Tbl_News.NewsLead LIKE N'% " + i + " %' AND ";
                            cmdBody += " dbo.Tbl_News.NewsBody LIKE N'% " + i + " %' AND ";
                        }
                        else
                        {
                            cmdTitle += " dbo.Tbl_News.NewsTitle LIKE N'% " + i + " %' )";
                            cmdLead += " dbo.Tbl_News.NewsLead LIKE N'% " + i + " %' )";
                            cmdBody += " dbo.Tbl_News.NewsBody LIKE N'% " + i + " %' )";
                        }

                    }
                    cmdSearch += cmdTitle + " OR " + cmdLead + " OR " + cmdBody;
                    cmdSearch += " ) ";
                }
                else
                {
                    cmdSearch = " AND (";
                    cmdSearch += " dbo.Tbl_News.NewsTitle LIKE N'% " + Search + " %' OR NewsLead LIKE N'% " + Search + " %' OR NewsBody LIKE N'% " + Search + " %'";
                    cmdSearch += " ) ";
                }


             panelIds = Class_Layer.UserPanels();
           
            dsAllData = Class_News.GetFocusNews(10000, 0, panelIds, false, fromDate, toDate
                      , cmdSearch, "", "");


          
            NewsList = Class_News.GetFromDataRows(dsAllData.Tables[0].Select());
            NewsFocusList = LoadTamarkozRasaneyi(NewsList);
            rptTimeLine.DataSource = NewsFocusList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
            rptTimeLine.DataBind();
            rptFehrest.DataSource = NewsFocusList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
            rptFehrest.DataBind();
            Session.Add("NewsList", NewsList);
            Session.Add("NewsFocusList", NewsFocusList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList());
            prepareDivs();
            divTimeLineBody.Visible = true;
            divFehrest.Visible = true;

        }
        private void prepareDivs()
        {
            divLoad.Visible = false;
            divTree.Visible = false;
            divTimeLineBody.Visible = false;
            divFehrest.Visible = false;
        }
        private void LoadTemplate()
        {
            Class_Panels _cls = new Class_Panels();
            List<int> ids = new List<int>();
            ListItem newItem = new ListItem();
            var parmin = _cls.GetParminById(int.Parse(panelIds[0].Value.ToString()));
            if (parmin.BultanId == null)
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = "قالب جدید";
                newItem1.Value = "58";
                drp_template.Items.Add(newItem);


                newItem.Text = "قالب اصلی";
                newItem.Value = "40";
                drp_template.Items.Add(newItem);
                return;
            }
            else
            {
                foreach (var id in parmin.BultanId.Split(','))
                {
                    ids.Add(int.Parse(id.ToString()));
                }
                var files = _cls.GetBultanFiles(ids);
                foreach (var file in files)
                {
                    newItem = new ListItem();
                    newItem.Text = file.Title;
                    newItem.Value = file.BultanID.ToString();
                    drp_template.Items.Add(newItem);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!Page.IsPostBack)
            {
                Class_Zaman zm = new Class_Zaman();
                txt_fromDate.Text = zm.Today();
              
                long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                long toDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                ///prepareData(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text);
                linkTimeLine.Attributes.Add("class", "active-titr");
                linkEvent.Attributes.Add("class", "");
                linkReport.Attributes.Add("class", "");
                linkImportData.Attributes.Add("class", "");
                linkReleaseNews.Attributes.Add("class", "");
                prepareDivs();
                divLoad.Visible = true;
                panelIds = Class_Layer.UserPanels();
                LoadTemplate();
            }
        }
        protected void rptTimeLine_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            Tbl_News_Type newsData = (Tbl_News_Type)e.Item.DataItem;
            //Repeater rptTimeLineNews = e.Item.FindControl("rptTimeLineNews") as Repeater;
            //if (newsData.RelateListIds != null)
            //{
            //    rptTimeLineNews.DataSource = NewsList.Where(i => newsData.RelateListIds.Contains(i.NewsID)).ToList();
            //    rptTimeLineNews.DataBind();
            //}

        }
        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
            long toDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
            prepareData(fromDateIndex, toDateIndex, txtSeacrh.Text);
        }
        protected void btnShowEvent_Click(object sender, EventArgs e)
        {

        }
        protected void btnTreeLink_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string newsID = btn.CommandArgument;
            List<Tbl_News_Type> NewsList = (List<Tbl_News_Type>)Session["NewsList"];
            List<Tbl_News_Type> NewsFocusListTimeLine = (List<Tbl_News_Type>)Session["NewsFocusList"];
            List<int> relatedIds = NewsFocusListTimeLine.FirstOrDefault(i => i.NewsID == Convert.ToInt32(newsID)).RelateListIds;
            rptTree.DataSource = NewsList.Where(i => relatedIds.Contains(i.NewsID)).ToList();
            rptTree.DataBind();
            prepareDivs();
            divTimeLineBody.Visible = true;
            divTree.Visible = true;

        }
        protected void rptFehrest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void btnGetTimeLineReport_Click(object sender, EventArgs e)
        {

            string result = "";
            panelIds = Class_Layer.UserPanels();
            foreach (RepeaterItem item in rptFehrest.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    string codes = "";
                    string relateCodes = "";
                    CheckBox check_SelectNews = (CheckBox)item.FindControl("check_SelectNews");
                    HiddenField hddRelated = (HiddenField)item.FindControl("hddRelated");
                    HiddenField hddNewsId = (HiddenField)item.FindControl("hddNewsId");
                    if (check_SelectNews.Checked == true)
                    {
                        codes += codes != string.Empty ? "," : string.Empty;
                        codes += hddNewsId.Value;
                        var a = hddRelated.Value.Split(',');
                        foreach (var r in a)
                        {
                            relateCodes += relateCodes != string.Empty ? "," : string.Empty;
                            relateCodes += r;
                        }
                        result += result != string.Empty ? "$" : string.Empty;
                        result += codes + "-" + relateCodes;
                    }

                }
            }
            if (result != string.Empty)
            {
                string dateFrom = txt_fromDate.Text.Replace("/", "");
                string dateTo = txt_fromDate.Text.Replace("/", "");
               
                int ArchiveId = (new Class_TimeLineReportArchive()).InsertFocus(0, (int)panelIds[0], txt_fromDate.Text.Replace("/", ""),
                      dateFrom, dateTo, txt_reportTitle.Text, result, DateTime.Now, check_IsCover.Checked,
                      check_IsAboutPayesh.Checked, check_IsAboutProject.Checked,
                     check_IsFehrest.Checked, check_IsProjectSubject.Checked, (byte)1, "", txt_aboutProject.Text,
                     txt_subjectProject.Text, Convert.ToInt32(drp_template.SelectedValue));
                Response.Redirect("/TimelineReport.aspx?ArchiveId=" + ArchiveId);
            }

        }
        public static List<Tbl_News_Type> LoadTamarkozRasaneyi(List<Tbl_News_Type> NewsList)
        {
            DataSet ds = null;
            List<Tbl_News_Type> compiledList = new List<Tbl_News_Type>();
            foreach (var n in NewsList)
            {
                try
                {
                    ds = Class_News.GetTamarkozRasaneyiData(n.NewsID);
                    List<Tbl_News_Type> news = Tbl_News_Type.GetFromDataRows(ds.Tables[0].Select());
                    foreach (var nn in news)
                    {

                        nn.RelateListStrings = new List<string>();

                        List<int> newsRelatedIdList = new List<int>();
                        if (nn.RelatedString != null && nn.RelatedString != "")
                            if (nn.RelatedString.Contains(","))
                            {
                                foreach (var i in nn.RelatedString.Split(','))
                                {
                                    newsRelatedIdList.Add(Convert.ToInt32(i));
                                    string siteTitle = Class_News.GetNewsSiteTitle(Convert.ToInt32(i));
                                    string newsTitle = Class_News.GetNewsTitle(Convert.ToInt32(i));
                                    nn.RelateListStrings.Add(i + "$" + siteTitle + "$" + newsTitle);
                                }
                            }
                            else
                            {
                                newsRelatedIdList.Add(Convert.ToInt32(nn.RelatedString));
                                string siteTitle = Class_News.GetNewsSiteTitle(Convert.ToInt32(nn.RelatedString));
                                string newsTitle = Class_News.GetNewsTitle(Convert.ToInt32(nn.RelatedString));
                                nn.RelateListStrings.Add(nn.RelatedString + "$" + siteTitle + "$" + newsTitle);
                            }
                        nn.RelateListIds = newsRelatedIdList;
                        compiledList.Add(nn);

                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch(Exception ex) { continue; }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            }
            return compiledList;
        }
    }
}