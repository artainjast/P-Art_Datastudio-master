using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PArt.Pages.P_Art.Repository;
using FarsiLibrary.Utils;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Data.OleDb;
using P_Art.Pages.P_Art.ModelNews;
using System.Globalization;
using System.Data.SqlClient;
using PArtCore.Class;
using System.Configuration;
using System.Web.Services;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Drawing;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class ExportReports : System.Web.UI.Page
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private static DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
        List<Tbl_ExportExcelKeywords> ExportExcelKeywords = new List<Tbl_ExportExcelKeywords>();
        List<Tbl_RssKeywords> RssKeyWords = new List<Tbl_RssKeywords>();



        List<int?> UserPanelList = new List<int?>();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        Class_Zaman _clsZm = new Class_Zaman();
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            UserPanelList = Class_Layer.UserPanels();
            var parmin = UserPanelList[0].Value + "";

            string UserPanelString = string.Empty;

            if (txt_fromDate.Text == "")
                txt_fromDate.Text = _clsZm.Today();
            if (txt_toDate.Text == "")
                txt_toDate.Text = _clsZm.Today();

            prepareKeywordsList();
        }



        private void prepareKeywordsList()
        {
            int parmin = UserPanelList[0].Value;
            var keywordsList = (from Key in _db.Tbl_ExportExcelKeywords
                                where Key.PanelId == parmin && Key.Type == 1 && Key.Active == true
                                orderby Key.KeyPriority
                                select Key).ToList();

            rptKeywordItem.DataSource = keywordsList;
            rptKeywordItem.DataBind();


        }


        private static DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }



        [WebMethod]
        public static Tbl_ExportExcelKeywords GetExportSerachKeywordWithId(string KeyID)
        {
            int keyId = int.Parse(KeyID);
            var keyWord = _dbStatic.Tbl_ExportExcelKeywords.AsNoTracking().Where(key => key.Id == keyId).FirstOrDefault();
            return keyWord;
        }



        protected void saveKeyword_Click(object sender, EventArgs e)
        {
            try
            {
                int keyId = 0;
                int parmin = int.Parse(UserPanelList[0].Value + "");
                if (!string.IsNullOrEmpty(SelectedKeywordIdHiddenField.Value) || !string.IsNullOrWhiteSpace(SelectedKeywordIdHiddenField.Value))
                    keyId = int.Parse(SelectedKeywordIdHiddenField.Value);
                var keyword = _db.Tbl_ExportExcelKeywords.Where(k => k.Id == keyId).FirstOrDefault();
                if (keyword != null)
                {
                    if (!string.IsNullOrWhiteSpace(txtKeywordTitle.Text))
                        keyword.Title = txtKeywordTitle.Text;

                    if (!string.IsNullOrWhiteSpace(txtKeyOrder.Text))
                        keyword.KeyPriority = int.Parse(txtKeyOrder.Text);
                    if (!string.IsNullOrWhiteSpace(NoWordOfTextbox.Text))
                        keyword.NoWordOf = NoWordOfTextbox.Text;

                    keyword.Type = 1; // نوع این قسمت ۱ می باشد
                    keyword.EditDateTime = DateTime.Now;
                    _db.SaveChanges();
                   
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtKeywordTitle.Text))
                    {
                        _db.Tbl_ExportExcelKeywords.Add(new Tbl_ExportExcelKeywords
                        {
                            Title = txtKeywordTitle.Text,
                            NoWordOf = NoWordOfTextbox.Text,
                            Active = true,
                            Type = 1,
                            CreateDateTime = DateTime.Now,
                            EditDateTime = DateTime.Now,
                            PanelId = parmin,
                            KeyPriority = string.IsNullOrEmpty(txtKeyOrder.Text) ? 0 : int.Parse(txtKeyOrder.Text)
                        });
                        _db.SaveChanges();
                    
                    }

                }
                prepareKeywordsList();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch
            {

            }
        }



        protected void deleteKeyword_Click(object sender, EventArgs e)
        {
            try
            {
                int keyId = int.Parse(SelectedKeywordIdHiddenField.Value);
                var keyword = _db.Tbl_ExportExcelKeywords.Where(k => k.Id == keyId).FirstOrDefault();
                keyword.Active = false;
                keyword.EditDateTime = DateTime.Now;
                _db.SaveChanges();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            catch
            {
            }
        }


        //public void UpdateListSelectedNewsKeyIds(List<ExcelReport_Type> List)
        //{
        //    List<int> ListKeyIds = new List<int>();

        //    foreach (var item in List)
        //    {
        //        foreach (var keyId in item.NewsKeywordsTitle.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            try
        //            {
        //                ListKeyIds.Add(int.Parse(keyId));
        //            }
        //            catch
        //            {

        //                continue;
        //            }

        //        }
        //    }
        //}

        public void GenerateExcelReport(List<ExcelReport_Type> List)
        {
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet wsheet = package.Workbook.Worksheets.Add("Report");

            wsheet.View.RightToLeft = true;

            wsheet.Cells["A1"].Value = "ردیف";
            wsheet.Cells["B1"].Value = "نوع رسانه";
            wsheet.Cells["C1"].Value = "نام رسانه";
            wsheet.Cells["D1"].Value = "کلمه جستجو";
            wsheet.Cells["E1"].Value = "عنوان خبر";
            wsheet.Cells["F1"].Value = "سوگیری خبر";
            wsheet.Cells["G1"].Value = "تاریخ";
            wsheet.Cells["H1"].Value = "کلمات کلیدی";
            wsheet.Cells["I1"].Value = "لینک";

            wsheet.Row(1).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            wsheet.Row(1).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#004d99"));
            wsheet.Row(1).Style.Font.Color.SetColor(ColorTranslator.FromHtml("#ffffff"));
            wsheet.Row(1).Style.Font.SetFromFont(new Font("B Mitra", 12));
            wsheet.Row(1).Style.Font.Bold = true;

            int rowStart = 2;
            foreach (var item in List)
            {
                wsheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                wsheet.Row(rowStart).Style.Font.SetFromFont(new Font("B Mitra", 12));

                if (rowStart % 2 == 0)
                {
                    wsheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#f2f2f2"));
                }
                else
                {
                    wsheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#cce6ff"));
                }


                wsheet.Cells[string.Format("A{0}", rowStart)].Value = rowStart - 1;
                wsheet.Cells[string.Format("B{0}", rowStart)].Value = item.MediaTypeTitle;
                wsheet.Cells[string.Format("C{0}", rowStart)].Value = item.MediaName;
                wsheet.Cells[string.Format("D{0}", rowStart)].Value = item.SearchKeyTitle;
                wsheet.Cells[string.Format("E{0}", rowStart)].Value = item.NewsTitle;
                wsheet.Cells[string.Format("F{0}", rowStart)].Value = item.SugiriTitle;
                wsheet.Cells[string.Format("G{0}", rowStart)].Value = item.Date;
                wsheet.Cells[string.Format("H{0}", rowStart)].Value = item.NewsKeywordsTitle;
                wsheet.Cells[string.Format("I{0}", rowStart)].Value = item.Url;
                rowStart++;
            }
            wsheet.Cells["A:AZ"].AutoFitColumns(10, 50);
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", string.Format("attachment;  filename={0}", "ExcellData.xlsx"));
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();

        }

        public void GenerateExcelReportWithoutSearchKey(List<ExcelReport_Type> List)
        {
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet wsheet = package.Workbook.Worksheets.Add("Report");

            wsheet.View.RightToLeft = true;

            wsheet.Cells["A1"].Value = "ردیف";
            wsheet.Cells["B1"].Value = "نوع رسانه";
            wsheet.Cells["C1"].Value = "نام رسانه";
            wsheet.Cells["D1"].Value = "عنوان خبر";
            wsheet.Cells["E1"].Value = "سوگیری خبر";
            wsheet.Cells["F1"].Value = "تاریخ";
            wsheet.Cells["G1"].Value = "کلمات کلیدی";
            wsheet.Cells["H1"].Value = "لینک";


            wsheet.Row(1).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            wsheet.Row(1).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#004d99"));
            wsheet.Row(1).Style.Font.Color.SetColor(ColorTranslator.FromHtml("#ffffff"));
            wsheet.Row(1).Style.Font.SetFromFont(new Font("B Mitra", 12));
            wsheet.Row(1).Style.Font.Bold = true;

            int rowStart = 2;
            foreach (var item in List)
            {
                wsheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                wsheet.Row(rowStart).Style.Font.SetFromFont(new Font("B Mitra", 12));

                if (rowStart % 2 == 0)
                {
                    wsheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#f2f2f2"));
                }
                else
                {
                    wsheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#cce6ff"));
                }


                wsheet.Cells[string.Format("A{0}", rowStart)].Value = rowStart - 1;
                wsheet.Cells[string.Format("B{0}", rowStart)].Value = item.MediaTypeTitle;
                wsheet.Cells[string.Format("C{0}", rowStart)].Value = item.MediaName;
                wsheet.Cells[string.Format("D{0}", rowStart)].Value = item.NewsTitle;
                wsheet.Cells[string.Format("E{0}", rowStart)].Value = item.SugiriTitle;
                wsheet.Cells[string.Format("F{0}", rowStart)].Value = item.Date;
                wsheet.Cells[string.Format("G{0}", rowStart)].Value = item.NewsKeywordsTitle;
                wsheet.Cells[string.Format("H{0}", rowStart)].Value = item.Url;

                rowStart++;
            }
            wsheet.Cells["A:AZ"].AutoFitColumns(10, 50);
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", string.Format("attachment;  filename={0}", "ExcellData.xlsx"));
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();

        }


        public string GetKeywordTitles(string value)
        {
            string result = "";
            foreach (var key in value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    result += RssKeyWords.Find(k => k.KeyId == int.Parse(key)).KeywordName + " ,";
                }
                catch
                {
                    continue;
                }

            }

            return result;
        }

        public string GetMediaTypeTitle(int? value)
        {
            switch (value)
            {
                case 1:
                    return "خبرگزاری";
                case 2:
                    return "روزنامه";
                case 4:
                    return "خبرگزاری های خارجی";
                default:
                    return "سایر";
            }
        }


        public string GetMediaSugiriTitle(int? value)
        {
            switch (value)
            {
                case 0:
                    return "خنثی";
                case 2:
                    return "منفی";
                case 1:
                    return "مثبت";
                case 3:
                    return "خبر کم ارتباط";
                case 4:
                    return "خبر بی ربط";

                default:
                    return "خنثی";
            }
        }
        protected void generateExcelReport_Click(object sender, EventArgs e)
        {
            long? fromDateTime = 0;
            long? toDateTime = 0;


            if (!string.IsNullOrWhiteSpace(txt_fromDate.Text.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_fromHour.Text.Trim()))
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Text.Trim().Replace("/", "") + "0000");
                }
                else
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Text.Trim().Replace("/", "") + txt_fromHour.Text.Trim().Replace(":", ""));
                }

            }

            if (!string.IsNullOrWhiteSpace(txt_toDate.Text.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_toHour.Text.Trim()))
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Text.Trim().Replace("/", "") + "2400");
                }
                else
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Text.Trim().Replace("/", "") + txt_toHour.Text.Trim().Replace(":", ""));
                }

            }


            int parmin = int.Parse(UserPanelList[0].Value + "");
            List<ExcelReport_Type> List = new List<ExcelReport_Type>();
            var keys = _db.Tbl_ExportExcelKeywords.Where(k => k.PanelId == parmin && k.Type == 1 && k.Active == true).ToList();

            foreach (var key in keys)
            {
                key.Title = key.Title.Replace("ی", "ي").Replace("ک", "ك");
                key.NoWordOf = key.NoWordOf.Replace("ی", "ي").Replace("ک", "ك");
            }

            foreach (var key in keys)
            {
                #region NoWordOf is empty
                if (string.IsNullOrEmpty(key.NoWordOf))
                {
                    if (key.Title.Contains("+"))
                    {
                        string str1 = "";
                        string str2 = "";
                        string str3 = "";

                        var SearchParameterList = key.Title.Split('+');


                        if (SearchParameterList.Count() == 2)
                        {
                            str1 = SearchParameterList[0];
                            str2 = SearchParameterList[1];

                            List.AddRange((from news in _db.Tbl_News
                                           join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                           where
                                           news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                           news.ParminId == key.PanelId &&

                                           (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                           (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2))

                                           select new ExcelReport_Type
                                           {
                                               Date = news.NewsDate,
                                               MediaName = site.SiteTitle,
                                               MediaTypeTitle = "",
                                               MediaTypeCode = site.SiteType,
                                               NewsKeywordsTitle = news.KeyIds,
                                               NewsTitle = news.NewsTitle,
                                               SearchKeyTitle = key.Title,
                                               Url = news.NewsLink,
                                               SugiriTitle = "",
                                               SugiriCode = news.NewsValue

                                           }).ToList()
                                        );

                        }
                        else if (SearchParameterList.Count() == 3)
                        {

                            str1 = SearchParameterList[0];
                            str2 = SearchParameterList[1];
                            str3 = SearchParameterList[2];

                            List.AddRange((from news in _db.Tbl_News
                                           join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                           where
                                           news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                           news.ParminId == key.PanelId &&

                                           (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                           (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2)) &&
                                           (news.NewsTitle.Contains(str3) || news.NewsLead.Contains(str3) || news.NewsBody.Contains(str3))

                                           select new ExcelReport_Type
                                           {
                                               Date = news.NewsDate,
                                               MediaName = site.SiteTitle,
                                               MediaTypeTitle = "",
                                               MediaTypeCode = site.SiteType,
                                               NewsKeywordsTitle = news.KeyIds,
                                               NewsTitle = news.NewsTitle,
                                               SearchKeyTitle = key.Title,
                                               Url = news.NewsLink,
                                               SugiriTitle = "",
                                               SugiriCode = news.NewsValue

                                           }).ToList()
                                        );

                        }


                    }
                    else
                    {


                        List.AddRange((from news in _db.Tbl_News
                                       join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                       where
                                       news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                       news.ParminId == key.PanelId &&

                                       (news.NewsTitle.Contains(key.Title) || news.NewsLead.Contains(key.Title) || news.NewsBody.Contains(key.Title))

                                       select new ExcelReport_Type
                                       {
                                           Date = news.NewsDate,
                                           MediaName = site.SiteTitle,
                                           MediaTypeTitle = "",
                                           MediaTypeCode = site.SiteType,
                                           NewsKeywordsTitle = news.KeyIds,
                                           NewsTitle = news.NewsTitle,
                                           SearchKeyTitle = key.Title,
                                           Url = news.NewsLink,
                                           SugiriTitle = "",
                                           SugiriCode = news.NewsValue

                                       }).ToList()

                                    );
                    }

                }
                #endregion

                #region NoWordOf is Exist
                else
                {

                    if (key.NoWordOf.Contains("+"))
                    {
                        #region some NowordOf is exist and some Title is Exist
                        if (key.Title.Contains("+"))
                        {
                            string NoStr1 = "";
                            string NoStr2 = "";
                            string NoStr3 = "";

                            string str1 = "";
                            string str2 = "";
                            string str3 = "";


                            var NoSearchParameterList = key.NoWordOf.Split('+');
                            var SearchParameterList = key.Title.Split('+');

                            #region title 2 and noWord 2
                            if (NoSearchParameterList.Count() == 2 && SearchParameterList.Count() == 2)
                            {
                                str1 = SearchParameterList[0];
                                str2 = SearchParameterList[1];

                                NoStr1 = NoSearchParameterList[0];
                                NoStr2 = NoSearchParameterList[1];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&


                                               !news.NewsTitle.Contains(NoStr1) &&
                                               !news.NewsLead.Contains(NoStr1) &&
                                               !news.NewsBody.Contains(NoStr1) &&

                                               !news.NewsTitle.Contains(NoStr2) &&
                                               !news.NewsLead.Contains(NoStr2) &&
                                               !news.NewsBody.Contains(NoStr2) &&

                                               (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                               (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2))


                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }
                            #endregion

                            #region title 3 and noWord 2
                            if (NoSearchParameterList.Count() == 3 && SearchParameterList.Count() == 2)
                            {
                                str1 = SearchParameterList[0];
                                str2 = SearchParameterList[1];

                                NoStr1 = NoSearchParameterList[0];
                                NoStr2 = NoSearchParameterList[1];
                                NoStr3 = NoSearchParameterList[2];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&


                                               !news.NewsTitle.Contains(NoStr1) &&
                                               !news.NewsLead.Contains(NoStr1) &&
                                               !news.NewsBody.Contains(NoStr1) &&

                                               !news.NewsTitle.Contains(NoStr2) &&
                                               !news.NewsLead.Contains(NoStr2) &&
                                               !news.NewsBody.Contains(NoStr2) &&

                                               !news.NewsTitle.Contains(NoStr3) &&
                                               !news.NewsLead.Contains(NoStr3) &&
                                               !news.NewsBody.Contains(NoStr3) &&

                                               (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                               (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2))


                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }
                            #endregion

                            #region title 2 and noWord 3
                            if (NoSearchParameterList.Count() == 2 && SearchParameterList.Count() == 3)
                            {
                                str1 = SearchParameterList[0];
                                str2 = SearchParameterList[1];
                                str3 = SearchParameterList[2];

                                NoStr1 = NoSearchParameterList[0];
                                NoStr2 = NoSearchParameterList[1];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&


                                               !news.NewsTitle.Contains(NoStr1) &&
                                               !news.NewsLead.Contains(NoStr1) &&
                                               !news.NewsBody.Contains(NoStr1) &&

                                               !news.NewsTitle.Contains(NoStr2) &&
                                               !news.NewsLead.Contains(NoStr2) &&
                                               !news.NewsBody.Contains(NoStr2) &&

                                               (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                               (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2)) &&
                                               (news.NewsTitle.Contains(str3) || news.NewsLead.Contains(str3) || news.NewsBody.Contains(str3))

                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }
                            #endregion

                            #region title 3 and noWord 3
                            if (NoSearchParameterList.Count() == 3 && SearchParameterList.Count() == 3)
                            {
                                str1 = SearchParameterList[0];
                                str2 = SearchParameterList[1];
                                str3 = SearchParameterList[2];

                                NoStr1 = NoSearchParameterList[0];
                                NoStr2 = NoSearchParameterList[1];
                                NoStr3 = NoSearchParameterList[3];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&


                                               !news.NewsTitle.Contains(NoStr1) &&
                                               !news.NewsLead.Contains(NoStr1) &&
                                               !news.NewsBody.Contains(NoStr1) &&

                                               !news.NewsTitle.Contains(NoStr2) &&
                                               !news.NewsLead.Contains(NoStr2) &&
                                               !news.NewsBody.Contains(NoStr2) &&

                                                !news.NewsTitle.Contains(NoStr3) &&
                                               !news.NewsLead.Contains(NoStr3) &&
                                               !news.NewsBody.Contains(NoStr3) &&

                                               (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                               (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2)) &&
                                               (news.NewsTitle.Contains(str3) || news.NewsLead.Contains(str3) || news.NewsBody.Contains(str3))

                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }
                            #endregion


                        }
                        #endregion

                        #region some NowordOf is exist and one Title is Exist

                        else
                        {
                            string NoStr1 = "";
                            string NoStr2 = "";
                            string NoStr3 = "";

                            var NoSearchParameterList = key.NoWordOf.Split('+');


                            if (NoSearchParameterList.Count() == 2)
                            {
                                NoStr1 = NoSearchParameterList[0];
                                NoStr2 = NoSearchParameterList[1];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&


                                               !news.NewsTitle.Contains(NoStr1) &&
                                               !news.NewsLead.Contains(NoStr1) &&
                                               !news.NewsBody.Contains(NoStr1) &&

                                               !news.NewsTitle.Contains(NoStr2) &&
                                               !news.NewsLead.Contains(NoStr2) &&
                                               !news.NewsBody.Contains(NoStr2) &&

                                               (news.NewsTitle.Contains(key.Title) || news.NewsLead.Contains(key.Title) || news.NewsBody.Contains(key.Title))


                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }
                            else if (NoSearchParameterList.Count() == 3)
                            {

                                NoStr1 = NoSearchParameterList[0];
                                NoStr2 = NoSearchParameterList[1];
                                NoStr3 = NoSearchParameterList[2];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&



                                               !news.NewsTitle.Contains(NoStr1) &&
                                               !news.NewsLead.Contains(NoStr1) &&
                                               !news.NewsBody.Contains(NoStr1) &&

                                               !news.NewsTitle.Contains(NoStr2) &&
                                               !news.NewsLead.Contains(NoStr2) &&
                                               !news.NewsBody.Contains(NoStr2) &&

                                               !news.NewsTitle.Contains(NoStr3) &&
                                               !news.NewsLead.Contains(NoStr3) &&
                                               !news.NewsBody.Contains(NoStr3) &&


                                               (news.NewsTitle.Contains(key.Title) || news.NewsLead.Contains(key.Title) || news.NewsBody.Contains(key.Title))

                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }


                        }


                        #endregion


                    }
                    else
                    {
                        #region one NoWordOf is Exist and some Title is exist

                        if (key.Title.Contains("+"))
                        {
                            string str1 = "";
                            string str2 = "";
                            string str3 = "";

                            var SearchParameterList = key.Title.Split('+');


                            if (SearchParameterList.Count() == 2)
                            {
                                str1 = SearchParameterList[0];
                                str2 = SearchParameterList[1];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&


                                               !news.NewsTitle.Contains(key.NoWordOf.Trim()) &&
                                               !news.NewsLead.Contains(key.NoWordOf.Trim()) &&
                                               !news.NewsBody.Contains(key.NoWordOf.Trim()) &&

                                               (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                               (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2))

                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }
                            else if (SearchParameterList.Count() == 3)
                            {

                                str1 = SearchParameterList[0];
                                str2 = SearchParameterList[1];
                                str3 = SearchParameterList[2];

                                List.AddRange((from news in _db.Tbl_News
                                               join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                               where
                                               news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                               news.ParminId == key.PanelId &&


                                               !news.NewsTitle.Contains(key.NoWordOf.Trim()) &&
                                               !news.NewsLead.Contains(key.NoWordOf.Trim()) &&
                                               !news.NewsBody.Contains(key.NoWordOf.Trim()) &&

                                               (news.NewsTitle.Contains(str1) || news.NewsLead.Contains(str1) || news.NewsBody.Contains(str1)) &&
                                               (news.NewsTitle.Contains(str2) || news.NewsLead.Contains(str2) || news.NewsBody.Contains(str2)) &&
                                               (news.NewsTitle.Contains(str3) || news.NewsLead.Contains(str3) || news.NewsBody.Contains(str3))

                                               select new ExcelReport_Type
                                               {
                                                   Date = news.NewsDate,
                                                   MediaName = site.SiteTitle,
                                                   MediaTypeTitle = "",
                                                   MediaTypeCode = site.SiteType,
                                                   NewsKeywordsTitle = news.KeyIds,
                                                   NewsTitle = news.NewsTitle,
                                                   SearchKeyTitle = key.Title,
                                                   Url = news.NewsLink,
                                                   SugiriTitle = "",
                                                   SugiriCode = news.NewsValue

                                               }).ToList()
                                            );

                            }


                        }
                        #endregion
                        #region one NoWordOf is Exist and one Title is exist
                        else
                        {


                            List.AddRange((from news in _db.Tbl_News
                                           join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                                           where
                                           news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                                           news.ParminId == key.PanelId &&


                                           !news.NewsTitle.Contains(key.NoWordOf.Trim()) &&
                                           !news.NewsLead.Contains(key.NoWordOf.Trim()) &&
                                           !news.NewsBody.Contains(key.NoWordOf.Trim()) &&


                                           (news.NewsTitle.Contains(key.Title) || news.NewsLead.Contains(key.Title) || news.NewsBody.Contains(key.Title))

                                           select new ExcelReport_Type
                                           {
                                               Date = news.NewsDate,
                                               MediaName = site.SiteTitle,
                                               MediaTypeTitle = "",
                                               MediaTypeCode = site.SiteType,
                                               NewsKeywordsTitle = news.KeyIds,
                                               NewsTitle = news.NewsTitle,
                                               SearchKeyTitle = key.Title,
                                               Url = news.NewsLink,
                                               SugiriTitle = "",
                                               SugiriCode = news.NewsValue

                                           }).ToList()

                                        );
                        }
                        #endregion
                    }
                }
                #endregion


            }

            List<Tbl_Sites> SitesList = _db.Tbl_Sites.ToList();

            RssKeyWords.AddRange(_db.Tbl_RssKeywords.ToList());


            foreach (var item in List)
            {
                item.NewsKeywordsTitle = GetKeywordTitles(item.NewsKeywordsTitle);
                item.MediaTypeTitle = GetMediaTypeTitle(item.MediaTypeCode);
                item.SugiriTitle = GetMediaSugiriTitle(item.SugiriCode);
            }

            GenerateExcelReport(List);
        }

        protected void generateExcelReportWithoutKeySearch_Click(object sender, EventArgs e)
        {
            long? fromDateTime = 0;
            long? toDateTime = 0;


            if (!string.IsNullOrWhiteSpace(txt_fromDate.Text.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_fromHour.Text.Trim()))
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Text.Trim().Replace("/", "") + "0000");
                }
                else
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Text.Trim().Replace("/", "") + txt_fromHour.Text.Trim().Replace(":", ""));
                }

            }

            if (!string.IsNullOrWhiteSpace(txt_toDate.Text.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_toHour.Text.Trim()))
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Text.Trim().Replace("/", "") + "2400");
                }
                else
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Text.Trim().Replace("/", "") + txt_toHour.Text.Trim().Replace(":", ""));
                }

            }


            int parmin = int.Parse(UserPanelList[0].Value + "");
            List<ExcelReport_Type> List = new List<ExcelReport_Type>();


            List.AddRange((from news in _db.Tbl_News
                           join site in _db.Tbl_Sites on news.SiteID equals site.SiteID
                           where
                           news.NewsDateTimeIndex >= fromDateTime && news.NewsDateTimeIndex <= toDateTime &&
                           news.ParminId == parmin


                           select new ExcelReport_Type
                           {
                               Date = news.NewsDate,
                               MediaName = site.SiteTitle,
                               MediaTypeTitle = "",
                               MediaTypeCode = site.SiteType,
                               NewsKeywordsTitle = news.KeyIds,
                               NewsTitle = news.NewsTitle,
                               SearchKeyTitle = "",
                               Url = news.NewsLink,
                               SugiriTitle = "",
                               SugiriCode = news.NewsValue

                           }).ToList()

                   );



            List<Tbl_Sites> SitesList = _db.Tbl_Sites.ToList();

            RssKeyWords.AddRange(_db.Tbl_RssKeywords.ToList());


            foreach (var item in List)
            {
                item.NewsKeywordsTitle = GetKeywordTitles(item.NewsKeywordsTitle);
                item.MediaTypeTitle = GetMediaTypeTitle(item.MediaTypeCode);
                item.SugiriTitle = GetMediaSugiriTitle(item.SugiriCode);
            }

            GenerateExcelReportWithoutSearchKey(List);
        }
    }


}