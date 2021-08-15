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


namespace PArt.Pages.P_Art.Pages
{

    public partial class NewsMaster : System.Web.UI.Page
    {
        [ThemeableAttribute(false)]
        public virtual string GroupName { get; set; }

        Class_News _clsNews = new Class_News();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();

        private int RecordCount = 1000;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMasterNewsTag();
            Class_Layer.CheckSession();
            if (IsPostBack) return;

            LoadUserData();
            LoadNewsSource();
            LoadData(0);
            LoadTemplate();

            DateTime dt = DateTime.Now.AddDays(-1);
            string date = _clsZm.MiladiToShamsi(dt.ToShortDateString());
            date = date.Substring(0, 10).Replace("/", "");
            lnk_yesterday.HRef = "/News/Latest/?FromDate=" + date + "&toDate=" + date;

        }
        private void LoadMasterNewsTag()
        {
            try
            {

                DB_NewsCenterEntities db = new DB_NewsCenterEntities();
                var currentUser = Class_Layer.CurrentUser();
                var parminID = Convert.ToInt32(currentUser.ParminIds);

                var parmins = (from n in db.Tbl_MasterNewsTag
                               where n.ParminID == parminID
                               orderby n.Title ascending
                               select n).ToList();
                var data = "";
                foreach (var item in parmins)
                {
                    if (string.IsNullOrWhiteSpace(data))
                    {
                        data += item.ParminID + ":" + item.Title;
                    }
                    else
                    {
                        data += "," + item.ParminID + ":" + item.Title;
                    }
                }

                hdfMasterNewsTag.Value = data;
            }
            catch
            {

            }


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

            }
            if (Request.QueryString["recordcount"] != null)
            {
                RecordCount = int.Parse(Server.HtmlDecode(Request.QueryString["recordcount"].ToString()));


            }
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
            result = _clsNews.GetAllNewsDataTable(RecordCount, 1, Class_Layer.UserPanels(), null, true, Class_Layer.UserHighlight(), fromDate, toDate, strSearch, siteId, null, "", "", newsIds,"",false);


            if (drp_sort.SelectedValue == "1")
            {
                result.DefaultView.Sort = "NewsId desc";
            }
            //  var lstCRC = new List<long>();
            //  var newResult = new DataTable();
            //foreach (DataRow item in result.Rows)
            //{
            //    try
            //    {

            //        if (item["NewsLinkCRC"] != null)
            //        {
            //            var crc = Convert.ToInt64(item["NewsLinkCRC"]);
            //            if (crc != 0)
            //            {
            //                var find = lstCRC.FirstOrDefault(t => t == crc);
            //                if (find == null || find == 0)
            //                {
            //                    newResult.Rows.Add(item);
            //                }
            //            }
            //            else
            //            {
            //                newResult.Rows.Add(item);

            //            }
            //        }
            //        else
            //        {
            //            newResult.Rows.Add(item);
            //        }
            //    }
            //    catch
            //    {
            //        newResult.Rows.Add(item);

            //    }
            //}
            news_list.DataSource = result;
            news_list.DataBind();

            if (result.Rows.Count == 0)
            {
                Session["LastNewsId"] = "0";
            }
            else
            {

                Session["LastNewsId"] = result.Rows[0]["NewsId"].ToString();
            }


            LoadGroups(result);



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
        public string GetNewsFullDateIndex(string createDate, string newsTime, string siteType)
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
                    newsTime = newsTime.Replace(":", "");
                }
            }

            var dt = DateTime.Parse(createDate);
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            var dateIndex = pc.GetYear(dt) + "" + pc.GetMonth(dt) + "" + pc.GetDayOfMonth(dt);

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
                var sel = siteIds.FirstOrDefault(t => t == keyId);
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                if (sel == null || sel == 0)
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                {
                    return "1000";
                }
                else
                {
                    return siteIds.IndexOf(keyId) + "";
                }
            }
            return "1000";
        }
        public static string DiffrentDate(object ddate, string sitetype, string newstime)
        {
            Class_Zaman zm = new Class_Zaman();
            if (sitetype == "2")
            {
                return zm.MiladiToShamsi(ddate.ToString()).Substring(0, 10);

            }
            var dt = new DateTime();
            if (!string.IsNullOrWhiteSpace(newstime))
            {
                try
                {
                    var newsDate = Convert.ToDateTime(ddate);
                    newstime = Class_Static.GetAbsoluteTime(newstime);
                    var newstimeSpil = newstime.Split(':');
                    dt = new DateTime(newsDate.Year, newsDate.Month, newsDate.Day, Convert.ToInt32(newstimeSpil[0]), Convert.ToInt32(newstimeSpil[1]), 0);
                    //  return Class_Static.GetOnTimeDate(dateTime);
                }
                catch
                {
                    dt = Convert.ToDateTime(ddate);
                    //return Class_Static.GetOnTimeDate();



                }

            }
            else
            {
                // return Class_Static.GetOnTimeDate(Convert.ToDateTime(ddate));
                dt = Convert.ToDateTime(ddate);
            }

            //if (newstime.Trim() == "")
            //{
            //    dt = DateTime.Parse(ddate.ToString());
            //}
            //else
            //{
            //    try
            //    {
            //        DateTime dtTemp = DateTime.Parse(ddate.ToString());

            //        dt = DateTime.Parse(dtTemp.Year + "/" + dtTemp.Month + "/" + dtTemp.Day + " " + newstime);
            //    }
            //    catch
            //    {
            //        dt = DateTime.Parse(ddate.ToString());
            //    }
            //}
            return Class_Static.GetOnTimeDate(dt);
            //int hour = (DateTime.Now - dt).Hours;
            //int minute = (DateTime.Now - dt).Minutes;
            //int second = (DateTime.Now - dt).Seconds;
            //int days = (DateTime.Now - dt).Days;

            //if (days == 0)
            //{

            //    if (hour == 0)
            //    {
            //        return minute + " دقیقه " + " پیش ";
            //    }
            //    else
            //    {
            //        return hour + " ساعت " + minute + " دقیقه " + " پیش ";
            //    }



            //}
            //else if (days == 1)
            //{
            //    return "دیروز";
            //}
            //else
            //{

            //    return zm.MiladiToShamsi(ddate.ToString()).Substring(0, 10);
            //}

        }

        protected void news_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            HtmlGenericControl _div = e.Item.FindControl("news_row") as HtmlGenericControl;
            if (_div == null) return;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField fld_newsId = e.Item.FindControl("fld_newsId") as HiddenField;
            HiddenField fld_isSelected = e.Item.FindControl("fld_IsSelected") as HiddenField;

            HiddenField fld_newscrc = e.Item.FindControl("fld_news_crc") as HiddenField;

            CheckBox check = e.Item.FindControl("check_SelectNews") as CheckBox;


            PlaceHolder pc_DelNews = e.Item.FindControl("pc_DelNews") as PlaceHolder;



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

            try
            {
                DropDownList ddlMasterTag = e.Item.FindControl("ddlMasterTag") as DropDownList;
                var item0 = new ListItem();
                item0.Value = "0";
                item0.Text = "خوشه خبر";
                ddlMasterTag.Items.Add(item0);
                if (!string.IsNullOrWhiteSpace(hdfMasterNewsTag.Value))
                {
                    foreach (var dr in hdfMasterNewsTag.Value.Split(','))
                    {
                        var item = new ListItem();
                        item.Value = dr.Split(':')[0];
                        item.Text = dr.Split(':')[1];
                        ddlMasterTag.Items.Add(item);
                    }
                }
            }
            catch
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

            _div.Style.Add("background-color", fld_color.Value.Trim());
        }

        private void LoadGroups(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["keywordid"].ToString() == "")
                {
                    row["keywordid"] = "-1";

                }
                if (row["OrderItem"].ToString() == "")
                {

                    row["OrderItem"] = "1000";
                }

            }
            var x = (from r in dt.AsEnumerable()
                     orderby r["OrderItem"]
                     select r["KeywordId"]).Distinct().ToList();

            List<int?> ids = new List<int?>();
            foreach (var item in x)
            {
                if (item.ToString() == "") continue;
                ids.Add(int.Parse(item.ToString()));

            }

            Class_Keywords _cls = new Class_Keywords();
            //Class_NewsGroup _cls = new Class_NewsGroup();
            rpt_Groups.DataSource = _cls.GetRssKeywordByIds(ids);
            rpt_Groups.DataBind();

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
                url += "keyword=" + Server.HtmlEncode(txt_search.Text.Trim()) + "&";
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

            Response.Redirect("/NewsList/?" + url);



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
            var parmin = _cls.GetParminById(int.Parse(Class_Layer.UserPanels()[0].Value.ToString()));
            if (parmin.BultanId == null)
            {
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
            Class_Ado _cls = new Class_Ado();
            _cls.ExecuteCommand("update tbl_news set IsSelected = null,SortOrder=null where newsid in (select newsid from Tbl_Relation_NewsParminPanel where ParminPanelId = " + Class_Layer.UserPanels()[0] + " and NewsDateIndex between " + txt_fromDate.Text.Replace("/", "") + " and " + txt_toDate.Text.Replace("/", "") + ")");

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
                cmd.CommandText = "insert into Tbl_News (NewsId,SiteId,SiteType,SiteTitle,Newstitle,NewsLead,NewsBody,NewsDateIndex,NewsDate,NewsTime,NewsPicture,NewsLink,NewsPosition,NewsValue) values " +
                                                       "(@NewsId,@SiteId,@SiteType,@SiteTitle,@Newstitle,@NewsLead,@NewsBody,@NewsDateIndex,@NewsDate,@NewsTime,@NewsPicture,@NewsLink,@NewsPosition,@NewsValue)";

                cmd.Parameters.Clear();
                cmd.Parameters.Add("NewsId", OleDbType.Numeric).Value = news["NewsId"].ToString();
                cmd.Parameters.Add("SiteId", OleDbType.Numeric).Value = news["SiteId"].ToString();
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
            var currentUser = Class_Layer.CurrentUser();

            foreach (RepeaterItem item in news_list.Items)
            {
                try
                {


                    CheckBox check = item.FindControl("check_SelectNews") as CheckBox;
                    TextBox txt = item.FindControl("txt_row_index") as TextBox;
                    HiddenField fld = item.FindControl("fld_newsId") as HiddenField;

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
            db.Database.ExecuteSqlCommand("update Tbl_AgenceMembers set SavedNewsIds = '" + userSelectedNews + "' where MemberID=" + currentUser.MemberID);
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

        protected void btnProPDF_Click(object sender, EventArgs e)
        {
            var lstSeletedNews = new List<NewsSelectClass>();
            foreach (RepeaterItem item in news_list.Items)
            {
                try
                {


                    CheckBox check = item.FindControl("check_SelectNews") as CheckBox;


                    if (check.Checked == true)
                    {
                        TextBox txtIndex = item.FindControl("txt_row_index") as TextBox;
                        HiddenField fld = item.FindControl("fld_newsId") as HiddenField;
                        HiddenField hdfNewsOrientation = item.FindControl("hdfNewsOrientation") as HiddenField;
                        DropDownList ddlMasterTag = item.FindControl("ddlMasterTag") as DropDownList;

                        var selItem = new NewsSelectClass();

                        selItem.NewsChecked = true;
                        selItem.NewsID = Convert.ToInt32(fld.Value);
                        if (string.IsNullOrWhiteSpace(txtIndex.Text))
                        {
                            selItem.NewsOrder = 0;
                        }
                        else
                        {
                            selItem.NewsOrder = Convert.ToInt32(txtIndex.Text);
                        }
                        selItem.NewsMasterTagID = Convert.ToInt32(ddlMasterTag.SelectedValue);
                        selItem.NewsMasterTagTitle = (ddlMasterTag.SelectedItem.Text);
                        if (string.IsNullOrWhiteSpace(hdfNewsOrientation.Value))
                        {
                            selItem.NewsOrientation = 0;
                        }
                        else
                        {
                            selItem.NewsOrientation = Convert.ToInt32(hdfNewsOrientation.Value);
                        }

                        lstSeletedNews.Add(selItem);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    continue;
                }
            }
            Session.Add("NewsBultanSelected", lstSeletedNews);
            Response.Redirect("/pages/P-Art/pages/ExportBultanHtml.aspx", false);
        }



    }
}