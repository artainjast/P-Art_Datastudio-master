using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
    public class Class_Core_SocialMediaPost
    {
        Class_Ado _clsAdo = new Class_Ado();
        Class_Core_SocialMediaUser _clsUser = new Class_Core_SocialMediaUser();
        public string KeyID = "SocialMediaPostID";
        public string KeyOrder = "SocialMediaPostID";
        public string TableName = "Tbl_SocialMediaPost";

        public List<Tbl_SocialMediaPost_Type> SelectAll(int top)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();


                //var res = _clsAdo.FillDatabaseParametric("", "SELECT TOP "+top+" * FROM " + TableName + " WHERE   [Active]=1 AND [PosteDateTimeIndex] IS NULL", lstParam);
                var res = _clsAdo.FillDatabaseParametric("", "SELECT TOP " + top + " * FROM " + TableName + " WHERE   [Active]=1 ", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaPost_Type>(res);

            }
            catch
            {
                return null;
            }
        }
        public List<Tbl_SocialMediaUser_Type> SelectByUserGroup(int top, string parmins, string socialCodes, string dateFrom, string dateEnd, string keys)
        {
            var lst = new List<Tbl_SocialMediaUser_Type>();
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "Tbl_SocialMediaKey", ColumnType = SqlDbType.NVarChar, ColumnValue = parmins, ParamName = "@p1" });

                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaUserID_FK", ColumnType = SqlDbType.NVarChar, ColumnValue = socialCodes, ParamName = "@p2" });

                lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateIndex", ColumnType = SqlDbType.Char, ColumnValue = dateFrom, ParamName = "@p3" });

                lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateIndex", ColumnType = SqlDbType.Char, ColumnValue = dateEnd, ParamName = "@p4" });



                var where = "";
                if (!string.IsNullOrWhiteSpace(dateFrom))
                {

                    where += "AND Tbl_SocialMediaPost.PosteDateIndex >=@p3 ";
                }
                if (!string.IsNullOrWhiteSpace(dateEnd))
                {

                    where += "AND Tbl_SocialMediaPost.PosteDateIndex <=@p4 ";
                }
                if (!string.IsNullOrWhiteSpace(keys))
                {
                    where += "AND Tbl_SocialMediaPost.SocialMediaKeyID_FK IN (" + keys + ") ";
                }
                //if (!string.IsNullOrWhiteSpace(where))
                //{
                //    where = " WHERE " + where.Substring(3);
                //}

                var res = _clsAdo.FillDatabaseParametric("", @"SELECT TOP " + top + @" SocialMediaUserID_FK,Count(SocialMediaUserID_FK) AS CCount  FROM  Tbl_SocialMediaPost
 WHERE Tbl_SocialMediaPost.Active = 1 AND
                    Tbl_SocialMediaPost.SocialMediaKeyID_FK IN
                    (SELECT SocialMediaKeyID FROM Tbl_SocialMediaKey WHERE ParminID_FK IN (@p1))  AND

                     Tbl_SocialMediaPost.SocialMediaUserID_FK IN
                    (SELECT SocialMediaUserID FROM Tbl_SocialMediaUser WHERE SocialCode IN (@p2))

" + where + @"
 GROUP BY SocialMediaUserID_FK


 ORDER BY CCount DESC", lstParam);

                if (res != null)
                {
                    foreach (DataRow item in res.Rows)
                    {
                        try
                        {
                            var data = _clsUser.SelectItem(Convert.ToInt32(item["SocialMediaUserID_FK"]));
                            data.PostCount = Convert.ToInt32(item["CCount"]);
                            lst.Add(data);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                //  return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaPost_Type>(res);

            }
            catch
            {

            }
            return lst;
        }
        public List<Tbl_SocialMediaPost_Type> SelectAllToShow(string parminPanelIDs, string dateFrom, string dateEnd, string socialCodes, int pageNumber, int pageCount, int? skipCount, int? SocialMediaPostID, bool? GreaterOrLeass, string userIds, string keys, Social_Sorting sorting, string postIds, string searchTag)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateIndex", ColumnType = SqlDbType.Char, ColumnValue = dateFrom, ParamName = "@p1" });
                lstParam.Add(new ColumnData_Type { ColumnName = "ParminID_FK", ColumnType = SqlDbType.NVarChar, ColumnValue = parminPanelIDs, ParamName = "@p2" });
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialCode", ColumnType = SqlDbType.NVarChar, ColumnValue = socialCodes, ParamName = "@p3" });
                lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateIndex", ColumnType = SqlDbType.Char, ColumnValue = dateEnd, ParamName = "@p4" });


                var where = "";
                if (!string.IsNullOrWhiteSpace(dateFrom))
                {

                    where += "AND Tbl_SocialMediaPost.PosteDateIndex >=@p1 ";
                }
                if (!string.IsNullOrWhiteSpace(dateEnd))
                {

                    where += "AND Tbl_SocialMediaPost.PosteDateIndex <=@p4 ";
                }

                if (!string.IsNullOrWhiteSpace(userIds))
                {
                    where += "AND Tbl_SocialMediaPost.SocialMediaUserID_FK IN (" + userIds + ") ";
                }
                if (!string.IsNullOrWhiteSpace(keys))
                {
                    where += "AND Tbl_SocialMediaPost.SocialMediaKeyID_FK IN (" + keys + ") ";
                }
                if (!string.IsNullOrWhiteSpace(searchTag))
                {
                    where += "AND ( [Tbl_SocialMediaPost].[Text] LIKE '%" + searchTag + "%' OR [Tbl_SocialMediaPost].[Text] LIKE N'%" + searchTag + "%' )";
                }
                var sortSql = "";
                if (sorting == Social_Sorting.Date)
                {
                    sortSql = "ORDER BY Tbl_SocialMediaPost.PosteDateTimeIndex DESC";
                }
                else if (sorting == Social_Sorting.Like)
                {
                    sortSql = "ORDER BY Tbl_SocialMediaPost.LikeCount DESC";
                    SocialMediaPostID = null;
                    GreaterOrLeass = null;
                }
                else if (sorting == Social_Sorting.Retweets)
                {
                    sortSql = "ORDER BY Tbl_SocialMediaPost.RetweetCount DESC";
                    SocialMediaPostID = null;
                    GreaterOrLeass = null;
                }
                else if (sorting == Social_Sorting.Comment)
                {
                    sortSql = "ORDER BY Tbl_SocialMediaPost.CommentCount DESC";
                }
                else if (sorting == Social_Sorting.PostID)
                {
                    sortSql = "ORDER BY Tbl_SocialMediaPost.SocialMediaPostID DESC";
                }


                if (SocialMediaPostID != null && SocialMediaPostID > 0)
                {
                    if (GreaterOrLeass == true)
                    {
                        where += "AND Tbl_SocialMediaPost.SocialMediaPostID>" + SocialMediaPostID + " ";
                    }
                    else
                    {
                        where += "AND Tbl_SocialMediaPost.SocialMediaPostID<" + SocialMediaPostID + " ";
                    }

                }

                if (!string.IsNullOrWhiteSpace(postIds))
                {
                    where += "AND Tbl_SocialMediaPost.SocialMediaPostID IN (" + postIds + ")";

                }


                if (!string.IsNullOrWhiteSpace(where))
                {
                    where = @" WHERE Tbl_SocialMediaPost.Active=1 AND
                    Tbl_SocialMediaPost.SocialMediaKeyID_FK IN
                    (SELECT SocialMediaKeyID FROM Tbl_SocialMediaKey WHERE ParminID_FK IN(@p2) )  " + where;
                }
                else
                {
                    where = @" WHERE Tbl_SocialMediaPost.Active=1 AND
                    Tbl_SocialMediaPost.SocialMediaKeyID_FK IN
                    (SELECT SocialMediaKeyID FROM Tbl_SocialMediaKey WHERE ParminID_FK IN(@p2) ) ";
                }


                var rowWhere = "";
                if (skipCount != null && skipCount > 0)
                    rowWhere += " AND  RowNumber BETWEEN " + (((pageNumber * pageCount) - pageCount) + 1) + skipCount + " and " + (pageCount * pageNumber) + "";
                else
                {
                    rowWhere += " AND RowNumber BETWEEN " + (((pageNumber * pageCount) - pageCount) + 1) + " and " + (pageCount * pageNumber) + " ";
                }
                var sql2 = @"SELECT    Tbl_SocialMediaUser.UserCode AS User_UserCode,
                    Tbl_SocialMediaUser.UserName  AS User_UserName,
                    Tbl_SocialMediaUser.ScreenName  AS User_ScreenName,
                    Tbl_SocialMediaUser.PictureUrl  AS User_PictureUrl,
                 	Tbl_SocialMediaUser.Picture  AS User_Picture,
                    Tbl_SocialMediaPost.SocialMediaPostID, 
					Tbl_SocialMediaPost.SocialMediaKeyID_FK,
                    Tbl_SocialMediaPost.SocialMediaUserID_FK,
                    Tbl_SocialMediaPost.PosteDateTimeIndex,
                    Tbl_SocialMediaPost.Active,
                    Tbl_SocialMediaPost.Text,
                    Tbl_SocialMediaPost.UserName,
                    Tbl_SocialMediaPost.LikeCount,
                    Tbl_SocialMediaPost.CommentCount, 
                    Tbl_SocialMediaPost.PostDate, 
                    Tbl_SocialMediaPost.PosteDateIndex, 
                    Tbl_SocialMediaPost.RetweetCount,
                    Tbl_SocialMediaPost.Lang,
                    Tbl_SocialMediaPost.LinkUrl,
                    Tbl_SocialMediaPost.LinkUrlCRC,
                    Tbl_SocialMediaPost.CreateDate,
                    Tbl_SocialMediaKey.Title  AS Key_Title

                    FROM(SELECT 

                    Tbl_SocialMediaPost.SocialMediaPostID, 
                    Tbl_SocialMediaPost.SocialMediaKeyID_FK,
                    Tbl_SocialMediaPost.SocialMediaUserID_FK,
                    Tbl_SocialMediaPost.Active,
                    Tbl_SocialMediaPost.Text,
                    Tbl_SocialMediaPost.UserName,
                    Tbl_SocialMediaPost.LikeCount,
                    Tbl_SocialMediaPost.CommentCount, 
                    Tbl_SocialMediaPost.PostDate, 
                    Tbl_SocialMediaPost.PosteDateIndex, 
                    Tbl_SocialMediaPost.RetweetCount,
                    Tbl_SocialMediaPost.Lang,
                    Tbl_SocialMediaPost.LinkUrl,
                    Tbl_SocialMediaPost.LinkUrlCRC,
                    Tbl_SocialMediaPost.CreateDate,
                    Tbl_SocialMediaPost.PosteDateTimeIndex,

    ROW_NUMBER() OVER (" + sortSql + @") AS RowNumber,
    COUNT(*) OVER() AS TotalRows
     FROM  Tbl_SocialMediaPost  " + where + @")
       AS Tbl_SocialMediaPost
	   
	   INNER JOIN[Tbl_SocialMediaUser]  ON  [Tbl_SocialMediaPost].SocialMediaUserID_FK=[Tbl_SocialMediaUser].[SocialMediaUserID] 
                    INNER JOIN[Tbl_SocialMediaKey]  ON  [Tbl_SocialMediaPost].SocialMediaKeyID_FK=[Tbl_SocialMediaKey].[SocialMediaKeyID] 
                  
	   
	    WHERE  Tbl_SocialMediaPost.Active=1 AND
                    Tbl_SocialMediaPost.SocialMediaKeyID_FK IN 
                    (SELECT SocialMediaKeyID FROM Tbl_SocialMediaKey WHERE ParminID_FK IN (@p2) ) AND [Tbl_SocialMediaUser].[SocialCode] IN (@p3)   " + rowWhere + " " + sortSql;



                var res = _clsAdo.FillDatabaseParametric("", sql2, lstParam);

                var lst = Class_Static.ConvertDataTableToClass<Tbl_SocialMediaPost_Type>(res);
                foreach (var item in lst)
                {
                    item.TimeAgo = Class_Static.GetOnTimeDate(item.PostDate);
                    item.TimeAgoShow = Class_Static.ShamsiBySlash(item.PosteDateIndex) + " - " + item.PostDate.Hour + ":" + item.PostDate.Minute;
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }

        public List<Tbl_SocialMediaPost_Type> SelectAll(int SocialMediaKeyID_FK, string where, string sortBy, string sortField)
        {
            if (string.IsNullOrWhiteSpace(where))
            {
                where = " WHERE SocialMediaKeyID_FK=" + SocialMediaKeyID_FK;
            }
            else
            {
                where += " AND SocialMediaKeyID_FK=" + SocialMediaKeyID_FK;

            }
            where += " AND (Active=1)";
            var item = new List<Tbl_SocialMediaPost_Type>();

            var lstParam = new List<ColumnData_Type>();

            var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " " + where + " ORDER BY " + sortField + " " + sortBy + " ", lstParam);

            item = Class_Static.ConvertDataTableToClass<Tbl_SocialMediaPost_Type>(res);


            return item;
        }

        public Tbl_SocialMediaPost_Type SelectItem(int id)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = id, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE " + KeyID + "=@p1 AND [Active]=1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaPost_Type>(res).FirstOrDefault();

            }
            catch
            {
                return null;

            }

        }

        public int InsertItem(Tbl_SocialMediaPost_Type item)
        {
            var lstParam = new List<ColumnData_Type>();
            lstParam.Add(new ColumnData_Type { ColumnName = "Active", ColumnType = SqlDbType.Bit, ColumnValue = item.Active, ParamName = "@p1", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CommentCount", ColumnType = SqlDbType.Int, ColumnValue = item.CommentCount, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Lang", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Lang, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LikeCount", ColumnType = SqlDbType.Int, ColumnValue = item.LikeCount, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LinkUrl", ColumnType = SqlDbType.NVarChar, ColumnValue = item.LinkUrl, ParamName = "@p5", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LinkUrlCRC", ColumnType = SqlDbType.BigInt, ColumnValue = item.LinkUrlCRC, ParamName = "@p6", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "PostDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.PostDate, ParamName = "@p7", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateIndex", ColumnType = SqlDbType.Char, ColumnValue = item.PosteDateIndex, ParamName = "@p8", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "RetweetCount", ColumnType = SqlDbType.Int, ColumnValue = item.RetweetCount, ParamName = "@p9", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaKeyID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaKeyID_FK, ParamName = "@p10", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Text", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Text, ParamName = "@p11", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "UserName", ColumnType = SqlDbType.NVarChar, ColumnValue = item.UserName, ParamName = "@p12", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p13", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaUserID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaUserID_FK, ParamName = "@p14", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "SocialPostID", ColumnType = SqlDbType.BigInt, ColumnValue = item.SocialPostID, ParamName = "@p15", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateTimeIndex", ColumnType = SqlDbType.Char, ColumnValue = item.PosteDateTimeIndex, ParamName = "@p16", IsWhereParam = false });

            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.INSERT, lstParam, KeyID);
            return res;

        }

        public bool CheckDuplicate(long postID, int userID, int keyID)
        {



            try
            {




                Class_Ado _clsAdo = new Class_Ado();

                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialPostID", ColumnType = SqlDbType.BigInt, ColumnValue = postID, ParamName = "@p1" });

                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaUserID_FK", ColumnType = SqlDbType.Int, ColumnValue = userID, ParamName = "@p2" });
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaKeyID_FK", ColumnType = SqlDbType.Int, ColumnValue = keyID, ParamName = "@p3" });


                var query = _clsAdo.FillDatabaseParametric(Class_Static.conn, "SELECT " + KeyID + " FROM " + TableName + " WHERE SocialPostID=@p1 AND SocialMediaUserID_FK=@p2 AND SocialMediaKeyID_FK=@p3", lstParam);
                var lst = new List<Tbl_SocialMediaPost_Type>();
                foreach (DataRow dr in query.Rows)
                {

                    try
                    {
                        var item = new Tbl_SocialMediaPost_Type();

                        item.SocialMediaPostID = Convert.ToInt32(dr["SocialMediaPostID"]);


                        lst.Add(item);
                    }
                    catch
                    {
                        continue;
                    }
                }




                if (lst == null)
                {
                    return true;
                }

                if (lst.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }



            }
            catch (Exception ex)
            {

                //  Program.WriteLogException(ex, "Class_Threading-CheckDuplicate");

                return true;
            }
        }
      
        public int UpdateItem(Tbl_SocialMediaPost_Type item)
        {
            var lstParam = new List<ColumnData_Type>();

            lstParam.Add(new ColumnData_Type { ColumnName = "Active", ColumnType = SqlDbType.Bit, ColumnValue = item.Active, ParamName = "@p1", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CommentCount", ColumnType = SqlDbType.Int, ColumnValue = item.CommentCount, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Lang", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Lang, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LikeCount", ColumnType = SqlDbType.Int, ColumnValue = item.LikeCount, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LinkUrl", ColumnType = SqlDbType.NVarChar, ColumnValue = item.LinkUrl, ParamName = "@p5", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LinkUrlCRC", ColumnType = SqlDbType.BigInt, ColumnValue = item.LinkUrlCRC, ParamName = "@p6", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "PostDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.PostDate, ParamName = "@p7", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateIndex", ColumnType = SqlDbType.Char, ColumnValue = item.PosteDateIndex, ParamName = "@p8", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "RetweetCount", ColumnType = SqlDbType.Int, ColumnValue = item.RetweetCount, ParamName = "@p9", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaKeyID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaKeyID_FK, ParamName = "@p10", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Text", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Text, ParamName = "@p11", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "UserName", ColumnType = SqlDbType.NVarChar, ColumnValue = item.UserName, ParamName = "@p12", IsWhereParam = false });



            lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaPostID, ParamName = "@p88", IsWhereParam = true });

            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.UPDATE, lstParam, KeyID);
            return res;

        }
        public int UpdateItemDateTimeIndex(Tbl_SocialMediaPost_Type item)
        {
            var lstParam = new List<ColumnData_Type>();



            lstParam.Add(new ColumnData_Type { ColumnName = "PosteDateTimeIndex", ColumnType = SqlDbType.NVarChar, ColumnValue = item.PosteDateTimeIndex, ParamName = "@p12", IsWhereParam = false });



            lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaPostID, ParamName = "@p88", IsWhereParam = true });

            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.UPDATE, lstParam, KeyID);
            return res;

        }
        public int DeleteItem(int id)
        {

            try
            {
                Class_Ado _clsAdo = new Class_Ado();
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "Active", ColumnType = SqlDbType.Bit, ColumnValue = false, ParamName = "@p1", IsWhereParam = false });


                lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Char, ColumnValue = id, ParamName = "@p2", IsWhereParam = true });

                return _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.UPDATE, lstParam, KeyID);

            }
            catch
            {
                return 0;
            }

        }
    }
}
