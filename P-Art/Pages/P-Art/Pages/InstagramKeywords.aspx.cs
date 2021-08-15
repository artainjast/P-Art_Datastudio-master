﻿using System;
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
using PArtCore.Class;
using System.Configuration;
using System.Web.Services;

namespace P_Art.Pages.P_Art.Pages
{

    public partial class InstagramKeywords : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<Tbl_NewsGroup> NewsGroupList = new List<Tbl_NewsGroup>();
        List<Tbl_InstagramKeywords> InstagramKey = new List<Tbl_InstagramKeywords>();

        List<int?> UserPanelList = new List<int?>();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (bool.Parse(Session["IsAdmin"].ToString()) != true)
            {
                Class_Layer.SignOutCookie();
                Response.Redirect("/login/");

            }
            Class_Layer.CheckSession();
            UserPanelList = Class_Layer.UserPanels();
            var parmin = UserPanelList[0].Value + "";
            if (ParminTable.AccessInstagram == false)
            {
                HttpContext.Current.Response.Redirect("~/Welcome/");
            }
            if (!IsPostBack)
            {
                prepareDropDownList();
            }



        }

        private void prepareDropDownList()
        {
            NewsGroupList = (from Group in _db.Tbl_NewsGroup
                             where UserPanelList.Contains(Group.ParminId) && Group.GroupType == 4 && Group.Active == true
                             orderby Group.GroupOrder
                             select Group).ToList();

            rptKeyword.DataSource = NewsGroupList;
            rptKeyword.DataBind();


            lstGroup.DataSource = NewsGroupList;
            lstGroup.DataValueField = "GroupId";
            lstGroup.DataTextField = "GroupName";

            lstGroup.DataBind();
        }

        private static DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }


        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int keyGroup = int.Parse((e.Item.FindControl("GroupIdHiddenField") as HiddenField).Value);
                Repeater rtpKeyWordItemRepeater = e.Item.FindControl("rptKeywordItem") as Repeater;
                InstagramKey = (from key in _db.Tbl_InstagramKeywords
                                where key.KeysGroupID == keyGroup && key.Active == true
                                orderby key.Priority
                                select key).ToList();
                rtpKeyWordItemRepeater.DataSource = InstagramKey;
                rtpKeyWordItemRepeater.DataBind();
            }
        }
        [WebMethod]
        public static Tbl_NewsGroup GetInstagramKeyGroupWithId(string GroupID)
        {
            int groupId = int.Parse(GroupID);
            var KeyGroup = _dbStatic.Tbl_NewsGroup.Where(keyGroup => keyGroup.GroupId == groupId).FirstOrDefault();
            return KeyGroup;
        }
        [WebMethod]
        public static KeywordType GetInstagramKeywordWithId(string KeyID)
        {
            int keyId = int.Parse(KeyID);
            var keyWord = _dbStatic.Tbl_InstagramKeywords.Where(key => key.Id == keyId).FirstOrDefault();
            return new KeywordType
            {
                Active = keyWord.Active,
                CreateDateTime = keyWord.CreateDateTime,
                EditDateTime = keyWord.EditDateTime,
                Id = keyWord.Id,
                KeysGroupID = keyWord.KeysGroupID,
                LastSearchTimeUnix = keyWord.LastSearchTimeUnix,
                PanelId = keyWord.PanelId,
                Priority = keyWord.Priority,
                Title = keyWord.Title
            };
        }




        protected void deleteGroupButton_Click(object sender, EventArgs e)
        {
            try
            {
                int groupId = int.Parse(SelectedGroupIdHiddenField.Value);
                var Keyword = _db.Tbl_InstagramKeywords.Where(key => key.KeysGroupID == groupId && key.Active == true).FirstOrDefault();
                if (Keyword == null)
                {
                    var Group = _db.Tbl_NewsGroup.Where(k => k.GroupId == groupId).FirstOrDefault();
                    Group.Active = false;

                    _db.SaveChanges();

                    prepareDropDownList();
                }

                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            catch
            {
            }
        }

        protected void saveGroupButton_Click(object sender, EventArgs e)
        {
            try
            {
                int groupId = 0;
                int parmin = int.Parse(UserPanelList[0].Value + "");
                if (!string.IsNullOrEmpty(SelectedGroupIdHiddenField.Value) || !string.IsNullOrWhiteSpace(SelectedGroupIdHiddenField.Value))
                    groupId = int.Parse(SelectedGroupIdHiddenField.Value);
                var keyGroup = _db.Tbl_NewsGroup.Where(k => k.GroupId == groupId).FirstOrDefault();
                if (keyGroup != null)
                {
                    if (!string.IsNullOrWhiteSpace(txtGroupName.Text))
                        keyGroup.GroupName = txtGroupName.Text;

                    if (!string.IsNullOrWhiteSpace(txtGroupOrder.Text))
                        keyGroup.GroupOrder = int.Parse(txtGroupOrder.Text);

                    _db.SaveChanges();

                    prepareDropDownList();
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtGroupName.Text))
                    {
                        _db.Tbl_NewsGroup.Add(new Tbl_NewsGroup
                        {
                            GroupName = txtGroupName.Text,
                            GroupOrder = string.IsNullOrEmpty(txtGroupOrder.Text) ? 0 : int.Parse(txtGroupOrder.Text),
                            GroupType = 4,
                            ParminId = parmin,
                            Color = "#FFFFFF",
                            Active = true

                        });
                        _db.SaveChanges();

                        prepareDropDownList();
                    }

                }

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch
            {

            }
        }

        protected void saveKeyword_Click(object sender, EventArgs e)
        {
            try
            {
                int keyId = 0;
                int parmin = int.Parse(UserPanelList[0].Value + "");
                if (!string.IsNullOrEmpty(SelectedKeywordIdHiddenField.Value) || !string.IsNullOrWhiteSpace(SelectedKeywordIdHiddenField.Value))
                    keyId = int.Parse(SelectedKeywordIdHiddenField.Value);
                var keyword = _db.Tbl_InstagramKeywords.Where(k => k.Id == keyId).FirstOrDefault();
                if (keyword != null)
                {
                    if (!string.IsNullOrWhiteSpace(txtKeywordTitle.Text))
                        keyword.Title = txtKeywordTitle.Text;

                    if (!string.IsNullOrWhiteSpace(txtKeyOrder.Text))
                        keyword.Priority = int.Parse(txtKeyOrder.Text);

                    if (!string.IsNullOrWhiteSpace(lstGroup.SelectedValue))
                        keyword.KeysGroupID = int.Parse(lstGroup.SelectedValue);
                    keyword.EditDateTime = DateTime.Now;
                    keyword.Type = int.Parse(ddlType.SelectedValue);
                    _db.SaveChanges();
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtKeywordTitle.Text))
                    {
                        _db.Tbl_InstagramKeywords.Add(new Tbl_InstagramKeywords
                        {
                            Title = txtKeywordTitle.Text,
                            Active = true,
                            CreateDateTime = DateTime.Now,
                            EditDateTime = DateTime.Now,
                            KeysGroupID = int.Parse(lstGroup.SelectedValue),
                            Type = int.Parse(ddlType.SelectedValue),
                            LastSearchTimeUnix = 0,
                            PanelId = parmin,
                            Priority = string.IsNullOrEmpty(txtKeyOrder.Text) ? 0 : int.Parse(txtKeyOrder.Text)

                        });
                        _db.SaveChanges();
                    }

                }

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch
            {

            }
        }
        protected void deleteKeyword_Click(object sender, EventArgs e)
        {
            try
            {
                int keyId = int.Parse(SelectedKeywordIdHiddenField.Value);
                var keyword = _db.Tbl_InstagramKeywords.Where(k => k.Id == keyId).FirstOrDefault();
                keyword.Active = false;
                keyword.EditDateTime = DateTime.Now;
                _db.SaveChanges();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            catch
            {
            }
        }
    }

    public class KeywordType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LastSearchTimeUnix { get; set; }
        public int PanelId { get; set; }
        public Nullable<int> KeysGroupID { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<System.DateTime> EditDateTime { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}