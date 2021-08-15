using AnalyzeReportMaker.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnalyzeReportMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class KeysResaultClass
        {
            public int Row { get; set; }
            public string Key { get; set; }
            public string Date { get; set; }
            public int Count { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var dt = DateTime.Now;

            txtStartDate.Text = Persia.Calendar.ConvertToPersian(dt).ToString();
            txtEndDate.Text = Persia.Calendar.ConvertToPersian(dt).ToString();

            stiReport1.ReportFile = Application.ExecutablePath + "//Report.mrt";

            stiReport1.Show();
        }
        Class_CoreNews _clsCoreNews = new Class_CoreNews();
        private void btnDoReport_Click(object sender, EventArgs e)
        {
            var parmins = txtPanel.Text.Trim();
            //var fromDate = txtStartDate.Text.Trim();
            // var toDate = txtEndDate.Text.Trim();

            var lst = new List<KeysResaultClass>();
            var keys = txtKeys.Text.Trim();
            if (!string.IsNullOrWhiteSpace(keys))
            {
                keys = keys.Substring(1);
            }

            //  var data = _clsCoreNews.SelectAll(parmins, "", "", null, null, "", 1, 5000, null, fromDate, toDate, 0, "");
            var fromDate = Class_Static.ShamsiToMiladi(txtStartDate.Text);
            var toDate = Class_Static.ShamsiToMiladi(txtEndDate.Text);
            var betDays = (toDate - fromDate).TotalDays;

            var pc = new PersianCalendar();
            for (int i = 0; i <= betDays; i++)
            {


                try
                {
                    var dtNew = fromDate.AddDays(i);
                    var dateStr = pc.GetYear(dtNew) + "/" + Class_Static.RoundTenNum(pc.GetMonth(dtNew)) + "/" + Class_Static.RoundTenNum(pc.GetDayOfMonth(dtNew));
                    var dateIndex = pc.GetYear(dtNew) + Class_Static.RoundTenNum(pc.GetMonth(dtNew)) + Class_Static.RoundTenNum(pc.GetDayOfMonth(dtNew));




                    var allNews = _clsCoreNews.SelectAll(parmins, "", "", null, null, "", 1, 999999999, null, dateIndex, dateIndex, 0, "");
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

            var lstKeys = lst.GroupBy(t => t.Key).Select(g => g.First()).OrderBy(t => t.Key).ToList();
            var lstDates = lst.GroupBy(t => t.Date).Select(g => g.First()).OrderBy(t => t.Date).ToList();



         
        }
    }
}
