using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class MediaAnalyzePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["f"] != null && Request.QueryString["t"] != null && Request.QueryString["p"] != null && Request.QueryString["ft"] != null && Request.QueryString["tt"] != null && Request.QueryString["k"] != null)
            {
                Tbl_Parmin parmin = (new Class_Panels()).GetParminById(Convert.ToInt32(Request.QueryString["p"].ToString()));
                hddFrom.Value = Request.QueryString["f"].ToString();
                hddTo.Value = Request.QueryString["t"].ToString();
                hddParmin.Value = Request.QueryString["p"].ToString();
                hddKeyword.Value = Request.QueryString["k"].ToString();
                hddFromTime.Value = Request.QueryString["ft"].ToString();
                hddToTime.Value = Request.QueryString["tt"].ToString();
                hddParminTitle.Value = parmin.AgName;
                CurrentParminLabel.InnerText = parmin.AgName;
                FromDateLabel.Text = hddFrom.Value.ToString();
                ToDateLabel.Text = hddTo.Value.ToString();
            }
        }
    }
}