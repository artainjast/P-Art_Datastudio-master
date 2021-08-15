using P_Art.Pages.P_Art.ModelNews;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelEnvAds;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Competitors_Data
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        private DB_EnvAdsEntities _dbEnv = new DB_EnvAdsEntities();
        public ChartData GetCompetitorsNews(int ParminId, long fromDatetimeIndex, long toDatetimeIndex, int siteType)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT k.KeywordName,COUNT(n.NewsID) AS Count FROM dbo.Tbl_News AS n" +
                        " INNER JOIN dbo.Tbl_Sites AS s ON s.SiteID = n.SiteID" +
                        " INNER JOIN dbo.Tbl_RssKeywords AS k ON n.KeywordId = k.KeyId" +
                        " WHERE n.NewsDateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND n.ParminId = " + ParminId +
                        " AND k.Type IN (2,3) AND s.SiteType = " + siteType +
                        " GROUP BY k.KeywordName";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            string name = "";
            if (siteType == 1)
                name = "سایت های خبری";
            else if (siteType == 2)
                name = "مطبوعات";
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["KeywordName"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = name;
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTelegram(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT k.Title , COUNT(k.ID) AS [Count] FROM dbo.Tbl_TLPMessage AS m INNER JOIN dbo.Tbl_TLPKeywords AS k ON m.KeywordID = k.ID" +
                        " WHERE k.Type IN (2,3) AND m.PanelID = " + ParminId + " AND m.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex +
                        " GROUP BY k.Title";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            string name = "تلگرام";

            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());
                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = name;
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTwitter(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT k.Title , COUNT(k.ID) AS [Count] FROM dbo.Tbl_TwitterPost AS m INNER JOIN dbo.Tbl_TwitterKeywords AS k ON m.KeywordID = k.ID" +
                        " WHERE k.Type IN (2,3) AND m.PanelID = " + ParminId + " AND m.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex +
                        " GROUP BY k.Title";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            string name = "توییتر";

            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());
                chartValues.Add(newItem);
            }
            values.Name = name;
            values.data = chartValues;
            cnn.Close();
            return values;
        }
        public ChartData GetCompetitorsInstagram(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT k.Title , COUNT(k.Id) AS [Count] FROM dbo.Tbl_InstagramPosts AS m INNER JOIN dbo.Tbl_InstagramKeywords AS k ON m.KeywordId = k.Id" +
                        " WHERE k.Type IN (2,3) AND m.PanelId = " + ParminId + " AND m.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex +
                        " GROUP BY k.Title";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            string name = "اینستاگرام";

            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());
                chartValues.Add(newItem);
            }
            values.Name = name;
            values.data = chartValues;
            cnn.Close();
            return values;
        }
        public List<ChartValue> GetCompetitorsAdsVideo(int ParminId, long fromDateIndex, long toDateIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT COUNT(p.ParminID) AS [Count],p.AgName AS Title FROM dbo.Tbl_Movies AS m " +
                        " INNER JOIN dbo.Tbl_Relation_MovieParminPanel AS r ON r.movieId = m.MovieID" +
                        " INNER JOIN dbo.Tbl_Parmin AS p ON	p.ParminID = r.ParminPanelId" +
                        " WHERE (r.ParminPanelId = " + ParminId + " OR r.ParminPanelId IN (SELECT CompetitorsParminId FROM dbo.Tbl_ParminCompetitors WHERE ParminID = " + ParminId + ")) AND m.Type <> 0" +
                        " AND m.VideoDateIndex BETWEEN " + fromDateIndex + " AND " + toDateIndex +
                        " GROUP BY p.AgName";
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<ChartValue> chartValues = new List<ChartValue>();

            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            return chartValues;
        }
        public List<ChartValue> GetCompetitorsAdsRadio(int ParminId, long fromDateIndex, long toDateIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT COUNT(p.ParminID) AS [Count],p.AgName AS Title FROM dbo.Tbl_Radio AS m  " +
                        " INNER JOIN dbo.Tbl_Relation_RadioParminPanel AS r ON r.SoundId = m.SoundID" +
                        " INNER JOIN dbo.Tbl_Parmin AS p ON	p.ParminID = r.ParminPanelId" +
                        " WHERE (r.ParminPanelId = " + ParminId + " OR r.ParminPanelId IN (SELECT CompetitorsParminId FROM dbo.Tbl_ParminCompetitors WHERE ParminID = " + ParminId + ")) AND m.Type <> 0" +
                        " AND m.SoundDateIndex BETWEEN " + fromDateIndex + " AND " + toDateIndex +
                        " GROUP BY p.AgName";
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<ChartValue> chartValues = new List<ChartValue>();

            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            return chartValues;
        }
        public List<ChartValue> GetCompetitorsAdsAdvertise(int ParminId, long fromDatetimeIndex, long toDatetimeIndex, int StructureType)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _dbEnv.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT b.Title , COUNT(*) AS [Count] FROM dbo.Advertises AS a INNER JOIN	dbo.Brands AS b ON b.BrandId = a.BrandId" +
                " INNER JOIN dbo.Structures AS s ON s.StructureId = a.StructureId" +
                " WHERE b.PanelId = " + ParminId + "  AND s.StructureTypeId = " + StructureType + " AND a.FarsiDateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex +
                " GROUP BY b.Title";
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<ChartValue> chartValues = new List<ChartValue>();

            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            return chartValues;
        }
        public List<ChartValue_NewData> GetCompetitorsAdsAdvertiseEkran(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {

            SqlParameter[] prms = {
                new SqlParameter("@" + "ParminId",ParminId),
                 new SqlParameter("@" + "DateTimeIndexFrom",fromDatetimeIndex),
                  new SqlParameter("@" + "DateTimeIndexTo",toDatetimeIndex),
            };
           

            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _dbEnv.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"p_Advertise_Ekran_Getdata";
            dtr.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in prms)
            {
                dtr.SelectCommand.Parameters.Add(p);
            }
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<ChartValue_NewData> chartValues = new List<ChartValue_NewData>();
            List<object> datas = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                datas = new List<object>();
                var newItem = new ChartValue_NewData();
                newItem.name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                datas.Add(Convert.ToInt64(row["Budget"].ToString()));
                datas.Add(Convert.ToInt32(row["Count"].ToString()));
                datas.Add(Convert.ToInt32(row["Area"].ToString()));
                newItem.data = datas;
                chartValues.Add(newItem);
            }
            cnn.Close();
            return chartValues;
        }
        public List<Campain_Type> GetCompetitorsAdsCampain(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _dbEnv.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT c.Title,i.ImageName,a.BrandId ,b.PanelId ,b.Title AS Brandtitle FROM dbo.Advertises as a INNER JOIN dbo.Campains AS c ON c.CampainId = a.CampainId INNER JOIN dbo.Brands AS b ON b.BrandId = c.BrandId INNER JOIN dbo.Images AS i ON i.AdvertiseId = a.AdvertiseId" +
                " WHERE b.PanelId = " + ParminId + " AND a.FarsiDateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<Campain_Type> chartValues = new List<Campain_Type>();

            foreach (DataRow row in dt.Rows)
            {
                var newItem = new Campain_Type();
                newItem.ImageName = row["ImageName"].ToString();
                newItem.Title = row["Title"].ToString();
                newItem.Brandtitle = row["Brandtitle"].ToString();
                newItem.BrandId = Convert.ToInt32(row["BrandId"]);
                newItem.PanelId = Convert.ToInt32(row["PanelId"]);
                chartValues.Add(newItem);
            }
            cnn.Close();
            return chartValues;
        }

        public ChartData GetCompetitorsInstagramLike(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 SUM(p.LikeCount) AS [Count] , k.Title FROM dbo.Tbl_InstagramPosts AS p " +
                        " INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = p.KeywordId" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY SUM(p.LikeCount)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "لایک";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsInstagramComment(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 SUM(p.CommentsCount) AS [Count] , k.Title FROM dbo.Tbl_InstagramPosts AS p " +
                        " INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = p.KeywordId" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY SUM(p.CommentsCount)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "کامنت";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsInstagramVideo(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_InstagramPosts AS p " +
                        " INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = p.KeywordId" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) AND p.TypeName = 'GraphVideo' GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "ویدیو";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsInstagramPicture(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_InstagramPosts AS p " +
                        " INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = p.KeywordId" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) AND p.TypeName = 'GraphImage' GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "عکس";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsInstagramContent(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_InstagramPosts AS p " +
                        " INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = p.KeywordId" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "محتوا";
            values.data = chartValues;
            return values;
        }

        public ChartData GetCompetitorsTelegramView(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 SUM(p.ViewCount) AS [Count] , k.Title FROM dbo.Tbl_TLPMessage AS p  " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY SUM(p.ViewCount)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "بازدید";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTelegramChannelCount(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(DISTINCT  p.ChannelID) AS [Count] , k.Title FROM dbo.Tbl_TLPMessage AS p  " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(DISTINCT  p.ChannelID)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "کانال";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTelegramVideo(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_TLPMessage AS p  " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.MediaType = 3 AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "ویدیو";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTelegramPicture(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_TLPMessage AS p  " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.MediaType = 2 AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "ویدیو";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTelegramText(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_TLPMessage AS p  " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.MediaType = 1 AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "ویدیو";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTelegramAll(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_TLPMessage AS p  " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + "  AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "ویدیو";
            values.data = chartValues;
            return values;
        }

        public ChartData GetCompetitorsTwitterFavorite(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 SUM(p.FavoriteCount) AS [Count] , k.Title FROM dbo.Tbl_TwitterPost AS p  " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY SUM(p.FavoriteCount)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "لایک";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTwitterReply(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 SUM(p.ReplyCount) AS [Count] , k.Title FROM dbo.Tbl_TwitterPost AS p  " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY SUM(p.ReplyCount)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "کامنت";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTwitterRetwitte(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 Count(*) AS [Count] , k.Title FROM dbo.Tbl_TwitterPost AS p   " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.IsRetweet = 1 AND  p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY Count(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "ریتوییت";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTwitterPicture(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 Count(*) AS [Count] , k.Title FROM dbo.Tbl_TwitterPost AS p  " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.MediaType = N'photo' AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY Count(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "عکس";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTwitterText(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 Count(*) AS [Count] , k.Title FROM dbo.Tbl_TwitterPost AS p  " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.MediaType <> N'photo' AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY Count(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "متن";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTwitterAll(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 Count(*) AS [Count] , k.Title FROM dbo.Tbl_TwitterPost AS p  " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY Count(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "محتوا";
            values.data = chartValues;
            return values;
        }

        public ChartData GetCompetitorsInstagramKeyword(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_InstagramPosts AS p " +
                        " INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = p.KeywordId" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "کلیدواژه";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTelegramKeyword(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 COUNT(*) AS [Count] , k.Title FROM dbo.Tbl_TLPMessage AS p  " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + "  AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY COUNT(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "کلیدواژه";
            values.data = chartValues;
            return values;
        }
        public ChartData GetCompetitorsTwitterKeyword(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 Count(*) AS [Count] , k.Title FROM dbo.Tbl_TwitterPost AS p  " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY k.Title ORDER BY Count(*)  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            ChartData values = new ChartData();
            List<ChartValue> chartValues = new List<ChartValue>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                newItem.Name = Class_Static.PersianAlpha(row["Title"].ToString()).Trim();
                newItem.Value = int.Parse(row["Count"].ToString());


                chartValues.Add(newItem);
            }
            cnn.Close();
            values.Name = "کلیدواژه";
            values.data = chartValues;
            return values;
        }


        public List<ChartData> GetCompetitorsNewsByKeyword(int ParminId, long fromDateIndex, long toDateIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT COUNT(*) AS Count ,s.SiteTitle AS Title , k.KeywordName FROM dbo.Tbl_News AS n INNER JOIN dbo.Tbl_RssKeywords AS k ON n.KeywordId = k.KeyId " +
                        " INNER JOIN dbo.Tbl_Sites AS s ON s.SiteID = n.SiteID  " +
                        " WHERE  n.NewsDateIndex BETWEEN " + fromDateIndex + " AND " + toDateIndex + " AND n.ParminId  = " + ParminId +
                        " AND k.Type IN (2) GROUP BY s.SiteTitle, k.KeywordName";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            List<ChartData> categories = new List<ChartData>();
            ChartData val = new ChartData();


            List<ChartValue> chartValues  = new List<ChartValue>(); 
            List<ChartData> allData = new List<ChartData>();
            foreach (DataRow row in dt.Rows)
            {
                var newItem = new ChartValue();
                if (!categories.Any(i=>i.Name == row["KeywordName"].ToString()))
                {
                    ChartData newData = new ChartData();
                    newData.Name = row["KeywordName"].ToString();
                    categories.Add(newData);
                }
                ChartData newChartData = new ChartData();
                newChartData.Name = row["KeywordName"].ToString();


                ChartValue newalues = new ChartValue();
                newalues.Name = row["Title"].ToString();
                newalues.Value = Convert.ToInt64(row["Count"].ToString());
                chartValues.Add(newalues);

                newChartData.data = chartValues;

                allData.Add(newChartData);

            }

            foreach(var ctgData in categories)
            {
                foreach(var d in allData.Where(i => i.Name == ctgData.Name).ToList())
                {
                    chartValues = new List<ChartValue>();
                    List<ChartValue> dValue = d.data;
                    foreach(var v in dValue)
                    {
                        ChartValue newd = new ChartValue();
                        newd.Name = v.Name;
                        newd.Value = v.Value;
                        chartValues.Add(newd);
                    }
                }
                ctgData.data = chartValues;
            }
            cnn.Close();
            return categories;
        }
        public List<ChartData> GetCompetitorsNewsByKeywordSource(int ParminId, long fromDateIndex, long toDateIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT COUNT(*) AS Count ,s.SiteTitle AS Title , k.KeywordName FROM dbo.Tbl_News AS n INNER JOIN dbo.Tbl_RssKeywords AS k ON n.KeywordId = k.KeyId " +
                        " INNER JOIN dbo.Tbl_Sites AS s ON s.SiteID = n.SiteID  " +
                        " WHERE  n.NewsDateIndex BETWEEN " + fromDateIndex + " AND " + toDateIndex + " AND n.ParminId  = " + ParminId +
                        " AND k.Type IN (2,3) GROUP BY s.SiteTitle, k.KeywordName";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            List<ChartData> categories = new List<ChartData>();
            ChartData val = new ChartData();


            List<ChartValue> chartValues = new List<ChartValue>();
            List<ChartData> allData = new List<ChartData>();
            foreach (DataRow row in dt.Rows)
            {
                chartValues = new List<ChartValue>();
                var newItem = new ChartValue();
                if (!categories.Any(i => i.Name == row["KeywordName"].ToString()))
                {
                    ChartData newData = new ChartData();
                    newData.Name = row["KeywordName"].ToString();
                    categories.Add(newData);
                }
                ChartData newChartData = new ChartData();
                newChartData.Name = row["KeywordName"].ToString();


                ChartValue newalues = new ChartValue();
                newalues.Name = row["Title"].ToString();
                newalues.Value = Convert.ToInt64(row["Count"].ToString());
                chartValues.Add(newalues);

                newChartData.data = chartValues;

                allData.Add(newChartData);

            }

            foreach (var ctgData in categories)
            {
                chartValues = new List<ChartValue>();
                foreach (var d in allData.Where(i => i.Name == ctgData.Name).ToList())
                {
                    
                    List<ChartValue> dValue = d.data;
                    foreach (var v in dValue)
                    {
                        ChartValue newd = new ChartValue();
                        newd.Name = v.Name;
                        newd.Value = v.Value;
                        chartValues.Add(newd);
                    }
                }
                ctgData.data = chartValues;
            }
            cnn.Close();
            return categories;
        }



        public List<Tbl_Video_General> GetCompetitorsShowAdsVideo(int ParminId, long fromDateIndex, long toDateIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT m.MovieID, m.Title , m.VideoDate , m.PlayTime , m.VideoTime , m.NetworkName , m.ProgramName , m.PosterPath,m.VideoPath," +
                        " m.[Percent] , m.Tabaghe , m.DefaultPrice ,p.AgName,p.ParminID FROM dbo.Tbl_Movies AS m " +
                        " INNER JOIN dbo.Tbl_Relation_MovieParminPanel AS r ON m.MovieID = r.movieId " +
                        " INNER JOIN dbo.Tbl_Parmin AS p ON	p.ParminID = r.ParminPanelId" +
                        " WHERE (r.ParminPanelId = " + ParminId + " OR r.ParminPanelId IN (SELECT CompetitorsParminId FROM dbo.Tbl_ParminCompetitors WHERE ParminID = " + ParminId + ")) AND m.Type <> 0" +
                        " AND m.VideoDateIndex BETWEEN " + fromDateIndex + " AND " + toDateIndex ;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<Tbl_Video_General> chartValues  = Tbl_Video_General.GetFromDataRows(dt.Select());
            cnn.Close();
            return chartValues;
        }
        public List<Tbl_Radio_General> GetCompetitorsShowAdsRadio(int ParminId, long fromDateIndex, long toDateIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT m.SoundID,m.Title,m.Tabaghe,m.Source,m.SourcePath,m.ProgramName,m.TTime,m.DDate,m.Tabaghe,m.DefaultPrice,  " +
                        " m.PosterPath, p.AgName,p.ParminID,m.[Percent]  FROM dbo.Tbl_Radio AS m " +
                        " INNER JOIN dbo.Tbl_Relation_RadioParminPanel AS r ON r.SoundId = m.SoundID" +
                        " INNER JOIN dbo.Tbl_Parmin AS p ON	p.ParminID = r.ParminPanelId" +
                        " WHERE (r.ParminPanelId = " + ParminId + " OR r.ParminPanelId IN (SELECT CompetitorsParminId FROM dbo.Tbl_ParminCompetitors WHERE ParminID = " + ParminId + ")) AND m.Type <> 0" +
                        " AND m.SoundDateIndex BETWEEN " + fromDateIndex + " AND " + toDateIndex;
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<Tbl_Radio_General> chartValues = Tbl_Radio_General.GetFromDataRows(dt.Select());
            cnn.Close();
            return chartValues;
        }
        public List<Tbl_Advertise_General> GetCompetitorsShowAdsAdvertiseEkran(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {

            SqlParameter[] prms = {
                new SqlParameter("@" + "ParminId",ParminId),
                 new SqlParameter("@" + "DateTimeIndexFrom",fromDatetimeIndex),
                  new SqlParameter("@" + "DateTimeIndexTo",toDatetimeIndex),
            };


            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _dbEnv.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"p_Advertise_Ekran_ShowDetail_Getdata";
            dtr.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in prms)
            {
                dtr.SelectCommand.Parameters.Add(p);
            }
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<Tbl_Advertise_General> chartValues = Tbl_Advertise_General.GetFromDataRows(dt.Select());

            cnn.Close();
            return chartValues;
        }
        public List<Tbl_Instagram_General> GetCompetitorsShowInstagram(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT TOP 10 p.Id , p.InstagramPostId , p.DateTimeIndex ,p.LikeCount ,p.KeywordId, k.Title AS keywordTitle , p.CaptionText,p.FullName,p.UserName,p.DisplayUrl,p.CommentsCount,p.NewsValue,p.PanelId FROM dbo.Tbl_InstagramPosts AS p " +
                        " INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = p.KeywordId" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) ORDER BY  p.DateTimeIndex  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            cnn.Close();
            List<Tbl_Instagram_General> chartValues = Tbl_Instagram_General.GetFromDataRows(dt.Select());
            return chartValues;
        }
        public List<Tbl_Telegram_General> GetCompetitorsShowTelegram(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT  p.ID,p.ViewCount , k.Title AS keywordTitle , p.MessageText , p.MessageDate , p.MessageTime ,p.KeywordID, ISNULL(p.NewsValue,0) AS NewsValue,p.DateTimeIndex,p.CreateDateTIme,p.PanelID,c.ChannelTitle  FROM dbo.Tbl_TLPMessage AS p   " +
                        " INNER JOIN dbo.Tbl_TLPKeywords AS k ON k.ID = p.KeywordID" +
                        " INNER JOIN dbo.Tbl_TLPChannels AS c ON c.ChannelID = p.ChannelID " +
                        " WHERE  p.DateTimeIndex BETWEEN  " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) ORDER BY p.DateTimeIndex  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
          
            cnn.Close();
            List<Tbl_Telegram_General> chartValues = Tbl_Telegram_General.GetFromDataRowsShortText(dt.Select());
            return chartValues;
        }
        public List<Tbl_Twitter_General> GetCompetitorsShowTwitter(int ParminId, long fromDatetimeIndex, long toDatetimeIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT p.ID,p.TweetID,p.FavoriteCount , k.Title AS keywordTitle ,p.KeywordID, p.UserScreenName ,p.DateTimeIndex,p.PostDateTime, p.Text , p.Date , p.Time , p.RetweetCount , p.ReplyCount , p.QuoteCount,p.Url,p.MediaUrl,ISNULL(p.NewsValue,0) AS NewsValue,p.UserName FROM dbo.Tbl_TwitterPost AS p   " +
                        " INNER JOIN dbo.Tbl_TwitterKeywords AS k ON k.ID = p.KeywordID" +
                        " WHERE  p.DateTimeIndex BETWEEN " + fromDatetimeIndex + " AND " + toDatetimeIndex + " AND p.PanelId  = " + ParminId +
                        " AND k.Type IN (2,3) ORDER BY p.DateTimeIndex  DESC";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            List<Tbl_Twitter_General> chartValues = Tbl_Twitter_General.GetFromDataRows(dt.Select());
            cnn.Close();

            return chartValues;
        }
        public List<Tbl_News_General> GetCompetitorsShowNewsByKeywordSource(int ParminId, long fromDateIndex, long toDateIndex)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = _db.Database.Connection.ConnectionString;
            cnn.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = cnn;
            dtr.SelectCommand.CommandText = @"SELECT n.NewsID as NewsId,s.SiteTitle,s.SiteID, k.KeywordName,n.KeywordId,n.NewsTitle,n.NewsDate,n.NewsTime , n.NewsLink,n.NewsPicture FROM dbo.Tbl_News AS n INNER JOIN dbo.Tbl_RssKeywords AS k ON n.KeywordId = k.KeyId  " +
                        " INNER JOIN dbo.Tbl_Sites AS s ON s.SiteID = n.SiteID  " +
                        " WHERE  n.NewsDateIndex BETWEEN " + fromDateIndex + " AND " + toDateIndex + " AND n.ParminId  = " + ParminId +
                        " AND k.Type IN (2,3)";
            DataTable dt = new DataTable();
            dtr.Fill(dt);
            List<Tbl_News_General> chartValues = Tbl_News_General.GetFromDataRows(dt.Select());
            cnn.Close();
            return chartValues;
        }
    }
}