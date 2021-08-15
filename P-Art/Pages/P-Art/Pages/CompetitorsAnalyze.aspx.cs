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
    public partial class CompetitorsAnalyze : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        }
    }
}