using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PArtCore.Class
{
    public class Class_Core_Sites
    {
        Class_Ado _clsAdo = new Class_Ado();
        public Tbl_Sites_Type SelectSingle(int siteID)
        {
            var item = new Tbl_Sites_Type();
            var lstParam = new List<ColumnData_Type>();

            var query = @"select * FROM Tbl_Sites  WHERE SiteID=" + siteID + " Order BY SiteID ASC ";
            var res = _clsAdo.FillDatabaseParametric("", query, lstParam);
            if (res != null)
            {
                item = Class_Static.ConvertDataTableToClass<Tbl_Sites_Type>(res).FirstOrDefault();

            }
            return item;
        }

        public List<Tbl_Sites_Type> SelectAll()
        {
            var item = new List<Tbl_Sites_Type>();
            var lstParam = new List<ColumnData_Type>();

            var query = @"select * FROM Tbl_Sites  Order BY SiteID ASC ";
            var res = _clsAdo.FillDatabaseParametric("", query, lstParam);
            if (res != null)
            {
                item = Class_Static.ConvertDataTableToClass<Tbl_Sites_Type>(res);

            }
            return item;
        }
    }
}
