using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
    public class Class_Core_Keyword
    {
        Class_Ado _clsAdo = new Class_Ado();
        public List<Tbl_RssKeywords_Type> SelectAll(string parminIds)
        {
            var item = new List<Tbl_RssKeywords_Type>();
            var lstParam = new List<ColumnData_Type>();

            var query = @"select * FROM Tbl_RssKeywords  WHERE PanelId IN (" + parminIds + ") Order BY OrderItem ASC ";
            var res = _clsAdo.FillDatabaseParametric("", query, lstParam);
            if (res != null)
            {
                item = Class_Static.ConvertDataTableToClass<Tbl_RssKeywords_Type>(res);

            }
            return item;
        }

        public Tbl_RssKeywords_Type SelectSingle(int id)
        {
            var item = new Tbl_RssKeywords_Type();
            var lstParam = new List<ColumnData_Type>();

            var query = @"select * FROM Tbl_RssKeywords  WHERE KeyId IN (" + id + ") Order BY OrderItem ASC ";
            var res = _clsAdo.FillDatabaseParametric("", query, lstParam);
            if (res != null)
            {
                item = Class_Static.ConvertDataTableToClass<Tbl_RssKeywords_Type>(res).FirstOrDefault();

            }
            return item;
        }
    }
}
