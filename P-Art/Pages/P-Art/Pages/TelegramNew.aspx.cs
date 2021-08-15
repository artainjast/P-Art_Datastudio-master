using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class TelegramNew : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<Tbl_TLPMessage> TelegramMassageList = new List<Tbl_TLPMessage>();
        List<Tbl_TLPKeywords> TelegramKeyword = new List<Tbl_TLPKeywords>();
        List<int?> UserPanelList = new List<int?>();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();

        public Tbl_Parmin ParminTable = new Tbl_Parmin();

        int userPanelId = 0;

        List<int> panelActivTelegramKeyIds = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] != null)
                if (bool.Parse(Session["IsAdmin"].ToString()) == true)
                {
                    keywordPageButton.Visible = true;
                    keywordPageButton.HRef = "/TelegramKeywords/";

                }
                else
                {
                    keywordPageButton.Visible = false;
                }
            else
                keywordPageButton.Visible = false;
            Class_Layer.CheckSession();
            UserPanelList = Class_Layer.UserPanels();
            ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;
            if (ParminTable.AccessTelegram == false)
            {
                HttpContext.Current.Response.Redirect("~/Welcome/");
            }
            var keywordActiveList = _db.Tbl_TLPKeywords.Where(k => k.Active == true && k.ParminId == userPanelId && ParminTable.AccessTelegram == true).ToList();
            panelActivTelegramKeyIds.AddRange(keywordActiveList.Select(k => k.ID).ToList());

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
                //UserPanelList = Class_Layer.UserPanels();
                //var parmin = UserPanelList[0].Value + "";
                NewsIdParminId.Value = userPanelId.ToString();



                PrepareTelegramMassage(fromDateTime, toDateTime, keyIds, searchStrig, isFilter, userPanelId);

                PrepareKeyCheckBox(keywordActiveList);
            }

        }

        private void PrepareTelegramMassage(long fromDateTimeIndex, long toDateTimeIndex, string keyIds, string searchString, bool isFilterd , int ParminId)
        {
            _db = new DB_NewsCenterEntities();
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
            if (Keys.Count > 0)
            {

                if (!string.IsNullOrEmpty(searchString))
                {

                    List<long> messageList = new List<long>();
                    List<long> searchResult = new List<long>();

                    messageList = (from Massage in _db.Tbl_TLPMessage
                                   where panelActivTelegramKeyIds.Contains(Massage.KeywordID) && UserPanelList.Contains(Massage.PanelID) && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex && Keys.Contains(Massage.KeywordID)
                                   select Massage.ID).ToList();


                    searchResult = SearchPhraseInNews(messageList, searchString);

                    TelegramMassageList = (from Massage in _db.Tbl_TLPMessage
                                           where searchResult.Contains(Massage.ID)
                                           orderby Massage.DateTimeIndex descending
                                           select Massage).ToList();

                }
                else
                {
                    if (isFilterd)
                    {
                        TelegramMassageList = (from Massage in _db.Tbl_TLPMessage
                                               where panelActivTelegramKeyIds.Contains(Massage.KeywordID) && UserPanelList.Contains(Massage.PanelID) && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex && Keys.Contains(Massage.KeywordID)
                                               orderby Massage.DateTimeIndex descending
                                               select Massage).ToList();
                    }
                    else
                    {
                        TelegramMassageList = (from Massage in _db.Tbl_TLPMessage
                                               where panelActivTelegramKeyIds.Contains(Massage.KeywordID) && UserPanelList.Contains(Massage.PanelID) && Keys.Contains(Massage.KeywordID)
                                               orderby Massage.DateTimeIndex descending
                                               select Massage).Take(200).ToList();
                    }


                }
            }

            else
            {
                if (!string.IsNullOrEmpty(searchString))
                {

                    List<long> messageList = new List<long>();
                    List<long> searchResult = new List<long>();

                    messageList = (from Massage in _db.Tbl_TLPMessage
                                   where panelActivTelegramKeyIds.Contains(Massage.KeywordID) && UserPanelList.Contains(Massage.PanelID) && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                                   select Massage.ID).ToList();


                    searchResult = SearchPhraseInNews(messageList, searchString);

                    TelegramMassageList = (from Massage in _db.Tbl_TLPMessage
                                           where searchResult.Contains(Massage.ID)
                                           orderby Massage.DateTimeIndex descending
                                           select Massage).ToList();
                }
                else
                {
                    if (isFilterd)
                    {
                        //TelegramMassageList = (from Massage in _db.Tbl_TLPMessage
                        //                       where panelActivTelegramKeyIds.Contains(Massage.KeywordID) && UserPanelList.Contains(Massage.PanelID) && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                        //                       orderby Massage.DateTimeIndex descending
                        //                       select Massage).ToList();
                        TelegramMassageList = _db.Tbl_TLPMessage.Where(i => i.PanelID == userPanelId && i.DateTimeIndex >= fromDateTimeIndex && i.DateTimeIndex <= toDateTimeIndex).OrderByDescending(i => i.DateTimeIndex).ToList();
                    }
                    else
                    {
                        
                        TelegramMassageList = _db.Tbl_TLPMessage.Where(i => i.PanelID == userPanelId).OrderByDescending(i => i.DateTimeIndex).Take(200).ToList();
                        //TelegramMassageList = (from Massage in _db.Tbl_TLPMessage
                        //                       where panelActivTelegramKeyIds.Contains(Massage.KeywordID) && Massage.PanelID == UserPanelList[0]
                        //                       orderby Massage.DateTimeIndex descending
                        //                       select Massage).Take(200).ToList();
                    }

                }
            }


            TelegramMassageRepeater.DataSource = TelegramMassageList;
            TelegramMassageRepeater.DataBind();
        }



        private List<long> SearchPhraseInNews(List<long> TelegramIds, string searchText)
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
                    //List<long> FirstSearchResult = new List<long>();

                    //FirstSearchResult = _db.Tbl_TLPMessage.Where(n => ids.Contains(n.ID) && (n.MessageText.Contains(str1) )).Select(n => n.ID).ToList();
                    //result = _db.Tbl_TLPMessage.Where(n => FirstSearchResult.Contains(n.ID) && (n.MessageText.Contains(str2) )).Select(n => n.ID).ToList();

                    result = _db.Tbl_TLPMessage.Where(n => TelegramIds.Contains(n.ID) && n.MessageText.Contains(str1) && n.MessageText.Contains(str2)).Select(n => n.ID).ToList();

                }
                else if (SearchParameterList.Count() == 3)
                {

                    str1 = SearchParameterList[0];
                    str2 = SearchParameterList[1];
                    str3 = SearchParameterList[2];


                    //List<long> FirstSearchResult = new List<long>();
                    //List<long> SecondSearchResult = new List<long>();

                    //FirstSearchResult = _db.Tbl_News.Where(n => newsIds.Contains(n.NewsID) && (n.NewsTitle.Contains(str1) || n.NewsLead.Contains(str1) || n.NewsBody.Contains(str1))).Select(n => n.NewsID).ToList();
                    //SecondSearchResult = _db.Tbl_News.Where(n => FirstSearchResult.Contains(n.NewsID) && (n.NewsTitle.Contains(str2) || n.NewsLead.Contains(str2) || n.NewsBody.Contains(str2))).Select(n => n.NewsID).ToList();
                    //result = _db.Tbl_News.Where(n => SecondSearchResult.Contains(n.NewsID) && (n.NewsTitle.Contains(str3) || n.NewsLead.Contains(str3) || n.NewsBody.Contains(str3))).Select(n => n.NewsID).ToList();

                    result = _db.Tbl_TLPMessage.Where(n => TelegramIds.Contains(n.ID) && n.MessageText.Contains(str1) && n.MessageText.Contains(str2) && n.MessageText.Contains(str3)).Select(n => n.ID).ToList();

                }

            }
            else
            {
                result = _db.Tbl_TLPMessage.Where(n => TelegramIds.Contains(n.ID) && n.MessageText.Contains(searchText)).Select(n => n.ID).ToList();
            }

            return result;
        }


        private void PrepareKeyCheckBox(List<Tbl_TLPKeywords> keywords)
        {
            //int parmin = int.Parse(UserPanelList[0].Value + "");
           // var keyWords = _db.Tbl_TLPKeywords.Where(k => k.ParminId == parmin && k.Active == true).ToList();

            SocialKeyCheckBox.DataSource = keywords;
            SocialKeyCheckBox.DataBind();
        }

        public string GetKeywordName(int KeyId)
        {
            string keyName = _db.Tbl_TLPKeywords.Where(K => K.ID == KeyId).Select(k => k.Title).FirstOrDefault();
            return keyName;
        }

        public string GetChannelName(int ChannelID)
        {
            string ChannelName = _db.Tbl_TLPChannels.Where(C => C.ChannelID == ChannelID).Select(C => C.ChannelTitle).FirstOrDefault();
            return ChannelName;
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
                Response.Redirect("/Telegram/?" + url);





            }
            catch { }

        }

        [WebMethod]
        public static string CreateTelegramBultan(string fromDate, string toDate, string parmin, string SelectedMessageIds, string bultanTitle, string linkUrl)
        {
            try
            {
                bultanTitle = Class_Static.ConvertToLatinNumberSam(bultanTitle);
                PersianCalendar pc = new PersianCalendar();
                long dateTimeIndex = long.Parse(pc.GetYear(DateTime.Now).ToString("0000") + pc.GetMonth(DateTime.Now).ToString("00") + pc.GetDayOfMonth(DateTime.Now).ToString("00"));
                SelectedMessageIds = SelectedMessageIds.Substring(1);
                if (string.IsNullOrEmpty(bultanTitle))
                {
                    bultanTitle = "فاقد عنوان";
                }
                Tbl_BultanArchive BultanArchive = new Tbl_BultanArchive
                {
                    NewsDateIndex = dateTimeIndex,
                    PanelId = int.Parse(parmin),
                    Path = @"" + linkUrl + "/HTMLTelegramReportNew.aspx?ArchiveId=",
                    Name = bultanTitle,
                    SelectedNews = SelectedMessageIds,
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
                    BultanType = 5
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

                var telegramTable = _dbStatic.Tbl_TLPMessage.FirstOrDefault(t => t.ID == id);
                telegramTable.NewsValue = value;

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