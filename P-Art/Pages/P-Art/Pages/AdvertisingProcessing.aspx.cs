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
    public partial class AdvertisingProcessing : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        int panelId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();

            panelId = Class_Layer.UserPanels().FirstOrDefault().Value;
            ParminTable = _db.Tbl_Parmin.Where(p => p.ParminID == panelId).FirstOrDefault();

            //
            if (ParminTable.AccessShareOfVoice == true)
            {
                topBrandsUrl.HRef = "http://en.payeshmedia.ir/topbrands";
                //topBrands.Style.Remove("display");
            }
            else
            {
                //topBrands.Style.Add("display", "none");
                topBrands.Disabled = true;
                topBrandsUrl.HRef = "";
            }

            //


            //
            if (ParminTable.AccessEnvironmentAdvertise == true)
            {
                accessEnvironmentAdvertiseUrl.HRef = "/AdvertisesList";
                //accessEnvironmentAdvertise.Style.Remove("display");
            }
            else
            {
                //accessEnvironmentAdvertise.Style.Add("display", "none");
                accessEnvironmentAdvertise.Disabled = true;
                accessEnvironmentAdvertiseUrl.HRef = "";
            }

            //
            if (ParminTable.AccessTvAdvertise == true)
            {
                accessTvAdvertiseUrl.HRef = "http://bi.payeshmedia.ir/";
                //accessTvAdvertise.Style.Remove("display");
            }
            else
            {
                //accessTvAdvertise.Style.Add("display", "none");
                accessTvAdvertise.Disabled = true;
                accessTvAdvertiseUrl.HRef = "";
            }

            if (ParminTable.AccessTvAdvertise == true)
            {
                accessRadioAdvertiseUrl.HRef = "http://bi.payeshmedia.ir/";
                //accessRadioAdvertise.Style.Remove("display");
            }
            else
            {
                //accessRadioAdvertise.Style.Add("display", "none");
                accessRadioAdvertise.Disabled = true;
                accessRadioAdvertiseUrl.HRef = "";
            }


        }
    }
}