using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.Repository;

namespace PArt.Pages.P_Art.Pages
{
    public partial class ShowImage : System.Web.UI.Page
    {
        private Class_Gallery _cls = new Class_Gallery();

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            int ImageIndex = int.Parse(RouteData.Values["ImageId"].ToString());
            img_Plate.ImageUrl = "http://admin.cportalteam.com/resource/monitoring/images/" + _cls.GetGalleryById(ImageIndex).LargePath;

            lst_Gallery.DataSource = _cls.GetGallery(Class_Layer.UserPanels(), 50, 1);
            lst_Gallery.DataBind();


        }
    }
}