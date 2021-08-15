using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Admin
{
    public partial class AdminSites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // LoadGrid();
                LoadDropDown();
            }
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {

            LoadGrid();

        }
        Class_Sites _clsSites = new Class_Sites();
        private void LoadDropDown()
        {

            var data = _clsSites.GetAllSites();
            ddlParmins.DataSource = data;
            ddlParmins.DataTextField = "SiteTitle";
            ddlParmins.DataValueField = "SiteID";
            ddlParmins.DataBind();
        }
        private void LoadGrid()
        {
            var tag = txtParminTag.Text.Trim();
            var data = _clsSites.SelectAllByTag(tag);
            Session.Add("lstSites", data);
            grvData.DataSource = data;
            grvData.DataBind();
        }
        protected void btnReg_Click(object sender, EventArgs e)
        {

            var parminName = txtParminName.Text.Trim();
            if (string.IsNullOrWhiteSpace(parminName))
                return;
            parminName = Class_Static.PersianAlpha(parminName);
            var interval = Convert.ToInt32(txtInterval.Text);
            var res = _clsSites.InsertSite(parminName, Convert.ToInt32(ddlSiteType.SelectedValue), true, interval);

            ltMsgRegBil.Text = "سایت '" + parminName + "' با موفقیت ثبت شد" + Environment.NewLine + " [با کد] " + res.SiteID;
            txtParminName.Text = "";
            LoadDropDown();
        }

        protected void grvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvData.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void lbtnRemove_Click(object sender, EventArgs e)
        {

        }

        protected void grvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var lst = Session["lstSites"] as List<Tbl_Sites>;
                DataRowView drv = e.Row.DataItem as DataRowView;
                DropDownList ddlStatusType = e.Row.FindControl("ddlSiteType") as DropDownList;
                DropDownList ddlPayeshType = e.Row.FindControl("ddlPayeshType") as DropDownList;
                LinkButton lbtnActive = e.Row.FindControl("lbtnRemove") as LinkButton;
                if (ddlStatusType != null)
                {
                    int? activeVal = 1;
                    if (lst != null)
                    {
                        activeVal = lst.FirstOrDefault(t => t.SiteID == Convert.ToInt32(lbtnActive.CommandArgument)).SiteType;
                    }

                    //Get the data from DB and bind the dropdownlist
                    if (activeVal != null)
                    {
                        ddlStatusType.SelectedValue = activeVal.ToString().ToLower();
                    }

                }
                if (ddlPayeshType != null)
                {
                    bool? activeVal = false;
                    if (lst != null)
                    {
                        activeVal = lst.FirstOrDefault(t => t.SiteID == Convert.ToInt32(lbtnActive.CommandArgument)).IsPayesh;
                    }

                    //Get the data from DB and bind the dropdownlist
                    if (activeVal != null)
                    {
                        ddlPayeshType.SelectedValue = activeVal.ToString().ToLower();
                    }

                }

            }
        }

    }
}