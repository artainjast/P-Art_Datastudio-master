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
    public partial class SiteSettings : System.Web.UI.Page
    {
        private static DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        Class_Sites _clsSite = new Class_Sites();
        Class_Zaman _clsZm = new Class_Zaman();
        public List<Tbl_Sites> siteData = new List<Tbl_Sites>();
        public List<Tbl_MemberParminSites> memberParminSiteList;
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        public static string parmin = "0";
        public static Tbl_AgenceMembers currentUser;
        private void LoadUserData()
        {
            currentUser = Class_Layer.CurrentUser();
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
            parmin = UserPanelList[0].Value + "";
            siteData = _clsSite.GetAllSites();
            memberParminSiteList = (new Class_MemberParminSites()).GetMemberParminSite(currentUser.MemberID, Convert.ToInt32(parmin));
            List<Tbl_SiteGroups> groupList = (new Class_SiteGroups()).GetSiteGroup();
            List<Tbl_TLPChannels> telegramChannels = (new Class_TLPChannels()).GetChannels();
            //rptSiteGroup.DataSource = groupList;
            //rptSiteGroup.DataBind();
            lblKhabargozari.Text = FillKhabargozari(siteData.Where(i => i.SiteType == 1 && i.SiteGroupID == 1).ToList());
            lblRooznameh.Text = FillRooznameh(siteData.Where(i => i.SiteType == 2 && i.SiteGroupID == 2).ToList());
            lblPayegah.Text = FillPaygah(siteData.Where(i => i.SiteType == 1 && i.SiteGroupID != 1 && i.SiteGroupID != 2).ToList());
            lblTelegram.Text = FillTelegram(telegramChannels);
            //rptSelectedSiteSort.DataSource = siteData;
            //rptSelectedSiteSort.DataBind();
            // hdfUserID.Value = currentUser.MemberID + "";
        }
        private string FillKhabargozari(List<Tbl_Sites> listSiteKhabargozari)
        {
            string html = "";
            html += "<div class='group-header'><a class='title-link-site'  >گروه خبرگزاری ها</a></div>";
            foreach (var s in listSiteKhabargozari)
            {
                if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                    html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                        "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                else
                    html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                 "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
            }
            return html;
        }
        private string FillRooznameh(List<Tbl_Sites> listSiteRooznameh)
        {
            string html = "";
            html += "";
            foreach (var s in listSiteRooznameh)
            {
              
                if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                    html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                    "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                else
                    html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                   "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
            }
            return html;
        }
        private string FillPaygah(List<Tbl_Sites> listSitePaygah)
        {
            string html = "";
           
            foreach (var s in listSitePaygah)
            {
                if (s.SiteGroupID == 4)
                {
                    html += "<div class='group-header'><a class='title-link-site'  >پایگاه های خبری</a></div>";
                    if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                        html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                        "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                    else html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                       "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                }
                if (s.SiteGroupID == 6)
                {
                    html += "<div class='group-header'><a class='title-link-site'  >پایگاه های خبری اقتصادی</a></div>";
                    if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                        html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                        "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                    else html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                       "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                }
                if (s.SiteGroupID == 7)
                {
                    html += "<div class='group-header'><a class='title-link-site'  >پایگاه های خبری اجتماعی</a></div>";
                    if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                        html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                        "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                    else html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                       "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                }
                if (s.SiteGroupID == 8)
                {
                    html += "<div class='group-header'><a class='title-link-site'  >پایگاه های خبری حوزه فناوری</a></div>";
                    if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                        html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                        "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                    else html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                       "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                }
                if (s.SiteGroupID == 9)
                {
                    html += "<div class='group-header'><a class='title-link-site'  >پایگاه های هنری</a></div>";
                    if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                        html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                        "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                    else html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                       "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                }
                if (s.SiteGroupID == 10)
                {
                    html += "<div class='group-header'><a class='title-link-site'  >پایگاه های خبری ورزشی</a></div>";
                    if (memberParminSiteList.Any(i => i.SiteID == s.SiteID && i.MediaType == (byte)1))
                        html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                        "," + currentUser.MemberID + ",this)' class='link-site selected' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                    else html += "<a onClick='updateSiteMember(" + s.SiteID + ",1," + parmin +
                       "," + currentUser.MemberID + ",this)' class='link-site' data-siteid='" + s.SiteID + "' >" + s.SiteTitle + "</a>";
                }
            }
            return html;
        }
        private string FillTelegram(List<Tbl_TLPChannels> listTelegram)
        {
            string html = "";
            html += "";
            foreach (var s in listTelegram)
            {
                if (memberParminSiteList.Any(i => i.SiteID == s.ChannelID && i.MediaType == (byte)2))
                    html += "<a onClick='updateSiteMember(" + s.ChannelID + ",2," + parmin +
                    "," + currentUser.MemberID + ",this)' class='link-telegram selected' data-channelid='" + s.ChannelID + "' >" + s.ChannelTitle + "</a>";
                else html += "<a onClick='updateSiteMember(" + s.ChannelID + ",2," + parmin +
                   "," + currentUser.MemberID + ",this)' class='link-telegram' data-channelid='" + s.ChannelID + "' >" + s.ChannelTitle + "</a>";
            }
            return html;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (IsPostBack)
            {
            }
            else
            {

                LoadUserData();
            }
        }

        protected void rptSelectedSiteSort_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var cbIsCheck = (CheckBox)e.Item.FindControl("cbIsCheck");
                Tbl_Sites dr = (Tbl_Sites)e.Item.DataItem;
                if (memberParminSiteList.Any(i => i.SiteID == dr.SiteID))
                {
                    cbIsCheck.Checked = true;
                }
                else
                {
                    cbIsCheck.Checked = false;
                }
            }
        }

        protected void rptSiteGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptSelectedSiteSort = e.Item.FindControl("rptSelectedSiteSort") as Repeater;
                if (rptSelectedSiteSort != null)
                {
                    Tbl_SiteGroups dr = (Tbl_SiteGroups)e.Item.DataItem;
                    rptSelectedSiteSort.DataSource = siteData.Where(i => i.SiteGroupID == dr.ID).ToList();
                    rptSelectedSiteSort.DataBind();
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string codes = "";
            foreach (RepeaterItem itemGroup in rptSiteGroup.Items)
            {
                if (itemGroup.ItemType == ListItemType.Item || itemGroup.ItemType == ListItemType.AlternatingItem)
                {
                    var rptSelectedSiteSort = (Repeater)itemGroup.FindControl("rptSelectedSiteSort");
                    foreach (RepeaterItem item in rptSelectedSiteSort.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            var cbIsCheck = (CheckBox)item.FindControl("cbIsCheck");
                            var siteID = (HiddenField)item.FindControl("hddSite");
                            // Tbl_Sites dr = (Tbl_Sites)item.DataItem;
                            if (cbIsCheck.Checked)
                            {
                                codes += codes != string.Empty ? "," : string.Empty;
                                codes += siteID.Value.ToString();
                            }
                        }
                    }
                }
            }
            Class_MemberParminSites.UpdateMemeberPanelSite(currentUser.MemberID, codes, Convert.ToInt32(parmin), 1/*1=site 2=telegram*/);
        }
    }
}