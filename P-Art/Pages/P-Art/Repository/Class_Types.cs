using PArt.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PArt.Pages.P_Art.Repository
{
    public class BreakImages
    {
        public int ImageId { get; set; }
        public string SmallPath { get; set; }
        public string LargePath { get; set; }
        public string Title { get; set; }
        public int NewsId { get; set; }

    }
    public class NewsSelectClass
    {
        public int NewsID { get; set; }
        public int NewsOrder { get; set; }
        public bool NewsChecked { get; set; }
        public int NewsOrientation { get; set; }
        public int NewsMasterTagID { get; set; }


        public string NewsMasterTagTitle { get; set; }
    }

    public class NamayandehPanels
    {
        public int PanelId { get; set; }
        public string PanelName { get; set; }
        public string ImagePath { get; set; }
        public string City { get; set; }
        public string District { get; set; }

    }

    public class ChartValue
    {
        public string Name { get; set; }
        public long Value { get; set; }

    }
    public class Media_Keywords_Serie
    {
        public string SerieName { get; set; }
        public Media_Keywords_Value Values { get; set; }
    }
    public class Media_Keywords_Value
    {
        public long News { get; set; }
        public long Newspaper { get; set; }
        public long Telegram { get; set; }
        public long Twitter { get; set; }
        public long Instagram { get; set; }
    }
    public class Instagram_Serie
    {
        public string SerieName { get; set; }
        public Instagram_Value Values { get; set; }
    }
    public class Instagram_Value
    {
        public long Like { get; set; }
        public long Comment { get; set; }
        public long Video { get; set; }
        public long Picture { get; set; }
        public long Content { get; set; }
    }
    public class Telegram_Serie
    {
        public string SerieName { get; set; }
        public Telegram_Value Values { get; set; }
    }
    public class Telegram_Value
    {
        public long View { get; set; }
        public long Channel { get; set; }
        public long Video { get; set; }
        public long Picture { get; set; }
        public long Text { get; set; }
        public long All { get; set; }
    }
    public class Twitter_Serie
    {
        public string SerieName { get; set; }
        public Twitter_Value Values { get; set; }
    }
    public class Twitter_Value
    {
        public long Favorite { get; set; }
        public long Reply { get; set; }
        public long ReTwitte { get; set; }
        public long Picture { get; set; }
        public long Text { get; set; }
        public long All { get; set; }
    }
    public class RootJson_Chart
    {
        public List<string> Categories { get; set; }
        public List<Json_ChartSerie> SeiresName { get; set; }
    }
    public class Json_ChartData
    {
        public string Category { get; set; }
        public List<Json_ChartSerie> data { get; set; }

    }
    public class Json_ChartSerie
    {
        public string Name { get; set; }
        public List<Json_ChartSerieData> Values { get; set; }
    }
    public class Json_ChartSerieData
    {
        public long Value { get; set; }
    }


    public class ChartData
    {
        public string Name { get; set; }
        public List<ChartValue> data { get; set; }

    }
    public class ChartValue_New
    {

        public string name { get; set; }
        public List<object> color { get; set; }
        public List<object> data { get; set; }

    }
    public class ChartValue_NewData
    {

        public string name { get; set; }
        public List<object> data { get; set; }

    }
    public class DateListType
    {
        public int Year { get; set; }
        public int Month { get; set; }

    }
    public class ChartValueSolo_New
    {

        public object color { get; set; }

        public object data { get; set; }

        public string name { get; set; }
    }
    public class ChartChildSolo_New
    {
        public string name { get; set; }
        public string val1 { get; set; }
        public string val2 { get; set; }
        public int count { get; set; }
    }

    [Serializable]
    public partial class DomesticNews_Type
    {
        public int NewsID { get; set; }
        public Nullable<int> ParminId { get; set; }
        public int SiteID { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public string NewsTitle { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string NewsLink { get; set; }
        public Nullable<long> NewsDateIndex { get; set; }
        public Nullable<int> KeywordId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<long> NewsLinkCRC { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public Nullable<int> NewsType { get; set; }
        public Nullable<long> NewsTitleCRC { get; set; }
        public Nullable<bool> IsFeederNews { get; set; }
        public Nullable<int> NewsGroupOrder { get; set; }
        public string KeyIds { get; set; }
        public Nullable<byte> NewsTypeShow { get; set; }
        public Nullable<long> NewsDateTimeIndex { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public Nullable<byte> NewsValue { get; set; }
        public string SiteTitle { get; set; }
        public Nullable<int> SiteType { get; set; }
        public string KeywordName { get; set; }
        public string GroupName { get; set; }
        public string Color { get; set; }
        public Nullable<int> GroupOrder { get; set; }
        public Nullable<int> OrderItem { get; set; }
        public string NewsLead { get; set; }
        public string NewsPicture { get; set; }
        public string SiteLogo { get; set; }
        public int ViewCount { get; set; }

    }


    [Serializable]
    public partial class LiveNews_Type
    {
        public int NewsID { get; set; }
        public Nullable<int> ParminId { get; set; }
        public int SiteID { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public string NewsTitle { get; set; }
        public string NewsLead { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> KeywordId { get; set; }
        public Nullable<int> NewsType { get; set; }
        public string KeyIds { get; set; }
        public Nullable<byte> NewsTypeShow { get; set; }
        public Nullable<long> NewsDateTimeIndex { get; set; }
        public Nullable<byte> NewsValue { get; set; }
        public string SiteTitle { get; set; }
        public Nullable<int> SiteType { get; set; }
        public string KeywordName { get; set; }
        public string GroupName { get; set; }
        public string Color { get; set; }
        public Nullable<int> GroupOrder { get; set; }
        public Nullable<int> OrderItem { get; set; }
    }


    [Serializable]
    public partial class ForeignNews_Type
    {
        public int NewsID { get; set; }
        public Nullable<int> ParminId { get; set; }
        public int SiteID { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public string NewsTitle { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string NewsLink { get; set; }
        public Nullable<long> NewsDateIndex { get; set; }
        public Nullable<int> KeywordId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<long> NewsLinkCRC { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public Nullable<int> NewsType { get; set; }
        public Nullable<long> NewsTitleCRC { get; set; }
        public Nullable<bool> IsFeederNews { get; set; }
        public Nullable<int> NewsGroupOrder { get; set; }
        public string KeyIds { get; set; }
        public Nullable<byte> NewsTypeShow { get; set; }
        public Nullable<long> NewsDateTimeIndex { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public Nullable<byte> NewsValue { get; set; }
        public string SiteTitle { get; set; }
        public Nullable<int> SiteType { get; set; }
        public string KeywordName { get; set; }
        public string GroupName { get; set; }
        public string Color { get; set; }
        public Nullable<int> GroupOrder { get; set; }
        public Nullable<int> OrderItem { get; set; }
    }

    [Serializable]
    public class Tbl_NewsNewMedia_Type
    {

        public long NewsId { get; set; }
        public int SiteId { get; set; }
        public string NewsTitle { get; set; }
        public long NewsCreateDateTimeIndex { get; set; }
        public long NewsDateTimeIndex { get; set; }
        public string NewsLead { get; set; }
        public string NewsBody { get; set; }
        public string NewsPicture { get; set; }
        public string NewsOrginalLink { get; set; }
        public long NewsLinkCrc { get; set; }
        public int GroupId { get; set; }
        public DateTime NewsCreateDateTime { get; set; }
        public int ViewCount { get; set; }
        public string SiteTitle { get; set; }
        public string SiteUrl { get; set; }
        public string GroupTitle { get; set; }
        public string NewsLink { get; set; }
        public string SiteLogo { get; set; }
        public int NewsBultanPriority { get; set; }

        public static List<Tbl_NewsNewMedia_Type> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_NewsNewMedia_Type> list = new List<Tbl_NewsNewMedia_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_NewsNewMedia_Type acc = new Tbl_NewsNewMedia_Type();
                acc.NewsId = Convert.ToInt64(dr["NewsId"]);
                acc.SiteId = Convert.ToInt32(dr["SiteId"]);
                acc.NewsCreateDateTimeIndex = Convert.ToInt64(dr["NewsCreateDateTimeIndex"]);
                acc.NewsDateTimeIndex = Convert.ToInt64(dr["NewsDateTimeIndex"]);
                acc.NewsTitle = dr["NewsTitle"].ToString();
                acc.NewsLead = dr["NewsLead"].ToString();
                acc.NewsBody = dr["NewsBody"].ToString();
                acc.NewsPicture = dr["NewsPicture"].ToString();
                acc.NewsOrginalLink = dr["NewsOrginalLink"].ToString();
                acc.NewsLinkCrc = Convert.ToInt64(dr["NewsLinkCrc"]);
                acc.GroupId = Convert.ToInt32(dr["GroupId"]);
                acc.NewsCreateDateTime = Convert.ToDateTime(dr["NewsCreateDateTime"]);
                acc.ViewCount = Convert.ToInt32(dr["ViewCount"]);
                acc.SiteTitle = dr["SiteTitle"].ToString();
                acc.SiteUrl = dr["SiteUrl"].ToString();
                acc.GroupTitle = dr["GroupTitle"].ToString();
                list.Add(acc);
            }
            return list;
        }

    }
    [Serializable]
    public class Tbl_News_Type
    {
        public int? NewsGroupOrderTest { get; set; }
        public string KeyIds { get; set; }

        public int RowNum { get; set; }
        public int TotalRows { get; set; }
        public int NewsID { get; set; }
        public int SiteID { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public string NewsSiteLink { get; set; }
        public string NewsTitle { get; set; }
        public string NewsLead { get; set; }
        public string NewsBody { get; set; }
        public string NewsPicture { get; set; }
        public int UserIndexOrder { get; set; }
        public int CreateUser { get; set; }
        public long NewsDateIndex { get; set; }
        public string Logo { get; set; }
        public string SiteTitle { get; set; }
        public int SiteType { get; set; }
        public int KeywordId { get; set; }
        public int? GroupOrder { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string NewsLink { get; set; }
        public string NewsLink2 { get; set; }
        public long NewsLinkCRC { get; set; }
        public string Color { get; set; }
        public bool IsSelected { get; set; }
        public string NewsValue { get; set; }
        public bool IsFeederNews { get; set; }
        public string SortOrder { get; set; }
        public string CreateDate { get; set; }
        public List<int> RelateListIds { get; set; }
        public int RelateListIdsCount { get; set; }
        public string RelateListSites { get; set; }
        public List<string> RelateListStrings { get; set; }
        public string RelatedNewsStringIds { get; set; }
        public int? NewsGroupOrder { get; set; }
        public string SiteLogo { get; set; }
        public List<int> NewsKeyTags { get; set; }
        public List<int> NewsKeyGroups { get; set; }
        public int NewsKeyGroupsOrder { get; set; }
        public int NewsKeyTagsOrder { get; set; }
        public int KeywordID { get; set; }
        public int OrderItem { get; set; }
        public string KeywordName { get; set; }
        public byte NewsTypeShow { get; set; }
        public string RelatedString { get; set; }
        public int NewsBultanPriority { get; set; }
        public int ViewCount { get; set; }

        public class Tbl_Panel_Type
        {
            public int ParminID { get; set; }
            public string AgName { get; set; }
        }


        public static List<Tbl_News_Type> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_Type> list = new List<Tbl_News_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_Type acc = new Tbl_News_Type();
                acc.NewsLink = dr["NewsLink"].ToString();


                //"/ShowBultanNewsItem.aspx?newsId=" + dr["NewsID"];
                acc.SiteID = Convert.ToInt32(dr["SiteID"]);
                acc.NewsID = Convert.ToInt32(dr["NewsID"]);
                acc.GroupId = Convert.ToInt32(dr["GroupId"]);
                acc.KeywordID = Convert.ToInt32(dr["KeywordId"]);
                acc.NewsTitle = _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false);
                acc.NewsDate = dr["NewsDate"] + "";
                acc.NewsLead = _clsHtmlRemoval.NormalText(dr["NewsLead"] + "", false);
                acc.KeywordName = dr["KeywordName"] + "";
                acc.NewsBody = _clsHtmlRemoval.NormalText(dr["NewsBody"] + "", false);
                acc.SiteTitle = dr["SiteTitle"] + "";
                acc.NewsPicture = dr["NewsPicture"] + "";
                acc.GroupName = dr["GroupName"] + "";
                acc.CreateDate = (dr["CreateDate"] + "");
                acc.SiteType = Convert.ToInt32(dr["SiteType"]);
                acc.NewsTime = dr["NewsTime"] + "";
                acc.SiteLogo = dr["Logo"] + "";
                acc.GroupOrder = Class_Static.ToNullableInt(dr["GroupOrder"] + "");
                acc.NewsValue = (dr["NewsValue"] + "");
                acc.NewsGroupOrder = Class_Static.ToNullableInt(dr["NewsGroupOrder"] + "");
                try { acc.NewsTypeShow = Convert.ToByte(dr["NewsTypeShow"]); } catch { acc.NewsTypeShow = Convert.ToByte(0); }
                try { acc.RelatedString = dr["RelatedString"] + ""; } catch { acc.RelatedString = ""; }
                list.Add(acc);
            }
            return list;
        }

    }
    [Serializable]
    public class Tbl_NewsRelate_Type
    {
        public int RelateId { get; set; }
        public int NewsId { get; set; }
        public int RelateNewsId { get; set; }
        public static List<Tbl_NewsRelate_Type> GetFromDataRows(DataRow[] Rows)
        {
            List<Tbl_NewsRelate_Type> list = new List<Tbl_NewsRelate_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_NewsRelate_Type acc = new Tbl_NewsRelate_Type();
                acc.RelateId = Convert.ToInt32(dr["RelateId"]);
                acc.NewsId = Convert.ToInt32(dr["NewsId"]);
                acc.RelateNewsId = Convert.ToInt32(dr["RelateNewsId"]);
                list.Add(acc);
            }
            return list;
        }

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


    public class ExcelReport_Type
    {
        public string MediaTypeTitle { get; set; }
        public Nullable<int> MediaTypeCode { get; set; }
        public string MediaName { get; set; }
        public string SearchKeyTitle { get; set; }
        public string NewsTitle { get; set; }
        public string SugiriTitle { get; set; }
        public Nullable<int> SugiriCode { get; set; }
        public string Date { get; set; }
        public string NewsKeywordsTitle { get; set; }
        public string Url { get; set; }


    }


    public class SearchAllMedia_Type
    {
        public long id { get; set; }
        public string MediaType { get; set; }
        public long DateTimeIndex { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string MediaUrl { get; set; }
        public string Keywords { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
    }


    public class PagingNewsItem_Type
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int NewsType { get; set; }
        public int NewsValue { get; set; }
        public string KeyIds { get; set; }
        public string KeyTitles { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public string DateTimeString { get; set; }
        public string RelatedNews { get; set; }
        public int RelatedCount { get; set; }
        public int SiteType { get; set; }
        public string Url { get; set; }
        public string UrlDisplayControl { get; set; }
        public string BultanCheckBox { get; set; }
        public string SaveCheckBox { get; set; }
        public int MemberId { get; set; }
        public int ViewCount { get; set; }
        public string NewsLink { get; set; }
        public string SiteLogo { get; set; }
        public string NewsPicture { get; set; }
        public string NewsLead { get; set; }
        public DateTime CreateDate { get; set; }



    }

    public class PagingNewsList_Type
    {
        public List<PagingNewsItem_Type> NewsList { get; set; }
        public int TotalNewsCount { get; set; }
    }


    public class PagingGoogleApiNewsItem_Type
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string Snippet { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int KeyId { get; set; }
        public string KeyTitle { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public string DateTimeString { get; set; }
        public string Url { get; set; }
        public string UrlDisplayControl { get; set; }
        public string BultanCheckBox { get; set; }
        public string SaveCheckBox { get; set; }
        public int MemberId { get; set; }
        public string NewsImage { get; set; }
    }

    public class PagingGoogleApiNewsList_Type
    {
        public List<PagingGoogleApiNewsItem_Type> NewsList { get; set; }
        public int TotalNewsCount { get; set; }
    }

    public class PagingMediaItem_Type
    {
        public long MediaId { get; set; }
        public string MediaTitle { get; set; }
        public int MediaSourceId { get; set; }
        public string MediaSource { get; set; }
        public int MediaType { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public string DateTimeString { get; set; }
        public string MediaUrl { get; set; }
        public string UrlDisplayControl { get; set; }
        public string BultanCheckBox { get; set; }
        public string SaveCheckBox { get; set; }
        public int Priority { get; set; }


    }
    public class PagingMediaItemList_Type
    {
        public List<PagingMediaItem_Type> MediaList { get; set; }
        public int TotalMediaCount { get; set; }
    }
    public class PagingNewMediaNewsItem_Type
    {
        public long id { get; set; }
        public string Title { get; set; }
        public int SiteID { get; set; }
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        public string SiteName { get; set; }
        public int NewsType { get; set; }
        public int NewsValue { get; set; }
        public string KeyIds { get; set; }
        public string KeyTitles { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public string DateTimeString { get; set; }
        public string Url { get; set; }
        public string UrlDisplayControl { get; set; }
        public string BultanCheckBox { get; set; }
        public string SaveCheckBox { get; set; }
        public int ViewCount { get; set; }
        public int SiteType { get; set; }

    }
    public class PagingNewMediaNewsList_Type
    {
        public List<PagingNewMediaNewsItem_Type> NewsList { get; set; }
        public int TotalNewsCount { get; set; }
    }

    [Serializable]
    public class PagingNewsDetails_Type
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Body { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int NewsType { get; set; }
        public int NewsValue { get; set; }
        public string KeyIds { get; set; }
        public string KeyTitles { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public string DateTimeString { get; set; }
        public string RelatedNews { get; set; }
        public int SiteType { get; set; }

    }
    public class PagingRSSNewsList_Type
    {
        public List<PagingRssNewsDetails_Type> NewsList { get; set; }
        public int TotalNewsCount { get; set; }
    }

    [Serializable]
    public class PagingRssNewsDetails_Type
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Body { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int NewsType { get; set; }
        public int NewsValue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public string DateTimeString { get; set; }
        public int SiteType { get; set; }
        public string SourceLink { get; set; }


    }
    [Serializable]
    public class PagingNewMediaNewsDetails_Type
    {
        public long id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Body { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string KeyTitles { get; set; }
        public long DateTimeIndex { get; set; }
        public string DateTimeString { get; set; }

    }
    [Serializable]
    public class PagingNewsRelated_Type
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public string BultanCheckBox { get; set; }

    }




    public class PagingSearchAllMediaItem_Type
    {
        public long Id { get; set; }
        public int MediaTypeId { get; set; }
        public string MediaType { get; set; }
        public long DateTimeIndex { get; set; }
        public string Title { get; set; }
        public int SiteId { get; set; }
        public long ReferenceId { get; set; }
        public string ReferenceTitle { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string PanelUrl { get; set; }
        public string PanelUrlVisibility { get; set; }
        public string OrginalUrl { get; set; }
        public string OrginalUrlVisibility { get; set; }
        public string MediaPicture { get; set; }
    }


    public class PagingSearchAllMediaList_Type
    {
        public List<PagingSearchAllMediaItem_Type> ItemsList { get; set; }
        public int TotaItemsCount { get; set; }
    }


    [Serializable]
    public class PagingItemDetails_Type
    {
        public long Id { get; set; }
        public int MediaTypeId { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Body { get; set; }
        public int keywordId { get; set; }
        public string KeyIds { get; set; }
        public string KeyTitles { get; set; }

        public string MediaUrl { get; set; }
        public string MediaUrlVisibility { get; set; }
    }


    [Serializable]
    public class PagingAdvertiseItem_Type
    {
        public long AdvertiseId { get; set; }
        public string Title { get; set; }
        public string LastImageName { get; set; }
        public long FarsiDateTimeIndex { get; set; }
        public string FarsiDateString { get; set; }
        public string TimeString { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImageName { get; set; }
        public int CampainId { get; set; }
        public string CampainTitle { get; set; }
        public int StructureId { get; set; }
        public int StructureTypeId { get; set; }
        public string StructureTitle { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressTypeTitle { get; set; }
        public string Address { get; set; }

    }

    [Serializable]
    public class PagingAdvertiseList_Type
    {
        public List<PagingAdvertiseItem_Type> AdvertiseList { get; set; }
        public int TotalAdvertiseCount { get; set; }
    }



    [Serializable]
    public class PagingAdvertiseImageItem_Type
    {
        public long AdvertiseId { get; set; }
        public string Title { get; set; }
        public long ImageId { get; set; }
        public string ImageName { get; set; }
        public long FarsiDateTimeIndex { get; set; }
        public string FarsiDateString { get; set; }
        public string TimeString { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImageName { get; set; }
        public int CampainId { get; set; }
        public string CampainTitle { get; set; }
        public int StructureId { get; set; }
        public int StructureTypeId { get; set; }
        public string StructureTitle { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressTypeTitle { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }

    }

    [Serializable]
    public class PagingAdvertiseImageList_Type
    {
        public List<PagingAdvertiseImageItem_Type> AdvertiseImageList { get; set; }
        public int TotalAdvertiseImageCount { get; set; }
    }


    public class ShowImagesListItem_Type
    {
        public long ImageId { get; set; }
        public string ImageName { get; set; }
        public long FarsiDateTimeIndex { get; set; }
        public string FarsiDateString { get; set; }
        public string TimeString { get; set; }
        public int StatusId { get; set; }
    }

    public class LastImageOfAdvertise_Type
    {
        public long AdvertiseId { get; set; }
        public long ImageId { get; set; }
        public string ImageName { get; set; }
        public long FarsiDateTimeIndex { get; set; }
        public string FarsiDateString { get; set; }
        public string TimeString { get; set; }
        public int StatusId { get; set; }
    }


    public class AdvertiseItem_Type
    {
        public long AdvertiseId { get; set; }
        public string Title { get; set; }
        public long FarsiDateTimeIndex { get; set; }
        public string FarsiDateString { get; set; }
        public string TimeString { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImageName { get; set; }
        public int CampainId { get; set; }
        public string CampainTitle { get; set; }
        public int StructureId { get; set; }
        public int StructureTypeId { get; set; }
        public string StructureTitle { get; set; }
        public int Area { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressTypeTitle { get; set; }
        public string Address { get; set; }


        public List<ShowImagesListItem_Type> Images { get; set; }

    }

    public class BrandCombo_Type
    {
        public int BrandId { get; set; }
        public string Title { get; set; }
    }

    public class CampainCombo_Type
    {
        public int CampainId { get; set; }
        public string Title { get; set; }
    }

    public class StructuresDataCombo_Type
    {
        public int StructureId { get; set; }
        public string Title { get; set; }
    }

    public class StructureTypeCombo_Type
    {
        public int StructureTypeId { get; set; }
        public string Title { get; set; }
    }

    public class AddressTypeCombo_Type
    {
        public int AddressTypeId { get; set; }
        public string Title { get; set; }
    }

    public class ProvincesCombo_Type
    {
        public int ProvinceId { get; set; }
        public string Title { get; set; }
    }

    public class CitiesCombo_Type
    {
        public int CityId { get; set; }
        public string Title { get; set; }
    }

    public class Type_Rss
    {
        public string Title { get; set; }
        public string SiteTitle { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int SiteId { get; set; }
        public string date { get; set; }
        public long CRC { get; set; }
    }

    [Serializable]
    public class Tbl_Twitter_Type
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public int KeywordID { get; set; }
        public string UserName { get; set; }
        public long UserID { get; set; }
        public string UserScreenName { get; set; }
        public string UserProfileImageUrl { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int QuoteCount { get; set; }
        public int ReplyCount { get; set; }
        public int RetweetCount { get; set; }
        public int FavoriteCount { get; set; }
        public string Url { get; set; }
        public string MediaUrl { get; set; }
        public bool Active { get; set; }
        public int PanelID { get; set; }
        public string Keyword { get; set; }
        public int NewsValue { get; set; }
        public static List<Tbl_Twitter_Type> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Twitter_Type> list = new List<Tbl_Twitter_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Twitter_Type acc = new Tbl_Twitter_Type();
                acc.ID = Convert.ToInt64(dr["ID"]);
                acc.Text = dr["Text"].ToString();
                acc.KeywordID = Convert.ToInt32(dr["KeywordID"]);
                acc.UserName = dr["UserName"].ToString();
                acc.UserID = Convert.ToInt64(dr["UserID"]);
                acc.UserScreenName = dr["UserScreenName"].ToString();
                acc.UserProfileImageUrl = dr["UserProfileImageUrl"].ToString();
                acc.Date = dr["Date"].ToString();
                acc.Time = dr["Time"].ToString();
                acc.QuoteCount = Convert.ToInt32(dr["QuoteCount"]);
                acc.ReplyCount = Convert.ToInt32(dr["ReplyCount"]);
                acc.RetweetCount = Convert.ToInt32(dr["RetweetCount"]);
                acc.FavoriteCount = Convert.ToInt32(dr["FavoriteCount"]);
                acc.Url = dr["Url"].ToString();
                acc.MediaUrl = dr["MediaUrl"].ToString();
                acc.PanelID = Convert.ToInt32(dr["PanelID"]);
                acc.Active = Convert.ToBoolean(dr["Active"]);
                try { acc.Keyword = dr["Keyword"] + ""; } catch { acc.Keyword = ""; }
                try
                {
                    acc.NewsValue = Convert.ToInt32(dr["NewsValue"]);
                }
                catch { acc.NewsValue = 0; }
                list.Add(acc);
            }
            return list;
        }

    }
    [Serializable]
    public class Tbl_Telegram_Type
    {
        public long ID { get; set; }
        public int PostID { get; set; }
        public int KeywordID { get; set; }
        public int ChannelID { get; set; }
        public string MessageText { get; set; }
        public string MessageDate { get; set; }
        public string MessageTime { get; set; }
        public long DateTimeIndex { get; set; }
        public DateTime CreateDateTIme { get; set; }
        public int PanelID { get; set; }
        public int ViewCount { get; set; }
        public bool ShowStatus { get; set; }
        public int MediaType { get; set; }
        public long MediaID { get; set; }
        public string Keyword { get; set; }
        public string Channel { get; set; }
        public string Username { get; set; }
        public byte NewsValue { get; set; }
        public static List<Tbl_Telegram_Type> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Telegram_Type> list = new List<Tbl_Telegram_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Telegram_Type acc = new Tbl_Telegram_Type();
                acc.ID = Convert.ToInt64(dr["ID"]);
                acc.PostID = Convert.ToInt32(dr["PostID"]);
                acc.KeywordID = Convert.ToInt32(dr["KeywordID"]);
                acc.ChannelID = Convert.ToInt32(dr["ChannelID"]);
                acc.MessageText = dr["MessageText"].ToString();
                acc.MessageDate = dr["MessageDate"].ToString();
                acc.MessageTime = dr["MessageTime"].ToString();
                acc.DateTimeIndex = Convert.ToInt64(dr["DateTimeIndex"]);
                acc.CreateDateTIme = Convert.ToDateTime(dr["CreateDateTIme"]);
                acc.PanelID = Convert.ToInt32(dr["PanelID"]);
                acc.ViewCount = Convert.ToInt32(dr["ViewCount"]);
                try { acc.ShowStatus = Convert.ToBoolean(dr["ShowStatus"]); } catch { acc.ShowStatus = false; }
                acc.MediaType = Convert.ToInt32(dr["MediaType"]);
                acc.MediaID = Convert.ToInt64(dr["MediaID"]);
                try { acc.Keyword = dr["Title"] + ""; } catch { acc.Keyword = ""; }
                try { acc.Channel = dr["ChannelTitle"] + ""; } catch { acc.Channel = ""; }
                try { acc.Username = dr["Username"] + ""; } catch { acc.Username = ""; }
                try { acc.NewsValue = Convert.ToByte(dr["NewsValue"]); } catch { acc.NewsValue = 0; }
                list.Add(acc);
            }
            return list;
        }

    }
    [Serializable]
    public class Tbl_Instagram_Type
    {
        public long Id { get; set; }
        public long InstagramPostId { get; set; }
        public string TypeName { get; set; }
        public string ShortCode { get; set; }
        public string DisplayUrl { get; set; }
        public bool IsVideo { get; set; }
        public string CaptionText { get; set; }
        public int LikeCount { get; set; }
        public int CommentsCount { get; set; }
        public DateTime DateTime { get; set; }
        public long DateTimeIndex { get; set; }
        public DateTime ReadDateTime { get; set; }
        public string VideoUrl { get; set; }
        public int KeywordId { get; set; }
        public string PostUrl { get; set; }
        public long UserId { get; set; }
        public string ProfilePicUrl { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int PanelId { get; set; }
        public byte NewsValue { get; set; }
        public string Keyword { get; set; }

        public static List<Tbl_Instagram_Type> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Instagram_Type> list = new List<Tbl_Instagram_Type>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Instagram_Type acc = new Tbl_Instagram_Type();
                acc.Id = Convert.ToInt64(dr["Id"]);
                acc.InstagramPostId = Convert.ToInt64(dr["InstagramPostId"]);
                acc.IsVideo = Convert.ToBoolean(dr["IsVideo"]);
                acc.CaptionText = dr["CaptionText"].ToString();
                acc.TypeName = dr["TypeName"].ToString();
                acc.ShortCode = dr["ShortCode"].ToString();
                acc.DisplayUrl = dr["DisplayUrl"].ToString();
                acc.DateTimeIndex = Convert.ToInt64(dr["DateTimeIndex"]);
                acc.LikeCount = Convert.ToInt32(dr["LikeCount"]);
                acc.CommentsCount = Convert.ToInt32(dr["CommentsCount"]);
                acc.KeywordId = Convert.ToInt32(dr["KeywordId"]);
                try { acc.DateTime = Convert.ToDateTime(dr["DateTime"]); } catch { acc.DateTime = DateTime.Now; }
                acc.ReadDateTime = Convert.ToDateTime(dr["ReadDateTime"]);
                acc.UserId = Convert.ToInt64(dr["UserId"]);
                try { acc.VideoUrl = dr["VideoUrl"] + ""; } catch { acc.VideoUrl = ""; }
                try { acc.PostUrl = dr["PostUrl"] + ""; } catch { acc.PostUrl = ""; }
                try { acc.ProfilePicUrl = dr["ProfilePicUrl"] + ""; } catch { acc.ProfilePicUrl = ""; }
                try { acc.NewsValue = Convert.ToByte(dr["NewsValue"]); } catch { acc.NewsValue = 0; }
                acc.PanelId = Convert.ToInt32(dr["PanelId"]);
                try { acc.FullName = dr["FullName"] + ""; } catch { acc.FullName = ""; }
                try { acc.UserName = dr["UserName"] + ""; } catch { acc.UserName = ""; }
                try { acc.Keyword = dr["Keyword"] + ""; } catch { acc.Keyword = ""; }
                list.Add(acc);
            }
            return list;
        }

    }
    public class Campain_Type
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int BrandId { get; set; }
        public int PanelId { get; set; }
        public string Brandtitle { get; set; }
    }
    public class Campain_By_Brand
    {
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public List<Campain_Type> campains { get; set; }
        public List<Campain_Type> campainSubjects { get; set; }
    }
}