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
    public partial class NewsTimeLine : System.Web.UI.Page
    {
        DataSet dsAllData;
        List<int?> panelIds = new List<int?>();
        List<Tbl_News_Type> NewsList = new List<Tbl_News_Type>();
        List<Tbl_News_Type> NewsListTimeLine = new List<Tbl_News_Type>();
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
        private void prepareData(long fromDate, long toDate, string fromHour, string toHour, string Search = "")
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

            dsAllData = Class_News.GetStreamNews(10000, 0, panelIds, false, fromDate, toDate,
                fromHour, toHour, cmdSearch, "", "");
            NewsList = Class_News.GetFromDataRows(dsAllData.Tables[0].Select());
            NewsListTimeLine = Class_Static.LoadRelatedNewsTimeline(NewsList);
            rptTimeLine.DataSource = NewsListTimeLine.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
            rptTimeLine.DataBind();
            rptFehrest.DataSource = NewsListTimeLine.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
            rptFehrest.DataBind();
            Session.Add("NewsList", NewsList);
            Session.Add("NewsListTimeLine", NewsListTimeLine.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList());
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
                txt_toDate.Text = zm.Today();
                long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));
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
            long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));
            prepareData(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text, txtSeacrh.Text);
        }
        protected void btnShowEvent_Click(object sender, EventArgs e)
        {

        }
        protected void btnTreeLink_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string newsID = btn.CommandArgument;
            List<Tbl_News_Type> NewsList = (List<Tbl_News_Type>)Session["NewsList"];
            List<Tbl_News_Type> NewsListTimeLine = (List<Tbl_News_Type>)Session["NewsListTimeLine"];
            List<int> relatedIds = NewsListTimeLine.FirstOrDefault(i => i.NewsID == Convert.ToInt32(newsID)).RelateListIds;
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
                string dateTo = txt_toDate.Text.Replace("/", "");
                if (txt_fromHour.Text != string.Empty)
                    dateFrom = dateFrom + "" + txt_fromHour.Text.Replace(":", "");
                else
                    dateFrom = dateFrom + "" + "0000";
                if (txt_toHour.Text != string.Empty)
                    dateTo = dateTo + "" + txt_toHour.Text.Replace(":", "");
                else
                    dateTo = dateTo + "" + DateTime.Now.ToString("HHmm");
              int ArchiveId =   (new Class_TimeLineReportArchive()).Insert(0, (int)panelIds[0], txt_toDate.Text.Replace("/", ""),
                    dateFrom, dateTo, txt_reportTitle.Text,result, DateTime.Now, check_IsCover.Checked,
                    check_IsAboutPayesh.Checked, check_IsAboutProject.Checked,
                   check_IsFehrest.Checked, check_IsProjectSubject.Checked, (byte)1, "", txt_aboutProject.Text,
                   txt_subjectProject.Text, Convert.ToInt32(drp_template.SelectedValue));
                Response.Redirect("/TimelineReport.aspx?ArchiveId=" + ArchiveId);
            }

        }
    }
}