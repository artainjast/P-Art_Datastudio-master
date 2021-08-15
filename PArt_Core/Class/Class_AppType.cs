using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;

namespace PArtCore.Class
{
    public enum SqlOperation_Type
    {
        SELECT,
        UPDATE,
        DELETE,
        INSERT
    }
    public enum Social_Sorting
    {
        Date,
        User,
        Retweets,
        Key,
        Like,
        Comment,
        PostID
    }
    public enum SocialName_Type
    {
        Twitter = 1,
        Facebook = 2,
        Instagram = 3,
        GooglePlus = 4,
        Telegram = 5
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
    public class RESTReadTextParameters
    {
        public string Text { get; set; }

        public string Tag { get; set; }

        public int BeginningSilence { get; set; }
        public int EndingSilence { get; set; }

        public string Speaker { get; set; }
        public int PitchLevel { get; set; }
        public int PunctuationLevel { get; set; }
        public int SpeechSpeedLevel { get; set; }
        public int ToneLevel { get; set; }
        public int GainLevel { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string Format { get; set; }


        public static string FORMATS_RAW = "raw";

        public static string FORMATS_WAV_16K_MONO = "wav/16/m";
        public static string FORMATS_WAV_16K_MONO_ALAW = "wav/16/m/alaw";
        public static string FORMATS_WAV_16K_MONO_MULAW = "wav/16/m/mulaw";

        public static string FORMATS_WAV_8K_MONO = "wav/8/m";
        public static string FORMATS_WAV_8K_MONO_ALAW = "wav/8/m/alaw";
        public static string FORMATS_WAV_8K_MONO_MULAW = "wav/8/m/mulaw";

        public static string FORMATS_MP3_32K_MONO = "mp3/32/m";
    }
    public class Tbl_Setting_Type
    {



        public int ID { get; set; }

        public int LastRegged_NewsID { get; set; }

        public string NotRegNews_Ids { get; set; }

    }

    [Serializable]
    public class Tbl_SocialMediaPost_Type
    {
        public int SocialMediaPostID { get; set; }
        public bool Active { get; set; }
        public int SocialMediaKeyID_FK { get; set; }
        public int SocialMediaUserID_FK { get; set; }

        public string Text { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string PosteDateIndex { get; set; }
        public string PosteDateTimeIndex { get; set; }
        public int RetweetCount { get; set; }
        public string Lang { get; set; }
        public string LinkUrl { get; set; }
        public long LinkUrlCRC { get; set; }
        public string User_UserCode { get; set; }
        public string User_UserName { get; set; }
        public string User_ScreenName { get; set; }
        public string User_PictureUrl { get; set; }
        public byte[] User_Picture { get; set; }
        //  public System.Drawing.Image User_Picture2 { get; set; }
        public string Key_Title { get; set; }
        public string TimeAgo { get; set; }
        public string TimeAgoShow { get; set; }
        public long SocialPostID { get; set; }

    }
    public class Tbl_NewsGroup_Type
    {
        public int GroupId { get; set; }
        public int ParminId { get; set; }
        public string GroupName { get; set; }
        public byte GroupType { get; set; }
        public int GroupOrder { get; set; }
        public string Color { get; set; }

        public DataSet GetSocialKeywordData(string PanelIds)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "PanelIds",PanelIds)
        };
            return Class_Static.ExecuteDataset("", "p_SocialPost_GetKeywords", CommandType.StoredProcedure, sqlParams);
        }
        public DataSet GetTelegramKeywordData(string PanelIds)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "PanelIds",PanelIds)
        };
            return Class_Static.ExecuteDataset("", "p_TelegramPost_GetKeywords", CommandType.StoredProcedure, sqlParams);
        }
        public static List<Tbl_NewsGroup_Type> GetFromDataRows(DataRow[] Rows)
        {
            List<Tbl_NewsGroup_Type> list = new List<Tbl_NewsGroup_Type>();
            foreach (DataRow r in Rows)
            {
                Tbl_NewsGroup_Type acc = new Tbl_NewsGroup_Type();
                acc.GroupId = Convert.ToInt32(r["GroupId"]);
                acc.ParminId = Convert.ToInt32(r["ParminId"]);
                acc.GroupName = r["GroupName"].ToString();
                acc.Color = r["Color"].ToString();
                try { acc.GroupType = Convert.ToByte(r["GroupType"]); } catch { acc.GroupType = 2; }
                try { acc.GroupOrder = Convert.ToInt32(r["GroupOrder"]); } catch { acc.GroupOrder = 0; }
                list.Add(acc);
            }
            return list;
        }
        public int Add(int GroupId, string GroupName, int ParminId, string Color, byte GroupType, int GroupOrder)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "GroupId",GroupId),
                new SqlParameter("@" + "GroupName",GroupName),
                new SqlParameter("@" + "ParminId",ParminId),
                new SqlParameter("@" + "Color",Color),
                new SqlParameter("@" + "GroupType",GroupType),
                new SqlParameter("@" + "GroupOrder",GroupOrder),
                new SqlParameter("@" + "Mode","insert")
        };
            return Class_Static.ExecuteNonQuery("", "p_NewsGroup_Update", CommandType.StoredProcedure, sqlParams);
        }
        public int Update(int GroupId, string GroupName, int ParminId, string Color, byte GroupType, int GroupOrder)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "GroupId",GroupId),
                new SqlParameter("@" + "GroupName",GroupName),
                new SqlParameter("@" + "ParminId",ParminId),
                new SqlParameter("@" + "Color",Color),
                new SqlParameter("@" + "GroupType",GroupType),
                new SqlParameter("@" + "GroupOrder",GroupOrder),
                new SqlParameter("@" + "Mode","edit")
        };
            return Class_Static.ExecuteNonQuery("", "p_NewsGroup_Update", CommandType.StoredProcedure, sqlParams);
        }

    }
    public class Tbl_TelegramMediaKey_Type
    {
        public int TelegramKeyId { get; set; }
        public int ParminID_FK { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string NotLike { get; set; }
        public int GroupId_FK { get; set; }

        public static List<Tbl_TelegramMediaKey_Type> GetFromDataRows(DataRow[] Rows)
        {
            List<Tbl_TelegramMediaKey_Type> list = new List<Tbl_TelegramMediaKey_Type>();
            foreach (DataRow r in Rows)
            {
                Tbl_TelegramMediaKey_Type acc = new Tbl_TelegramMediaKey_Type();
                acc.TelegramKeyId = Convert.ToInt32(r["TelegramKeyId"]);
                acc.ParminID_FK = Convert.ToInt32(r["ParminID_FK"]);
                acc.Title = r["Title"].ToString();
                acc.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                acc.CreateDate = Convert.ToDateTime(r["CreateDate"]);
                acc.Active = Convert.ToBoolean(r["Active"]);
                try { acc.GroupId_FK = Convert.ToInt32(r["GroupId_FK"]); } catch { acc.GroupId_FK = 0; }
                try { acc.NotLike = r["NotLike"].ToString(); } catch { acc.NotLike = ""; }
                list.Add(acc);
            }
            return list;
        }

        public int Add(int TelegramKeyId, int ParminID_FK, string Title, int OrderNumber, DateTime CreateDate,
            bool Active, int GroupId_FK, string NotLike)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "TelegramKeyId",TelegramKeyId),
                new SqlParameter("@" + "ParminID_FK",ParminID_FK),
                new SqlParameter("@" + "Title",Title),
                new SqlParameter("@" + "OrderNumber",OrderNumber),
                new SqlParameter("@" + "CreateDate",CreateDate),
                new SqlParameter("@" + "Active",Active),
                new SqlParameter("@" + "GroupId_FK",GroupId_FK),
                new SqlParameter("@" + "NotLike",NotLike),
                new SqlParameter("@" + "Mode","insert")
        };
            return Class_Static.ExecuteNonQuery("", "p_TelegramMediaKey_Update", CommandType.StoredProcedure, sqlParams);
        }
        public int Update(int TelegramKeyId, int ParminID_FK, string Title, int OrderNumber, DateTime CreateDate,
            bool Active, int GroupId_FK, string NotLike)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "TelegramKeyId",TelegramKeyId),
                new SqlParameter("@" + "ParminID_FK",ParminID_FK),
                new SqlParameter("@" + "Title",Title),
                new SqlParameter("@" + "OrderNumber",OrderNumber),
                new SqlParameter("@" + "CreateDate",CreateDate),
                new SqlParameter("@" + "Active",Active),
                new SqlParameter("@" + "GroupId_FK",GroupId_FK),
                new SqlParameter("@" + "NotLike",NotLike),
                new SqlParameter("@" + "Mode","edit")
        };
            return Class_Static.ExecuteNonQuery("", "p_TelegramMediaKey_Update", CommandType.StoredProcedure, sqlParams);
        }
    }
    public class Tbl_SocialMediaKey_Type
    {
        public int SocialMediaKeyID { get; set; }
        public int ParminID_FK { get; set; }
        public string Title { get; set; }

        public bool Active { get; set; }
        public int OrderNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public string NotLike { get; set; }
        public int GroupId_FK { get; set; }

        public static List<Tbl_SocialMediaKey_Type> GetFromDataRows(DataRow[] Rows)
        {
            List<Tbl_SocialMediaKey_Type> list = new List<Tbl_SocialMediaKey_Type>();
            foreach (DataRow r in Rows)
            {
                Tbl_SocialMediaKey_Type acc = new Tbl_SocialMediaKey_Type();
                acc.SocialMediaKeyID = Convert.ToInt32(r["SocialMediaKeyID"]);
                acc.ParminID_FK = Convert.ToInt32(r["ParminID_FK"]);
                acc.Title = r["Title"].ToString();
                acc.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                acc.CreateDate = Convert.ToDateTime(r["CreateDate"]);
                acc.Active = Convert.ToBoolean(r["Active"]);
                try { acc.GroupId_FK = Convert.ToInt32(r["GroupId_FK"]); } catch { acc.GroupId_FK = 0; }
                try { acc.NotLike = r["NotLike"].ToString(); } catch { acc.NotLike = ""; }
                list.Add(acc);
            }
            return list;
        }

        public int Add(int SocialMediaKeyID, int ParminID_FK, string Title, int OrderNumber, DateTime CreateDate,
            bool Active, int GroupId_FK, string NotLike)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "SocialMediaKeyID",SocialMediaKeyID),
                new SqlParameter("@" + "ParminID_FK",ParminID_FK),
                new SqlParameter("@" + "Title",Title),
                new SqlParameter("@" + "OrderNumber",OrderNumber),
                new SqlParameter("@" + "CreateDate",CreateDate),
                new SqlParameter("@" + "Active",Active),
                new SqlParameter("@" + "GroupId_FK",GroupId_FK),
                new SqlParameter("@" + "NotLike",NotLike),
                new SqlParameter("@" + "Mode","insert")
        };
            return Class_Static.ExecuteNonQuery("", "p_SocialMediaKey_Update", CommandType.StoredProcedure, sqlParams);
        }
        public int Update(int SocialMediaKeyID, int ParminID_FK, string Title, int OrderNumber, DateTime CreateDate,
            bool Active, int GroupId_FK, string NotLike)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "SocialMediaKeyID",SocialMediaKeyID),
                new SqlParameter("@" + "ParminID_FK",ParminID_FK),
                new SqlParameter("@" + "Title",Title),
                new SqlParameter("@" + "OrderNumber",OrderNumber),
                new SqlParameter("@" + "CreateDate",CreateDate),
                new SqlParameter("@" + "Active",Active),
                new SqlParameter("@" + "GroupId_FK",GroupId_FK),
                new SqlParameter("@" + "NotLike",NotLike),
                new SqlParameter("@" + "Mode","edit")
        };
            return Class_Static.ExecuteNonQuery("", "p_SocialMediaKey_Update", CommandType.StoredProcedure, sqlParams);
        }
    }

    public class Tbl_SocialMediaUser_Type
    {
        public int SocialMediaUserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string ScreenName { get; set; }
        public string Url { get; set; }
        public string PictureUrl { get; set; }
        public byte[] Picture { get; set; }
        public int RetweetsCount { get; set; }
        public string Location { get; set; }
        public int FriendsCount { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int FavouritesCount { get; set; }
        public int FollowersCount { get; set; }
        public string Language { get; set; }
        public bool Active { get; set; }

        public SocialName_Type SocialCodeEnum { get; set; }
        public int SocialCode { get; set; }
        public int PostCount { get; set; }
        //Twitter=1,
        //Facebook=2,
        //Instagram=3,
        //GooglePlus=4,
        //Telegram=5

    }

    public class Tbl_SocialMediaBultan_Type
    {
        public int SocialMediaBultanID { get; set; }
        public int ParminID_FK { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser_FK { get; set; }
        public string LastPDFPath { get; set; }
        public string LastWordPath { get; set; }

    }
    public class Tbl_SocialMediaBultanPost_Type
    {
        public int SocialMediaBultanPostID { get; set; }
        public int SocialMediaBultanID_FK { get; set; }
        public int SocialMediaPostID_FK { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser_FK { get; set; }

    }
    public class Tbl_SocialMediaMember_Type
    {
        public int SocialMediaMemberID { get; set; }
        public int ParminID_FK { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class Tbl_ParminSocialAccount_Type
    {
        public int AcountID { get; set; }
        public int ParminID { get; set; }
        public string Gmail { get; set; }
        public string GmailPassword { get; set; }
        public string OAuthConsumerKey { get; set; }
        public string OAuthConsumerAccessToken { get; set; }
        public string OAuthConsumerSecret { get; set; }
        public string OAuthConsumerAccessTokenSecret { get; set; }
        public bool Active { get; set; }

        public DataSet GetData()
        {
            return Class_Static.ExecuteDataset("", "p_ParminSocialAccount_Getdata", CommandType.StoredProcedure);
        }
        public static List<Tbl_ParminSocialAccount_Type> GetFromDataRows(DataRow[] Rows)
        {
            List<Tbl_ParminSocialAccount_Type> list = new List<Tbl_ParminSocialAccount_Type>();
            foreach (DataRow r in Rows)
            {
                Tbl_ParminSocialAccount_Type acc = new Tbl_ParminSocialAccount_Type();
                acc.AcountID = Convert.ToInt32(r["AcountID"]);
                acc.ParminID = Convert.ToInt32(r["ParminID"]);
                acc.Gmail = r["Gmail"].ToString();
                acc.GmailPassword = r["GmailPassword"].ToString();
                acc.OAuthConsumerKey = r["OAuthConsumerKey"].ToString();
                acc.OAuthConsumerSecret = r["OAuthConsumerSecret"].ToString();
                acc.OAuthConsumerAccessToken = r["OAuthConsumerAccessToken"].ToString();
                acc.OAuthConsumerAccessTokenSecret = r["OAuthConsumerAccessTokenSecret"].ToString();
                acc.Active = Convert.ToBoolean(r["Active"]);
                list.Add(acc);
            }
            return list;
        }

    }

}