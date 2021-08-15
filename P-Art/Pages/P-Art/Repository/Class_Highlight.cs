using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Highlight
    {
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public Tbl_Highlight GetHighlightByParminId(List<int?> parminId,int siteId)
        {
            var query = (from high in _db.Tbl_Highlight
                         where parminId.Contains(high.ParminId)
                         && high.SiteId == siteId
                         select high).FirstOrDefault();
            return query;

        }
    }
}