using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using PArtCore.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.UserControls
{
    public partial class UC_ChartWelcome_Bultan : System.Web.UI.UserControl
    {
        Class_Zaman _clsZm = new Class_Zaman();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        Pages.P_Art.Repository.Class_Ado _clsAdo = new Pages.P_Art.Repository.Class_Ado();
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ArchiveId"] != null)
                {
                    string archiveId = Request.QueryString["ArchiveId"] + "";


                    Tbl_BultanArchive archive = (new Class_BultanArchive()).GetBultanByArchiveId(Convert.ToInt32(archiveId));
                    hddFromDate.Value = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(archive.FromDateIndex));
                    hddToDate.Value = PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateToCorrectDate(Convert.ToInt32(archive.ToDateIndex));
                    hddParmin.Value = archive.PanelId.ToString();
                    hddParmin2.Value = archive.PanelId.ToString();
                    hddId.Value = archiveId;

                    newspaper.InnerText = LoadNewsPaper();
                    prepareDivs();
                    string value = "0";

                    int firstPageCount = 0;
                    int secondPageCount = 0;
                    int thirdPageCount = 0;
                    int fourthPageCount = 0;
                    int fifthPageCount = 0;
                    int sixthPageCount = 0;

                    List<Tbl_BultanArchiveFeatures> settings = (new Class_BultanArchiveFeature()).GetList(archive.ArchiveId);
                    if (settings.Any(i => i.SettingTitle == "all_top_news"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_news").SettingValue;
                        if (value == "1")
                        {
                            div_all_top_news.Style.Remove("display");
                            div_all_top_news.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_top_radio"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_radio").SettingValue;
                        if (value == "1")
                        {
                            div_all_top_radio.Style.Remove("display");
                            div_all_top_radio.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_top_video"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_video").SettingValue;
                        if (value == "1")
                        {
                            div_all_top_video.Style.Remove("display");
                            div_all_top_video.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_top_social"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_top_social").SettingValue;
                        if (value == "1")
                        {
                            div_all_top_social.Style.Remove("display");
                            div_all_top_social.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_instagram"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_instagram").SettingValue;
                        if (value == "1")
                        {
                            div_all_instagram.Style.Remove("display");
                            div_all_instagram.Style.Add("display", "inline-block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_twitter"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_twitter").SettingValue;
                        if (value == "1")
                        {
                            div_all_twitter.Style.Remove("display");
                            div_all_twitter.Style.Add("display", "inline-block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_telegram"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_telegram").SettingValue;
                        if (value == "1")
                        {
                            div_all_telegram.Style.Remove("display");
                            div_all_telegram.Style.Add("display", "inline-block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_website"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_website").SettingValue;
                        if (value == "1")
                        {
                            div_all_website.Style.Remove("display");
                            div_all_website.Style.Add("display", "inline-block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "all_newspaper"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "all_newspaper").SettingValue;
                        if (value == "1")
                        {
                            div_all_newspaper.Style.Remove("display");
                            div_all_newspaper.Style.Add("display", "inline-block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "social_count_day"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "social_count_day").SettingValue;
                        if (value == "1")
                        {
                            div_social_count_day.Style.Remove("display");
                            div_social_count_day.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "tafkik_news_online"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "tafkik_news_online").SettingValue;
                        if (value == "1")
                        {
                            div_tafkik_news_online.Style.Remove("display");
                            div_tafkik_news_online.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "tafkik_social"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "tafkik_social").SettingValue;
                        if (value == "1")
                        {
                            div_tafkik_social.Style.Remove("display");
                            div_tafkik_social.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "tafkik_tv"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "tafkik_tv").SettingValue;
                        if (value == "1")
                        {
                            div_tafkik_tv.Style.Remove("display");
                            div_tafkik_tv.Style.Add("display", "block");
                            firstPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "top_hashtag"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "top_hashtag").SettingValue;
                        if (value == "1")
                        {
                            div_top_hashtag.Style.Remove("display");
                            div_top_hashtag.Style.Add("display", "block");
                            secondPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "jensiat"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "jensiat").SettingValue;
                        if (value == "1")
                        {
                            div_jensiat.Style.Remove("display");
                            div_jensiat.Style.Add("display", "block");
                            secondPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "news_mosbat_manfi"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "news_mosbat_manfi").SettingValue;
                        if (value == "1")
                        {
                            div_news_mosbat_manfi.Style.Remove("display");
                            div_news_mosbat_manfi.Style.Add("display", "block");
                            thirdPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "top_twitter"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "top_twitter").SettingValue;
                        if (value == "1")
                        {
                            //div_top_twitter.Style.Remove("display");
                            //div_top_twitter.Style.Add("display", "block");
                            thirdPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "sugiri_webnewspaper_mosbat"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "sugiri_webnewspaper_mosbat").SettingValue;
                        if (value == "1")
                        {
                            div_sugiri_webnewspaper_mosbat.Style.Remove("display");
                            div_sugiri_webnewspaper_mosbat.Style.Add("display", "block");
                            thirdPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "sugiri_webnewspaper_manfi"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "sugiri_webnewspaper_manfi").SettingValue;
                        if (value == "1")
                        {
                            div_sugiri_webnewspaper_manfi.Style.Remove("display");
                            div_sugiri_webnewspaper_manfi.Style.Add("display", "block");
                            thirdPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "cloud_chart_twitter"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "cloud_chart_twitter").SettingValue;
                        if (value == "1")
                        {
                            div_cloud_chart_twitter.Style.Remove("display");
                            div_cloud_chart_twitter.Style.Add("display", "block");
                            fourthPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "cloud_chart_news"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "cloud_chart_news").SettingValue;
                        if (value == "1")
                        {
                            div_cloud_chart_news.Style.Remove("display");
                            div_cloud_chart_news.Style.Add("display", "block");
                            fourthPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "map_twitter"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "map_twitter").SettingValue;
                        if (value == "1")
                        {
                            div_map_twitter.Style.Remove("display");
                            div_map_twitter.Style.Add("display", "block");
                            fourthPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "map_instagram"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "map_instagram").SettingValue;
                        if (value == "1")
                        {
                            div_map_instagram.Style.Remove("display");
                            div_map_instagram.Style.Add("display", "block");
                            fifthPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "map_telegram"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "map_telegram").SettingValue;
                        if (value == "1")
                        {
                            div_map_telegram.Style.Remove("display");
                            div_map_telegram.Style.Add("display", "block");
                            fifthPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "news_bohransaz_mosbat"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "news_bohransaz_mosbat").SettingValue;
                        if (value == "1")
                        {
                            div_news_bohransaz_mosbat.Style.Remove("display");
                            div_news_bohransaz_mosbat.Style.Add("display", "block");
                            sixthPageCount++;
                        }
                    }
                    if (settings.Any(i => i.SettingTitle == "news_bohransaz_manfi"))
                    {
                        value = settings.FirstOrDefault(i => i.SettingTitle == "news_bohransaz_manfi").SettingValue;
                        if (value == "1")
                        {
                            div_news_bohransaz_manfi.Style.Remove("display");
                            div_news_bohransaz_manfi.Style.Add("display", "block");
                            sixthPageCount++;
                        }
                    }
                    //if (settings.Any(i => i.SettingTitle == "newspaper"))
                    //{
                    //    value = settings.FirstOrDefault(i => i.SettingTitle == "newspaper").SettingValue;
                    //    if (value == "1")
                    //    {
                    //        div_newspaper.Visible = true;
                    //        sixthPageCount++;
                    //    }
                    //}

                    if (firstPageCount > 0)
                    {
                        divFirstPage.Style.Remove("display");
                        divFirstPage.Style.Add("display", "block");
                    }
                    if (secondPageCount > 0)
                    {
                        divSecondPage.Style.Remove("display");
                        divSecondPage.Style.Add("display", "block");
                    }
                    if (thirdPageCount > 0)
                    {
                        divThirdPage.Style.Remove("display");
                        divThirdPage.Style.Add("display", "block");
                    }
                    if (fourthPageCount > 0)
                    {
                        divFourthPage.Style.Remove("display");
                        divFourthPage.Style.Add("display", "block");
                    }
                    if (fifthPageCount > 0)
                    {
                        divFifthPage.Style.Remove("display");
                        divFifthPage.Style.Add("display", "block");
                    }
                    if (sixthPageCount > 0)
                    {
                        divSixthPage.Style.Remove("display");
                        divSixthPage.Style.Add("display", "block");
                    }
                }
            }
        }
        public void prepareDivs()
        {
            div_all_top_news.Style.Add("display", "none");
            div_all_instagram.Style.Add("display", "none");
            div_all_newspaper.Style.Add("display", "none");
            div_all_telegram.Style.Add("display", "none");
            div_all_top_radio.Style.Add("display", "none");
            div_all_top_social.Style.Add("display", "none");
            div_all_top_video.Style.Add("display", "none");
            div_all_twitter.Style.Add("display", "none");
            div_all_website.Style.Add("display", "none");
            div_cloud_chart_news.Style.Add("display", "none");
            div_cloud_chart_twitter.Style.Add("display", "none");
            div_jensiat.Style.Add("display", "none");
            div_map_instagram.Style.Add("display", "none");
            div_map_telegram.Style.Add("display", "none");
            div_map_twitter.Style.Add("display", "none");
            div_newspaper.Style.Add("display", "none");
            div_news_bohransaz_manfi.Style.Add("display", "none");
            div_news_bohransaz_mosbat.Style.Add("display", "none");
            div_news_mosbat_manfi.Style.Add("display", "none");
            div_social_count_day.Style.Add("display", "none");
            div_sugiri_webnewspaper_manfi.Style.Add("display", "none");
            div_sugiri_webnewspaper_mosbat.Style.Add("display", "none");
            div_tafkik_news_online.Style.Add("display", "none");
            div_tafkik_social.Style.Add("display", "none");
            div_tafkik_tv.Style.Add("display", "none");
            div_top_hashtag.Style.Add("display", "none");
            div_top_twitter.Style.Add("display", "none");

            divFirstPage.Style.Add("display", "none");
            divSecondPage.Style.Add("display", "none");
            divThirdPage.Style.Add("display", "none");
            divFourthPage.Style.Add("display", "none");
            divFifthPage.Style.Add("display", "none");
            divSixthPage.Style.Add("display", "none");
            ////div_all_top_news.Visible = false;
            ////div_all_instagram.Visible = false;
            ////div_all_newspaper.Visible = false;
            ////div_all_telegram.Visible = false;
            ////div_all_top_radio.Visible = false;
            ////div_all_top_social.Visible = false;
            ////div_all_top_video.Visible = false;
            ////div_all_twitter.Visible = false;
            ////div_all_website.Visible = false;
            ////div_cloud_chart_news.Visible = false;
            ////div_cloud_chart_twitter.Visible = false;
            ////div_jensiat.Visible = false;
            ////div_map_instagram.Visible = false;
            ////div_map_telegram.Visible = false;
            ////div_map_twitter.Visible = false;
            ////div_newspaper.Visible = false;
            ////div_news_bohransaz_manfi.Visible = false;
            ////div_news_bohransaz_mosbat.Visible = false;
            ////div_news_mosbat_manfi.Visible = false;
            ////div_social_count_day.Visible = false;
            ////div_sugiri_webnewspaper_manfi.Visible = false;
            ////div_sugiri_webnewspaper_mosbat.Visible = false;
            ////div_tafkik_news_online.Visible = false;
            ////div_tafkik_social.Visible = false;
            ////div_tafkik_tv.Visible = false;
            ////div_top_hashtag.Visible = false;
            ////div_top_twitter.Visible = false;

            ////divFirstPage.Visible = false;
            ////divSecondPage.Visible = false;
            ////divThirdPage.Visible = false;
            ////divFourthPage.Visible = false;
            ////divFifthPage.Visible = false;
            ////divSixthPage.Visible = false;
        }
        public string LoadNewsPaper()
        {
            try
            {



                var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'> گیشه مطبوعات </span></div>   
                                                  
                                     
                                    </header>";

                var footerHtml = @"<footer><span>" + 1 + @"</span></footer>";

                var htmlNewsPaper = "";

                var sqlCmdNimta = @" select nimtaId,'http://media.e-sepaar.net/nimta/' 
                            + OriginalImage as 'Path','http://media.e-sepaar.net/nimta/' 
                            + LargePath as 'LargePath',Title,SiteID_FK From Tbl_Nimta where NimtaDate = '1399/08/22'";



                var allNewsPaper = _clsAdo.FillDataTable(sqlCmdNimta);
                if (allNewsPaper != null && allNewsPaper.Rows.Count > 0)
                {
                    var nimtaCounter = 0;
                    var nimtaHtml = "";
                    foreach (DataRow nimtaRow in allNewsPaper.Rows)
                    {
                        nimtaCounter += 1;
                        nimtaHtml += @" <div class='nimtaItem nimtaOrderItem" + nimtaCounter + "'  id='nimta" + nimtaRow["nimtaId"] + @"'>
                                <a href='" + nimtaRow["Path"] + @"' data-src='" + nimtaRow["Path"] + @"' class='fancybox' rel='group'>
                                   
                                    <img class='lazy' src='http://media.e-sepaar.net/logo/nopic.jpg'  data-src='" + nimtaRow["Path"] + @"' />

                                   
                                </a>
                            </div>";


                    }
                    if (!string.IsNullOrWhiteSpace(nimtaHtml))
                    {
                        htmlNewsPaper = headerHtml + nimtaHtml + footerHtml;

                    }

                }
                return htmlNewsPaper;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}