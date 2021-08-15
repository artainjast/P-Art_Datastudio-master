using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArtCore.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.UserControls
{
    public partial class UC_Alert : System.Web.UI.UserControl
    {
        Class_Zaman _clsZm = new Class_Zaman();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        Pages.P_Art.Repository.Class_Ado _clsAdo = new Pages.P_Art.Repository.Class_Ado();
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
    }
}