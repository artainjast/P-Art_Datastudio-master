using P_Art.Pages.P_Art.ModelEnvAds;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art.Pages.P_Art.Pages
{
    public partial class envDailyScreen : System.Web.UI.Page
    {
        private DB_EnvAdsEntities _db = new DB_EnvAdsEntities();
        private static DB_EnvAdsEntities _dbStatic = new DB_EnvAdsEntities();
        Class_Zaman _clsZm = new Class_Zaman();
        public Tbl_Parmin ParminTable = new Tbl_Parmin();
        List<int?> UserPanelList = new List<int?>();
        int memberId = 0;
        int userPanelId = 0;

        string strSearch = "";

        int fromDate = 0;
        int toDate = 0;
        int pageSize = 25;
        int pageIndex = 1;
        int brandId = -1;
        int campainId = -1;
        int structureTypeId = -1;
        int addressTypeId = -1;
        bool hasDateTime = false;

        PagingAdvertiseImageList_Type pagingAdvertiseImages = new PagingAdvertiseImageList_Type();

        int time = 0;
        Int64 fromDateTime = 0;
        Int64 toDateTime = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            Class_Layer.CheckSession();

            if (!Page.IsPostBack)
            {

                memberId = Class_Layer.CurrentUser().MemberID;

                userPanelId = Class_Layer.UserPanels().FirstOrDefault().Value;

                brandId = _db.Brands.Where(b => b.PanelId == userPanelId).Select(b => b.BrandId).FirstOrDefault();

                LoadData();



                PrepareNews(hasDateTime, fromDateTime, toDateTime, strSearch, brandId, campainId, structureTypeId, addressTypeId, pageSize, pageIndex);

                GeneratePaginationButton(pagingAdvertiseImages.TotalAdvertiseImageCount, pageSize, pageIndex);


                GetCompletedData();

                GenerateAdvertisesList(pagingAdvertiseImages);

            }
        }

        private void LoadData()
        {
            LoadBrandsOnComboBox(brandId);
            AddressTypeComboBoxLoad();
            StructureTypeComboBoxLoad();

            fromDate = int.Parse(_clsZm.Today().Replace("/", ""));
            toDate = fromDate;

            if (Request.QueryString["ftime"] != null)
            {
                txt_fromHour.Value = Request.QueryString["ftime"].ToString().Replace("-", ":");
            }
            if (Request.QueryString["ttime"] != null)
            {
                txt_toHour.Value = Request.QueryString["ttime"].ToString().Replace("-", ":");
            }
            if (Request.QueryString["FromDate"] != null)
            {
                fromDate = int.Parse(Request.QueryString["FromDate"].ToString());
                txt_fromDate.Value = fromDate.ToString().Substring(0, 4) + "/" + fromDate.ToString().Substring(4, 2) + "/" + fromDate.ToString().Substring(6, 2);
            }
            else
            {
                txt_fromDate.Value = _clsZm.Today();
            }
            if (Request.QueryString["ToDate"] != null)
            {
                toDate = int.Parse(Request.QueryString["ToDate"].ToString());
                txt_toDate.Value = toDate.ToString().Substring(0, 4) + "/" + toDate.ToString().Substring(4, 2) + "/" + toDate.ToString().Substring(6, 2);

            }
            else
            {
                txt_toDate.Value = _clsZm.Today();

            }


            if (Request.QueryString["time"] != null)
            {
                time = int.Parse(Request.QueryString["time"].ToString());

            }

            if (Request.QueryString["hasd"] != null)
            {
                hasDateTime = true;
            }

            if (Request.QueryString["keyword"] != null)
            {
                strSearch = Server.HtmlDecode(Request.QueryString["keyword"].ToString());
                txt_search.Value = strSearch.Replace("|", "+");
            }

            if (Request.QueryString["brand"] != null)
            {
                BrandsDropDownList.SelectedValue = Server.HtmlDecode(Request.QueryString["brand"].ToString());
                brandId = Convert.ToInt32(BrandsDropDownList.SelectedValue);
                SelectedBrandIdHiddenField.Value = brandId.ToString();
            }


            if (Request.QueryString["campain"] != null)
            {
                CampainIDHiddenField.Value = Server.HtmlDecode(Request.QueryString["campain"].ToString());
                campainId = Convert.ToInt32(CampainIDHiddenField.Value);
            }

            if (Request.QueryString["structtype"] != null)
            {
                StructureTypeDropDownList.SelectedValue = Server.HtmlDecode(Request.QueryString["structtype"].ToString());
                structureTypeId = Convert.ToInt32(StructureTypeDropDownList.SelectedValue);
            }

            if (Request.QueryString["addresstype"] != null)
            {
                AddressTypeDropDownList.SelectedValue = Server.HtmlDecode(Request.QueryString["addresstype"].ToString());
                addressTypeId = Convert.ToInt32(AddressTypeDropDownList.SelectedValue);
            }


            if (Request.QueryString["index"] != null)
            {
                PageIndexHiddenField.Value = Server.HtmlDecode(Request.QueryString["index"].ToString());
                pageIndex = int.Parse(PageIndexHiddenField.Value);
            }


            if (Request.QueryString["size"] != null)
            {
                PageSizeDropDownList.SelectedValue = Server.HtmlDecode(Request.QueryString["size"].ToString());
                pageSize = int.Parse(PageSizeDropDownList.SelectedValue) < 100 ? int.Parse(PageSizeDropDownList.SelectedValue) : 100;
            }



            if (!string.IsNullOrWhiteSpace(txt_fromDate.Value.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_fromHour.Value.Trim()))
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Value.Trim().Replace("/", "") + "0000");
                }
                else
                {
                    fromDateTime = Convert.ToInt64(txt_fromDate.Value.Trim().Replace("/", "") + txt_fromHour.Value.Trim().Replace(":", ""));
                }

            }

            if (!string.IsNullOrWhiteSpace(txt_toDate.Value.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_toHour.Value.Trim()))
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Value.Trim().Replace("/", "") + "2400");
                }
                else
                {
                    toDateTime = Convert.ToInt64(txt_toDate.Value.Trim().Replace("/", "") + txt_toHour.Value.Trim().Replace(":", ""));
                }

            }

        }

        protected void btn_ShowNews_Click(object sender, EventArgs e)
        {
            int index = 1;
            generateUrl(index);
        }

        private void generateUrl(int index)
        {
            string url = "";

            if (txt_fromDate.Value != "")
            {
                url = "fromDate=" + txt_fromDate.Value.Replace("/", "") + "&";
            }
            if (txt_toDate.Value != "")
            {
                url += "toDate=" + txt_toDate.Value.Replace("/", "") + "&";
            }

            if (txt_search.Value.Trim() != "")
            {
                url += "keyword=" + Server.HtmlEncode(txt_search.Value.Trim().Replace("+", "|")) + "&";
            }
            if (txt_fromHour.Value != "" && txt_toHour.Value != "")
            {
                url += "ftime=" + Server.HtmlEncode(txt_fromHour.Value.Trim().Replace(":", "-")) + "&";
                url += "ttime=" + Server.HtmlEncode(txt_toHour.Value.Trim().Replace(":", "-")) + "&";
            }

            if (searchHasDateTime.Checked)
            {
                url += "hasd=1" + "&";
            }

            if (BrandsDropDownList.SelectedItem.Value != null && BrandsDropDownList.SelectedItem.Value != "-1")
            {
                url += "brand=" + Server.HtmlEncode(BrandsDropDownList.SelectedItem.Value) + "&";
            }

            if (!string.IsNullOrEmpty(CampainIDHiddenField.Value) && CampainIDHiddenField.Value != "-1")
            {
                url += "campain=" + Server.HtmlEncode(CampainIDHiddenField.Value) + "&";
            }

            if (StructureTypeDropDownList.SelectedItem.Value != null && StructureTypeDropDownList.SelectedItem.Value != "-1")
            {
                url += "structtype=" + Server.HtmlEncode(StructureTypeDropDownList.SelectedItem.Value) + "&";
            }

            if (AddressTypeDropDownList.SelectedItem.Value != null && AddressTypeDropDownList.SelectedItem.Value != "-1")
            {
                url += "addresstype=" + Server.HtmlEncode(AddressTypeDropDownList.SelectedItem.Value) + "&";
            }

            if (PageSizeDropDownList.SelectedItem.Value != null)
            {
                url += "size=" + Server.HtmlEncode(PageSizeDropDownList.SelectedItem.Value) + "&";
            }

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            Response.Redirect("/AdvertiseImagesList/?" + url);


        }

        private void PrepareNews(bool hasDateTime, long fromDateTimeIndex, long toDateTimeIndex, string searchString, int brandId, int campainId, int structureTypeId, int addressTypeId, int pageSize, int pageIndex)
        {
            PagingAdvertiseImageList_Type Result = new PagingAdvertiseImageList_Type();

            IQueryable<Images> query = _db.Images
                .Where(a => a.IsDelete != true).Select(n => n);

            if (hasDateTime)
            {
                query = query.Where(a => a.FarsiDateTimeIndex >= fromDateTimeIndex && a.FarsiDateTimeIndex < toDateTimeIndex);
            }

            if (brandId > -1)
            {
                query = query.Where(a => a.Advertises.BrandId == brandId);
            }

            if (campainId > -1)
            {
                query = query.Where(a => a.Advertises.CampainId == campainId);
            }
            if (structureTypeId > -1)
            {
                query = query.Where(a => a.Advertises.Structures.StructureTypeId == structureTypeId);
            }
            if (addressTypeId > -1)
            {
                query = query.Where(a => a.Advertises.Structures.AddressTypeId == addressTypeId);
            }


            if (!string.IsNullOrEmpty(searchString.Trim()))
            {
                searchString = Class_Static.PersianAlpha(searchString);

                string str1 = "";
#pragma warning disable CS0219 // The variable 'str2' is assigned but its value is never used
                string str2 = "";
#pragma warning restore CS0219 // The variable 'str2' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'str3' is assigned but its value is never used
                string str3 = "";
#pragma warning restore CS0219 // The variable 'str3' is assigned but its value is never used


                if (searchString.Contains("|"))
                {
                    var SearchParameterList = searchString.Split('|');

                    str1 = SearchParameterList[0];

                    query = query.Where(n =>
                    (n.Advertises.Campains.Title.Contains(str1)));
                }
                else
                {
                    query = query.Where(n => (n.Advertises.Campains.Title.Contains(searchString)));
                }
            }

            pagingAdvertiseImages.TotalAdvertiseImageCount = query.Count();
            pagingAdvertiseImages.AdvertiseImageList = query
                .OrderByDescending(n => n.FarsiDateTimeIndex)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .Select(n => new PagingAdvertiseImageItem_Type
                {
                    AdvertiseId = (long)n.AdvertiseId,
                    FarsiDateString = n.FarsiDateString,
                    TimeString = n.TimeString,
                    BrandId = (int)n.Advertises.BrandId,
                    CampainId = (int)n.Advertises.CampainId,
                    CampainTitle = "",
                    StructureId = (int)n.Advertises.StructureId,
                    Address = n.Advertises.Structures.Address,
                    StructureTypeId = (int)n.Advertises.Structures.StructureTypeId,
                    AddressTypeId = (int)n.Advertises.Structures.AddressTypeId,
                    AddressTypeTitle = n.Advertises.Structures.AddressTypes.Title,
                    BrandName = "",
                    BrandImageName ="",
                    StructureTitle = "",
                    Title = "",
                    ImageId = n.ImageId,
                    ImageName = n.ImageName,
                    FarsiDateTimeIndex = (long)n.FarsiDateTimeIndex
                }).ToList();

        }


        private void GeneratePaginationButton(int totalCount, int pageSize, int index)
        {
            var remind = (totalCount % pageSize) > 0 ? 1 : 0;

            int tab = totalCount / pageSize + remind;

            int rangeStart = 1;
            int rangeEnd = tab;

            StringBuilder PaginationHTML = new StringBuilder();

            PaginationHTML.AppendLine("<div class=\"pagination\">");

            if (tab > 10 && index > 5)
            {
                PaginationHTML.Append($"<a href=\"{generatePaginationLink(1)}\">&laquo;</a>  ");
            }

            if (tab <= 10)
            {
                for (int i = rangeStart; i <= rangeEnd; i++)
                {
                    if (index == i)
                    {
                        PaginationHTML.Append($"<a class=\"active\"   href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                    }
                    else
                    {
                        PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                    }

                }
            }
            else
            {
                if (index < 6)
                {
                    rangeStart = 1;
                    rangeEnd = 10;

                    for (int i = rangeStart; i <= rangeEnd; i++)
                    {
                        if (index == i)
                        {
                            PaginationHTML.Append($"<a class=\"active\"  href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                        else
                        {
                            PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }

                    }

                }
                else if (index > tab - 6)
                {
                    rangeStart = tab - 10;
                    rangeEnd = tab;

                    for (int i = rangeStart; i <= rangeEnd; i++)
                    {
                        if (index == i)
                        {
                            PaginationHTML.Append($"<a  class=\"active\" href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                        else
                        {
                            PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                    }
                }
                else
                {
                    rangeStart = index - 4;
                    rangeEnd = index + 5;

                    for (int i = rangeStart; i <= rangeEnd; i++)
                    {
                        if (index == i)
                        {
                            PaginationHTML.Append($"<a  class=\"active\" href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                        else
                        {
                            PaginationHTML.Append($"<a href=\"{generatePaginationLink(i)}\">{i}</a>  ");
                        }
                    }
                }
            }

            if (tab > 10 && index < tab - 5)
            {
                PaginationHTML.Append($"<a href=\"{generatePaginationLink(tab)}\">&raquo;</a>  ");
            }

            PaginationHTML.AppendLine("</div>");
            PaginationHTML.AppendLine($"<span class=\"PagingTotalCount\">صفحه {index} از {tab} </span>");
            PaginationHTML.AppendLine($"<span class=\"PagingTotalCount\">تعداد تصاویر: {totalCount}  </span>");

            topPagination.InnerHtml = PaginationHTML.ToString();
            buttomPagination.InnerHtml = PaginationHTML.ToString();

        }

        private string generatePaginationLink(int index)
        {

            string url = "";

            if (fromDate > 0)
            {
                url += "fromDate=" + fromDate.ToString() + "&";
            }

            if (toDate > 0)
            {
                url += "toDate=" + toDate.ToString() + "&";
            }

            if (!string.IsNullOrEmpty(strSearch))
            {
                url += "keyword=" + Server.HtmlEncode(strSearch) + "&";
            }

            if (txt_fromHour.Value != "" && txt_toHour.Value != "")
            {
                url += "ftime=" + Server.HtmlEncode(txt_fromHour.Value.Trim().Replace(":", "-")) + "&";
                url += "ttime=" + Server.HtmlEncode(txt_toHour.Value.Trim().Replace(":", "-")) + "&";
            }

            url += "size=" + Server.HtmlEncode(pageSize.ToString()) + "&";

            url += "index=" + Server.HtmlEncode(index.ToString()) + "&";

            url = url.Substring(0, url.Length - 1);

            return "/AdvertisesList/?" + url;

        }

        private void GenerateAdvertisesList(PagingAdvertiseImageList_Type pagingAdvertiseImage)
        {
            pagingGridRepeater.DataSource = pagingAdvertiseImage.AdvertiseImageList;
            pagingGridRepeater.DataBind();
        }

        private void GetCompletedData()
        {
            var AdvertiseIdList = pagingAdvertiseImages.AdvertiseImageList.Select(a => a.AdvertiseId).ToList();
            var brandsIdList = pagingAdvertiseImages.AdvertiseImageList.Select(a => a.BrandId).Distinct().ToList();

            var Brands = _db.Brands.Where(b => brandsIdList.Contains(b.BrandId)).ToList();
            var StructureTypes = _db.StructureTypes.ToList();
            var AddressTypes = _db.AddressTypes.ToList();

            foreach (var item in pagingAdvertiseImages.AdvertiseImageList)
            {
                item.StructureTitle = StructureTypes.Where(s => s.StructureTypeId == item.StructureTypeId).Select(s => s.Title).FirstOrDefault();
                item.AddressTypeTitle = AddressTypes.Where(a => a.AddressTypeId == item.AddressTypeId).Select(a => a.Title).FirstOrDefault();
                item.BrandName = Brands.Where(b => b.BrandId == item.BrandId).Select(b => b.Title).FirstOrDefault();
                item.BrandImageName = Brands.Where(b => b.BrandId == item.BrandId).Select(b => b.BrandImageName).FirstOrDefault();
                item.Title = item.StructureTitle + " | " + item.CampainTitle;
                

            }
        }

        public List<LastImageOfAdvertise_Type> GetEachAdvertiseLastImage(List<long> advertiseList)
        {
            var imageList = _db.Images
                               .Where(i => advertiseList.Contains((long)i.AdvertiseId))
                               .Select(i => new LastImageOfAdvertise_Type
                               {
                                   AdvertiseId = (long)i.AdvertiseId,
                                   ImageId = i.ImageId,
                                   ImageName = i.ImageName,
                                   FarsiDateTimeIndex = (long)i.FarsiDateTimeIndex,
                                   FarsiDateString = i.FarsiDateString,
                                   TimeString = i.TimeString
                               });

            List<LastImageOfAdvertise_Type> finalImageList = new List<LastImageOfAdvertise_Type>();

            foreach (var id in advertiseList.Distinct())
            {
                if (imageList.Any(i => i.AdvertiseId == id))
                {
                    finalImageList.Add(imageList.Where(i => i.AdvertiseId == id).OrderByDescending(i => i.FarsiDateTimeIndex).FirstOrDefault());
                }
            }

            return finalImageList;
        }

        private void LoadBrandsOnComboBox(int? brandId)
        {
            var brands = _db.Brands
            .Where(b => b.IsDelete != true)
            .Select(b => new BrandCombo_Type
            {
                BrandId = b.BrandId,
                Title = b.Title
            }).ToList();

            BrandsDropDownList.Items.Clear();
            BrandsDropDownList.Items.Add(new ListItem("تمامی برندها", "-1"));

            foreach (var brand in brands)
            {
                BrandsDropDownList.Items.Add(new ListItem(brand.Title, brand.BrandId.ToString()));
            }

            if (brandId.HasValue && brandId != -1 && brandId != 0)
            {
                ListItem li = BrandsDropDownList.Items.FindByValue(brandId.ToString());
                li.Selected = true;
            }
            SelectedBrandIdHiddenField.Value = brandId.Value.ToString();
        }




        private void StructureTypeComboBoxLoad()
        {
            var brands = _db.StructureTypes
            .Where(c => c.IsDelete != true)
            .Select(c => new StructureTypeCombo_Type
            {
                StructureTypeId = c.StructureTypeId,
                Title = c.Title
            })
            .ToList();

            StructureTypeDropDownList.Items.Clear();
            StructureTypeDropDownList.Items.Add(new ListItem("همه نوع سازه", "-1"));

            foreach (var brand in brands)
            {
                StructureTypeDropDownList.Items.Add(new ListItem(brand.Title, brand.StructureTypeId.ToString()));
            }
        }



        private void AddressTypeComboBoxLoad()
        {
            var brands = _db.AddressTypes
            .Where(c => c.IsDelete != true)
            .Select(c => new AddressTypeCombo_Type
            {
                AddressTypeId = c.AddressTypeId,
                Title = c.Title
            })
            .ToList();

            AddressTypeDropDownList.Items.Clear();
            AddressTypeDropDownList.Items.Add(new ListItem("همه نوع موقعیت", "-1"));

            foreach (var brand in brands)
            {
                AddressTypeDropDownList.Items.Add(new ListItem(brand.Title, brand.AddressTypeId.ToString()));
            }
        }


        [WebMethod]
        public static List<CampainCombo_Type> LoadCampainsComboBox(string brandIdstring)
        {
            int brandId = -1;
            if (!string.IsNullOrEmpty(brandIdstring) && brandIdstring != "undefined")
            {
                brandId = Convert.ToInt32(brandIdstring);
            }

            var campainsQuery = _dbStatic.Campains
            .Where(c => c.IsDelete != true);
            if (brandId != -1)
            {
                campainsQuery = campainsQuery.Where(c => c.BrandId == brandId);
            }
            return campainsQuery.Select(c => new CampainCombo_Type
            {
                CampainId = c.CampainId,
                Title = c.Title
            })
            .OrderBy(c => c.Title)
            .ToList();
        }




    }
}