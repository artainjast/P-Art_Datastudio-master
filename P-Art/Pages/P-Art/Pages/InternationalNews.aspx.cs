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
using Telegram.Bot;
using Newtonsoft.Json;
using System.Web.Services.Description;
using Telegram.Bot.Types.Enums;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class InternationalNews : System.Web.UI.Page
    {
        DataSet dsAllData;
        DataTable dsAllData1 = new DataTable();
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        List<int?> UserPanelList = new List<int?>();
        Class_Ado _cls = new Class_Ado();
        List<int?> panelIds = new List<int?>();
        List<Tbl_Parmin> tblparmin = new List<Tbl_Parmin>();
        List<Tbl_News_Type> NewsList = new List<Tbl_News_Type>();
        List<Tbl_News_Type> NewsList2 = new List<Tbl_News_Type>();
        List<Tbl_News_Type> NewsListTimeLine = new List<Tbl_News_Type>();
        List<Tbl_RssKeywords> keywordList = new List<Tbl_RssKeywords>();
        Class_News _clsNews = new Class_News();
        List<Tbl_News_Type> GroupNewsList = new List<Tbl_News_Type>();



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


        public List<Tbl_News_Type> GetFromInternationalDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_Type acc = new Tbl_News_Type();
                acc.NewsLink = "/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"];
                acc.NewsLink2 = dr["NewsLink"] + "";
                acc.SiteID = Convert.ToInt32(dr["SiteID"]);
                acc.NewsID = Convert.ToInt32(dr["NewsID"]);
                acc.GroupId = Convert.ToInt32(dr["GroupId"]);
                acc.KeywordId = Convert.ToInt32(dr["KeywordId"]);
                acc.NewsTitle = _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false);
                acc.NewsDate = dr["NewsDate"] + "";
                acc.NewsLead = _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false);
                acc.KeywordName = dr["KeywordName"] + "";
                acc.NewsBody = _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false);
                acc.SiteTitle = dr["SiteTitle"] + "";
                acc.NewsPicture = dr["NewsPicture"] + "";
                if (acc.NewsPicture == "")
                    acc.NewsPicture = "/Pages/P-Art/Images/noimage.png";
                acc.GroupName = dr["GroupName"] + "";
                acc.CreateDate = (dr["CreateDate"] + "");
                acc.SiteType = Convert.ToInt32(dr["SiteType"]);
                acc.NewsTime = dr["NewsTime"] + "";
                acc.SiteLogo = dr["Logo"] + "";
                acc.GroupOrder = Class_Static.ToNullableInt(dr["GroupOrder"] + "");
                acc.NewsValue = (dr["NewsValue"] + "");
                acc.NewsGroupOrder = Class_Static.ToNullableInt(dr["NewsGroupOrder"] + "");
                acc.KeyIds = (dr["KeyIds"] + "").ToString();
                //acc.NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"]);
                acc.SortOrder = dr["SortOrder"].ToString();
                try { acc.RelatedNewsStringIds = dr["RelatedNewsStringIds"] + ""; } catch { acc.RelatedNewsStringIds = ""; }
                list.Add(acc);

            }
            return list;



        }


        public List<Tbl_News_Type> GetFromInternationalDataRows2(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_Type acc = new Tbl_News_Type();
                acc.NewsLink = dr["NewsLink"] + "";
                acc.SiteID = Convert.ToInt32(dr["SiteID"]);
                acc.NewsID = Convert.ToInt32(dr["NewsID"]);
                acc.GroupId = Convert.ToInt32(dr["GroupId"]);
                acc.KeywordId = Convert.ToInt32(dr["KeywordId"]);
                acc.NewsTitle = _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false);
                acc.NewsDate = dr["NewsDate"] + "";
                acc.NewsLead = _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false);
                acc.KeywordName = dr["KeywordName"] + "";
                acc.NewsBody = _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false);
                acc.SiteTitle = dr["SiteTitle"] + "";
                acc.NewsPicture = dr["NewsPicture"] + "";
                if (acc.NewsPicture == "")
                    acc.NewsPicture = "/Pages/P-Art/Images/noimage.png";
                acc.GroupName = dr["GroupName"] + "";
                acc.CreateDate = (dr["CreateDate"] + "");
                acc.SiteType = Convert.ToInt32(dr["SiteType"]);
                acc.NewsTime = dr["NewsTime"] + "";
                acc.SiteLogo = dr["Logo"] + "";
                acc.GroupOrder = Class_Static.ToNullableInt(dr["GroupOrder"] + "");
                acc.NewsValue = (dr["NewsValue"] + "");
                acc.NewsGroupOrder = Class_Static.ToNullableInt(dr["NewsGroupOrder"] + "");
                acc.KeyIds = (dr["KeyIds"] + "").ToString();
                //acc.NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"]);
                try { acc.RelatedNewsStringIds = dr["RelatedNewsStringIds"] + ""; } catch { acc.RelatedNewsStringIds = ""; }
                list.Add(acc);

            }
            return list;



        }




        DB_NewsCenterEntities db = new DB_NewsCenterEntities();

        public static string SendToTelegramChannel(string panelIds, string NewsList)
        {

            try
            {

                var newsTemplate = NewsList;

                string channelID = panelIds;

                var botToken = "195742414:AAGMkJr9suOYh6Tgfi7YapyDpmOjTp0Pg2Q";


                try
                {



                    var Bot = new TelegramBotClient(botToken);// new Telegram.Bot.TelegramBotClient(botToken);

                    var tt = Bot.SendTextMessageAsync(channelID, newsTemplate, false, true, 0, null);
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                }

            }
            catch
            {

            }

            return "hello";
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
                    cmdSearch += " )  and dbo.Tbl_News.SiteID = " + drp_NewsSource.SelectedItem.Value + "";
                }
                else
                {
                    cmdSearch = " AND (";
                    cmdSearch += " dbo.Tbl_News.NewsTitle LIKE N'% " + Search + " %' OR dbo.Tbl_News.NewsLead LIKE N'% " + Search + " %' OR dbo.Tbl_News.NewsBody LIKE N'% " + Search + " %'";
                    cmdSearch += " ) ";
                }

            if (drp_NewsSource.SelectedItem.Value != "0")
            {
                cmdSearch += "AND dbo.Tbl_News.SiteID =" + drp_NewsSource.SelectedItem.Value + "";
            }

            //if (drp_NewsSource.SelectedItem.Value != "0")
            //{
            //    cmdSearch += "SiteId=" + drp_NewsSource.SelectedItem.Value;
            //}
            var html = "";
#pragma warning disable CS0219 // The variable 'newsIds' is assigned but its value is never used
            string newsIds = "";
#pragma warning restore CS0219 // The variable 'newsIds' is assigned but its value is never used
            panelIds = Class_Layer.UserPanels();


            dsAllData = Class_News.GetInternationalNews(10000, 0, panelIds, false, fromDate, toDate,
                fromHour, toHour, cmdSearch, "", "");
            NewsList = GetFromInternationalDataRows(dsAllData.Tables[0].Select());
            if (NewsList.Count != 0)
            {
                rptFehrest.DataSource = NewsList.ToList();


                rptFehrest.DataBind();

                prepareDivs();

                divFehrest.Visible = true;
                divFehrest1.Visible = false;
                literalll.Visible = false;
                divloader.Visible = false;
                divmessage.Visible = false;
                spanalert.Visible = false;

            }
            else
            {
                divloader.Visible = false;
                divmessage.Visible = true;
                spanalert.Visible = true;
                divFehrest.Visible = false;

                divFehrest1.Visible = false;
                html = "برای امروز اخباری موجود نیست.برای مشاهده اخبار بازه زمانی را مشخص کنید";
                literalll.Text = html;
            }


        }

        private void prepareData2(long fromDate, long toDate, string fromHour, string toHour, string Search = "")
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

            var html = "";
            panelIds = Class_Layer.UserPanels();

            dsAllData = Class_News.GetInternationalNews(10000, 0, panelIds, false, fromDate, toDate,
                fromHour, toHour, cmdSearch, "", "");
            NewsList2 = GetFromInternationalDataRows2(dsAllData.Tables[0].Select());
            if (NewsList2.Count != 0)
            {
                rptFehrest.DataSource = NewsList2.ToList();
                rptFehrest.DataBind();

                prepareDivs();

                divFehrest.Visible = true;
                divFehrest1.Visible = false;
                literalll.Visible = false;
                divloader.Visible = false;
                divmessage.Visible = false;
                spanalert.Visible = false;

            }
            else
            {
                spanalert.Visible = true;

                divloader.Visible = false;
                divmessage.Visible = true;
                divFehrest.Visible = false;

                divFehrest1.Visible = false;
                html = "برای امروز اخباری موجود نیست.برای مشاهده اخبار بازه زمانی را مشخص کنید";
                literalll.Text = html;
            }


        }

        private void prepareFirstPageData(long fromDate, long toDate, string fromHour, string toHour, string Search = "")
        {
            var html = "";


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
                    cmdSearch += " )  and dbo.Tbl_News.SiteID = " + drp_NewsSource.SelectedItem.Value + "";
                }
                else
                {
                    cmdSearch = " AND (";
                    cmdSearch += " dbo.Tbl_News.NewsTitle LIKE N'% " + Search + " %' OR dbo.Tbl_News.NewsLead LIKE N'% " + Search + " %' OR dbo.Tbl_News.NewsBody LIKE N'% " + Search + " %'";
                    cmdSearch += " ) ";
                }

            //if (drp_NewsSource.SelectedItem.Value != "0")
            //{
            //    cmdSearch += "AND dbo.Tbl_News.SiteID =" + drp_NewsSource.SelectedItem.Value + "";
            //}

            //if (drp_NewsSource.SelectedItem.Value != "0")
            //{
            //    cmdSearch += "SiteId=" + drp_NewsSource.SelectedItem.Value;
            //}

            string newsIds = "";
            panelIds = Class_Layer.UserPanels();
            int siteId = 0;
            if (Request.QueryString["SiteId"] != null)
            {
                siteId = int.Parse(Request.QueryString["SiteId"].ToString());
                drp_NewsSource.SelectedValue = siteId.ToString();
            }

            dsAllData1 = Class_News.GetAllInternationalNewsDataTable(10000, 1, Class_Layer.UserPanels(), false, true, Class_Layer.UserHighlight(),
                fromDate, toDate, "", siteId, false, txt_fromHour.Text, txt_toHour.Text, newsIds, "", false);

            var dtNew = dsAllData1.Copy();


            List<Tbl_News_Type> newsList = GetFromInternationalDataRows(dtNew.Select());
            if (newsList.Count != 0)
            {
                rptFehrest1.DataSource = newsList.ToList();
                rptFehrest1.DataBind();

                prepareDivs();

                divFehrest1.Visible = true;
                literalll.Visible = false;
                divmessage.Visible = false;
                spanalert.Visible = false;

            }

            else
            {
                spanalert.Visible = true;

                divloader.Visible = false;
                divmessage.Visible = true;

                divFehrest1.Visible = false;
                html = "برای امروز اخباری موجود نیست.برای مشاهده اخبار بازه زمانی را مشخص کنید";
                literalll.Text = html;
            }

        }




        private void prepareDivs()
        {
            //  divLoad.Visible = false;

            divFehrest.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Panels _clsPanel = new Class_Panels();
            Class_Layer.CheckSession();
            if (!Page.IsPostBack)
            {
                Class_Zaman zm = new Class_Zaman();
                txt_fromDate.Text = zm.Today();
                txt_toDate.Text = zm.Today();
                long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));
                prepareFirstPageData(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text);
                ///prepareData(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text);
                linkTimeLine.Attributes.Add("class", "active-titr");

                linkReport.Attributes.Add("class", "");

                prepareDivs();
                //divLoad.Visible = true;
                panelIds = Class_Layer.UserPanels();
                int parminId = _clsPanel.GetParminById(Class_Layer.UserPanels()[0].Value).ParminID;


                var parmin = panelIds[0].Value + "";
                btn_generateGroupHtml.Attributes.Add("data-parmin", parmin);
                btn_generateGroupHtml1.Attributes.Add("data-parmin", parmin);
                LoadNewsSource();
            }
        }

        private void LoadNewsSource()
        {
            drp_NewsSource.Items.Clear();
            ListItem newItem = new ListItem();
            newItem.Text = "کليه منابع";
            newItem.Value = "0";

            drp_NewsSource.Items.Add(newItem);

            //newItem = new ListItem();
            //newItem.Text = "کليه خبرگزاري ها";
            //newItem.Value = "-1";
            //drp_NewsSource.Items.Add(newItem);

            //newItem = new ListItem();
            //newItem.Text = "کليه روزنامه ها";
            //newItem.Value = "-2";
            //drp_NewsSource.Items.Add(newItem);


            Class_Sites _clsSite = new Class_Sites();
            Class_Ado _clsAdo = new Class_Ado();

            string panels = Class_Layer.CurrentUser().ParminIds;
            string sites = "";
            int sitetype = 3;
            DataTable dt = _clsAdo.FillDataTable("select * from tbl_parmin where parminId in(" + panels + ")");
            DataTable dt1 = _clsAdo.FillDataTable("select SiteID from Tbl_Sites where SiteType=(" + sitetype + ")");
            foreach (DataRow row in dt1.Rows)
            {
                if (row["SiteID"].ToString() != "")
                {
                    sites += "," + row["SiteID"].ToString();
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

        private Tuple<string, string> GenerateTags(List<Tbl_RssKeywords> keywords, string newsDateIndex, string keyIds)
        {
            Class_Keywords _clsKeyword = new Class_Keywords();

            keywords = _clsKeyword.GetRssKeywordByPanelIds(Class_Layer.UserPanels());
            keywordList = keywords;

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

            prepareDivs();


        }

        protected void rptFehrest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {



        }




        protected void btnGetTimeLineReport_Click(object sender, EventArgs e)
        {
            string codes = "";
            string relateCodes = "";
#pragma warning disable CS0219 // The variable 'result' is assigned but its value is never used
            string result = "";
#pragma warning restore CS0219 // The variable 'result' is assigned but its value is never used
            foreach (RepeaterItem item in rptFehrest.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {

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
                    }

                }
            }
        }


        protected void rptFehrest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Class_Panels _clsPanel = new Class_Panels();
            if (e.CommandName == "sendTeleram")
            {
                string parminId = _clsPanel.GetParminById(Class_Layer.UserPanels()[0].Value).TelegramChannel2;

                if (parminId != null)
                {


                    int newsId = Convert.ToInt32(e.CommandArgument.ToString());

                    long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                    long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));
                    prepareData(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text, txtSeacrh.Text);
                    prepareData2(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text, txtSeacrh.Text);

                    string sitetitle = NewsList.FirstOrDefault(i => i.NewsID == newsId).SiteTitle;
                    string newstime = NewsList.FirstOrDefault(i => i.NewsID == newsId).NewsTime;
                    string newstitle = NewsList.FirstOrDefault(i => i.NewsID == newsId).NewsTitle;
                    string newdate = NewsList.FirstOrDefault(i => i.NewsID == newsId).NewsDate;
                    string newlink = NewsList2.FirstOrDefault(i => i.NewsID == newsId).NewsLink;
                    var newsShortLink = Class_Static.GoogleShortenLink(newlink);
                    string keyword = NewsList.FirstOrDefault(i => i.NewsID == newsId).KeywordName;
                    string message = newstitle + Environment.NewLine + sitetitle + "|" + newdate + Environment.NewLine + newsShortLink + Environment.NewLine + keyword;


                    SendToTelegramChannel(parminId, message);
                    string script = "alert(\"پیام شما با موفقیت ارسال شد.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else
                {
                    //string script = "alert(\"کانال تلگرام برای شما تعریف نشده است.\");";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('کانال تلگرام برای شما تعریف نشده است')", true);
                }
            }
        }
        protected void rptFehrest1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Class_Panels _clsPanel = new Class_Panels();
            if (e.CommandName == "sendTeleram")
            {
                string parminId = _clsPanel.GetParminById(Class_Layer.UserPanels()[0].Value).TelegramChannel2;

                if (parminId != null)
                {


                    int newsId = Convert.ToInt32(e.CommandArgument.ToString());

                    long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                    long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));
                    prepareData(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text, txtSeacrh.Text);
                    prepareData2(fromDateIndex, toDateIndex, txt_fromHour.Text, txt_toHour.Text, txtSeacrh.Text);

                    string sitetitle = NewsList.FirstOrDefault(i => i.NewsID == newsId).SiteTitle;
                    string newstime = NewsList.FirstOrDefault(i => i.NewsID == newsId).NewsTime;
                    string newstitle = NewsList.FirstOrDefault(i => i.NewsID == newsId).NewsTitle;
                    string newdate = NewsList.FirstOrDefault(i => i.NewsID == newsId).NewsDate;
                    string newlink = NewsList2.FirstOrDefault(i => i.NewsID == newsId).NewsLink;
                    var newsShortLink = Class_Static.GoogleShortenLink(newlink);
                    string keyword = NewsList.FirstOrDefault(i => i.NewsID == newsId).KeywordName;
                    string message = newstitle + Environment.NewLine + sitetitle + "|" + newdate + Environment.NewLine + newsShortLink + Environment.NewLine + keyword;


                    SendToTelegramChannel(parminId, message);
                    string script = "alert(\"پیام شما با موفقیت ارسال شد.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('کانال تلگرام برای شما تعریف نشده است')", true);
                }
            }
        }


    }
}