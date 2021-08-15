using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System.Web.UI.HtmlControls;
using P_Art.Pages.P_Art.ModelNews;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;


namespace P_Art.Pages.P_Art.Pages
{
    public partial class ReportNews : System.Web.UI.Page
    {
        private Class_News _cls = new Class_News();
        private Class_Zaman _zm = new Class_Zaman();

        private int LblNewsCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            if (Request["__EVENTARGUMENT"] != null)
            {
                var arg = Request["__EVENTARGUMENT"].ToString();

                if (arg != "")
                {
                    GotoExport(arg);
                    ShowGrid();

                }
            }
            if (IsPostBack) return;

            txt_fromDate.Text = _zm.Today();
            txt_toDate.Text = _zm.Today();
            if (Session["NewsSelection"] != null)
            {
                drp_reportType.SelectedIndex = 3;

            }

            if (HttpContext.Current.Session["CurrentDB"] == null)
            {
                check_gozideh.Visible = false;
                check_mashrooh.Visible = false;
                span_gozideh.Visible = false;
                span_mashrooh.Visible = false;
            }
            else
            {
                check_gozideh.Visible = true;
                check_mashrooh.Visible = true;
                span_gozideh.Visible = true;
                span_mashrooh.Visible = true;
            }
            Class_Panels _clsPanel = new Class_Panels();

            ShowGrid();

        }
        private string RemoveDuplicates(string s)
        {
            string s1 = "";
            s1 += s[0];
            int J = 0;
            for (int I = 0; I <= s.Length - 1; I++)
            {
                if (s[I] == s1[J]) continue;
                J += 1;
                s1 += s[I];
            }
            return s1;
        }
        private void GotoExport(string NewsIds)
        {
            NewsIds = NewsIds.Replace(",,", ",");
            NewsIds = NewsIds.Replace(",undefined,", ",");
            NewsIds = NewsIds.Replace(",,", ",");




            if (NewsIds.Substring(0, 1) == ",") NewsIds = NewsIds.Substring(1, NewsIds.Length - 1);
            if (NewsIds.Substring(NewsIds.Length - 1, 1) == ",") NewsIds = NewsIds.Substring(0, NewsIds.Length - 1);




            grd_word.DataSource = _cls.GetAllNewsByIds(NewsIds);


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=ReportNews.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd_word.DataBind();
            grd_word.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {


        }
        private void ShowGrid()
        {
            long? fromDate = 0;
            long? toDate = 0;

            try
            {
                fromDate = long.Parse(txt_fromDate.Text.Replace("/", ""));
                toDate = long.Parse(txt_toDate.Text.Replace("/", ""));
            }
            catch
            {
                fromDate = null;
                toDate = null;

            }

            //List<Tbl_News> result = new List<Tbl_News>();


            if (drp_reportType.SelectedValue == "3")
            {
                var result = _cls.GetAllNewsByIds(Session["NewsSelection"].ToString());

                grd_News.DataSource = result;
                LblNewsCount = result.Rows.Count; ;

                ViewState.Add("NewsCount", "تعداد " + result.Rows.Count);
            }
            else
            {
                //result = _cls.GetAllNews(-1, -1, Class_Layer.UserPanels(), null, true, Class_Layer.UserHighlight(), fromDate, toDate, txt_Search.Text.Trim(), int.Parse(drp_newsSource.SelectedValue));
                //var result = _cls.GetAllNewsDataTable(-1, -1, Class_Layer.UserPanels(), null, true, Class_Layer.UserHighlight(), fromDate, toDate, txt_Search.Text, int.Parse(drp_newsSource.SelectedValue), null, txt_fromHour.Text, txt_toHour.Text);

                //grd_News.DataSource = result;
                //LblNewsCount = result.Rows.Count;

                //ViewState.Add("NewsCount", "تعداد " + result.Rows.Count);
            }


            grd_News.DataBind();



        }
        public List<int> ConvertNewsList(string newsIds)
        {
            var splt = newsIds.Split(',');
            List<int> result = new List<int>();

            foreach (var s in splt)
            {
                if (s == "") continue;
                result.Add(int.Parse(s));

            }

            return result;
        }
        public string GetNewsSite(int siteId)
        {
            try
            {

                Class_Sites cls = new Class_Sites();
                return cls.GetSiteById(siteId).SiteTitle;

            }
            catch
            {
                return "";
            }

        }

        protected void btn_Report_Click(object sender, EventArgs e)
        {
            ShowGrid();
        }

        protected void btn_exportReport_Click(object sender, EventArgs e)
        {

        }

        protected void grd_News_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label NewsCount = e.Row.FindControl("NewsCount") as Label;
                NewsCount.Text = ViewState["NewsCount"].ToString();
            }
            else
            {
                HiddenField allowTv = (HiddenField)e.Row.FindControl("fld_TvShow");
                DropDownList dpTv = (DropDownList)e.Row.FindControl("drp_AllowTv");

                if (allowTv != null)
                {

                
                    if (allowTv.Value == "")
                    {
                        dpTv.SelectedValue = "0";
                    }
                    else if (allowTv.Value == "False")
                    {
                        dpTv.SelectedValue = "1";
                    }
                    else
                    {
                        dpTv.SelectedValue = "0";
                    }
                }
                if (Session["NewsIds"] != null)
                {
                    HiddenField fld = (HiddenField)e.Row.FindControl("fld_newsId");
                    CheckBox check = (CheckBox)e.Row.FindControl("check_selected");

                    if (check != null && fld != null)
                    {

                        if (Session["NewsIds"].ToString().IndexOf("," + fld.Value + ",") > -1)
                        {
                            check.Checked = true;
                        }
                    }
                }
            }
        }

        public string mirrorDate(string NewsDate)
        {
            var date = NewsDate.Split('/');

            var result = date[2] + "/" + date[1] + "/" + date[0];
            return result;
        }

        protected void btn_PrintTitle_Click(object sender, EventArgs e)
        {
            var ids = "";

            foreach (GridViewRow row in grd_News.Rows)
            {
                CheckBox currentCheck = (CheckBox)row.FindControl("check_selected");
                ids += currentCheck.Attributes["data-id"] + ",";


            }
            Session["tempSelection"] = ids.Substring(0, ids.Length - 1);
            Response.Redirect("~/print/?tag=printTitle");
        }

        protected void btn_PrintLead_Click(object sender, EventArgs e)
        {
            var ids = "";

            foreach (GridViewRow row in grd_News.Rows)
            {
                CheckBox currentCheck = (CheckBox)row.FindControl("check_selected");
                ids += currentCheck.Attributes["data-id"] + ",";


            }
            Session["tempSelection"] = ids.Substring(0, ids.Length - 1);
            Response.Redirect("~/print/?tag=printLead");
        }

        protected void grd_News_DataBound(object sender, EventArgs e)
        {

        }

        protected void grd_News_RowCreated(object sender, GridViewRowEventArgs e)
        {
  
        }

        public static string NewsRateOpacity(object newsValue,string MustValue)
        {
            if (newsValue.ToString() == "")
            {
                if (MustValue == "0")
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.1";
                }
            }
            else
            {
                if (newsValue.ToString() == MustValue)
                {
                    return "opacity:1";
                }
                else
                {
                    return "opacity:0.1";
                }
            }
        }
        public static bool IsNewsRateVisible()
        {
            return (bool)HttpContext.Current.Session["IsAdmin"];
        }

        public static bool IsTvSelected(string value)
        {
            if (value== null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}