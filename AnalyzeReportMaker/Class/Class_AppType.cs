using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AnalyzeReportMaker.Class
{
    public enum SqlOperation_Type
    {
        SELECT,
        UPDATE,
        DELETE,
        INSERT
    }

    public class ColumnData_Type
    {

        public string ColumnName { get; set; }
        public string ParamName { get; set; }
        public SqlDbType ColumnType { get; set; }
        public object ColumnValue { get; set; }

        public bool IsWhereParam { get; set; }
        public ColumnData_Type()
        {
            IsWhereParam = false;
        }
    }
    public class Tbl_News_Type
    {
        public int RowNum { get; set; }
        public int TotalRows { get; set; }
        public int NewsID { get; set; }
        public int SiteID { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public string NewsNumber { get; set; }
        public string NewsTitle { get; set; }
        public string NewsLead { get; set; }
        public string NewsBody { get; set; }
        public string NewsPicture { get; set; }
        public int NewsType { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public int ViewCount { get; set; }
        public string NewsLink { get; set; }
        public int NewsPosition { get; set; }
        public int pageIndex { get; set; }
        public long NewsDateIndex { get; set; }
        public int NewsEnum { get; set; }
        public bool IsRelate { get; set; }
        public string RelateList { get; set; }
        public bool IsRead { get; set; }
        public int Rate { get; set; }
        public bool IsJarayed { get; set; }
        public string Logo { get; set; }
        public string SiteTitle { get; set; }
        public int SiteType { get; set; }
        public int KeywordId { get; set; }

        public long NewsTitleCRC { get; set; }
        public long NewsLinkCRC { get; set; }
        public int NewsRate { get; set; }

        public List<int> RelateListIds { get; set; }
    }
    public class Tbl_RssKeywords_Type
    {
        public int KeyId { get; set; }
        public string KeywordName { get; set; }
        public string Mobiles { get; set; }
        public int OrderItem { get; set; }
        public string NotLike { get; set; }
        public int PanelId { get; set; }
        public bool Active { get; set; }
        public bool IsConfirmingKeyword { get; set; }


    }

    public class Tbl_Sites_Type
    {
        public int SiteID { get; set; }
        public string SiteTitle { get; set; }
        public string Logo { get; set; }
        public string SiteUrl { get; set; }
        public bool Active { get; set; }
        public bool IsPayesh { get; set; }

    }
}
