using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class MediaAnalyze : System.Web.UI.Page
    {
        List<int?> UserPanelList = new List<int?>();
        public static string UserPanelString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            UserPanelList = new List<int?>();
            UserPanelString = "";
            UserPanelList = Class_Layer.UserPanels();
            if (UserPanelList != null)
            {
                foreach (var i in UserPanelList)
                {
                    UserPanelString += "," + i;
                }
                if (!String.IsNullOrWhiteSpace(UserPanelString))
                    UserPanelString = UserPanelString.Substring(1);
            }

            Class_Zaman _clsZm = new Class_Zaman();
            hddFrom.Value = _clsZm.Today(); 

            hddTo.Value = _clsZm.Today();
            hddParmin.Value = UserPanelString;

        }
    }
}