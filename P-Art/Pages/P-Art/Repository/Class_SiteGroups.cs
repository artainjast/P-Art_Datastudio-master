using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_SiteGroups
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public List<Tbl_SiteGroups> GetSiteGroup()
        {
            var query = from site in _db.Tbl_SiteGroups
                        select site;
            return query.ToList();

        }
    }
}