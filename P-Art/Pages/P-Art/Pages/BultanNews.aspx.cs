using FarsiLibrary.Utils;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class BultanNews : System.Web.UI.Page
    {
        [ThemeableAttribute(false)]
        public virtual string GroupName { get; set; }

        Class_News _clsNews = new Class_News();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
        List<Tbl_News_Type> GroupNewsList = new List<Tbl_News_Type>();
        List<Tbl_RssKeywords> keywordList = new List<Tbl_RssKeywords>();
        List<Tbl_RssKeywords> keywordGroupList = new List<Tbl_RssKeywords>();
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        //  List<Tbl_News_Type> allNewsList = new List<Tbl_News_Type>();
        private int RecordCount = 10000;

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (IsPostBack)
            {
                //string parameter = Request["__EVENTARGUMENT"] + ""; // parameter
                //var buttonClick = Request["__EVENTTARGET"] + ""; // btnSave
                //if (!string.IsNullOrWhiteSpace(buttonClick))
                //{
                //    switch (buttonClick.Trim().ToLower())
                //    {
                //        case "DoRelateNews":
                //            {


                //                // rptMostRelatedNews_list.DataSource = relatedList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
                //                //rptMostRelatedNews_list.DataBind();
                //                break;
                //            }

                //        default: break;

                //    }
                //}
            }
            else
            {



                UserPanelList = Class_Layer.UserPanels();
                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }

                LoadUserData();
                LoadNewsSource();
                LoadData(0);
                LoadTemplate();
                DateTime dt = DateTime.Now.AddDays(-1);
                string date = _clsZm.MiladiToShamsi(dt.ToShortDateString());
                date = date.Substring(0, 10).Replace("/", "");
                lnk_yesterday.HRef = "/News/Latest/?FromDate=" + date + "&toDate=" + date;

                var parmin = UserPanelList[0].Value + "";// (Class_Layer.UserPanels()[0].Value) + "";

                //  btn_generateGroupHtml.CommandArgument = parmin;
                btn_generateGroupHtml.Attributes.Add("data-parmin", parmin);
            }
        }

        public string GetClearText(object str)
        {

            var htmlNode = new HtmlAgilityPack.HtmlDocument();
            htmlNode.LoadHtml(str + "");
#pragma warning disable CS0618 // 'HtmlNode.DescendantNodes()' is obsolete: 'Use Descendants() instead, the results of this function will change in a future version'
            return Class_Static.GetAbsoulateTextFromHtmlNode(htmlNode.DocumentNode.DescendantNodes().FirstOrDefault());
#pragma warning restore CS0618 // 'HtmlNode.DescendantNodes()' is obsolete: 'Use Descendants() instead, the results of this function will change in a future version'
        }
        private void LoadUserData()
        {
            var currentUser = Class_Layer.CurrentUser();
            //Load ResourceSortingOrder

            if (!string.IsNullOrWhiteSpace(currentUser.ResourceSortingOrder))
            {
                List<int> siteIds = new List<int>();
                foreach (string site in currentUser.ResourceSortingOrder.Split(','))
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
                hdfUserCustomSort.Value = currentUser.ResourceSortingOrder;
                var siteData = _clsSite.SelectResourceSortingOrder(siteIds);
                rptSelectedSiteSort.DataSource = siteData;
                rptSelectedSiteSort.DataBind();
            }


            hdfUserID.Value = currentUser.MemberID + "";
        }



        public static List<Tbl_News_Type> GetFromDataRows(DataRow[] Rows)
        {
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            foreach (DataRow r in Rows)
            {
                //news.CreateDate = Convert.ToDateTime(i.CreateDate);
                //news.GroupId = i.GroupId;
                //news.GroupName = i.GroupName;
                //news.GroupOrder = i.GroupOrder.ToString();
                //news.KeywordId = i.KeywordId;
                //news.NewsBody = i.NewsBody;
                //news.NewsDate = i.NewsDate;
                //news.NewsID = i.NewsID;
                //news.NewsLead = i.NewsLead;
                //news.NewsLink = i.NewsLink;
                //news.NewsPicture = i.NewsPicture;
                //news.NewsTime = i.NewsTime;
                //news.NewsTitle = i.NewsTitle;
                //news.SiteID = i.SiteID;
                //news.SiteLogo = i.Logo;
                //news.SiteTitle = i.SiteTitle;
                //news.SiteType = i.SiteType;
                //news.IsFeederNews = i.IsFeederNews;
                //news.NewsLinkCRC = i.NewsLinkCRC;
                //news.Color = i.Color;
                //news.IsSelected = i.IsSelected;
                //news.NewsValue = i.NewsValue;
                //news.SortOrder = i.SortOrder;
                //news.NewsDateIndex = i.NewsDateIndex;
                //news.CreateUser = i.CreateUser;
                //news.NewsGroupOrder = (i.NewsGroupOrder);
                try
                {
                    Tbl_News_Type n = new Tbl_News_Type();
                    n.NewsID = Convert.ToInt32(r["NewsID"]);
                    n.CreateUser = Convert.ToInt32(r["CreateUser"]);
                    n.SiteLogo = (r["Logo"] + "").ToString();
                    n.NewsTitle = (r["NewsTitle"] + "").ToString();
                    n.NewsLead = (r["NewsLead"] + "").ToString();
                    n.NewsBody = (r["NewsBody"] + "").ToString();
                    n.NewsGroupOrder = Class_Static.ToNullableInt(r["NewsGroupOrder"] + "");
                    n.SiteID = Convert.ToInt32(r["SiteID"] + "");

                    n.GroupOrder = Class_Static.ToNullableInt(r["GroupOrder"] + "");
                    n.GroupName = (r["GroupName"] + "").ToString();
                    n.NewsDateIndex = Convert.ToInt64(r["NewsDateIndex"]);
                    n.KeywordId = r["KeywordId"] != null ? Convert.ToInt32(r["KeywordId"]) : 0;
                    n.GroupId = r["GroupId"] != null ? Convert.ToInt32(r["GroupId"]) : 0;
                    try { n.NewsLinkCRC = Convert.ToInt64(r["NewsLinkCRC"]); } catch { n.NewsLinkCRC = 0; }
                    try { n.IsFeederNews = Convert.ToBoolean(r["IsFeederNews"]); } catch { n.IsFeederNews = false; }
                    try { n.SortOrder = r["SortOrder"].ToString(); } catch { n.SortOrder = string.Empty; }
                    n.Color = (r["Color"] + "").ToString();
                    try { n.IsSelected = Convert.ToBoolean(r["IsSelected"]); } catch { n.IsSelected = false; }
                    n.NewsValue = (r["NewsValue"] + "").ToString();
                    /*try*/
                    { n.CreateDate = (r["CreateDate"] + "").ToString(); }/* catch { n.CreateDate = string.Empty; }*/
                                                                         /*try*/
                    { n.NewsTime = (r["NewsTime"] + "").ToString(); }/* catch { n.NewsTime = string.Empty; }
                /*try*/
                    {
                        n.SiteType = Convert.ToInt32(r["SiteType"]);
                    } /*catch { n.SiteType = 0; }*/
                      /*try*/
                    {
                        n.SiteTitle = (r["SiteTitle"] + "").ToString();
                    }/* catch { n.SiteTitle = string.Empty; }*/
                     /*try*/
                    { n.NewsDate = (r["NewsDate"] + "").ToString(); }/* catch { n.NewsDate = string.Empty; }*/

                    n.KeyIds = (r["KeyIds"] + "").ToString();
                    //  n.NewsGroupOrderTest = Class_Static.ToNullableInt(r["NewsGroupOrderTest"] + "");
                    list.Add(n);
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
            }
            return list;
        }
        public string IsSelectedItem(object isSelected)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(isSelected.ToString()))
                    return "";

                var res = Convert.ToBoolean(isSelected);
                if (!res)
                    return "";
                else
                    return "checked";
            }
            catch
            {
                return "";
            }
        }
        public string GetNewsLead(string NewsLead)
        {
            HtmlRemoval html = new HtmlRemoval();
            var htmlStrip = html.HtmlStrip(NewsLead);
            if (htmlStrip.Length >= 300)
            {
                htmlStrip = htmlStrip.Substring(0, 300) + " ...";

            }

            foreach (var highText in Class_Layer.UserHighlight())
            {
                if (highText.Trim() == "") continue;

                string HighCon = highText.Replace('ی', 'ي');

                htmlStrip = htmlStrip.Replace(" " + highText + " ", "<span class='highlight'> " + highText + " </span>");
                htmlStrip = htmlStrip.Replace(" " + HighCon + " ", "<span class='highlight'> " + HighCon + " </span>");

            }

            return htmlStrip;

        }
        public string GetNewsSite(int siteId)
        {
            try
            {

                Class_Sites cls = new Class_Sites();
                //return "";
                return cls.GetSiteById(siteId).SiteTitle;
            }
            catch
            {
                return "";
            }

        }
        public string GetNewsDate(string NewsDate)
        {
            try
            {
                PersianDate pDate = PersianDate.Parse(NewsDate);

                return pDate.ToString("D");
            }
            catch
            {
                return "";
            }
        }
        public string IsRead(bool IsRead)
        {
            try
            {

                if (IsRead == false)
                {
                    return "<figcaption>جدید</figcaption>";
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }

        }
        public string GetNewsPicture(string NewsPicture)
        {
            try
            {
                if (NewsPicture.ToString().Trim() == "" || NewsPicture.ToString().Trim() == ".")
                {
                    return "~/Pages/P-Art/Images/noImage.gif";
                }

                else
                {
                    return NewsPicture.ToString();
                }
            }
            catch
            {
                return "~/Pages/P-Art/Images/noImage.gif";
            }
        }
        public bool IsSelection(string newsId)
        {

            return false;

#pragma warning disable CS0162 // Unreachable code detected
            if (Session["NewsSelection"] == null)
#pragma warning restore CS0162 // Unreachable code detected
            {
                return true;

            }


            if (Session["NewsSelection"].ToString().IndexOf("," + newsId.ToString() + ",") > -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected void FilterGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public bool CanRemoveNews()
        {
            return (bool)HttpContext.Current.Session["IsAdmin"];

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
        private void LoadGroups(List<Tbl_News_Type> dt)
        {





            Class_Keywords _cls = new Class_Keywords();
            //Class_NewsGroup _cls = new Class_NewsGroup();
            var keyWords = keywordList.GroupBy(t => t.KeyId).Select(g => g.First()).ToList().Where(t => dt.Any(n => n.KeywordId == t.KeyId)).ToList();

            var parminIds = UserPanelList;// (Class_Layer.UserPanels());


            rpt_Groups.DataSource = keyWords;
            rpt_Groups.DataBind();


            // var allkeyWords = _cls.GetRssKeywordByPanelIds(parminIds);

            var keyGroups = keywordList.GroupBy(k => k.GroupName).Select(k => k.FirstOrDefault()).OrderBy(k => k.GroupOrder).ToList();



            rptGroupNewKeyword.DataSource = keyGroups;
            rptGroupNewKeyword.DataBind();



            rbtGroups.Items.Clear();
            foreach (var item in keyGroups)
            {
                if (string.IsNullOrWhiteSpace(item.GroupName)) continue;

                rbtGroups.Items.Add(new ListItem()
                {
                    Text = "(" + item.GroupOrder + ")" + item.GroupName,
                    Value = item.GroupOrder + ""
                });
            }

            //rbtGroups.DataSource = keyWords.GroupBy(k => k.GroupName).Select(k => k.FirstOrDefault()).OrderBy(k => k.GroupOrder).ToList();
            //rbtGroups.DataBind();

            //keywordGroupList = keyWords.GroupBy(k => k.GroupName).Select(k => k.FirstOrDefault()).OrderBy(k => k.GroupOrder).Where(k => k.Active == true);
        }
        protected void rpt_Groups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlGenericControl _div = e.Item.FindControl("group_item") as HtmlGenericControl;
            if (_div == null) return;

            HtmlGenericControl color_span = e.Item.FindControl("color_span") as HtmlGenericControl;

            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            color_span.Style.Add("background-color", fld_color.Value.Trim());



        }
        private void LoadNewsSource()
        {
            drp_NewsSource.Items.Clear();
            ListItem newItem = new ListItem();
            newItem.Text = "کلیه منابع";
            newItem.Value = "0";

            drp_NewsSource.Items.Add(newItem);

            newItem = new ListItem();
            newItem.Text = "کلیه خبرگزاری ها";
            newItem.Value = "-1";
            drp_NewsSource.Items.Add(newItem);

            newItem = new ListItem();
            newItem.Text = "کلیه روزنامه ها";
            newItem.Value = "-2";
            drp_NewsSource.Items.Add(newItem);


            Class_Sites _clsSite = new Class_Sites();
            Class_Ado _clsAdo = new Class_Ado();

            string panels = Class_Layer.CurrentUser().ParminIds;
            string sites = "";
            DataTable dt = _clsAdo.FillDataTable("select * from tbl_parmin where parminId in(" + panels + ")");
            foreach (DataRow row in dt.Rows)
            {
                if (row["Sites"].ToString() != "")
                {
                    sites += "," + row["Sites"].ToString();
                }
            }
            if (sites != "")
            {
                sites = sites.Substring(1, sites.Length - 1);
            }

            List<int> siteIds = new List<int>();
            foreach (string site in sites.Split(','))
            {
                if (site == "") continue;
                siteIds.Add(int.Parse(site));
            }

            var result = _clsSite.GetSiteByIds(siteIds);
            //modal sorting
            rptSiteSort.DataSource = result;
            rptSiteSort.DataBind();
            foreach (var item in result)
            {
                newItem = new ListItem();
                newItem.Text = item.SiteTitle.Trim();
                newItem.Value = item.SiteID.ToString();
                drp_NewsSource.Items.Add(newItem);
            }

        }

        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {


            string url = "";

            if (txt_fromDate.Text != "")
            {
                url = "fromDate=" + txt_fromDate.Text.Replace("/", "") + "&";
            }
            if (txt_toDate.Text != "")
            {
                url += "toDate=" + txt_toDate.Text.Replace("/", "") + "&";
            }
            if (drp_NewsSource.SelectedItem.Value != "0")
            {
                url += "SiteId=" + drp_NewsSource.SelectedItem.Value + "&";
            }
            if (txt_search.Text.Trim() != "")
            {
                url += "keyword=" + Server.HtmlEncode(txt_search.Text.Trim().Replace("+", "|")) + "&";
            }
            if (txt_fromHour.Text != "" && txt_toHour.Text != "")
            {
                url += "ftime=" + Server.HtmlEncode(txt_fromHour.Text.Trim().Replace(":", "-")) + "&";
                url += "ttime=" + Server.HtmlEncode(txt_toHour.Text.Trim().Replace(":", "-")) + "&";
            }
            url += "recordCount=10000000" + "&";
            //if (txt_fromHour.Text != "00:00")
            //{
            //    url += "fromtimezone=" + txt_fromHour.Text + "&";
            //}
            //if (txt_toHour.Text != "00:00")
            //{
            //    url += "totimezone=" + txt_toHour.Text + "&";
            //}
            url = url.Substring(0, url.Length - 1);

            //Response.Redirect("/NewsList/?" + url);
            Response.Redirect("/Pages/P-Art/Pages/BultanNews.aspx?bultanarchive=" + hdfBultnArchiveID.Value.ToString() +
                "&" + url);


        }
        protected void btn_PrintLead_Click(object sender, EventArgs e)
        {
            var ids = "";



            foreach (RepeaterItem row in news_list.Items)
            {
                CheckBox check_SelectNews = (CheckBox)row.FindControl("check_SelectNews");
                HiddenField fld_newsId = (HiddenField)row.FindControl("fld_newsId");

                if (check_SelectNews.Checked == false) continue;

                ids += fld_newsId.Value + ",";


            }
            if (ids == "") return;
            ids = ids.Substring(0, ids.Length - 1);
            ReportBuilder.SepaarReport rpt = new ReportBuilder.SepaarReport();
            List<string> st = new List<string>();

            rpt.AllowJarayed = false;
            rpt.AllowKeys = false;
            rpt.AllowKhabarGozari = true;
            rpt.AllowNewsSource = false;
            rpt.AllowNimta = false;
            rpt.AllowPeople = false;
            rpt.AllowRelate = false;
            rpt.AllowTV = false;

            rpt.BultanId = 50;
            rpt.NewsIds = ids;
            rpt.pageIndexChart1 = -1;
            rpt.pageIndexChart2 = -1;
            rpt.pageIndexChart3 = -1;
            rpt.pageIndexJarayed = 2;
            rpt.pageIndexKeys = -1;
            rpt.pageIndexKhabarGozari = 3;
            rpt.pageIndexList = 1;
            rpt.pageIndexNimta = -1;
            rpt.pageIndexPeople = -1;
            rpt.pageIndexTV = -1;

            st.Clear();
            rpt.ReportPath = @"C:\BultanForms\printlead.frx";
            string fid = Guid.NewGuid().ToString();
            rpt.FileName = fid + ".pdf";
            rpt.FileName = HttpContext.Current.Server.MapPath("~") + "Pages\\P-Art\\Pages\\Pdf\\" + rpt.FileName;
            st.Add(rpt.FileName);
            rpt.DateFrom = long.Parse(txt_fromDate.Text.Replace("/", ""));
            rpt.DateTo = long.Parse(txt_toDate.Text.Replace("/", ""));
            rpt.ExportPaths = st;
            rpt.AllowSplitNews = false;
            bool result = rpt.GenerateReport();


            Response.Redirect("/Pages/P-Art/Pages/Pdf/" + fid + ".pdf");

            return;

#pragma warning disable CS0162 // Unreachable code detected
            Session["tempSelection"] = ids.Substring(0, ids.Length - 1);
#pragma warning restore CS0162 // Unreachable code detected
            Response.Redirect("~/print/?tag=printLead");
        }
        protected void btn_printTitle_Click(object sender, EventArgs e)
        {
            var ids = "";

            foreach (RepeaterItem row in news_list.Items)
            {
                CheckBox check_SelectNews = (CheckBox)row.FindControl("check_SelectNews");
                HiddenField fld_newsId = (HiddenField)row.FindControl("fld_newsId");

                if (check_SelectNews.Checked == false) continue;

                ids += fld_newsId.Value + ",";


            }
            Session["tempSelection"] = ids.Substring(0, ids.Length - 1);
            Response.Redirect("~/print/?tag=printTitle");
        }
        public override void VerifyRenderingInServerForm(Control control)
        {


        }
        protected void btn_exportWord_Click(object sender, EventArgs e)
        {
            var ids = "";

            foreach (RepeaterItem row in news_list.Items)
            {
                CheckBox check_SelectNews = (CheckBox)row.FindControl("check_SelectNews");
                HiddenField fld_newsId = (HiddenField)row.FindControl("fld_newsId");

                if (check_SelectNews.Checked == false) continue;

                ids += fld_newsId.Value + ",";


            }


            Class_News _cls = new Class_News();

            ids = ids.Substring(0, ids.Length - 1);

            var db = _cls.GetAllNewsByIds(ids);

            //foreach(DataRow dr in db.Rows)
            //{
            //    dr["NewsTitle"]=Class_Static.RemoveScriptsTags(dr["NewsTitle"]);
            //    RemoveScriptsTags
            //}
            grd_word.DataSource = db;
            grd_word.AllowPaging = false;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=ReportNews.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd_word.DataBind();
            grd_word.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        public string mirrorDate(string NewsDate)
        {
            var date = NewsDate.Split('/');

            var result = date[2] + "/" + date[1] + "/" + date[0];
            return result;
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
        private void LoadTemplate()
        {
            Class_Panels _cls = new Class_Panels();
            List<int> ids = new List<int>();
            ListItem newItem = new ListItem();
            var parmin = _cls.GetParminById(int.Parse(UserPanelList[0].Value.ToString()));
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
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            try
            {
                Class_Ado _cls = new Class_Ado();
                _cls.ExecuteCommand("update tbl_news set IsSelected = null,SortOrder=null where newsid in (select newsid from Tbl_Relation_NewsParminPanel where ParminPanelId = " + Class_Layer.UserPanels()[0] + " and NewsDateIndex between " + txt_fromDate.Text.Replace("/", "") + " and " + txt_toDate.Text.Replace("/", "") + ")");
            }
            catch { }

            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var currentUser = Class_Layer.CurrentUser();
            db.Database.ExecuteSqlCommand("update Tbl_AgenceMembers set SavedNewsIds='' where MemberID=" + currentUser.MemberID);
            db.Database.ExecuteSqlCommand("update Tbl_AgenceMembers set SavedOrderIds='' where MemberID=" + currentUser.MemberID);

        }
        protected void btn_db_Click(object sender, EventArgs e)
        {
            string newdbFile = Server.MapPath("~/dbExport") + "\\" + Guid.NewGuid().ToString() + ".hdf";
            System.IO.File.Copy(Server.MapPath("~/dbExport") + "\\dbNews.mdb", newdbFile);

            OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + newdbFile);
            cnn.Open();
            string newsId = "";
            foreach (RepeaterItem news in news_list.Items)
            {
                CheckBox check = news.FindControl("check_SelectNews") as CheckBox;
                if (check.Checked == true)
                {
                    HiddenField fld = news.FindControl("fld_newsId") as HiddenField;
                    newsId += fld.Value + ",";
                }
            }

            if (newsId == "") return;
            newsId = newsId.Substring(0, newsId.Length - 1);

            Class_News _cls = new Class_News();

            DataTable result = _cls.GetAllNewsByIds(newsId);

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "delete from tbl_news";
            cmd.ExecuteNonQuery();

            foreach (DataRow news in result.Rows)
            {
                cmd.CommandText = "insert into Tbl_News (NewsId,SiteId,KeywordId,SiteType,SiteTitle,Newstitle,NewsLead,NewsBody,NewsDateIndex,NewsDate,NewsTime,NewsPicture,NewsLink,NewsPosition,NewsValue) values " +
                                                       "(@NewsId,@SiteId,@KeywordId,@SiteType,@SiteTitle,@Newstitle,@NewsLead,@NewsBody,@NewsDateIndex,@NewsDate,@NewsTime,@NewsPicture,@NewsLink,@NewsPosition,@NewsValue)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("NewsId", OleDbType.Numeric).Value = news["NewsId"].ToString();
                cmd.Parameters.Add("SiteId", OleDbType.Numeric).Value = news["SiteId"].ToString();
                cmd.Parameters.Add("KeywordId", OleDbType.Numeric).Value = news["KeywordId"].ToString();

                cmd.Parameters.Add("Sitetype", OleDbType.Numeric).Value = news["SiteType"].ToString();
                cmd.Parameters.Add("SiteTitle", OleDbType.VarChar).Value = news["SiteTitle"].ToString();
                cmd.Parameters.Add("Newstitle", OleDbType.VarChar).Value = news["NewsTitle"].ToString();
                cmd.Parameters.Add("NewsLead", OleDbType.VarChar).Value = news["NewsLead"].ToString();
                cmd.Parameters.Add("NewsBody", OleDbType.VarChar).Value = news["NewsBody"].ToString();
                cmd.Parameters.Add("NewsDateIndex", OleDbType.Numeric).Value = news["NewsDateIndex"].ToString();
                cmd.Parameters.Add("NewsDate", OleDbType.VarChar).Value = news["NewsDate"].ToString();
                cmd.Parameters.Add("NewsTime", OleDbType.VarChar).Value = news["NewsTime"].ToString();
                cmd.Parameters.Add("NewsPicture", OleDbType.VarChar).Value = news["NewsPicture"].ToString();
                cmd.Parameters.Add("NewsLink", OleDbType.VarChar).Value = news["NewsLink"].ToString();

                if (news["NewsPosition"].ToString() == "")
                {
                    cmd.Parameters.Add("NewsPosition", OleDbType.Numeric).Value = DBNull.Value;
                }
                else
                {


                    cmd.Parameters.Add("NewsPosition", OleDbType.Numeric).Value = news["NewsPosition"].ToString();
                }
                if (news["NewsValue"].ToString() == "")
                {
                    cmd.Parameters.Add("NewsValue", OleDbType.Numeric).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("NewsValue", OleDbType.Numeric).Value = news["NewsValue"].ToString();
                }

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
#pragma warning disable CS0219 // The variable 'error' is assigned but its value is never used
                    int error = 0;
#pragma warning restore CS0219 // The variable 'error' is assigned but its value is never used
                }



            }
            cnn.Close();
            Response.Redirect("/dbExport/" + System.IO.Path.GetFileName(newdbFile));
        }
        protected void btn_saveState_Click(object sender, EventArgs e)
        {

            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var userSelectedNews = "";
            var userOrderedNews = "";
            var currentUser = Class_Layer.CurrentUser();

            foreach (RepeaterItem item in news_list.Items)
            {
                try
                {


                    CheckBox check = item.FindControl("check_SelectNews") as CheckBox;
                    TextBox txt = item.FindControl("txt_row_index") as TextBox;
                    HiddenField fld = item.FindControl("fld_newsId") as HiddenField;

                    if (!string.IsNullOrWhiteSpace(txt.Text))
                    {
                        userOrderedNews += "," + fld.Value + ":" + txt.Text + ",";
                    }
                    if (check.Checked == true)
                    {
                        if (txt == null || string.IsNullOrWhiteSpace(txt.Text))
                        {
                            //   db.Database.ExecuteSqlCommand("update tbl_news set SortOrder=" + txt.Text + " where NewsId=" + fld.Value);

                        }
                        else
                        {
                            db.Database.ExecuteSqlCommand("update tbl_news set SortOrder=" + txt.Text + " where NewsId=" + fld.Value);

                        }
                        // db.Database.ExecuteSqlCommand("update tbl_news set IsSelected=1 where NewsId=" + fld.Value);
                        userSelectedNews += "," + fld.Value + ",";


                    }
                    else
                    {
                        db.Database.ExecuteSqlCommand("update tbl_news set SortOrder = null where NewsId=" + fld.Value);
                        //  db.Database.ExecuteSqlCommand("update tbl_news set IsSelected = 0 where NewsId=" + fld.Value);
                    }


                }
                catch
                {
                    continue;
                }
            }

            db.Database.ExecuteSqlCommand("update Tbl_AgenceMembers set SavedNewsIds = '" + currentUser.SavedNewsIds + userSelectedNews + "' where MemberID=" + currentUser.MemberID);
            db.Database.ExecuteSqlCommand("update Tbl_AgenceMembers set SavedOrderIds = '" + currentUser.SavedOrderIds + userOrderedNews + "' where MemberID=" + currentUser.MemberID);
            //set user session

            if (currentUser.SavedNewsIds != userSelectedNews)
            {
                Tbl_AgenceMembers CurrentUserNew = new Tbl_AgenceMembers();
                Class_User _cls_User = new Class_User();
                CurrentUserNew = _cls_User.SelectSingle(currentUser.MemberID);
                Session["CurrentUser"] = CurrentUserNew;
            }
        }
        protected void grd_word_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //for (int i = 0; i < e.Row.Cells.Count; i++)
            //{
            //    e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
            //}
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Literal txtTitle = (Literal)e.Row.FindControl("ltTitle");
                    Literal txtLead = (Literal)e.Row.FindControl("ltLead");
                    try
                    {
                        Literal txtBody = (Literal)e.Row.FindControl("ltBody");
                        txtBody.Text = Class_Static.RemoveScriptsTags(txtBody.Text);
                    }
                    catch
                    {

                    }

                    txtTitle.Text = Class_Static.RemoveScriptsTags(txtTitle.Text);
                    txtLead.Text = Class_Static.RemoveScriptsTags(txtLead.Text);


                    //string result = string.Empty;
                    //for (int i = 0; i < txtTitle.Text.Length; i++)
                    //{
                    //    result += (i % 140 == 0 && i != 0) ? (txtTitle.Text[i].ToString() + "<br/>") : txtTitle.Text[i].ToString();
                    //}
                    //txtTitle.Text = result;




                    //result = string.Empty;
                    //for (int i = 0; i < txtLead.Text.Length; i++)
                    //{
                    //    result += (i % 140 == 0 && i != 0) ? (txtLead.Text[i].ToString() + "<br/>") : txtLead.Text[i].ToString();
                    //}
                    //txtLead.Text = result;



                    //result = string.Empty;
                    //for (int i = 0; i < txtBody.Text.Length; i++)
                    //{
                    //    result += (i % 140 == 0 && i != 0) ? (txtBody.Text[i].ToString() + "<br/>") : txtBody.Text[i].ToString();
                    //}
                    //txtBody.Text = result;
                }
                catch
                {

                }
                //Find dropdown control & get values
                //  e.Row.Cells[0].Text = Class_Static.RemoveScriptsTags(e.Row.Cells[0].Text);

            }
        }
        protected void btn_exportWordShort_Click(object sender, EventArgs e)
        {
            var ids = "";

            foreach (RepeaterItem row in news_list.Items)
            {
                CheckBox check_SelectNews = (CheckBox)row.FindControl("check_SelectNews");
                HiddenField fld_newsId = (HiddenField)row.FindControl("fld_newsId");

                if (check_SelectNews.Checked == false) continue;

                ids += fld_newsId.Value + ",";


            }


            Class_News _cls = new Class_News();

            ids = ids.Substring(0, ids.Length - 1);

            var db = _cls.GetAllNewsByIds(ids);

            //foreach(DataRow dr in db.Rows)
            //{
            //    dr["NewsTitle"]=Class_Static.RemoveScriptsTags(dr["NewsTitle"]);
            //    RemoveScriptsTags
            //}
            grd_word_short.DataSource = db;
            grd_word_short.AllowPaging = false;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=ReportNews.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd_word_short.DataBind();
            grd_word_short.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void btnGetNewsDB_Click(object sender, EventArgs e)
        {
            // return;
            string strSearch = "";

            DataTable result = new DataTable();
            int fromDate = int.Parse(txt_fromDate.Text.Replace("/", ""));
            int toDate = int.Parse(txt_toDate.Text.Replace("/", ""));
            int siteId = 0;
#pragma warning disable CS0219 // The variable 'time' is assigned but its value is never used
            int time = 0;
#pragma warning restore CS0219 // The variable 'time' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'fromTimeZone' is assigned but its value is never used
            string fromTimeZone = "";
#pragma warning restore CS0219 // The variable 'fromTimeZone' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'toTimeZone' is assigned but its value is never used
            string toTimeZone = "";
#pragma warning restore CS0219 // The variable 'toTimeZone' is assigned but its value is never used

            string newsIds = "";



            RecordCount = 10000000;

            //if (Request.QueryString["fromtimezone"] != null)
            //{
            //    fromTimeZone = Request.QueryString["fromtimezone"].ToString();
            //    txt_fromHour.Text = fromTimeZone;
            //    toTimeZone = Request.QueryString["totimezone"].ToString();
            //    txt_toHour.Text = toTimeZone;

            //    DateTime fDate = _clsZm.ShamsiToMiladi(txt_fromDate.Text);
            //    DateTime tDate = _clsZm.ShamsiToMiladi(txt_toDate.Text);

            //    string AMPM = "AM";
            //    if (int.Parse(txt_fromHour.Text.Split(':')[0]) > 12)
            //    {
            //        AMPM = "PM";
            //    }
            //    else
            //    {
            //        AMPM = "AM";
            //    }
            //    fDate = DateTime.Parse(fDate.Year + "/" + fDate.Month + "/" + fDate.Day + " " + txt_fromHour.Text + " " + AMPM);
            //    if (int.Parse(txt_toHour.Text.Split(':')[0]) > 12)
            //    {
            //        AMPM = "PM";
            //    }
            //    else
            //    {
            //        AMPM = "AM";
            //    }
            //    tDate = DateTime.Parse(tDate.Year + "/" + tDate.Month + "/" + tDate.Day + " " + txt_toHour.Text + " " + AMPM);
            //    int minutes = int.Parse((tDate - fDate).TotalMinutes.ToString());

            //    time = minutes;

            //}

            if (drp_NewsSource.SelectedValue == "-1")
            {
                siteId = -1;
            }
            else if (drp_NewsSource.SelectedValue == "-2")
            {
                siteId = -2;
            }

            if (Request.QueryString["bultanarchive"] != null)
            {
                Class_BultanArchive _clsBultan = new Class_BultanArchive();
                var archive = _clsBultan.GetBultanById(int.Parse(Request.QueryString["bultanarchive"]));
                if (archive != null)
                {
                    if (archive.SelectedNews != null)
                    {
                        if (archive.SelectedNews != "")
                        {
                            newsIds = archive.SelectedNews;
                        }
                    }
                }
            }
            result = _clsNews.GetAllNewsDataTable(RecordCount, 1, Class_Layer.UserPanels(), false, true, Class_Layer.UserHighlight(), fromDate, toDate, strSearch, siteId, false, "", "", newsIds, "", false);


            if (drp_sort.SelectedValue == "1")
            {
                result.DefaultView.Sort = "NewsId desc";
            }


            var lstDuplicateCRC = new List<long>();


            var lstDic = new Dictionary<string, int>();
            var dataRowList = new List<DataRow>();
            var dtNew = result.Copy();
            dtNew.Rows.Clear();
            var index = 0;
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
                    dtNew.Rows.Add(dr.ItemArray);
                    //  }




                    index++;

                }
                catch
                {

                    index++;
                    continue;
                }
            }

            string newdbFile = Server.MapPath("~/dbExport") + "\\" + Guid.NewGuid().ToString() + ".hdf";
            System.IO.File.Copy(Server.MapPath("~/dbExport") + "\\dbNews.mdb", newdbFile);

            OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + newdbFile);
            cnn.Open();


            Class_News _cls = new Class_News();

            //   DataTable result = _cls.GetAllNewsByIds(newsId);

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "delete from tbl_news";
            cmd.ExecuteNonQuery();

            foreach (DataRow news in dtNew.Rows)
            {
                cmd.CommandText = "insert into Tbl_News (NewsId,SiteId,KeywordId,SiteType,SiteTitle,Newstitle,NewsLead,NewsBody,NewsDateIndex,NewsDate,NewsTime,NewsPicture,NewsLink,NewsPosition,NewsValue) values " +
                                                       "(@NewsId,@SiteId,@KeywordId,@SiteType,@SiteTitle,@Newstitle,@NewsLead,@NewsBody,@NewsDateIndex,@NewsDate,@NewsTime,@NewsPicture,@NewsLink,@NewsPosition,@NewsValue)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("NewsId", OleDbType.Numeric).Value = news["NewsId"].ToString();
                cmd.Parameters.Add("SiteId", OleDbType.Numeric).Value = news["SiteId"].ToString();
                cmd.Parameters.Add("KeywordId", OleDbType.Numeric).Value = news["KeywordId"].ToString();

                cmd.Parameters.Add("Sitetype", OleDbType.Numeric).Value = news["SiteType"].ToString();
                cmd.Parameters.Add("SiteTitle", OleDbType.VarChar).Value = news["SiteTitle"].ToString();
                cmd.Parameters.Add("Newstitle", OleDbType.VarChar).Value = news["NewsTitle"].ToString();
                cmd.Parameters.Add("NewsLead", OleDbType.VarChar).Value = news["NewsLead"].ToString();
                cmd.Parameters.Add("NewsBody", OleDbType.VarChar).Value = news["NewsBody"].ToString();
                cmd.Parameters.Add("NewsDateIndex", OleDbType.Numeric).Value = news["NewsDateIndex"].ToString();
                cmd.Parameters.Add("NewsDate", OleDbType.VarChar).Value = news["NewsDate"].ToString();
                cmd.Parameters.Add("NewsTime", OleDbType.VarChar).Value = news["NewsTime"].ToString();
                cmd.Parameters.Add("NewsPicture", OleDbType.VarChar).Value = news["NewsPicture"].ToString();
                cmd.Parameters.Add("NewsLink", OleDbType.VarChar).Value = news["NewsLink"].ToString();

                if (news["NewsPosition"].ToString() == "")
                {
                    cmd.Parameters.Add("NewsPosition", OleDbType.Numeric).Value = DBNull.Value;
                }
                else
                {


                    cmd.Parameters.Add("NewsPosition", OleDbType.Numeric).Value = news["NewsPosition"].ToString();
                }
                if (news["NewsValue"].ToString() == "")
                {
                    cmd.Parameters.Add("NewsValue", OleDbType.Numeric).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("NewsValue", OleDbType.Numeric).Value = news["NewsValue"].ToString();
                }

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
#pragma warning disable CS0219 // The variable 'error' is assigned but its value is never used
                    int error = 0;
#pragma warning restore CS0219 // The variable 'error' is assigned but its value is never used
                }



            }
            cnn.Close();
            Response.Redirect("/dbExport/" + System.IO.Path.GetFileName(newdbFile));
        }
        public static string CheckIsNewsFeed(object isNewsFeeder)
        {
            if (string.IsNullOrWhiteSpace(isNewsFeeder + ""))
            {
                return "";
            }
            if ((isNewsFeeder + "").ToLower() == "true")
            {
                return "<span class='feederNews'>غیر رسمی</span>";
            }
            return "";
        }
        protected void btn_exportWordTitr_Click(object sender, EventArgs e)
        {
            var ids = "";

            foreach (RepeaterItem row in news_list.Items)
            {
                CheckBox check_SelectNews = (CheckBox)row.FindControl("check_SelectNews");
                HiddenField fld_newsId = (HiddenField)row.FindControl("fld_newsId");

                if (check_SelectNews.Checked == false) continue;

                ids += fld_newsId.Value + ",";


            }


            Class_News _cls = new Class_News();

            ids = ids.Substring(0, ids.Length - 1);

            var db = _cls.GetAllNewsByIds(ids);

            //foreach(DataRow dr in db.Rows)
            //{
            //    dr["NewsTitle"]=Class_Static.RemoveScriptsTags(dr["NewsTitle"]);
            //    RemoveScriptsTags
            //}
            grv_word_titr.DataSource = db;
            grv_word_titr.AllowPaging = false;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=ReportNews.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grv_word_titr.DataBind();
            grv_word_titr.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }


        private void LoadData(int siteType)
        {

            // return;
            string strSearch = "";

            DataTable result = new DataTable();
            int fromDate = int.Parse(_clsZm.Today().Replace("/", ""));
            int toDate = fromDate;
            int siteId = 0;
            int time = 0;
#pragma warning disable CS0219 // The variable 'fromTimeZone' is assigned but its value is never used
            string fromTimeZone = "";
#pragma warning restore CS0219 // The variable 'fromTimeZone' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'toTimeZone' is assigned but its value is never used
            string toTimeZone = "";
#pragma warning restore CS0219 // The variable 'toTimeZone' is assigned but its value is never used


            string newsIds = "";
            if (Request.QueryString["ftime"] != null)
            {
                txt_fromHour.Text = Request.QueryString["ftime"].ToString().Replace("-", ":");
            }
            if (Request.QueryString["ttime"] != null)
            {
                txt_toHour.Text = Request.QueryString["ttime"].ToString().Replace("-", ":");
            }
            if (Request.QueryString["FromDate"] != null)
            {
                fromDate = int.Parse(Request.QueryString["FromDate"].ToString());
                txt_fromDate.Text = fromDate.ToString().Substring(0, 4) + "/" + fromDate.ToString().Substring(4, 2) + "/" + fromDate.ToString().Substring(6, 2);
            }
            else
            {
                txt_fromDate.Text = _clsZm.Today();
            }
            if (Request.QueryString["ToDate"] != null)
            {
                toDate = int.Parse(Request.QueryString["ToDate"].ToString());
                txt_toDate.Text = toDate.ToString().Substring(0, 4) + "/" + toDate.ToString().Substring(4, 2) + "/" + toDate.ToString().Substring(6, 2);

            }
            else
            {
                txt_toDate.Text = _clsZm.Today();

            }

            if (Request.QueryString["SiteId"] != null)
            {
                siteId = int.Parse(Request.QueryString["SiteId"].ToString());
                drp_NewsSource.SelectedValue = siteId.ToString();
            }
            if (Request.QueryString["time"] != null)
            {
                time = int.Parse(Request.QueryString["time"].ToString());

            }
            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                txt_search.Text = strSearch.Replace("|", "+");

            }
            if (Request.QueryString["recordcount"] != null)
            {
                RecordCount = int.Parse(Server.HtmlDecode(Request.QueryString["recordcount"].ToString()));
            }

            if (drp_NewsSource.SelectedValue == "-1")
            {
                siteId = -1;
            }
            else if (drp_NewsSource.SelectedValue == "-2")
            {
                siteId = -2;
            }
            Class_Keywords _clsKeyword = new Class_Keywords();
            var keywords = new List<Tbl_RssKeywords>();
            keywords = _clsKeyword.GetRssKeywordByPanelIds(Class_Layer.UserPanels());
            keywordList = keywords;

            if (Request.QueryString["bultanarchive"] != null)
            {
                Class_BultanArchive _clsBultan = new Class_BultanArchive();
                var archive = _clsBultan.GetBultanById(int.Parse(Request.QueryString["bultanarchive"]));

                if (archive != null)
                {
                    if (archive.SelectedNews != null)
                    {
                        if (archive.SelectedNews != "")
                        {
                            var link = archive.Path;
                            if (link.ToLower().Contains("http://"))
                            {
                                try
                                {
                                    Uri myUri = new Uri(link);
                                    if (string.IsNullOrWhiteSpace(HttpUtility.ParseQueryString(myUri.Query).Get("fromDate")))
                                    {
                                        try
                                        {
                                            txt_fromDate.Text = Class_Static.ShamisiBySlash(archive.FromDateIndex);
                                            fromDate = Convert.ToInt32(Class_Static.ShamisiWithoutSlash(archive.FromDateIndex));

                                            txt_toDate.Text = Class_Static.ShamisiBySlash(archive.ToDateIndex);
                                            toDate = Convert.ToInt32(Class_Static.ShamisiWithoutSlash(archive.ToDateIndex));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else
                                    {
                                        txt_fromDate.Text = HttpUtility.ParseQueryString(myUri.Query).Get("fromDate");
                                        fromDate = Convert.ToInt32(txt_fromDate.Text.Replace("/", ""));

                                        txt_toDate.Text = HttpUtility.ParseQueryString(myUri.Query).Get("toDate");
                                        toDate = Convert.ToInt32(txt_toDate.Text.Replace("/", ""));
                                    }
                                }
                                catch
                                {

                                }

                            }

                            hdfBultnArchiveID.Value = archive.ArchiveId + "";
                            //  newsIds = archive.SelectedNews;
                            hdfSelectedBultanNews.Value = archive.SelectedNews;
                        }
                    }
                }
            }
            result = _clsNews.GetAllNewsDataTable(RecordCount, 1, Class_Layer.UserPanels(), false, true, Class_Layer.UserHighlight(),
                fromDate, toDate, strSearch, siteId, false, txt_fromHour.Text, txt_toHour.Text, newsIds, "", false);


            if (drp_sort.SelectedValue == "1")
            {
                result.DefaultView.Sort = "NewsId desc";
            }


            var lstDuplicateCRC = new List<long>();
            var lstDic = new Dictionary<string, int>();
            var dataRowList = new List<DataRow>();
            var dtNew = result.Copy();
            dtNew.Rows.Clear();
            var index = 0;
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
                    dtNew.Rows.Add(dr.ItemArray);


                    index++;
                }
                catch
                {

                    index++;
                    continue;
                }
            }

            List<Tbl_News_Type> newsList = GetFromDataRows(dtNew.Select());
            //if (UserPanelList.Contains(771))
            //    GroupNewsList = newsList.OrderBy(d => d.NewsDateIndex).ThenBy(d => d.NewsTime).ToList();
            //else
            GroupNewsList = Class_Static.GenerateNewsTags(newsList, UserPanelList).OrderBy(d => d.NewsDateIndex).ThenBy(d => d.NewsTime).ToList();
            Session.Add("GroupNewsList", GroupNewsList);


            //news_list.DataSource = GroupNewsList;
            //news_list.DataBind();

            //var relatedList = Class_Static.LoadRelatedNews(GroupNewsList);
            //rptRelatedNews_list.DataSource = relatedList;
            //rptRelatedNews_list.DataBind();

            // rptMostRelatedNews_list.DataSource = relatedList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
            //rptMostRelatedNews_list.DataBind();



            if (GroupNewsList.Count == 0)
            {
                Session["LastNewsId"] = "0";
            }
            else
            {

                Session["LastNewsId"] = GroupNewsList.FirstOrDefault().NewsID;
            }


            LoadGroups(GroupNewsList);
        }


        protected void rptRelatedNews_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (GroupNewsList == null || GroupNewsList.Count == 0)
            {
                GroupNewsList = (List<Tbl_News_Type>)Session["GroupNewsList"];

            }
            //return;
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;
            Tbl_News_Type newsData = (Tbl_News_Type)e.Item.DataItem;
            Repeater relatedNews = e.Item.FindControl("relatedNews") as Repeater;
            if (newsData.RelateListIds != null)
            {
                relatedNews.DataSource = GroupNewsList.Where(i => newsData.RelateListIds.Contains(i.NewsID)).ToList();
                relatedNews.DataBind();
            }
            //relatedNews.ItemDataBound += RelatedNews_ItemDataBound;
            // var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                //var news = _clsNews.GetNewsById(Convert.ToInt32(fld_newsId.Value), false);
                var res = GenerateTags(keywordList, newsData.NewsDateIndex + "", newsData.KeyIds);
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }

            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;


            PlaceHolder pc_DelNews = e.Item.FindControl("pc_DelNews") as PlaceHolder;

            TextBox txtOrder = e.Item.FindControl("txt_row_index") as TextBox;

            var currentUser = Class_Layer.CurrentUser();

            if (currentUser.AllowSaveNews == false)
            {
                check.Checked = false;
            }
            else if (currentUser.SavedNewsIds != null && currentUser.SavedNewsIds.Contains("," + fld_newsId.Value + ","))
            {
                check.Checked = true;
            }
            else
            {
                check.Checked = false;
            }
            if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            {
                pc_DelNews.Visible = true;


            }
            else
            {
                pc_DelNews.Visible = false;
            }



            // news Index
            try
            {

                if (!string.IsNullOrWhiteSpace(currentUser.SavedOrderIds))
                {
                    var orderIndex = currentUser.SavedOrderIds.IndexOf("," + fld_newsId.Value + ":");
                    if (orderIndex > -1)
                    {
                        var orderIndex2 = currentUser.SavedOrderIds.Substring(orderIndex + 1).IndexOf(",");
                        txtOrder.Text = currentUser.SavedOrderIds.Substring(orderIndex + 1, orderIndex2).Split(':')[1];
                    }
                    else
                    {
                        txtOrder.Text = "";
                    }
                }
                else
                {
                    txtOrder.Text = "";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            _div.Style.Add("background-color", fld_color.Value.Trim());
        }
        protected void news_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;
            Tbl_News_Type newsData = (Tbl_News_Type)e.Item.DataItem;

            //var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                //var news = _clsNews.GetNewsById(Convert.ToInt32(fld_newsId.Value), false);
                //  var res = GenerateTags(keywordList, newsData.NewsTitle, newsData.NewsLead, newsData.NewsBody, newsData.KeywordId, newsData.NewsDateIndex, newsData.CreateUser);
                var res = GenerateTags(keywordList, newsData.NewsDateIndex + "", newsData.KeyIds);
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }

            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;


            PlaceHolder pc_DelNews = e.Item.FindControl("pc_DelNews") as PlaceHolder;

            TextBox txtOrder = e.Item.FindControl("txt_row_index") as TextBox;

            var currentUser = Class_Layer.CurrentUser();

            if (currentUser.AllowSaveNews == false)
            {
                check.Checked = false;
            }
            else if (currentUser.SavedNewsIds != null && currentUser.SavedNewsIds.Contains("," + fld_newsId.Value + ","))
            {
                check.Checked = true;
            }
            else
            {
                check.Checked = false;
            }
            if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            {
                pc_DelNews.Visible = true;


            }
            else
            {
                pc_DelNews.Visible = false;
            }



            // news Index
            try
            {

                if (!string.IsNullOrWhiteSpace(currentUser.SavedOrderIds))
                {
                    var orderIndex = currentUser.SavedOrderIds.IndexOf("," + fld_newsId.Value + ":");
                    if (orderIndex > -1)
                    {
                        var orderIndex2 = currentUser.SavedOrderIds.Substring(orderIndex + 1).IndexOf(",");
                        txtOrder.Text = currentUser.SavedOrderIds.Substring(orderIndex + 1, orderIndex2).Split(':')[1];
                    }
                    else
                    {
                        txtOrder.Text = "";
                    }
                }
                else
                {
                    txtOrder.Text = "";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }



            //if (fld_isSelected.Value == "True")
            //{
            //    check.Checked = true;
            //}
            //else
            //{
            //check.Checked = false;
            //}
            //  ClientScript.RegisterStartupScript(GetType(), "retrieveRelatedData", "retrieveRelatedData(" + fld_newsId + "," + allNewsList + ");", true);

            _div.Style.Add("background-color", fld_color.Value.Trim());
        }
        protected void rptMostRelatedNews_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (GroupNewsList == null || GroupNewsList.Count == 0)
            {
                GroupNewsList = (List<Tbl_News_Type>)Session["GroupNewsList"];

            }
            //return;
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;
            Tbl_News_Type newsData = (Tbl_News_Type)e.Item.DataItem;
            Repeater relatedNewsMost = e.Item.FindControl("relatedNewsMost") as Repeater;
            if (newsData.RelateListIds != null)
            {
                relatedNewsMost.DataSource = GroupNewsList.Where(i => newsData.RelateListIds.Contains(i.NewsID)).ToList();
                relatedNewsMost.DataBind();
            }
            //relatedNews.ItemDataBound += RelatedNews_ItemDataBound;
            // var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                //var news = _clsNews.GetNewsById(Convert.ToInt32(fld_newsId.Value), false);
                //  var res = GenerateTags(keywordList, newsData.NewsTitle, newsData.NewsLead, newsData.NewsBody, newsData.KeywordId, newsData.NewsDateIndex, newsData.CreateUser);
                var res = GenerateTags(keywordList, newsData.NewsDateIndex + "", newsData.KeyIds);
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }

            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;


            PlaceHolder pc_DelNews = e.Item.FindControl("pc_DelNews") as PlaceHolder;

            TextBox txtOrder = e.Item.FindControl("txt_row_index") as TextBox;

            var currentUser = Class_Layer.CurrentUser();

            if (currentUser.AllowSaveNews == false)
            {
                check.Checked = false;
            }
            else if (currentUser.SavedNewsIds != null && currentUser.SavedNewsIds.Contains("," + fld_newsId.Value + ","))
            {
                check.Checked = true;
            }
            else
            {
                check.Checked = false;
            }
            if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            {
                pc_DelNews.Visible = true;


            }
            else
            {
                pc_DelNews.Visible = false;
            }



            // news Index
            try
            {

                if (!string.IsNullOrWhiteSpace(currentUser.SavedOrderIds))
                {
                    var orderIndex = currentUser.SavedOrderIds.IndexOf("," + fld_newsId.Value + ":");
                    if (orderIndex > -1)
                    {
                        var orderIndex2 = currentUser.SavedOrderIds.Substring(orderIndex + 1).IndexOf(",");
                        txtOrder.Text = currentUser.SavedOrderIds.Substring(orderIndex + 1, orderIndex2).Split(':')[1];
                    }
                    else
                    {
                        txtOrder.Text = "";
                    }
                }
                else
                {
                    txtOrder.Text = "";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            _div.Style.Add("background-color", fld_color.Value.Trim());
        }
        protected void RelatedNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Tbl_News_Type newsData = (Tbl_News_Type)e.Item.DataItem;
            // var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                //var news = _clsNews.GetNewsById(Convert.ToInt32(fld_newsId.Value), false);
                //  var res = GenerateTags(keywordList, newsData.NewsTitle, newsData.NewsLead, newsData.NewsBody, newsData.KeywordId, newsData.NewsDateIndex, newsData.CreateUser);
                var res = GenerateTags(keywordList, newsData.NewsDateIndex + "", newsData.KeyIds);
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }
        }
        protected void relatedNewsMost_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            if (GroupNewsList == null || GroupNewsList.Count == 0)
            {
                GroupNewsList = (List<Tbl_News_Type>)Session["GroupNewsList"];

            }
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;
            Tbl_News_Type newsData = (Tbl_News_Type)e.Item.DataItem;
            Repeater relatedNewsMost = e.Item.FindControl("relatedNewsMost") as Repeater;
            if (newsData.RelateListIds != null)
            {
                relatedNewsMost.DataSource = GroupNewsList.Where(i => newsData.RelateListIds.Contains(i.NewsID)).ToList();
                relatedNewsMost.DataBind();
            }
            //relatedNews.ItemDataBound += RelatedNews_ItemDataBound;
            //var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                //var news = _clsNews.GetNewsById(Convert.ToInt32(fld_newsId.Value), false);
                //   var res = GenerateTags(keywordList, newsData.NewsTitle, newsData.NewsLead, newsData.NewsBody, newsData.KeywordId, newsData.NewsDateIndex, newsData.CreateUser);
                var res = GenerateTags(keywordList, newsData.NewsDateIndex + "", newsData.KeyIds);
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }

            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;


            PlaceHolder pc_DelNews = e.Item.FindControl("pc_DelNews") as PlaceHolder;

            TextBox txtOrder = e.Item.FindControl("txt_row_index") as TextBox;

            var currentUser = Class_Layer.CurrentUser();

            if (currentUser.AllowSaveNews == false)
            {
                check.Checked = false;
            }
            else if (currentUser.SavedNewsIds != null && currentUser.SavedNewsIds.Contains("," + fld_newsId.Value + ","))
            {
                check.Checked = true;
            }
            else
            {
                check.Checked = false;
            }
            if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            {
                pc_DelNews.Visible = true;


            }
            else
            {
                pc_DelNews.Visible = false;
            }



            // news Index
            try
            {

                if (!string.IsNullOrWhiteSpace(currentUser.SavedOrderIds))
                {
                    var orderIndex = currentUser.SavedOrderIds.IndexOf("," + fld_newsId.Value + ":");
                    if (orderIndex > -1)
                    {
                        var orderIndex2 = currentUser.SavedOrderIds.Substring(orderIndex + 1).IndexOf(",");
                        txtOrder.Text = currentUser.SavedOrderIds.Substring(orderIndex + 1, orderIndex2).Split(':')[1];
                    }
                    else
                    {
                        txtOrder.Text = "";
                    }
                }
                else
                {
                    txtOrder.Text = "";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            _div.Style.Add("background-color", fld_color.Value.Trim());
        }
        protected void btn_generateGroupHtml_Click(object sender, EventArgs e)
        {

        }
        protected void rptGroupNewKeyword_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (GroupNewsList == null || GroupNewsList.Count == 0)
            {
                GroupNewsList = (List<Tbl_News_Type>)Session["GroupNewsList"];

            }
            Tbl_RssKeywords data = (Tbl_RssKeywords)e.Item.DataItem;
            Repeater rptGroupNewsList = e.Item.FindControl("rptGroupNewsList") as Repeater;
            if (data != null)
            {
                if (GroupNewsList.Count != 0)
                {


                    //newsData.RelateListIds.Contains(i.NewsID)
                    //GenerateTags();
                    List<Tbl_RssKeywords> keys = (new Class_News()).GetKeywords(data.GroupName);
                    List<int> keyIds = new List<int>();
                    foreach (var ii in keys)
                    {
                        keyIds.Add(ii.KeyId);
                    }
                    //rptGroupNewsList.DataSource = GroupNewsList.Where(i => keyIds.Contains(i.KeywordId)).ToList();
                    //rptGroupNewsList.DataBind();
                    rptGroupNewsList.DataSource = GroupNewsList.Where(i => i.NewsKeyGroupsOrder == data.GroupOrder).OrderBy(t => t.OrderItem).ThenByDescending(d => d.NewsDateIndex).ThenByDescending(d => d.NewsTime).ToList();
                    rptGroupNewsList.DataBind();
                }
            }
        }
        protected void rptGroupNewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;
            Tbl_News_Type newsData = (Tbl_News_Type)e.Item.DataItem;

            //var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                //  var res = GenerateTags(keywordList, newsData.NewsTitle, newsData.NewsLead, newsData.NewsBody,
                //  newsData.KeywordId, newsData.NewsDateIndex, newsData.CreateUser);
                var res = GenerateTags(keywordList, newsData.NewsDateIndex + "", newsData.KeyIds);
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }

            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;


            PlaceHolder pc_DelNews = e.Item.FindControl("pc_DelNews") as PlaceHolder;

            TextBox txtOrder = e.Item.FindControl("txt_row_index") as TextBox;

            var currentUser = Class_Layer.CurrentUser();

            if (currentUser.AllowSaveNews == false)
            {
                check.Checked = false;
            }
            else if (currentUser.SavedNewsIds != null && currentUser.SavedNewsIds.Contains("," + fld_newsId.Value + ","))
            {
                check.Checked = true;
            }
            else
            {
                check.Checked = false;
            }

            var lstSelectedNews = new List<int>();
            foreach (var item in hdfSelectedBultanNews.Value.Split(','))
            {
                if (fld_newsId.Value == item)
                {
                    check.Checked = true;
                    break;
                }

            }

            if (bool.Parse(Session["IsAdmin"].ToString()) == true)
            {
                pc_DelNews.Visible = true;


            }
            else
            {
                pc_DelNews.Visible = false;
            }

            // news Index
            try
            {

                if (!string.IsNullOrWhiteSpace(currentUser.SavedOrderIds))
                {
                    var orderIndex = currentUser.SavedOrderIds.IndexOf("," + fld_newsId.Value + ":");
                    if (orderIndex > -1)
                    {
                        var orderIndex2 = currentUser.SavedOrderIds.Substring(orderIndex + 1).IndexOf(",");
                        txtOrder.Text = currentUser.SavedOrderIds.Substring(orderIndex + 1, orderIndex2).Split(':')[1];
                    }
                    else
                    {
                        txtOrder.Text = "";
                    }
                }
                else
                {
                    txtOrder.Text = "";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            _div.Style.Add("background-color", fld_color.Value.Trim());
        }
        //private Tuple<string, string> GenerateTags(List<Tbl_RssKeywords> keywords, string newsTitle, string newsLead,
        //    string newsBody, int? keywordId, long? newsDateIndex, int createUser)
        //{
        //    string newsMerge = Class_Static.PersianAlpha(newsTitle + " " + newsLead + " " + newsBody).ToLower().Trim();
        //    newsMerge = newsMerge.Replace("-", " ");
        //    newsMerge = newsMerge.Replace(".", " . ");
        //    newsMerge = newsMerge.Replace(":", " : ");
        //    newsMerge = newsMerge.Replace("?", " ? ");
        //    newsMerge = newsMerge.Replace("!", " ! ");
        //    newsMerge = newsMerge.Replace("،", " ، ");
        //    newsMerge = newsMerge.Replace(",", " , ");
        //    newsMerge = newsMerge.Replace("»", " » ");
        //    newsMerge = newsMerge.Replace("«", " « ");
        //    newsMerge = newsMerge.Replace("(", " ( ");
        //    newsMerge = newsMerge.Replace(")", " ) ");
        //    newsMerge = newsMerge.Replace("}", " } ");
        //    newsMerge = newsMerge.Replace("{", " { ");
        //    newsMerge = newsMerge.Replace("*", " * ");
        //    newsMerge = newsMerge.Replace("<", " < ");
        //    newsMerge = newsMerge.Replace(">", " > ");
        //    newsMerge = newsMerge.Replace("/", " / ");
        //    //newsMerge = newsMerge.Replace("\", " \\ ");

        //    newsMerge = " " + newsMerge + " ";



        //    string findKeywords = "";
        //    var dic = new Dictionary<int, int?>();
        //    foreach (var key in keywords)
        //    {
        //        try
        //        {
        //            key.KeywordName = Class_Static.PersianAlpha((key.KeywordName)).ToLower().Trim();
        //            var spils = key.KeywordName.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries); ;

        //            var findCount = 0;
        //            foreach (var spilItem in spils)
        //            {
        //                if (newsMerge.IndexOf(" " + spilItem.Trim() + " ") > -1)
        //                {
        //                    findCount++;

        //                }

        //            }
        //            if (findCount == spils.Count())
        //            {
        //                if (!dic.Any(t => t.Key == key.KeyId))
        //                {


        //                    dic.Add(key.KeyId, key.PanelId);
        //                    findKeywords += "<a data-keyid='" + key.KeyId + "' data-color='" + key.Color + "' data-text='" + key.KeywordName + "' title='جهت نمایش موارد مشابه این کلید واژه کلیک کنید' href='/NewsList/?fromDate=" + newsDateIndex + "&toDate=" + newsDateIndex + "&keyword=" + Server.HtmlEncode(key.KeywordName.Replace("+", "&")) + "&recordCount=10000000' target='_blank'>" + key.KeywordName + "</a>";
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            continue;
        //        }
        //    }

        //    try
        //    {
        //        var currentKey = keywords.FirstOrDefault(t => t.KeyId == Convert.ToInt32(keywordId));
        //        if (currentKey != null)
        //        {
        //            if (findKeywords.IndexOf(" " + currentKey.KeywordName + " ") == -1)
        //            {
        //                dic.Add(currentKey.KeyId, currentKey.PanelId);
        //                findKeywords += "<a title='جهت نمایش موارد مشابه این کلید واژه کلیک کنید' href='/NewsList/?fromDate=" + newsDateIndex + "&toDate=" + newsDateIndex + "&keyword=" + Server.HtmlEncode(currentKey.KeywordName.Replace("+", "|")) + "&recordCount=10000000' target='_blank'>" + currentKey.KeywordName + "</a>";
        //            }

        //        }
        //    }
        //    catch { }
        //    if (!string.IsNullOrWhiteSpace(findKeywords))
        //    {
        //        findKeywords = "کلیدواژه ها : " + findKeywords;
        //    }
        //    var keyIds = "";
        //    foreach (var item in dic)
        //    {
        //        keyIds += "," + item.Key + ",";
        //    }
        //    var ifOwnUser = "";
        //    if (createUser == 29)
        //    {
        //        ifOwnUser = "<span> * </span>";
        //    }
        //    return new Tuple<string, string>(Class_Static.PersianAlpha(ifOwnUser + findKeywords), keyIds);
        //}
        private Tuple<string, string> GenerateTags(List<Tbl_RssKeywords> keywords, string newsDateIndex, string keyIds)
        {

            string findKeywords = "";

            if (string.IsNullOrWhiteSpace(keyIds))
                return new Tuple<string, string>("", keyIds);

            var finalKeyIds = "";
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    var selKeyId = Convert.ToInt32(keySpil);
                    var key = keywords.FirstOrDefault(t => t.KeyId == selKeyId);
                    if (key == null) continue;

                    finalKeyIds += "," + key.KeyId + ",";

                    findKeywords += "<a data-keyid='" + key.KeyId + "' data-color='" + key.Color + "' data-text='" + key.KeywordName + "' title='جهت نمایش موارد مشابه این کلید واژه کلیک کنید' href='/NewsList/?fromDate=" + newsDateIndex + "&toDate=" + newsDateIndex + "&keyword=" + Server.HtmlEncode(key.KeywordName.Replace("+", "&")) + "&recordCount=10000000' target='_blank'>" + key.KeywordName + "</a>";
                }
                catch
                {
                    continue;
                }
            }


            return new Tuple<string, string>(Class_Static.PersianAlpha(findKeywords), finalKeyIds);
        }

        //public class NewsType
        //{
        //    public string SiteLogo { get; set; }
        //    public string GroupOrder { get; set; }
        //    public int NewsID { get; set; }
        //    public int SiteID { get; set; }
        //    public int KeywordId { get; set; }
        //    public int GroupId { get; set; }
        //    public string NewsTitle { get; set; }
        //    public string KeywordName { get; set; }
        //    public string NewsLead { get; set; }
        //    public string NewsBody { get; set; }
        //    public string NewsLink { get; set; }
        //    public string SiteTitle { get; set; }
        //    public string NewsPicture { get; set; }
        //    public string GroupName { get; set; }
        //    public string NewsDate { get; set; }
        //    public DateTime CreateDate { get; set; }
        //    public int SiteType { get; set; }
        //    public string NewsTime { get; set; }
        //    public List<int> NewsKeyTags { get; set; }
        //    public List<int> NewsKeyGroups { get; set; }
        //    public int NewsKeyGroupsOrder { get; set; }
        //    public int NewsKeyTagsOrder { get; set; }
        //    public int? NewsGroupOrder { get; set; }
        //    public bool IsFeederNews { get; set; }
        //    public long NewsLinkCRC { get; set; }
        //    public string Color { get; set; }
        //    public bool IsSelected { get; set; }
        //    public string NewsValue { get; set; }
        //    public string SortOrder { get; set; }
        //    public long NewsDateIndex { get; set; }
        //    public int CreateUser { get; set; }

        //}
        protected void btnSaveGroup_Click(object sender, EventArgs e)
        {

            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsID",Convert.ToInt32(hddNewsIdGroup.Value)),
                new SqlParameter("@" + "GroupOrder",Convert.ToInt32(rbtGroups.SelectedValue))
        };
            Convert.ToInt32(Class_Ado.ExecuteNonQuery("", "p_News_GroupOrder_Update", CommandType.StoredProcedure, sqlParams));
        }

        protected void rbtRelatedList_CheckedChanged(object sender, EventArgs e)
        {
            //if (ViewState["relatedListOK"] == null)
            //{
            //    var relatedList = Class_Static.LoadRelatedNews(GroupNewsList);
            //    rptRelatedNews_list.DataSource = relatedList;
            //    rptRelatedNews_list.DataBind();


            //    rptMostRelatedNews_list.DataSource = relatedList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
            //    rptMostRelatedNews_list.DataBind();


            //    ViewState.Add("relatedListOK", "ok");
            //}
        }

        protected void rbtMostPublished_CheckedChanged(object sender, EventArgs e)
        {
            //if (ViewState["relatedListOK"] == null)
            //{
            //    var relatedList = Class_Static.LoadRelatedNews(GroupNewsList);
            //    rptRelatedNews_list.DataSource = relatedList;
            //    rptRelatedNews_list.DataBind();


            //    rptMostRelatedNews_list.DataSource = relatedList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
            //    rptMostRelatedNews_list.DataBind();


            //    ViewState.Add("relatedListOK", "ok");
            //}

        }

        protected void rbtRelatedList_Click(object sender, EventArgs e)
        {
            GetRelateData();
            //DoRelateNews
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DoRelateNews", "DoRelateNews()", true);

        }

        protected void rbtMostPublished_Click(object sender, EventArgs e)
        {
            GetRelateData();
            //DoMostPublishNews
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "DoMostPublishNews", "DoMostPublishNews()", true);

        }
        public void GetRelateData()
        {
            if (ViewState["relatedListOK"] == null)
            {
                if (GroupNewsList == null || GroupNewsList.Count == 0)
                {
                    GroupNewsList = (List<Tbl_News_Type>)Session["GroupNewsList"];

                }
                var relatedList = Class_Static.LoadRelatedNews(GroupNewsList);
                rptRelatedNews_list.DataSource = relatedList;
                rptRelatedNews_list.DataBind();


                rptMostRelatedNews_list.DataSource = relatedList.Where(j => j.RelateListIds != null ? j.RelateListIds.Count > 0 : j.RelateListIds != null).OrderByDescending(i => i.RelateListIds != null ? i.RelateListIds.Count : 0).ToList();
                rptMostRelatedNews_list.DataBind();


                ViewState.Add("relatedListOK", "ok");
                // updMain.Update();
            }
        }

        protected void btnBultan_Click(object sender, EventArgs e)
        {
            var list = new Dictionary<int, int>();
            var counter = 0;
            foreach (RepeaterItem item0 in rptGroupNewKeyword.Items)
            {
                try
                {


                    var rptGroupNewsList = (Repeater)item0.FindControl("rptGroupNewsList");
                    foreach (RepeaterItem item in rptGroupNewsList.Items)
                    {
                        try
                        {
                            var fld_newsId = (HiddenField)item.FindControl("fld_newsId");
                            var txt_row_index = (TextBox)item.FindControl("txt_row_index");
                            var check_SelectNews = (CheckBox)item.FindControl("check_SelectNews");

                            if (check_SelectNews.Checked)
                            {
                                if (string.IsNullOrWhiteSpace(txt_row_index.Text))
                                {
                                    txt_row_index.Text = "10000" + counter;
                                    counter++;
                                }
                                list.Add(Convert.ToInt32(fld_newsId.Value), Convert.ToInt32(txt_row_index.Text));
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }


                // DropDownList yourDropDown = (DropDownList)item.FindControl("the name of your dropdown control here");
                // string value = yourDropDown.SelectedValue;

            }

            var bultanId = Convert.ToInt32(hdfBultnArchiveID.Value);
            var str = "";
            foreach (var item in list.OrderBy(t => t.Value))
            {
                str += "," + item.Key + "";
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                str = str.Substring(1);
            }
            new Class_BultanArchive().UpdateArchiveNews(bultanId, str);

            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            //  nameValues.Set("sortBy", "4");
            string url = Request.Url.AbsolutePath;
            Response.Redirect(url + "?" + nameValues, false); // ToString() is called implicitly


            //  Response.Redirect(Request.RawUrl, false);
        }
    }
}