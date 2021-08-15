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
using PArtCore.Class;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class SocialKeywords : System.Web.UI.Page
    {
        DataSet dsAllData = null;
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        List<Tbl_NewsGroup_Type> KeywordGroupList;
        List<Tbl_SocialMediaKey_Type> KeywordList;
        List<int?> UserPanelList = new List<int?>();
        private void PrepareData()
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

            dsAllData = (new Tbl_NewsGroup_Type()).GetSocialKeywordData(UserPanelString);

            KeywordGroupList = Tbl_NewsGroup_Type.GetFromDataRows(dsAllData.Tables[0].Select());
            KeywordList = Tbl_SocialMediaKey_Type.GetFromDataRows(dsAllData.Tables[1].Select());

            if (KeywordGroupList.Count != 0)
            {
                rptKeyword.DataSource = KeywordGroupList;
                rptKeyword.DataBind();
            }
            else
            {
                rptKeyword.DataSource = null;
                rptKeyword.DataBind();
            }

        }
        private void PrepareDivs()
        {
            divKeywordList.Visible = false;
            divAddKeyword.Visible = false;
            divAddGroup.Visible = false;
        }
        private void PrepareGroup()
        {
            lstGroup.DataSource = KeywordGroupList;
            lstGroup.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!Page.IsPostBack)
            {
                PrepareDivs();
                PrepareData();
                divCommand.Visible = true;
                divKeywordList.Visible = true;

            }

        }

        protected void rptKeyword_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Tbl_NewsGroup_Type data = (Tbl_NewsGroup_Type)e.Item.DataItem;
            if (data != null)
            {
                Repeater rptKeywordItem = e.Item.FindControl("rptKeywordItem") as Repeater;
                try
                {
                    rptKeywordItem.DataSource = KeywordList.Where(i => i.GroupId_FK == data.GroupId).ToList();
                    rptKeywordItem.DataBind();
                }
                catch { }
            }
        }

        protected void btn_new_group_Click(object sender, EventArgs e)
        {
            PrepareDivs();
            divAddGroup.Visible = true;
            ViewState["GroupId"] = 0;
            txtGroupOrder.Text = "0";
        }

        protected void btn_new_keyword_Click(object sender, EventArgs e)
        {
            PrepareData();
            PrepareGroup();
            PrepareDivs();
            divAddKeyword.Visible = true;
            ViewState["SocialMediaKeyID"] = 0;
        }

        protected void btnSaveGroup_Click(object sender, EventArgs e)
        {
            if (ViewState["GroupId"] != null)
            {
                int GroupId = Convert.ToInt32(ViewState["GroupId"].ToString());
                if (GroupId == 0)
                {
                    int panelId = int.Parse(Class_Layer.UserPanels()[0].ToString());
                    (new Tbl_NewsGroup_Type()).Add(GroupId, txtGroupName.Text.Trim(), panelId, "#FFFFFF",
                        2, Convert.ToInt32(txtGroupOrder.Text.Trim()));
                    PrepareDivs();
                    divCommand.Visible = true;
                    divKeywordList.Visible = true;
                    PrepareData();
                }
                else
                {
                    int panelId = int.Parse(Class_Layer.UserPanels()[0].ToString());
                    (new Tbl_NewsGroup_Type()).Update(GroupId, txtGroupName.Text.Trim(), panelId, "#FFFFFF",
                        2, Convert.ToInt32(txtGroupOrder.Text.Trim()));
                    PrepareDivs();
                    divCommand.Visible = true;
                    divKeywordList.Visible = true;
                    PrepareData();
                }
            }
        }

        protected void btnBackGroup_Click(object sender, EventArgs e)
        {
            PrepareData();
            PrepareDivs();
            divCommand.Visible = true;
            divKeywordList.Visible = true;
        }

        protected void rptKeyword_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int code = 0;
            switch (e.CommandName)
            {
                #region EditGroup
                case "EditGroup":
                    PrepareData();
                    PrepareDivs();
                    divAddGroup.Visible = true;
                    code = Convert.ToInt32(e.CommandArgument);
                    ViewState["GroupId"] = code;
                    txtGroupName.Text = KeywordGroupList.FirstOrDefault(i => i.GroupId == code).GroupName;
                    txtGroupOrder.Text = KeywordGroupList.FirstOrDefault(i => i.GroupId == code).GroupOrder.ToString();
                    break;
                #endregion

                #region EditKey
                case "EditKey":
                    PrepareData();
                    PrepareDivs();
                    divAddKeyword.Visible = true;
                    code = Convert.ToInt32(e.CommandArgument);
                    ViewState["SocialMediaKeyID"] = code;
                    txtKeywordTitle.Text = KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).Title;
                    txtKeyOrder.Text = KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).OrderNumber.ToString();
                    txtNotLike.Text = KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).NotLike.ToString();
                    lstGroup.SelectedIndex = lstGroup.Items.IndexOf(lstGroup.Items.FindByValue(KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).GroupId_FK.ToString()));
                    break;
                    #endregion
            }
        }

        protected void btnSaveKey_Click(object sender, EventArgs e)
        {
            if (ViewState["SocialMediaKeyID"] != null)
            {
                int SocialMediaKeyID = Convert.ToInt32(ViewState["SocialMediaKeyID"].ToString());
                if (SocialMediaKeyID == 0)
                {
                    int panelId = int.Parse(Class_Layer.UserPanels()[0].ToString());
                    (new Tbl_SocialMediaKey_Type()).Add(0, panelId, txtKeywordTitle.Text.Trim(),
                        Convert.ToInt32(txtKeyOrder.Text), DateTime.Now,
                        true, Convert.ToInt32(lstGroup.SelectedValue), txtNotLike.Text.Trim());
                    PrepareDivs();
                    divCommand.Visible = true;
                    divKeywordList.Visible = true;
                    PrepareData();
                }
                else
                {
                    int panelId = int.Parse(Class_Layer.UserPanels()[0].ToString());
                    (new Tbl_SocialMediaKey_Type()).Update(SocialMediaKeyID, panelId, txtKeywordTitle.Text.Trim(),
                        Convert.ToInt32(txtKeyOrder.Text), DateTime.Now,
                        true, Convert.ToInt32(lstGroup.SelectedValue), txtNotLike.Text.Trim());
                    PrepareDivs();
                    divCommand.Visible = true;
                    divKeywordList.Visible = true;
                    PrepareData();
                }
            }
        }

        protected void btnBackKey_Click(object sender, EventArgs e)
        {
            PrepareData();
            PrepareDivs();
            divCommand.Visible = true;
            divKeywordList.Visible = true;
        }

        protected void rptKeywordItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int code = 0;
            switch (e.CommandName)
            {
                #region EditKey
                case "EditKey":
                    PrepareData();
                    PrepareGroup();
                    PrepareDivs();
                    divAddKeyword.Visible = true;
                    code = Convert.ToInt32(e.CommandArgument);
                    ViewState["SocialMediaKeyID"] = code;
                    txtKeywordTitle.Text = KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).Title;
                    txtKeyOrder.Text = KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).OrderNumber.ToString();
                    txtNotLike.Text = KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).NotLike.ToString();
                    lstGroup.SelectedIndex = lstGroup.Items.IndexOf(lstGroup.Items.FindByValue(KeywordList.FirstOrDefault(i => i.SocialMediaKeyID == code).GroupId_FK.ToString()));
                    break;
                    #endregion
            }
        }
    }
}