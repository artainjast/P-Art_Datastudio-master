using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
   public class Class_Core_SocialMediaBultan
    {
        Class_Ado _clsAdo = new Class_Ado();
        public string KeyID = "SocialMediaBultanID";
        public string KeyOrder = "SocialMediaBultanID";
        public string TableName = "Tbl_SocialMediaBultan";

        public List<Tbl_SocialMediaBultan_Type> SelectAll(int panelId)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "ParminID_FK", ColumnType = SqlDbType.Int, ColumnValue = panelId, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE ParminID_FK=@p1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaBultan_Type>(res);

            }
            catch
            {
                return null;
            }
        }
        public List<Tbl_SocialMediaBultan_Type> SelectAll(string panelId)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "ParminID_FK", ColumnType = SqlDbType.NVarChar, ColumnValue = panelId, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE ParminID_FK IN (@p1)", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaBultan_Type>(res);

            }
            catch
            {
                return null;
            }
        }

        public Tbl_SocialMediaBultan_Type SelectItem(int id)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = id, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE " + KeyID + "=@p1 ", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaBultan_Type>(res).FirstOrDefault();

            }
            catch
            {
                return null;

            }

        }

        public int InsertItem(Tbl_SocialMediaBultan_Type item)
        {
            var lstParam = new List<ColumnData_Type>();
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p1", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateUser_FK", ColumnType = SqlDbType.Int, ColumnValue = item.CreateUser_FK, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LastPDFPath", ColumnType = SqlDbType.NVarChar, ColumnValue = item.LastPDFPath, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LastWordPath", ColumnType = SqlDbType.NVarChar, ColumnValue = item.LastWordPath, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "ParminID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.ParminID_FK, ParamName = "@p5", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Title", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Title, ParamName = "@p6", IsWhereParam = false });
        

            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.INSERT, lstParam, KeyID);
            return res;

        }
        public int UpdateItem(Tbl_SocialMediaBultan_Type item)
        {
            var lstParam = new List<ColumnData_Type>();

            //lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p1", IsWhereParam = false });
            //lstParam.Add(new ColumnData_Type { ColumnName = "CreateUser_FK", ColumnType = SqlDbType.Int, ColumnValue = item.CreateUser_FK, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LastPDFPath", ColumnType = SqlDbType.NVarChar, ColumnValue = item.LastPDFPath, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "LastWordPath", ColumnType = SqlDbType.NVarChar, ColumnValue = item.LastWordPath, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "ParminID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.ParminID_FK, ParamName = "@p5", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Title", ColumnType = SqlDbType.NVarChar, ColumnValue = item.Title, ParamName = "@p6", IsWhereParam = false });


            lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = item.SocialMediaBultanID, ParamName = "@p88", IsWhereParam = true });

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
