using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
   public class Class_Core_Tbl_SocialMediaMember
    {
        Class_Ado _clsAdo = new Class_Ado();
        public string KeyID = "SocialMediaMemberID";
        public string KeyOrder = "SocialMediaMemberID";
        public string TableName = "Tbl_SocialMediaMember";
        public List<Tbl_SocialMediaMember_Type> SelectAll()
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
              
                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE  [Active]=1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaMember_Type>(res);

            }
            catch
            {
                return null;
            }
        }
        public List<Tbl_SocialMediaMember_Type> SelectAll(int panelId)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "ParminID_FK", ColumnType = SqlDbType.Int, ColumnValue = panelId, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE ParminID_FK=@p1 AND [Active]=1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaMember_Type>(res);

            }
            catch
            {
                return null;
            }
        }
      

        public Tbl_SocialMediaMember_Type SelectItem(int id)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = KeyID, ColumnType = SqlDbType.Int, ColumnValue = id, ParamName = "@p1" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE " + KeyID + "=@p1 AND [Active]=1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaMember_Type>(res).FirstOrDefault();

            }
            catch
            {
                return null;

            }

        }
        public Tbl_SocialMediaMember_Type DoLogin(string username,string password)
        {
            try
            {
                var lstParam = new List<ColumnData_Type>();
                lstParam.Add(new ColumnData_Type { ColumnName = "Username", ColumnType = SqlDbType.NChar, ColumnValue = username, ParamName = "@p1" });
                lstParam.Add(new ColumnData_Type { ColumnName = "Password", ColumnType = SqlDbType.NChar, ColumnValue = password, ParamName = "@p2" });

                var res = _clsAdo.FillDatabaseParametric("", "SELECT * FROM " + TableName + " WHERE Username=@p1 AND Password=@p2 AND [Active]=1", lstParam);
                return Class_Static.ConvertDataTableToClass<Tbl_SocialMediaMember_Type>(res).FirstOrDefault();

            }
            catch
            {
                return null;

            }

        }
        public int InsertItem(Tbl_SocialMediaMember_Type item)
        {
            var lstParam = new List<ColumnData_Type>();
            lstParam.Add(new ColumnData_Type { ColumnName = "Active", ColumnType = SqlDbType.Bit, ColumnValue = item.Active, ParamName = "@p1", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "CreateDate", ColumnType = SqlDbType.DateTime, ColumnValue = item.CreateDate, ParamName = "@p2", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Password", ColumnType = SqlDbType.NChar, ColumnValue = item.Password, ParamName = "@p3", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "ParminID_FK", ColumnType = SqlDbType.Int, ColumnValue = item.ParminID_FK, ParamName = "@p4", IsWhereParam = false });
            lstParam.Add(new ColumnData_Type { ColumnName = "Username", ColumnType = SqlDbType.NChar, ColumnValue = item.Username, ParamName = "@p5", IsWhereParam = false });



            var res = _clsAdo.ExecuteSQLParametric("", TableName, SqlOperation_Type.INSERT, lstParam, KeyID);
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
