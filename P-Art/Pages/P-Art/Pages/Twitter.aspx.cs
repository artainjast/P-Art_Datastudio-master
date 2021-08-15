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
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Twitter : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<Tbl_TwitterPost> TwitterPostList = new List<Tbl_TwitterPost>();
        List<Tbl_TwitterKeywords> TwitterKeyword = new List<Tbl_TwitterKeywords>();
        List<int?> UserPanelList = new List<int?>();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
#pragma warning disable CS0169 // The field 'Twitter.staticfromDateIndex' is never used
        static int staticfromDateIndex;
#pragma warning restore CS0169 // The field 'Twitter.staticfromDateIndex' is never used
#pragma warning disable CS0169 // The field 'Twitter.statictoDateIndex' is never used
        static int statictoDateIndex;
#pragma warning restore CS0169 // The field 'Twitter.statictoDateIndex' is never used
        public Tbl_Parmin ParminTable = new Tbl_Parmin();

        int userPanelId = 0;
        List<int> panelActivTwitterKeyIds = new List<int>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] != null)
            {
                if (bool.Parse(Session["IsAdmin"].ToString()) == true)
                {
                    keywordPageButton.Visible = true;
                    keywordPageButton.HRef = "/TwitterKeywords/";

                }
                else
                {
                    keywordPageButton.Visible = false;
                }
            }
            else
            {
                keywordPageButton.Visible = false;
            }
            Class_Layer.CheckSession();
            UserPanelList = Class_Layer.UserPanels();
            ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

            if (ParminTable.AccessTwitter == false)
            {
                HttpContext.Current.Response.Redirect("~/Welcome/");
            }

            panelActivTwitterKeyIds.AddRange(_db.Tbl_TwitterKeywords.Where(k => k.Active == true && k.PanelID == userPanelId && ParminTable.AccessTwitter == true).Select(k => k.ID).ToList());

            if (!IsPostBack)
            {
                string searchStrig = "";
                string keyIds = "";
                bool isFilter = false;

                if (Request.QueryString["keyword"] != null)
                {
                    searchStrig = Request.QueryString["keyword"].ToString().Replace("ي", "ی").Replace("ك", "ک");
                    txt_search.Text = searchStrig.Replace("|", "+").Trim();
                    isFilter = true;
                }

                long fromDateTime = long.Parse(_clsZm.Today().Replace("/", "") + "0000");
                long toDateTime = long.Parse(_clsZm.Today().Replace("/", "") + "2500");

                if (Request.QueryString["from"] != null)
                {
                    try
                    {
                        fromDateTime = long.Parse(Request.QueryString["from"].ToString());
                        isFilter = true;

                    }
                    catch
                    { }

                }
                if (Request.QueryString["to"] != null)
                {
                    try
                    {
                        toDateTime = long.Parse(Request.QueryString["to"].ToString());
                        isFilter = true;
                    }
                    catch
                    { }

                }

                if (Request.QueryString["keyids"] != null)
                {
                    try
                    {
                        keyIds = Request.QueryString["keyids"].ToString().Trim();
                        isFilter = true;
                    }
                    catch
                    { }


                }


                string UserPanelString = string.Empty;

                if (txt_fromDate.Text == "")
                    txt_fromDate.Text = _clsZm.Today();
                if (txt_toDate.Text == "")
                    txt_toDate.Text = _clsZm.Today();

                if (UserPanelList != null)
                {
                    foreach (var i in UserPanelList)
                    {
                        UserPanelString += "," + i;
                    }
                    if (!String.IsNullOrWhiteSpace(UserPanelString))
                        UserPanelString = UserPanelString.Substring(1);
                }

                txt_fromDate.Text = fromDateTime.ToString().Substring(0, 4) + "/" + fromDateTime.ToString().Substring(4, 2) + "/" + fromDateTime.ToString().Substring(6, 2);
                txt_toDate.Text = toDateTime.ToString().Substring(0, 4) + "/" + toDateTime.ToString().Substring(4, 2) + "/" + toDateTime.ToString().Substring(6, 2);

                string controlTime = "";
                if ((toDateTime / 100) % 100 > 24)
                {
                    controlTime = "";
                }
                else
                {
                    controlTime = toDateTime.ToString().Substring(8, 2) + ":";
                }
                if (string.IsNullOrEmpty(controlTime))
                {
                    txt_fromHour.Text = "";
                    txt_toHour.Text = "";
                }
                else
                {
                    controlTime += toDateTime.ToString().Substring(10, 2);
                    txt_toHour.Text = controlTime;
                    txt_fromHour.Text = fromDateTime.ToString().ToString().Substring(8, 2) + ":" + fromDateTime.ToString().Substring(10, 2);
                }

                List<int> Keys = new List<int>();
                foreach (var keySpil in keyIds.Split(','))
                {
                    try
                    {
                        Keys.Add(Convert.ToInt32(keySpil));
                    }
                    catch
                    {
                        continue;
                    }
                }


                //Class_Layer.CheckSession();
                UserPanelList = Class_Layer.UserPanels();
                var parmin = UserPanelList[0].Value + "";
                NewsIdParminId.Value = parmin;



                PrepareTwitterPost(fromDateTime, toDateTime, keyIds, searchStrig, isFilter);

                PrepareKeyCheckBox();
            }

        }

        private void PrepareTwitterPost(long fromDateTimeIndex, long toDateTimeIndex, string keyIds, string searchString, bool isFilter)
        {
            List<int> Keys = new List<int>();
            foreach (var keySpil in keyIds.Split(','))
            {
                try
                {
                    Keys.Add(Convert.ToInt32(keySpil));
                }
                catch
                {
                    continue;
                }
            }

            if (Keys.Count > 0) // By Time
            {
                if (!string.IsNullOrEmpty(searchString))
                {

                    List<long> messageList = new List<long>();
                    List<long> searchResult = new List<long>();

                    messageList = (from Post in _db.Tbl_TwitterPost
                                   where panelActivTwitterKeyIds.Contains(Post.KeywordID) && UserPanelList.Contains(Post.PanelID) && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex && Keys.Contains(Post.KeywordID) && Post.Active == true
                                   select Post.ID).ToList();

                    searchResult = SearchPhraseInNews(messageList, searchString);

                    TwitterPostList = (from Post in _db.Tbl_TwitterPost
                                       where searchResult.Contains(Post.ID)
                                       orderby Post.DateTimeIndex descending
                                       select Post).ToList();
                }
                else
                {
                    if (isFilter)
                    {
                        TwitterPostList = (from Post in _db.Tbl_TwitterPost
                                           where panelActivTwitterKeyIds.Contains(Post.KeywordID) && UserPanelList.Contains(Post.PanelID) && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex && Keys.Contains(Post.KeywordID) && Post.Active == true
                                           orderby Post.DateTimeIndex descending
                                           select Post).ToList();
                    }
                    else
                    {
                        TwitterPostList = (from Post in _db.Tbl_TwitterPost
                                           where panelActivTwitterKeyIds.Contains(Post.KeywordID) && UserPanelList.Contains(Post.PanelID) && Keys.Contains(Post.KeywordID) && Post.Active == true
                                           orderby Post.DateTimeIndex descending
                                           select Post).Take(200).ToList();
                    }
                    
                }
            }

            else
            {
                if (!string.IsNullOrEmpty(searchString))
                {

                    List<long> messageList = new List<long>();
                    List<long> searchResult = new List<long>();

                    messageList = (from Post in _db.Tbl_TwitterPost
                                   where panelActivTwitterKeyIds.Contains(Post.KeywordID) && UserPanelList.Contains(Post.PanelID) && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex  && Post.Active == true
                                   select Post.ID).ToList();

                    searchResult = SearchPhraseInNews(messageList, searchString);

                    TwitterPostList = (from Post in _db.Tbl_TwitterPost
                                       where searchResult.Contains(Post.ID)
                                       orderby Post.DateTimeIndex descending
                                       select Post).ToList();
                }
                else
                {
                    if (isFilter)
                    {
                        TwitterPostList = (from Post in _db.Tbl_TwitterPost
                                           where panelActivTwitterKeyIds.Contains(Post.KeywordID) && UserPanelList.Contains(Post.PanelID) && Post.DateTimeIndex >= fromDateTimeIndex && Post.DateTimeIndex <= toDateTimeIndex && Post.Active == true
                                           orderby Post.DateTimeIndex descending
                                           select Post).ToList();
                    }
                    else
                    {
                        TwitterPostList = (from Post in _db.Tbl_TwitterPost
                                           where panelActivTwitterKeyIds.Contains(Post.KeywordID) && UserPanelList.Contains(Post.PanelID) && Post.Active == true
                                           orderby Post.DateTimeIndex descending
                                           select Post).Take(200).ToList();
                    }
                    
                }
            }


            Session.Add("TwitterPostList", TwitterPostList);

            TwitterMassageRepeater.DataSource = TwitterPostList;
            TwitterMassageRepeater.DataBind();
        }

        private void PrepareKeyCheckBox()
        {
            int parmin = int.Parse(UserPanelList[0].Value + "");
            var keyWords = _db.Tbl_TwitterKeywords.Where(k => k.PanelID == parmin && k.Active == true).ToList();

            SocialKeyCheckBox.DataSource = keyWords;
            SocialKeyCheckBox.DataBind();
        }

        public string GetKeywordName(int KeyId)
        {
            string keyName = _db.Tbl_TwitterKeywords.Where(K => K.ID == KeyId).Select(k => k.Title).FirstOrDefault();
            return keyName;
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

        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            try
            {
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

                string url = "";

                if (txt_fromDate.Text != "")
                {
                    url = "from=" + txt_fromDate.Text.Replace("/", "");

                    if (txt_fromHour.Text != "")
                    {
                        url += Server.HtmlEncode(txt_fromHour.Text.Trim().Replace(":", "")) + "&";
                    }
                    else
                    {
                        url += "0000&";
                    }

                }


                if (txt_toDate.Text != "")
                {
                    url += "to=" + txt_toDate.Text.Replace("/", "");

                    if (txt_fromHour.Text != "")
                    {
                        url += Server.HtmlEncode(txt_toHour.Text.Trim().Replace(":", "")) + "&";
                    }
                    else
                    {
                        url += "2500&";
                    }

                }


                if (txt_search.Text.Trim() != "")
                {
                    url += "keyword=" + Server.HtmlEncode(txt_search.Text.Trim().Replace("+", "|")) + "&";
                }

                if (!string.IsNullOrEmpty(keyids))
                {
                    url += "keyids=" + keyids + "&";
                }



                url = url.Substring(0, url.Length - 1);
                Response.Redirect("/Twitter/?" + url);





            }
            catch { }

        }

        protected void RetweetSortButton_Click(object sender, EventArgs e)
        {
            TwitterPostList.Clear();
            TwitterPostList = ((List<Tbl_TwitterPost>)Session["TwitterPostList"]).OrderByDescending(t => t.RetweetCount).ToList();
            TwitterMassageRepeater.DataSource = null;
            TwitterMassageRepeater.DataSource = TwitterPostList;
            TwitterMassageRepeater.DataBind();
        }
        protected void ReplySortButton_Click(object sender, EventArgs e)
        {
            TwitterPostList.Clear();
            TwitterPostList = ((List<Tbl_TwitterPost>)Session["TwitterPostList"]).OrderByDescending(t => t.ReplyCount).ToList();
            TwitterMassageRepeater.DataSource = null;
            TwitterMassageRepeater.DataSource = TwitterPostList;
            TwitterMassageRepeater.DataBind();
        }

        protected void FavoriteSortButton_Click(object sender, EventArgs e)
        {
            TwitterPostList.Clear();
            TwitterPostList = ((List<Tbl_TwitterPost>)Session["TwitterPostList"]).OrderByDescending(t => t.FavoriteCount).ToList();
            TwitterMassageRepeater.DataSource = null;
            TwitterMassageRepeater.DataSource = TwitterPostList;
            TwitterMassageRepeater.DataBind();
        }

        protected void DateTimeSortButton_Click(object sender, EventArgs e)
        {
            TwitterPostList.Clear();
            TwitterPostList = ((List<Tbl_TwitterPost>)Session["TwitterPostList"]).OrderByDescending(t => t.DateTimeIndex).ToList();
            TwitterMassageRepeater.DataSource = null;
            TwitterMassageRepeater.DataSource = TwitterPostList;
            TwitterMassageRepeater.DataBind();
        }


        private List<long> SearchPhraseInNews(List<long> TwitterIds, string searchText)
        {
            List<long> result = new List<long>();
            string str1 = "";
            string str2 = "";
            string str3 = "";

            if (searchText.Contains("|"))
            {
                var SearchParameterList = searchText.Split('|');


                if (SearchParameterList.Count() == 2)
                {
                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];

                    result = _db.Tbl_TwitterPost.Where(n => TwitterIds.Contains(n.ID) && n.Text.Contains(str1) && n.Text.Contains(str2)).Select(n => n.ID).ToList();

                }
                else if (SearchParameterList.Count() == 3)
                {

                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    str3 = SearchParameterList[2];


                    result = _db.Tbl_TwitterPost.Where(n => TwitterIds.Contains(n.ID) && n.Text.Contains(str1) && n.Text.Contains(str2) && n.Text.Contains(str3)).Select(n => n.ID).ToList();

                }

            }
            else
            {
                result = _db.Tbl_TwitterPost.Where(n => TwitterIds.Contains(n.ID) && n.Text.Contains(searchText)).Select(n => n.ID).ToList();
            }

            return result;
        }



        [WebMethod]
        public static string CreateTwitterBultan(string fromDate, string toDate, string parmin, string SelectedPostIds, string bultanTitle, string linkUrl)
        {
            try
            {
                bultanTitle = Class_Static.ConvertToLatinNumberSam(bultanTitle);
                PersianCalendar pc = new PersianCalendar();
                long dateTimeIndex = long.Parse(pc.GetYear(DateTime.Now).ToString("0000") + pc.GetMonth(DateTime.Now).ToString("00") + pc.GetDayOfMonth(DateTime.Now).ToString("00"));
                SelectedPostIds = SelectedPostIds.Substring(1);
                if (string.IsNullOrEmpty(bultanTitle))
                {
                    bultanTitle = "فاقد عنوان";
                }
                Tbl_BultanArchive BultanArchive = new Tbl_BultanArchive
                {
                    NewsDateIndex = dateTimeIndex,
                    PanelId = int.Parse(parmin),
                    Path = @"" + linkUrl + "/HTMLTwitterReport.aspx?ArchiveId=",
                    Name = bultanTitle,
                    SelectedNews = SelectedPostIds,
                    CreateDate = DateTime.Now,
                    AllowNewspaper = false,
                    AllowGalleryNewspaper = false,
                    AllowChart = false,
                    IsArchive = false,
                    AllowHighlight = false,
                    AllowRelated = false,
                    FromDateIndex = fromDate.Replace("/", ""),
                    ToDateIndex = toDate.Replace("/", ""),
                    FromTimeIndex = "",
                    ToTimeIndex = "",
                    AllowGroup = false,
                    AllowJeld = false,
                    AllowArz = false,
                    AllowSima = false,
                    BultanType = 9
                };

                _dbStatic.Tbl_BultanArchive.Add(BultanArchive);
                _dbStatic.SaveChanges();

                BultanArchive.Path += BultanArchive.ArchiveId.ToString();
                _dbStatic.SaveChanges();

                return BultanArchive.Path;

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [WebMethod]
        public static void SetNewsValue(string idString, string valueString)
        {
            try
            {
                var value = Convert.ToByte(valueString);
                var id = Convert.ToInt32(idString);

                var twitterTable = _dbStatic.Tbl_TwitterPost.FirstOrDefault(t => t.ID == id);
                twitterTable.NewsValue = value;

                _dbStatic.SaveChanges();
            }
            catch (Exception)
            {
            }



        }

        public static string NewsRateOpacity(object newsValue, string MustValue)
        {
            var value = Convert.ToString(newsValue);
            if (string.IsNullOrEmpty(value))
            {
                if (MustValue == "0")
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.3";
                }
            }
            else
            {
                if (value == MustValue)
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.3";
                }
            }
        }

    }
}