using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class HtmlGroupNews : System.Web.UI.Page
    {
        //List<int?> UserPanels = new List<int?>();

        public static string DiffrentDate(object ddate, string sitetype, string newstime, string newsDateStr)
        {
            Class_Zaman zm = new Class_Zaman();
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            var newsDtTime = new DateTime();
            if (string.IsNullOrWhiteSpace(newsDateStr))
            {
                newsDtTime = Convert.ToDateTime(ddate);
            }
            else
            {
                newsDtTime = Class_Static.ConvertIntFarsiDate(newsDateStr);
            }

            if (sitetype == "2")
            {
                return Persia.Calendar.ConvertToPersian(newsDtTime).ToString();

            }
            var dt = new DateTime();
            if (!string.IsNullOrWhiteSpace(newstime))
            {
                try
                {
                    var newsDate = Convert.ToDateTime(newsDtTime);
                    newstime = Class_Static.GetAbsoluteTime(newstime);
                    var newstimeSpil = newstime.Split(':');
                    dt = new DateTime(newsDate.Year, newsDate.Month, newsDate.Day, Convert.ToInt32(newstimeSpil[0]), Convert.ToInt32(newstimeSpil[1]), 0);
                    //  return Class_Static.GetOnTimeDate(dateTime);
                }
                catch
                {
                    dt = (newsDtTime);
                    //return Class_Static.GetOnTimeDate();



                }

            }
            else
            {
                // return Class_Static.GetOnTimeDate(Convert.ToDateTime(ddate));
                dt = Convert.ToDateTime(newsDtTime);
            }


            return Class_Static.GetOnTimeDate(dt);


        }
        string BoultanName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var galleryNewspaper = "";
                var newsPaperHtml = "";
                hdfBultanType.Value = "2";
                if (Request.QueryString["ArchiveId"] != null)
                {
                    hdfBultanArchiveID.Value = Request.QueryString["ArchiveId"] + "";

                    Tbl_BultanArchive archive = (new Class_BultanArchive()).GetBultanByArchiveId(Convert.ToInt32(hdfBultanArchiveID.Value));
                    hdfDate.Value = archive.FromDateIndex;
                    hdfToDate.Value = archive.ToDateIndex;
                    hdfParmin.Value = archive.PanelId.ToString();
                    hdfSelectedBultan.Value = archive.SelectedBultan.ToString();
                    hdfSelectedNews.Value = archive.SelectedNews.ToString();
                    hdfAllowHighlight.Value = archive.AllowHighlight.ToString();
                    hdfAllowChart.Value = archive.AllowChart.ToString();
                    hdfAllowGroup.Value = archive.AllowGroup.ToString();
                    hdfGalleryNewspaper.Value = archive.AllowGalleryNewspaper.ToString();
                    hdfSima.Value = archive.AllowSima.ToString();
                    hdfArz.Value = archive.AllowArz.ToString();
                    hdfAllowrelated.Value = archive.AllowRelated.ToString();
                    hdfAllowNewspaper.Value = archive.AllowNewspaper.ToString();
                    BoultanName = archive.Name;
                    try { hdfBultanType.Value = archive.BultanType.ToString(); } catch { hdfBultanType.Value = "2"; }
                }
                else
                {
                    #region oldTypeBultan
                    hdfAllowrelated.Value = "false";
                    if (Request.QueryString["AllowRelated"] != null)
                    {
                        hdfAllowrelated.Value = Request.QueryString["AllowRelated"].ToString();
                    }
                    if (Request.QueryString["fromdate"] != null)
                    {
                        if (Request.QueryString["toDate"] != null)
                        {
                            hdfDate.Value = Class_Static.ShamisiWithoutSlash(Request.QueryString["toDate"] + "").Trim();
                            hdfToDate.Value = Class_Static.ShamisiWithoutSlash(Request.QueryString["toDate"] + "").Trim();
                        }
                        else
                        {
                            hdfDate.Value = Class_Static.ShamisiWithoutSlash(Request.QueryString["fromdate"] + "").Trim();

                        }
                    }
                    else
                    {
                        hdfDate.Value = Class_Static.GetFarsiDate(DateTime.Now);
                    }
                    if (Request.QueryString["parmin"] != null)
                    {
                        hdfParmin.Value = Request.QueryString["parmin"];

                    }
                    else
                    {
                        hdfParmin.Value = "551";
                    }

                    if (Request.QueryString["selectedBultan"] != null)
                    {
                        hdfSelectedBultan.Value = Request.QueryString["selectedBultan"];

                    }
                    else
                    {
                        hdfSelectedBultan.Value = "68";

                    }

                    if (Request.QueryString["SelectedNews"] != null)
                    {
                        hdfSelectedNews.Value = Request.QueryString["SelectedNews"] + "";
                    }
                    if (Request.QueryString["bultanArchiveId"] != null)
                    {
                        hdfBultanArchiveID.Value = Request.QueryString["bultanArchiveId"] + "";
                    }
                    hdfAllowHighlight.Value = "true";
                    if (Request.QueryString["AllowHighlight"] != null)
                    {
                        hdfAllowHighlight.Value = Request.QueryString["AllowHighlight"] + "";
                    }
                    hdfAllowGroup.Value = "false";
                    if (Request.QueryString["AllowGroup"] != null)
                    {
                        hdfAllowGroup.Value = Request.QueryString["AllowGroup"] + "";
                    }
                    hdfGalleryNewspaper.Value = "false";
                    if (Request.QueryString["GalleryNewspaper"] != null)
                    {
                        hdfGalleryNewspaper.Value = Request.QueryString["GalleryNewspaper"] + "";
                    }
                    hdfSima.Value = "false";
                    if (Request.QueryString["Sima"] != null)
                    {
                        hdfSima.Value = Request.QueryString["Sima"] + "";
                    }
                    hdfAllowrelated.Value = "false";
                    if (Request.QueryString["AllowRelated"] != null)
                    {
                        hdfAllowrelated.Value = Request.QueryString["AllowRelated"] + "";
                    }
                    hdfArz.Value = "false";
                    if (Request.QueryString["Arz"] != null)
                    {
                        hdfArz.Value = Request.QueryString["Arz"] + "";
                    }

                    if (Request.QueryString["bultanArchiveId"] != null)
                    {
                        hdfBultanArchiveID.Value = Request.QueryString["bultanArchiveId"] + "";
                    }


                    var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);

                    hdfAllowNewspaper.Value = "false";
                    if (Request.QueryString["checkNewsPaper"] != null)
                    {
                        hdfAllowNewspaper.Value = Request.QueryString["checkNewsPaper"];
                    }
                    #endregion
                }

                if (hdfGalleryNewspaper.Value.ToLower() == "true")
                {
                    galleryNewspaper = LoadAllNewsPaper();
                }
                if (hdfAllowNewspaper.Value.ToLower() == "true")
                {

                    newsPaperHtml = LoadNewsPaper();
                }
                var jeldHtml = "";
                var newsHtml = "";
                var arzHtml = "";
                var simaHtml = "";
                var chartHtml = "";

                jeldHtml = LoadJeld();
                newsHtml = LoadNews();
                arzHtml = LoadArz();
                simaHtml = LoadSima();
                if (hdfAllowChart.Value.ToLower() == "true")
                    chartHtml = LoadChart(Convert.ToInt32(hdfBultanArchiveID.Value));
                ltNewsHtml.Text = LoadFixedHeader() + jeldHtml + galleryNewspaper + newsPaperHtml +
                    arzHtml + simaHtml + chartHtml + newsHtml;


            }
        }

        Class_Ado _clsAdo = new Class_Ado();
        Class_News _clsNews = new Class_News();
        Class_BultanArchive _clsBultanArchive = new Class_BultanArchive();
        Class_Keywords _clsKeyword = new Class_Keywords();
        HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
        Class_BultanFiles _clsBultanFiles = new Class_BultanFiles();
        public string LoadNewsPaper()
        {
            try
            {
                var seletedDate = Class_Static.ShamsiToMiladi(hdfToDate.Value);

                string bultanNewsDate = "";

                try
                {
                    if (hdfDate.Value != hdfToDate.Value)
                    { bultanNewsDate = hdfDate.Value.Substring(0, 4) + "/" + hdfDate.Value.Substring(4, 2) + "/" + hdfDate.Value.Substring(6, 2) + " - " + hdfToDate.Value.Substring(0, 4) + "/" + hdfToDate.Value.Substring(4, 2) + "/" + hdfToDate.Value.Substring(6, 2); }
                    else
                    { bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate); }

                }
                catch
                { }

                var ParminNimtaCodes = "";

                try
                {
                    var dtNimtaCodes = _clsAdo.FillDataTable("SELECT TOP 1 ParminNimtaCodes FROM Tbl_Parmin WHERE ParminID IN (" + hdfParmin.Value + ")");
                    ParminNimtaCodes = (dtNimtaCodes.Rows[0][0] + "").Trim();
                }
                catch { }


                var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'> پبشخوان روزنامه های منتخب </span></div>   
                                                  
                                      <div class='left'>    <span class='headerBultanDate'>" + bultanNewsDate + @"</span></div>
                                    </header>";

                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";

                var htmlNewsPaper = "";

                string[] codes = ParminNimtaCodes.Split(',');
                var sqlCmdNimta = "";
                foreach (var c in codes)
                {
                    sqlCmdNimta += @" select nimtaId,'http://media.e-sepaar.net/nimta/' 
                            + OriginalImage as 'Path','http://media.e-sepaar.net/nimta/' 
                            + LargePath as 'LargePath',Title,SiteID_FK From Tbl_Nimta where NimtaDate = '" +
                           Class_Static.ShamisiBySlash(hdfToDate.Value) +
                           "' and SiteID_FK in (" + c + ") union";
                }
                if (sqlCmdNimta != string.Empty)
                {
                    if (sqlCmdNimta.Length > 5)
                    {
                        sqlCmdNimta = sqlCmdNimta.Substring(0, (sqlCmdNimta.Length - 5));
                    }
                }


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
                        if (nimtaCounter == 2)
                        {
                            htmlNewsPaper += "<div class='page nimtaContainer'>" + headerHtml + nimtaHtml + footerHtml + "</div>";
                            // htmlNewsPaper = "";
                            nimtaHtml = "";
                            nimtaCounter = 0;
                        }
                        else
                        {
                            //  htmlNewsPaper = nimtaHtml;
                        }

                    }
                    if (!string.IsNullOrWhiteSpace(nimtaHtml))
                    {
                        htmlNewsPaper += "<div id='divNewsPaper' class='page nimtaContainer'>" + headerHtml + nimtaHtml + footerHtml + "</div>";

                    }

                }
                return htmlNewsPaper;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        Class_Panels _clsParmin = new Class_Panels();
        public string LoadFixedHeader()
        {
            // hdfSelectedBultan.Value
            //     hdfDate.Value
            var html = @"";

            var parmin = _clsParmin.GetParminById(Convert.ToInt32(hdfParmin.Value));
            var seletedBultan = _clsBultanArchive.GetBultanById(Convert.ToInt32(hdfBultanArchiveID.Value));

            var time = Persia.Calendar.ConvertToPersian(Class_Static.ShamsiToMiladi(hdfToDate.Value.ToString())).ToString("N");
            try
            {
                time += " ساعت " + seletedBultan.CreateDate.Value.Hour + ":" + seletedBultan.CreateDate.Value.Minute;
            }
            catch
            {

            }
            if (string.IsNullOrWhiteSpace(parmin.ParminLogo))
            {
                parmin.ParminLogo = "";
                html = @"<div id='fixedheader' class='clearfix'>
            <div id='title' >
 

                                    <span>" + parmin.AgName + " - " + seletedBultan.Name + @"</span>
  

                     </div>
  
 <div id='titleDate'> " + time + @" </div>


                   </div> ";
            }
            else
            {
                html = @"<div id='fixedheader'>
            <div id='title' >
 
                                 <img height='50' class='lazy'  src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + parmin.ParminLogo + @"' >

                                    <span>" + parmin.AgName + " - " + seletedBultan.Name + @"</span>
  

                     </div>
  
 <div id='titleDate'>  " + time + @"  </div>


                   </div> ";
            }

            //<h3>" + Class_Static.ShamisiBySlash(hdfDate.Value) + @"</h3>
            //                      <h4></h4>
            ltIntroInfo.Text = @"  <div class='logo'>
                                        <img src='" + parmin.ParminLogo + @"' alt='" + parmin.AgName + @"'>
                                    </div>
                                    <h2>" + parmin.AgName + " - " + seletedBultan.Name + @"</h2>
                                  
                                    <h5>تاریخ انتشار: " + time + "</h5>";



            return html;
        }
        public string LoadAllNewsPaper()
        {
            try
            {
                var seletedDate = Class_Static.ShamsiToMiladi(hdfToDate.Value);

                string bultanNewsDate = "";

                try
                {
                    if (hdfDate.Value != hdfToDate.Value)
                    { bultanNewsDate = hdfDate.Value.Substring(0, 4) + "/" + hdfDate.Value.Substring(4, 2) + "/" + hdfDate.Value.Substring(6, 2) + " - " + hdfToDate.Value.Substring(0, 4) + "/" + hdfToDate.Value.Substring(4, 2) + "/" + hdfToDate.Value.Substring(6, 2); }
                    else
                    { bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate); }

                }
                catch
                { }


                var ParminNimtaCodes = "";




                var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'> پبشخوان تمامی روزنامه ها </span></div>   
                                                  
                                      <div class='left'>    <span class='headerBultanDate'>" + bultanNewsDate + @"</span></div>
                                    </header>";

                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";

                var htmlNewsPaper = "";


                var sqlCmdNimta = @" select nimtaId,'http://media.e-sepaar.net/nimta/' 
                            + OriginalImage as 'Path','http://media.e-sepaar.net/nimta/' 
                            + PreviewPath as 'PreviewPath',Title,SiteID_FK From Tbl_Nimta where NimtaDate = '" +
                       Class_Static.ShamisiBySlash(hdfDate.Value) +
                       "' ";



                var allNewsPaper = _clsAdo.FillDataTable(sqlCmdNimta);
                if (allNewsPaper != null && allNewsPaper.Rows.Count > 0)
                {
                    var nimtaCounter = 0;
                    var nimtaHtml = "";
                    foreach (DataRow nimtaRow in allNewsPaper.Rows)
                    {

                        nimtaHtml += @" <div class='nimtaItem nimtaOrderItem" + nimtaCounter + "'  id='nimta" + nimtaRow["nimtaId"] + @"'>
                                <a href='" + nimtaRow["Path"] + @"' data-src='" + nimtaRow["Path"] + @"' class='fancyboxGallery' rel='group'>
                                   
                                    <img  class='lazy' src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + nimtaRow["PreviewPath"] + @"' />

                                   
                                </a>
                            </div>";



                    }
                    if (!string.IsNullOrWhiteSpace(nimtaHtml))
                    {
                        htmlNewsPaper += "<div id='divAllNewsPaper' class='page nimtaContainer nimtaGalleryContainer'>" + headerHtml + nimtaHtml + "</div>";

                    }

                }



                return htmlNewsPaper;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static int currentPage = 1;
        private string LoadNews()
        {
            List<Tbl_NewsRelate_Type> newsRelatedList = new List<Tbl_NewsRelate_Type>();
            var parminIds = new List<int?>();
            foreach (var parm in hdfParmin.Value.Split(','))
            {
                parminIds.Add(Convert.ToInt32(parm));

            }

            var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);

            string bultanNewsDate = "";
            try
            {
                if (hdfDate.Value != hdfToDate.Value)
                { bultanNewsDate = hdfDate.Value.Substring(0, 4) + "/" + hdfDate.Value.Substring(4, 2) + "/" + hdfDate.Value.Substring(6, 2) + " - " + hdfToDate.Value.Substring(0, 4) + "/" + hdfToDate.Value.Substring(4, 2) + "/" + hdfToDate.Value.Substring(6, 2); }
                else
                { bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate); }

            }
            catch
            { }



            int RecordCount = 1000;
            var fromDate = Class_Static.GetIntFarsiDate(seletedDate);
            var toDate = Class_Static.GetIntFarsiDate(Class_Static.ShamsiToMiladi(hdfToDate.Value));// fromDate;
            var strSearch = "";
            string NewsIds = "";
            int siteId = 0;
            int time = 0;
            var UserHighlight = new List<string>();

            var NewsIdsFinal = "";
            if (!string.IsNullOrWhiteSpace(hdfBultanArchiveID.Value))
            {

                try
                {
                    NewsIdsFinal = _clsBultanArchive.GetBultanById(Convert.ToInt32(hdfBultanArchiveID.Value)).SelectedNews;
                }
                catch
                {

                }
            }
            else
            {

                NewsIds = hdfSelectedNews.Value;
            }
            var lstNewsIds = new List<int>();
            try
            {
                foreach (var spil in NewsIdsFinal.Split(','))
                {
                    if (string.IsNullOrWhiteSpace(spil)) continue;
                    if (spil == ",") continue;
                    lstNewsIds.Add(Convert.ToInt32(spil));
                }
            }
            catch { }

            // اگر خبری سلکت شده بود
            if (!string.IsNullOrWhiteSpace(NewsIds) && string.IsNullOrWhiteSpace(NewsIdsFinal))
            {
                NewsIds = NewsIds.Replace(",,", ",");
                NewsIds = NewsIds.Replace(",undefined,", ",");
                NewsIds = NewsIds.Replace(",,", ",");

                if (NewsIds.Substring(0, 1) == ",") NewsIds = NewsIds.Substring(1, NewsIds.Length - 1);
                if (NewsIds.Substring(NewsIds.Length - 1, 1) == ",") NewsIds = NewsIds.Substring(0, NewsIds.Length - 1);
                NewsIds = NewsIds.Replace(",,", ",");


                var lstNewsDic = new Dictionary<int, int>();
                foreach (var n in NewsIds.Split(','))
                {

                    if (string.IsNullOrWhiteSpace(n)) continue;

                    var nVal = Convert.ToInt32(n.Split(';')[0]);
                    var nOrder = Convert.ToInt32(n.Split(';')[1]);

                    if (lstNewsDic.Any(t => t.Key == nVal))
                    {
                        //اگر خبری با همین مشخصه اولیت بالاتر یعنی اول تر بود آپدیت کن
                        if (lstNewsDic.FirstOrDefault(t => t.Key == nVal).Value == 1000 && nOrder != 1000)
                        {
                            lstNewsDic.Remove(nVal);
                            lstNewsDic.Add(nVal, nOrder);
                        }
                        continue;
                    }
                    lstNewsDic.Add(nVal, nOrder);
                }

                foreach (var item in lstNewsDic.OrderBy(t => t.Value).ToList())
                {
                    NewsIdsFinal += "," + item.Key;
                }
                if (!string.IsNullOrWhiteSpace(NewsIdsFinal))
                {
                    NewsIdsFinal = NewsIdsFinal.Substring(1);
                }
            }
            DataTable result;
            if (hdfAllowrelated.Value != null)
            {
                if (hdfAllowrelated.Value.ToString().ToLower() == "true")
                {
                    DataSet ds = _clsNews.GetAllNewsDataTableByRelatedProcedure(RecordCount, 1, parminIds, null, true, UserHighlight, fromDate, toDate, strSearch, siteId, null, "", "", NewsIdsFinal, "", false);
                    result = ds.Tables[0];
                    newsRelatedList = Tbl_NewsRelate_Type.GetFromDataRows(ds.Tables[1].Select());
                }
                else
                {
                    result = _clsNews.GetAllNewsDataTableByNewsIds(RecordCount, 1, parminIds, null, true, UserHighlight, fromDate, toDate, strSearch, siteId, null, "", "", NewsIdsFinal, "", false);
                }
            }
            else
            {
                result = _clsNews.GetAllNewsDataTableByNewsIds(RecordCount, 1, parminIds, null, true, UserHighlight, fromDate, toDate, strSearch, siteId, null, "", "", NewsIdsFinal, "", false);
            }

            var lstDuplicateCRC = new List<long>();


            var lstDic = new Dictionary<string, int>();

            var index = 0;
            var lstNews = new List<Tbl_News_Type>();

            List<Tbl_RssKeywords> keywords = null;
            keywords = _clsKeyword.GetRssKeywordByPanelIds(parminIds);

            int indexOrder = -1;
            char HalfSpace = (char)8204;
            char space = (char)' ';
            foreach (DataRow dr in result.Rows)
            {
                indexOrder++;

                try
                {

                    var NewsTitleSel = Class_Static.ArabicAlpha(dr["NewsTitle"].ToString().ToLower().Trim());

                    NewsTitleSel = NewsTitleSel.Replace(HalfSpace, space);
                    NewsTitleSel = Persia.PersianWord.ConvertToLatinNumber(NewsTitleSel);
                    var NewsLinkUrl = (dr["NewsLink"]);
                    var SiteIDSel = Convert.ToInt32(dr["SiteID"]);
                    var NewsDateIndex = Convert.ToInt64(dr["NewsDate"].ToString().Replace("/", ""));

                    var titleCRC = Math.Abs(NewsTitleSel.Trim().GetHashCode());



                    lstDic.Add(titleCRC + "" + SiteIDSel + "" + NewsDateIndex, SiteIDSel);

                    //  }
                    var keyId = Convert.ToInt32(dr["GroupId"]);
                    var currentKey = keywords.FirstOrDefault(i => i.KeyId == keyId); /*_clsKeyword.GetRssKeywordById(Convert.ToInt32(dr["GroupId"]));*/

                    // if (keywords == null)
                    // {
                    //     var ls = new List<int?>();
                    //     ls.Add(Convert.ToInt32(dr["KeywordId"]));
                    //     keywords = _clsKeyword.GetRssKeywordByPanelIds(ls);
                    // }
                    try
                    {
                        if (string.IsNullOrWhiteSpace(dr["NewsLead"] + ""))
                        {
                            dr["NewsLead"] = (dr["NewsBody"] + "").Split('.').FirstOrDefault() + ".";

                        }
                    }
                    catch
                    {

                    }
                    lstNews.Add(new Tbl_News_Type
                    {
                        //NewsLink = (dr["NewsLink"] + "").StartsWith("http://") ? (dr["NewsLink"]) + "" : "/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"],
                        NewsLink = "/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"],
                        UserIndexOrder = indexOrder,
                        SiteID = Convert.ToInt32(dr["SiteID"]),
                        NewsID = Convert.ToInt32(dr["NewsID"]),
                        GroupId = Convert.ToInt32(dr["GroupId"]),
                        KeywordID = Convert.ToInt32(dr["KeywordId"]),
                        NewsTitle = _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false),
                        NewsDate = dr["NewsDate"] + "",
                        NewsLead = _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false),
                        KeywordName = dr["KeywordName"] + "",
                        NewsBody = _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false),
                        SiteTitle = dr["SiteTitle"] + "",
                        NewsPicture = dr["NewsPicture"] + "",
                        GroupName = dr["GroupName"] + "",
                        CreateDate = (dr["CreateDate"] + ""),
                        SiteType = Convert.ToInt32(dr["SiteType"]),
                        NewsTime = dr["NewsTime"] + "",
                        SiteLogo = dr["Logo"] + "",
                        GroupOrder = Class_Static.ToNullableInt(dr["GroupOrder"] + ""),
                        NewsValue = (dr["NewsValue"] + ""),
                        NewsGroupOrder = Class_Static.ToNullableInt(dr["NewsGroupOrder"] + ""),
                        NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"]),
                        RelatedNewsStringIds = (dr["RelatedNewsStringIds"] + ""),
                        RelatedString = (dr["RelatedNewsStringIds"] + ""),
                        //   OrderItem= dr["GroupOrder"] + "",
                    });


                    index++;

                }
                catch (Exception ex)
                {

                    index++;
                    continue;
                }
            }

            lstNews = lstNews.OrderBy(d => lstNewsIds.IndexOf(d.NewsID)).ToList();

            lstNews = lstNews.GroupBy(test => test.NewsID).Select(grp => grp.First()).ToList();

            lstNews = Class_Static.GenerateNewsTags(lstNews, parminIds).ToList();

            var allowRelated = false;

            if (hdfBultanType.Value.ToString() != "3")
            {
                if (hdfAllowrelated.Value != null)
                {
                    if (hdfAllowrelated.Value.ToString().ToLower() == "true")
                    {
                        allowRelated = true;
                        foreach (var nn in lstNews)
                        {
                            string relateds = "";
                            foreach (var r in newsRelatedList.Where(i => i.NewsId == nn.NewsID).ToList())
                            {
                                relateds += relateds != string.Empty ? "," : string.Empty;
                                relateds += r.RelateNewsId;
                            }
                            nn.RelatedNewsStringIds = relateds;
                            nn.RelatedString = relateds;
                        }
                        lstNews = LoadRelated(lstNews);
                    }
                }
            }
            if (hdfBultanType.Value.ToString() == "3")
            {
                allowRelated = true;
                lstNews = LoadTamarkozRasaneyi(lstNews);
                lstNews = lstNews.OrderByDescending(t => t.RelatedString.Length).ToList();
            }
            foreach (var item in lstNews)
            {
                var currentKey = keywords.FirstOrDefault(i => i.KeyId == item.KeywordID); /*_clsKeyword.GetRssKeywordById(item.KeywordID);*/
                item.NewsTitle = hdfAllowHighlight.Value.ToLower() == "true" ? Class_Static.HighlightKeywords(currentKey, item.NewsTitle, keywords) : item.NewsTitle;
                item.NewsLead = hdfAllowHighlight.Value.ToLower() == "true" ? Class_Static.HighlightKeywords(currentKey, item.NewsLead, keywords) : item.NewsLead;
                item.NewsBody = hdfAllowHighlight.Value.ToLower() == "true" ? Class_Static.HighlightKeywords(currentKey, item.NewsBody, keywords) : item.NewsBody;

            }

            var html = "";


            //انجمن منتقدین
            if (parminIds.Any(t => t == 2230))
            {
                lstNews = lstNews.OrderBy(t => t.NewsDate).ToList();
            }

            html = LoadFehrest(lstNews);

            var listGroupName = lstNews.GroupBy(t => t.GroupOrder).Select(g => g.First()).OrderBy(t => t.GroupOrder).ToList();




            var str = "";
            foreach (var item in listGroupName)
            {
                str += "," + item.GroupName;
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                hdfGroups.Value = str.Substring(1);
            }
            // rptNews.DataSource = lstNews.OrderBy(t => t.GroupName).ThenBy(t => t.KeywordName).ToList();

            var MaxPageLength = 3200;
            var MaxPageNewLength = 3900;
            var MaxVerbInPage = 529;
            int CurrentPageIndex = 1;
            // var MaxPageContentLength = 6000;
            var isPageBreaked = false;

            var lastHeader = "";

            foreach (var item in listGroupName)
            {

                if (string.IsNullOrWhiteSpace(item.GroupName))
                {
                    try
                    {
                        item.GroupName = _clsKeyword.GetRssKeywordByGroupOrder(Convert.ToInt32(hdfParmin.Value.Split(',')[0]), item.GroupOrder);
                        //var counterComapreNews = 0;
                        //while (string.IsNullOrWhiteSpace(item.GroupName))
                        //{
                        //    item.GroupName = lstNews.Where(t => t.GroupOrder == item.GroupOrder).Take(counterComapreNews).FirstOrDefault().GroupName;
                        //    counterComapreNews += 1;
                        //}
                    }
                    catch
                    {

                    }
                }

                var htmlPageNews = "";

                var watermark = "";
                if (parminIds.Any(t => t == 551))
                {
                    //   watermark += "<div class='watermark'><abbr>دفتر روابط عمومی وزارت علوم،تحقیقات و فناوری</abbr></div>";
                }

                var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'>گزیده اخبار و رویدادها" + " - " + item.GroupName + @" </span></div>   
                                                  
                                      <div class='left'>    <span class='headerBultanDate'>" + bultanNewsDate + @"</span></div>
                                    </header>";
                lastHeader = headerHtml;
                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                if (hdfAllowGroup.Value == "True")
                {
                    if (lstNews.Any(t => t.GroupOrder == item.GroupOrder))
                    {
                        html += "<div class='page groupContainer'>" + watermark + @"<div class='newsGroupRow clearfix'><h2>" + item.GroupName + "</h2></div>" + footerHtml + "</div>";
                    }
                }
                try
                {

                    foreach (var news in lstNews.Where(t => t.GroupOrder == item.GroupOrder).ToList())
                    {
                        string[] splitedVerbsNewsBody = news.NewsBody.Split(' ');
                        var relatedStringHtml = "";
                        //نمایش اخبار مرتبط
                        if (allowRelated)
                        {
                            try
                            {
                                foreach (var related in news.RelateListStrings)
                                {

                                    relatedStringHtml += "<a target='_blank' title='" + (related.Split('$')[2] + "").Trim().Replace("<span class='highlight'>", "").Replace("</span>", "") + "' href='/ShowBultanNewsItem.aspx?newsId=" + related.Split('$')[0] + "'>" + related.Split('$')[1] + "</a>";

                                }
                                if (!string.IsNullOrWhiteSpace(relatedStringHtml))
                                {
                                    relatedStringHtml = "<div class='relatedNews'><h6>اخبار مرتبط این خبر</h6><p>" + relatedStringHtml + "</p></div>";
                                }
                            }
                            catch
                            {

                            }
                            //if(news.RelateListIds!=null && news.RelateListIds.Count>0)
                            //   {
                            //     //  var newsRelated = _clsNews.GetNewsById(news.NewsID);

                            //       relatedStringHtml += "";
                            //   }
                        }

                        var htmlSingleNews = "";



                        try
                        {
                            news.NewsLead = Class_Static.PrepareNewsLead(news.NewsLead);
                            news.NewsBody = Class_Static.PrepareNewsBody(news.NewsBody);
                        }
                        catch
                        {

                        }

                        news.SiteLogo = (news.SiteLogo + "").ToLower().Replace("c:\\bultanforms\\logos\\", "http://media.e-sepaar.net/logo/");
                        //if (!Class_Static.UrlExists(news.SiteLogo))
                        //{
                        //    news.SiteLogo = "http://media.e-sepaar.net/logo/nologo.jpg";
                        //}
                        try
                        {
                            var pictureHtml = "";
                            var newsTimeTag = @" <div class='newsDate'>
                                     " + news.NewsDate + @"
                                </div> ";
                            if (news.SiteType == 1)
                            {
                                newsTimeTag += @" <div class='newsTime'>
                                     " + news.NewsTime + @"
                                </div> ";
                                //if (!Class_Static.UrlExists(news.NewsPicture))
                                //{
                                //    news.NewsPicture = "http://media.e-sepaar.net/logo/nopic.jpg";
                                //}
                                //pictureHtml = @"  <div class='newsPicture'>
                                //    <a>
                                //        <img src='" + (news.NewsPicture) + @"' /></a>
                                //</div>";
                            }
                            //if (Class_Static.UrlExists(news.NewsPicture))
                            //{
                            pictureHtml = @"  <div class='newsPicture'>
                                    <a>
                                        <img class='lazy' src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + (news.NewsPicture) + @"' /></a>
                                </div>";
                            // }


                            var newsValueHtml = "";
                            if (!string.IsNullOrWhiteSpace(news.NewsValue))
                            {
                                if (news.NewsValue == "1")
                                {
                                    newsValueHtml = @"<div class='newsValue plusNews'>
                                    <a>
                                       مثبت</a>
                                </div>";

                                }
                                else if (news.NewsValue == "2")
                                {
                                    newsValueHtml = @"<div class='newsValue minuesNews'>
                                    <a>
                                       منفی</a>
                                </div>";
                                }
                            }

                            // اگر متن خبر دو صفحه ای بود
                            if (htmlPageNews.Length + news.NewsBody.Length > MaxPageLength)
                            {
                                var maxLength = 0;
                                if (!string.IsNullOrWhiteSpace(htmlPageNews))
                                {
                                    maxLength = MaxPageLength - htmlPageNews.Length;
                                }
                                else
                                {
                                    maxLength = MaxPageLength;
                                }
                                //  var maxLength = (news.NewsBody.Length + htmlPageNews.Length) - MaxPageLength;

                                var splitedNewsBody = news.NewsBody.Substring(0, maxLength);
                                //string splitedNewsBody = "";

                                //for(int v=0; v < MaxVerbInPage; v++)
                                //{
                                //    CurrentPageIndex++;
                                //    splitedNewsBody += splitedVerbsNewsBody[v] + " ";
                                //}
                                var counterMinus = 1;
                                var counterWhile = 0;
                                var findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                                {
                                    if (counterWhile > 500)
                                    {
                                        break;
                                    }
                                    //_clsNews.InsertLog(0, news.NewsID + "  کد خبر f   ");
                                    counterMinus++;
                                    findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                    counterWhile++;
                                }
                                splitedNewsBody = news.NewsBody.Substring(0, (maxLength - counterMinus) + 1);
                                var afterSplitedNewsBody = news.NewsBody.Substring(maxLength - counterMinus + 1);

                                string direction = "";
                                if (!news.NewsBody.Contains("ا") || !news.NewsBody.Contains("و"))
                                    direction = "Style='direction:ltr;text-align:left;'";
                                //ثبت قسمت اول
                                htmlSingleNews = @" <div " + direction + " class='newsItem clearfix'  data-id='" + news.NewsID + @"' data-group='" + news.GroupName + @"' id='news_" + news.NewsID + @"'>

                                                                <div class='right newsTools' style=''>

                               <div class='GroupName'>" + Class_Static.PersianAlpha(news.GroupName) + @"</div>

                                                            <div class='KeywordName'>" + Class_Static.PersianAlpha(news.KeywordName) + @"</div>
                            <div class='siteLogo'><a><img class='lazy'  src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + (news.SiteLogo) + @"'/></a></div>
                                                            <div class='siteTitle'>" + Class_Static.PersianAlpha(news.SiteTitle) + @"</div>
                             " + newsTimeTag + @"
                              " + pictureHtml + @"
                              " + relatedStringHtml + @"

                            </div>";



                                if (news.NewsTypeShow == (byte)2)
                                {
                                    htmlSingleNews += @" <div class='right newsDetails' style=''> 
                                                         <div class='newsTitle'>
                                                              <a href = '" + (news.NewsLink) + @"' target='_blank'>" +
                                                              Class_Static.PersianAlpha(news.NewsTitle) + @"</a>
                                                          </div>  
                                                        <div style='text-align:center;margin:0 auto;margin-bottom:10px' ><img src='" + news.NewsPicture + @"' ></div></div>";
                                    afterSplitedNewsBody = "";
                                }
                                else
                                {
                                    htmlSingleNews += @" <div class='right newsDetails' style=''>   
                                                          <div class='newsTitle'>
                                                              <a href = '" + (news.NewsLink) + @"' target='_blank'>" +
                                                              Class_Static.PersianAlpha(news.NewsTitle) + @"</a>
                                                          </div>
                                                           <div class='newsLead'>" + (news.NewsLead) + @"</div>
                                                           <div class='newsBody'>" + (splitedNewsBody) + @"</div>
                                                         </div>";
                                }
                                htmlSingleNews += @" </div>  ";
                                footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                                if (!string.IsNullOrWhiteSpace(htmlPageNews + htmlSingleNews))
                                {
                                    html += "<div class='page pageContainer'>" + headerHtml + htmlPageNews + htmlSingleNews + footerHtml + "</div>";

                                }
                                htmlPageNews = "";
                                htmlSingleNews = "";

                                // آیا صفحه دوم و سوم نیاز دارد؟
                                var counterPageInt = 1;
                                while (afterSplitedNewsBody.Length > (MaxPageNewLength))
                                {
                                    //_clsNews.InsertLog(0, news.NewsID + "  کد خبر   ");
                                    counterPageInt += 1;
                                    try
                                    {
                                        var afterSplitedNewsBody2 = afterSplitedNewsBody;

                                        maxLength = afterSplitedNewsBody2.Length - (afterSplitedNewsBody2.Length - (MaxPageNewLength));

                                        splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength);
                                        counterMinus = 1;

                                        findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                        counterWhile = 0;
                                        while (findedChar != "." && findedChar != "؛" && findedChar != "," && findedChar != "," && findedChar != "،" && findedChar != ";")
                                        {
                                            if (counterWhile > 500)
                                            {
                                                break;
                                            }
                                            //_clsNews.InsertLog(0, news.NewsID + "  فایندر   ");
                                            counterMinus++;
                                            findedChar = splitedNewsBody.Substring(splitedNewsBody.Length - counterMinus, 1);
                                            counterWhile++;
                                        }
                                        splitedNewsBody = afterSplitedNewsBody2.Substring(0, maxLength - counterMinus + 1);
                                        afterSplitedNewsBody = afterSplitedNewsBody2.Substring(maxLength - counterMinus + 1);

                                        //ثبت قسمت دوم
                                        htmlSingleNews = @"



                                                            <div " + direction + " class='newsItem clearfix'  data-childgroup='" + news.GroupName + @"' id='news_" + counterPageInt + "_" + news.NewsID + @"'>

                                                                <div class='right newsTools' style=''>
   <div class='newsContinued'><a>ادامه خبر صفحه قبل " + " <br/> " + "[ " + counterPageInt + " ]" + @" </a></div>
                               <div class='GroupName'>" + Class_Static.PersianAlpha(news.GroupName) + @"</div>

                                                            <div class='KeywordName'>" + Class_Static.PersianAlpha(news.KeywordName) + @"</div>
                            <div class='siteLogo'><a><img class='lazy'  src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + (news.SiteLogo) + @"'/></a></div>
                                                            <div class='siteTitle'>" + Class_Static.PersianAlpha(news.SiteTitle) + @"</div>
                              " + newsTimeTag + @"
                              " + pictureHtml + @"
                              " + relatedStringHtml + @"
                            </div>

                                                        <div class='right newsDetails' style=''>   
                                                          
                                                            <div class='newsBody'>" + (splitedNewsBody) + @"</div>
                                                          </div>
                                                        </div>  ";

                                        footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                                        if (!string.IsNullOrWhiteSpace(htmlSingleNews))
                                        {
                                            html += "<div class='page pageContainer'>" + headerHtml + htmlSingleNews + footerHtml + "</div>";

                                        }
                                    }
                                    catch
                                    {

                                    }
                                    htmlPageNews = "";
                                    htmlSingleNews = "";
                                }



                                if (afterSplitedNewsBody.Length > 0)
                                {
                                    counterPageInt++;
                                    // ثبت صفحه دوم یا سوم و ادامه خبر
                                    htmlSingleNews = @"



                                                            <div " + direction + " class='newsItem clearfix'   data-childgroup='" + news.GroupName + @"' id='news_" + (counterPageInt + 1) + "_" + news.NewsID + @"'>

                                                                <div class='right newsTools' style=''>
                            <div class='newsContinued'><a>ادامه خبر صفحه قبل " + " <br/> " + "[ " + counterPageInt + " ]" + @" </a></div>
                               <div class='GroupName'>" + Class_Static.PersianAlpha(news.GroupName) + @"</div>

                                                            <div class='KeywordName'>" + Class_Static.PersianAlpha(news.KeywordName) + @"</div>
                            <div class='siteLogo'><a><img class='lazy'  src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + (news.SiteLogo) + @"'/></a></div>
                                                            <div class='siteTitle'>" + Class_Static.PersianAlpha(news.SiteTitle) + @"</div>
                             " + newsTimeTag + @"
                              " + pictureHtml + @"
                             " + relatedStringHtml + @"
                            </div>

                                                        <div class='right newsDetails' style=''>   

                                                            <div class='newsBody'>" + (afterSplitedNewsBody) + @"</div>
                                                          </div>
                                                        </div>  ";
                                    if (!string.IsNullOrWhiteSpace(htmlSingleNews))
                                    {
                                        footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                                        html += "<div class='page pageContainer'>" + headerHtml + htmlSingleNews + footerHtml + "</div>";
                                    }
                                }
                                htmlPageNews = "";
                                htmlSingleNews = "";

                            }

                            else
                            {
                                string direction = "";
                                if (!news.NewsBody.Contains("ا") || !news.NewsBody.Contains("و"))
                                    direction = "Style='direction:ltr;text-align:left;'";

                                htmlSingleNews = @"
      
                                   

                                <div " + direction + " class='newsItem clearfix'  data-id='" + news.NewsID + @"' data-group='" + news.GroupName + @"' id='news_" + news.NewsID + @"'>
 
                                    <div class='right newsTools' style=''>
   <div class='GroupName'>" + Class_Static.PersianAlpha(news.GroupName) + @"</div>
                              
                                <div class='KeywordName'>" + Class_Static.PersianAlpha(news.KeywordName) + @"</div>" +
 "<div class='siteLogo'><a><img class='lazy'  src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + (news.SiteLogo) +
 @"'/></a></div>
                                <div class='siteTitle'>" + Class_Static.PersianAlpha(news.SiteTitle) + @"</div>
 " + newsTimeTag + @"
" + newsValueHtml + @"
  " + pictureHtml + @"
   " + relatedStringHtml + @"
                           </div>";

                                if (news.NewsTypeShow == (byte)2)
                                {
                                    htmlSingleNews += @" <div class='right newsDetails' style=''> 
                                                         <div class='newsTitle'>
                                                              <a href = '" + (news.NewsLink) + @"' target='_blank'>" +
                                                              Class_Static.PersianAlpha(news.NewsTitle) + @"</a>
                                                          </div>  
                                                        <div style='text-align:center;margin:0 auto;margin-bottom:10px' ><img src='" + news.NewsPicture + @"' ></div></div>";
                                }
                                else
                                {
                                    htmlSingleNews += @" <div class='right newsDetails' style=''>   
                                                          <div class='newsTitle'>
                                                              <a href = '" + (news.NewsLink) + @"' target='_blank'>" +
                                                              Class_Static.PersianAlpha(news.NewsTitle) + @"</a>
                                                          </div>
                                                           <div class='newsLead'>" + (news.NewsLead) + @"</div>
                                                           <div class='newsBody'>" + (news.NewsBody) + @"</div>
                                                         </div>";
                                }
                                htmlSingleNews += @" </div>  ";
                                //else
                            }
                        }
                        catch
                        {

                        }

                        var continueKeys = new string[] { ".", "!", "?", ",", "'", "''" };

                        if (!string.IsNullOrWhiteSpace(htmlPageNews))
                        {
                            if (htmlPageNews.Length + htmlSingleNews.Length < MaxPageLength)
                            {
                                html += "<div class='page pageContainer'>" + watermark + @"" + headerHtml + htmlPageNews + htmlSingleNews + footerHtml + "</div>";
                                htmlPageNews = "";
                                htmlSingleNews = "";
                            }
                            else
                            {
                                html += "<div class='page pageContainer'>" + watermark + @"" + headerHtml + htmlPageNews + footerHtml + "</div>";
                                htmlPageNews = htmlSingleNews;
                                htmlSingleNews = "";
                            }
                        }
                        else
                        {
                            //اگر خبری بود صفحه بساز

                            if (htmlSingleNews.Length < MaxPageLength / 2)
                            {
                                //  currentPage = currentPage + 1;

                                htmlPageNews += htmlSingleNews;


                            }
                            else
                            {
                                html += "<div class='page pageContainer'>" + watermark + @"" + headerHtml + htmlSingleNews + footerHtml + "</div>";
                                htmlPageNews = "";

                            }
                        }


                    }
                }
                catch
                {

                }
                if (!string.IsNullOrWhiteSpace(htmlPageNews))
                {

                    // currentPage = currentPage + 1;

                    footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                    html += "<div class='page pageContainer'> " + lastHeader + htmlPageNews + footerHtml + "</div>";
                    htmlPageNews = "";
                    // htmlSingleNews = "";
                }
            }


            return html;
        }
        private string LoadFehrest(List<Tbl_News_Type> lstNews)
        {
            var allowRelated = false;
            if (hdfBultanType.Value != null)
            {
                // if (hdfBultanType.Value.ToString() == "3")
                try
                {
                    allowRelated = Convert.ToBoolean(hdfAllowrelated.Value.ToString());
                }
                catch { allowRelated = false; }

            }

            //if (Request.QueryString["AllowRelated"] != null)
            //{
            //    if (Request.QueryString["AllowRelated"].ToLower() == "true")
            //    {
            //        allowRelated = true;

            //        // lstNews = Class_Static.LoadRelatedNews(lstNews);
            //    }
            //}



            var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);

            string bultanNewsDate = "";
            try
            {
                if (hdfDate.Value != hdfToDate.Value)
                { bultanNewsDate = hdfDate.Value.Substring(0, 4) + "/" + hdfDate.Value.Substring(4, 2) + "/" + hdfDate.Value.Substring(6, 2) + " - " + hdfToDate.Value.Substring(0, 4) + "/" + hdfToDate.Value.Substring(4, 2) + "/" + hdfToDate.Value.Substring(6, 2); }
                else
                { bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate); }

            }
            catch
            { }


            var MaxMenuLine = 25;
            var html = "";
            var listGroupName = lstNews.GroupBy(t => t.GroupOrder).Select(g => g.First()).OrderBy(t => t.GroupOrder).ToList();

            var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'>فهرست اخبار</span></div>   
                                                  
                                      <div class='left'>    <span class='headerBultanDate'>" + bultanNewsDate + @"</span></div>
                                    </header>";

            var htmlPageNews = "";
            var LineContinued = 0;

            foreach (var item in listGroupName)
            {
                if (string.IsNullOrWhiteSpace(item.GroupName))
                {
                    try
                    {
                        item.GroupName = _clsKeyword.GetRssKeywordByGroupOrder(Convert.ToInt32(hdfParmin.Value.Split(',')[0]), item.GroupOrder);
                        //var counterComapreNews = 0;
                        //while (string.IsNullOrWhiteSpace(item.GroupName))
                        //{
                        //    item.GroupName = lstNews.Where(t => t.GroupOrder == item.GroupOrder).Take(counterComapreNews).FirstOrDefault().GroupName;
                        //    counterComapreNews += 1;
                        //}
                    }
                    catch
                    {
                    }
                }
                try
                {
                    if (lstNews.Any(t => t.GroupOrder == item.GroupOrder))
                    {
                        htmlPageNews += "<div class='fehrestGroupRow clearfix'>" + item.GroupName + "</div>";

                    }
                    foreach (var news in lstNews.Where(t => t.GroupOrder == item.GroupOrder).ToList())
                    {

                        var relatedText = "";
                        if (allowRelated)
                        {
                            try
                            {
                                foreach (var related in news.RelateListStrings)
                                {
                                    relatedText += "," + related.Split('$')[1];
                                }
                                if (!string.IsNullOrWhiteSpace(relatedText))
                                {
                                    relatedText = " " + "(" + relatedText.Substring(1) + ")";
                                }
                            }
                            catch
                            {

                            }
                        }

                        var newsTimeTag = "";
                        if (news.SiteType == 1)
                        {
                            newsTimeTag += @" <span class='time'> 
                                     " + news.NewsTime + @"
                               </span>  ";
                        }
                        var htmlSingleNews = "";


                        var deleteStr = "";


                        if (HttpContext.Current.Session["CurrentUser"] != null)
                        {
                            deleteStr = " <a href='#' title='حذف خبر از بولتن' class='deleteNewsBooltan' onclick='DeleteNewsFromBooltanArchieve(" + hdfBultanArchiveID.Value + "," + news.NewsID + ")'  > x </a> ";
                        }
                        string shortedTitle = "";
                        var countHighlight = news.NewsTitle.Split(new string[] { "span" }, StringSplitOptions.None);
                        if (countHighlight.Count() > 3)
                        {
                            shortedTitle = PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(news.NewsTitle, 140);
                        }
                        else if (countHighlight.Count() > 1)
                        {
                            shortedTitle = PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(news.NewsTitle, 110);
                        }
                        else
                        {
                            shortedTitle = PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(news.NewsTitle, 80);
                        }
                        htmlSingleNews = @"<div class='fehrestRow clearfix'>
                             <div class='fehrestRowRight'> " + deleteStr +

                        @" <span class='circleSing'></span><a><img class='lazy' style='display: inline; width: 52px;height: 36px;'  src='http://media.e-sepaar.net/logo/nopic.jpg' data-src='" + (news.SiteLogo) + @"'/></a>                   
                            <a class='newsTitle' data-newsid='" + news.NewsID + @"'>" + shortedTitle + " " + "<span style='color:#F00'>" + relatedText + "</span>" + @"</a></div>
                                <div class='fehrestRowLeft'>   <span class='pageNumber'>" + news.NewsID + @"</span>                    
                                   " + newsTimeTag + @"             
                                             
 <span class='siteTitle'>" + news.SiteTitle + @"</span>   </div>
                        </div> ";
                        if (news.NewsTitle.Length > 100)
                        {
                            LineContinued += 2;

                        }
                        else
                        {
                            LineContinued += 1;

                        }
                        if (LineContinued > MaxMenuLine)
                        {
                            LineContinued = 0;
                            // currentPage = currentPage + 1;

                            var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";

                            html += "<div  class='page fehrestContainer'>" + headerHtml + htmlPageNews + footerHtml + "</div>";
                            htmlPageNews = htmlSingleNews;

                        }
                        else
                        {
                            htmlPageNews += htmlSingleNews;
                        }
                    }
                }
                catch
                {

                }
            }
            if (!string.IsNullOrWhiteSpace(htmlPageNews))
            {
                // currentPage = currentPage + 1;


                LineContinued = 0;
                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";


                html += "<div class='page fehrestContainer'> " + headerHtml + htmlPageNews + footerHtml + "</div>";

            }
            return "<span id='fehrestContainer'></span>" + html;
        }
        private string LoadChart(int ArchiveId)
        {


            var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
            string html = "<div class='page coverPage'>";
            html += "<div id='chart1'></div>";
            html += "<div id='chart2'></div>";
            html += "<div id='chart3'></div>";
            html += footerHtml + "</div>";

            return html;
        }
        public string LoadJeld()
        {
            var jeld = true;
            try
            {
                if (Request.QueryString["jeld"] != null)
                {
                    jeld = Convert.ToBoolean(Request.QueryString["jeld"]);
                }
            }
            catch
            {

            }
            var html = "";
            if (!jeld) return html;
            try
            {
                DateTime seletedDate;
                try { seletedDate = Class_Static.ShamsiToMiladi(hdfToDate.Value); } catch { seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value); }

                string bultanNewsDate = "";

                try
                {
                    if (hdfDate.Value != hdfToDate.Value)
                    { bultanNewsDate = hdfDate.Value.Substring(0, 4) + "/" + hdfDate.Value.Substring(4, 2) + "/" + hdfDate.Value.Substring(6, 2) + " - " + hdfToDate.Value.Substring(0, 4) + "/" + hdfToDate.Value.Substring(4, 2) + "/" + hdfToDate.Value.Substring(6, 2); }
                    else
                    { bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate); }

                }
                catch
                { }

                var BultanJeldPath = "";
                try
                {
                    var selectedBultan = _clsBultanFiles.SelectItem(Convert.ToInt32(hdfSelectedBultan.Value));
                    BultanJeldPath = selectedBultan.BultanJeldPath;
                }
                catch
                {
                    BultanJeldPath = "/Styles/img/jeld.jpg";
                }
                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";

                html = "<div class='page coverPage'><img  src='" + BultanJeldPath + "' /><time>" + bultanNewsDate + "</time><h3>" + BoultanName + "</h3>" + footerHtml + "</div>";


            }
            catch
            {

            }
            return html;


        }
        private string LoadArz()
        {
            try
            {
                if (hdfArz.Value.ToLower() == "false")
                    return "";
                var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);

                string bultanNewsDate = "";

                try
                {
                    if (hdfDate.Value != hdfToDate.Value)
                    { bultanNewsDate = hdfDate.Value.Substring(0, 4) + "/" + hdfDate.Value.Substring(4, 2) + "/" + hdfDate.Value.Substring(6, 2) + " - " + hdfToDate.Value.Substring(0, 4) + "/" + hdfToDate.Value.Substring(4, 2) + "/" + hdfToDate.Value.Substring(6, 2); }
                    else
                    { bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate); }

                }
                catch
                { }

                var fromDate = Class_Static.GetIntFarsiDate(seletedDate);

                List<Class_CurrencyStats> currencyStatsList = Class_CurrencyStats.GetList(fromDate.ToString());
                List<Class_CurrencyStats> talaSekeList = currencyStatsList.Where(i => i.CurrencyType == (byte)CurrencyType.GoldCoin).ToList();
                List<Class_CurrencyStats> currencyList = currencyStatsList.Where(i => i.CurrencyType == (byte)CurrencyType.Currency).ToList();
                List<Class_CurrencyStats> currencyExchList = currencyStatsList.Where(i => i.CurrencyType == (byte)CurrencyType.CurrencyExchange).ToList();
                var talaSekeHtml = @"<div class='Arz-body'> <div class='arz-header'>
                    <ul>
                        <li ><span class='arz-title'> سکه و طلا </span>
                       <span class='arz-value'>بروزرسانی</span>
                        <span class='arz-value'>تغییرات</span>
                        <span class='arz-value'> (ریال)</span></li>
                </ul>
                    </div> <ul>";
                foreach (var t in talaSekeList)
                {
                    string year = t.LastUpdateDateTimeIndex.Substring(0, 4);
                    string month = t.LastUpdateDateTimeIndex.Substring(4, 2);
                    string day = t.LastUpdateDateTimeIndex.Substring(6, 2);
                    string hour = t.LastUpdateDateTimeIndex.Substring(8, 2);
                    string min = t.LastUpdateDateTimeIndex.Substring(10, 2);
                    talaSekeHtml += @"<li><span class='arz-title' >" + t.Title +
                        "</span><span class='arz-value'>" + hour + ":" + min +
                                   "</span><span class='arz-value'>" + t.Diffrence +
                        "</span><span class='arz-value'>" + t.Price + "</span></li>";
                }
                talaSekeHtml += @"</ul></div>";

                var arzHtml = @"<div class='Arz-body'> <div class='arz-header'>      <ul>
                        <li ><span class='arz-title'> ارز </span>
                            <span class='arz-value'>بروزرسانی</span>
                        <span class='arz-value'>تغییرات</span>
                        <span class='arz-value'> (ریال)</span></li>
                </ul></div> <ul>";
                foreach (var t in currencyList)
                {
                    string year = t.LastUpdateDateTimeIndex.Substring(0, 4);
                    string month = t.LastUpdateDateTimeIndex.Substring(4, 2);
                    string day = t.LastUpdateDateTimeIndex.Substring(6, 2);
                    string hour = t.LastUpdateDateTimeIndex.Substring(8, 2);
                    string min = t.LastUpdateDateTimeIndex.Substring(10, 2);
                    arzHtml += @"<li><span class='arz-title' >" + t.Title +
                       "</span><span class='arz-value'>" + hour + ":" + min +
                                   "</span><span class='arz-value'>" + t.Diffrence +
                        "</span><span class='arz-value'>" + t.Price + "</span></li>";
                }
                arzHtml += @"</ul></div>";

                var arzMobadeleyiHtml = @"<div class='Arz-body'> <div class='arz-header'>      <ul>
                        <li ><span class='arz-title'> ارز مبادله ای </span>
                            <span class='arz-value'>بروزرسانی</span>
                        <span class='arz-value'>تغییرات</span>
                        <span class='arz-value'> (ریال)</span></li>
                </ul></div> <ul>";
                foreach (var t in currencyExchList)
                {
                    string year = t.LastUpdateDateTimeIndex.Substring(0, 4);
                    string month = t.LastUpdateDateTimeIndex.Substring(4, 2);
                    string day = t.LastUpdateDateTimeIndex.Substring(6, 2);
                    string hour = t.LastUpdateDateTimeIndex.Substring(8, 2);
                    string min = t.LastUpdateDateTimeIndex.Substring(10, 2);
                    arzMobadeleyiHtml += @"<li><span class='arz-title' >" + t.Title +
                        "</span><span class='arz-value'>" + hour + ":" + min +
                                   "</span><span class='arz-value'>" + t.Diffrence +
                        "</span><span class='arz-value'>" + t.Price + "</span></li>";
                }
                arzMobadeleyiHtml += @"</ul></div>";



                var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'> نرخ طلا، سکه و ارز </span></div>   
                                                  
                                      <div class='left'>    <span class='headerBultanDate'>" + bultanNewsDate + @"</span></div>
                                    </header>";

                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";


                return "<div class='page nimtaContainer' id='divArz' >" + headerHtml + arzHtml + arzMobadeleyiHtml + talaSekeHtml + footerHtml + "</div>";
            }
            catch { return ""; }
        }
        private string LoadSima()
        {
            try
            {
                if (hdfSima.Value.ToLower() == "false")
                    return "";
                var seletedDate = Class_Static.ShamsiToMiladi(hdfDate.Value);

                string bultanNewsDate = "";

                try
                {
                    if (hdfDate.Value != hdfToDate.Value)
                    { bultanNewsDate = hdfDate.Value.Substring(0, 4) + "/" + hdfDate.Value.Substring(4, 2) + "/" + hdfDate.Value.Substring(6, 2) + " - " + hdfToDate.Value.Substring(0, 4) + "/" + hdfToDate.Value.Substring(4, 2) + "/" + hdfToDate.Value.Substring(6, 2); }
                    else
                    { bultanNewsDate = Class_Static.GetFarsiDateFull(seletedDate); }

                }
                catch
                { }

                var fromDate = Class_Static.GetIntFarsiDate(seletedDate);
                var parminIds = new List<int?>();
                foreach (var parm in hdfParmin.Value.Split(','))
                {
                    parminIds.Add(Convert.ToInt32(parm));

                }
                var movieHtml = "";
                var headerHtml = @" <header class='clearfix'>
                                                 <div class='right'>  <span class='headerTitle'> صدا و سیما </span></div>   
                                                  
                                      <div class='left'>    <span class='headerBultanDate'>" + bultanNewsDate + @"</span></div>
                                    </header>";

                var footerHtml = @"<footer><span>" + currentPage + @"</span></footer>";
                var simaCounter = 0;
                var movieFullHtml = "";
                List<Tbl_Movies> movies = (new Class_Movies()).GetAllMovie(10, 1, parminIds, true, "", null);
                List<Tbl_Movies> datedMovies = movies.Where(i => Convert.ToInt64(i.VideoDateIndex) >= (fromDate - 3)).ToList();
                foreach (var m in datedMovies)
                {

                    //<source src='" + m.VideoPath + "' type='video/x-flv'>
                    simaCounter += 1;
                    movieHtml += "<div class='simaItem simaOrderItem" + simaCounter + "'  id='sima" + m.MovieID + "' > ";
                    movieHtml += @"<div class='simaItemHeader clearfix'><span class='videoSource'>" + m.NetworkName + " - " + m.ProgramName + "</span><span class='videoDate'>" + m.VideoDate + "  " + m.ProgramTime + "</span></div>";
                    movieHtml += @"<video width='600' height='460' poster='" + m.PosterPath + "' controls autobuffer='none'>";
                    movieHtml += @"<source src='" + m.VideoPath + "' type='video/mp4'/></video>";
                    movieHtml += @"<div class='simaItemFooter clearfix'><span class='videotitle'>" + m.Title + "</span></div>";
                    movieHtml += "</div>";
                    if (simaCounter == 2)
                    {
                        movieFullHtml += "<div class='page nimtaContainer' id='divSima' >" + headerHtml + movieHtml + footerHtml + "</div>";
                        // htmlNewsPaper = "";
                        movieHtml = "";
                        simaCounter = 0;
                    }

                }
                if (movieFullHtml == "")
                    movieFullHtml = "<div class='page nimtaContainer' id='divSima' >" + headerHtml + movieHtml + footerHtml + "</div>";
                return movieFullHtml;
            }
            catch (Exception ex)
            { return ""; }
        }
        private string CheckSiteLogo(string newspic)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newspic))
                {
                    newspic = @"C:\BultanForms\Logos\nologo.jpg";
                }
                return newspic;
            }
            catch
            {
                newspic = @"C:\BultanForms\Logos\nologo.jpg";
                return newspic;
            }

        }

        public class NewsType
        {
            public string SiteLogo { get; set; }
            public string GroupOrder { get; set; }
            public int NewsID { get; set; }
            public int SiteID { get; set; }
            public int KeywordID { get; set; }
            public int GroupId { get; set; }
            public string NewsTitle { get; set; }
            public string KeywordName { get; set; }
            public string NewsLead { get; set; }
            public string NewsBody { get; set; }
            public string NewsLink { get; set; }
            public string SiteTitle { get; set; }
            public string NewsPicture { get; set; }
            public string GroupName { get; set; }
            public int OrderItem { get; set; }

            public string NewsDate { get; set; }

            public DateTime CreateDate { get; set; }

            public int SiteType { get; set; }
            public int? NewsValue { get; set; }

            public string NewsTime { get; set; }
            public int? NewsGroupOrder { get; set; }

            //public List<int> NewsKeyTags { get; set; }
            //public List<int> NewsKeyGroups { get; set; }
            //public int NewsKeyGroupsOrder { get; set; }
            //public int NewsKeyTagsOrder { get; set; }

        }

        public static List<Tbl_News_Type> LoadTamarkozRasaneyi(List<Tbl_News_Type> NewsList)
        {
            DataSet ds = null;
            List<Tbl_News_Type> compiledList = new List<Tbl_News_Type>();
            foreach (var n in NewsList)
            {
                try
                {
                    ds = Class_News.GetTamarkozRasaneyiData(n.NewsID);
                    List<Tbl_News_Type> news = Tbl_News_Type.GetFromDataRows(ds.Tables[0].Select());
                    foreach (var nn in news)
                    {

                        nn.RelateListStrings = new List<string>();

                        List<int> newsRelatedIdList = new List<int>();
                        if (nn.RelatedString != null && nn.RelatedString != "")
                            if (nn.RelatedString.Contains(","))
                            {
                                foreach (var i in nn.RelatedString.Split(','))
                                {
                                    newsRelatedIdList.Add(Convert.ToInt32(i));
                                    string siteTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(i)).SiteTitle; //Class_News.GetNewsSiteTitle(Convert.ToInt32(i));
                                    string newsTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(i)).NewsTitle;//Class_News.GetNewsTitle(Convert.ToInt32(i));
                                    nn.RelateListStrings.Add(i + "$" + siteTitle + "$" + newsTitle);
                                }
                            }
                            else
                            {
                                newsRelatedIdList.Add(Convert.ToInt32(nn.RelatedString));
                                //string siteTitle = Class_News.GetNewsSiteTitle(Convert.ToInt32(nn.RelatedString));
                                //string newsTitle = Class_News.GetNewsTitle(Convert.ToInt32(nn.RelatedString));
                                string siteTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(nn.RelatedString)).SiteTitle;
                                string newsTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(nn.RelatedString)).NewsTitle;
                                nn.RelateListStrings.Add(nn.RelatedString + "$" + siteTitle + "$" + newsTitle);
                            }
                        nn.RelateListIds = newsRelatedIdList;
                        compiledList.Add(nn);

                    }
                }
                catch (Exception ex) { continue; }
            }
            return compiledList;
        }
        public static List<Tbl_News_Type> LoadRelated(List<Tbl_News_Type> NewsList)
        {
            DataSet ds = null;
            List<Tbl_News_Type> compiledList = new List<Tbl_News_Type>();

            try
            {
                foreach (var nn in NewsList)
                {

                    nn.RelateListStrings = new List<string>();

                    List<int> newsRelatedIdList = new List<int>();
                    if (nn.RelatedString != null && nn.RelatedString != "")
                        if (nn.RelatedString.Contains(","))
                        {
                            foreach (var i in nn.RelatedString.Split(','))
                            {
                                newsRelatedIdList.Add(Convert.ToInt32(i));
                                try
                                {
                                    string siteTitle = Class_News.GetNewsSiteTitle(Convert.ToInt32(i)); //NewsList.First(j => j.NewsID == Convert.ToInt32(i)).SiteTitle;
                                    string newsTitle = Class_News.GetNewsTitle(Convert.ToInt32(i));//NewsList.First(j => j.NewsID == Convert.ToInt32(i)).NewsTitle;;
                                    nn.RelateListStrings.Add(i + "$" + siteTitle + "$" + newsTitle);
                                }
                                catch { continue; }
                            }
                        }
                        else
                        {
                            newsRelatedIdList.Add(Convert.ToInt32(nn.RelatedString));
                            try
                            {
                                string siteTitle = Class_News.GetNewsSiteTitle(Convert.ToInt32(nn.RelatedString));
                                string newsTitle = Class_News.GetNewsTitle(Convert.ToInt32(nn.RelatedString));
                                //string siteTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(nn.RelatedString)).SiteTitle;
                                //string newsTitle = NewsList.First(j => j.NewsID == Convert.ToInt32(nn.RelatedString)).NewsTitle;
                                nn.RelateListStrings.Add(nn.RelatedString + "$" + siteTitle + "$" + newsTitle);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    nn.RelateListIds = newsRelatedIdList;
                    compiledList.Add(nn);

                }
            }
            catch (Exception ex) { }
            return compiledList;
        }
        public string SplitedText(string txt)
        {
            var maxLength = 2500;
            var str = "";
            var continueKeys = new string[] { ".", };
            foreach (var strings in (txt + "").Split('.'))
            {
                if (str.Length > maxLength) continue;

                if (!string.IsNullOrWhiteSpace(strings))
                {

                    if (continueKeys.Any(t => t == strings.Trim()))
                    {
                        str += continueKeys;
                    }
                    else
                    {
                        if (strings.Length < 3)
                        {
                            str += strings;

                        }
                        else
                        {
                            str += strings + " . ";
                        }

                    }
                }
            }

            return str;
        }

    }
}