using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.Repository;
using Highchart.Core;
using Highchart.Core.Data.Chart;
using System.Collections.ObjectModel;
using System.Web.UI.HtmlControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Analyz2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl sideBar = this.Master.FindControl("sidebar") as HtmlGenericControl;
            sideBar.Visible = false;
        }

        protected void Btn_Show_Click(object sender, EventArgs e)
        {
            LoadChartKhabarGozari();
            LoadChartJarayed();
            LoadPieCompare1();

        }


        private void LoadChartKhabarGozari()
        {
            Class_Ado _clsAdo = new Class_Ado();

            DataTable chart_khabarGozari = _clsAdo.FillDataTable(@"SELECT     SiteID, COUNT(SiteID) AS CCount,
                          (SELECT     TOP (1) SiteTitle
                             FROM         Tbl_Sites
                             WHERE     (SiteID = tbl.SiteID)) AS SiteTitle
                            FROM         Tbl_News AS tbl
                            WHERE     (NewsID IN
                                                      (SELECT     NewsId
                                                         FROM         Tbl_Relation_NewsParminPanel
                                                         WHERE     (ParminPanelId IN (34)) AND (NewsDateIndex BETWEEN 13930301 AND 13930310))) AND (SiteID IN
                                                      (SELECT     SiteID
                                                         FROM         Tbl_Sites AS Tbl_Sites_1
                                                         WHERE     (SiteType = 1)))
                            GROUP BY SiteID
                            ORDER BY SiteTitle");


            Dictionary<string, int> categories = new Dictionary<string, int>();
            var series = new Collection<Serie>();
            var xItem = new XAxisItem();

            foreach (DataRow row in chart_khabarGozari.Rows)
            {

                categories.Add(row["SiteTitle"].ToString(), int.Parse(row["CCount"].ToString()));
            }
            object[] values = new object[categories.Count];
            int index = 0;
            foreach (KeyValuePair<string, int> pair in categories.OrderBy(p => p.Key))
            {
                values[index] = pair.Value;

                index++;
            }
            int index2 = 0;
            object[] cats = new object[categories.Count];
            foreach (KeyValuePair<string, int> pair in categories.OrderBy(p => p.Key))
            {
                cats[index2] = pair.Key;
                index2++;
            }

            series.Add(new Serie { name = "نمودار خبرگزاری ها", data = values });
            xItem.categories = cats;
            chart_bar_khabargozari.YAxis.Add(new YAxisItem { title = new Title("نمودار خبرگزاری ها") });
            chart_bar_khabargozari.XAxis.Add(new XAxisItem { categories = cats });
            chart_bar_khabargozari.Series.Clear();
            chart_bar_khabargozari.DataSource = null;
            chart_bar_khabargozari.DataSource = series;
            chart_bar_khabargozari.DataBind();



        }
        private void LoadChartJarayed()
        {
            Class_Ado _clsAdo = new Class_Ado();

            DataTable chart_khabarGozari = _clsAdo.FillDataTable(@"SELECT     SiteID, COUNT(SiteID) AS CCount,
                          (SELECT     TOP (1) SiteTitle
                             FROM         Tbl_Sites
                             WHERE     (SiteID = tbl.SiteID)) AS SiteTitle
                            FROM         Tbl_News AS tbl
                            WHERE     (NewsID IN
                                                      (SELECT     NewsId
                                                         FROM         Tbl_Relation_NewsParminPanel
                                                         WHERE     (ParminPanelId IN (34)) AND (NewsDateIndex BETWEEN 13930301 AND 13930310))) AND (SiteID IN
                                                      (SELECT     SiteID
                                                         FROM         Tbl_Sites AS Tbl_Sites_1
                                                         WHERE     (SiteType = 2)))
                            GROUP BY SiteID
                            ORDER BY SiteTitle");


            Dictionary<string, int> categories = new Dictionary<string, int>();
            var series = new Collection<Serie>();
            var xItem = new XAxisItem();

            foreach (DataRow row in chart_khabarGozari.Rows)
            {

                categories.Add(row["SiteTitle"].ToString(), int.Parse(row["CCount"].ToString()));
            }
            object[] values = new object[categories.Count];
            int index = 0;
            foreach (KeyValuePair<string, int> pair in categories.OrderBy(p => p.Key))
            {
                values[index] = pair.Value;

                index++;
            }
            int index2 = 0;
            object[] cats = new object[categories.Count];
            foreach (KeyValuePair<string, int> pair in categories.OrderBy(p => p.Key))
            {
                cats[index2] = pair.Key;
                index2++;
            }

            series.Add(new Serie { name = "نمودار روزنامه ها", data = values });


            chart_bar_jarayed.YAxis.Add(new YAxisItem { title = new Title("نمودار روزنامه ها") });
            chart_bar_jarayed.XAxis.Add(new XAxisItem { categories = cats });
            chart_bar_jarayed.Series.Clear();
            chart_bar_jarayed.DataSource = null;
            chart_bar_jarayed.DataSource = series;
            chart_bar_jarayed.DataBind();

        }

        private void LoadPieCompare1()
        {
            //            Class_Ado _clsAdo = new Class_Ado();

            //            DataTable dsChart = _clsAdo.FillDataTable(@"select COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from dbo.Tbl_Relation_NewsParminPanel where ParminPanelId in (34) and NewsDateIndex between 13930101 and 13930130) and SiteID in (select SiteID from Tbl_Sites where SiteType=1)
            //                                                                union all
            //                                                                select COUNT(*) as CCount from Tbl_News where NewsID in (select NewsID from dbo.Tbl_Relation_NewsParminPanel where ParminPanelId in (34) and NewsDateIndex between 13930101 and 13930130) and SiteID in (select SiteID from Tbl_Sites where SiteType=2)");

            //            Dictionary<string, int> categories = new Dictionary<string, int>();
            //            var series = new Collection<Serie>();




            //            //series.Add(new Serie { name = "فراوانی خبرگزاری ها", data = values });
            //            series.Add(new Serie
            //            {
            //                data = new object[] { 
            //                new object[] {  dsChart.Rows[0]["CCount"].ToString(),"خبرگزاری" }, 
            //                new object[] {  dsChart.Rows[1]["CCount"].ToString() ,"جراید"}
            //            },
            //                name = "",
            //                type = Highchart.Core.RenderType.pie


            //            });


            //            chart_pie_compare1.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsPie
            //            {
            //                allowPointSelect = true,
            //                cursor = "pointer",
            //                dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true }
            //            };

            //            chart_pie_compare1.Legend = new Legend { layout = Layout.vertical, align = Align.right, verticalAlign = Highchart.Core.VerticalAlign.top, x = -20, y = 100 };
            //            chart_pie_compare1.Appearance = new Highchart.Core.Appearance.Appearance { marginBottom = 30, marginRight = 130, borderRadius = 15 };            

            //            //xItem.categories = cats;

            //            //chart_pie_compare1.Series.Clear();
            //            //chart_pie_compare1.DataSource = null;
            //            chart_pie_compare1.DataSource = series;
            //            chart_pie_compare1.DataBind();

            string query = @"<script>$(function () {
    $('#chart3_result').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false
        },
        title: {
            text: 'Browser market shares at a specific website, 2014'
        },
        tooltip: {
    	    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            type: 'pie',
            name: 'Browser share',
            data: [
                ['Firefox',   45.0],
                ['IE',       26.8],
                {
                    name: 'Chrome',
                    y: 12.8,
                    sliced: true,
                    selected: true
                },
                ['Safari',    8.5],
                ['Opera',     6.2],
                ['Others',   0.7]
            ]
        }]
    });
});
    </script>";

            chart3_result.InnerHtml = query;
        }
    }
}