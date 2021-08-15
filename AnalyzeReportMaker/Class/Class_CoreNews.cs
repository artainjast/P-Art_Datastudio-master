using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AnalyzeReportMaker.Class
{
    public class Class_CoreNews
    {
        Class_Ado _clsAdo = new Class_Ado();

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
            var query = @"select * from (SELECT     ROW_NUMBER() OVER(ORDER BY Tbl_News.NewsId desc) AS RowNum,COUNT(*) OVER() AS TotalRows,Tbl_News.NewsID, Tbl_News.SiteID, Tbl_News.NewsDate,
                        Tbl_News.NewsTime, Tbl_News.NewsTitle, Tbl_News.NewsLead,  Tbl_News.NewsBody, Tbl_News.NewsPicture,
                        Tbl_News.CreateDate, Tbl_News.CreateUser, Tbl_News.ViewCount, Tbl_News.NewsLink,Tbl_News.NewsDateIndex, 
                        Tbl_Sites.Logo, Tbl_Sites.SiteTitle,Tbl_News.KeywordId,Tbl_News.NewsTitleCRC,Tbl_News.NewsLinkCRC,
                            Tbl_Sites.SiteType
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

            if (newsType != null)
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
 
    }
}
