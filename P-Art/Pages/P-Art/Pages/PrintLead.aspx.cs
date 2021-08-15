using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PArt.Pages.P_Art.Repository;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class PrintLead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tag"] == null)
            {
                return;

            }

            var ids = "";
            if (Session["tempSelection"] != null)
            {
                ids = Session["tempSelection"].ToString();
            }

            if (ids == "") return;
            Class_News _cls = new Class_News();
            var result = _cls.GetAllNewsByIds(ids);
            grd_news.DataSource = result;
            grd_news.DataBind();


        }

        protected void grd_news_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Request.QueryString["tag"] == "printTitle")
            {

                var item = e.Item.FindControl("NewsLead");
                item.Visible = false;
            }
        }

        
    }
}