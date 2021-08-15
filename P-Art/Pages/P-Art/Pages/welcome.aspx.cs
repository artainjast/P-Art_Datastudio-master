using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using FarsiLibrary.Utils;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Data.OleDb;
using P_Art.Pages.P_Art.ModelNews;
using System.Globalization;
using System.Data.SqlClient;
using System.Web.Services;


namespace P_Art.Pages.P_Art.Pages
{
    public partial class welcome : System.Web.UI.Page
    {
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            DateTime dt = DateTime.Now.AddDays(-180);
            //var UserPanelList = Class_Layer.UserPanels();
            string UserPanelString = "";
            //if (UserPanelList != null)
            //{
            //    foreach (var i in UserPanelList)
            //    {
            //        UserPanelString += "," + i;
            //    }
            //    if (!String.IsNullOrWhiteSpace(UserPanelString))
            //        UserPanelString = UserPanelString.Substring(1);
            //}



            var UserPanelList = Class_Layer.UserPanels();
            var ParminTable = _db.Tbl_Parmin.Where(p => UserPanelList.Contains(p.ParminID)).FirstOrDefault();
            UserPanelString = ParminTable.ParminID.ToString();
            Class_Zaman _clsZm = new Class_Zaman();

           


            DateTime dtChart = DateTime.Now.AddDays(-7);
            string dateFrom = _clsZm.MiladiToShamsi(dtChart.ToShortDateString());
            dateFrom = dateFrom.Substring(0, 10).Replace("/", "");


            List<string> IranNetworkName = new List<string>();
            List<string> IntenationalNetworkName = new List<string>();
            IranNetworkName.Add("شبکه 1");
            IranNetworkName.Add("شبکه 2");
            IranNetworkName.Add("شبکه خبر");
            IranNetworkName.Add("شبکه 5");
            IranNetworkName.Add("شبکه 3");
            IranNetworkName.Add("شبکه 4");


            hddFrom.Value = dateFrom;

            hddTo.Value = _clsZm.Today();




        }


    }
}