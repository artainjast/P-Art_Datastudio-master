using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Radio : System.Web.UI.Page
    {
        private Class_Sound _cls = new Class_Sound();
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            int pageIndex = 0;
            long RadioCount = 0;


            if (RouteData.Values["paging"] != null)
            {
                pageIndex = int.Parse(RouteData.Values["paging"].ToString());
                pageIndex = (pageIndex - 1) * 22;

            }


            if (RouteData.Values["query"] == null)
            {
                #region CalculatePaging
                RadioCount = _cls.GetRadioCount(Class_Layer.UserPanels(), null);
                if (RadioCount > 22)
                {
                    if (pageIndex == 0)
                    {
                        btn_PageNext.HRef = "~/Radio/Latest/2";
                        btn_PageBack.Attributes.CssStyle.Add("display", "none");

                    }
                    else
                    {
                        btn_PageBack.Attributes.CssStyle.Add("display", "block");
                        btn_PageBack.HRef = "~/Radio/Latest/" + (((pageIndex + 22) / 22) - 1).ToString();

                        if ((pageIndex + 22) >= RadioCount)
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "none");

                            btn_PageNext.Visible = false;
                        }
                        else
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "block");
                            btn_PageNext.HRef = "~/Radio/Latest/" + (((pageIndex + 22) / 22) + 1).ToString();
                        }
                    }
                }
                else
                {

                    btn_PageNext.Attributes.CssStyle.Add("display", "none");
                    btn_PageBack.Attributes.CssStyle.Add("display", "none");
                }
                if (RadioCount == 0)
                {

                    noData.Visible = true;
                }
                else
                {

                    noData.Visible = false;
                }
                #endregion
                lst_movies.DataSource = _cls.GetAllSound(22, pageIndex, Class_Layer.UserPanels());
                lst_movies.DataBind();
            }
            else if (RouteData.Values["query"].ToString().ToLower() == "latest")
            {
                #region CalculatePaging
                RadioCount = _cls.GetRadioCount(Class_Layer.UserPanels(), null);
                if (RadioCount > 22)
                {
                    if (pageIndex == 0)
                    {
                        btn_PageNext.HRef = "~/Radio/Latest/2";
                        btn_PageBack.Attributes.CssStyle.Add("display", "none");

                    }
                    else
                    {
                        btn_PageBack.Attributes.CssStyle.Add("display", "block");
                        btn_PageBack.HRef = "~/Radio/Latest/" + (((pageIndex + 22) / 22) - 1).ToString();

                        if ((pageIndex + 22) >= RadioCount)
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "none");

                            btn_PageNext.Visible = false;
                        }
                        else
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "block");
                            btn_PageNext.HRef = "~/Radio/Latest/" + (((pageIndex + 22) / 22) + 1).ToString();
                        }
                    }
                }
                else
                {

                    btn_PageNext.Attributes.CssStyle.Add("display", "none");
                    btn_PageBack.Attributes.CssStyle.Add("display", "none");
                }
                if (RadioCount == 0)
                {

                    noData.Visible = true;
                }
                else
                {

                    noData.Visible = false;
                }
                #endregion
                lst_movies.DataSource = _cls.GetAllSound(22, pageIndex, Class_Layer.UserPanels());
                lst_movies.DataBind();
            }
            else if (RouteData.Values["query"].ToString().ToLower() == "update")
            {
                #region CalculatePaging
                RadioCount = _cls.GetRadioCount(Class_Layer.UserPanels(), false);
                if (RadioCount > 22)
                {
                    if (pageIndex == 0)
                    {
                        btn_PageNext.HRef = "~/Radio/update/2";
                        btn_PageBack.Attributes.CssStyle.Add("display", "none");

                    }
                    else
                    {
                        btn_PageBack.Attributes.CssStyle.Add("display", "block");
                        btn_PageBack.HRef = "~/Radio/update/" + (((pageIndex + 22) / 22) - 1).ToString();

                        if ((pageIndex + 22) >= RadioCount)
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "none");

                            btn_PageNext.Visible = false;
                        }
                        else
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "block");
                            btn_PageNext.HRef = "~/Radio/update/" + (((pageIndex + 22) / 22) + 1).ToString();
                        }
                    }
                }
                else
                {

                    btn_PageNext.Attributes.CssStyle.Add("display", "none");
                    btn_PageBack.Attributes.CssStyle.Add("display", "none");
                }
                if (RadioCount == 0)
                {

                    noData.Visible = true;
                }
                else
                {

                    noData.Visible = false;
                }
                #endregion

                lst_movies.DataSource = _cls.GetAllSound(22, pageIndex, Class_Layer.UserPanels());
                lst_movies.DataBind();
            }
            else if (RouteData.Values["query"].ToString().ToLower() == "archive")
            {
                #region CalculatePaging
                RadioCount = _cls.GetRadioCount(Class_Layer.UserPanels(), true);
                if (RadioCount > 22)
                {
                    if (pageIndex == 0)
                    {
                        btn_PageNext.HRef = "~/Radio/archive/2";
                        btn_PageBack.Attributes.CssStyle.Add("display", "none");

                    }
                    else
                    {
                        btn_PageBack.Attributes.CssStyle.Add("display", "block");
                        btn_PageBack.HRef = "~/Radio/archive/" + (((pageIndex + 22) / 22) - 1).ToString();

                        if ((pageIndex + 22) >= RadioCount)
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "none");

                            btn_PageNext.Visible = false;
                        }
                        else
                        {
                            btn_PageNext.Attributes.CssStyle.Add("display", "block");
                            btn_PageNext.HRef = "~/Radio/archive/" + (((pageIndex + 22) / 22) + 1).ToString();
                        }
                    }
                }
                else
                {

                    btn_PageNext.Attributes.CssStyle.Add("display", "none");
                    btn_PageBack.Attributes.CssStyle.Add("display", "none");
                }
                if (RadioCount == 0)
                {

                    noData.Visible = true;
                }
                else
                {

                    noData.Visible = false;
                }
                #endregion
                lst_movies.DataSource = _cls.GetAllSound(22, pageIndex, Class_Layer.UserPanels());
                lst_movies.DataBind();
            }


        }
        public string GetTitle(string Title)
        {
            if (Title == null) return "";
            if (Title == "") return "";
            if (Title.Length <= 60) return Title;

            return Title.Substring(0, 60) + "...";
        }
    }
}