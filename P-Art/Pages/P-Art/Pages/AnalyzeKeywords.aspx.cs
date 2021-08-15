using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class AnalyzeKeywords : System.Web.UI.Page
    {
        Class_Zaman _zm = new Class_Zaman();
        Class_News _clsNews = new Class_News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Class_Layer.CheckSession();
                txt_fromDate.Text = _zm.Today();
                txt_toDate.Text = _zm.Today();

                //HtmlGenericControl sideBar = this.Master.FindControl("sidebar") as HtmlGenericControl;
                //sideBar.Visible = false;
            }

        }
        public class KeysResaultClass
        {
            public int Row { get; set; }
            public string Key { get; set; }
            public string Date { get; set; }
            public int Count { get; set; }
        }
        protected void btn_ReportChart_Click(object sender, EventArgs e)
        {
            var lst = new List<KeysResaultClass>();
            var keys = hdfKeys.Value;
            if (!string.IsNullOrWhiteSpace(keys))
            {
                keys = keys.Substring(1);
            }

            var fromDate = Convert.ToDateTime(txt_fromDate.Date);
            var toDate = Convert.ToDateTime(txt_toDate.Date);
            var betDays = (toDate - fromDate).TotalDays;

            var pc = new PersianCalendar();
            for (int i = 0; i <= betDays; i++)
            {


                try
                {
                    var dtNew = fromDate.AddDays(i);
                    var dateStr = pc.GetYear(dtNew) + "/" + Class_Static.RoundTenNum(pc.GetMonth(dtNew)) + "/" + Class_Static.RoundTenNum(pc.GetDayOfMonth(dtNew));
                    var dateIndex = pc.GetYear(dtNew) + Class_Static.RoundTenNum(pc.GetMonth(dtNew)) + Class_Static.RoundTenNum(pc.GetDayOfMonth(dtNew));

                    var parmins="";
                    foreach(var parm in Class_Layer.UserPanels())
                    {
                        parmins+=","+parm;
                    }
                    if(!string.IsNullOrWhiteSpace(parmins))
                    {
                        parmins=parmins.Substring(1);
                    }

                    var allNews = _clsNews.SelectAll(parmins, "", "", null, Convert.ToInt32(drp_newsSource.SelectedValue), "", 1, 999999999, null, dateIndex, dateIndex, 0, "");
                    foreach (var key in keys.Split(','))
                    {
                        var item = new KeysResaultClass();
                        item.Date = dateStr;
                        item.Row = i + 1;
                        item.Count = 0;
                        try
                        {
                            item.Key = Class_Static.PersianAlpha(key).Trim();

                            item.Count = allNews.Where(t => (t.NewsTitle + t.NewsLead + t.NewsBody).Contains(item.Key)).Count();



                        }
                        catch
                        {


                            // continue;
                        }
                        lst.Add(item);
                    }
                }
                catch
                {

                }

            }
            grvData.DataSource = lst.OrderByDescending(t => t.Count).ToList();
            grvData.DataBind();

            var lstKeys = lst.GroupBy(t => t.Key).Select(g => g.First()).OrderBy(t => t.Key).ToList();
            var lstDates = lst.GroupBy(t => t.Date).Select(g => g.First()).OrderBy(t => t.Date).ToList();

            var htmlAllCompareCat = "";
            var htmlAllCount = "";


            foreach (var title in lstKeys)
            {



                htmlAllCompareCat += "<th>" + title.Key + "</th>";





            }
            foreach (var date in lstDates)
            {
                htmlAllCount += "<tr> <th>[" + date.Date + "]</th>";

                foreach (var key in lstKeys)
                {


                    htmlAllCount += "<td>" + lst.FirstOrDefault(t => t.Date == date.Date && t.Key == key.Key).Count + "</td>";


                }
                htmlAllCount += "</tr>";
            }

            var html = @"<table id='datatable'>
    <thead>
        <tr>
            <th></th>
           " + htmlAllCompareCat + @"
        </tr>
    </thead>
    <tbody>
      " + htmlAllCount + @"
    </tbody>
</table>";
            ltChart.Text = html;



            htmlAllCount = "";
            foreach (var key in lstKeys)
            {
                htmlAllCount += "<tr> <th>" + key.Key + "</th>";


                var count = 0;
                foreach (var item in lst.Where(t => t.Key == key.Key).ToList())
                {
                    count += item.Count;
                }

                htmlAllCount += "<td>" + count + "</td>";



                htmlAllCount += "</tr>";
            }

            htmlAllCompareCat = "";
            html = @"<table id='datatablePie'>
    <thead>
        <tr>
            <th></th>
           " + htmlAllCompareCat + @"
        </tr>
    </thead>
    <tbody>
      " + htmlAllCount + @"
    </tbody>
</table>";
            ltPie.Text = html;

            updMain.Update();

            ScriptManager.RegisterStartupScript(this, GetType(), "ShowChart", "ShowChart();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowPie", "ShowPie();", true);

        }

    }
}