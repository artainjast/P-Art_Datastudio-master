using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;

namespace PArt.Pages.P_Art.Pages
{
    public partial class gallery : System.Web.UI.Page
    {
        private Class_Gallery _cls = new Class_Gallery();
        private Class_News _clsNews = new Class_News();

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            var result = _cls.GetGallery(Class_Layer.UserPanels(), 50, 1);
            
            lst_Gallery.DataSource = result;
            lst_Gallery.DataBind();

          

            if (result.Count() == 0)
            {
                var images = _clsNews.GetBreakImages(Class_Layer.UserPanels(), 1, 100);
                lst_Gallery.DataSource = images;
                lst_Gallery.DataBind();
                if (images.Count == 0)
                {
                    noData.Visible = true;
                }
                else
                {
                    noData.Visible = false;
                }

            }
            else
            {
                noData.Visible = false;
            }
        }
    }
}