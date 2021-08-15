using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace PArt.Pages.P_Art.Repository
{
    public class Class_Sites
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public Tbl_Sites GetSiteById(int siteId)
        {
            //  _db.Dispose();
            var query = (from r in _db.Tbl_Sites
                         where r.SiteID == siteId
                         select r).FirstOrDefault();


            return query;
        }

        public List<int> GetSiteByType(int siteType)
        {

            List<int> Uids = new List<int>();

            Uids = (from r in _db.Tbl_Sites
                    where r.SiteType == siteType
                    select r.SiteID
                   ).ToList<int>();


            return Uids;
        }

        public List<Tbl_Sites> SiteByType(int type)
        {
            var query = from site in _db.Tbl_Sites
                        where site.SiteType == type
                        orderby site.SiteTitle
                        select site;
            return query.ToList();

        }

        public DataTable GetHighlight(string parminPanels, string siteIds, int DateIndex)
        {
            Class_Ado _clsAdo = new Class_Ado();
            return _clsAdo.FillDataTable("select sitetitle,siteid,sitetype,(select count(*) from Tbl_News where newsId in (select NewsID from Tbl_Relation_NewsParminPanel where NewsDateIndex=" + DateIndex + " and ParminPanelId in (" + parminPanels + ")) and SiteID=tbl.SiteID) as CCount from Tbl_Sites  as tbl where SiteID in (" + siteIds + ") order by SiteTitle");



        }

        //public List<Tbl_Sites> GetSiteByIds(List<int> ids)
        //{
        //    var query = from site in _db.Tbl_Sites
        //                where ids.Contains(site.SiteID)
        //                orderby site.SiteTitle
        //                select site;
        //    return query.ToList();
        //}

        public List<Tbl_Sites> GetSiteByIds(List<int> ids)
        {
            string idStr = "";
            foreach (int i in ids)
            {
                idStr += i.ToString() + ",";
            }
            idStr = idStr.Remove(idStr.Length - 1);
            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("",
                @"SELECT SiteID,SiteName,SiteTitle,SiteType,Logo,Active,ParminID,PanelCategory,IsPayesh,
                '' AS ErrorLinks,Interval,SiteUrl,IsFeeder,GolrangCode,SitePriority  FROM dbo.Tbl_Sites WHERE  SiteID IN (" + idStr + ") ORDER BY SiteTitle", CommandType.Text);
            List<Tbl_Sites> sites = GetFromDataRows(ds.Tables[0].Select());
            return sites;
        }
        public static List<Tbl_Sites> GetFromDataRows(DataRow[] Rows)
        {
            HtmlRemoval _clsHtmlRemoval = new HtmlRemoval();
            List<Tbl_Sites> list = new List<Tbl_Sites>();
            foreach (DataRow dr in Rows)
            {
                Tbl_Sites acc = new Tbl_Sites();
                try { acc.SiteName = dr["SiteName"].ToString(); } catch { };
                try { acc.SiteTitle = dr["SiteTitle"].ToString(); } catch { };
                try { acc.SiteType = Convert.ToInt32(dr["SiteType"]); } catch { };
                try { acc.Logo = dr["Logo"] + ""; } catch { };
                try { acc.Active = Convert.ToBoolean(dr["Active"]); } catch { };
                try { acc.ParminID = Convert.ToInt32(dr["ParminID"]); } catch { };
                try { acc.PanelCategory = Convert.ToInt32(dr["PanelCategory"]); } catch { };
                try { acc.IsPayesh = Convert.ToBoolean(dr["IsPayesh"]); } catch { };
                try { acc.ErrorLinks = dr["ErrorLinks"] + ""; } catch { };
                try { acc.Interval = Convert.ToInt32(dr["Interval"]); } catch { };
                try { acc.SiteUrl = dr["SiteUrl"].ToString(); } catch { };
                try { acc.IsFeeder = Convert.ToBoolean(dr["IsFeeder"]); } catch { };
                try { acc.SiteID = Convert.ToInt32(dr["SiteID"]); } catch { };
                try { acc.GolrangCode = dr["GolrangCode"].ToString(); } catch { };
                try { acc.SitePriority = Convert.ToInt32(dr["SitePriority"]); } catch { };
                list.Add(acc);
            }
            return list;
        }
        public List<Tbl_Sites> GetAllSites()
        {
            return _db.Tbl_Sites.OrderBy(site => site.SiteTitle).ToList();
        }
        public List<Tbl_Sites> SelectResourceSortingOrder(List<int> siteIds)
        {
            //var query = (from site in _db.Tbl_Sites
            //             where siteIds.Contains(site.SiteID)
            //             select site).ToList();

            //return query;
            string idStr = "";
            foreach (int i in siteIds)
            {
                idStr += i.ToString() + ",";
            }
            idStr = idStr.Remove(idStr.Length - 1);
            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("",
                @"SELECT SiteID,SiteName,SiteTitle,SiteType,Logo,Active,ParminID,PanelCategory,IsPayesh,
                '' AS ErrorLinks,Interval,SiteUrl,IsFeeder,GolrangCode,SitePriority  FROM dbo.Tbl_Sites WHERE  SiteID IN (" + idStr + ") ORDER BY SiteTitle", CommandType.Text);
            List<Tbl_Sites> sites = GetFromDataRows(ds.Tables[0].Select());
            return sites;
        }

        public List<Tbl_Sites> SelectAllPayesh()
        {
            return _db.Tbl_Sites.Where(t => t.IsPayesh == true).ToList();
        }

        public List<Tbl_Sites> SelectAllByTag(string tag)
        {
            return _db.Tbl_Sites.Where(t => t.SiteTitle.Contains(tag)).ToList();
        }
        public Tbl_Sites InsertSite(string name, int type, bool isPayesh, int interval)
        {
            var itemold = _db.Tbl_Sites.FirstOrDefault(t => t.SiteTitle == name);
            if (itemold != null)
                return itemold;

            var item = new Tbl_Sites();
            item.SiteTitle = name;
            item.Active = true;
            item.SiteType = type;
            item.IsPayesh = isPayesh;
            item.Interval = interval;

            _db.Tbl_Sites.Add(item);
            _db.SaveChanges();

            return item;
        }
    }
}