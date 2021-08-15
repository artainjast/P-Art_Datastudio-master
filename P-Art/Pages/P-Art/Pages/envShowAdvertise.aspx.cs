using P_Art.Pages.P_Art.ModelEnvAds;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class envShowAdvertise : System.Web.UI.Page
    {
        private DB_EnvAdsEntities _db = new DB_EnvAdsEntities();
        private static DB_EnvAdsEntities _dbStatic = new DB_EnvAdsEntities();
        Class_Zaman _clsZm = new Class_Zaman();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        List<int?> UserPanelList = new List<int?>();
#pragma warning disable CS0414 // The field 'envShowAdvertise.memberId' is assigned but its value is never used
        int memberId = 0;
#pragma warning restore CS0414 // The field 'envShowAdvertise.memberId' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'envShowAdvertise.userPanelId' is assigned but its value is never used
        int userPanelId = 0;
#pragma warning restore CS0414 // The field 'envShowAdvertise.userPanelId' is assigned but its value is never used

        public AdvertiseItem_Type currentAdvertise = new AdvertiseItem_Type();


        protected void Page_Load(object sender, EventArgs e)
        {
            Class_Layer.CheckSession();
            if (RouteData.Values["Id"] != null)
            {
                long advertiseId = long.Parse(RouteData.Values["Id"].ToString());
                Advertises ads = _db.Advertises.FirstOrDefault(i => i.AdvertiseId == advertiseId);
                var Brands = _db.Brands.Where(b => b.BrandId == ads.BrandId).FirstOrDefault();
               
                
                var Structure = _db.Structures.FirstOrDefault(i => i.StructureId == ads.StructureId);
                var StructureTypes = _db.StructureTypes.FirstOrDefault(i => i.StructureTypeId == Structure.StructureTypeId);
                var AddressTypes = _db.AddressTypes.FirstOrDefault(i => i.AddressTypeId == Structure.AddressTypeId);
                var campain = _db.Campains.FirstOrDefault(c => c.CampainId == ads.CampainId);
                currentAdvertise = (from advertise in _db.Advertises
                                    where advertise.AdvertiseId == advertiseId
                                    select new AdvertiseItem_Type {
                                        AdvertiseId = advertise.AdvertiseId,
                                        BrandId = (int)advertise.BrandId,
                                        BrandName = Brands.Title,
                                        BrandImageName = Brands.BrandImageName,
                                        CampainId = (int)advertise.CampainId,
                                        CampainTitle = campain.Title,
                                        StructureId = (int)advertise.StructureId,
                                        StructureTypeId = (int)Structure.StructureTypeId,
                                        StructureTitle = StructureTypes.Title,
                                        Area = (int)Structure.Area,
                                        AddressTypeId = (int)Structure.AddressTypeId,
                                        AddressTypeTitle = AddressTypes.Title,// advertise.Structures.AddressTypes.Title,
                                        Address = Structure.Address,
                                        FarsiDateTimeIndex = (long)advertise.FarsiDateTimeIndex,
                                        FarsiDateString = advertise.FarsiDateString,
                                        TimeString = advertise.TimeString,
                                        Title = ""

                                    }).FirstOrDefault();



                if (currentAdvertise != null)
                {
                    brandTitile.InnerText = currentAdvertise.BrandName;
                    campainTitle.InnerText = currentAdvertise.CampainTitle;
                    addressTypeTitle.InnerText = currentAdvertise.AddressTypeTitle;
                    addressTitle.InnerText = currentAdvertise.Address;
                    structureTypeTitle.InnerText = currentAdvertise.StructureTitle;
                    dateTime.InnerText = currentAdvertise.FarsiDateString;
                    structureArea.InnerText = $"{currentAdvertise.Area.ToString()} متر مربع";

                    var images = (from image in _db.Images
                                  where image.AdvertiseId == advertiseId
                                  orderby image.FarsiDateTimeIndex descending
                                  select new ShowImagesListItem_Type
                                  {
                                      ImageId = image.ImageId,
                                      ImageName = image.ImageName,
                                      FarsiDateString = image.FarsiDateString,
                                      TimeString = image.TimeString,
                                      FarsiDateTimeIndex = (long)image.FarsiDateTimeIndex
                                  }).ToList();

                    if (images.Any())
                    {
                        currentAdvertise.Images = images;
                    }

                    imagesGalleryRepeater.DataSource = currentAdvertise.Images;
                    imagesGalleryRepeater.DataBind();

                }


            }

        }
    }
}