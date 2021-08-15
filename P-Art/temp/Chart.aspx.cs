using System;
using System.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.Repository;
using System.Net;
using P_Art.Pages.P_Art.ModelNews;
using System.Text;

namespace P_Art.temp
{
    public partial class Chart : System.Web.UI.Page
    {
        [WebMethod]
        public static string GetChart(string country)
        {
            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            var top10News = _db.Tbl_News.OrderByDescending(t => t.NewsID).Take(10).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var item in top10News)
            {
                sb.Append("{");
                System.Threading.Thread.Sleep(50);
                string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                sb.Append(string.Format("text :'{0}', value:{1}, color: '{2}'", item.NewsTitle, item.NewsDate, color));
                sb.Append("},");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        [WebMethod]
        public static string GetChart2(string element)
        {
            var ltChart = "";
            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            var tb = _db.Tbl_News.OrderByDescending(t => t.NewsID).Take(10).ToList();
            if (tb != null)
            {
                String chart = "";
                // You can change your chart height by modify height value
                chart = "<canvas id='" + element + "' width ='100%' height='40'></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(" + element + "), " +
                    " {type: 'line'," +
                    "  data:  { labels:[";

                // more details in x-axis
                foreach (var item in tb)
                {
                    chart += item.NewsTitle + ",";
                }
                chart = chart.Substring(0, chart.Length - 1);

                chart += "],datasets: [{ data: [";

                // put data from database to chart
                String value = "";
                foreach (var item in tb)
                {
                    value += item.NewsLinkCRC + ",";
                   

                  

                }
                value = value.Substring(0, value.Length - 1);

                chart += value;
                chart += "],label: 'Air Temperature',  borderColor: '#3e95cd',fill: true}"; // Chart color
                chart += "]},options: { title: { display: true,text:'Air Temperature (oC)'} }"; // Chart title
                chart += "});";
                chart += "</script>";
                ltChart = chart;

            }
            return ltChart;

        }

        [Serializable]
        public class chartjs_Data
        {
            public string label { get; set; }
            public string value { get; set; }
            public string color { get; set; }
            public string hightlight { get; set; }
        }
        [WebMethod]
        public static chartjs_Data[] GetChart3()
        {
            List<chartjs_Data> t = new List<chartjs_Data>();

            string[] arrColor = new string[] { "#231F20", "#FFC200", "#F44937", "#16F27E", "#FC9775", "#5A69A6" };
            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
            var top10News = _db.Tbl_News.OrderByDescending(m => m.NewsID).Take(6).ToList();
            int counter = 0;
            foreach (var item in top10News)
            {
                chartjs_Data tsData = new chartjs_Data();
                tsData.value = item.NewsDateIndex.ToString();
                tsData.label = item.NewsTitle;
                tsData.color = arrColor[counter];
                t.Add(tsData);
                counter++;
            }
            return t.ToArray();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}