using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;

namespace PArt.Pages.P_Art.Repository
{

    public class Class_Gallery
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public List<Tbl_Gallery> GetGallery(List<int?> PanelIds, int PageCount, int PageIndex)
        {
            var query = (from gallery in _db.Tbl_Gallery
                         join RGallery in _db.Tbl_Relation_Gallery
                         on gallery.imageId equals RGallery.ImageID
                         where PanelIds.Contains(RGallery.ParminId)
                         orderby gallery.imageId descending
                         select gallery).Skip(PageIndex).Take(PageCount);

            return query.ToList();
        }

        public Tbl_Gallery GetGalleryById(int imageId)
        {
            var query = (from record in _db.Tbl_Gallery
                         where record.imageId == imageId
                         select record).FirstOrDefault();

            return query;

        }
    }
}