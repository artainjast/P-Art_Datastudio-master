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
using System.Drawing;
using static System.Web.UI.ClientScriptManager;


namespace P_Art.Pages.P_Art.Pages
{
    public partial class Social : System.Web.UI.Page
    {
#pragma warning disable CS0414 // The field 'Social.dsAllData' is assigned but its value is never used
        DataTable dsAllData = null;
#pragma warning restore CS0414 // The field 'Social.dsAllData' is assigned but its value is never used
        List<Class_SocialMedia> socialMediaList;
#pragma warning disable CS0169 // The field 'Social.socialkeywords' is never used
        List<socialkey> socialkeywords;
#pragma warning restore CS0169 // The field 'Social.socialkeywords' is never used
        List<int?> UserPanelList = new List<int?>();
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        string strSearch = "";
        Class_Zaman _clsZm = new Class_Zaman();
#pragma warning disable CS0169 // The field 'Social._firstIndex' is never used
#pragma warning disable CS0169 // The field 'Social._lastIndex' is never used
        int _firstIndex, _lastIndex;
#pragma warning restore CS0169 // The field 'Social._lastIndex' is never used
#pragma warning restore CS0169 // The field 'Social._firstIndex' is never used
#pragma warning disable CS0169 // The field 'Social.dt' is never used
        List<Tbl_SocialMediaPost> dt;
#pragma warning restore CS0169 // The field 'Social.dt' is never used

#pragma warning disable CS0414 // The field 'Social._pageSize' is assigned but its value is never used
        private int _pageSize = 50;
#pragma warning restore CS0414 // The field 'Social._pageSize' is assigned but its value is never used
        readonly PagedDataSource _pgsource = new PagedDataSource();
        List<Tbl_SocialMediaKey> keywordList = new List<Tbl_SocialMediaKey>();

        private Tuple<string, string> GenerateTags(List<Tbl_SocialMediaKey> keywords, string newsDateIndex, string keyIds)
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
                    var key = keywords.FirstOrDefault(t => t.SocialMediaKeyID == selKeyId);
                    if (key == null) continue;

                    finalKeyIds += "," + key.SocialMediaKeyID + ",";

                    findKeywords += "<a data-keyid='" + key.SocialMediaKeyID + "' data-text='" + key.Title + newsDateIndex + "&toDate=" + newsDateIndex + "&keyword=" + Server.HtmlEncode(key.Title.Replace("+", "&")) + "&recordCount=10000000' target='_blank'>" + key.Title + "</a>";
                }
                catch
                {
                    continue;
                }
            }


            return new Tuple<string, string>(Class_Static.PersianAlpha(findKeywords), finalKeyIds);
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

        protected void news_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //return;
            HtmlGenericControl _div = e.Item.FindControl("post") as HtmlGenericControl;
            if (_div == null) return;
            // HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            HiddenField hddNewsId = e.Item.FindControl("hddNewsId") as HiddenField;
            Literal ltTags = e.Item.FindControl("ltTags") as Literal;
            HiddenField hdfNewsTags = e.Item.FindControl("hdfNewsTags") as HiddenField;

            Class_SocialMedia newsData = (Class_SocialMedia)e.Item.DataItem;

            ////var panels = Class_Layer.UserPanels();
            if (UserPanelList.Count <= 3)
            {
                //var news = _clsNews.GetNewsById(Convert.ToInt32(fld_newsId.Value), false);
                //  var res = GenerateTags(keywordList, newsData.NewsTitle, newsData.NewsLead, newsData.NewsBody, newsData.KeywordId, newsData.NewsDateIndex, newsData.CreateUser);
                var res = GenerateTags(keywordList, newsData.PosteDateIndex + "", newsData.SocialMediaKeyID_FK.ToString());
                ltTags.Text = res.Item1;
                hdfNewsTags.Value = res.Item2;
            }
        }

        protected void rpt_Groups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlGenericControl _div = e.Item.FindControl("group_item") as HtmlGenericControl;
            if (_div == null) return;
            CheckBox cbx = e.Item.FindControl("check_selected_group") as CheckBox;
            Label cbx1 = e.Item.FindControl("lable1") as Label;
            if (cbx != null)
            {
                cbx.Attributes.Add("onclick", "sortArticleIndex();");
            }




        }
        protected void SocialKey_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlGenericControl _div = e.Item.FindControl("group_item") as HtmlGenericControl;
            if (_div == null) return;
            CheckBox cbx = e.Item.FindControl("check_selected_group") as CheckBox;
            Label cbx1 = e.Item.FindControl("lable1") as Label;
            if (cbx != null)
            {
                cbx.Attributes.Add("onclick", "sortArticleIndex();");
            }




        }


        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPanelList = Class_Layer.UserPanels();
                string UserPanelString = string.Empty;

                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }
                if (txt_fromDate.Text == "")
                    txt_fromDate.Text = _clsZm.Today();
                if (txt_toDate.Text == "")
                    txt_toDate.Text = _clsZm.Today();

                long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));



                //string keyids = string.Empty;

                //foreach (RepeaterItem item in rpt_Groups.Items)
                //{
                //    HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                //    CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                //    if (check_selected_group.Checked == true)
                //    {
                //        keyids += "," + hddsocialkeyid.Value;
                //    }
                //}
                //if (!String.IsNullOrWhiteSpace(keyids))
                //    keyids = keyids.Substring(1);

                //UserPanelList = Class_Layer.UserPanels();



                preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                            Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", "");

                var parmin = UserPanelList[0].Value + "";
                btn_generateGroupHtml.Attributes.Add("data-parmin", parmin);



            }
        }

        private void loadkeyword(List<Class_SocialMedia> dt)
        {


            //Tbl_SocialMediaKey _cls = new Tbl_SocialMediaKey();
            //Class_NewsGroup _cls = new Class_NewsGroup();
            var keyWords = keywordList.GroupBy(t => t.SocialMediaKeyID).Select(g => g.First()).ToList().Where(t => dt.Any(n => n.SocialMediaKeyID_FK == t.SocialMediaKeyID)).ToList();
            var parminIds = UserPanelList;// (Class_Layer.UserPanels());


            rpt_Groups.DataSource = keyWords;
            rpt_Groups.DataBind();


        }

        private void loadAllkeyword(List<Class_SocialMedia> dt)
        {


            var keyWords = keywordList.GroupBy(t => t.SocialMediaKeyID).Select(g => g.First()).ToList();
            var parminIds = UserPanelList;// (Class_Layer.UserPanels());

            SocialKeyCheckBox.DataSource = keyWords;
            SocialKeyCheckBox.DataBind();

        }
        public static string RemoveWeekDay(string txt)
        {

            var weeks = new string[] { "پنج‌شنبه", "چهارشنبه", "دو‌شنبه", "یک‌شنبه", "سه‌شنبه", "یک شنبه", "يكشنبه", "يک شنبه", "یکشنبه", "يکشنبه", "دوشنبه", "دو شنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "پنجشنبه", "جمعه", "شنبه" };
            foreach (var item in weeks)
            {
                txt = txt.Replace(item, "");
            }
            return txt;
        }
        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            try
            {
                UserPanelList = Class_Layer.UserPanels();
                string UserPanelString = string.Empty;

                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }
                string keyids = string.Empty;

                foreach (RepeaterItem item in SocialKeyCheckBox.Items)
                {
                    HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                    CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                    if (check_selected_group.Checked == true)
                    {
                        keyids += "," + hddsocialkeyid.Value;
                    }
                }
                if (!String.IsNullOrWhiteSpace(keyids))
                    keyids = keyids.Substring(1);

                UserPanelList = Class_Layer.UserPanels();



                preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                            Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", keyids);

            }
            catch { }

        }

        public static string DiffrentDate(string ddate)
        {
            //var nodeDash = Persia.PersianWord.ConvertToLatinNumber(RemoveWeekDay(ddate.Trim())).Trim()
            //                  .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            char[] letters = ddate.ToCharArray();

            var year1 = letters[0].ToString();
            var year2 = letters[1].ToString();
            var year3 = letters[2].ToString();
            var year4 = letters[3].ToString();
            var month1 = letters[4].ToString();
            var month2 = letters[5].ToString();
            var day1 = letters[6].ToString();
            var day2 = letters[7].ToString();
            var date = year1 + year2 + year3 + year4 + "/" + month1 + month2 + "/" + day1 + day2;
            return date;
        }



        private void preparedata(int PageCount, int PageIndex, string PanelIds, long Fromdate, long Todate, string Search, string Keyids)
        {
            DataTable result = new DataTable();



            UserPanelList = Class_Layer.UserPanels();





            if (Request.QueryString["keyword"] != null)
            {

                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                result = new Class_SocialMedia().GetData(10000, 1, PanelIds, Fromdate,
                       Todate, Request.QueryString["keyword"].ToString(), Keyids);



            }
            else
            {



                result = new Class_SocialMedia().GetData(10000, 1, PanelIds, Fromdate,
                       Todate, "", Keyids);




            }
            var dtNew = result.Copy();

            // List<Tbl_SocialMediaPost> newsList = Class_SocialMedia.GetFromDataRows(dtNew.Select());

            socialMediaList = Class_SocialMedia.GetFromDataRows(dtNew.Select());
            //_pgsource.DataSource = socialMediaList;//result.DefaultView;//
            //                                       //if (_pgsource.PageSize >= 50)
            //                                       //{
            //_pgsource.AllowPaging = true;
            //_pgsource.PageSize = _pageSize;
            ////}
            //_pgsource.CurrentPageIndex = CurrentPage;
            //// Keep the Total pages in View State
            //ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            //lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            //lbPrevious.Enabled = !_pgsource.IsFirstPage;
            //lbNext.Enabled = !_pgsource.IsLastPage;
            //lbFirst.Enabled = !_pgsource.IsFirstPage;
            //lbLast.Enabled = !_pgsource.IsLastPage;



            Class_SocialMedia _clsKeyword = new Class_SocialMedia();
            var keywords = new List<Tbl_SocialMediaKey>();
            keywords = _clsKeyword.GetRssKeywordByPanelIds(Class_Layer.UserPanels());
            keywordList = keywords;





            news_list.DataSource = socialMediaList;
            news_list.DataBind();
            //HandlePaging();
            loadkeyword(socialMediaList);

            loadAllkeyword(socialMediaList);

        }


        private void prepareLikedata(int PageCount, int PageIndex, string PanelIds, long Fromdate, long Todate, string Search, string Keyids)
        {
            DataTable result = new DataTable();




            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                result = new Class_SocialMedia().GetLikeData(10000, 1, PanelIds, Fromdate,
                       Todate, Request.QueryString["keyword"].ToString(), Keyids);



            }
            else
            {


                result = new Class_SocialMedia().GetLikeData(10000, 1, PanelIds, Fromdate,
                       Todate, "", Keyids);


            }
            var dtNew = result.Copy();

            // List<Tbl_SocialMediaPost> newsList = Class_SocialMedia.GetFromDataRows(dtNew.Select());


            //_pgsource.DataSource = Class_SocialMedia.GetFromDataRows(dtNew.Select());
            ////if (_pgsource.PageSize >= 50)
            ////{
            //_pgsource.AllowPaging = true;
            //_pgsource.PageSize = _pageSize;
            ////}
            //_pgsource.CurrentPageIndex = CurrentPage;

            //// Keep the Total pages in View State
            //ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            //lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            //lbPrevious.Enabled = !_pgsource.IsFirstPage;
            //lbNext.Enabled = !_pgsource.IsLastPage;
            //lbFirst.Enabled = !_pgsource.IsFirstPage;
            //lbLast.Enabled = !_pgsource.IsLastPage;




            socialMediaList = Class_SocialMedia.GetFromDataRows(dtNew.Select());

            news_list.DataSource = socialMediaList;
            //_pgsource;
            news_list.DataBind();
            //loadkeyword(socialMediaList);
            //HandlePaging();

        }
        private void prepareCommentdata(int PageCount, int PageIndex, string PanelIds, long Fromdate, long Todate, string Search, string Keyids)
        {
            DataTable result = new DataTable();




            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                result = new Class_SocialMedia().GetCommentData(10000, 1, PanelIds, Fromdate,
                       Todate, Request.QueryString["keyword"].ToString(), Keyids);



            }
            else
            {


                result = new Class_SocialMedia().GetCommentData(10000, 1, PanelIds, Fromdate,
                       Todate, "", Keyids);


            }
            var dtNew = result.Copy();

            // List<Tbl_SocialMediaPost> newsList = Class_SocialMedia.GetFromDataRows(dtNew.Select());


            //_pgsource.DataSource = Class_SocialMedia.GetFromDataRows(dtNew.Select());
            ////if (_pgsource.PageSize >= 50)
            ////{
            //_pgsource.AllowPaging = true;
            //_pgsource.PageSize = _pageSize;
            ////}
            //_pgsource.CurrentPageIndex = CurrentPage;
            //// Keep the Total pages in View State
            //ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            //lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            //lbPrevious.Enabled = !_pgsource.IsFirstPage;
            //lbNext.Enabled = !_pgsource.IsLastPage;
            //lbFirst.Enabled = !_pgsource.IsFirstPage;
            //lbLast.Enabled = !_pgsource.IsLastPage;




           socialMediaList = Class_SocialMedia.GetFromDataRows(dtNew.Select());

            news_list.DataSource = socialMediaList;
            //_pgsource;
            news_list.DataBind();
            //HandlePaging();

        }
        private void prepareRetweetdata(int PageCount, int PageIndex, string PanelIds, long Fromdate, long Todate, string Search, string Keyids)
        {
            DataTable result = new DataTable();




            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                result = new Class_SocialMedia().GetRetweetData(10000, 1, PanelIds, Fromdate,
                       Todate, Request.QueryString["keyword"].ToString(), "");



            }
            else
            {


                result = new Class_SocialMedia().GetRetweetData(10000, 1, PanelIds, Fromdate,
                       Todate, "", "");


            }
            var dtNew = result.Copy();

            // List<Tbl_SocialMediaPost> newsList = Class_SocialMedia.GetFromDataRows(dtNew.Select());


            //_pgsource.DataSource = Class_SocialMedia.GetFromDataRows(dtNew.Select());
            ////if (_pgsource.PageSize >= 50)
            ////{
            //_pgsource.AllowPaging = true;
            //_pgsource.PageSize = _pageSize;
            ////}

            //_pgsource.CurrentPageIndex = CurrentPage;
            //// Keep the Total pages in View State
            //ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            //lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            //lbPrevious.Enabled = !_pgsource.IsFirstPage;
            //lbNext.Enabled = !_pgsource.IsLastPage;
            //lbFirst.Enabled = !_pgsource.IsFirstPage;
            //lbLast.Enabled = !_pgsource.IsLastPage;




            socialMediaList = Class_SocialMedia.GetFromDataRows(dtNew.Select());

            news_list.DataSource = socialMediaList;
            //_pgsource;
            news_list.DataBind();
            // HandlePaging();
            //loadkeyword(socialMediaList);
        }


        private void prepareRetweetdata1(int PageCount, int PageIndex, string PanelIds, long Fromdate, long Todate, string Search, string Keyids)
        {
            DataTable result = new DataTable();




            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                result = new Class_SocialMedia().GetRetweetData(10000, 1, PanelIds, Fromdate,
                       Todate, Request.QueryString["keyword"].ToString(), Keyids);



            }
            else
            {


                result = new Class_SocialMedia().GetRetweetData(10000, 1, PanelIds, Fromdate,
                       Todate, "", Keyids);


            }
            var dtNew = result.Copy();

            // List<Tbl_SocialMediaPost> newsList = Class_SocialMedia.GetFromDataRows(dtNew.Select());


            //_pgsource.DataSource = Class_SocialMedia.GetFromDataRows(dtNew.Select());
            ////if (_pgsource.PageSize >= 50)
            ////{
            //_pgsource.AllowPaging = true;
            //_pgsource.PageSize = _pageSize;
            ////}
            //_pgsource.CurrentPageIndex = CurrentPage;
            //// Keep the Total pages in View State
            //ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            //lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            //lbPrevious.Enabled = !_pgsource.IsFirstPage;
            //lbNext.Enabled = !_pgsource.IsLastPage;
            //lbFirst.Enabled = !_pgsource.IsFirstPage;
            //lbLast.Enabled = !_pgsource.IsLastPage;




            socialMediaList = Class_SocialMedia.GetFromDataRows(dtNew.Select());

            news_list.DataSource = socialMediaList;
            //_pgsource;
            //_pgsource;
            news_list.DataBind();
            //HandlePaging();
            //loadkeyword(socialMediaList);
        }


        //private void HandlePaging()
        //{
        //    var dt = new DataTable();
        //    dt.Columns.Add("PageIndex"); //Start from 0
        //    dt.Columns.Add("PageText"); //Start from 1

        //    _firstIndex = CurrentPage - 5;
        //    if (CurrentPage > 5)
        //        _lastIndex = CurrentPage + 5;
        //    else
        //        _lastIndex = 10;

        //    // Check last page is greater than total page then reduced it 
        //    // to total no. of page is last index
        //    if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        //    {
        //        _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
        //        _firstIndex = _lastIndex - 10;
        //    }

        //    if (_firstIndex < 0)
        //        _firstIndex = 0;

        //    // Now creating page number based on above first and last page index
        //    for (var i = _firstIndex; i < _lastIndex; i++)
        //    {
        //        var dr = dt.NewRow();
        //        dr[0] = i;
        //        dr[1] = i + 1;
        //        dt.Rows.Add(dr);
        //    }

        //    rptPaging.DataSource = dt;
        //    rptPaging.DataBind();
        //}
        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            UserPanelList = Class_Layer.UserPanels();
            string UserPanelString = string.Empty;

            if (UserPanelList != null)
            {
                foreach (var i in UserPanelList)
                {
                    UserPanelString += "," + i;
                }
                if (!String.IsNullOrWhiteSpace(UserPanelString))
                    UserPanelString = UserPanelString.Substring(1);
            }
            preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                        Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", "");
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            UserPanelList = Class_Layer.UserPanels();
            string UserPanelString = string.Empty;

            if (UserPanelList != null)
            {
                foreach (var i in UserPanelList)
                {
                    UserPanelString += "," + i;
                }
                if (!String.IsNullOrWhiteSpace(UserPanelString))
                    UserPanelString = UserPanelString.Substring(1);
            }
            preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                        Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", "");
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            UserPanelList = Class_Layer.UserPanels();
            string UserPanelString = string.Empty;

            if (UserPanelList != null)
            {
                foreach (var i in UserPanelList)
                {
                    UserPanelString += "," + i;
                }
                if (!String.IsNullOrWhiteSpace(UserPanelString))
                    UserPanelString = UserPanelString.Substring(1);
            }
            preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                        Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", "");
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            UserPanelList = Class_Layer.UserPanels();
            string UserPanelString = string.Empty;

            if (UserPanelList != null)
            {
                foreach (var i in UserPanelList)
                {
                    UserPanelString += "," + i;
                }
                if (!String.IsNullOrWhiteSpace(UserPanelString))
                    UserPanelString = UserPanelString.Substring(1);
            }
            preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                        Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", "");
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            UserPanelList = Class_Layer.UserPanels();
            string UserPanelString = string.Empty;

            if (UserPanelList != null)
            {
                foreach (var i in UserPanelList)
                {
                    UserPanelString += "," + i;
                }
                if (!String.IsNullOrWhiteSpace(UserPanelString))
                    UserPanelString = UserPanelString.Substring(1);
            }

            string keyids = string.Empty;

            foreach (RepeaterItem item in rpt_Groups.Items)
            {
                HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                if (check_selected_group.Checked == true)
                {
                    keyids += "," + hddsocialkeyid.Value;
                }
            }
            if (!String.IsNullOrWhiteSpace(keyids))
                keyids = keyids.Substring(1);

            UserPanelList = Class_Layer.UserPanels();



            preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                        Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", keyids);
        }


        protected void btnRetweet_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    string keyids = string.Empty;

                    foreach (RepeaterItem item in rpt_Groups.Items)
                    {
                        HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                        CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                        if (check_selected_group.Checked == true)
                        {
                            keyids += "," + hddsocialkeyid.Value;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(keyids))
                        keyids = keyids.Substring(1);
                    //Label cbx = f.Item.FindControl("lable1") as Label;
                    //if (cbx != null)
                    //{
                    UserPanelList = Class_Layer.UserPanels();
                    string UserPanelString = string.Empty;

                    if (UserPanelList != null)
                    {
                        foreach (var i in UserPanelList)
                        {
                            UserPanelString += "," + i;
                        }
                        if (!String.IsNullOrWhiteSpace(UserPanelString))
                            UserPanelString = UserPanelString.Substring(1);
                    }
                    prepareRetweetdata1(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                          Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", keyids);

                }
                //}
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used

            }
            //else
            //{
            //    try
            //    {
            //        UserPanelList = Class_Layer.UserPanels();
            //        string UserPanelString = string.Empty;

            //        if (UserPanelList != null)
            //        {
            //            foreach (var i in UserPanelList)
            //            {
            //                UserPanelString += "," + i;
            //            }
            //            if (!String.IsNullOrWhiteSpace(UserPanelString))
            //                UserPanelString = UserPanelString.Substring(1);
            //        }
            //        prepareRetweetdata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
            //              Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", "");
            //    }
            //    catch { }


            //}
        }

        protected void btnlike_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    string keyids = string.Empty;

                    foreach (RepeaterItem item in rpt_Groups.Items)
                    {
                        HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                        CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                        if (check_selected_group.Checked == true)
                        {
                            keyids += "," + hddsocialkeyid.Value;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(keyids))
                        keyids = keyids.Substring(1);
                    //Label cbx = f.Item.FindControl("lable1") as Label;
                    //if (cbx != null)
                    //{
                    UserPanelList = Class_Layer.UserPanels();
                    string UserPanelString = string.Empty;

                    if (UserPanelList != null)
                    {
                        foreach (var i in UserPanelList)
                        {
                            UserPanelString += "," + i;
                        }
                        if (!String.IsNullOrWhiteSpace(UserPanelString))
                            UserPanelString = UserPanelString.Substring(1);
                    }
                    prepareLikedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                          Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", keyids);

                }
                //}
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used

            }
            //else
            //{
            //    try
            //    {
            //        UserPanelList = Class_Layer.UserPanels();
            //        string UserPanelString = string.Empty;

            //        if (UserPanelList != null)
            //        {
            //            foreach (var i in UserPanelList)
            //            {
            //                UserPanelString += "," + i;
            //            }
            //            if (!String.IsNullOrWhiteSpace(UserPanelString))
            //                UserPanelString = UserPanelString.Substring(1);
            //        }
            //        prepareLikedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
            //              Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", "");
            //    }
            //    catch { }
            //}
        }

        protected void btncm_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    string keyids = string.Empty;

                    foreach (RepeaterItem item in rpt_Groups.Items)
                    {
                        HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                        CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                        if (check_selected_group.Checked == true)
                        {
                            keyids += "," + hddsocialkeyid.Value;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(keyids))
                        keyids = keyids.Substring(1);
                    //Label cbx = f.Item.FindControl("lable1") as Label;
                    //if (cbx != null)
                    //{
                    UserPanelList = Class_Layer.UserPanels();
                    string UserPanelString = string.Empty;

                    if (UserPanelList != null)
                    {
                        foreach (var i in UserPanelList)
                        {
                            UserPanelString += "," + i;
                        }
                        if (!String.IsNullOrWhiteSpace(UserPanelString))
                            UserPanelString = UserPanelString.Substring(1);
                    }
                    prepareCommentdata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                          Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", keyids);

                }
                //}
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnmatn_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserPanelList = Class_Layer.UserPanels();
                string UserPanelString = string.Empty;

                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }
                if (txt_fromDate.Text == "")
                    txt_fromDate.Text = _clsZm.Today();
                if (txt_toDate.Text == "")
                    txt_toDate.Text = _clsZm.Today();

                long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));

                string keyids = string.Empty;

                foreach (RepeaterItem item in rpt_Groups.Items)
                {
                    HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                    CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                    if (check_selected_group.Checked == true)
                    {
                        keyids += "," + hddsocialkeyid.Value;
                    }
                }
                if (!String.IsNullOrWhiteSpace(keyids))
                    keyids = keyids.Substring(1);

                UserPanelList = Class_Layer.UserPanels();



                preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                            Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", keyids);

                var parmin = UserPanelList[0].Value + "";
                btn_generateGroupHtml.Attributes.Add("data-parmin", parmin);



            }

        }

        protected void btnfilter_Click(object sender, EventArgs e)
        {
            string UserPanelString = string.Empty;

            if (UserPanelList != null)
            {
                foreach (var i in UserPanelList)
                {
                    UserPanelString += "," + i;
                }
                if (!String.IsNullOrWhiteSpace(UserPanelString))
                    UserPanelString = UserPanelString.Substring(1);
            }
            string keyids = string.Empty;

            foreach (RepeaterItem item in rpt_Groups.Items)
            {
                HiddenField hddsocialkeyid = (HiddenField)item.FindControl("hddsocialkeyid");
                CheckBox check_selected_group = (CheckBox)item.FindControl("check_selected_group");
                if (check_selected_group.Checked == true)
                {
                    keyids += "," + hddsocialkeyid.Value;
                }
            }
            if (!String.IsNullOrWhiteSpace(keyids))
                keyids = keyids.Substring(1);

            UserPanelList = Class_Layer.UserPanels();



            preparedata(10000, 1, UserPanelString, Convert.ToInt64(txt_fromDate.Text.Replace("/", "")),
                        Convert.ToInt64(txt_toDate.Text.Replace("/", "")), "", keyids);

        }



        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#4caf50");
            //lnkPage.ForeColor= Color.FromName("#FFFFFF");
            // lnkPage.BorderColor = Color.FromName("#68bfe0");
        }
    }
}