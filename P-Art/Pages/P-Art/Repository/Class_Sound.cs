using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Sound
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public List<Tbl_Radio> GetAllSound(int PageCount, int PageIndex, List<int?> PanelIds)
        {


            IQueryable<Tbl_Radio> query;

            query = (from t in _db.Tbl_Radio
                     where
                         (from t0 in _db.Tbl_Relation_RadioParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.SoundId).Contains(t.SoundID)
                          && t.Type == 0
                     orderby t.SoundDateIndex descending
                     select t).Skip(PageIndex).Take(PageCount);



            return query.ToList();

        }
        public Tbl_Radio GetRadioById(int SoundId, List<int?> PanelIds)
        {
            var query = (from t in _db.Tbl_Radio
                         where
                             (from t0 in _db.Tbl_Relation_RadioParminPanel
                              where
                              PanelIds.Contains(t0.ParminPanelId)
                              select t0.SoundId).Contains(t.SoundID)
                              && t.SoundID == SoundId
                         orderby t.SoundID descending
                         select t).FirstOrDefault();
            return query;
        }
        public long GetRadioCount(List<int?> PanelIds, bool? IsView)
        {
            IQueryable<Tbl_Radio> query;

            query = from t in _db.Tbl_Radio
                    where
                        (from t0 in _db.Tbl_Relation_RadioParminPanel
                         where
                         PanelIds.Contains(t0.ParminPanelId)
                         select t0.SoundId).Contains(t.SoundID)
                    orderby t.SoundID descending
                    select t;

            return query.Count();
        }
    }
}