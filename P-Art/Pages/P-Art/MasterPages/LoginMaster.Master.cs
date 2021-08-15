using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;

namespace PArt.Pages.P_Art.MasterPages
{
    public partial class LoginMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


          
        }
        protected void Page_init(object sender, EventArgs e)
        {

            if (Request.Url.Host == "artreport.ir" )
            {
                Session["PortalMode"] = "0";
                Page.Title = "پایش اخبار (سرویس پی.آرت)";
            }
            else if (Request.Url.Host == "bimna.net")
            {
                Session["PortalMode"] = "1";
                Page.Title = "پایش اخبار - اخبار بیمه";
            }
            else if (Request.Url.Host == "new.e-sepaar.net")
            {
                Session["PortalMode"] = "2";
                Page.Title = "سیستم پایش اخبار";
            }
            else if (Request.Url.Host == "namayandeh.net")
            {
                Session["PortalMode"] = "3";
                Page.Title = "سیستم پایش اخبار";
            }
            else
            {
                Session["PortalMode"] = "4";
                Page.Title = "سیستم پایش اخبار";
            

            }
        }
    }
}