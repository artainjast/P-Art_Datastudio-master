using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_General_Type
    {
    }
    [Serializable]
    public class Tbl_News_General
    {
        public int NewsId { get; set; }
        public int SiteID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public long NewsDateTimeIndex { get; set; }
        public long NewsDateIndex { get; set; }
        public string NewsPicture { get; set; }
        public string NewsLink { get; set; }
        public int RelatedCount { get; set; }
        public string NewsTitleShort { get; set; }
        public string NewsLead { get; set; }
        public string NewsBody { get; set; }
        public string SiteTitle { get; set; }
        public string KeywordName { get; set; }
        public int KeywordId { get; set; }

        public static List<Tbl_News_General> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_General> list = new List<Tbl_News_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_General acc = new Tbl_News_General();

                acc.NewsId = Convert.ToInt32(dr["NewsId"]);
                acc.SiteID = Convert.ToInt32(dr["SiteID"]);
                acc.NewsLink = dr["NewsLink"].ToString();
                acc.NewsTitle = _clsHtmlRemoval.NormalText(dr["NewsTitle"] + "", false);
                acc.NewsTitleShort = Class_Static.ShortTxt(acc.NewsTitle, 100);
                acc.NewsDate = dr["NewsDate"] + "";
                acc.NewsPicture = dr["NewsPicture"] + "";
                acc.NewsTime = dr["NewsTime"] + "";
                try { acc.RelatedCount = Convert.ToInt32(dr["RelatedCount"]); } catch { acc.RelatedCount = 0; }
                try { acc.NewsLead = dr["NewsLead"].ToString(); } catch { acc.NewsLead = ""; }
                try { acc.NewsBody = dr["NewsBody"].ToString(); } catch { acc.NewsBody = ""; }
                try { acc.SiteTitle = dr["SiteTitle"].ToString(); } catch { acc.SiteTitle = ""; }
                try { acc.KeywordId = Convert.ToInt32(dr["KeywordId"]); } catch { acc.KeywordId = 0; }
                try { acc.KeywordName = dr["KeywordName"].ToString(); } catch { acc.KeywordName = ""; }
                list.Add(acc);
            }
            return list;
        }
        public static DataSet GetImportantMedia(int ParminID, long DateTimeIndexFrom, long DateTimeIndexTo, string Keyword)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "DateTimeIndexFrom",DateTimeIndexFrom),
                new SqlParameter("@" + "DateTimeIndexTo",DateTimeIndexTo),
                new SqlParameter("@" + "Keyword",Keyword),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_MediaAnalyze_ImportantTitle_Getdata", CommandType.StoredProcedure, sqlParams);
            return news;

        }
        public static DataSet GetHighNumberMedia(int ParminID, long DateTimeIndexFrom, long DateTimeIndexTo, string Keyword)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "DateTimeIndexFrom",DateTimeIndexFrom),
                new SqlParameter("@" + "DateTimeIndexTo",DateTimeIndexTo),
                new SqlParameter("@" + "Keyword",Keyword),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_MediaAnalyze_HighNumberMedia_Getdata", CommandType.StoredProcedure, sqlParams);
            return news;

        }

        public static DataSet GetSugiriNews(int ParminID, long DateTimeIndexFrom, long DateTimeIndexTo, string Keyword)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "DateTimeIndexFrom",DateTimeIndexFrom),
                new SqlParameter("@" + "DateTimeIndexTo",DateTimeIndexTo),
                 new SqlParameter("@" + "Keyword",Keyword),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_MediaAnalyze_Sugiri_Getdata", CommandType.StoredProcedure, sqlParams);
            return news;

        }
        public static DataSet GetImportantSugiriNews(int ParminID, long DateTimeIndexFrom, long DateTimeIndexTo, string Keyword)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "DateTimeIndexFrom",DateTimeIndexFrom),
                new SqlParameter("@" + "DateTimeIndexTo",DateTimeIndexTo),
                new SqlParameter("@" + "Keyword",Keyword),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_MediaAnalyze_Sugiri_Important_Getdata", CommandType.StoredProcedure, sqlParams);
            return news;

        }
        public static DataSet GetTableNews(int ParminID, long DateTimeIndexFrom, long DateTimeIndexTo, string Keyword)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "DateTimeIndexFrom",DateTimeIndexFrom),
                new SqlParameter("@" + "DateTimeIndexTo",DateTimeIndexTo),
                new SqlParameter("@" + "Keyword",Keyword),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_MediaAnalyze_AllNews_Getdata", CommandType.StoredProcedure, sqlParams);
            return news;

        }
        public static DataSet GetMediaShahed(int NewsId, string Type)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "NewsId",NewsId),
                new SqlParameter("@" + "Type",Type),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_MediaAnalyze_MediaShahed_Getdata", CommandType.StoredProcedure, sqlParams);
            return news;

        }
        public static DataSet GetMediaStatics(int ParminID, long DateTimeIndexFrom, long DateTimeIndexTo)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "DateIndexFrom",DateTimeIndexFrom),
                new SqlParameter("@" + "DateIndexTo",DateTimeIndexTo),
        };
            DataSet news = PArtCore.Class.Class_Static.ExecuteDataset("", "p_Media_Statics_Getdata", CommandType.StoredProcedure, sqlParams);
            return news;

        }
    }
    [Serializable]
    public class Tbl_Telegram_General
    {
        public long ID { get; set; }
        public int KeywordID { get; set; }
        public string MessageText { get; set; }
        public string MessageTextShort { get; set; }
        public string MessageDate { get; set; }
        public string MessageTime { get; set; }
        public long DateTimeIndex { get; set; }
        public DateTime CreateDateTIme { get; set; }
        public int PanelID { get; set; }
        public int ViewCount { get; set; }
        public string keywordTitle { get; set; }
        public string ChannelTitle { get; set; }
        public static List<Tbl_Telegram_General> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Telegram_General> list = new List<Tbl_Telegram_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Telegram_General acc = new Tbl_Telegram_General();

                acc.ID = Convert.ToInt64(dr["ID"]);
                acc.KeywordID = Convert.ToInt32(dr["KeywordID"]);
                acc.MessageText = dr["MessageText"].ToString();
                acc.MessageTextShort = Class_Static.ShortTxt(acc.MessageText, 100);
                acc.MessageDate = dr["MessageDate"].ToString();
                acc.MessageTime = dr["MessageTime"] + "";
                acc.DateTimeIndex = Convert.ToInt64(dr["DateTimeIndex"]);
                acc.CreateDateTIme = Convert.ToDateTime(dr["CreateDateTIme"]);
                acc.PanelID = Convert.ToInt32(dr["PanelID"]);
                acc.ViewCount = Convert.ToInt32(dr["ViewCount"]);
                try { acc.keywordTitle = dr["keywordTitle"].ToString(); } catch { acc.keywordTitle = ""; }
                try { acc.ChannelTitle   = dr["ChannelTitle"].ToString(); } catch { acc.ChannelTitle = ""; }
                list.Add(acc);
            }
            return list;
        }
        public static List<Tbl_Telegram_General> GetFromDataRowsShortText(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Telegram_General> list = new List<Tbl_Telegram_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Telegram_General acc = new Tbl_Telegram_General();

                acc.ID = Convert.ToInt64(dr["ID"]);
                acc.KeywordID = Convert.ToInt32(dr["KeywordID"]);
                acc.MessageText = dr["MessageText"].ToString();
                acc.MessageTextShort = Class_Static.ShortTxt(acc.MessageText, 180);
                acc.MessageText = acc.MessageTextShort;
                acc.MessageDate = dr["MessageDate"].ToString();
                acc.MessageTime = dr["MessageTime"] + "";
                acc.DateTimeIndex = Convert.ToInt64(dr["DateTimeIndex"]);
                acc.CreateDateTIme = Convert.ToDateTime(dr["CreateDateTIme"]);
                acc.PanelID = Convert.ToInt32(dr["PanelID"]);
                acc.ViewCount = Convert.ToInt32(dr["ViewCount"]);
                try { acc.keywordTitle = dr["keywordTitle"].ToString(); } catch { acc.keywordTitle = ""; }
                try { acc.ChannelTitle = dr["ChannelTitle"].ToString(); } catch { acc.ChannelTitle = ""; }
                list.Add(acc);
            }
            return list;
        }
    }
    [Serializable]
    public class Tbl_Twitter_General
    {
        public long ID { get; set; }
        public long TweetID { get; set; }
        public string Text { get; set; }
        public string TextShort { get; set; }
        public int KeywordID { get; set; }
        public string UserName { get; set; }
        public string UserScreenName { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long DateTimeIndex { get; set; }
        public int RetweetCount { get; set; }
        public string Url { get; set; }
        public string MediaUrl { get; set; }
        public string keywordTitle { get; set; }
        public int FavoriteCount { get; set; }
        public int ReplyCount { get; set; }
        public int QuoteCount { get; set; }
        public static List<Tbl_Twitter_General> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Twitter_General> list = new List<Tbl_Twitter_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Twitter_General acc = new Tbl_Twitter_General();

                acc.ID = Convert.ToInt64(dr["ID"]);
                acc.KeywordID = Convert.ToInt32(dr["KeywordID"]);
                acc.TweetID = Convert.ToInt64(dr["TweetID"]);
                acc.Text = dr["Text"].ToString();
                acc.TextShort = Class_Static.ShortTxt(acc.Text, 90);
                acc.UserName = dr["UserName"] + "";
                acc.UserScreenName = dr["UserScreenName"] + "";
                acc.DateTimeIndex = Convert.ToInt64(dr["DateTimeIndex"]);
                acc.PostDateTime = Convert.ToDateTime(dr["PostDateTime"]);
                acc.Date = dr["Date"] + "";
                acc.Time = dr["Time"] + "";
                acc.UserName = dr["UserName"] + "";
                acc.Url = dr["Url"].ToString();
                acc.MediaUrl = dr["MediaUrl"].ToString();
                acc.RetweetCount = Convert.ToInt32(dr["RetweetCount"]);
                try { acc.keywordTitle = dr["keywordTitle"].ToString(); } catch { acc.keywordTitle = ""; }
                try
                {
                    acc.FavoriteCount = Convert.ToInt32(dr["FavoriteCount"]);
                }
                catch { acc.FavoriteCount = 0; }
                try
                    {
                        acc.ReplyCount = Convert.ToInt32(dr["ReplyCount"]);
                }
                catch { acc.ReplyCount = 0; }
                try
                        {
                            acc.QuoteCount = Convert.ToInt32(dr["QuoteCount"]);
                }
                catch { acc.QuoteCount = 0; }
                list.Add(acc);
            }
            return list;
        }
    }
    [Serializable]
    public class AllMedia_General
    {
        public List<Tbl_News_General> NewspaperList;
        public List<Tbl_News_General> NewsList;
        public List<Tbl_Telegram_General> TelegramList;
        public List<Tbl_Twitter_General> TwitterList;
    }
    [Serializable]
    public class AllMedia_HighSource
    {
        public Tbl_Media_CountType AllMediaCount;
        public List<Tbl_Media_Type> NewsCountList;
        public List<Tbl_Media_Type> NewsPaperCountList;
        public List<Tbl_Media_Type> TelegramCountList;
        public List<Tbl_Media_Type> TwitterCountList;
        public List<ReportChartValue> MediaChartList;
    }
    [Serializable]
    public class Tbl_Media_CountType
    {
        public int NewsCount { get; set; }
        public int NewspaperCount { get; set; }
        public int TelegramCount { get; set; }
        public int TwitterCount { get; set; }
        public int AllMediaCount { get; set; }
        public int VideoCount { get; set; }
        public static Tbl_Media_CountType GetFromDataRow(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Media_CountType> list = new List<Tbl_Media_CountType>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Media_CountType acc = new Tbl_Media_CountType();
                acc.NewsCount = Convert.ToInt32(dr["NewsCount"]);
                acc.NewspaperCount = Convert.ToInt32(dr["NewspaperCount"]);
                acc.TelegramCount = Convert.ToInt32(dr["TelegramCount"]);
                acc.TwitterCount = Convert.ToInt32(dr["TwitterCount"]);
                acc.AllMediaCount = Convert.ToInt32(dr["AllMediaCount"]);
                try { acc.VideoCount = Convert.ToInt32(dr["VideoCount"]); } catch { acc.VideoCount = 0; }
                list.Add(acc);
            }
            return list.Count != 0 ? list[0] : null;
        }
    }

    [Serializable]
    public class Tbl_Media_Type
    {
        public int CountMedia { get; set; }
        public string SourceMedia { get; set; }
        public double PercentMedia { get; set; }
        public string ChannelLogo { get; set; }
        public string ChannelID { get; set; }
        public int Followers { get; set; }

        public static List<Tbl_Media_Type> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Media_Type> list = new List<Tbl_Media_Type>();
            List<Tbl_Media_Type> listWithPercent = new List<Tbl_Media_Type>();
            int total = 0;
            foreach (DataRow dr in Rows)
            {
                Tbl_Media_Type acc = new Tbl_Media_Type();
                acc.CountMedia = Convert.ToInt32(dr["CountMedia"]);
                acc.SourceMedia = dr["SourceMedia"].ToString();
                total += acc.CountMedia;
                list.Add(acc);
            }
            foreach (var l in list)
            {
                Tbl_Media_Type acc = new Tbl_Media_Type();
                acc.CountMedia = l.CountMedia;
                acc.SourceMedia = l.SourceMedia;
                try { acc.PercentMedia = (acc.CountMedia * 100) / total; } catch { acc.PercentMedia = 0; }
                listWithPercent.Add(acc);
            }
            return listWithPercent;
        }
    }
    public class ReportChartValue
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal SecondValue { get; set; }
        public decimal ThirdValue { get; set; }

        public static List<ReportChartValue> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<ReportChartValue> list = new List<ReportChartValue>();
            foreach (DataRow dr in Rows)
            {
                ReportChartValue acc = new ReportChartValue();
                try { acc.Value = Convert.ToDecimal(dr["Value"]); } catch { acc.Value = 0; }
                try { acc.SecondValue = Convert.ToDecimal(dr["SecondValue"]); } catch { acc.SecondValue = 0; }
                try { acc.ThirdValue = Convert.ToDecimal(dr["ThirdValue"]); } catch { acc.ThirdValue = 0; }
                acc.Name = dr["Name"].ToString();
                list.Add(acc);
            }
            return list;
        }

    }
    [Serializable]
    public class News_Sugiri
    {
        public Tbl_News_CountType AllNewsCount;
        public List<Tbl_News_SugiriType> PosetiveNewsCountList;
        public List<Tbl_News_SugiriType> NegativeNewsCountList;
        public List<ReportChartValue> NewsChartList;
    }
    [Serializable]
    public class News_AllSugiri
    {
        public List<Tbl_News_SugiriAllType> AllSugiriNewsCountList;
        public List<Tbl_News_General> PosetiveNewsCountList;
        public List<Tbl_News_General> NegativeNewsCountList;
        public List<ReportChartValue> PosetiveNewsChartList;
        public List<ReportChartValue> NegativeNewsChartList;
    }
    [Serializable]
    public class Media_All
    {
        public List<ReportChartValue> NewsStaticChartList;
        public List<ReportChartValue> VideoStaticChartList;
        public List<ReportChartValue> SocialStaticChartList;
        public List<ReportChartValue> AudioStaticChartList;
    }
    [Serializable]
    public class Tbl_News_CountType
    {
        public int PosetiveNewsCount { get; set; }
        public int NegativeNewsCount { get; set; }
        public int ComonNewsCount { get; set; }
        public int AllNewsCount { get; set; }

        public static Tbl_News_CountType GetFromDataRow(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_CountType> list = new List<Tbl_News_CountType>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_CountType acc = new Tbl_News_CountType();
                acc.PosetiveNewsCount = Convert.ToInt32(dr["PosetiveNewsCount"]);
                acc.NegativeNewsCount = Convert.ToInt32(dr["NegativeNewsCount"]);
                acc.ComonNewsCount = Convert.ToInt32(dr["ComonNewsCount"]);
                acc.AllNewsCount = Convert.ToInt32(dr["AllNewsCount"]);
                list.Add(acc);
            }
            return list.Count != 0 ? list[0] : null;
        }
    }

    [Serializable]
    public class Tbl_News_SugiriType
    {
        public int CountNews { get; set; }
        public string SourceNews { get; set; }
        public static List<Tbl_News_SugiriType> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_SugiriType> list = new List<Tbl_News_SugiriType>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_SugiriType acc = new Tbl_News_SugiriType();
                acc.CountNews = Convert.ToInt32(dr["CountNews"]);
                acc.SourceNews = dr["SourceNews"].ToString();
                list.Add(acc);
            }
            return list;
        }
    }
    [Serializable]
    public class Tbl_News_SugiriAllType
    {
        public int Total { get; set; }
        public int Negative { get; set; }
        public int Posetive { get; set; }
        public int Common { get; set; }
        public string SourceNews { get; set; }
        public static List<Tbl_News_SugiriAllType> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_News_SugiriAllType> list = new List<Tbl_News_SugiriAllType>();
            foreach (DataRow dr in Rows)
            {
                Tbl_News_SugiriAllType acc = new Tbl_News_SugiriAllType();
                acc.Total = Convert.ToInt32(dr["Total"]);
                acc.Negative = Convert.ToInt32(dr["Negative"]);
                acc.Posetive = Convert.ToInt32(dr["Posetive"]);
                acc.Common = Convert.ToInt32(dr["Common"]);
                acc.SourceNews = dr["SourceNews"].ToString();
                list.Add(acc);
            }
            return list;
        }
    }
    public class AllNews_HighSource
    {
        public List<Tbl_Media_Type> NewsCountList;
        public List<Tbl_Media_Type> NewspaperCountList;
    }
    [Serializable]
    public class ViewModel_RadioVideo
    {
        public List<Tbl_Video_General> videoList { get; set; }
        public List<Tbl_Radio_General> radioList { get; set; }
    }

    [Serializable]
    public class Tbl_Video_General
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string VideoDate { get; set; }
        public string PlayTime { get; set; }
        public string VideoTime { get; set; }
        public string NetworkName { get; set; }
        public string ProgramName { get; set; }
        public string PosterPath { get; set; }
        public string VideoPath { get; set; }
        public int Percent { get; set; }
        public int Tabaghe { get; set; }
        public long DefaultPrice { get; set; }
        public string AgName { get; set; }
        public int ParminID { get; set; }
        public static List<Tbl_Video_General> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Video_General> list = new List<Tbl_Video_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Video_General acc = new Tbl_Video_General();
                acc.MovieID = Convert.ToInt32(dr["MovieID"]);
                acc.Title = dr["Title"].ToString();
                acc.VideoDate = dr["VideoDate"].ToString();
                acc.PlayTime = dr["PlayTime"] + "";
                acc.VideoTime = dr["VideoTime"] + "";
                acc.NetworkName = dr["NetworkName"] + "";
                acc.ProgramName = dr["ProgramName"] + "";
                acc.PosterPath = dr["PosterPath"] + "";
                if (acc.PosterPath == "")
                    acc.PosterPath = "/Pages/P-Art/Images/no-ads.jpg";
                acc.VideoPath = dr["VideoPath"] + "";
                acc.Percent = Convert.ToInt32(dr["Percent"]);
                acc.Tabaghe = Convert.ToInt32(dr["Tabaghe"]);
                acc.DefaultPrice = Convert.ToInt64(dr["DefaultPrice"]);
                acc.AgName = dr["AgName"] + "";
                try { acc.ParminID = Convert.ToInt32(dr["ParminID"]); } catch { acc.ParminID = 0; }
                list.Add(acc);
            }
            return list;
        }
    }

    [Serializable]
    public class Tbl_Radio_General
    {
        public int SoundID { get; set; }
        public string Title { get; set; }
        public int Tabaghe { get; set; }
        public string Source { get; set; }
        public string SourcePath { get; set; }
        public string ProgramName { get; set; }
        public string TTime { get; set; }
        public string DDate { get; set; }
        public long DefaultPrice { get; set; }
        public int Percent { get; set; }
        public string PosterPath { get; set; }
        public string AgName { get; set; }
        public int ParminID { get; set; }
        public static List<Tbl_Radio_General> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Radio_General> list = new List<Tbl_Radio_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Radio_General acc = new Tbl_Radio_General();
                acc.SoundID = Convert.ToInt32(dr["SoundID"]);
                acc.Title = dr["Title"].ToString();
                acc.Source = dr["Source"].ToString();
                acc.SourcePath = dr["SourcePath"] + "";
                acc.TTime = dr["TTime"] + "";
                acc.DDate = dr["DDate"] + "";
                acc.ProgramName = dr["ProgramName"] + "";
                acc.PosterPath = dr["PosterPath"] + "";
                if (acc.PosterPath == "")
                    acc.PosterPath = "/Pages/P-Art/Images/no-ads.jpg";
                acc.Percent = Convert.ToInt32(dr["Percent"]);
                acc.Tabaghe = Convert.ToInt32(dr["Tabaghe"]);
                acc.DefaultPrice = Convert.ToInt64(dr["DefaultPrice"]);
                acc.AgName = dr["AgName"] + "";
                try { acc.ParminID = Convert.ToInt32(dr["ParminID"]); } catch { acc.ParminID = 0; }
                list.Add(acc);
            }
            return list;
        }
    }

    [Serializable]
    public class Tbl_Advertise_General
    {
        public long AdvertiseId { get; set; }
        public int BrandId { get; set; }
        public string BrandTitle { get; set; }
        public int Area { get; set; }
        public long Budget { get; set; }
        public string FarsiDateString { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

       
        public static List<Tbl_Advertise_General> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Advertise_General> list = new List<Tbl_Advertise_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Advertise_General acc = new Tbl_Advertise_General();
                acc.AdvertiseId = Convert.ToInt64(dr["AdvertiseId"]);
                acc.BrandId = Convert.ToInt32(dr["BrandId"]);
                acc.BrandTitle = dr["BrandTitle"].ToString();
                acc.FarsiDateString = dr["FarsiDateString"].ToString();
                acc.Address = dr["Address"] + "";
                acc.Description = dr["Description"] + "";
                acc.ImageName = dr["ImageName"] + "";
                acc.Area = Convert.ToInt32(dr["Area"]);
                acc.Budget = Convert.ToInt64(dr["Budget"]);
                list.Add(acc);
            }
            return list;
        }
    }
    [Serializable]
    public class Tbl_Instagram_General
    {
        public int Id { get; set; }
        public long InstagramPostId { get; set; }
        public int LikeCount { get; set; }
        public string keywordTitle { get; set; }
        public string CaptionText { get; set; }
        public string CaptionTextShort { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string DisplayUrl { get; set; }
        public int CommentsCount { get; set; }
        public byte NewsValue { get; set; }
        public int PanelId { get; set; }
        public long DateTimeIndex { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int KeywordId { get; set; }
        public string PostUrl { get; set; }


        public static List<Tbl_Instagram_General> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Instagram_General> list = new List<Tbl_Instagram_General>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Instagram_General acc = new Tbl_Instagram_General();
                acc.Id = Convert.ToInt32(dr["Id"]);
                acc.LikeCount = Convert.ToInt32(dr["LikeCount"]);
                acc.keywordTitle = dr["keywordTitle"].ToString();
                acc.CaptionText = dr["CaptionText"].ToString();
                acc.CaptionTextShort = Class_Static.ShortTxt(acc.CaptionText, 90);
                acc.FullName = dr["FullName"] + "";
                acc.UserName = dr["UserName"] + "";
                acc.DisplayUrl = dr["DisplayUrl"] + "";
                acc.CommentsCount = Convert.ToInt32(dr["CommentsCount"]);
                acc.NewsValue = Convert.ToByte(dr["NewsValue"]);
                acc.PanelId = Convert.ToInt32(dr["PanelId"]);
                try { acc.KeywordId = Convert.ToInt32(dr["KeywordId"]); } catch { acc.KeywordId = 0; }
                try { acc.DateTimeIndex = Convert.ToInt64(dr["DateTimeIndex"]); } catch { acc.DateTimeIndex = 0; }
                try { acc.PostUrl = dr["PostUrl"].ToString(); } catch { acc.PostUrl = ""; }
                try
                {
                    string year = "";
                    string month = "";
                    string day = "";
                    string hour = "";
                    string min = "";
                    string date = "";
                    string time = "";
                    if(acc.DateTimeIndex != 0)
                    {
                        year = acc.DateTimeIndex.ToString().Substring(0, 4);
                        month = acc.DateTimeIndex.ToString().Substring(4, 2);
                        day = acc.DateTimeIndex.ToString().Substring(6, 2);
                        hour = acc.DateTimeIndex.ToString().Substring(8, 2);
                        min = acc.DateTimeIndex.ToString().Substring(10, 2);
                        date = year + "/" + month + "/" + day;
                        time = hour + ":" + min;

                        acc.Date = date;
                        acc.Time = time;
                    }
                    else
                    {
                        acc.Date = "";
                        acc.Time = "";
                    }

                }
                catch
                {
                    acc.Date = "";
                    acc.Time = "";
                }
                list.Add(acc);
            }
            return list;
        }
    }
    public class ViewModel_Video_General
    {
        public int ParminID { get; set; }
        public string AgName { get; set; }
        public List<Tbl_Video_General> videoList { get; set; }
    }
    public class ViewModel_Radio_General
    {
        public int ParminID { get; set; }
        public string AgName { get; set; }
        public List<Tbl_Radio_General> radioList { get; set; }
    }
    public class ViewModel_Twitter_General
    {
        public int KeywordID { get; set; }
        public string Keyword { get; set; }
        public List<Tbl_Twitter_General> twitterList { get; set; }
    }
    public class ViewModel_Telegram_General
    {
        public int KeywordID { get; set; }
        public string Keyword { get; set; }
        public List<Tbl_Telegram_General> telegramList { get; set; }
    }
    public class ViewModel_Instagram_General
    {
        public int KeywordID { get; set; }
        public string Keyword { get; set; }
        public List<Tbl_Instagram_General> instagramList { get; set; }
    }
    public class ViewModel_News_BySource_General
    {
        public int KeywordID { get; set; }
        public string Keyword { get; set; }
        public List<Tbl_News_General> newsList { get; set; }
    }
}