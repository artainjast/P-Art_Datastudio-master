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
    public class Class_BultanArchiveFeature
    {
        DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        public long Add(int ArchiveId ,string SettingTitle , string SettingValue)
        {
            try
            {
                db = new DB_NewsCenterEntities();
                Tbl_BultanArchiveFeatures item = new Tbl_BultanArchiveFeatures();
                item.ArchiveId = ArchiveId;
                item.SettingTitle = SettingTitle;
                item.SettingValue = SettingValue;
                db.Tbl_BultanArchiveFeatures.Add(item);
                db.SaveChanges();
                return item.BultanArchiveFeatureId;
            }
            catch
            {
                return 0;
            }
        }
        public List<Tbl_BultanArchiveFeatures> GetList(int ArchiveId)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var setting = db.Tbl_BultanArchiveFeatures.Where(i => i.ArchiveId == ArchiveId).ToList();
            return setting;
        }
    }
}