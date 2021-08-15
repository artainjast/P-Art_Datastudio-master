using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
    public class Class_Core_SocialMediaUser
    {
        Class_Ado _clsAdo = new Class_Ado();
        public string KeyID = "SocialMediaUserID";
        public string KeyOrder = "SocialMediaUserID";
        public string TableName = "Tbl_SocialMediaUser";

        public List<Tbl_SocialMediaUser_Type> SelectAll()
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();


                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE  [Active]=1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaUser_Type>(res);

            }
            catch
            {
                return null;
            }
        }

        public Tbl_SocialMediaUser_Type SelectItem(int id)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = id, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE " + KeyID + "=@p1 AND [Active]=1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaUser_Type>(res).FirstOrDefault();

            }
            catch
            {
                return null;

            }

        }

        public int InsertItem(Tbl_SocialMediaUser_Type item)
        {

            var lstParam = new List<ColumnData_Type>();
            lstParam.Add(new ColumnData_Type { ColumnName = "Active", ColumnType = SqlDbType.Bit, ColumnValue = item.Active, ParamName = "@p1", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateAt", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateAt, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Description", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Description, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "FavouritesCount", ColumnType = SqlDbType.Int, ColumnValue = item.FavouritesCount, ParamName = "@p5", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "FollowersCount", ColumnType = SqlDbType.Int, ColumnValue = item.FollowersCount, ParamName = "@p6", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "FriendsCount", ColumnType = SqlDbType.Int, ColumnValue = item.FriendsCount, ParamName = "@p7", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Language", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Language, ParamName = "@p8", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Location", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Location, ParamName = "@p9", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "PictureUrl", ColumnType = SqlDbType.NVarChar, ColumnValue = item.PictureUrl, ParamName = "@p10", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "RetweetsCount", ColumnType = SqlDbType.Int, ColumnValue = item.RetweetsCount, ParamName = "@p11", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "ScreenName", ColumnType = SqlDbType.NVarChar, ColumnValue = item.ScreenName, ParamName = "@p12", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "SocialCode", ColumnType = SqlDbType.Int, ColumnValue = item.SocialCode, ParamName = "@p13", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Url", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Url, ParamName = "@p14", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "UserCode", ColumnType = SqlDbType.NVarChar, ColumnValue = item.UserCode, ParamName = "@p15", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "UserName", ColumnType = SqlDbType.NVarChar, ColumnValue = item.UserName, ParamName = "@p16", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "Picture", ColumnType = SqlDbType.VarBinary, ColumnValue = item.Picture, ParamName = "@p17", IsWhereParam = false });

            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.INSERT, lstParam, KeyID);
            return res;

        }


        public int CheckDuplicate(string usercode, int SocialCode)
        {
            var retVal = 0;


            try
            {
                Class_Ado _clsAdo = new Class_Ado();

                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "UserCode", ColumnType = SqlDbType.NVarChar, ColumnValue = usercode, ParamName = "@usercode" });
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialCode", ColumnType = SqlDbType.Int, ColumnValue = SocialCode, ParamName = "@socialCode" });

                var sql = "SELECT " + KeyID + " FROM " + TableName + " WHERE SocialCode=@socialCode AND UserCode=@usercode";
                var query = _clsAdo.FillDatabaseParametric(Class_Static.conn, sql, lstParam);
                var lst = new List<Tbl_SocialMediaUser_Type>();
                foreach (DataRow dr in query.Rows)
                {

                    try
                    {
                        var item = new Tbl_SocialMediaUser_Type();

                        item.SocialMediaUserID = Convert.ToInt32(dr["SocialMediaUserID"]);

                        retVal = item.SocialMediaUserID;
                        lst.Add(item);
                    }
                    catch
                    {
                        continue;
                    }
                }





            }
            catch (Exception ex)
            {

                //  Program.WriteLogException(ex, "Class_Threading-CheckDuplicate");


            }
            return retVal;
        }

        public int UpdateItem(Tbl_SocialMediaUser_Type item)
        {
            var lstParam = new List<ColumnData_Type>();

            lstParam.Add(new ColumnData_Type { ColumnName = "Active", ColumnType = SqlDbType.Bit, ColumnValue = item.Active, ParamName = "@p1", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateAt", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateAt, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Description", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Description, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "FavouritesCount", ColumnType = SqlDbType.Int, ColumnValue = item.FavouritesCount, ParamName = "@p5", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "FollowersCount", ColumnType = SqlDbType.Int, ColumnValue = item.FollowersCount, ParamName = "@p6", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "FriendsCount", ColumnType = SqlDbType.Int, ColumnValue = item.FriendsCount, ParamName = "@p7", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Language", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Language, ParamName = "@p8", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Location", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Location, ParamName = "@p9", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "PictureUrl", ColumnType = SqlDbType.NVarChar, ColumnValue = item.PictureUrl, ParamName = "@p10", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "RetweetsCount", ColumnType = SqlDbType.Int, ColumnValue = item.RetweetsCount, ParamName = "@p11", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "ScreenName", ColumnType = SqlDbType.NVarChar, ColumnValue = item.ScreenName, ParamName = "@p12", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "SocialCode", ColumnType = SqlDbType.Int, ColumnValue = item.SocialCode, ParamName = "@p13", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Url", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Url, ParamName = "@p14", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "UserCode", ColumnType = SqlDbType.NVarChar, ColumnValue = item.UserCode, ParamName = "@p15", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "UserName", ColumnType = SqlDbType.NVarChar, ColumnValue = item.UserName, ParamName = "@p16", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = "Picture", ColumnType = SqlDbType.VarBinary, ColumnValue = item.Picture, ParamName = "@p17", IsWhereParam = false });

            lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaUserID, ParamName = "@p88", IsWhereParam = true });

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
