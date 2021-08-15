using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class SmsPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sidebarPC = Master.FindControl("pc_SideBar") as Panel;
            sidebarPC.Visible = false;
            Master.Controls.Remove(sidebarPC);

            Class_Layer.CheckSession();

            if (!IsPostBack)
            {
                ViewState.Add("SearchTxt", "");

                var panels = Class_Layer.UserPanels();
                var parminId = Convert.ToInt32(panels.FirstOrDefault());
                var parmin = new Class_Panels().GetParminById(parminId);
                if (string.IsNullOrWhiteSpace(parmin.SmsFormat))
                {
                    txtSmsFormat.Text = "[عنوان رسانه] | [ساعت خبر]" + Environment.NewLine + "[عنوان خبر]" + Environment.NewLine + "[شاهد خبر]";
                }
                else
                {
                    txtSmsFormat.Text = parmin.SmsFormat;
                }
                LoadData();

            }
        }
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private void LoadData()
        {
            var searchTxt = "";
            if (ViewState["SearchTxt"] != null)
            {
                searchTxt = Class_Static.ArabicAlpha(ViewState["SearchTxt"].ToString());
            }

            var panels = Class_Layer.UserPanels();
            var parminId = panels.FirstOrDefault();
            var allData = _db.Tbl_SmsHistory.Where(t => t.ParminID == parminId && t.SMSText.Contains(searchTxt)).Take(1000).OrderByDescending(t => t.NewsID).ToList();
            var data = allData.GroupBy(t => t.NewsID).Select(g => g.First()).ToList();

            grvSmsList.DataSource = data;
            grvSmsList.DataBind();
        }



        protected void rptSmsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdfID = (e.Row.FindControl("hdfID") as HiddenField);
                DropDownList ddlStatus = (e.Row.FindControl("ddlStatus") as DropDownList);
                Literal ltSmsNumberCount = (e.Row.FindControl("ltSmsNumberCount") as Literal);
                Literal ltSmsNumbers = (e.Row.FindControl("ltSmsNumbers") as Literal);

                try
                {
                    var newsID = Convert.ToInt32(hdfID.Value);
                    var allData = _db.Tbl_SmsHistory.Where(t => t.NewsID == newsID).ToList();
                    // ltSmsNumbers.Text = "<ul>";
                    var smsSendCount = 0; ;
                    foreach (var item in allData)
                    {
                        if (item.MobileNumber == "9121485651" || item.MobileNumber == "9126778380")
                            continue;

                        ltSmsNumbers.Text += "<li>0" + item.MobileNumber + "</li>";
                        smsSendCount++;
                    }
                    ltSmsNumberCount.Text = smsSendCount + "";

                    // ltSmsNumbers.Text += "</ul>";

                    ddlStatus.SelectedValue = (allData.FirstOrDefault().SmsStatus).ToString().ToLower();
                }
                catch
                {

                }
            }
        }



        protected void grvSmsList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grvSmsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSmsList.PageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void txtGridCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvSmsList.PageSize = Convert.ToInt32(txtGridCount.SelectedValue);
            LoadData();
        }

        protected void txtGridCount_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            ViewState.Add("SearchTxt", txtSearch.Text);
            LoadData();
        }

        protected void btnRegSetting_Click(object sender, EventArgs e)
        {
            var panels = Class_Layer.UserPanels();
            var parminId = Convert.ToInt32(panels.FirstOrDefault());
            //  var parmin = new Class_Panels().GetParminById(parminId);

            var parmin = _db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == parminId);
            parmin.SmsFormat = txtSmsFormat.Text;
            _db.SaveChanges();
            lblMsg.Text = "تنظیمات با موفقیت ثبت شد";
        }
    }
}