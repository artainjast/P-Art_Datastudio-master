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
    public partial class BreakNews : System.Web.UI.Page
    {
        private Class_News _cls = new Class_News();

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (IsPostBack) return;

            var years = _cls.GetDistrictBreaks(Class_Layer.UserPanels());

            
            if (years.Count() == 0)
            {
                noData.Visible = true;

            }
            else
            {
                foreach (var item in years)
                {
                    ListItem it = new ListItem();
                    it.Text = item.ToString().Substring(0,4);
                    drp_BreakDate.Items.Add(it);
                }
                var result = _cls.GetBreaks(Class_Layer.UserPanels(), years[0].Substring(0,4));

                lst_image.DataSource = result;
                lst_image.DataBind();

                noData.Visible = false;
            }

        }

        public string GetNewsPicture(string NewsPicture)
        {
            try
            {
                if (NewsPicture.ToString().Trim() == "")
                {
                    return "~/Pages/P-Art/Images/noImage.gif";
                }

                else if (NewsPicture.IndexOf('/') == -1)
                {
                    return "http://admin.cportalteam.com/resource/monitoring/images/" + NewsPicture;

                }
                else
                {
                    return NewsPicture ;
                }
                
            }
            catch
            {
                return "~/Pages/P-Art/Images/noImage.gif";
            }
        }

        protected void drp_BreakDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = _cls.GetBreaks(Class_Layer.UserPanels(), drp_BreakDate.SelectedItem.Text.Substring(0, 4));

            lst_image.DataSource = result;
            lst_image.DataBind();

            if(result.Count() ==0) noData.Visible = false;
        }
    }
}