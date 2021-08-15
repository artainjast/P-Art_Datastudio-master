using P_Art.Pages.P_Art.ModelNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_BultanFiles
    {
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public Tbl_BultanFiles SelectItem(int id)
        {
            return _db.Tbl_BultanFiles.Where(p => p.BultanID == id).FirstOrDefault();
        }
        public Tbl_BultanFiles SelectBultanItem(int ArchiveId)
        {
            var archive = _db.Tbl_BultanArchive.FirstOrDefault(i => i.ArchiveId == ArchiveId);
            return _db.Tbl_BultanFiles.Where(p => p.BultanID == archive.SelectedBultan).FirstOrDefault();
        }
    }
}