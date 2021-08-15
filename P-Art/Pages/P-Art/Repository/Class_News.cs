using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using System.Data;
using System.Data.SqlClient;
using PArt.Core;
using System.Text;

namespace PArt.Pages.P_Art.Repository
{

    public class Class_News
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        Class_Sites _site = new Class_Sites();
        Class_Panels cls_panel = new Class_Panels();
        Class_Ado _clsAdo = new Class_Ado();
        Class_Zaman _clsZm = new Class_Zaman();

        public List<Tbl_News_Type> SelectAll(string parminIds, string siteIDs, string filterNewsIds, bool? HasImage, int? newsType, string search, int? PageNumber, int? PageCount, int? SkipCount, string DateFrom, string DateTo, long lastNewsID, string newsIds)
        {
            var item = new List<Tbl_News_Type>();
            var lstParam = new List<ColumnData_Type>();
            //lstParam.Add(new ColumnData_Type { ColumnName = "ID", ColumnType = SqlDbType.NVarChar, ColumnValue = IndicatorCode, ParamName = "@p1" });
            //lstParam.Add(new ColumnData_Type { ColumnName = "SiteID_FK", ColumnType = SqlDbType.Int, ColumnValue = siteId, ParamName = "@p2" });

            var strFiltered = "";
            if (!string.IsNullOrWhiteSpace(parminIds))
            {
                strFiltered = @"(SELECT top " + (PageNumber * PageCount) + @" NewsID FROM Tbl_Relation_NewsParminPanel WHERE
					   ParminPanelId in (" + parminIds + ")  ORDER BY  RelationId DESC )";
            }
            else
            {
                strFiltered = "(" + newsIds + ")";
            }
            //   Tbl_News.SiteID,   Tbl_News.NewsTime,Tbl_News.NewsDate,, Tbl_News.NewsPicture,
            //   Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink,Tbl_News.NewsDateIndex, 
            // Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_News.KeywordId,Tbl_News.NewsTitleCRC,Tbl_News.NewsLinkCRC,
            //    Tbl_Sites.SiteType
            var query = @"select * from (SELECT     ROW_NUMBER() OVER(ORDER BY Tbl_News.NewsId desc) AS RowNum,COUNT(*) OVER() AS TotalRows,Tbl_News.NewsID,Tbl_News.NewsDateIndex,
                       Tbl_News.NewsTitle, Tbl_News.NewsLead,Tbl_News.NewsBody
                      FROM         Tbl_News LEFT OUTER JOIN
                      Tbl_Sites ON Tbl_News.SiteID = Tbl_Sites.SiteID where  NewsID IN " + strFiltered + "";

            var searchQ = "";
            if (!string.IsNullOrWhiteSpace(siteIDs))
            {
                if (string.IsNullOrWhiteSpace(searchQ))
                {
                    searchQ = " SiteId in (" + siteIDs + ") ";
                }
                else
                {
                    searchQ = " AND SiteId in (" + siteIDs + ") ";

                }
            }
            if (!string.IsNullOrWhiteSpace(searchQ))
            {
                searchQ = "  where " + searchQ;
            }

            query += searchQ;
            if (search != "")
            {
                search = search.Replace('ی', 'ي');
                var strCon = search;
                strCon = strCon.Replace('ي', 'ی');

                query += " and (Tbl_News.NewsTitle Like '%@PSearch1%' or Tbl_News.NewsLead Like '%@PSearch1%' or Tbl_News.NewsBody Like '%@PSearch1%'" + " or Tbl_News.NewsTitle Like '%@PSearch2%' or Tbl_News.NewsLead Like '%@PSearch2%' or Tbl_News.NewsBody Like '%@PSearch2%')";


                lstParam.Add(new ColumnData_Type { ColumnName = "PSearch1", ColumnType = SqlDbType.VarChar, ColumnValue = search, ParamName = "@PSearch1" });
                lstParam.Add(new ColumnData_Type { ColumnName = "PSearch2", ColumnType = SqlDbType.VarChar, ColumnValue = strCon, ParamName = "@PSearch2" });

            }

            if (DateFrom != "" && DateTo != "")
            {
                int From = int.Parse(DateFrom.Replace("/", ""));
                int To = int.Parse(DateTo.Replace("/", ""));


                query += " and Tbl_News.NewsDateIndex between " + From + " and " + To;

            }

            if (HasImage != null)
            {
                if (HasImage == true)
                {
                    query += " and not Tbl_News.NewsPicture is null and Tbl_News.NewsPicture  <> ''";
                }
                else
                {
                    query += " and Tbl_News.NewsPicture is null or Tbl_News.NewsPicture  =''";
                }
            }

            if (newsType != null && newsType != 0)
            {


                query += " and Tbl_Sites.SiteType =" + newsType;




            }
            query += " AND Tbl_News.Active=1  ";

            if (filterNewsIds != "")
            {
                if (query.IndexOf("where") == -1)
                {
                    query += " where ";
                    query += "  not Tbl_News.NewsId In (" + filterNewsIds + ")";
                }
                else
                {
                    query += "  AND not Tbl_News.NewsId In (" + filterNewsIds + ")";

                }
            }
            query += " AND Tbl_News.NewsID > " + lastNewsID;


            query += ") as tbl";

            if (PageNumber != -1 && PageCount != -1)
            {

                if (SkipCount != null)
                {
                    query += " where rownum between " + (Convert.ToInt32(Convert.ToInt32(PageNumber * PageCount) - PageCount) + 1) + SkipCount + " and " + (PageCount * PageNumber);
                }
                else
                {
                    query += " where rownum between " + (((PageNumber * PageCount) - PageCount) + 1) + " and " + (PageCount * PageNumber);
                }

            }




            query += " order by NewsDateIndex,NewsId  desc";




            var res = _clsAdo.FillDatabaseParametric("", query, lstParam);
            if (res != null)
            {
                item = Class_Static.ConvertDataTableToClass<Tbl_News_Type>(res);

            }
            return item;
        }
        //public DataTable GetAllNewsDataTable(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead, bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search, int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable)
        //{
        //    var panels = "";
        //    foreach (var str in PanelIds)
        //    {
        //        panels += str + ",";
        //    }

        //    panels = panels.Substring(0, panels.Length - 1);



        //    string SearchQuery = string.Empty;
        //    if (Search != "")
        //    {
        //        var strSearch = Search.Split('-');
        //        var strSearchOr = Search.Split('|');
        //        if (strSearchOr.Count() > 1)
        //        {
        //            SearchQuery += " AND (";
        //            foreach (string param in strSearchOr)
        //            {
        //                if (!SearchQuery.EndsWith("AND ("))
        //                {
        //                    SearchQuery += " OR (";
        //                }
        //                var strCon = Class_Static.PersianAlpha(param);
        //                var strCon2 = Class_Static.ArabicAlpha(param);
        //                SearchQuery += " n.NewsTitle LIKE N'%" + strCon + "%' OR  n.NewsTitle LIKE N'%" +
        //                    strCon2 + "%' OR n.NewsLead LIKE N'%" + strCon + "%' OR  n.NewsLead LIKE N'%" +
        //                    strCon2 + "%'  OR n.NewsBody LIKE N'%" + strCon + "%' OR  n.NewsBody LIKE N'%" +
        //                    strCon2 + "%' OR n.NewsBody LIKE '%" + strCon + "%' OR  n.NewsBody LIKE '%" + strCon2 + "%' OR ";

        //                SearchQuery = SearchQuery.Substring(0, SearchQuery.Length - 4);
        //                SearchQuery += ")";
        //            }
        //        }
        //        else
        //        {
        //            SearchQuery += " AND (";
        //            foreach (string param in strSearch)
        //            {
        //                if (!SearchQuery.EndsWith("AND ("))
        //                {
        //                    SearchQuery += " AND (";
        //                }
        //                var strCon = Class_Static.PersianAlpha(param);
        //                //  NewsTitle-NewsLead-NewsBody
        //                var strCon2 = Class_Static.ArabicAlpha(param);
        //                SearchQuery += " n.NewsTitle LIKE N'%" + strCon + "%' OR  n.NewsTitle LIKE N'%" + strCon2 +
        //                    "%' OR n.NewsLead LIKE N'%" + strCon + "%' OR  n.NewsLead LIKE N'%" + strCon2 +
        //                    "%'  OR n.NewsBody LIKE N'%" + strCon + "%' OR  n.NewsBody LIKE N'%" + strCon2 +
        //                    "%' OR n.NewsBody LIKE '%" + strCon + "%' OR  n.NewsBody LIKE '%" + strCon2 + "%' OR ";

        //                SearchQuery = SearchQuery.Substring(0, SearchQuery.Length - 4);
        //                SearchQuery += ")";
        //            }

        //        }
        //    }

        //    var queryRssKeywords = "";
        //    if (!string.IsNullOrWhiteSpace(keysIds))
        //    {
        //        if (keysIds.EndsWith(","))
        //        {
        //            keysIds = keysIds.Substring(0, keysIds.Length - 1);

        //        }
        //    }

        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@" + "PageCount",PageCount),
        //        new SqlParameter("@" + "PageIndex",PageIndex),
        //        new SqlParameter("@" + "PanelIds",panels),
        //        new SqlParameter("@" + "IsRead",isRead),
        //        new SqlParameter("@" + "FromDate",fromDate),
        //        new SqlParameter("@" + "ToDate",toDate),
        //        new SqlParameter("@" + "Search",SearchQuery),
        //        new SqlParameter("@" + "AllowTv",AllowTv),
        //         new SqlParameter("@" + "IsFromTvTable",isFromTvTable),
        //        new SqlParameter("@" + "KeysIds",keysIds),
        //        new SqlParameter("@" + "NewsIds",newsIds),
        //};

        //    DataSet ds = Class_Ado.ExecuteDataset("", "p_News_GetAlldata", CommandType.StoredProcedure, sqlParams);

        //    return ds.Tables[0];



        //    //////////////if (isRead != null)
        //    //////////////{
        //    //////////////    if (isRead == false)
        //    //////////////    {
        //    //////////////        query += " and Tbl_News.isRead = 0";

        //    //////////////    }
        //    //////////////    else if (isRead == true)
        //    //////////////    {
        //    //////////////        query += " and Tbl_News.isRead = 1";
        //    //////////////    }
        //    //////////////}



        //    ////////////////if (siteType != null)
        //    ////////////////{
        //    ////////////////    if (siteType == -1)
        //    ////////////////    {

        //    ////////////////        //query = query.Where(p => p.Tbl_Sites.SiteType == 2);
        //    ////////////////        query += " and Tbl_Sites.SiteType =1";

        //    ////////////////    }
        //    ////////////////    else if (siteType == -2)
        //    ////////////////    {
        //    ////////////////        //query = query.Where(p => p.Tbl_Sites.SiteType == 1);
        //    ////////////////        query += " and Tbl_Sites.SiteType =2";
        //    ////////////////    }
        //    ////////////////    else if (siteType != 0)
        //    ////////////////    {
        //    ////////////////        //query = query.Where(p => p.Tbl_Sites.SiteID == siteType);
        //    ////////////////        query += " and Tbl_Sites.SiteId =" + siteType;
        //    ////////////////    }
        //    ////////////////}

        //    //////////////////if (newsTimeFrom != "00:00" || newsTimeTo != "00:00")
        //    //////////////////{
        //    //////////////////    if (newsTimeFrom != "" && newsTimeTo != "")
        //    //////////////////    {
        //    //////////////////        query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
        //    //////////////////    }
        //    //////////////////}
        //    //////////////////query = query.Replace("{1}", "");

        //}

        public DataTable GetAllNewsDataTable(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead,
         bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search,
         int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable)
        {
            var panels = "";
            foreach (var str in PanelIds)
            {
                panels += str + ",";
            }

            panels = panels.Substring(0, panels.Length - 1);

            var rowNumberOrder = "ORDER BY Tbl_News.NewsId desc";
            if (!string.IsNullOrWhiteSpace(newsIds))
            {
                rowNumberOrder = "ORDER BY (SELECT NULL)";
            }

            var query = @"select * from (SELECT     ROW_NUMBER() OVER(" + rowNumberOrder + @") AS RowNum,Tbl_News.NewsID, Tbl_News.SiteID, Tbl_News.NewsDate, Tbl_News.NewsTime, Tbl_News.NewsNumber, Tbl_News.NewsTitle, Tbl_News.NewsLead, Tbl_News.NewsLinkCRC,
                         Tbl_News.NewsBody, Tbl_News.NewsPicture, Tbl_News.NewsType, Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink, Tbl_News.KeyIds,
                         Tbl_News.NewsPosition, Tbl_News.pageIndex, Tbl_News.NewsDateIndex, Tbl_News.NewsEnum, Tbl_News.IsRelate, Tbl_News.RelateList, Tbl_News.IsRead,Tbl_News.NewsGroupOrder, 
                         Tbl_News.NewsValue, Tbl_News.IsJarayed, Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_Sites.SiteType, Tbl_News.AllowTv, Tbl_News.IsFeederNews,Tbl_RssKeywords.GroupName ,Tbl_RssKeywords.KeywordName,Tbl_NewsGroup.GroupName as gpNewsGroup,Tbl_News.GroupId,Tbl_News.KeywordId,Tbl_RssKeywords.Color,Tbl_RssKeywords.GroupOrder,Tbl_News.IsSelected,Tbl_RssKeywords.OrderItem,Tbl_News.SortOrder,[dbo].[f_News_GetRelated_forAllTime] (Tbl_News.NewsID) AS RelatedNewsStringIds
                         FROM         Tbl_News LEFT OUTER JOIN
                         Tbl_RssKeywords ON Tbl_News.KeywordId = Tbl_RssKeywords.KeyId LEFT OUTER JOIN
                         Tbl_NewsGroup ON Tbl_News.GroupId = Tbl_NewsGroup.GroupId LEFT OUTER JOIN
                         Tbl_Sites ON Tbl_News.SiteID = Tbl_Sites.SiteID

        WHERE Tbl_Sites.SiteType IN (0,1,2,4) AND Tbl_RssKeywords.Active=1 AND  Tbl_News.ParminId IN (" + panels + ") {0} {1}";

            if (PanelIds.Count == 1)
            {
                //Class_Panels _clsParmin = new Class_Panels();
                //if (_clsParmin.GetParminById(int.Parse(PanelIds[0].ToString())).DefaultActiveNews != null)
                //{
                //    if (_clsParmin.GetParminById(int.Parse(PanelIds[0].ToString())).DefaultActiveNews == false)
                //    {
                query += " and Tbl_News.Active=1 ";
                //   }
                // }
            }
            if (newsIds == "")
            {


                if (isRead != null)
                {
                    if (isRead == false)
                    {
                        query += " and Tbl_News.isRead = 0";

                    }
                    else if (isRead == true)
                    {
                        query += " and Tbl_News.isRead = 1";
                    }
                }

                if (fromDate != null && toDate != null)
                {
                    string a = _clsZm.Today();
                    string b = _clsZm.AddDay(a, 1);
                    string c = _clsZm.AddDay(a, -1);
                    int yesterday = int.Parse(c.Split(' ')[0].Replace("/", ""));

                    if (newsTimeFrom != "" && newsTimeTo != "")
                    {
                        string newsTimeFromIndex = newsTimeFrom.Replace(":", "");
                        string newsTimeToIndex = newsTimeTo.Replace(":", "");
                        query = query.Replace("{0}", "and Tbl_News.NewsDateTimeIndex between " +
                            fromDate.ToString() + "" + newsTimeFromIndex + " and " + toDate.ToString() + "" + newsTimeToIndex);
                        // query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
                    }
                    else
                    {
                        query = query.Replace("{0}", "and (Tbl_News.NewsDateIndex between " +
                            fromDate + " and " + toDate +
                            ")");
                        //query = query.Replace("{0}", "and (Tbl_Relation_NewsParminPanel.NewsDateIndex between " +
                        //    fromDate + " and " + toDate +
                        //    " OR ( Tbl_Relation_NewsParminPanel.NewsDateIndex = " + yesterday +
                        //    " AND Tbl_News.NewsTime > '21:00' AND Tbl_Sites.SiteType = 2) )");
                    }

                    //    query = query.Replace("{0}", "and NewsDate between '" + Class_Static.ShamisiBySlash(fromDate + "") + "' and '" + Class_Static.ShamisiBySlash(toDate + "") + "'");
                }
                else
                {
                    query = query.Replace("{0}", "");
                }


                if (AllowTv != null)
                {
                    query += " and (Tbl_News.AllowTv is null or Tbl_News.AllowTv=1)";
                }

                if (siteType != null)
                {
                    if (siteType == -1)
                    {

                        //query = query.Where(p => p.Tbl_Sites.SiteType == 2);
                        query += " and Tbl_Sites.SiteType =1";

                    }
                    else if (siteType == -2)
                    {
                        //query = query.Where(p => p.Tbl_Sites.SiteType == 1);
                        query += " and Tbl_Sites.SiteType =2";
                    }
                    else if (siteType == -4)
                    {
                        //query = query.Where(p => p.Tbl_Sites.SiteType == 1);
                        query += " and Tbl_Sites.SiteType =4";
                    }
                    else if (siteType != 0)
                    {
                        //query = query.Where(p => p.Tbl_Sites.SiteID == siteType);
                        query += " and Tbl_Sites.SiteId =" + siteType;
                    }
                }

                //////////if (newsTimeFrom != "00:00" || newsTimeTo != "00:00")
                //////////{
                //////////    if (newsTimeFrom != "" && newsTimeTo != "")
                //////////    {
                //////////        query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
                //////////    }
                //////////}
                query = query.Replace("{1}", "");

                //if (fromTimeZone != "" && toTimeZone != "")
                //{
                //    query += " and CONVERT(VARCHAR(5), Tbl_News.CreateDate, 108) >= '" + fromTimeZone + "' and CONVERT(VARCHAR(5), Tbl_News.CreateDate, 108) <= '" + toTimeZone + "' ";
                //}
            }
            else
            {
                query = query.Replace("{0}", "");
                query = query.Replace("{1}", " and NewsId in (" + newsIds + ")");
            }
            query += ") as tbl";
            if (string.IsNullOrWhiteSpace(newsIds))
            {
                if (PageIndex != -1 && PageCount != -1)
                {
                    query += " where rownum between " + PageIndex + " and " + (PageIndex + PageCount);
                }
            }
            else
            {
                query += " where rownum >0 ";

            }

            if (Search != "")
            {
                var strSearch = Search.Split('-');
                var strSearchOr = Search.Split('|');
                if (strSearchOr.Count() > 1)
                {
                    query += " and (";
                    foreach (string param in strSearchOr)
                    {

                        if (!query.EndsWith("and ("))
                        {
                            query += " OR (";
                        }



                        var strCon = Class_Static.PersianAlpha(param);
                        //  NewsTitle-NewsLead-NewsBody
                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + " " + strCon + " " + "%' OR  NewsTitle LIKE N'%" + " " + strCon2 +
                            " " + "%' OR NewsLead LIKE N'%" + " " + strCon + " " + "%' OR  NewsLead LIKE N'%" + " " +
                            strCon2 + " " + "%'  OR NewsBody LIKE N'%" + " " + strCon + " " + "%' OR  NewsBody LIKE N'%" +
                            " " + strCon2 + " " + "%' OR NewsBody LIKE '%" + " " + strCon + " " +
                            "%' OR  NewsBody LIKE '%" + " " + strCon2 + " " + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }
                }
                else
                {
                    query += " and (";
                    foreach (string param in strSearch)
                    {
                        if (!query.EndsWith("and ("))
                        {
                            query += " and (";
                        }

                        var strCon = Class_Static.PersianAlpha(param);
                        //  NewsTitle-NewsLead-NewsBody
                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + " " + strCon + " " + "%' OR  NewsTitle LIKE N'%" + " " + strCon2 + " " +
                            "%' OR NewsLead LIKE N'%" + " " + strCon + " " + "%' OR  NewsLead LIKE N'%" + " " +
                            strCon2 + " " + "%'  OR NewsBody LIKE N'%" + " " + strCon + " " + "%' OR  NewsBody LIKE N'%" + " " +
                            strCon2 + " " + "%' OR NewsBody LIKE '%" + " " + strCon + " " +
                            "%' OR  NewsBody LIKE '%" + " " + strCon2 + " " + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }

                }




            }
            var queryTvTable = "";
            if (isFromTvTable)
            {
                queryTvTable = " AND NewsID IN ( SELECT NewsID FROM Tbl_TvNews)";
            }
            query += queryTvTable;

            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(keysIds))
            {
                if (keysIds.EndsWith(","))
                {
                    keysIds = keysIds.Substring(0, keysIds.Length - 1);

                }
                queryRssKeywords = " AND KeywordId IN (" + keysIds + ")";

            }
            query += queryRssKeywords;

            if (string.IsNullOrWhiteSpace(newsIds))
            {
                query += " order by SortOrder,OrderItem";
            }
            else
            {
                query += " order by SortOrder";

            }
            //query += " order by NewsDate desc,NewsId desc";
            query = query.Replace("{0}", "");



            SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            _Cnn.Open();

            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = _Cnn;
            dtr.SelectCommand.CommandText = query;
            dtr.SelectCommand.CommandTimeout = 20000;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            _Cnn.Close();



            return dt;

        }


        public DataTable GetSelectedTamarkozNews(string NewsIds)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsIds",NewsIds),
        };
            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", "p_News_GetSelectedTamarkozNews", CommandType.StoredProcedure, sqlParams);
            return ds.Tables[0];

        }


        public static DataSet GetStreamNews(int PageCount, int PageIndex, List<int?> PanelIds, bool? IsRead, long? FromDate,
            long? ToDate, string FromTime, string ToTime, string Search, string keysIds, string NewsIds)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "PageCount",PageCount),
                new SqlParameter("@" + "PageIndex",PageIndex),
                new SqlParameter("@" + "PanelIds",PanelIds[0]),
                new SqlParameter("@" + "IsRead",IsRead),
                new SqlParameter("@" + "FromDate",FromDate),
                new SqlParameter("@" + "ToDate",ToDate),
                new SqlParameter("@" + "FromTime",FromTime),
                new SqlParameter("@" + "ToTime",ToTime),
                new SqlParameter("@" + "Search",Search),
                new SqlParameter("@" + "keysIds",keysIds),
                new SqlParameter("@" + "NewsIds",NewsIds),
        };
            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", "p_News_GetAlldata_StreamNews", CommandType.StoredProcedure, sqlParams);
            return ds;

        }

        public static DataSet GetFocusNews(int PageCount, int PageIndex, List<int?> PanelIds, bool? IsRead, long? FromDate,
    long? ToDate, string Search, string keysIds, string NewsIds)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "PageCount",PageCount),
                new SqlParameter("@" + "PageIndex",PageIndex),
                new SqlParameter("@" + "PanelIds",PanelIds[0]),
                new SqlParameter("@" + "IsRead",IsRead),
                new SqlParameter("@" + "FromDate",FromDate),
                new SqlParameter("@" + "ToDate",ToDate),

                new SqlParameter("@" + "Search",Search),
                new SqlParameter("@" + "keysIds",keysIds),
                new SqlParameter("@" + "NewsIds",NewsIds),
        };
            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", "p_News_GetAlldata_FocusNews", CommandType.StoredProcedure, sqlParams);
            return ds;

        }



        public static DataSet GetData(long DateIndex, int ParminId)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "DateIndex",DateIndex),
                new SqlParameter("@" + "ParminId",ParminId)
        };

            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", "p_News_GetNewsForRelated", CommandType.StoredProcedure, sqlParams);
            return ds;
        }



        public static DataSet GetInternationalNews(int PageCount, int PageIndex, List<int?> PanelIds, bool? IsRead, long? FromDate,
      long? ToDate, string FromTime, string ToTime, string Search, string keysIds, string NewsIds)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "PageCount",PageCount),
                new SqlParameter("@" + "PageIndex",PageIndex),
                new SqlParameter("@" + "PanelIds",PanelIds[0]),
                new SqlParameter("@" + "IsRead",IsRead),
                new SqlParameter("@" + "FromDate",FromDate),
                new SqlParameter("@" + "ToDate",ToDate),
                new SqlParameter("@" + "FromTime",FromTime),
                new SqlParameter("@" + "ToTime",ToTime),
                new SqlParameter("@" + "Search",Search),
                new SqlParameter("@" + "keysIds",keysIds),
                new SqlParameter("@" + "NewsIds",NewsIds),


        };
            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", "p_News_GetAlldata_InternationalNews", CommandType.StoredProcedure, sqlParams);
            return ds;

        }


        public static List<Tbl_News_Type> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_Type acc = new Tbl_News_Type();
                acc.NewsLink = dr["NewsLink"].ToString();//"/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"];
                acc.SiteID = Convert.ToInt32(dr["SiteID"]);
                acc.NewsID = Convert.ToInt32(dr["NewsID"]);
                acc.GroupId = Convert.ToInt32(dr["GroupId"]);
                acc.KeywordId = Convert.ToInt32(dr["KeywordId"]);
                acc.NewsTitle = _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false);
                acc.NewsDate = dr["NewsDate"] + "";
                acc.NewsLead = _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false);
                acc.KeywordName = dr["KeywordName"] + "";
                acc.NewsBody = _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false);
                acc.SiteTitle = dr["SiteTitle"] + "";
                acc.NewsPicture = dr["NewsPicture"] + "";
                if (acc.NewsPicture == "")
                    acc.NewsPicture = "/Pages/P-Art/Images/noimage.png";
                acc.GroupName = dr["GroupName"] + "";
                acc.CreateDate = (dr["CreateDate"] + "");
                acc.SiteType = Convert.ToInt32(dr["SiteType"]);
                acc.NewsTime = dr["NewsTime"] + "";
                acc.SiteLogo = dr["Logo"] + "";
                acc.GroupOrder = Class_Static.ToNullableInt(dr["GroupOrder"] + "");
                acc.NewsValue = (dr["NewsValue"] + "");
                acc.NewsGroupOrder = Class_Static.ToNullableInt(dr["NewsGroupOrder"] + "");
                //acc.NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"]);
                try { acc.RelatedNewsStringIds = dr["RelatedNewsStringIds"] + ""; } catch { acc.RelatedNewsStringIds = ""; }
                list.Add(acc);
            }
            return list;
        }
        public List<Tbl_News_Type> GetFromDataRowsBultanMedia(DataRow[] Rows , List<Tbl_RssKeywords> keywords)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            char HalfSpace = (char)8204;
            char space = (char)' ';
            int indexOrder = 0;

            foreach (DataRow dr in Rows)
            {

                indexOrder++;
                Tbl_News_Type acc = new Tbl_News_Type();
                acc.NewsTitle = Class_Static.ArabicAlpha(_clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false));
                acc.NewsTitle = acc.NewsTitle.Replace(HalfSpace, space);
                acc.NewsTitle = Persia.PersianWord.ConvertToLatinNumber(acc.NewsTitle);
                acc.NewsLink = "/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"];
                acc.SiteID = Convert.ToInt32(dr["SiteID"]);
                acc.NewsDate = dr["NewsDate"] + "";
                acc.NewsDateIndex = Convert.ToInt64(dr["NewsDate"].ToString().Replace("/", ""));
                acc.NewsID = Convert.ToInt32(dr["NewsID"]);
                acc.GroupId = Convert.ToInt32(dr["GroupId"]);
                acc.KeywordId = Convert.ToInt32(dr["KeywordId"]);
                acc.NewsLead = _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false);
                acc.KeywordName = dr["KeywordName"] + "";
                acc.NewsBody = _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false);
                acc.SiteTitle = dr["SiteTitle"] + "";
                acc.NewsPicture = dr["NewsPicture"] + "";
                if (acc.NewsPicture == "" || acc.NewsPicture == null)
                    acc.NewsPicture = "/Pages/P-Art/Images/noimage.png";
                acc.GroupName = dr["GroupName"] + "";
                acc.CreateDate = (dr["CreateDate"] + "");
                acc.SiteType = Convert.ToInt32(dr["SiteType"]);
                acc.NewsTime = dr["NewsTime"] + "";
                acc.SiteLogo = dr["Logo"] + "";
                acc.GroupOrder = Class_Static.ToNullableInt(dr["GroupOrder"] + "");
                acc.NewsValue = (dr["NewsValue"] + "");
                acc.NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"]);
                acc.NewsGroupOrder = Class_Static.ToNullableInt(dr["NewsGroupOrder"] + "");
                //acc.NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"]);
                try { acc.RelatedNewsStringIds = dr["RelatedNewsStringIds"] + ""; } catch { acc.RelatedNewsStringIds = ""; }
                try { acc.RelatedString = dr["RelatedNewsStringIds"] + ""; } catch { acc.RelatedString = ""; }
                acc.UserIndexOrder = indexOrder;


                var keyId = Convert.ToInt32(dr["GroupId"]);
                var currentKey = keywords.FirstOrDefault(i => i.KeyId == keyId);

                list.Add(acc);
            }
            return list;
        }
        public DataTable GetAllNewsDataTable(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead,
            bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search,
            int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable, bool IsBodySelect = true)
        {
            var panels = "";
            foreach (var str in PanelIds)
            {
                panels += str + ",";
            }

            panels = panels.Substring(0, panels.Length - 1);


            var rowNumberOrder = "ORDER BY Tbl_News.NewsId desc";
            if (!string.IsNullOrWhiteSpace(newsIds))
            {
                rowNumberOrder = "ORDER BY (SELECT NULL)";
            }






            string searchQuery = "";
            if (IsBodySelect == false)
            {
                if (Search != "")
                    searchQuery = "Tbl_News.NewsBody";
                else searchQuery = " '' as NewsBody";
            }
            else
            {
                searchQuery = "Tbl_News.NewsBody";
            }


            var query = @"select * from (SELECT     ROW_NUMBER() OVER(" + rowNumberOrder + @") AS RowNum,Tbl_News.NewsID, Tbl_News.SiteID, Tbl_News.NewsDate, Tbl_News.NewsTime, Tbl_News.NewsNumber, Tbl_News.NewsTitle, Tbl_News.NewsLead, Tbl_News.NewsLinkCRC,
                         " + searchQuery + @", Tbl_News.NewsPicture, Tbl_News.NewsType, Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink, Tbl_News.KeyIds,
                         Tbl_News.NewsPosition, Tbl_News.pageIndex, Tbl_News.NewsDateIndex, Tbl_News.NewsEnum, Tbl_News.IsRelate, Tbl_News.RelateList, Tbl_News.IsRead,Tbl_News.NewsGroupOrder, 
                         Tbl_News.NewsValue, Tbl_News.IsJarayed, Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_Sites.SiteType, Tbl_News.AllowTv, Tbl_News.IsFeederNews,Tbl_RssKeywords.GroupName ,Tbl_RssKeywords.KeywordName,Tbl_NewsGroup.GroupName as gpNewsGroup,Tbl_News.GroupId,Tbl_News.KeywordId,Tbl_RssKeywords.Color,Tbl_RssKeywords.GroupOrder,Tbl_News.IsSelected,Tbl_RssKeywords.OrderItem,Tbl_News.SortOrder,[dbo].[f_News_GetRelated_forAllTime] (Tbl_News.NewsID) AS RelatedNewsStringIds
                         FROM  Tbl_News LEFT OUTER JOIN
                         Tbl_RssKeywords ON Tbl_News.KeywordId = Tbl_RssKeywords.KeyId LEFT OUTER JOIN
                         Tbl_NewsGroup ON Tbl_News.GroupId = Tbl_NewsGroup.GroupId LEFT OUTER JOIN
                         Tbl_Sites ON Tbl_News.SiteID = Tbl_Sites.SiteID

        WHERE Tbl_Sites.SiteType IN (0,1,2) AND Tbl_RssKeywords.Active=1 AND  Tbl_News.NewsId in (SELECT distinct(NewsId) from Tbl_Relation_NewsParminPanel WHERE ParminPanelId IN (" + panels + ") {0}) {1}";

            if (PanelIds.Count == 1)
            {
                //Class_Panels _clsParmin = new Class_Panels();
                //if (_clsParmin.GetParminById(int.Parse(PanelIds[0].ToString())).DefaultActiveNews != null)
                //{
                //    if (_clsParmin.GetParminById(int.Parse(PanelIds[0].ToString())).DefaultActiveNews == false)
                //    {
                query += " and Tbl_News.Active=1 ";
                //   }
                // }
            }
            if (newsIds == "")
            {


                if (isRead != null)
                {
                    if (isRead == false)
                    {
                        query += " and Tbl_News.isRead = 0";

                    }
                    else if (isRead == true)
                    {
                        query += " and Tbl_News.isRead = 1";
                    }
                }

                if (fromDate != null && toDate != null)
                {
                    string a = _clsZm.Today();
                    string b = _clsZm.AddDay(a, 1);
                    string c = _clsZm.AddDay(a, -1);
                    int yesterday = int.Parse(c.Split(' ')[0].Replace("/", ""));

                    if (newsTimeFrom != "" && newsTimeTo != "")
                    {
                        string newsTimeFromIndex = newsTimeFrom.Replace(":", "");
                        string newsTimeToIndex = newsTimeTo.Replace(":", "");
                        query = query.Replace("{0}", "and ( CAST(Tbl_Relation_NewsParminPanel.NewsDateIndex AS VARCHAR(8)) + [dbo].[f_News_CorrectTime](Tbl_News.NewsTime)) between '" +
                            fromDate.ToString() + "" + newsTimeFromIndex + "' and '" + toDate.ToString() + "" + newsTimeToIndex + "'");
                        // query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
                    }
                    else
                    {
                        query = query.Replace("{0}", "and (Tbl_Relation_NewsParminPanel.NewsDateIndex between " +
                            fromDate + " and " + toDate +
                            ")");
                        //query = query.Replace("{0}", "and (Tbl_Relation_NewsParminPanel.NewsDateIndex between " +
                        //    fromDate + " and " + toDate +
                        //    " OR ( Tbl_Relation_NewsParminPanel.NewsDateIndex = " + yesterday +
                        //    " AND Tbl_News.NewsTime > '21:00' AND Tbl_Sites.SiteType = 2) )");
                    }

                    //    query = query.Replace("{0}", "and NewsDate between '" + Class_Static.ShamisiBySlash(fromDate + "") + "' and '" + Class_Static.ShamisiBySlash(toDate + "") + "'");
                }
                else
                {
                    query = query.Replace("{0}", "");
                }


                if (AllowTv != null)
                {
                    query += " and (Tbl_News.AllowTv is null or Tbl_News.AllowTv=1)";
                }

                if (siteType != null)
                {
                    if (siteType == -1)
                    {

                        //query = query.Where(p => p.Tbl_Sites.SiteType == 2);
                        query += " and Tbl_Sites.SiteType =1";

                    }
                    else if (siteType == -2)
                    {
                        //query = query.Where(p => p.Tbl_Sites.SiteType == 1);
                        query += " and Tbl_Sites.SiteType =2";
                    }
                    else if (siteType != 0)
                    {
                        //query = query.Where(p => p.Tbl_Sites.SiteID == siteType);
                        query += " and Tbl_Sites.SiteId =" + siteType;
                    }
                }

                //////////if (newsTimeFrom != "00:00" || newsTimeTo != "00:00")
                //////////{
                //////////    if (newsTimeFrom != "" && newsTimeTo != "")
                //////////    {
                //////////        query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
                //////////    }
                //////////}
                query = query.Replace("{1}", "");

                //if (fromTimeZone != "" && toTimeZone != "")
                //{
                //    query += " and CONVERT(VARCHAR(5), Tbl_News.CreateDate, 108) >= '" + fromTimeZone + "' and CONVERT(VARCHAR(5), Tbl_News.CreateDate, 108) <= '" + toTimeZone + "' ";
                //}
            }
            else
            {
                query = query.Replace("{0}", "");
                query = query.Replace("{1}", " and NewsId in (" + newsIds + ")");
            }
            query += ") as tbl";
            if (string.IsNullOrWhiteSpace(newsIds))
            {
                if (PageIndex != -1 && PageCount != -1)
                {
                    query += " where rownum between " + PageIndex + " and " + (PageIndex + PageCount);
                }
            }
            else
            {
                query += " where rownum >0 ";

            }

            if (Search != "")
            {
                var strSearch = Search.Split('-');
                var strSearchOr = Search.Split('|');
                if (strSearchOr.Count() > 1)
                {
                    query += " and (";
                    foreach (string param in strSearchOr)
                    {

                        if (!query.EndsWith("and ("))
                        {
                            query += " OR (";
                        }

                        var strCon = Class_Static.PersianAlpha(param);
                        //  NewsTitle-NewsLead-NewsBody
                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }
                }
                else
                {
                    query += " and (";
                    foreach (string param in strSearch)
                    {
                        if (!query.EndsWith("and ("))
                        {
                            query += " and (";
                        }

                        var strCon = Class_Static.PersianAlpha(param);
                        //  NewsTitle-NewsLead-NewsBody
                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }

                }




            }
            var queryTvTable = "";
            if (isFromTvTable)
            {
                queryTvTable = " AND NewsID IN ( SELECT NewsID FROM Tbl_TvNews)";
            }
            query += queryTvTable;

            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(keysIds))
            {
                if (keysIds.EndsWith(","))
                {
                    keysIds = keysIds.Substring(0, keysIds.Length - 1);

                }
                queryRssKeywords = " AND KeywordId IN (" + keysIds + ")";

            }
            query += queryRssKeywords;

            if (string.IsNullOrWhiteSpace(newsIds))
            {
                query += " ORDER BY ISNULL(SortOrder,1000) ASC, tbl.NewsDate DESC,tbl.NewsTime DESC	 ";
            }
            else
            {
                query += " ORDER BY ISNULL(SortOrder,1000) ASC, tbl.NewsDate DESC,tbl.NewsTime DESC";

            }
            //query += " order by NewsDate desc,NewsId desc";
            query = query.Replace("{0}", "");



            SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            _Cnn.Open();

            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = _Cnn;
            dtr.SelectCommand.CommandText = query;
            dtr.SelectCommand.CommandTimeout = 20000;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            _Cnn.Close();



            return dt;

        }


        public static DataTable GetAllInternationalNewsDataTable(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead,
    bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search,
    int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable, bool IsBodySelect = true)
        {
            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

            Class_Zaman _clsZm = new Class_Zaman();

            var panels = "";
            foreach (var str in PanelIds)
            {
                panels += str + ",";
            }

            panels = panels.Substring(0, panels.Length - 1);



            var rowNumberOrder = "ORDER BY Tbl_News.NewsId desc";
            if (!string.IsNullOrWhiteSpace(newsIds))
            {
                rowNumberOrder = "ORDER BY (SELECT NULL)";
            }


            string searchQuery = "";
            if (IsBodySelect == false)
            {
                if (Search != "")
                    searchQuery = "Tbl_News.NewsBody";
                else searchQuery = " '' as NewsBody";
            }
            else
            {
                searchQuery = "Tbl_News.NewsBody";
            }


            var query = @"select * from (SELECT     ROW_NUMBER() OVER(" + rowNumberOrder + @") AS RowNum,Tbl_News.NewsID, Tbl_News.SiteID, Tbl_News.NewsDate, Tbl_News.NewsTime, Tbl_News.NewsNumber, Tbl_News.NewsTitle, Tbl_News.NewsLead, Tbl_News.NewsLinkCRC,
                         " + searchQuery + @", Tbl_News.NewsPicture, Tbl_News.NewsType, Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink, Tbl_News.KeyIds,
                         Tbl_News.NewsPosition, Tbl_News.pageIndex, Tbl_News.NewsDateIndex, Tbl_News.NewsEnum, Tbl_News.IsRelate, Tbl_News.RelateList, Tbl_News.IsRead,Tbl_News.NewsGroupOrder, 
                         Tbl_News.NewsValue, Tbl_News.IsJarayed, Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_Sites.SiteType, Tbl_News.AllowTv, Tbl_News.IsFeederNews,Tbl_RssKeywords.GroupName ,Tbl_RssKeywords.KeywordName,Tbl_NewsGroup.GroupName as gpNewsGroup,Tbl_News.GroupId,Tbl_News.KeywordId,Tbl_RssKeywords.Color,Tbl_RssKeywords.GroupOrder,Tbl_News.IsSelected,Tbl_RssKeywords.OrderItem,Tbl_News.SortOrder,[dbo].[f_News_GetRelated_forAllTime] (Tbl_News.NewsID) AS RelatedNewsStringIds
                         FROM  Tbl_News LEFT OUTER JOIN
                         Tbl_RssKeywords ON Tbl_News.KeywordId = Tbl_RssKeywords.KeyId LEFT OUTER JOIN
                         Tbl_NewsGroup ON Tbl_News.GroupId = Tbl_NewsGroup.GroupId LEFT OUTER JOIN
                         Tbl_Sites ON Tbl_News.SiteID = Tbl_Sites.SiteID

        WHERE Tbl_Sites.SiteType IN (3) AND Tbl_RssKeywords.Active=1 AND  Tbl_News.NewsId in (SELECT distinct(NewsId) from Tbl_Relation_NewsParminPanel WHERE ParminPanelId IN (" + panels + ") {0}) {1}";

            if (PanelIds.Count == 1)
            {

                query += " and Tbl_News.Active=1 ";

            }
            if (newsIds == "")
            {


                if (isRead != null)
                {
                    if (isRead == false)
                    {
                        query += " and Tbl_News.isRead = 0";

                    }
                    else if (isRead == true)
                    {
                        query += " and Tbl_News.isRead = 1";
                    }
                }

                if (fromDate != null && toDate != null)
                {
                    string a = _clsZm.Today();
                    string b = _clsZm.AddDay(a, 1);
                    string c = _clsZm.AddDay(a, -1);
                    int yesterday = int.Parse(a.Split(' ')[0].Replace("/", ""));

                    if (newsTimeFrom != "" && newsTimeTo != "")
                    {
                        string newsTimeFromIndex = newsTimeFrom.Replace(":", "");
                        string newsTimeToIndex = newsTimeTo.Replace(":", "");
                        query = query.Replace("{0}", "and ( CAST(Tbl_Relation_NewsParminPanel.NewsDateIndex AS VARCHAR(8)) + [dbo].[f_News_CorrectTime](Tbl_News.NewsTime)) between '" +
                            fromDate.ToString() + "" + newsTimeFromIndex + "' and '" + toDate.ToString() + "" + newsTimeToIndex + "'");

                    }
                    else
                    {
                        query = query.Replace("{0}", "and (Tbl_Relation_NewsParminPanel.NewsDateIndex between " +
                            fromDate.ToString() + " and " + toDate.ToString() +
                            ")");

                    }


                }
                else
                {
                    query = query.Replace("{0}", "");
                }


                if (AllowTv != null)
                {
                    query += " and (Tbl_News.AllowTv is null or Tbl_News.AllowTv=1)";
                }

                if (siteType != null)
                {
                    if (siteType == -1)
                    {


                        query += " and Tbl_Sites.SiteType = 3";

                    }
                    else if (siteType == -2)
                    {

                        query += " and Tbl_Sites.SiteType = 3";
                    }
                    else if (siteType != 0)
                    {

                        query += " and Tbl_Sites.SiteId =" + siteType;
                    }
                }


                query = query.Replace("{1}", "");


            }
            else
            {
                query = query.Replace("{0}", "");
                query = query.Replace("{1}", " and NewsId in (" + newsIds + ")");
            }
            query += ") as tbl";
            if (string.IsNullOrWhiteSpace(newsIds))
            {
                if (PageIndex != -1 && PageCount != -1)
                {
                    query += " where rownum between " + PageIndex + " and " + (PageIndex + PageCount);
                }
            }
            else
            {
                query += " where rownum >0 ";

            }

            if (Search != "")
            {
                var strSearch = Search.Split('-');
                var strSearchOr = Search.Split('|');
                if (strSearchOr.Count() > 1)
                {
                    query += " and (";
                    foreach (string param in strSearchOr)
                    {

                        if (!query.EndsWith("and ("))
                        {
                            query += " OR (";
                        }



                        var strCon = Class_Static.PersianAlpha(param);

                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }
                }
                else
                {
                    query += " and (";
                    foreach (string param in strSearch)
                    {
                        if (!query.EndsWith("and ("))
                        {
                            query += " and (";
                        }

                        var strCon = Class_Static.PersianAlpha(param);

                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }

                }




            }
            var queryTvTable = "";
            if (isFromTvTable)
            {
                queryTvTable = " AND NewsID IN ( SELECT NewsID FROM Tbl_TvNews)";
            }
            query += queryTvTable;

            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(keysIds))
            {
                if (keysIds.EndsWith(","))
                {
                    keysIds = keysIds.Substring(0, keysIds.Length - 1);

                }
                queryRssKeywords = " AND KeywordId IN (" + keysIds + ")";

            }
            query += queryRssKeywords;

            if (string.IsNullOrWhiteSpace(newsIds))
            {
                query += "ORDER BY ISNULL(SortOrder,1000) ASC, tbl.NewsDate DESC,tbl.NewsTime DESC";
            }
            else
            {
                query += " ORDER BY ISNULL(SortOrder,1000) ASC, tbl.NewsDate DESC,tbl.NewsTime DESC";

            }

            query = query.Replace("{0}", "");



            SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            _Cnn.Open();

            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = _Cnn;
            dtr.SelectCommand.CommandText = query;
            dtr.SelectCommand.CommandTimeout = 20000;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            _Cnn.Close();



            return dt;

        }

        public static List<Tbl_News_Type> GetFromDataRows2(DataRow[] Rows)
        {
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            foreach (DataRow r in Rows)
            {
                Tbl_News_Type n = new Tbl_News_Type();
                n.NewsID = Convert.ToInt32(r["NewsID"]);
                n.SiteID = Convert.ToInt32(r["SiteID"].ToString());
                n.NewsTitle = r["NewsTitle"].ToString();
                n.NewsLead = r["NewsLead"].ToString();
                n.NewsBody = r["NewsBody"].ToString();
                n.CreateDate = (r["CreateDate"]).ToString();
                n.KeywordId = Convert.ToInt32(r["KeywordId"]);
                n.KeyIds = r["KeyIds"].ToString();
                n.NewsTime = r["NewsTime"].ToString();
                n.NewsDateIndex = Convert.ToInt64(r["NewsDateIndex"]);
                list.Add(n);
            }
            return list;
        }

        public static string SpaceToWord(string input)
        {
            var lst = new List<string>() { ".", ",", "!", "-", "\u2000", ")", "(", "[", "]", "{", "}" , ":" ,
                "،","‌","%","*","_","<" , ">" , "»","«","=","\"","/","؟","?","\r\n","\r","\n"
            };
            input = input.Replace("\r\n", " ");
            input = input.Replace("\r", " ");
            input = input.Replace("\n", " ");
            input = input.Trim();
            foreach (var sec in lst)
            {

                input = input.Replace(sec, " " + sec + " ");

            }

            input = input + " ";
            return input;
        }

        public static string removeIligalCharacter(string input)
        {
            var lst = new List<string>() { ".", ",", "!", "-", "\u2000", ")", "(", "[", "]", "{", "}" , ":" ,
                "،","‌","%","*","_","<" , ">" , "»","«","=","\"","/","؟","?","\r\n","\r","\n"
            };
            input = input.Replace("\r\n", " ");
            input = input.Replace("\r", " ");
            input = input.Replace("\n", " ");
            input = input.Trim();
            foreach (var sec in lst)
                input = input.Replace(sec, " ");

            return input;
        }

        public static bool IsContainPrepositionPersianWord(string input)
        {
            List<string> lst = new List<string>() { "از", "الی", "الاّ", "اندر", "با", "بدون", "بر", "برای", "به", "بهر", "بی" , "تا" ,
                "جز","‌چون","در","ضد","علیه","غیر" , "مانند" , "مثل","مگر","واسه‎ی","غیراز","اگر","اما","باری","پس","تا","چه","هریک","ای","ضمن","های","حالی",
                "خواه","‌زیرا","که","لیکن","نیز","و" , "ولی" , "هم","یا","‎آن‌","ازبس","اگرچه","چنان‌چه","چنان‌که","اکنون","ازاین‌روی","آن‌گاه","این","را","روی","رو","آنها"
            };
            bool result = false;
            foreach (string s in lst)
                if (input == s)
                {
                    result = true;
                    if (result == true)
                        break;
                }
            return result;
        }

        public static void UpdateRelated(int NewsId, int RelatedNewsId, bool IsReference, string NewsDateTimeIndex)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsId",NewsId),
                new SqlParameter("@" + "RelatedNewsId",RelatedNewsId),
                 new SqlParameter("@" + "IsReference",IsReference),
                  new SqlParameter("@" + "NewsDateTimeIndex",NewsDateTimeIndex)
        };

            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", "p_NewsRelated_Update", CommandType.StoredProcedure);

        }


        public DataTable GetAllNewsDataTableByNewsIds(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead, bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search, int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable)
        {
            DataTable dt = new DataTable();

                var panels = "";
                foreach (var str in PanelIds)
                {
                    panels += str + ",";
                }

                panels = panels.Substring(0, panels.Length - 1);
                var query = @"select Tbl_News.NewsID, Tbl_News.SiteID, Tbl_News.NewsDate, Tbl_News.NewsTime, Tbl_News.NewsNumber, Tbl_News.NewsTitle, Tbl_News.NewsLead, Tbl_News.NewsLinkCRC,
                         Tbl_News.NewsBody, Tbl_News.NewsPicture, Tbl_News.NewsType, Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink, Tbl_News.KeyIds,
                         Tbl_News.NewsPosition,ISNULL(NewsTypeShow,1) AS NewsTypeShow, Tbl_News.pageIndex, Tbl_News.NewsDateIndex, Tbl_News.NewsEnum, Tbl_News.IsRelate, Tbl_News.RelateList, Tbl_News.IsRead,Tbl_News.NewsGroupOrder, 
                         Tbl_News.NewsValue, Tbl_News.IsJarayed, Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_Sites.SiteType, Tbl_News.AllowTv, Tbl_News.IsFeederNews,Tbl_RssKeywords.GroupName ,Tbl_RssKeywords.KeywordName,Tbl_NewsGroup.GroupName as gpNewsGroup,Tbl_News.GroupId,Tbl_News.KeywordId,Tbl_RssKeywords.Color,Tbl_RssKeywords.GroupOrder,Tbl_News.IsSelected,Tbl_RssKeywords.OrderItem,Tbl_News.SortOrder,'' AS RelatedNewsStringIds
                         FROM         Tbl_News LEFT OUTER JOIN
                         Tbl_RssKeywords ON Tbl_News.KeywordId = Tbl_RssKeywords.KeyId LEFT OUTER JOIN
                         Tbl_NewsGroup ON Tbl_News.GroupId = Tbl_NewsGroup.GroupId LEFT OUTER JOIN
                         Tbl_Sites ON Tbl_News.SiteID = Tbl_Sites.SiteID

        WHERE Tbl_Sites.SiteType IN (0,1,2,3) AND  Tbl_News.ParminId  = " + panels + " {0} {1}";

                if (PanelIds.Count == 1)
                {
                    query += " and Tbl_News.Active=1 ";
                }
                if (newsIds == "")
                {


                    if (isRead != null)
                    {
                        if (isRead == false)
                        {
                            query += " and Tbl_News.isRead = 0";

                        }
                        else if (isRead == true)
                        {
                            query += " and Tbl_News.isRead = 1";
                        }
                    }

                    if (fromDate != null && toDate != null)
                    {
                        string a = _clsZm.Today();
                        string b = _clsZm.AddDay(a, 1);
                        string c = _clsZm.AddDay(a, -1);
                        int yesterday = int.Parse(c.Split(' ')[0].Replace("/", ""));
                        query = query.Replace("{0}", "and (Tbl_News.NewsDateIndex between " + fromDate + " and " + toDate + " OR ( Tbl_News.NewsDateIndex = " + yesterday + " AND Tbl_News.NewsTime > '21:00' AND Tbl_Sites.SiteType = 2) )");
                    }
                    else
                    {
                        query = query.Replace("{0}", "");
                    }


                    if (AllowTv != null)
                    {
                        query += " and (Tbl_News.AllowTv is null or Tbl_News.AllowTv=1)";
                    }

                    if (siteType != null)
                    {
                        if (siteType == -1)
                        {
                            query += " and Tbl_Sites.SiteType =1";
                        }
                        else if (siteType == -2)
                        {
                            query += " and Tbl_Sites.SiteType =2";
                        }
                        else if (siteType != 0)
                        {
                            query += " and Tbl_Sites.SiteId =" + siteType;
                        }
                    }

                    if (newsTimeFrom != "00:00" || newsTimeTo != "00:00")
                    {
                        if (newsTimeFrom != "" && newsTimeTo != "")
                        {
                            query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
                        }
                    }
                    query = query.Replace("{1}", "");
                }
                else
                {
                    query = query.Replace("{0}", "");
                    query = query.Replace("{1}", " and NewsId in (" + newsIds + ")");
                }

                if (Search != "")
                {
                    var strSearch = Search.Split('-');
                    var strSearchOr = Search.Split('|');
                    if (strSearchOr.Count() > 1)
                    {
                        query += " and (";
                        foreach (string param in strSearchOr)
                        {

                            if (!query.EndsWith("and ("))
                            {
                                query += " OR (";
                            }



                            var strCon = Class_Static.PersianAlpha(param);
                            //  NewsTitle-NewsLead-NewsBody
                            var strCon2 = Class_Static.ArabicAlpha(param);
                            query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                            query = query.Substring(0, query.Length - 4);
                            query += ")";
                        }
                    }
                    else
                    {
                        query += " and (";
                        foreach (string param in strSearch)
                        {
                            if (!query.EndsWith("and ("))
                            {
                                query += " and (";
                            }

                            var strCon = Class_Static.PersianAlpha(param);
                            //  NewsTitle-NewsLead-NewsBody
                            var strCon2 = Class_Static.ArabicAlpha(param);
                            query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                            query = query.Substring(0, query.Length - 4);
                            query += ")";
                        }

                    }




                }
                var queryTvTable = "";
                if (isFromTvTable)
                {
                    queryTvTable = " AND NewsID IN ( SELECT NewsID FROM Tbl_TvNews)";
                }
                query += queryTvTable;

                var queryRssKeywords = "";
                if (!string.IsNullOrWhiteSpace(keysIds))
                {
                    if (keysIds.EndsWith(","))
                    {
                        keysIds = keysIds.Substring(0, keysIds.Length - 1);

                    }
                    queryRssKeywords = " AND KeywordId IN (" + keysIds + ")";

                }
                query += queryRssKeywords;

                if (string.IsNullOrWhiteSpace(newsIds))
                {
                    query += " order by SortOrder,OrderItem";
                }
                else
                {
                    query += " order by SortOrder";

                }
                //query += " order by NewsDate desc,NewsId desc";
                query = query.Replace("{0}", "");
                //
                //query = query.Replace(" AND  Tbl_News.NewsId in (SELECT distinct(NewsId) from Tbl_Relation_NewsParminPanel WHERE ParminPanelId IN (14) ) ", "");



                SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
                _Cnn.Open();

                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = _Cnn;
                dtr.SelectCommand.CommandText = query;
                dtr.SelectCommand.CommandTimeout = 20000;
              
                dtr.Fill(dt);

                _Cnn.Close();



                return dt;

        }

        public DataTable GetAllNewsDataTableByNewsIdsBultanMedia(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead, bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search, int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable)
        {
            DataTable dt = new DataTable();
            if (newsIds != "" && newsIds != null)
            {
                var panels = "";
                foreach (var str in PanelIds)
                {
                    panels += str + ",";
                }

                panels = panels.Substring(0, panels.Length - 1);
                var query = @"select Tbl_News.NewsID, Tbl_News.SiteID, Tbl_News.NewsDate, Tbl_News.NewsTime, Tbl_News.NewsNumber, Tbl_News.NewsTitle, Tbl_News.NewsLead, Tbl_News.NewsLinkCRC,
                         Tbl_News.NewsBody, Tbl_News.NewsPicture, Tbl_News.NewsType, Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink, Tbl_News.KeyIds,
                         Tbl_News.NewsPosition,ISNULL(NewsTypeShow,1) AS NewsTypeShow, Tbl_News.pageIndex, Tbl_News.NewsDateIndex, Tbl_News.NewsEnum, Tbl_News.IsRelate, Tbl_News.RelateList, Tbl_News.IsRead,Tbl_News.NewsGroupOrder, 
                         Tbl_News.NewsValue, Tbl_News.IsJarayed, Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_Sites.SiteType, Tbl_News.AllowTv, Tbl_News.IsFeederNews,Tbl_RssKeywords.GroupName ,Tbl_RssKeywords.KeywordName,Tbl_NewsGroup.GroupName as gpNewsGroup,Tbl_News.GroupId,Tbl_News.KeywordId,Tbl_RssKeywords.Color,Tbl_RssKeywords.GroupOrder,Tbl_News.IsSelected,Tbl_RssKeywords.OrderItem,Tbl_News.SortOrder,'' AS RelatedNewsStringIds
                         FROM         Tbl_News LEFT OUTER JOIN
                         Tbl_RssKeywords ON Tbl_News.KeywordId = Tbl_RssKeywords.KeyId LEFT OUTER JOIN
                         Tbl_NewsGroup ON Tbl_News.GroupId = Tbl_NewsGroup.GroupId LEFT OUTER JOIN
                         Tbl_Sites ON Tbl_News.SiteID = Tbl_Sites.SiteID

        WHERE Tbl_Sites.SiteType IN (0,1,2,3) AND  Tbl_News.ParminId  = " + panels + " {0} {1}";

                if (PanelIds.Count == 1)
                {
                    query += " and Tbl_News.Active=1 ";
                }
                if (newsIds == "")
                {


                    if (isRead != null)
                    {
                        if (isRead == false)
                        {
                            query += " and Tbl_News.isRead = 0";

                        }
                        else if (isRead == true)
                        {
                            query += " and Tbl_News.isRead = 1";
                        }
                    }

                    if (fromDate != null && toDate != null)
                    {
                        string a = _clsZm.Today();
                        string b = _clsZm.AddDay(a, 1);
                        string c = _clsZm.AddDay(a, -1);
                        int yesterday = int.Parse(c.Split(' ')[0].Replace("/", ""));
                        query = query.Replace("{0}", "and (Tbl_News.NewsDateIndex between " + fromDate + " and " + toDate + " OR ( Tbl_News.NewsDateIndex = " + yesterday + " AND Tbl_News.NewsTime > '21:00' AND Tbl_Sites.SiteType = 2) )");
                    }
                    else
                    {
                        query = query.Replace("{0}", "");
                    }


                    if (AllowTv != null)
                    {
                        query += " and (Tbl_News.AllowTv is null or Tbl_News.AllowTv=1)";
                    }

                    if (siteType != null)
                    {
                        if (siteType == -1)
                        {
                            query += " and Tbl_Sites.SiteType =1";
                        }
                        else if (siteType == -2)
                        {
                            query += " and Tbl_Sites.SiteType =2";
                        }
                        else if (siteType != 0)
                        {
                            query += " and Tbl_Sites.SiteId =" + siteType;
                        }
                    }

                    if (newsTimeFrom != "00:00" || newsTimeTo != "00:00")
                    {
                        if (newsTimeFrom != "" && newsTimeTo != "")
                        {
                            query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
                        }
                    }
                    query = query.Replace("{1}", "");
                }
                else
                {
                    query = query.Replace("{0}", "");
                    query = query.Replace("{1}", " and NewsId in (" + newsIds + ")");
                }

                if (Search != "")
                {
                    var strSearch = Search.Split('-');
                    var strSearchOr = Search.Split('|');
                    if (strSearchOr.Count() > 1)
                    {
                        query += " and (";
                        foreach (string param in strSearchOr)
                        {

                            if (!query.EndsWith("and ("))
                            {
                                query += " OR (";
                            }



                            var strCon = Class_Static.PersianAlpha(param);
                            //  NewsTitle-NewsLead-NewsBody
                            var strCon2 = Class_Static.ArabicAlpha(param);
                            query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                            query = query.Substring(0, query.Length - 4);
                            query += ")";
                        }
                    }
                    else
                    {
                        query += " and (";
                        foreach (string param in strSearch)
                        {
                            if (!query.EndsWith("and ("))
                            {
                                query += " and (";
                            }

                            var strCon = Class_Static.PersianAlpha(param);
                            //  NewsTitle-NewsLead-NewsBody
                            var strCon2 = Class_Static.ArabicAlpha(param);
                            query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                            query = query.Substring(0, query.Length - 4);
                            query += ")";
                        }

                    }




                }
                var queryTvTable = "";
                if (isFromTvTable)
                {
                    queryTvTable = " AND NewsID IN ( SELECT NewsID FROM Tbl_TvNews)";
                }
                query += queryTvTable;

                var queryRssKeywords = "";
                if (!string.IsNullOrWhiteSpace(keysIds))
                {
                    if (keysIds.EndsWith(","))
                    {
                        keysIds = keysIds.Substring(0, keysIds.Length - 1);

                    }
                    queryRssKeywords = " AND KeywordId IN (" + keysIds + ")";

                }
                query += queryRssKeywords;

                if (string.IsNullOrWhiteSpace(newsIds))
                {
                    query += " order by SortOrder,OrderItem";
                }
                else
                {
                    query += " order by SortOrder";

                }
                //query += " order by NewsDate desc,NewsId desc";
                query = query.Replace("{0}", "");
                //
                //query = query.Replace(" AND  Tbl_News.NewsId in (SELECT distinct(NewsId) from Tbl_Relation_NewsParminPanel WHERE ParminPanelId IN (14) ) ", "");



                SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
                _Cnn.Open();

                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = _Cnn;
                dtr.SelectCommand.CommandText = query;
                dtr.SelectCommand.CommandTimeout = 20000;

                dtr.Fill(dt);

                _Cnn.Close();



                return dt;
            }
            else
                return dt;

        }

        public DataTable GetAllSocialNewsDataTableByNewsIds(int PageCount, int PageIndex, List<int?> PanelIds, long? fromDate, string newsIds)
        {
            var panels = "";
            foreach (var str in PanelIds)
            {
                panels += str + ",";
            }

            panels = panels.Substring(0, panels.Length - 1);




            var query = @"select * from Tbl_SocialMediaPost WHERE SocialMediaPostID IN (" + newsIds + ")";



            //query = query.Replace("{0}", "");
            //query = query.Replace("{1}", " WHERE SocialMediaPostID IN (" + newsIds + ")");




            SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            _Cnn.Open();

            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = _Cnn;
            dtr.SelectCommand.CommandText = query;
            dtr.SelectCommand.CommandTimeout = 20000;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            _Cnn.Close();



            return dt;

        }
        public int GetNewsCount(string newsIds)
        {
            SqlConnection cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = "SELECT COUNT(*) FROM dbo.Tbl_News WHERE NewsID IN ({0})";
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{0}", newsIds);

            DataTable dt = new DataTable();
            dtr.Fill(dt);
            cnn.Close();
            return int.Parse(dt.Rows[0][0].ToString());

        }
        public int GetNewsCountBySiteType(string panelIds, long fromDateIndex, long toDateIndex, string siteType)
        {
            SqlConnection cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = "SELECT COUNT(*) FROM dbo.Tbl_News WHERE ParminId = {0} AND NewsDateIndex BETWEEN {1} and {2} and SiteID in (select SiteID from Tbl_Sites where SiteType={3})";
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{0}", panelIds);
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{1}", fromDateIndex.ToString());
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{2}", toDateIndex.ToString());
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{3}", siteType);

            DataTable dt = new DataTable();
            dtr.Fill(dt);
            cnn.Close();
            return int.Parse(dt.Rows[0][0].ToString());

        }
        public int GetNewsCountBySiteType(string siteType , string newsIds)
        {
            SqlConnection cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = "SELECT COUNT(*) FROM dbo.Tbl_News WHERE NewsID IN ({1}) AND  SiteID in (select SiteID from Tbl_Sites where SiteType={0})";
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{0}", siteType);
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{1}", newsIds);

            DataTable dt = new DataTable();
            dtr.Fill(dt);
            cnn.Close();
            return int.Parse(dt.Rows[0][0].ToString());

        }
        public int GetNewsCountBySiteType(string panelIds, string fromDate, string toDate)
        {
            SqlConnection cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = "select COUNT(*) from Tbl_News where ParminId= {0} AND NewsDateIndex between {1} and {2}  ";
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{0}", panelIds);
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{1}", fromDate);
            dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{2}", toDate);

            DataTable dt = new DataTable();
            dtr.Fill(dt);
            cnn.Close();
            return int.Parse(dt.Rows[0][0].ToString());

        }
        public int GetNewsCountBySiteTypeAndKeyword(string panelIds, string fromDate, string toDate, string siteType, string key)
        {
            try
            {
                var strCon = Class_Static.PersianAlpha(key);
                //  NewsTitle-NewsLead-NewsBody
                var strCon2 = Class_Static.ArabicAlpha(key);
                var queryKeyword = " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' ";

                SqlConnection cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
                cnn.Open();
                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = cnn;
                dtr.SelectCommand.CommandText = "select COUNT(*) from Tbl_News where  NewsID in (select NewsID from Tbl_Relation_NewsParminPanel where ParminPanelId={0}) and NewsDateIndex between {1} and {2} AND " + queryKeyword + "";

                dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{0}", panelIds);
                dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{1}", fromDate);
                dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{2}", toDate);
                if (siteType != "" && siteType != "0")
                {
                    dtr.SelectCommand.CommandText += "and SiteID in (select SiteID from Tbl_Sites where SiteType={3})";
                    dtr.SelectCommand.CommandText = dtr.SelectCommand.CommandText.Replace("{3}", siteType);
                }

                DataTable dt = new DataTable();
                dtr.Fill(dt);
                cnn.Close();
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }

        }
        public List<Tbl_News> GetAllNewsIds(List<int> NewsIds)
        {
            var query = from news in _db.Tbl_News
                        where NewsIds.Contains(news.NewsID)
                        select news;
            return query.ToList();

        }
        public DataTable GetAllNewsByIds(string NewsId)
        {
            if (NewsId.Substring(0, 1) == ",")
            {
                NewsId = NewsId.Substring(1, NewsId.Length - 2);
            }
            var query = @"select ROW_NUMBER()  OVER(ORDER BY NewsDateTimeIndex desc) AS RowNum,(select SiteTitle From Tbl_Sites where SiteId=tbl.SiteId)as SiteTitle,(select SiteType From Tbl_Sites where SiteId=tbl.SiteId) as SiteType, * from Tbl_News as Tbl where NewsId in (" + NewsId + ")";

            SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            _Cnn.Open();

            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = _Cnn;
            dtr.SelectCommand.CommandText = query;

            DataTable dt = new DataTable();
            dtr.Fill(dt);

            return dt;

        }
        public List<Tbl_RssKeywords> GetKeywords(string GroupName)
        {
            var query = (from r in _db.Tbl_RssKeywords
                         where r.GroupName == GroupName

                         select r).ToList();
            return query;
        }

        public Tbl_News GetNewsByIdNoHighlight(int NewsId, bool UpdateIsRead)
        {
            var query = (from r in _db.Tbl_News
                         where r.NewsID == NewsId

                         select r).FirstOrDefault();
            if (UpdateIsRead == true && query.IsRead == false)
            {
                if (query != null && (bool)HttpContext.Current.Session["IsAdmin"] == false)
                {
                    cls_panel.UpdateNewsCount(NewsId);
                }
            }

            return query;

        }
        public Tbl_News GetNewsById(int NewsId, bool UpdateIsRead)
        {
            var query = (from r in _db.Tbl_News
                         where r.NewsID == NewsId

                         select r).FirstOrDefault();
            if (UpdateIsRead == true && query.IsRead == false)
            {
                if (query != null && (bool)HttpContext.Current.Session["IsAdmin"] == false)
                {
                    cls_panel.UpdateNewsCount(NewsId);
                }
            }


            foreach (var highText in Class_Layer.UserHighlight())
            {
                try
                {
                    if (highText == "") continue;
                    string HighCon = highText.Replace('ی', 'ي');

                    query.NewsTitle = query.NewsTitle.Replace(" " + highText + " ", "<span class='highlight'> " + highText + " </span>");
                    query.NewsLead = query.NewsLead.Replace(highText + " ", "<span class='highlight'> " + highText + " </span>");
                    query.NewsBody = query.NewsBody.Replace(" " + highText, "<span class='highlight'> " + highText + " </span>");

                    query.NewsTitle = query.NewsTitle.Replace(" " + highText + " ", "<span class='highlight'> " + highText + "</span>");
                    query.NewsLead = query.NewsLead.Replace(highText + " ", "<span class='highlight'> " + highText + "</span>");
                    query.NewsBody = query.NewsBody.Replace(" " + highText, "<span class='highlight'> " + highText + "</span>");

                    query.NewsTitle = query.NewsTitle.Replace(" " + highText + " ", "<span class='highlight'> " + highText + " </span>");
                    query.NewsLead = query.NewsLead.Replace(highText + " ", "<span class='highlight'> " + highText + " </span>");
                    query.NewsBody = query.NewsBody.Replace(" " + highText, "<span class='highlight'> " + highText + " </span>");


                    query.NewsTitle = query.NewsTitle.Replace(highText, "<span class='highlight'> " + highText + " </span>");
                    query.NewsLead = query.NewsLead.Replace(highText, "<span class='highlight'> " + highText + " </span>");
                    query.NewsBody = query.NewsBody.Replace(highText, "<span class='highlight'> " + highText + " </span>");



                    ////////////////////////////
                    query.NewsTitle = query.NewsTitle.Replace(" " + HighCon + " ", "<span class='highlight'> " + HighCon + " </span>");
                    query.NewsLead = query.NewsLead.Replace(HighCon + " ", "<span class='highlight'> " + HighCon + " </span>");
                    query.NewsBody = query.NewsBody.Replace(" " + HighCon, "<span class='highlight'> " + HighCon + " </span>");

                    query.NewsTitle = query.NewsTitle.Replace(" " + HighCon + " ", "<span class='highlight'> " + HighCon + "</span>");
                    query.NewsLead = query.NewsLead.Replace(HighCon + " ", "<span class='highlight'> " + HighCon + "</span>");
                    query.NewsBody = query.NewsBody.Replace(" " + HighCon, "<span class='highlight'> " + HighCon + "</span>");

                    query.NewsTitle = query.NewsTitle.Replace(" " + HighCon + " ", "<span class='highlight'> " + HighCon + " </span>");
                    query.NewsLead = query.NewsLead.Replace(HighCon + " ", "<span class='highlight'> " + HighCon + " </span>");
                    query.NewsBody = query.NewsBody.Replace(" " + HighCon, "<span class='highlight'> " + HighCon + " </span>");


                    query.NewsTitle = query.NewsTitle.Replace(HighCon, "<span class='highlight'> " + HighCon + " </span>");
                    query.NewsLead = query.NewsLead.Replace(HighCon, "<span class='highlight'> " + HighCon + " </span>");
                    query.NewsBody = query.NewsBody.Replace(HighCon, "<span class='highlight'> " + HighCon + " </span>");

                }
                catch
                {
                    return query;
                }
            }

            return query;

        }
        public Tbl_News GetNewsById(int NewsId)
        {
            var query = (from r in _db.Tbl_News
                         where r.NewsID == NewsId
                         select r).FirstOrDefault();
            return query;

        }

        public List<Tbl_News> GetNewsByCategory(int catId, int count)
        {
            var query = (from t0 in _db.Tbl_News
                         join t in _db.Tbl_Relation_NewsParminPanel on new { NewsId = t0.NewsID } equals new { NewsId = t.NewsId.Value } into t_join
                         from t in t_join.DefaultIfEmpty()
                         join t1 in _db.Tbl_Parmin on new { ParminPanelId = t.ParminPanelId.Value } equals new { ParminPanelId = t1.ParminID } into t1_join
                         from t1 in t1_join.DefaultIfEmpty()
                         join t2 in _db.Tbl_ParminCategory on new { PanelCategory = t1.PanelCategory.Value } equals new { PanelCategory = t2.CatId } into t2_join
                         from t2 in t2_join.DefaultIfEmpty()
                         where
                           t1.PanelCategory == catId
                           && t0.IsJarayed == false
                         orderby t0.NewsID descending

                         select t0).Take(count);


            return query.ToList();

        }
        public int UpdateNewsOrder(int NewsID, int SortOrder)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsID",NewsID),
                new SqlParameter("@" + "SortOrder",SortOrder),
        };
            int newsid = PArtCore.Class.Class_Static.ExecuteNonQuery("", "p_News_NewsOrderUpdate", CommandType.StoredProcedure, sqlParams);
            return newsid;

        }
        public static string GetNewsSiteTitle(int NewsID)
        {
            string siteTitle = PArtCore.Class.Class_Static.ExecuteScalar("",
                "SELECT SiteTitle FROM dbo.Tbl_Sites WHERE SiteID IN (SELECT SiteID FROM dbo.Tbl_News WHERE NewsID=" + NewsID + ")", CommandType.Text, null);
            return siteTitle;

        }
        public static string GetNewsTitle(int NewsID)
        {
            string siteTitle = PArtCore.Class.Class_Static.ExecuteScalar("",
                "SELECT NewsTitle FROM dbo.Tbl_News WHERE NewsID=" + NewsID, CommandType.Text, null);
            return siteTitle;

        }
        public static DataSet GetTamarkozRasaneyiData(int NewsId)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsId",NewsId),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_News_TamarkozRasaneyi_GetNews", CommandType.StoredProcedure, sqlParams);
            return news;

        }
        public List<Tbl_News> GetLastBreaksImage(int PanelId)
        {
            var query = (from t in _db.Tbl_News
                         where
                             (from t0 in _db.Tbl_Relation_NewsParminPanel
                                  //where
                                  //t0.ParminPanelId == PanelId

                              select t0.NewsId).Contains(t.NewsID)

                                && t.NewsPicture != null
                                && t.NewsPicture != ""
                         orderby t.NewsDateIndex descending
                         select t).Take(5);

            return query.ToList();


        }
        public List<BreakImages> GetBreakImages(List<int?> PanelIds, int pageIndex, int pageCount)
        {
            IQueryable<BreakImages> query;

            query = (from t in _db.Tbl_News
                     join site in _db.Tbl_Sites on t.SiteID equals site.SiteID
                     where
                         (from t0 in _db.Tbl_Relation_NewsParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.NewsId).Contains(t.NewsID)
                          && site.SiteType == 2
                          && t.NewsPicture != null
                          && t.NewsPicture != ""
                     orderby t.NewsID descending
                     select new BreakImages
                     {
                         ImageId = t.NewsID,
                         SmallPath = t.NewsPicture,
                         LargePath = t.NewsPicture,
                         Title = t.NewsTitle,
                         NewsId = t.NewsID

                     }).Skip(pageIndex).Take(pageCount);

            return query.ToList();

        }
        public List<BreakImages> GetBreaks(List<int?> PanelIds, string Year)
        {
            IQueryable<BreakImages> query;

            query = (from t in _db.Tbl_News
                     join site in _db.Tbl_Sites on t.SiteID equals site.SiteID
                     where
                         (from t0 in _db.Tbl_Relation_NewsParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.NewsId).Contains(t.NewsID)
                          && t.IsJarayed == true
                          && t.NewsDate.Substring(0, 4) == Year

                     orderby t.NewsID descending
                     select new BreakImages
                     {
                         ImageId = t.NewsID,
                         SmallPath = t.NewsPicture,
                         LargePath = t.NewsPicture,
                         Title = t.NewsLead

                     });


            return query.ToList();

        }
        public List<string> GetDistrictBreaks(List<int?> PanelIds)
        {
            IQueryable<string> query;

            query = (from t in _db.Tbl_News
                     join site in _db.Tbl_Sites on t.SiteID equals site.SiteID
                     where
                         (from t0 in _db.Tbl_Relation_NewsParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.NewsId).Contains(t.NewsID)
                          && t.IsJarayed == true

                     select t.NewsDate.Substring(0, 4)).Distinct();


            return query.ToList();

        }
        public List<Tbl_News> GetMonitorinNews(List<int?> PanelIds, int LastNews)
        {

            IQueryable<Tbl_News> query;
            query = from news in _db.Tbl_News
                    join relation in _db.Tbl_Relation_NewsParminPanel
                    on news.NewsID equals relation.NewsId
                    where PanelIds.Contains(relation.ParminPanelId)
                    && news.NewsID > LastNews
                    && news.IsJarayed == false
                    orderby news.NewsID descending
                    select news;

            return query.ToList();

        }
        public long? UnreadNews(List<int?> PanelIds)
        {

            var query = (from panel in _db.Tbl_Parmin
                         where PanelIds.Contains(panel.ParminID)
                         select panel).FirstOrDefault();


            if (query.UnreadNews == null)
            {
                return query.NewsCount;
            }
            else
            {
                return query.NewsCount - query.UnreadNews;
            }


        }
        public bool DeleteNews(int NewsId)
        {
            try
            {
                var parmin = from news in _db.Tbl_Relation_NewsParminPanel
                             where news.NewsId == NewsId
                             select news;

                var relation = from news in _db.Tbl_Relation_NewsDistrict
                               where news.NewsID == NewsId
                               select news;

                var query = (from news in _db.Tbl_News
                             where news.NewsID == NewsId
                             select news).FirstOrDefault();

                var keywords = from key in _db.Tbl_KeywordEvents
                               where key.NewsId == NewsId
                               select key;

                var parmins = parmin.Select(i => i.ParminPanelId).Distinct();

                foreach (var item in parmins)
                {
                    var pp = (from r in _db.Tbl_Parmin
                              where r.ParminID == item
                              select r).FirstOrDefault();
                    if (pp.NewsCount != null)
                    {
                        pp.NewsCount--;
                    }

                    //_db.SaveChanges();
                }
                foreach (var item in parmin)
                {
                    _db.Tbl_Relation_NewsParminPanel.Remove(item);
                    //_db.SaveChanges();

                }

                foreach (var item in relation)
                {
                    _db.Tbl_Relation_NewsDistrict.Remove(item);
                    //_db.SaveChanges();
                }
                foreach (var item in keywords)
                {
                    _db.Tbl_KeywordEvents.Remove(item);
                }
                _db.Tbl_News.Remove(query);
                _db.SaveChanges();

                var currentUser = Class_Layer.CurrentUser();
                Class_Event ev = new Class_Event();
                ev.InsertEvent(3, currentUser.MemberID, NewsId, query.NewsTitle);


                return true;
            }
            catch
            {
                return false;
            }

        }
        public Tbl_News GetLastNewsTv(int? LastNewsId, List<int?> panels, long FromDate, long ToDate)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();

            var lastNews = (from news in db.Tbl_Relation_NewsParminPanel
                            where panels.Contains(news.ParminPanelId)
                            && news.NewsId > LastNewsId
                            orderby news.NewsId descending
                            select news).FirstOrDefault();
            if (lastNews == null) return null;
            var getNews = (from news in db.Tbl_News
                           where news.NewsID == lastNews.NewsId
                           select news).FirstOrDefault();

            return getNews;
        }
        public List<int> GetAnalyzWord(string word, string panels, long fromDate, long toDate, int SourceType)
        {
            try
            {
                SqlConnection _cnn = new SqlConnection();
                _cnn.ConnectionString = _db.Database.Connection.ConnectionString;
                _cnn.Open();


                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = _cnn;

                if (SourceType == 0)
                {
                    dtr.SelectCommand.CommandText = @"SELECT sum(LEN(newstitle) - LEN(REPLACE(newstitle, '" + word + "', '')))- LEN('" + word + "') as NewsTitle,sum(LEN(cast(newslead as varchar(max))) - LEN(REPLACE(cast(newslead as varchar(max)), '" + word + "', '')))- LEN('" + word + "') as NewsLead,sum(LEN(cast(newsbody as varchar(max))) - LEN(REPLACE(cast(newsbody as varchar(max)), '" + word + "', '')))- LEN('" + word + "') as NewsBody   from " +
                                            " (select newstitle,newslead,newsbody from tbl_news " +
                                            " where NewsID in(select NewsID from dbo.Tbl_Relation_NewsParminPanel " +
                                            " where ParminPanelId in (" + panels + ") and NewsDateIndex between " + fromDate + " and " + toDate + ")) as tbl";

                }
                else
                {
                    dtr.SelectCommand.CommandText = @"select count(*) from tbl_news where newsid in (select newsid from dbo.Tbl_Relation_NewsParminPanel where parminpanelid in (" + panels + ") and newsdateindex between " + fromDate + " and " + toDate + ") and cast(newstitle as varchar(max)) + ' ' + cast(newslead as varchar(max)) + ' ' + cast(NewsBody as varchar(max)) like '%" + word + "%'";

                }


                DataTable dt = new DataTable();
                dtr.Fill(dt);

                _cnn.Close();
                List<int> result = new List<int>();

                try
                {


                    if (dt.Rows[0][0].ToString() == "") dt.Rows[0][0] = "0";
                    if (dt.Rows[0][1].ToString() == "") dt.Rows[0][1] = "0";
                    if (dt.Rows[0][2].ToString() == "") dt.Rows[0][2] = "0";

                    if (dt.Rows[0][0].ToString().IndexOf("-") > -1) dt.Rows[0][0] = "0";
                    if (dt.Rows[0][1].ToString().IndexOf("-") > -1) dt.Rows[0][1] = "0";
                    if (dt.Rows[0][2].ToString().IndexOf("-") > -1) dt.Rows[0][2] = "0";
                }
                catch
                {

                }
                try
                {
                    result.Add(int.Parse(dt.Rows[0][0].ToString()));
                    result.Add(int.Parse(dt.Rows[0][1].ToString()));
                    result.Add(int.Parse(dt.Rows[0][2].ToString()));
                }
                catch
                {

                }

                return result;
            }
            catch
            {
                return null;
            }
        }


        public List<int> GetAnalyzWordSocial(string word, string panels, long fromDate, long toDate, int SourceType)
        {
            try
            {
                SqlConnection _cnn = new SqlConnection();
                _cnn.ConnectionString = _db.Database.Connection.ConnectionString;
                _cnn.Open();


                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = _cnn;

                if (SourceType == 0)
                {
                    dtr.SelectCommand.CommandText = @"SELECT sum(LEN(Text) - LEN(REPLACE(Text, '" + word + "', '')))- LEN('" + word + "') as NewsTitle  from " +
                                            " (select Text from Tbl_SocialMediaPost " +
                                            " inner join Tbl_SocialMediaKey on Tbl_SocialMediaPost.SocialMediaKeyID_FK=Tbl_SocialMediaKey.SocialMediaKeyID " +
                                            " where Tbl_SocialMediaKey.ParminID_FK in (" + panels + ") and Tbl_SocialMediaPost.PosteDateIndex between " + fromDate + " and " + toDate + ") as tbl";

                }
                else
                {
                    dtr.SelectCommand.CommandText = @"select count(*) from Tbl_SocialMediaPost (select Text from Tbl_SocialMediaPost inner join Tbl_SocialMediaKey on Tbl_SocialMediaPost.SocialMediaKeyID_FK=Tbl_SocialMediaKey.SocialMediaKeyID where Tbl_SocialMediaKey.ParminID_FK in (" + panels + ") and Tbl_SocialMediaPost.PosteDateIndex between " + fromDate + " and " + toDate + ") and cast(Text as varchar(max)) like '%" + word + "%'";

                }


                DataTable dt = new DataTable();
                dtr.Fill(dt);

                _cnn.Close();
                List<int> result = new List<int>();

                try
                {


                    if (dt.Rows[0][0].ToString() == "") dt.Rows[0][0] = "0";
                    //if (dt.Rows[0][1].ToString() == "") dt.Rows[0][1] = "0";
                    //if (dt.Rows[0][2].ToString() == "") dt.Rows[0][2] = "0";

                    if (dt.Rows[0][0].ToString().IndexOf("-") > -1) dt.Rows[0][0] = "0";
                    //if (dt.Rows[0][1].ToString().IndexOf("-") > -1) dt.Rows[0][1] = "0";
                    //if (dt.Rows[0][2].ToString().IndexOf("-") > -1) dt.Rows[0][2] = "0";
                }
                catch
                {

                }
                try
                {
                    result.Add(int.Parse(dt.Rows[0][0].ToString()));
                    //result.Add(int.Parse(dt.Rows[0][1].ToString()));
                    //result.Add(int.Parse(dt.Rows[0][2].ToString()));
                }
                catch
                {

                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public List<ChartValue> GetAnalyzUsersSocial(string panels, long fromDate, long toDate)
        {
            try
            {
                SqlConnection _cnn = new SqlConnection();
                _cnn.ConnectionString = _db.Database.Connection.ConnectionString;
                _cnn.Open();


                SqlDataAdapter dtr = new SqlDataAdapter();
                dtr.SelectCommand = new SqlCommand();
                dtr.SelectCommand.Connection = _cnn;


                string query = @"  select top 20 UserName,COUNT(UserName) as CCount from(select UserName from Tbl_SocialMediaPost inner join Tbl_SocialMediaKey on Tbl_SocialMediaPost.SocialMediaKeyID_FK = Tbl_SocialMediaKey.SocialMediaKeyID  where Tbl_SocialMediaKey.ParminID_FK in (" + panels + ") and Tbl_SocialMediaPost.PosteDateIndex between " + fromDate + " and " + toDate + ") as tbl  GROUP BY UserName order by COUNT(UserName) desc";


                DataTable dtResult = _clsAdo.FillDataTable(query);


                List<ChartValue> values = new List<ChartValue>();

                foreach (DataRow row in dtResult.Rows)
                {
                    values.Add(new ChartValue { Name = row["UserName"].ToString(), Value = int.Parse(row["CCount"].ToString()) });
                }


                //DataTable dt = new DataTable();
                ////dtr.Fill(dt);

                //_cnn.Close();
                //List<int> result = new List<int>();

                //try
                //{


                //    if (dt.Rows[0][0].ToString() == "") dt.Rows[0][0] = "0";
                //    //if (dt.Rows[0][1].ToString() == "") dt.Rows[0][1] = "0";
                //    //if (dt.Rows[0][2].ToString() == "") dt.Rows[0][2] = "0";

                //    if (dt.Rows[0][0].ToString().IndexOf("-") > -1) dt.Rows[0][0] = "0";
                //    //if (dt.Rows[0][1].ToString().IndexOf("-") > -1) dt.Rows[0][1] = "0";
                //    //if (dt.Rows[0][2].ToString().IndexOf("-") > -1) dt.Rows[0][2] = "0";
                //}
                //catch
                //{

                //}
                //try
                //{
                // result.Add(int.Parse(dtResult.Rows[0][0].ToString()));
                //    //result.Add(int.Parse(dt.Rows[0][1].ToString()));
                //    //result.Add(int.Parse(dt.Rows[0][2].ToString()));
                //}
                //catch
                //{

                //}

                return values;
            }
            catch
            {
                return null;
            }
        }


        public static void UpdateLastKeywords()
        {

        }
        public void UpdateNewsValue(int newsId, int value)
        {
            if (value == 0)
            {
                _db.Database.ExecuteSqlCommand("update tbl_news set NewsValue=null where NewsId=" + newsId);
            }
            else
            {
                _db.Database.ExecuteSqlCommand("update tbl_news set NewsValue=" + value + " where NewsId=" + newsId);
            }
        }

        public void UpdateNewsValue1(int newsId, int value)
        {
            if (value == 0)
            {
                _db.Database.ExecuteSqlCommand("update  Tbl_SocialMediaPost set NewsValue=null where SocialMediaPostID=" + newsId);
            }
            else
            {
                _db.Database.ExecuteSqlCommand("update Tbl_SocialMediaPost set NewsValue=" + value + " where SocialMediaPostID=" + newsId);
            }
        }



        public void UpdateNews(int newsId, string NewsTitle, string NewsLead, string NewsBody, string NewsDate,
            string NewsTime, string NewsLink, string NewsPicture, int NewsKeyId)
        {
            int newsDateIndex = Convert.ToInt32(NewsDate.Replace("/", ""));
            //UPDATE dbo.Tbl_News SET	 NewsTitle = @NewsTitle,NewsLead=@newsLead,NewsBody=@n,NewsDate=1,NewsTime=@qq,NewsPicture=a,KeywordId=@,NewsDateIndex=1 WHERE NewsID=1
            string cmd = "UPDATE dbo.Tbl_News SET NewsTitle=N'" + NewsTitle + "' ,NewsLead=N'" + NewsLead +
                "' , NewsBody=N'" + NewsBody + "' ,NewsDate='" + NewsDate + "' ,NewsTime='" + NewsTime + "' ,NewsLink=N'" +
                NewsLink + "' ,NewsPicture=N'" + NewsPicture + "' ,KeywordId =" + NewsKeyId + " ,NewsDateIndex=" +
                newsDateIndex + " where NewsId = " + newsId;
            _db.Database.ExecuteSqlCommand(cmd);

            string cmdLiveNews = "UPDATE dbo.Tbl_LiveNews SET NewsTitle=N'" + NewsTitle + "' ,NewsLead=N'" + NewsLead +
                "' , NewsBody=N'" + NewsBody + "' ,NewsDate='" + NewsDate + "' ,NewsTime='" + NewsTime + "' ,NewsLink=N'" +
                NewsLink + "' ,NewsPicture=N'" + NewsPicture + "' ,KeywordId =" + NewsKeyId + " ,NewsDateIndex=" +
                newsDateIndex + " where NewsId = " + newsId;
            _db.Database.ExecuteSqlCommand(cmdLiveNews);

        }
        public void InsertLog(int NewsId, string Comment)
        {

            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsId",NewsId) ,
                new SqlParameter("@" + "NewsBody",Comment) ,
        };
            Convert.ToInt32(Class_Ado.ExecuteNonQuery("", "p_Log_Update", CommandType.StoredProcedure, sqlParams));
        }
        public void UpdateNewsLog(int NewsId, string UserName, string IP, string UpdateDate, int ParminId)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsId",NewsId) ,
                new SqlParameter("@" + "UserName",UserName) ,
                new SqlParameter("@" + "IP",IP) ,
                new SqlParameter("@" + "UpdateDate",UpdateDate) ,
                new SqlParameter("@" + "ParminId",ParminId) ,
        };
            Convert.ToInt32(Class_Ado.ExecuteNonQuery("", "p_NewsLog_Update", CommandType.StoredProcedure, sqlParams));
        }
        public List<ChartValue> AnalyzNewsSource(List<int?> PanelIds, long fromDate, long toDate, int siteType)
        {
            var panels = "";
            foreach (var str in PanelIds)
            {
                panels += str + ",";
            }

            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();

            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;

            dtr.SelectCommand.CommandText = @"SELECT     tblResult.SiteID, tblResult.Count, Tbl_Sites.SiteTitle " +
                        " FROM         (SELECT     SiteID, COUNT(*) AS Count " +
                        " FROM         Tbl_News " +
                        " WHERE     (NewsID IN " +
                        " (SELECT     NewsId " +
                        " FROM         Tbl_Relation_NewsParminPanel " +
                        " WHERE     (ParminPanelId in(" + panels + ")) AND (NewsDateIndex BETWEEN " + fromDate + " AND " + toDate + "))) " +
                        " GROUP BY SiteID) AS tblResult LEFT OUTER JOIN " +
                        " Tbl_Sites ON tblResult.SiteID = Tbl_Sites.SiteID " +
                        " where Tbl_Sites.SiteType =" + siteType;

            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<ChartValue> values = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = row["SiteTitle"].ToString();
                newItem.Value = int.Parse(row["Count"].ToString());

                values.Add(newItem);
            }
            cnn.Close();
            return values;
        }
        public void SetTvAllow(string newsId, string value)
        {
            int nId = int.Parse(newsId);

            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var query = (from news in db.Tbl_News
                         where news.NewsID == nId
                         select news).FirstOrDefault();

            if (query == null) return;
            if (value == "0")
            {
                query.AllowTv = null;
            }
            else
            {
                query.AllowTv = false;
            }

            db.SaveChanges();
        }
        public void InsertNew(int? panelId, int siteId, string newsTime, string title, string lead, string body, string link, string picture, string newsDate, int keywordId)
        {
            var newItem = new Tbl_News();
            newItem.SiteID = siteId;
            newItem.NewsTime = newsTime;
            newItem.NewsTitle = title;
            newItem.NewsLead = lead;
            newItem.NewsBody = body;
            newItem.NewsLink = link;
            newItem.NewsPicture = picture;
            newItem.NewsDate = newsDate;
            newItem.NewsDateIndex = long.Parse(newsDate.Replace("/", ""));
            newItem.CreateDate = DateTime.Now;
            newItem.CreateUser = 29;
            newItem.Active = true;
            newItem.KeywordId = keywordId;
            _db.Tbl_News.Add(newItem);
            _db.SaveChanges();


            Tbl_Relation_NewsParminPanel newRelation = new Tbl_Relation_NewsParminPanel();
            newRelation.NewsId = newItem.NewsID;
            newRelation.ParminPanelId = panelId;
            newRelation.ParminNewsId = newItem.NewsID;
            newRelation.NewsDateIndex = long.Parse(newsDate.Replace("/", ""));

            _db.Tbl_Relation_NewsParminPanel.Add(newRelation);
            _db.SaveChanges();

        }

        public string GetUTF8String(string input)
        {
            var utf8 = new UTF8Encoding();
            var EncodedByte = utf8.GetBytes(input);
            string result = utf8.GetString(EncodedByte);

            return result;
        }


        public void InsertNew(int? panelId, int siteId, string newsTime, string title, string lead, string body,string link, string picture, string newsDate, int keywordId, byte newsTypeShow)
        {
            var Keyword = _db.Tbl_RssKeywords.Where(k => k.KeyId == keywordId).FirstOrDefault();

            var newItem = new Tbl_News();
            var LiveNewsItem = new Tbl_LiveNews();

            newItem.SiteID = siteId;
            newItem.NewsDate = newsDate;
            newItem.NewsTime = newsTime;
            newItem.NewsTitle = title;
            newItem.NewsLead = lead;
            newItem.NewsBody = body;
            newItem.NewsPicture = GetUTF8String(picture.Trim());
            newItem.CreateDate = DateTime.Now;
            newItem.EditDate = DateTime.Now;
            newItem.CreateUser = 29;
            newItem.NewsLink = HttpUtility.UrlDecode(HttpUtility.UrlEncode(link.Trim()));
            newItem.Active = true;
            newItem.NewsDateIndex = long.Parse(newsDate.Replace("/", ""));
            newItem.KeywordId = keywordId;
            newItem.NewsGroupOrder = Keyword.GroupOrder;
            newItem.GroupId = keywordId;
            newItem.NewsTypeShow = newsTypeShow;
            newItem.NewsDateTimeIndex = long.Parse(newsDate.Replace("/", "") + newsTime.Replace(":", ""));
            newItem.ParminId = panelId;

            if (!string.IsNullOrEmpty(newItem.NewsLink))
            {
                var crc = Math.Abs(link.Trim().GetHashCode());
                newItem.NewsLinkCRC = crc;
            }

            _db.Tbl_News.Add(newItem);


            LiveNewsItem.SiteID = siteId;
            LiveNewsItem.NewsDate = newsDate;
            LiveNewsItem.NewsTime = newsTime;
            LiveNewsItem.NewsTitle = title;
            LiveNewsItem.NewsLead = lead;
            LiveNewsItem.NewsBody = body;
            LiveNewsItem.NewsPicture = GetUTF8String(picture.Trim());
            LiveNewsItem.CreateDate = DateTime.Now;
            LiveNewsItem.EditDate = DateTime.Now;
            LiveNewsItem.CreateUser = 29;
            LiveNewsItem.NewsLink = HttpUtility.UrlDecode(HttpUtility.UrlEncode(link.Trim()));
            LiveNewsItem.Active = true;
            LiveNewsItem.NewsDateIndex = long.Parse(newsDate.Replace("/", ""));
            LiveNewsItem.KeywordId = keywordId;
            LiveNewsItem.NewsGroupOrder = Keyword.GroupOrder;
            LiveNewsItem.GroupId = keywordId;
            LiveNewsItem.NewsTypeShow = newsTypeShow;
            LiveNewsItem.NewsDateTimeIndex = long.Parse(newsDate.Replace("/", "") + newsTime.Replace(":", ""));
            LiveNewsItem.ParminId = panelId;

            if (!string.IsNullOrEmpty(newItem.NewsLink))
            {
                var crc = Math.Abs(link.Trim().GetHashCode());
                LiveNewsItem.NewsLinkCRC = crc;
            }

            _db.Tbl_LiveNews.Add(LiveNewsItem);


            _db.SaveChanges();


            var RelationItem = new Tbl_Relation_NewsParminPanel();
            RelationItem.Active = true;
            RelationItem.NewsId = newItem.NewsID;
            RelationItem.ParminPanelId = panelId;
            RelationItem.ParminNewsId = newItem.NewsID;
            RelationItem.NewsDateIndex = newItem.NewsDateIndex;
            RelationItem.KeywordId = keywordId;
            RelationItem.SiteId = siteId;
            RelationItem.CreateUser = 29;
            RelationItem.CreateDate = DateTime.Now;




            //Tbl_Relation_NewsParminPanel newRelation = new Tbl_Relation_NewsParminPanel();
            //newRelation.NewsId = newItem.NewsID;
            //newRelation.ParminPanelId = panelId;
            //newRelation.ParminNewsId = newItem.NewsID;
            //newRelation.NewsDateIndex = long.Parse(newsDate.Replace("/", ""));

            _db.Tbl_Relation_NewsParminPanel.Add(RelationItem);
            _db.SaveChanges();

        }
        public bool DeActiveNews(int NewsId)
        {
            DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

            try
            {
                var parmin = (from news in _db.Tbl_Relation_NewsParminPanel
                              where news.NewsId == NewsId
                              select news).FirstOrDefault();



                var query = (from news in _db.Tbl_News
                             where news.NewsID == NewsId
                             select news).FirstOrDefault();


                parmin.Active = false;
                query.Active = false;

                _db.SaveChanges();

                var currentUser = Class_Layer.CurrentUser();
                Class_Event ev = new Class_Event();
                ev.InsertEvent(3, currentUser.MemberID, NewsId, query.NewsTitle);


                return true;
            }
            catch
            {
                return false;
            }
        }
        public void InsertLog(string title, string value, string date)
        {
            string cmd = "INSERT INTO dbo.Tbl_Log_News ( NewsId ,NewsTitle , NewsLead , NewsBody , NewsDateTimeIndex,NewsLink ,NewsPicture ,UserName ,IP , UpdateDate ,ParminId )" +
              " VALUES ( 0 , '" + title + "' , '" + value + "' , N'' ,  ''  , ''  ,  N'' ,  N'' ,  N'' ,  '" + date + "' , 0  )";
            _db.Database.ExecuteSqlCommand(cmd);

        }

        public DataTable GetAllNewsDataTableByRelated(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead, bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search, int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable)
        {
            var panels = "";
            foreach (var str in PanelIds)
            {
                panels += str + ",";
            }

            panels = panels.Substring(0, panels.Length - 1);
            var query = @"select DISTINCT Tbl_News.NewsID, Tbl_News.SiteID, Tbl_News.NewsDate, Tbl_News.NewsTime, Tbl_News.NewsNumber, Tbl_News.NewsTitle, Tbl_News.NewsLead, Tbl_News.NewsLinkCRC,
                         Tbl_News.NewsBody, Tbl_News.NewsPicture, Tbl_News.NewsType, Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink, Tbl_News.KeyIds,
                         Tbl_News.NewsPosition,ISNULL(NewsTypeShow,1) AS NewsTypeShow, Tbl_News.pageIndex, Tbl_News.NewsDateIndex, Tbl_News.NewsEnum, Tbl_News.IsRelate, Tbl_News.RelateList, Tbl_News.IsRead,Tbl_News.NewsGroupOrder, 
                         Tbl_News.NewsValue, Tbl_News.IsJarayed, Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_Sites.SiteType, Tbl_News.AllowTv, Tbl_News.IsFeederNews,Tbl_RssKeywords.GroupName ,Tbl_RssKeywords.KeywordName,Tbl_NewsGroup.GroupName as gpNewsGroup,Tbl_News.GroupId,Tbl_News.KeywordId,Tbl_RssKeywords.Color,Tbl_RssKeywords.GroupOrder,Tbl_News.IsSelected,Tbl_RssKeywords.OrderItem,Tbl_News.SortOrder,[dbo].[f_News_GetRelated_forAllTime] (Tbl_News.NewsID) AS RelatedNewsStringIds
                         FROM         Tbl_News  INNER JOIN	 dbo.Tbl_NewsRelate ON Tbl_NewsRelate.NewsId = Tbl_News.NewsID  
                         LEFT OUTER JOIN Tbl_RssKeywords ON Tbl_News.KeywordId = Tbl_RssKeywords.KeyId LEFT OUTER JOIN
                         Tbl_NewsGroup ON Tbl_News.GroupId = Tbl_NewsGroup.GroupId LEFT OUTER JOIN
                         Tbl_Sites ON Tbl_News.SiteID = Tbl_Sites.SiteID

        WHERE Tbl_Sites.SiteType IN (0,1,2,3) AND Tbl_RssKeywords.Active=1 AND  Tbl_News.ParminId  = " + panels + " {0} {1}";

            if (PanelIds.Count == 1)
            {
                query += " and Tbl_News.Active=1 ";
            }
            if (newsIds == "")
            {


                if (isRead != null)
                {
                    if (isRead == false)
                    {
                        query += " and Tbl_News.isRead = 0";

                    }
                    else if (isRead == true)
                    {
                        query += " and Tbl_News.isRead = 1";
                    }
                }

                if (fromDate != null && toDate != null)
                {
                    string a = _clsZm.Today();
                    string b = _clsZm.AddDay(a, 1);
                    string c = _clsZm.AddDay(a, -1);
                    int yesterday = int.Parse(c.Split(' ')[0].Replace("/", ""));
                    query = query.Replace("{0}", "and (Tbl_Relation_NewsParminPanel.NewsDateIndex between " + fromDate + " and " + toDate + " OR ( Tbl_Relation_NewsParminPanel.NewsDateIndex = " + yesterday + " AND Tbl_News.NewsTime > '21:00' AND Tbl_Sites.SiteType = 2) )");
                    //    query = query.Replace("{0}", "and NewsDate between '" + Class_Static.ShamisiBySlash(fromDate + "") + "' and '" + Class_Static.ShamisiBySlash(toDate + "") + "'");
                }
                else
                {
                    query = query.Replace("{0}", "");
                }


                if (AllowTv != null)
                {
                    query += " and (Tbl_News.AllowTv is null or Tbl_News.AllowTv=1)";
                }

                if (siteType != null)
                {
                    if (siteType == -1)
                    {

                        //query = query.Where(p => p.Tbl_Sites.SiteType == 2);
                        query += " and Tbl_Sites.SiteType =1";

                    }
                    else if (siteType == -2)
                    {
                        //query = query.Where(p => p.Tbl_Sites.SiteType == 1);
                        query += " and Tbl_Sites.SiteType =2";
                    }
                    else if (siteType != 0)
                    {
                        //query = query.Where(p => p.Tbl_Sites.SiteID == siteType);
                        query += " and Tbl_Sites.SiteId =" + siteType;
                    }
                }

                if (newsTimeFrom != "00:00" || newsTimeTo != "00:00")
                {
                    if (newsTimeFrom != "" && newsTimeTo != "")
                    {
                        query += " and cast(replace(newstime,':','') as int) between '" + newsTimeTo.Replace(":", "") + "' and '" + newsTimeFrom.Replace(":", "") + "'";
                    }
                }
                query = query.Replace("{1}", "");

                //if (fromTimeZone != "" && toTimeZone != "")
                //{
                //    query += " and CONVERT(VARCHAR(5), Tbl_News.CreateDate, 108) >= '" + fromTimeZone + "' and CONVERT(VARCHAR(5), Tbl_News.CreateDate, 108) <= '" + toTimeZone + "' ";
                //}
            }
            else
            {
                query = query.Replace("{0}", "");
                query = query.Replace("{1}", " and Tbl_News.NewsId in (" + newsIds + ")");
            }

            if (string.IsNullOrWhiteSpace(newsIds))
            {
                if (PageIndex != -1 && PageCount != -1)
                {
                    // query += " where rownum between " + PageIndex + " and " + (PageIndex + PageCount);
                }
            }
            else
            {
                //   query += " where rownum >0 ";

            }

            if (Search != "")
            {
                var strSearch = Search.Split('-');
                var strSearchOr = Search.Split('|');
                if (strSearchOr.Count() > 1)
                {
                    query += " and (";
                    foreach (string param in strSearchOr)
                    {

                        if (!query.EndsWith("and ("))
                        {
                            query += " OR (";
                        }



                        var strCon = Class_Static.PersianAlpha(param);
                        //  NewsTitle-NewsLead-NewsBody
                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }
                }
                else
                {
                    query += " and (";
                    foreach (string param in strSearch)
                    {
                        if (!query.EndsWith("and ("))
                        {
                            query += " and (";
                        }

                        var strCon = Class_Static.PersianAlpha(param);
                        //  NewsTitle-NewsLead-NewsBody
                        var strCon2 = Class_Static.ArabicAlpha(param);
                        query += " NewsTitle LIKE N'%" + strCon + "%' OR  NewsTitle LIKE N'%" + strCon2 + "%' OR NewsLead LIKE N'%" + strCon + "%' OR  NewsLead LIKE N'%" + strCon2 + "%'  OR NewsBody LIKE N'%" + strCon + "%' OR  NewsBody LIKE N'%" + strCon2 + "%' OR NewsBody LIKE '%" + strCon + "%' OR  NewsBody LIKE '%" + strCon2 + "%' OR ";

                        query = query.Substring(0, query.Length - 4);
                        query += ")";
                    }

                }




            }
            var queryTvTable = "";
            if (isFromTvTable)
            {
                queryTvTable = " AND NewsID IN ( SELECT NewsID FROM Tbl_TvNews)";
            }
            query += queryTvTable;

            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(keysIds))
            {
                if (keysIds.EndsWith(","))
                {
                    keysIds = keysIds.Substring(0, keysIds.Length - 1);

                }
                queryRssKeywords = " AND KeywordId IN (" + keysIds + ")";

            }
            query += queryRssKeywords;

            if (string.IsNullOrWhiteSpace(newsIds))
            {
                query += " order by SortOrder,OrderItem";
            }
            else
            {
                query += " order by SortOrder";

            }
            //query += " order by NewsDate desc,NewsId desc";
            query = query.Replace("{0}", "");
            //
            //query = query.Replace(" AND  Tbl_News.NewsId in (SELECT distinct(NewsId) from Tbl_Relation_NewsParminPanel WHERE ParminPanelId IN (14) ) ", "");



            SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            _Cnn.Open();

            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = _Cnn;
            dtr.SelectCommand.CommandText = query;
            dtr.SelectCommand.CommandTimeout = 20000;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            _Cnn.Close();



            return dt;

        }
        public DataSet GetAllNewsDataTableByRelatedProcedure(int PageCount, int PageIndex, List<int?> PanelIds, bool? isRead, bool highlight, List<string> highlightText, long? fromDate, long? toDate, string Search, int? siteType, bool? AllowTv, string newsTimeFrom, string newsTimeTo, string newsIds, string keysIds, bool isFromTvTable)
        {
            var panels = "";
            foreach (var str in PanelIds)
            {
                panels += str + ",";
            }

            panels = panels.Substring(0, panels.Length - 1);
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsIds",newsIds),
                new SqlParameter("@" + "ParminId",panels)
        };
            DataSet ds = Class_Ado.ExecuteDataset(_db.Database.Connection.ConnectionString, "p_News_GetBultanNews_Alldata", CommandType.StoredProcedure, sqlParams);
            return ds;
        }
    }



}