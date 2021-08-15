using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using PArt.Pages.P_Art.Repository;
using System.Web.Routing;
using System.Data;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Keywords
    {
        Class_News _clsNews = new Class_News();

        public Tbl_RssKeywords GetRssKeywordById(int keyId)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            return db.Tbl_RssKeywords.Where(p => p.KeyId == keyId).FirstOrDefault();

        }
        public List<Tbl_RssKeywords> GetRssKeywordByIds(List<int?> ids)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var query = from key in db.Tbl_RssKeywords
                        where ids.Contains(key.KeyId) && key.Active == true
                        orderby key.OrderItem
                        select key;
            return query.ToList();


        }
        public List<Tbl_RssKeywords> GetRssKeywordByPanelIds(List<int?> ids)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var query = from key in db.Tbl_RssKeywords
                        where ids.Contains(key.PanelId)
                        && key.Active == true
                        orderby key.OrderItem
                        select key;
            return query.ToList();


        }

        public List<Tbl_SocialMediaKey> GetSocialRssKeywordByPanelIds(List<int?> ids)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var query = from key in db.Tbl_SocialMediaKey
                        where ids.Contains(key.ParminID_FK)
                        && key.Active == true
                        orderby key.GroupId_FK
                        select key;
            return query.ToList();


        }

        public List<Tbl_NewsGroup> GetgroupRssKeywordByPanelIds(List<int?> ids)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var query = from key in db.Tbl_NewsGroup
                        where ids.Contains(key.ParminId)

                        orderby key.GroupId
                        select key;
            return query.ToList();


        }


        public List<Tbl_RssKeywords> GetRssKeywordByPanelIds2(string ids)
        {

            DB_NewsCenterEntities db = new DB_NewsCenterEntities();

            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", @"SELECT * FROM Tbl_RssKeywords WHERE KeyId IN ( " + ids + ")", CommandType.Text, null);


            List<Tbl_RssKeywords> list = new List<Tbl_RssKeywords>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Tbl_RssKeywords acc = new Tbl_RssKeywords();
                acc.KeyId = Convert.ToInt32(dr["KeyId"]);
                acc.PanelId = Convert.ToInt32(dr["PanelId"]);

                acc.KeywordName = dr["KeywordName"] + "";

                list.Add(acc);

            }
            return list;



        }
        //public List<Tbl_RssKeywords> GetRssKeywordByPanelIds2(List<int?> ids)
        //{
        //    DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        //    var datasource = from x in db.Tbl_RssKeywords
        //                     where ids.Contains(x.PanelId)
        //                     select new
        //                     {
        //                         x.KeyId,
        //                         x.KeywordName,
        //                         x.GroupName,
        //                         x.GroupOrder
        //                     } ;
        //    return datasource.ToList();

        //}

        public Tbl_RssKeywords InsertKeyword(string keywordName, int panelId, string color, string notLike, int orderItem, string mobiles, string logo, bool isMobileNotification, bool isSmsActive, string keywordGroup, bool isTelegram, int groupOrder , int type)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var newItem = new Tbl_RssKeywords();
            newItem.KeywordName = keywordName;
            newItem.Mobiles = mobiles;
            newItem.NotLike = notLike;
            newItem.OrderItem = orderItem;
            newItem.PanelId = panelId;
            newItem.Type = type;
            newItem.Color = color;
            newItem.Active = true;
            newItem.KeywordImage = logo;
            newItem.IsMobileSMS = isSmsActive;
            newItem.IsMobileNotification = isMobileNotification;
            newItem.GroupName = keywordGroup;
            newItem.IsTelegramChannel = isTelegram;
            newItem.GroupOrder = groupOrder;
            db.Tbl_RssKeywords.Add(newItem);
            db.SaveChanges();
            return newItem;

        }

        public Tbl_RssKeywords UpdateKeyword(int keyId, string keywordName, int panelId, string color, string notLike, int orderItem, string mobiles, string logo, bool isMobileNotification, bool isSmsActive, string keywordGroup, bool isTelegram, int groupOrder , int type)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var newItem = (from k in db.Tbl_RssKeywords
                           where k.KeyId == keyId
                           select k).FirstOrDefault();

            newItem.KeywordName = keywordName;
            newItem.Color = color;
            newItem.Mobiles = mobiles;
            newItem.NotLike = notLike;
            newItem.OrderItem = orderItem;
            newItem.PanelId = panelId;
            newItem.KeywordImage = logo;
            newItem.IsMobileSMS = isSmsActive;
            newItem.IsMobileNotification = isMobileNotification;
            newItem.GroupName = keywordGroup;
            newItem.Type = type;
            newItem.IsTelegramChannel = isTelegram;
            newItem.GroupOrder = groupOrder;

            db.SaveChanges();
            return newItem;

        }

        public void DeleteKeyword(int keyId)
        {
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            var newItem = (from k in db.Tbl_RssKeywords
                           where k.KeyId == keyId
                           select k).FirstOrDefault();
            newItem.Active = false;
            db.SaveChanges();
        }

        public string GetRssKeywordByGroupOrder(int parminId, int? groupOrder)
        {
            try
            {
                DB_NewsCenterEntities db = new DB_NewsCenterEntities();
                var newItem = (from k in db.Tbl_RssKeywords
                               where k.PanelId == parminId && k.GroupOrder == groupOrder
                               select k).FirstOrDefault();
                return newItem.GroupName;
            }
            catch
            {
                return "";
            }
        }
    }
}
