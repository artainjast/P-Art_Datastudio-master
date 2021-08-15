using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using System.Web.UI.HtmlControls;
using FarsiLibrary.Utils;
using P_Art.Pages.P_Art.Repository;
using System.Data;
using PArt.Core;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Highlight : System.Web.UI.Page
    {
        Class_Highlight _clsHighlight = new Class_Highlight();
        Class_Zaman zm = new Class_Zaman();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHighlight();
                LoadNimta();

                HtmlGenericControl sideBar = this.Master.FindControl("sidebar") as HtmlGenericControl;
                sideBar.Visible = false;
            }
            catch
            {

            }
        }

        private void LoadNimta()
        {
            Class_Nimta _cls = new Class_Nimta();
            rpt_newspaper.DataSource = _cls.GetTodayNimta();
            rpt_newspaper.DataBind();

        }
        private void LoadHighlight()
        {
            Class_Sites _clsSite = new Class_Sites();
            Class_Ado _clsAdo = new Class_Ado();

            string panels = Class_Layer.CurrentUser().ParminIds;
            string sites = "";
            DataTable dt = _clsAdo.FillDataTable("select * from tbl_parmin where parminId in(" + panels + ")");
            foreach (DataRow row in dt.Rows)
            {
                if (row["Sites"].ToString() != "")
                {
                    sites += "," + row["Sites"].ToString();
                }
            }
            if (sites != "")
            {
                sites = sites.Substring(1, sites.Length - 1);
            }

            int dateIndex = int.Parse(zm.Today().Replace("/", ""));
            rpt_highlights.DataSource = _clsSite.GetHighlight(panels, sites,dateIndex);
            rpt_highlights.DataBind();

        }

        protected void rpt_highlights_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlGenericControl div = e.Item.FindControl("hightItem") as HtmlGenericControl;
            HiddenField fld = e.Item.FindControl("fld_count") as HiddenField;
            HiddenField fldSiteId = e.Item.FindControl("fld_siteId") as HiddenField;
            HtmlGenericControl time = e.Item.FindControl("lblTime") as HtmlGenericControl;
            HiddenField fld_color = e.Item.FindControl("fld_color") as HiddenField;
            if (fldSiteId.Value == "406")
            {
#pragma warning disable CS0219 // The variable 'bb' is assigned but its value is never used
                int bb = 0;
#pragma warning restore CS0219 // The variable 'bb' is assigned but its value is never used
            }
         
            var result = _clsHighlight.GetHighlightByParminId(Class_Layer.UserPanels(), int.Parse(fldSiteId.Value));


            HtmlGenericControl _div = e.Item.FindControl("hightItem") as HtmlGenericControl;
    
            if (result != null)
            {

                _div.Attributes.Add("data-datetime", result.NewsDate.Value.ToString());
                DateTime dt = DateTime.Parse(result.NewsDate.Value.ToString());
                int hour = (DateTime.Now - dt).Hours;
                int days = (DateTime.Now - dt).Days;

                if (days == 0)
                {


                    if (hour == 0)
                    {
                        time.InnerText = (DateTime.Now - dt).Minutes + " دقیقه پیش";
                    }
                    else
                    {
                        time.InnerText = (DateTime.Now - dt).Hours + " ساعت پیش";
                    }

                    div.Attributes.Add("class", "hightItem active");

                }
                else
                {
                    PArt.Core.Class_Zaman zm = new PArt.Core.Class_Zaman();
                    time.InnerText = zm.MiladiToShamsi(dt.ToShortDateString()).Substring(0, 10);

                }

            }
            else
            {
                time.InnerText = "خیلی قدیم";
            }

            return;
            //string panels = Class_Layer.CurrentUser().ParminIds;
            //Class_Ado _clsAdo = new Class_Ado();

            //DataTable result = _clsAdo.FillDataTable("select top 1 * from Tbl_News where NewsID in (select top 2000  newsid from Tbl_Relation_NewsParminPanel where ParminPanelId in (" + panels + ") order by RelationId desc) and SiteID=" + fldSiteId.Value + " order by newsid desc");
            //if (result.Rows.Count == 1)
            //{
            //    DateTime dt = DateTime.Parse(result.Rows[0]["CreateDate"].ToString());

            //    int hour = (DateTime.Now - dt).Hours;
            //    int days = (DateTime.Now - dt).Days;

            //    if (days == 0)
            //    {


            //        if (hour == 0)
            //        {
            //            time.InnerText= (DateTime.Now - dt).Minutes + " دقیقه پیش";
            //        }
            //        else
            //        {
            //            time.InnerText = (DateTime.Now - dt).Hours + " ساعت پیش";
            //        }

            //    }
            //    else
            //    {
            //        PArt.Core.Class_Zaman zm = new PArt.Core.Class_Zaman();
            //        time.InnerText = zm.MiladiToShamsi(result.Rows[0]["CreateDate"].ToString()).Substring(0,10);

            //    }
            //}
            //else
            //{
            //    time.InnerText = "-";
            //}
            //if (fld.Value != "0")
            //{
            //    div.Attributes.Add("class", "hightItem active");

            //}

        }
        public static string FromDate()
        {
            Class_Zaman _zm = new Class_Zaman();
            string dd = _zm.MiladiToShamsi(DateTime.Now.AddDays(-20).ToString()).Replace("/","");
            return dd.Substring(0,9).Trim();

        }
        public static string ToDate()
        {
            Class_Zaman _zm = new Class_Zaman();
            return _zm.Today().Replace("/", "");
        }
    }
}