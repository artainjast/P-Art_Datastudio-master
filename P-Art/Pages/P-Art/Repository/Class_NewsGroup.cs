using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_NewsGroup
    {
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public List<Tbl_NewsGroup> GetGroupsByPanelIds(List<int?> PanelIds)
        {
            var query = from gr in _db.Tbl_NewsGroup
                        where PanelIds.Contains(gr.ParminId)
                        select gr;

            return query.ToList();

        }
        public List<Tbl_NewsGroup> GetGroupsByIds(List<int> Ids)
        {
            var query = from gr in _db.Tbl_NewsGroup
                        where Ids.Contains(gr.GroupId)
                        select gr;

            return query.ToList();

        }
    }
}