using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using System.Data;
using System.Data.SqlClient;
using PArt.Core;
using System.Text;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Twitter
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        Class_Panels cls_panel = new Class_Panels();
        Class_Ado _clsAdo = new Class_Ado();
        Class_Zaman _clsZm = new Class_Zaman();

        public List<Tbl_TwitterPost> GetAllTwiiterIds(List<long> NewsIds)
        {
            var query = from news in _db.Tbl_TwitterPost
                        where NewsIds.Contains(news.ID)
                        select news;
            return query.ToList();

        }
    }
}