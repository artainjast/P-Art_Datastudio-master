using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PArt.Pages.P_Art.Repository;
using System.Data;
using System.Data.SqlClient;
using P_Art.Pages.P_Art.ModelNews;
using System.Text;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_SocialMedia
    {
        public int Row { get; set; }
        public int SocialMediaPostID { get; set; }
        public long SocialPostID { get; set; }
        public int SocialMediaUserID_FK { get; set; }
        public bool Active { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime PostDate { get; set; }
        public string PosteDateIndex { get; set; }
        public string PosteDateTimeIndex { get; set; }
        public int RetweetCount { get; set; }
        public string Lang { get; set; }
        public string LinkUrl { get; set; }
        public long LinkUrlCRC { get; set; }
        public DateTime CreateDate { get; set; }

        public string Title { get; set; }

        public int SocialMediaKeyID_FK { get; set; }

        public int NewsValue { get; set; }


        public DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public Class_SocialMedia GetReport(int ArchiveId)
        {
            string cmd = "SELECT * FROM dbo.Tbl_SocialMediaBultan WHERE SocialMediaBultanID =" +
                ArchiveId;
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            List<Class_SocialMedia> list = GetFromDataRows(ds.Tables[0].Select());
            return list.Count != 0 ? list[0] : null;
        }

        public List<Tbl_SocialMediaKey> GetRssKeywordByPanelIds(List<int?> ids)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var query = from key in db.Tbl_SocialMediaKey
                        where ids.Contains(key.ParminID_FK)
                        && key.Active == true

                        select key;
            return query.ToList();


        }




        public static List<Class_SocialMedia> GetFromDataRows(DataRow[] Rows)
        {
            System.Text.Encoding Utf8Encoder = System.Text.Encoding.GetEncoding("UTF-8",
new System.Text.EncoderReplacementFallback(string.Empty),
new System.Text.DecoderReplacementFallback(string.Empty)
);


            List<Class_SocialMedia> list = new List<Class_SocialMedia>();
            foreach (DataRow r in Rows)
            {
                Class_SocialMedia social = new Class_SocialMedia();


                social.SocialMediaPostID = Convert.ToInt32(r["SocialMediaPostID"]);
                social.Row = Convert.ToInt32(r["Row"]);
                social.SocialPostID = Convert.ToInt64(r["SocialPostID"]);
                social.SocialMediaUserID_FK = Convert.ToInt32(r["SocialMediaUserID_FK"]);
                social.Active = Convert.ToBoolean(r["Active"]);

                social.Text = Class_Static.RemoveIligallUnicodeCharacter(r["Text"].ToString());
                social.SocialMediaKeyID_FK = Convert.ToInt32(r["SocialMediaKeyID_FK"]);
                social.UserName = Class_Static.RemoveIligallUnicodeCharacter(r["UserName"].ToString());//r["UserName"].ToString();
                social.LikeCount = Convert.ToInt32(r["LikeCount"]);
                social.CommentCount = Convert.ToInt32(r["CommentCount"]);
                social.PostDate = Convert.ToDateTime(r["PostDate"]);
                social.PosteDateIndex = r["PosteDateIndex"].ToString();
                social.RetweetCount = Convert.ToInt32(r["RetweetCount"]);
                social.Lang = r["Lang"].ToString();
                social.LinkUrl = r["LinkUrl"].ToString();
                social.LinkUrlCRC = Convert.ToInt64(r["LinkUrlCRC"]);
                social.CreateDate = Convert.ToDateTime(r["CreateDate"]);
                try
                {
                    social.NewsValue = Convert.ToInt32(r["NewsValue"]);

                }
                catch
                {
                    social.NewsValue = 0;
                }
                //}

                list.Add(social);
            }
            return list;
        }
        public DataTable GetData(int PageCount, int PageIndex, string PanelIds, long FromDate,
            long ToDate, string Search, string KeysIds)
        {
            var query = @"SELECT   ROW_NUMBER() OVER(ORDER BY Tbl_SocialMediaPost.SocialMediaPostID asc) AS Row,  Tbl_SocialMediaPost.SocialMediaPostID, Tbl_SocialMediaPost.SocialPostID, Tbl_SocialMediaPost.SocialMediaKeyID_FK, Tbl_SocialMediaPost.SocialMediaUserID_FK, Tbl_SocialMediaPost.Active,Tbl_SocialMediaPost.NewsValue,k.Title, 
                         Tbl_SocialMediaPost.Text, Tbl_SocialMediaPost.UserName, Tbl_SocialMediaPost.LikeCount, Tbl_SocialMediaPost.CommentCount, Tbl_SocialMediaPost.PostDate, Tbl_SocialMediaPost.PosteDateIndex, 
                         Tbl_SocialMediaPost.PosteDateTimeIndex, Tbl_SocialMediaPost.RetweetCount, Tbl_SocialMediaPost.Lang, Tbl_SocialMediaPost.LinkUrl, Tbl_SocialMediaPost.LinkUrlCRC, Tbl_SocialMediaPost.CreateDate
FROM            Tbl_SocialMediaPost INNER JOIN
                         Tbl_SocialMediaKey AS k ON Tbl_SocialMediaPost.SocialMediaKeyID_FK = k.SocialMediaKeyID

					  WHERE Tbl_SocialMediaPost.Active=1 AND k.ParminID_FK IN (" + PanelIds + ")  AND Tbl_SocialMediaPost.PosteDateIndex BETWEEN '" + FromDate + "' and '" + ToDate + "'";

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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon + "%'";


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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon2 + "%'";


                        query += ")";
                    }

                }
                


            }


            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(KeysIds))
            {
                if (KeysIds.EndsWith(","))
                {
                    KeysIds = KeysIds.Substring(0, KeysIds.Length - 1);

                }
                queryRssKeywords = " AND SocialMediaKeyID_FK IN(" + KeysIds + ")";

            }
           

            query += queryRssKeywords;


            query = query.Replace("{0}", "");
            query += "ORDER BY PosteDateIndex DESC";


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
            //    SqlParameter[] sqlParams = {
            //        new SqlParameter("@" + "PageCount",PageCount),
            //        new SqlParameter("@" + "PageIndex",PageIndex),
            //         new SqlParameter("@" + "PanelIds",PanelIds),
            //        new SqlParameter("@" + "FromDate",FromDate) ,
            //         new SqlParameter("@" + "ToDate",ToDate),
            //        new SqlParameter("@" + "Search",Search),
            //         new SqlParameter("@" + "KeysIds",KeysIds)
            //};
            //    return Dashboard.ExecuteDataset("", "p_SocialPost_GetAlldata", CommandType.StoredProcedure, sqlParams);
            //}
        }


        public DataTable GetLikeData(int PageCount, int PageIndex, string PanelIds, long FromDate,
    long ToDate, string Search, string KeysIds)
        {
#pragma warning disable CS0219 // The variable 'panels' is assigned but its value is never used
            var panels = "";
#pragma warning restore CS0219 // The variable 'panels' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'searchQuery' is assigned but its value is never used
            string searchQuery = "";
#pragma warning restore CS0219 // The variable 'searchQuery' is assigned but its value is never used

            var query = @"SELECT   ROW_NUMBER() OVER(ORDER BY Tbl_SocialMediaPost.SocialMediaPostID asc) AS Row,   Tbl_SocialMediaPost.SocialMediaPostID,Tbl_SocialMediaPost.NewsValue, Tbl_SocialMediaPost.SocialPostID, Tbl_SocialMediaPost.SocialMediaKeyID_FK, Tbl_SocialMediaPost.SocialMediaUserID_FK, Tbl_SocialMediaPost.Active, 
                         Tbl_SocialMediaPost.Text, Tbl_SocialMediaPost.UserName, Tbl_SocialMediaPost.LikeCount, Tbl_SocialMediaPost.CommentCount, Tbl_SocialMediaPost.PostDate, Tbl_SocialMediaPost.PosteDateIndex, 
                         Tbl_SocialMediaPost.PosteDateTimeIndex, Tbl_SocialMediaPost.RetweetCount, Tbl_SocialMediaPost.Lang, Tbl_SocialMediaPost.LinkUrl, Tbl_SocialMediaPost.LinkUrlCRC, Tbl_SocialMediaPost.CreateDate
FROM            Tbl_SocialMediaPost INNER JOIN
                         Tbl_SocialMediaKey AS k ON Tbl_SocialMediaPost.SocialMediaKeyID_FK = k.SocialMediaKeyID

					  WHERE Tbl_SocialMediaPost.Active=1 AND k.ParminID_FK IN (" + PanelIds + ")  AND (Tbl_SocialMediaPost.PosteDateIndex BETWEEN '" + FromDate + "' and '" + ToDate + "')";

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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon + "%'";


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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon2 + "%'";


                        query += ")";
                    }

                }




            }


            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(KeysIds))
            {
                if (KeysIds.EndsWith(","))
                {
                    KeysIds = KeysIds.Substring(0, KeysIds.Length - 1);

                }
                queryRssKeywords = " AND k.SocialMediaKeyID IN (" + KeysIds + ")";

            }
            query += queryRssKeywords;


            query = query.Replace("{0}", "");
            query += "ORDER BY likecount DESC";


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


        public DataTable GetCommentData(int PageCount, int PageIndex, string PanelIds, long FromDate,
    long ToDate, string Search, string KeysIds)
        {
#pragma warning disable CS0219 // The variable 'panels' is assigned but its value is never used
            var panels = "";
#pragma warning restore CS0219 // The variable 'panels' is assigned but its value is never used






#pragma warning disable CS0219 // The variable 'searchQuery' is assigned but its value is never used
            string searchQuery = "";
#pragma warning restore CS0219 // The variable 'searchQuery' is assigned but its value is never used



            var query = @"SELECT   ROW_NUMBER() OVER(ORDER BY Tbl_SocialMediaPost.SocialMediaPostID asc) AS Row,   Tbl_SocialMediaPost.SocialMediaPostID,Tbl_SocialMediaPost.NewsValue, Tbl_SocialMediaPost.SocialPostID, Tbl_SocialMediaPost.SocialMediaKeyID_FK, Tbl_SocialMediaPost.SocialMediaUserID_FK, Tbl_SocialMediaPost.Active, 
                         Tbl_SocialMediaPost.Text, Tbl_SocialMediaPost.UserName, Tbl_SocialMediaPost.LikeCount, Tbl_SocialMediaPost.CommentCount, Tbl_SocialMediaPost.PostDate, Tbl_SocialMediaPost.PosteDateIndex, 
                         Tbl_SocialMediaPost.PosteDateTimeIndex, Tbl_SocialMediaPost.RetweetCount, Tbl_SocialMediaPost.Lang, Tbl_SocialMediaPost.LinkUrl, Tbl_SocialMediaPost.LinkUrlCRC, Tbl_SocialMediaPost.CreateDate
FROM            Tbl_SocialMediaPost INNER JOIN
                         Tbl_SocialMediaKey AS k ON Tbl_SocialMediaPost.SocialMediaKeyID_FK = k.SocialMediaKeyID

					  WHERE Tbl_SocialMediaPost.Active=1 AND k.ParminID_FK IN (" + PanelIds + ")  AND (Tbl_SocialMediaPost.PosteDateIndex BETWEEN '" + FromDate + "' and '" + ToDate + "')";

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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon + "%'";


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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon2 + "%'";


                        query += ")";
                    }

                }




            }


            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(KeysIds))
            {
                if (KeysIds.EndsWith(","))
                {
                    KeysIds = KeysIds.Substring(0, KeysIds.Length - 1);

                }
                queryRssKeywords = " AND k.SocialMediaKeyID IN (" + KeysIds + ")";

            }
            query += queryRssKeywords;


            query = query.Replace("{0}", "");
            query += "ORDER BY CommentCount DESC";


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



        public DataTable GetRetweetData(int PageCount, int PageIndex, string PanelIds, long FromDate,
    long ToDate, string Search, string KeysIds)
        {
#pragma warning disable CS0219 // The variable 'panels' is assigned but its value is never used
            var panels = "";
#pragma warning restore CS0219 // The variable 'panels' is assigned but its value is never used






#pragma warning disable CS0219 // The variable 'searchQuery' is assigned but its value is never used
            string searchQuery = "";
#pragma warning restore CS0219 // The variable 'searchQuery' is assigned but its value is never used



            var query = @"SELECT   ROW_NUMBER() OVER(ORDER BY Tbl_SocialMediaPost.SocialMediaPostID asc) AS Row,  Tbl_SocialMediaPost.SocialMediaPostID,Tbl_SocialMediaPost.NewsValue, Tbl_SocialMediaPost.SocialPostID, Tbl_SocialMediaPost.SocialMediaKeyID_FK, Tbl_SocialMediaPost.SocialMediaUserID_FK, Tbl_SocialMediaPost.Active, 
                         Tbl_SocialMediaPost.Text, Tbl_SocialMediaPost.UserName, Tbl_SocialMediaPost.LikeCount, Tbl_SocialMediaPost.CommentCount, Tbl_SocialMediaPost.PostDate, Tbl_SocialMediaPost.PosteDateIndex, 
                         Tbl_SocialMediaPost.PosteDateTimeIndex, Tbl_SocialMediaPost.RetweetCount, Tbl_SocialMediaPost.Lang, Tbl_SocialMediaPost.LinkUrl, Tbl_SocialMediaPost.LinkUrlCRC, Tbl_SocialMediaPost.CreateDate
FROM            Tbl_SocialMediaPost INNER JOIN
                         Tbl_SocialMediaKey AS k ON Tbl_SocialMediaPost.SocialMediaKeyID_FK = k.SocialMediaKeyID

					  WHERE Tbl_SocialMediaPost.Active=1 AND k.ParminID_FK IN (" + PanelIds + ")  AND (Tbl_SocialMediaPost.PosteDateIndex BETWEEN '" + FromDate + "' and '" + ToDate + "')";

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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon + "%'";


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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon2 + "%'";


                        query += ")";
                    }

                }




            }


            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(KeysIds))
            {
                if (KeysIds.EndsWith(","))
                {
                    KeysIds = KeysIds.Substring(0, KeysIds.Length - 1);

                }
                queryRssKeywords = " AND k.SocialMediaKeyID IN (" + KeysIds + ")";

            }
            query += queryRssKeywords;


            query = query.Replace("{0}", "");
            query += "ORDER BY retweetcount DESC";


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

        public DataTable GetRetweetData1(int PageCount, int PageIndex, string PanelIds, long FromDate,
long ToDate, string Search, string KeysIds, string keyname)
        {
#pragma warning disable CS0219 // The variable 'panels' is assigned but its value is never used
            var panels = "";
#pragma warning restore CS0219 // The variable 'panels' is assigned but its value is never used






#pragma warning disable CS0219 // The variable 'searchQuery' is assigned but its value is never used
            string searchQuery = "";
#pragma warning restore CS0219 // The variable 'searchQuery' is assigned but its value is never used



            var query = @"SELECT   ROW_NUMBER() OVER(ORDER BY Tbl_SocialMediaPost.SocialMediaPostID asc) AS Row,  Tbl_SocialMediaPost.SocialMediaPostID, Tbl_SocialMediaPost.SocialPostID, Tbl_SocialMediaPost.SocialMediaKeyID_FK, Tbl_SocialMediaPost.SocialMediaUserID_FK, Tbl_SocialMediaPost.Active, 
                         Tbl_SocialMediaPost.Text, Tbl_SocialMediaPost.UserName, Tbl_SocialMediaPost.LikeCount, Tbl_SocialMediaPost.CommentCount, Tbl_SocialMediaPost.PostDate, Tbl_SocialMediaPost.PosteDateIndex, 
                         Tbl_SocialMediaPost.PosteDateTimeIndex, Tbl_SocialMediaPost.RetweetCount, Tbl_SocialMediaPost.Lang, Tbl_SocialMediaPost.LinkUrl, Tbl_SocialMediaPost.LinkUrlCRC, Tbl_SocialMediaPost.CreateDate
FROM            Tbl_SocialMediaPost INNER JOIN
                         Tbl_SocialMediaKey AS k ON Tbl_SocialMediaPost.SocialMediaKeyID_FK = k.SocialMediaKeyID

					  WHERE Tbl_SocialMediaPost.Active=1 AND k.ParminID_FK IN (" + PanelIds + ")  AND (Tbl_SocialMediaPost.PosteDateIndex BETWEEN '" + FromDate + "' and '" + ToDate + "')";

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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon + "%'";


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
                        query += " Tbl_SocialMediaPost.Text LIKE N'%" + strCon2 + "%'";


                        query += ")";
                    }

                }




            }


            var queryRssKeywords = "";
            if (!string.IsNullOrWhiteSpace(KeysIds))
            {
                if (KeysIds.EndsWith(","))
                {
                    KeysIds = KeysIds.Substring(0, KeysIds.Length - 1);

                }
                queryRssKeywords = " AND KeywordId IN (" + KeysIds + ")";

            }
            query += queryRssKeywords;


            query = query.Replace("{0}", "");
            query += "ORDER BY retweetcount DESC";


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



    }

    [Serializable]
    public class socialkey
    {
        public int Row { get; set; }
        public int SocialMediaPostID { get; set; }
        public long SocialPostID { get; set; }
        public int SocialMediaUserID_FK { get; set; }
        public bool Active { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime PostDate { get; set; }
        public string PosteDateIndex { get; set; }
        public string PosteDateTimeIndex { get; set; }
        public int RetweetCount { get; set; }
        public string Lang { get; set; }
        public string LinkUrl { get; set; }
        public long LinkUrlCRC { get; set; }
        public DateTime CreateDate { get; set; }

        public string Title { get; set; }

        public int SocialMediaKeyID_FK { get; set; }


        public static List<socialkey> GetFromDataRows(DataRow[] Rows)
        {
            List<socialkey> list = new List<socialkey>();
            foreach (DataRow r in Rows)
            {
                socialkey social = new socialkey();
                social.SocialMediaPostID = Convert.ToInt32(r["SocialMediaPostID"]);
                social.Row = Convert.ToInt32(r["Row"]);
                social.SocialPostID = Convert.ToInt64(r["SocialPostID"]);
                social.SocialMediaUserID_FK = Convert.ToInt32(r["SocialMediaUserID_FK"]);
                social.Active = Convert.ToBoolean(r["Active"]);
                social.Text = r["Text"].ToString();
                social.SocialMediaKeyID_FK = Convert.ToInt32(r["SocialMediaKeyID_FK"]);
                social.Title = r["Title"].ToString();

                social.UserName = r["UserName"].ToString();
                social.LikeCount = Convert.ToInt32(r["LikeCount"]);
                social.CommentCount = Convert.ToInt32(r["CommentCount"]);
                social.PostDate = Convert.ToDateTime(r["PostDate"]);
                social.PosteDateIndex = r["PosteDateIndex"].ToString();
                social.PosteDateTimeIndex = r["PosteDateTimeIndex"].ToString();
                social.RetweetCount = Convert.ToInt32(r["RetweetCount"]);
                social.Lang = r["Lang"].ToString();
                social.LinkUrl = r["LinkUrl"].ToString();
                social.LinkUrlCRC = Convert.ToInt64(r["LinkUrlCRC"]);
                social.CreateDate = Convert.ToDateTime(r["CreateDate"]);
                list.Add(social);
            }
            return list;
        }

    }

}