using FarsiLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;

namespace PArt.Pages.P_Art.MasterPages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public Class_News _clsNews = new Class_News();
        public Class_Panels _clsPanel = new Class_Panels();

        protected void Page_init(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            namayandeh_info.Visible = false;
            namayandeh_name.Visible = false;
            namayandeh_pic.Visible = false;
            //btn_BoridehJarayed.Visible = false;
          //  btn_BoridehJarayed2.Visible = false;
            if (Request.Url.Host == "artreport.ir")
            {
                Session["PortalMode"] = "0";
                Page.Title = "پایش اخبار (سرویس پی.آرت)";
                //btn_BoridehJarayed.Visible = true;
              //  btn_BoridehJarayed2.Visible = true;
            }
            else if (Request.Url.Host == "bimna.net")
            {
                Session["PortalMode"] = "1";
                Page.Title = "پایش اخبار - اخبار بیمه";
            }
            else if (Request.Url.Host == "new.e-sepaar" || Request.Url.Host == "localhost")
            {
                Session["PortalMode"] = "2";
                Page.Title = "سیستم پایش اخبار";
            }
            else if (Request.Url.Host == "namayandeh.net")
            {
                Session["PortalMode"] = "3";
                var panel = _clsPanel.GetParminById(Class_Layer.UserPanels()[0].Value);
                namayandeh_info.Style.Add("float", "right");

                logoBox.Style.Add("float", "left");
                logoBox.Style.Add("position", "relative");
                logoBox.Style.Add("top", "10px");

                namayandeh_info.Style.Add("height", "107px");
                namayandeh_info.Style.Add("font-family", "'BMitra'");
                namayandeh_info.Style.Add("font-weight", "bold");
                namayandeh_info.Style.Add("font-size", "107px");
                namayandeh_pic.Style.Add("width", "88px");
                namayandeh_pic.Style.Add("height", "107px");
                namayandeh_pic.Style.Add("border-top-right-radius", "15px");
                namayandeh_pic.Style.Add("position", "relative");
                namayandeh_pic.Style.Add("top", "-3px");
                namayandeh_pic.Style.Add("border-bottom-right-radius", "15px");
                namayandeh_pic.Style.Add("right", "-3px");

                headerBox.Style.Add("overflow", "hidden");
                headerBox.Style.Add("width", "978px");
                headerBox.Style.Add("border", "1px solid #E6E6E6");
                headerBox.Style.Add("border-radius", "15px");
                headerBox.Style.Add("margin-bottom", "1px");
                headerBox.Style.Add("background-color", "white");


                if (panel.Description != null)
                {
                    namayandeh_pic.Src = "~/Pages/P-Art/Images/" + panel.Description.Split(';')[2];
                    namayandeh_name.InnerHtml = "نام نماینده : " + panel.AgName + "<br/>" + "نماینده استان : " + panel.Description.Split(';')[1];
                    namayandeh_info.Visible = true;
                    namayandeh_name.Visible = true;
                    namayandeh_pic.Visible = true;
                }
                Page.Title = "سیستم پایش اخبار";
            }
            else
            {
                Session["PortalMode"] = "4";
                Page.Title = "سیستم پایش اخبار";
                img_logo.Src = "~/Pages/P-Art/Images/project-logo-payesh.png";
            }
            LoadKeywordList();

        }
        Class_Keywords _clsKeywords = new Class_Keywords();
        private void LoadKeywordList()
        {
            var allKeys = _clsKeywords.GetRssKeywordByPanelIds(Class_Layer.UserPanels());
            foreach (var item in allKeys)
            {
                var li = new ListItem { Text = item.KeywordName, Value = item.KeyId + "" };
                li.Attributes.Add("class", "onoffswitch");
                chbTvKeyList.Items.Add(li);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Class_Layer.HasSwitch() == true)
            {
                LoadSwitch();
                SwitchSelect.Visible = true;
                Cmb_Switch.Visible = true;
            }
            else
            {
                var parminId = int.Parse(Class_Layer.CurrentUser().ParminIds);
                if (_clsPanel.GetParminById(parminId).BultanId == null)
                {
                    Session["CurrentDB"] = null;
                }
                else
                {
                    Session["CurrentDB"] = parminId;

                }

                SwitchSelect.Visible = false;
                Cmb_Switch.Visible = false;
            }

            LoadMovies();
            LoadRadio();

            var parmin = _clsPanel.GetParminById(int.Parse(Class_Layer.UserPanels()[0].ToString()));
            string logo = parmin.ParminLogo;
            if (Session["IsAdmin"] != null)
            {
                if (parmin.SmsActive == true)
                {

                  //  pc_SMSPanel.Visible = true;

                }
              //  pc_Keywords.Visible = true;
              //  pc_UsersPanel.Visible = true;
            }
            if (logo == null)
            {
                img_panel_logo.Visible = false;
            }
            else
            {
                img_panel_logo.Src = logo;
            }


        }

        private void LoadSwitch()
        {
            Class_Panels _cls = new Class_Panels();
            ListItem newItem = new ListItem();
            Cmb_Switch.Items.Clear();
            newItem.Text = "کلی";
            newItem.Value = "0";

            Cmb_Switch.Items.Add(newItem);

            foreach (var item in _cls.GetPanelsById(Class_Layer.UserAllPanels()))
            {
                newItem = new ListItem();
                newItem.Text = item.AgName;
                newItem.Value = item.ParminID.ToString();

                Cmb_Switch.Items.Add(newItem);

            }

            if (HttpContext.Current.Session["CurrentDB"] != null)
            {
                Cmb_Switch.SelectedValue = HttpContext.Current.Session["CurrentDB"].ToString();

            }
        }
        public string GetNewsPicture(string NewsPicture)
        {
            if (NewsPicture == null)
            {
                return "~/Pages/P-Art/Images/noImage.gif";
            }
            else if (NewsPicture.ToString().Trim() == "")
            {
                return "~/Pages/P-Art/Images/noImage.gif";
            }

            else
            {
                return NewsPicture.ToString();
            }
        }
        public string GetNewsDate(string NewsDate)
        {
            PersianDate pDate = PersianDate.Parse(NewsDate);

            return pDate.ToString("D");
        }
        protected void btn_Exit_Click(object sender, EventArgs e)
        {
            Class_Layer.SignOutCookie();
            Response.Redirect("~/login");
        }
        protected void Cmb_Switch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Cmb_Switch_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        private void LoadMovies()
        {
            Class_Movies _cls = new Class_Movies();

            rpt_tv.DataSource = _cls.GetAllMovie(30, 1, Class_Layer.UserPanels(), null, "", null);
            rpt_tv.DataBind();
        }
        private void LoadRadio()
        {
            Class_Sound _cls = new Class_Sound();
            rpt_radio.DataSource = _cls.GetAllSound(20, 1, Class_Layer.UserPanels());
            rpt_radio.DataBind();
        }
        public static string DiffrentDate(object ddate, object ttime, object createDate)
        {

            try
            {


                Class_Zaman zm = new Class_Zaman();
                DateTime dt = zm.ShamsiToMiladi(ddate.ToString() + " " + ttime);


                int hour = (DateTime.Now - dt).Hours;
                int minute = (DateTime.Now - dt).Minutes;
                int second = (DateTime.Now - dt).Seconds;
                int days = (DateTime.Now - dt).Days;

                if (days == 0)
                {

                    if (hour == 0)
                    {
                        return minute + " دقیقه " + " پیش ";
                    }
                    else
                    {
                        return hour + " ساعت " + minute + " دقیقه " + " پیش ";
                    }



                }
                else if (days == 1)
                {
                    return "دیروز";
                }
                else
                {

                    return ddate.ToString();
                }

            }
            catch
            {
                return "";
            }
        }


    }


}