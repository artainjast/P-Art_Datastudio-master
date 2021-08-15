using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class TelegramBultanArchive : System.Web.UI.Page
    {
        Class_Zaman _clsZm = new Class_Zaman();
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        List<int?> UserPanelList = new List<int?>();

        protected void Page_Load(object sender, EventArgs e)
        {
            long fromDateIndex = 0;
            long toDateIndex = 0;
            Class_Layer.CheckSession();
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
                txt_fromDate.Text = Class_Layer.MiladiToShamsi(DateTime.Now.AddDays(-30));
                txt_toDate.Text = Class_Layer.MiladiToShamsi(DateTime.Now);
                Class_Layer.CheckSession();
                UserPanelList = Class_Layer.UserPanels();
                int parmin = int.Parse(UserPanelList[0].Value + "");
                fromDateIndex = long.Parse(txt_fromDate.Text.Replace("/", ""));
                toDateIndex = long.Parse(txt_toDate.Text.Replace("/", ""));

                PrepareBultanArchive(fromDateIndex, toDateIndex, parmin);
            }




        }

        private void PrepareBultanArchive(long fromDateTimeIndex, long toDateTimeIndex, int parmin )
        {
            var bultans = _db.Tbl_BultanArchive.Where(b => b.BultanType == 5 && b.PanelId == parmin && b.NewsDateIndex >= fromDateTimeIndex && b.NewsDateIndex <= toDateTimeIndex).OrderByDescending(s => s.ArchiveId).ToList();
            rpt_result.DataSource = bultans;
            rpt_result.DataBind();
        }

        protected void btn_Show_Click(object sender, EventArgs e)
        {
            UserPanelList = Class_Layer.UserPanels();
            int parmin = int.Parse(UserPanelList[0].Value + "");
            long fromDateIndex = long.Parse(txt_fromDate.Text.Replace("/", ""));
            long toDateIndex = long.Parse(txt_toDate.Text.Replace("/", ""));

            PrepareBultanArchive(fromDateIndex, toDateIndex, parmin);
        }

        protected void deleteBultanArchive(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;

                int Id = int.Parse(btn.CommandArgument);
                var ArchiveId = _db.Tbl_BultanArchive.Where(k => k.ArchiveId == Id).FirstOrDefault();
                _db.Tbl_BultanArchive.Remove(ArchiveId);
                
                _db.SaveChanges();
                //int parmin = int.Parse(UserPanelList[0].Value + "");
                //long fromDateIndex = long.Parse(txt_fromDate.Text.Replace("/", ""));
                //long toDateIndex = long.Parse(txt_toDate.Text.Replace("/", ""));
                //PrepareBultanArchive(fromDateIndex, toDateIndex, parmin);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            catch
            {
            }
        }
    }
}