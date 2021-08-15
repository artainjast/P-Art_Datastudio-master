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
    public partial class Telegram : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<Tbl_Telegram_Messages> TelegramMassageList = new List<Tbl_Telegram_Messages>();
        List<Tbl_Telegram_SearchKeyWords> TelegramKeyword = new List<Tbl_Telegram_SearchKeyWords>();
        List<int?> UserPanelList = new List<int?>();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
#pragma warning disable CS0169 // The field 'Telegram.staticfromDateIndex' is never used
        static int staticfromDateIndex;
#pragma warning restore CS0169 // The field 'Telegram.staticfromDateIndex' is never used
#pragma warning disable CS0169 // The field 'Telegram.statictoDateIndex' is never used
        static int statictoDateIndex ;
#pragma warning restore CS0169 // The field 'Telegram.statictoDateIndex' is never used
        public Tbl_Parmin ParminTable = new Tbl_Parmin();

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            UserPanelList = Class_Layer.UserPanels();
            ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();

            if (ParminTable.AccessTelegram == false)
            {
                HttpContext.Current.Response.Redirect("~/Welcome/");
            }

            if (!IsPostBack)
            {
               
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
                txt_fromDate.Text = _clsZm.Today();
                txt_toDate.Text = _clsZm.Today();

                long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));

                //Class_Layer.CheckSession();
                UserPanelList = Class_Layer.UserPanels();
                var parmin = UserPanelList[0].Value + "";
                NewsIdParminId.Value = parmin;



                PrepareTelegramMassage(fromDateIndex * 10000, toDateIndex * 10000 + 2400, string.Empty);

                PrepareKeyCheckBox();
            }

        }

        private void PrepareTelegramMassage(long fromDateTimeIndex, long toDateTimeIndex, string keyIds)
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
            if (Keys.Count > 0)
            {
                TelegramMassageList = (from Massage in _db.Tbl_Telegram_Messages
                                       where UserPanelList.Contains(Massage.FK_ParminId) && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex && Keys.Contains(Massage.FK_Id_Tbl_SearchKeyWord)
                                       orderby Massage.DateTimeIndex descending
                                       select Massage).ToList();
            }

            else
            {
                TelegramMassageList = (from Massage in _db.Tbl_Telegram_Messages
                                       where UserPanelList.Contains(Massage.FK_ParminId) && Massage.DateTimeIndex >= fromDateTimeIndex && Massage.DateTimeIndex <= toDateTimeIndex
                                       orderby Massage.DateTimeIndex descending
                                       select Massage).ToList();
            }
            
            TelegramMassageRepeater.DataSource = TelegramMassageList;
            TelegramMassageRepeater.DataBind();
        }

        private void PrepareKeyCheckBox()
        {
            int parmin = int.Parse(UserPanelList[0].Value + "");
            var keyWords = _db.Tbl_Telegram_SearchKeyWords.Where(k => k.FK_ParminId == parmin).ToList();
            
            SocialKeyCheckBox.DataSource = keyWords;
            SocialKeyCheckBox.DataBind();
        }

        public string GetKeywordName(int KeyId)
        {
            string keyName = _db.Tbl_Telegram_SearchKeyWords.Where(K => K.Id == KeyId).Select(k => k.SearchKeyWord).FirstOrDefault();
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

                long fromDateIndex = Convert.ToInt64(txt_fromDate.Text.Replace("/", ""));
                long toDateIndex = Convert.ToInt64(txt_toDate.Text.Replace("/", ""));

                UserPanelList = Class_Layer.UserPanels();

                PrepareTelegramMassage(fromDateIndex * 10000, toDateIndex * 10000 + 2400 , keyids);

            }
            catch { }

        }

        [WebMethod]
        public static string CreateTelegramBultan(string fromDate, string toDate, string parmin, string SelectedMessageIds, string bultanTitle, string linkUrl)
        {
            try
            {
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
                    Path = @""+ linkUrl +"/HTMLTelegramReport.aspx?ArchiveId=",
                    Name = bultanTitle,
                    SelectedNews = SelectedMessageIds,
                    CreateDate = DateTime.Now,
                    AllowNewspaper = false,
                    AllowGalleryNewspaper = false,
                    AllowChart = false,
                    IsArchive = false,
                    AllowHighlight = false,
                    AllowRelated = false,
                    FromDateIndex = fromDate.Replace("/",""),
                    ToDateIndex = toDate.Replace("/", ""),
                    FromTimeIndex="",
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
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }


    }
}