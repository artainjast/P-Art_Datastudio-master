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
    public enum MediaType : int
    {
        News = 1,
        NewMediaNews = 2 ,
        Telegram = 3 ,
        Twitter = 4 ,
        Instagram = 5
    }
    public class Class_BultanArchiveMedia
    {
        DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        public Tbl_BultanArchiveMedia InsertArchive(int archiveId, long mediaId, int mediaType, int priority)
        {
            var newItem = new Tbl_BultanArchiveMedia();
            newItem.ArchiveId = archiveId;
            newItem.MediaId = mediaId;
            newItem.MediaType = mediaType;
            newItem.Priority = priority;
            db.Tbl_BultanArchiveMedia.Add(newItem);
            db.SaveChanges();
            return newItem;

        }
        public List<Tbl_BultanArchiveMedia> GeArchiveList(int ArchiveId)
        {
            List<Tbl_BultanArchiveMedia> list = db.Tbl_BultanArchiveMedia.Where(i => i.ArchiveId == ArchiveId).ToList();
            return list;
        }
    }
}