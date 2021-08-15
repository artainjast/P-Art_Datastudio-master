using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Analyz : System.Web.UI.Page
    {
        string fromDate;
        string toDate;
        private Class_Zaman _zm = new Class_Zaman();
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (!Page.IsPostBack)
            {
                txt_fromDate.Text = _zm.Today();
                txt_toDate.Text = _zm.Today();
            }
                
            SetDatesVar();
            HtmlGenericControl sideBar = this.Master.FindControl("sidebar") as HtmlGenericControl;
            if (sideBar == null) return;
            sideBar.Visible = false;
            
        }

        private void SetDatesVar()
        {
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now;
            Class_Zaman _cls = new Class_Zaman();
            
            dateTo = dateFrom.AddDays(-10);
            fld_10day.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0,10).Replace("/", "");

            dateTo = dateFrom.AddDays(-30);
            fld_1month.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0, 10).Replace("/", "").Replace("/", "");

            dateTo = dateFrom.AddDays(-365);
            fld_1year.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0, 10).Replace("/", "").Replace("/", "");

            dateTo = dateFrom.AddDays(-20);
            fld_20day.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0, 10).Replace("/", "").Replace("/", "");

            dateTo = dateFrom.AddDays(-30);
            fld_30day.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0, 10).Replace("/", "").Replace("/", "");

            dateTo = dateFrom.AddDays(-90);
            fld_3month.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0, 10).Replace("/", "").Replace("/", "");

            dateTo = dateFrom.AddDays(-60);
            fld_6month.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0, 10).Replace("/", "").Replace("/", "");


            fld_today.Value = _cls.Today().Replace("/", "");

            dateTo = dateFrom.AddDays(-1);
            fld_yestarday.Value = _cls.MiladiToShamsi(dateTo.ToString()).Substring(0, 10).Replace("/", "").Replace("/", "");




        }
        
        protected void AnalayzNewsBultanButton_Click(object sender, EventArgs e)
        {
            fromDate = txt_fromDate.Text;
            toDate = txt_toDate.Text;
            StringBuilder queryString = new StringBuilder();
            queryString.Append("/Pages/P-Art/Pages/AnalayzNewsBultan.aspx?FromDate=");
            queryString.Append(fromDate);
            queryString.Append("&ToDate=");
            queryString.Append(toDate);
            HttpContext.Current.Response.Redirect(queryString.ToString());
        }


    }
}