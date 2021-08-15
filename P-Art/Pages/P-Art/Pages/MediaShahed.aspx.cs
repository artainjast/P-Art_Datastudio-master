using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class MediaShahed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["t"] != null && Request.QueryString["id"] != null )
            {

                hddNewsId.Value = Request.QueryString["id"].ToString();
                hddType.Value = Request.QueryString["t"].ToString();
            }
        }
    }
}