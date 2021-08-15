using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using P_Art.Pages.P_Art.ModelNews;
using PArtCore.Class;

namespace P_Art.Pages.P_Art.Repository
{
    public enum BultanType : byte
    {
        Pdf = 1,
        GroupHtml = 2
    }
    public class Class_BultanArchive
    {
        DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        public Tbl_BultanArchive InsertArchive(long NewsDateIndex, int panelId, string Path, string title, string newsids)
        {
            // var user = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == userId);
            // var parminId = Convert.ToInt32(user.ParminIds.Split(',')[0]);
            var parmin = db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == panelId);
            if (parmin.hdParmin == true) return null;

            var newItem = new Tbl_BultanArchive();
            newItem.PanelId = panelId;
            newItem.Path = Path;
            newItem.NewsDateIndex = NewsDateIndex;
            newItem.Name = title;
            newItem.SelectedNews = newsids;
            db.Tbl_BultanArchive.Add(newItem);
            db.SaveChanges();
            return newItem;

        }
        public int InsertArchive(long NewsDateIndex, int panelId, string Path, string title, string newsids,
          string fromDate, string toDate, string fromTime, string toTime, bool allowNewspaper, bool galleryNewspaper,
          bool arz, bool sima, bool highLight,
            bool allowGroup, bool related, int selectedBultan, bool isArchive, bool chart, bool jeld, byte BultanType)
        {
            // var user = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == userId);
            // var parminId = Convert.ToInt32(user.ParminIds.Split(',')[0]);
            var parmin = db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == panelId);
            if (parmin.hdParmin == true) return 0;
            int ArchiveId = 0;
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
                new SqlParameter("@" + "NewsDateIndex",NewsDateIndex),
                new SqlParameter("@" + "panelId",panelId),
                new SqlParameter("@" + "Path",Path),
                new SqlParameter("@" + "title",title),
                new SqlParameter("@" + "newsids",newsids),
                new SqlParameter("@" + "fromDate",fromDate),
                new SqlParameter("@" + "toDate",toDate),
                new SqlParameter("@" + "fromTime",fromTime),
                new SqlParameter("@" + "toTime",toTime),
                new SqlParameter("@" + "allowNewspaper",allowNewspaper),
                new SqlParameter("@" + "galleryNewspaper",galleryNewspaper),
                new SqlParameter("@" + "arz",arz),
                new SqlParameter("@" + "sima",sima),
                new SqlParameter("@" + "highLight",highLight),
                new SqlParameter("@" + "allowGroup",allowGroup),
                new SqlParameter("@" + "related",related),
                new SqlParameter("@" + "selectedBultan",selectedBultan),
                new SqlParameter("@" + "isArchive",isArchive),
                new SqlParameter("@" + "chart",chart),
                new SqlParameter("@" + "jeld",jeld),
                new SqlParameter("@" + "BultanType",BultanType),
                new SqlParameter("@" + "mode","insert"),
        };
            int archiveId = Convert.ToInt32(Class_Static.ExecuteScalar("", "p_BooltanArchieve_Update", CommandType.StoredProcedure, sqlParams));
            return archiveId;

        }
        public int InsertArchive(long NewsDateIndex, int panelId, string Path, string title, string newsids,
string fromDate, string toDate, string fromTime, string toTime, bool arz, bool sima, bool allowGroup,
bool highLight, byte BultanType)
        {

            var parmin = db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == panelId);
            if (parmin.hdParmin == true) return 0;
            int ArchiveId = 0;
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
                new SqlParameter("@" + "NewsDateIndex",NewsDateIndex),
                new SqlParameter("@" + "panelId",panelId),
                new SqlParameter("@" + "Path",Path),
                new SqlParameter("@" + "title",title),
                new SqlParameter("@" + "newsids",newsids),
                new SqlParameter("@" + "fromDate",fromDate),
                   new SqlParameter("@" + "arz",arz),
                new SqlParameter("@" + "sima",sima),
                new SqlParameter("@" + "toDate",toDate),
                new SqlParameter("@" + "fromTime",fromTime),
                new SqlParameter("@" + "toTime",toTime),
                  new SqlParameter("@" + "allowGroup",allowGroup),
                new SqlParameter("@" + "highLight",highLight),

                new SqlParameter("@" + "BultanType",BultanType),
                new SqlParameter("@" + "mode","insert"),
        };
            int archiveId = Convert.ToInt32(Class_Static.ExecuteScalar("", "p_BooltansocialArchieve_Update", CommandType.StoredProcedure, sqlParams));
            return archiveId;

        }

        public int InsertArchive(long NewsDateIndex, int panelId, string Path, string title, string newsids,
  string fromDate, string toDate, string fromTime, string toTime, bool arz, bool sima, bool allowGroup,
 bool highLight,
      bool jeld, byte BultanType)
        {
            // var user = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == userId);
            // var parminId = Convert.ToInt32(user.ParminIds.Split(',')[0]);
            var parmin = db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == panelId);
            if (parmin.hdParmin == true) return 0;
            int ArchiveId = 0;
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
                new SqlParameter("@" + "NewsDateIndex",NewsDateIndex),
                new SqlParameter("@" + "panelId",panelId),
                new SqlParameter("@" + "Path",Path),
                new SqlParameter("@" + "title",title),
                new SqlParameter("@" + "newsids",newsids),
                new SqlParameter("@" + "fromDate",fromDate),
                   new SqlParameter("@" + "arz",arz),
                new SqlParameter("@" + "sima",sima),
                new SqlParameter("@" + "toDate",toDate),
                new SqlParameter("@" + "fromTime",fromTime),
                new SqlParameter("@" + "toTime",toTime),
                  new SqlParameter("@" + "allowGroup",allowGroup),
                new SqlParameter("@" + "highLight",highLight),

                new SqlParameter("@" + "jeld",jeld),
                new SqlParameter("@" + "BultanType",BultanType),
                new SqlParameter("@" + "mode","insert"),
        };
            int archiveId = Convert.ToInt32(Class_Static.ExecuteScalar("", "p_BooltanInternationalArchieve_Update", CommandType.StoredProcedure, sqlParams));
            return archiveId;

        }

        public int InsertSocialArchive(long NewsDateIndex, int ParminID_FK, string Path, string title, string SelectedPosts, bool chart)
        {

            var parmin = db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == ParminID_FK);
            if (parmin.hdParmin == true) return 0;
            int SocialMediaBultanID = 0;
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "SocialMediaBultanID",SocialMediaBultanID),
                
                new SqlParameter("@" + "ParminID_FK ",ParminID_FK ),
                new SqlParameter("@" + "LastPDFPath",Path),
                new SqlParameter("@" + "Title",title),
                new SqlParameter("@" + "SelectedPosts",SelectedPosts),

                   new SqlParameter("@" + "chart",chart),

                   new SqlParameter("@" + "NewsDateIndex",NewsDateIndex),

                new SqlParameter("@" + "mode","insert"),
        };
            int SocialMediaBultanId = Convert.ToInt32(Class_Static.ExecuteScalar("", "p_BooltanSoicalArchieve_Update", CommandType.StoredProcedure, sqlParams));
            return SocialMediaBultanId;

        }

        public int UpdateArchive(int ArchiveId, long NewsDateIndex, int panelId, string Path, string title, string newsids,
          string fromDate, string toDate, string fromTime, string toTime, bool allowNewspaper, bool galleryNewspaper,
          bool arz, bool sima, bool highLight,
            bool allowGroup, bool related, int selectedBultan, bool isArchive, bool chart, bool jeld, byte BultanType)
        {
            // var user = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == userId);
            // var parminId = Convert.ToInt32(user.ParminIds.Split(',')[0]);
            var parmin = db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == panelId);
            if (parmin.hdParmin == true) return 0;
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
                new SqlParameter("@" + "NewsDateIndex",NewsDateIndex),
                new SqlParameter("@" + "panelId",panelId),
                new SqlParameter("@" + "Path",Path),
                new SqlParameter("@" + "title",title),
                new SqlParameter("@" + "newsids",newsids),
                new SqlParameter("@" + "fromDate",fromDate),
                new SqlParameter("@" + "toDate",toDate),
                new SqlParameter("@" + "fromTime",fromTime),
                new SqlParameter("@" + "toTime",toTime),
                new SqlParameter("@" + "allowNewspaper",allowNewspaper),
                new SqlParameter("@" + "galleryNewspaper",galleryNewspaper),
                new SqlParameter("@" + "arz",arz),
                new SqlParameter("@" + "sima",sima),
                new SqlParameter("@" + "highLight",highLight),
                 new SqlParameter("@" + "allowGroup",allowGroup),
                new SqlParameter("@" + "related",related),
                new SqlParameter("@" + "selectedBultan",selectedBultan),
                new SqlParameter("@" + "isArchive",isArchive),
                new SqlParameter("@" + "chart",chart),
                new SqlParameter("@" + "jeld",jeld),
                new SqlParameter("@" + "BultanType",BultanType),
                new SqlParameter("@" + "mode","edit"),
        };
            int archiveId = Class_Static.ExecuteNonQuery("", "p_BooltanArchieve_Update", CommandType.StoredProcedure, sqlParams);
            return archiveId;

        }
        public List<Tbl_BultanArchive> GetBultanByDate(long fromDate, long toDate, string key)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            Guid gid = Guid.Parse(key);
            var panel = (from p in db.Tbl_Parmin
                         where p.ParminGid == gid
                         select p).FirstOrDefault();
            if (panel == null) return null;

            var result = (from r in db.Tbl_BultanArchive
                          where r.PanelId == panel.ParminID
                          && r.NewsDateIndex >= fromDate && r.NewsDateIndex <= toDate
                          orderby r.NewsDateIndex
                          select r).ToList();
            return result;
        }
        public List<Tbl_BultanArchive> GetBultanByDate(long fromDate, long toDate, int parminId)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();

            var panel = (from p in db.Tbl_Parmin
                         where p.ParminID == parminId
                         select p).FirstOrDefault();
            if (panel == null) return null;

            var result = (from r in db.Tbl_BultanArchive
                          where r.PanelId == panel.ParminID
                          && r.NewsDateIndex >= fromDate && r.NewsDateIndex <= toDate
                          orderby r.NewsDateIndex descending
                          select r).ToList();
            return result;
        }


        public List<Tbl_SocialMediaBultan> GetSocialBultanByDate(long fromDate, long toDate, int parminId)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();

            var panel = (from p in db.Tbl_Parmin
                         where p.ParminID == parminId
                         select p).FirstOrDefault();
            if (panel == null) return null;

            var result = (from r in db.Tbl_SocialMediaBultan
                          where r.ParminID_FK == panel.ParminID
                          && r.dateindex >= fromDate && r.dateindex <= toDate
                          orderby r.dateindex descending
                          select r).ToList();
            return result;
        }



        public Tbl_BultanArchive GeLastArchive(int panelId, long NewsDate)
        {
            var query = (from archive in db.Tbl_BultanArchive
                         where archive.PanelId == panelId
                         && archive.NewsDateIndex == NewsDate
                         select archive).Take(1).FirstOrDefault();
            return query;
        }

        public Tbl_BultanArchive UpdateArchive(int archiveId, string Path, string name, string newsids)
        {
            var query = (from archive in db.Tbl_BultanArchive
                         where archive.ArchiveId == archiveId
                         select archive).FirstOrDefault();
            query.Name = name;
            query.Path = Path;
            query.SelectedNews = newsids;
            db.SaveChanges();
            return query;
        }
        public Tbl_BultanArchive UpdateArchiveNews(int archiveId, string newsids)
        {
            var query = (from archive in db.Tbl_BultanArchive
                         where archive.ArchiveId == archiveId
                         select archive).FirstOrDefault();

            db.SaveChanges();
            return query;
        }
        public int UpdateBultanArchiveNews(int ArchiveId, string newsids)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
                new SqlParameter("@" + "newsids",newsids),
        };
            int archiveId = Class_Static.ExecuteNonQuery("", "p_BooltanArchieve_NewsUpdate", CommandType.StoredProcedure, sqlParams);
            return archiveId;

        }
        public Tbl_BultanArchive GetBultanById(int id)
        {
            return db.Tbl_BultanArchive.Where(p => p.ArchiveId == id).FirstOrDefault();
        }

        public Tbl_SocialMediaBultan GetSocialBultanById(int id)
        {
            return db.Tbl_SocialMediaBultan.Where(p => p.SocialMediaBultanID == id).FirstOrDefault();
        }


        public Tbl_BultanArchive GetBultanByArchiveId(int Id)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();

            var result = (from r in db.Tbl_BultanArchive
                          where r.ArchiveId == Id
                          select r).ToList();
            return result.Count != 0 ? result[0] : null;
        }

        public Tbl_SocialMediaBultan GetSocialBultanByArchiveId(int Id)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();

            var result = (from r in db.Tbl_SocialMediaBultan
                          where r.SocialMediaBultanID == Id
                          select r).ToList();
            return result.Count != 0 ? result[0] : null;
        }


        public void DeleteBultan(int archiveId)
        {
            db.Database.ExecuteSqlCommand("delete from Tbl_BultanArchive where ArchiveId=" + archiveId);
        }

        public void UpdateArchiveLink(int archiveId, string link)
        {
            try
            {
                var query = (from archive in db.Tbl_BultanArchive
                             where archive.ArchiveId == archiveId
                             select archive).FirstOrDefault();
                query.Path = link;
                db.SaveChanges();
            }
            catch
            {

            }
            //  return query;

        }

        public void DeleteBultan(int ArchiveId, int NewsId)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId) ,
                new SqlParameter("@" + "NewsId",NewsId) ,
        };
            Convert.ToInt32(Class_Ado.ExecuteNonQuery("", "p_BooltanArchieve_DeleteNews", CommandType.StoredProcedure, sqlParams));
        }

    }
}