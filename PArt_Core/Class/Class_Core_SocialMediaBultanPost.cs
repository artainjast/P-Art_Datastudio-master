using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
    public class Class_Core_SocialMediaBultanPost
    {
        Class_Ado _clsAdo = new Class_Ado();

        public string KeyID = "SocialMediaBultanPostID";
        public string KeyOrder = "SocialMediaBultanPostID";
        public string TableName = "Tbl_SocialMediaBultanPost";

        public bool CheckDuplicate(long postID, int bultanID)
        {



            try
            {




                Class_Ado _clsAdo = new Class_Ado();



                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaPostID_FK", ColumnType = SqlDbType.Int, ColumnValue = postID, ParamName = "@p1" });

                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaBultanID_FK", ColumnType = SqlDbType.Int, ColumnValue = bultanID, ParamName = "@p2" });


                var query = _clsAdo.FillDatabaseParametric(Class_Static.conn, "SELECT " + KeyID + " FROM " + TableName + " WHERE SocialMediaPostID_FK=@p1 AND SocialMediaBultanID_FK=@p2", lstParam);
                var lst = new List<Tbl_SocialMediaBultanPost_Type>();
                foreach (DataRow dr in query.Rows)
                {

                    try
                    {
                        var item = new Tbl_SocialMediaBultanPost_Type();

                        item.SocialMediaBultanPostID = Convert.ToInt32(dr["SocialMediaBultanPostID"]);


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

        public List<Tbl_SocialMediaBultanPost_Type> SelectAll(int bultanId)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaBultanID_FK", ColumnType = SqlDbType.Int, ColumnValue = bultanId, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE SocialMediaBultanID_FK=@p1", lstParam);
                var res1= Class_Static.ConvertDataTableToClass<Tbl_SocialMediaBultanPost_Type>(res);

                foreach(var item in res1)
                {
                    
                }

                return res1;

            }
            catch
            {
                return null;
            }
        }
        public List<Tbl_SocialMediaBultanPost_Type> SelectAll(string bultanIds)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaBultanID_FK", ColumnType = SqlDbType.NVarChar, ColumnValue = bultanIds, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE SocialMediaBultanID_FK IN (@p1)", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaBultanPost_Type>(res);

            }
            catch
            {
                return null;
            }
        }
        public string SelectAllPostIds(int bultanId)
        {
            var resStr = "";
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaBultanID_FK", ColumnType = SqlDbType.Int, ColumnValue = bultanId, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT SocialMediaPostID_FK FROM " + TableName + " WHERE SocialMediaBultanID_FK=@p1", lstParam);
                if (res != null)
                {
                    foreach (DataRow dr in res.Rows)
                    {
                        try
                        {
                            var st = "," + dr["SocialMediaPostID_FK"];
                            if (resStr.Contains(st))
                            {
                                continue;
                            }
                            else
                            {
                                resStr += st;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(resStr))
                {
                    resStr = resStr.Substring(1);
                }

            }
            catch (Exception ex)
            {
            }
            return resStr;

        }
        public Tbl_SocialMediaBultanPost_Type SelectItem(int id)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = id, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE " + KeyID + "=@p1 ", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaBultanPost_Type>(res).FirstOrDefault();

            }
            catch
            {
                return null;

            }

        }

        public int InsertItem(Tbl_SocialMediaBultanPost_Type item)
        {
            var lstParam = new List<ColumnData_Type>();
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p1", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateUser_FK", ColumnType = SqlDbType.Int, ColumnValue = item.CreateUser_FK, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "OrderNumber", ColumnType = SqlDbType.Int, ColumnValue = item.OrderNumber, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaBultanID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaBultanID_FK, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaPostID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaPostID_FK, ParamName = "@p5", IsWhereParam = false });


            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.INSERT, lstParam, KeyID);
            return res;

        }
        public int UpdateItem(Tbl_SocialMediaBultanPost_Type item)
        {
            var lstParam = new List<ColumnData_Type>();

            //lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p1", IsWhereParam = false });
            //lstParam.Add(new ColumnData_Type { ColumnName = "CreateUser_FK", ColumnType = SqlDbType.Int, ColumnValue = item.CreateUser_FK, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "OrderNumber", ColumnType = SqlDbType.Int, ColumnValue = item.OrderNumber, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaBultanID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaBultanID_FK, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "SocialMediaPostID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaPostID_FK, ParamName = "@p5", IsWhereParam = false });


            lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaBultanPostID, ParamName = "@p88", IsWhereParam = true });

            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.UPDATE, lstParam, KeyID);
            return res;

        }
        public int DeleteItem(int id)
        {

            try
            {
                Class_Ado _clsAdo = new Class_Ado();
                var lstParam = new List<ColumnData_Type>();

                lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = id, ParamName = "@p2", IsWhereParam = true });

                return _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.UPDATE, lstParam, KeyID);

            }
            catch
            {
                return 0;
            }

        }
    }
}
