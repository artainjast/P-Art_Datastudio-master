using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class Movies : System.Web.UI.Page
    {
        private Class_Movies _cls = new Class_Movies();
        string type = "1";
        string network = "همه شبکه ها";
        string keyword = "";
        Class_Zaman _clsZm = new Class_Zaman();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Class_Layer.CheckSession();
                try
                {
                    type = Page.Request.QueryString["type"];
                }
                catch { type = "1"; }
                if (type == null)
                    type = "1";


                try
                {
                    network = Page.Request.QueryString["network"];
                }
                catch { network = "همه شبکه ها"; }
                if (network == null)
                    network = "همه شبکه ها";

                DateTime dtFrom = DateTime.Now.AddDays(-30);
                string dateFromStr = _clsZm.MiladiToShamsi(dtFrom.ToShortDateString());
                dateFromStr = dateFromStr.Substring(0, 10).Replace("/", "");

                DateTime dtTo = DateTime.Now;
                string dateToStr = _clsZm.MiladiToShamsi(dtTo.ToShortDateString());
                dateToStr = dateToStr.Substring(0, 10).Replace("/", "");
                try
                {
                    keyword = Page.Request.QueryString["keyword"];
                }
                catch { keyword = ""; }
                if (keyword == null)
                    keyword = "";
                int dateFrom = 0;
                try
                {
                    if (Page.Request.QueryString["from"] != null)
                    {
                        dateFrom = Convert.ToInt32(Page.Request.QueryString["from"].ToString());
                        txt_fromDate.Text = dateFrom.ToString().Substring(0, 4) + "/" + dateFrom.ToString().Substring(4, 2) + "/" + dateFrom.ToString().Substring(6, 2);
                    }
                    else
                    {
                        dateFrom = Convert.ToInt32(dateFromStr);
                        txt_fromDate.Text = dateFrom.ToString().Substring(0, 4) + "/" + dateFrom.ToString().Substring(4, 2) + "/" + dateFrom.ToString().Substring(6, 2);
                    }
                }
                catch
                {
                    dateFrom = Convert.ToInt32(dateFromStr);
                    txt_fromDate.Text = dateFromStr;
                }
                int dateTo = 0;
                try
                {
                    if (Page.Request.QueryString["to"] != null)
                    {
                        dateTo = Convert.ToInt32(Page.Request.QueryString["to"].ToString());
                        txt_toDate.Text = dateTo.ToString().Substring(0, 4) + "/" + dateTo.ToString().Substring(4, 2) + "/" + dateTo.ToString().Substring(6, 2);
                    }
                    else
                    {
                        dateTo = Convert.ToInt32(dateToStr);
                        txt_toDate.Text = _clsZm.Today(); ;
                    }
                }
                catch
                {
                    dateTo = Convert.ToInt32(dateToStr);
                    txt_toDate.Text = _clsZm.Today(); ;
                }
                LoadData(type, keyword, network, dateFrom, dateTo);
            }
         

        }




        private void LoadData(string type, string keyword, string network, int fromIndex, int toIndex)
        {

            if (RouteData.Values["VideoId"] != null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Button), "src", "PlayVideo(" + RouteData.Values["VideoId"].ToString() + ");", true);

            }
            List<string> IranNetworkName = new List<string>();
            List<string> IntenationalNetworkName = new List<string>();


            if (type == "1" && network == "همه شبکه ها")
            {
                IranNetworkName.Add("شبکه 1");
                IranNetworkName.Add("شبکه 2");
                IranNetworkName.Add("شبکه خبر");
                IranNetworkName.Add("شبکه 5");
                IranNetworkName.Add("شبکه 3");
                IranNetworkName.Add("شبکه 4");

            }
            else if (type == "1" && network != "همه شبکه ها")
            {
                IranNetworkName.Add(network);
            }
            else if (type == "2" && network == "همه شبکه ها")
            {

                IntenationalNetworkName.Add("شبکه بي بي سي");
                IntenationalNetworkName.Add("شبکه منوتو");
                IntenationalNetworkName.Add("شبکه ایران اینترنشنال");
                IntenationalNetworkName.Add("شبکه صدای آمریکا");
            }
            else if (type == "2" && network != "همه شبکه ها")
            {
                IntenationalNetworkName.Add(network);
            }


            List<string> Networks = new List<string>();
            if (type == "1")
                Networks = IranNetworkName;
            else
                Networks = IntenationalNetworkName;
            var result = _cls.GetAllMovie(100, 1, Class_Layer.UserPanels(), null, keyword, null, Networks, fromIndex, toIndex);
            List<ModelNews.Tbl_Movies> resultTop10 = new List<ModelNews.Tbl_Movies>();
            List<ModelNews.Tbl_Movies> resultArchive = new List<ModelNews.Tbl_Movies>();
            List<ModelNews.Tbl_Movies> resultMostvisit = new List<ModelNews.Tbl_Movies>();
            int index = 0;

            if (result.Count != 0)
            {
                foreach (ModelNews.Tbl_Movies movie in result)
                {

                    if (index < 8)
                        resultTop10.Add(movie);
                    else if (index < 18)
                        resultMostvisit.Add(movie);
                    //else if (index < 60)
                    resultArchive.Add(movie);
                    index++;
                }
                hddFirstMovie.Value = result.FirstOrDefault().MovieID.ToString();
            }
            if (resultTop10.Count != 0)
            {
                List<Class_Movies.Tbl_Type_Movie> movieLatTop10 = new List<Class_Movies.Tbl_Type_Movie>();
                foreach (var item in resultTop10)
                {
                    Class_Movies.Tbl_Type_Movie m = new Class_Movies.Tbl_Type_Movie();
                    m.Active = item.Active;
                    m.CampainId = item.CampainId;
                    m.CompanyType = item.CompanyType;
                    m.CreateDate = item.CreateDate;
                    m.CreateUser = item.CreateUser;
                    m.DefaultPrice = item.DefaultPrice;
                    m.EditDate = item.EditDate;
                    m.EditUser = item.EditUser;
                    m.IsForeign = item.IsForeign;
                    m.IsView = item.IsView;
                    m.MediaKitGroupID = item.MediaKitGroupID;
                    m.MovieID = item.MovieID;
                    m.NetworkGroupID = item.NetworkGroupID;
                    m.NetworkName = item.NetworkName;
                    m.PackageID = item.PackageID;
                    m.Percent = item.Percent;
                    m.Periority = item.Periority;
                    m.PlayTime = item.PlayTime;
                    m.Position = item.Position;
                    m.PosterPath = item.PosterPath;
                    m.ProgramName = item.ProgramName;
                    m.ProgramTime = item.ProgramTime;
                    m.Rate = item.Rate;
                    m.SendAllInOneTelegram = item.SendAllInOneTelegram;
                    m.Tabaghe = item.Tabaghe;
                    m.Title = item.Title;
                    m.TizerPackCount = item.TizerPackCount;
                    m.Type = item.Type;
                    m.VideoDate = item.VideoDate;
                    m.VideoDateIndex = Convert.ToInt32(item.VideoDateIndex);
                    m.VideoPath = item.VideoPath;
                    m.VideoPriceGroup = item.VideoPriceGroup;
                    m.VideoTime = item.VideoTime;
                    m.ViewCount = item.ViewCount;
                    m.weekdayindex = item.weekdayindex;
                    movieLatTop10.Add(m);
                }
                lst_movies.DataSource = movieLatTop10.Where(i => i.VideoDateIndex >= fromIndex && i.VideoDateIndex <= toIndex).ToList();
                lst_movies.DataBind();
            }
            if (resultMostvisit.Count != 0)
            {
                List<Class_Movies.Tbl_Type_Movie> movieMostvisit = new List<Class_Movies.Tbl_Type_Movie>();
                foreach (var item in resultMostvisit)
                {
                    Class_Movies.Tbl_Type_Movie m = new Class_Movies.Tbl_Type_Movie();
                    m.Active = item.Active;
                    m.CampainId = item.CampainId;
                    m.CompanyType = item.CompanyType;
                    m.CreateDate = item.CreateDate;
                    m.CreateUser = item.CreateUser;
                    m.DefaultPrice = item.DefaultPrice;
                    m.EditDate = item.EditDate;
                    m.EditUser = item.EditUser;
                    m.IsForeign = item.IsForeign;
                    m.IsView = item.IsView;
                    m.MediaKitGroupID = item.MediaKitGroupID;
                    m.MovieID = item.MovieID;
                    m.NetworkGroupID = item.NetworkGroupID;
                    m.NetworkName = item.NetworkName;
                    m.PackageID = item.PackageID;
                    m.Percent = item.Percent;
                    m.Periority = item.Periority;
                    m.PlayTime = item.PlayTime;
                    m.Position = item.Position;
                    m.PosterPath = item.PosterPath;
                    m.ProgramName = item.ProgramName;
                    m.ProgramTime = item.ProgramTime;
                    m.Rate = item.Rate;
                    m.SendAllInOneTelegram = item.SendAllInOneTelegram;
                    m.Tabaghe = item.Tabaghe;
                    m.Title = item.Title;
                    m.TizerPackCount = item.TizerPackCount;
                    m.Type = item.Type;
                    m.VideoDate = item.VideoDate;
                    m.VideoDateIndex = Convert.ToInt32(item.VideoDateIndex);
                    m.VideoPath = item.VideoPath;
                    m.VideoPriceGroup = item.VideoPriceGroup;
                    m.VideoTime = item.VideoTime;
                    m.ViewCount = item.ViewCount;
                    m.weekdayindex = item.weekdayindex;
                    movieMostvisit.Add(m);
                }
                rptMostView.DataSource = movieMostvisit.Where(i => i.VideoDateIndex >= fromIndex && i.VideoDateIndex <= toIndex).ToList(); ;
                rptMostView.DataBind();
            }

            if (resultArchive.Count != 0)
            {
                List<Class_Movies.Tbl_Type_Movie> movieArchive = new List<Class_Movies.Tbl_Type_Movie>();
                foreach (var item in resultArchive)
                {
                    Class_Movies.Tbl_Type_Movie m = new Class_Movies.Tbl_Type_Movie();
                    m.Active = item.Active;
                    m.CampainId = item.CampainId;
                    m.CompanyType = item.CompanyType;
                    m.CreateDate = item.CreateDate;
                    m.CreateUser = item.CreateUser;
                    m.DefaultPrice = item.DefaultPrice;
                    m.EditDate = item.EditDate;
                    m.EditUser = item.EditUser;
                    m.IsForeign = item.IsForeign;
                    m.IsView = item.IsView;
                    m.MediaKitGroupID = item.MediaKitGroupID;
                    m.MovieID = item.MovieID;
                    m.NetworkGroupID = item.NetworkGroupID;
                    m.NetworkName = item.NetworkName;
                    m.PackageID = item.PackageID;
                    m.Percent = item.Percent;
                    m.Periority = item.Periority;
                    m.PlayTime = item.PlayTime;
                    m.Position = item.Position;
                    m.PosterPath = item.PosterPath;
                    m.ProgramName = item.ProgramName;
                    m.ProgramTime = item.ProgramTime;
                    m.Rate = item.Rate;
                    m.SendAllInOneTelegram = item.SendAllInOneTelegram;
                    m.Tabaghe = item.Tabaghe;
                    m.Title = item.Title;
                    m.TizerPackCount = item.TizerPackCount;
                    m.Type = item.Type;
                    m.VideoDate = item.VideoDate;
                    m.VideoDateIndex = Convert.ToInt32(item.VideoDateIndex);
                    m.VideoPath = item.VideoPath;
                    m.VideoPriceGroup = item.VideoPriceGroup;
                    m.VideoTime = item.VideoTime;
                    m.ViewCount = item.ViewCount;
                    m.weekdayindex = item.weekdayindex;
                    movieArchive.Add(m);
                }
                rptMovieArchive.DataSource = movieArchive.Where(i => i.VideoDateIndex >= fromIndex && i.VideoDateIndex <= toIndex).ToList(); ;
                rptMovieArchive.DataBind();
            }
            if (result.Count == 0)
            {

                noData.Visible = true;
            }
            else
            {

                noData.Visible = false;
            }

            //HtmlGenericControl sideBar = this.Master.FindControl("sidebar") as HtmlGenericControl;
            //sideBar.Visible = false;
        }

        public string GetTitle(string Title)
        {
            if (Title == null) return "";
            if (Title == "") return "";
            if (Title.Length <= 50) return Title;

            return Title.Substring(0, 50) + "...";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                type = Page.Request.QueryString["type"];
            }
            catch { type = "1"; }
            if (type == null)
                type = "1";

            DateTime dtFrom = DateTime.Now.AddDays(-30);
            string dateFromStr = _clsZm.MiladiToShamsi(dtFrom.ToShortDateString());
            dateFromStr = dateFromStr.Substring(0, 10).Replace("/", "");

            DateTime dtTo = DateTime.Now;
            string dateToStr = _clsZm.MiladiToShamsi(dtTo.ToShortDateString());
            dateToStr = dateToStr.Substring(0, 10).Replace("/", "");

            int dateFrom = 0;
            try
            {
                dateFrom = Convert.ToInt32(Page.Request.QueryString["from"].ToString());
            }
            catch { dateFrom = Convert.ToInt32(dateFromStr); }
            int dateTo = 0;
            try
            {
                dateTo = Convert.ToInt32(Page.Request.QueryString["to"].ToString());
            }
            catch { dateTo = Convert.ToInt32(dateToStr); }



            LoadData(type, txtKeyword.Text.Trim(), ddlNetwork.SelectedValue, dateFrom, dateTo);
        }

        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            try
            {
                type = Page.Request.QueryString["type"];
            }
            catch { type = "1"; }
            if (type == null)
                type = "1";

            DateTime dtFrom = DateTime.Now.AddDays(-30);
            string dateFromStr = _clsZm.MiladiToShamsi(dtFrom.ToShortDateString());
            dateFromStr = dateFromStr.Substring(0, 10).Replace("/", "");

            DateTime dtTo = DateTime.Now;
            string dateToStr = _clsZm.MiladiToShamsi(dtTo.ToShortDateString());
            dateToStr = dateToStr.Substring(0, 10).Replace("/", "");

            int dateFrom = 0;
            try
            {
                dateFrom = Convert.ToInt32(txt_fromDate.Text.Replace("/", ""));
            }
            catch { dateFrom = Convert.ToInt32(dateFromStr); }
            int dateTo = 0;
            try
            {
                dateTo = Convert.ToInt32(txt_toDate.Text.Replace("/", ""));
            }
            catch { dateTo = Convert.ToInt32(dateToStr); }

           Response.Redirect("/Movies/Latest?type=" + type + "&network=" + network + "&from=" + dateFrom + "&to=" + dateTo);

            //LoadData(type, txtKeyword.Text.Trim(), ddlNetwork.SelectedValue, dateFrom, dateTo);
        }
    }
}