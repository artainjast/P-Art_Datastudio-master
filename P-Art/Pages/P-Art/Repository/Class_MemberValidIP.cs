using P_Art.Pages.P_Art.ModelNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_MemberValidIP
    {
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public List<Tbl_MemberValidIP> SelectSingle(List<int?> parminIds)
        {

            return _db.Tbl_MemberValidIP.Where(t => parminIds.Contains(t.ParminID_FK)).ToList();
        }
    }
}