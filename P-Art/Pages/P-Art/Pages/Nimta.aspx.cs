using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using Stimulsoft.Report;
using Stimulsoft.Report.Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Nimta : System.Web.UI.Page
    {
        Class_Zaman _clsZm = new Class_Zaman();
        Class_Panels.Panel_Type Parmin;
        string date;
        private void PrepareNimtaData()
        {
            string last3Month = _clsZm.AddDay(_clsZm.Today(), -10).Split(' ')[0];
            string parminId = Class_Layer.CurrentUserCode();
            DataSet dsData = new Class_Nimta().GetData(Convert.ToInt32(parminId), last3Month);
            Parmin = Class_Panels.Panel_Type.GetFromDataRows(dsData.Tables[1].Select());
            List<NimtaType> nimtaList = Class_Nimta.GetFromDataRows(dsData.Tables[0].Select());
            if (nimtaList.Count > 0)
                rptNimta.DataSource = nimtaList;
            else rptNimta.DataSource = null;
            rptNimta.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PrepareNimtaData();
                txtDate.Text = _clsZm.Today().Split(' ')[0];
                date = txtDate.Text;

            }

        }

        protected void btnNimtaBooltan_Click(object sender, EventArgs e)
        {
            date = txtDate.Text;
            string parminId = Class_Layer.CurrentUserCode();
            string nimtaCodes = string.Empty;
            foreach (RepeaterItem item in rptNimta.Items)
            {
                CheckBox cbSelect = (CheckBox)item.FindControl("cbSelect");

                if (cbSelect.Checked == true)
                {
                    Label lblSiteId = item.FindControl("lblSiteId") as Label;
                    nimtaCodes += nimtaCodes != string.Empty ? "," : string.Empty;
                    nimtaCodes += lblSiteId.Text;
                }

            }
            new Class_Panels().UpdateParminNimtaCodes(Convert.ToInt32(parminId), nimtaCodes);

            DataSet dsData = new Class_Nimta().GetReportData(nimtaCodes, date);
            List<NimtaType> nimta = Class_Nimta.GetFromDataRows(dsData.Tables[0].Select());
            StiReport report2 = new StiReport();
            report2.RegBusinessObject("Nimta", nimta);
            report2.Load(Server.MapPath("/Content/Report.mrt"));
            report2.Render(false);
            report2.RegReportDataSources();
            StiOptions.Export.Html.ReplaceSpecialCharacters = false;
            report2.Dictionary.Synchronize();
            MemoryStream stream = new MemoryStream();

            StiPdfExportSettings settings = new StiPdfExportSettings();
            settings.AutoPrintMode = StiPdfAutoPrintMode.Dialog;

            StiPdfExportService service = new StiPdfExportService();
            service.ExportPdf(report2, stream, settings);

            this.Response.Buffer = true;
            this.Response.ClearContent();
            this.Response.ClearHeaders();
            this.Response.ContentType = "application/pdf";
            this.Response.ContentEncoding = Encoding.UTF8;
            this.Response.AddHeader("Content-Length", stream.Length.ToString());
            this.Response.BinaryWrite(stream.ToArray());
            this.Response.End();

        }

        protected void rptNimta_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox cbSelect = (CheckBox)e.Item.FindControl("cbSelect");
                
                NimtaType newsData = (NimtaType)e.Item.DataItem;
                cbSelect.InputAttributes.Add("data-group", newsData.SiteID_FK.ToString());
                if (Parmin.ParminNimtaCodes != string.Empty)
                {
                    string[] codes = Parmin.ParminNimtaCodes.Split(',');
                    foreach (string siteId in codes)
                    {
                        //cbSelect.Checked = false;
                        if (Convert.ToInt32(siteId) == newsData.SiteID_FK)
                            cbSelect.Checked = true;

                    }
                }
            }
        }
    }
}