using NewsLibrary.Repository;
using PArt.Pages.P_Art.Repository;
using PayeshEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class TopBrandA3 : System.Web.UI.Page
    {
        [Serializable]
        public class PayeshBrandType
        {
            public string Brand { get; set; }
            public string LatinBrand { get; set; }
            public string YearMonthIndex { get; set; }
            public int Count { get; set; }
            public int Time { get; set; }
            public int PositionType { get; set; }
            public DateTime DateInsert { get; set; }
            public byte MediaType { get; set; }
            public decimal Average { get; set; }
            public int LastMonthSpotRank { get; set; }
            public int LastMonthTimeRank { get; set; }

        }
        Class_PayeshTopBrands _clsTopBrands = new Class_PayeshTopBrands();
        Class_PayeshTopBrandColor _clsBrandColor = new Class_PayeshTopBrandColor();
        public static string reportType = "spot";//or time
        public static byte mediaType = 1;//tvc 
        public static int GroupId = 0;
        public static int ChildId = 0;
        public static string currentDateIndex = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request.QueryString["m"] != null)
                    try { mediaType = Convert.ToByte(Request.QueryString["m"].ToString()); } catch { }
                if (Request.QueryString["r"] != null)
                    try { reportType = Request.QueryString["r"].ToString(); } catch { }
                if (Request.QueryString["g"] != null)
                    try { GroupId = Convert.ToInt32(Request.QueryString["g"].ToString()); } catch { GroupId = 0; }
                if (Request.QueryString["ch"] != null)
                    try { ChildId = Convert.ToInt32(Request.QueryString["ch"].ToString()); } catch { ChildId = 0; }
                if (GroupId != 0 || ChildId != 0)
                {
                    divFilter.Style.Add("display", "block");
                }
                else
                {
                    divFilter.Style.Add("display", "none");
                }

                var report = _clsTopBrands.SelectGroupByMediaType();
                var tvReport = report.Select("MediaType = 1");
                var radioReport = report.Select("MediaType = 2");
                var strReportMonth = "<ul>";
                var strTvReportMonth = "<li><h5 class='uncollapse'>TV</h5>";
                var strRadioReportMonth = "<li><h5 class='uncollapse'>Radio</h5>";
                if (reportType == "time")
                    hypSort.InnerText = "spot";
                else hypSort.InnerText = "time";
                if (Request.QueryString["d"] != null)
                {
                    currentDateIndex = Request.QueryString["d"] + "";

                    if (tvReport != null)
                    {
                        var currentUrl = Request.Url.AbsoluteUri;
                        currentUrl = "";
                        strTvReportMonth += "<ul class='uncollapse' style='display: none;' >";
                        foreach (DataRow dr in tvReport)
                        {
                            var dateIndex = dr["YearMonthIndex"].ToString();
                            var year = dateIndex.Substring(0, 4);
                            var month = Convert.ToInt32(dateIndex.Substring(4));
                            var active = "";
                            if (currentDateIndex == dateIndex)
                            {
                                active = "active";
                            }
                            strTvReportMonth += "<li><a class='" + active + "' href='" + currentUrl + "?d=" + dr["YearMonthIndex"] + "&m=1" + "&r=" + reportType + "'>" + NewsLibrary.Repository.Class_Static.GetEnMonthDic().FirstOrDefault(t => t.Key == month).Value + " " + year + "</a></li>";
                        }
                        strTvReportMonth += "</ul></li>";

                    }

                    if (radioReport != null)
                    {
                        var currentUrl = Request.Url.AbsoluteUri;
                        currentUrl = "/topbrands";
                        strRadioReportMonth += "<ul class='uncollapse' style='display: none;' >";
                        foreach (DataRow dr in radioReport)
                        {
                            var dateIndex = dr["YearMonthIndex"].ToString();
                            var year = dateIndex.Substring(0, 4);
                            var month = Convert.ToInt32(dateIndex.Substring(4));
                            var active = "";
                            if (currentDateIndex == dateIndex)
                            {
                                active = "active";
                            }
                            strRadioReportMonth += "<li><a class='" + active + "' href='" + currentUrl + "?d=" + dr["YearMonthIndex"] + "&m=2" + "&r=" + reportType + "'>" + NewsLibrary.Repository.Class_Static.GetEnMonthDic().FirstOrDefault(t => t.Key == month).Value + " " + year + "</a></li>";
                        }
                        strRadioReportMonth += "</ul></li>";
                        if (reportType == "spot")
                            hypSort.HRef = currentUrl + "?d=" + currentDateIndex + "&m=" +
                                mediaType + "&r=time" + "&g=" + GroupId + "&ch=" + ChildId;
                        else
                            hypSort.HRef = currentUrl + "?d=" + currentDateIndex + "&m=" +
                                mediaType + "&r=spot" + "&g=" + GroupId + "&ch=" + ChildId;
                    }
                    ViewState["currentDateIndex"] = currentDateIndex;
                    ViewState["mediaType"] = mediaType;
                    LoadData(currentDateIndex, mediaType, reportType, GroupId, ChildId);

                }
                else
                {
                    currentDateIndex = report.Rows[0][0] + "";
                    if (report != null)
                    {
                        var currentUrl = Request.Url.AbsoluteUri;
                        currentUrl = "/topbrands";
                        strTvReportMonth += "<ul class='uncollapse' style='display: none;' >";
                        foreach (DataRow dr in tvReport)
                        {
                            var dateIndex = dr["YearMonthIndex"].ToString();
                            var year = dateIndex.Substring(0, 4);
                            var month = Convert.ToInt32(dateIndex.Substring(4));
                            var active = "";
                            if (currentDateIndex == dateIndex)
                            {
                                active = "active";
                            }
                            strTvReportMonth += "<li><a class='" + active + "' href='" + currentUrl + "?d=" + dr["YearMonthIndex"] + "&m=1" + "&r=" + reportType + "'>" + NewsLibrary.Repository.Class_Static.GetEnMonthDic().FirstOrDefault(t => t.Key == month).Value + " " + year + "</a></li>";
                        }
                        strTvReportMonth += "</ul></li>";

                        strRadioReportMonth += "<ul class='uncollapse' style='display: none;' >";
                        foreach (DataRow dr in radioReport)
                        {
                            var dateIndex = dr["YearMonthIndex"].ToString();
                            var year = dateIndex.Substring(0, 4);
                            var month = Convert.ToInt32(dateIndex.Substring(4));
                            var active = "";
                            if (currentDateIndex == dateIndex)
                            {
                                active = "active";
                            }
                            strRadioReportMonth += "<li><a class='" + active + "' href='" + currentUrl + "?d=" + dr["YearMonthIndex"] + "&m=2" + "&r=" + reportType + "'>" + NewsLibrary.Repository.Class_Static.GetEnMonthDic().FirstOrDefault(t => t.Key == month).Value + " " + year + "</a></li>";
                        }
                        if (reportType == "spot")
                            hypSort.HRef = currentUrl + "?m=" + mediaType + "&r=time" + "&g=" + GroupId +
                                "&ch=" + ChildId;
                        else
                            hypSort.HRef = currentUrl + "?m=" + mediaType + "&r=spot" + "&g=" + GroupId +
                               "&ch=" + ChildId;
                        strRadioReportMonth += "</ul></li>";
                    }
                    ViewState["currentDateIndex"] = currentDateIndex;
                    ViewState["mediaType"] = mediaType;
                    LoadData(currentDateIndex, mediaType, reportType, GroupId, ChildId);

                }
                prepareBrandChild(GroupId);
                PrepareGroupLinks();
                strReportMonth = strTvReportMonth + strRadioReportMonth + "</ul>";
                ltMenu.Text = strReportMonth;


            }
        }
        private void LoadData(string YearMonth, byte MediaType = 1, string ReportType = "spot", int GroupId = 0,
            int ChildId = 0)
        {
            // string LastMonth = (Convert.ToInt32(YearMonth) - 1).ToString();
            string monthIndex = YearMonth.Substring(4, YearMonth.Length - 4);
            string year = YearMonth.Substring(0, YearMonth.Length - 2);
            string lastYear = (Convert.ToInt32(year)).ToString();
            string lastMonth = "";
            if (monthIndex == "1" || monthIndex == "01")
                lastMonth = "12";
            else if (monthIndex == "2" || monthIndex == "02")
                lastMonth = "01";
            else if (monthIndex == "3" || monthIndex == "03")
                lastMonth = "02";
            else if (monthIndex == "4" || monthIndex == "04")
                lastMonth = "03";
            else if (monthIndex == "5" || monthIndex == "05")
                lastMonth = "04";
            else if (monthIndex == "6" || monthIndex == "06")
                lastMonth = "05";
            else if (monthIndex == "7" || monthIndex == "07")
                lastMonth = "06";
            else if (monthIndex == "8" || monthIndex == "08")
                lastMonth = "07";
            else if (monthIndex == "9" || monthIndex == "09")
                lastMonth = "08";
            else if (monthIndex == "10")
                lastMonth = "09";
            else if (monthIndex == "11")
                lastMonth = "10";
            else if (monthIndex == "12")
                lastMonth = "11";

            if (monthIndex == "1" || monthIndex == "01")
                lastYear = (Convert.ToInt32(year) - 1).ToString();

            // var dt = _clsTopBrands.SelectAllWithLastMonthRank(YearMonth);
            DataTable dt;
            string whereClouse = "";
            if (GroupId != 0)
                whereClouse += " AND b.Fk_ParentId_MediakitGroupId = " + GroupId;
            if (ChildId != 0)
                whereClouse += " AND b.Fk_BrandChildId = " + ChildId;
            string cmd = "SELECT  tp.ID,tp.[Count],tp.[Time],tp.DateInsert ,tp.YearMonthIndex,tp.PositionType,tp.MediaType,tp.BrandId,b.LatinBrand,b.Brand," +
                " [dbo].[f_Brand_GetLastMonthTimeById]('" + lastYear + lastMonth + "', BrandId, MediaType) AS LastMonthTimeRank ," +
                " [dbo].[f_Brand_GetLastMonthCountById]('" + lastYear + lastMonth + "', BrandId, MediaType) AS LastMonthSpotRank" +
                " FROM    dbo.Tbl_PayeshTopBrands AS tp INNER JOIN	dbo.Tbl_MediaKit_Brands AS b ON b.Id = tp.BrandId" +
                " WHERE   YearMonthIndex ='" + YearMonth + "'" + whereClouse + " ORDER BY tp.Count DESC";
            dt = ExecuteDatatable("", cmd, CommandType.Text, null);


            if (dt == null) return;
            var lst = new List<PayeshBrandType>();
            var html = "";
            foreach (DataRow dr in dt.Rows)
            {
                var brand = dr["Brand"] + "";
                var latinbrand = dr["LatinBrand"] + "";
                var count = Convert.ToInt32(dr["Count"]);
                var time = Convert.ToInt32(dr["Time"]);
                var DateInsert = Convert.ToDateTime(dr["DateInsert"]);
                var PositionType = Convert.ToInt32(dr["PositionType"]);
                var YearMonthIndex = dr["YearMonthIndex"] + "";
                var LastMonthTimeRank = Convert.ToInt32(dr["LastMonthTimeRank"]);
                var LastMonthSpotRank = Convert.ToInt32(dr["LastMonthSpotRank"]);
                var BrandId = Convert.ToInt32(dr["BrandId"]);
                byte mediaType = 1;
                try { mediaType = Convert.ToByte(dr["MediaType"]); } catch { }

                lst.Add(new PayeshBrandType()
                {
                    Brand = brand.Trim(),
                    LatinBrand = latinbrand.Trim(),
                    Count = count,
                    DateInsert = DateInsert,
                    PositionType = PositionType,
                    Time = time,
                    YearMonthIndex = YearMonthIndex.Trim(),
                    MediaType = mediaType,
                    Average = time / count,
                    LastMonthSpotRank = LastMonthSpotRank,
                    LastMonthTimeRank = LastMonthTimeRank
                }
                    );
            }
            List<PayeshBrandType> lstTop = new List<PayeshBrandType>();
            lstTop = lst.Where(i => i.MediaType == MediaType).OrderByDescending(t => t.Count).ToList();
            if (ReportType == "time")
            {
                lstTop = new List<PayeshBrandType>();
                lstTop = lst.Where(i => i.MediaType == MediaType).OrderByDescending(t => t.Time).ToList();
            }
            var counter = 1;
            foreach (var item in lstTop)
            {
                var doubleClass = "";
                if (counter < 4)
                {
                    doubleClass = "double";
                }

                var dtColor = _clsBrandColor.SelectItem(item.YearMonthIndex, counter);
                var colorTile = "";
                if (dtColor != null)
                {
                    if (dtColor.Rows.Count > 0)
                    {
                        colorTile = " style='background-color:" + dtColor.Rows[0][0] + "'";
                    }
                }

                var counterStr = NewsLibrary.Repository.Class_Static.RoundTenNum(counter);
                if (ReportType == "time")
                {
                    html += "<span class='tile " + doubleClass + "' " + colorTile + "><span class='pos'>" +
                        counterStr + "</span><span class='lastPos'>" + item.LastMonthTimeRank + "</span><span class='brand brand-hide'>" +
                        item.Brand + "</span><span class='latinbrand'>" + item.LatinBrand + "</span><span class='value'>" +
                        item.Count + "</span><span class='Average'>" + Math.Round(item.Average, 2) +
                        "</span><span class='time'>" + item.Time + "</span></span>";
                }
                else
                {
                    html += "<span class='tile " + doubleClass + "' " + colorTile + "><span class='pos'>" +
                      counterStr + "</span><span class='lastPos'>" + item.LastMonthSpotRank + "</span><span class='brand brand-hide'>" +
                      item.Brand + "</span><span class='latinbrand'>" + item.LatinBrand + "</span><span class='value'>" +
                      item.Count + "</span><span class='Average'>" + Math.Round(item.Average, 2) +
                      "</span><span class='time'>" + item.Time + "</span></span>";
                }

                counter++;
            }
            ltHtml.Text = "<div class='page'>" + html + "</div>";

        }
        public static DataTable ExecuteDatatable(string ConnectionString, string Cmd, CommandType type, SqlParameter[] prms = null)
        {
            string connection = GlobalSetting.ConnectionServerPanel;// @"data source=e-sepaar.net\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            if (string.IsNullOrWhiteSpace(ConnectionString))
                ConnectionString = connection;
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Cmd;

            cmd.CommandType = type;
            if (prms != null)
            {
                foreach (SqlParameter p in prms)
                {
                    cmd.Parameters.Add(p);
                }
            }
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds.Tables[0];
        }
        private void prepareBrandChild(int GroupId)
        {
            DataTable dt;
            if (GroupId != 0)
                dt = ExecuteDatatable("", "SELECT ChildId,BrandChildName,Fk_ParentId_MediakitGroupId " +
                   " FROM dbo.Tbl_MediaKit_BrandChilds WHERE Fk_ParentId_MediakitGroupId = " +
                   GroupId, CommandType.Text, null);
            else
                dt = ExecuteDatatable("", "SELECT ChildId,BrandChildName,Fk_ParentId_MediakitGroupId " +
                    " FROM dbo.Tbl_MediaKit_BrandChilds ", CommandType.Text, null);
            List<type_BrandChild> childs = new List<type_BrandChild>();

            foreach (DataRow dr in dt.Rows)
            {
                type_BrandChild child = new type_BrandChild();
                child.ChildId = Convert.ToInt32(dr["ChildId"]);
                child.BrandChildName = dr["BrandChildName"].ToString();
                child.Fk_ParentId_MediakitGroupId = Convert.ToInt32(dr["Fk_ParentId_MediakitGroupId"]);
                childs.Add(child);
            }

            rptBrandChild.DataSource = childs;
            rptBrandChild.DataBind();
        }
        public static DataSet ExecuteDataset(string ConnectionString, string Cmd, CommandType type, SqlParameter[] prms = null)
        {
            string connection = GlobalSetting.ConnectionServerPanel;// @"data source=e-sepaar.net\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            if (string.IsNullOrWhiteSpace(ConnectionString))
                ConnectionString = connection;
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Cmd;

            cmd.CommandType = type;
            if (prms != null)
            {
                foreach (SqlParameter p in prms)
                {
                    cmd.Parameters.Add(p);
                }
            }
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }
        public static int ExecuteNonQuery(string ConnectionString, string cmdText, CommandType type, SqlParameter[] prms)
        {
            string connection = GlobalSetting.ConnectionServerPanel;// @"data source=e-sepaar.net\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            if (string.IsNullOrWhiteSpace(ConnectionString))
                ConnectionString = connection;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;

                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static string ExecuteScalar(string ConnectionString, string cmdText, CommandType type, SqlParameter[] prms)
        {
            string connection = GlobalSetting.ConnectionServerPanel; //@"data source=e-sepaar.net\enterprise;initial catalog=DB_DDN;persist security info=True;user id=sa;password=1qaz@WSX";
            if (string.IsNullOrWhiteSpace(ConnectionString))
                ConnectionString = connection;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;

                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }
        public class type_BrandChild
        {
            public int ChildId { get; set; }
            public string BrandChildName { get; set; }
            public int Fk_ParentId_MediakitGroupId { get; set; }
        }
        private void PrepareGroupLinks()
        {
            var currentUrl = Request.Url.AbsoluteUri;
            currentUrl = "/topbrands";
            hypGroup_All.HRef = currentUrl + "?d=" + ViewState["currentDateIndex"].ToString() + "&m=" +
                             ViewState["mediaType"].ToString() + "&r=spot" + "&g=" + 0 + "&ch=" + 0;
            hypGroup_Auto.HRef = currentUrl + "?d=" + ViewState["currentDateIndex"].ToString() + "&m=" +
                             ViewState["mediaType"].ToString() + "&r=spot" + "&g=" + 3 + "&ch=" + 0;
            hypGroup_Elec.HRef = currentUrl + "?d=" + ViewState["currentDateIndex"].ToString() + "&m=" +
                             ViewState["mediaType"].ToString() + "&r=spot" + "&g=" + 5 + "&ch=" + 0;
            hypGroup_FMCF.HRef = currentUrl + "?d=" + ViewState["currentDateIndex"].ToString() + "&m=" +
                             ViewState["mediaType"].ToString() + "&r=spot" + "&g=" + 1 + "&ch=" + 0;
            hypGroup_Service.HRef = currentUrl + "?d=" + ViewState["currentDateIndex"].ToString() + "&m=" +
                             ViewState["mediaType"].ToString() + "&r=spot" + "&g=" + 4 + "&ch=" + 0;
            hypGroup_Tele.HRef = currentUrl + "?d=" + ViewState["currentDateIndex"].ToString() + "&m=" +
                             ViewState["mediaType"].ToString() + "&r=spot" + "&g=" + 2 + "&ch=" + 0;
        }
        protected void rptBrandChild_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            type_BrandChild data = (type_BrandChild)e.Item.DataItem;
            HyperLink hypChilds = e.Item.FindControl("hypChilds") as HyperLink;
            if (data != null)
            {
                var currentUrl = Request.Url.AbsoluteUri;
                currentUrl = "/topbrands";
                hypChilds.NavigateUrl = currentUrl + "?d=" + ViewState["currentDateIndex"].ToString() + "&m=" +
                                ViewState["mediaType"].ToString() + "&r=spot" + "&g=" + data.Fk_ParentId_MediakitGroupId + "&ch=" + data.ChildId;
            }
        }
        private void prepareChart(int BrandId)
        {
#pragma warning disable CS0219 // The variable 'dt' is assigned but its value is never used
            DataTable dt = null;
#pragma warning restore CS0219 // The variable 'dt' is assigned but its value is never used
        }
    }
}