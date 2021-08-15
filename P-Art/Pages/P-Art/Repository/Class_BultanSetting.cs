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
    public class Class_BultanSetting
    {
        DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        public long Add(int ParminId, string SettingTitle, string SettingValue)
        {
            try
            {
                db = new DB_NewsCenterEntities();
                Tbl_BultanSettings item = new Tbl_BultanSettings();
                item.ParminId = ParminId;
                item.SettingTitle = SettingTitle;
                item.SettingValue = SettingValue;
                db.Tbl_BultanSettings.Add(item);
                db.SaveChanges();
                return item.BultanSettingId;
            }
            catch
            {
                return 0;
            }
        }
        public List<Tbl_BultanSettings> GetList(int ParminId)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var setting = db.Tbl_BultanSettings.Where(i => i.ParminId == ParminId).ToList();
            return setting;
        }
    }
}