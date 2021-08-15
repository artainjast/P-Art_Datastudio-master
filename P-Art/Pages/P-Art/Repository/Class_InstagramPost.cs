using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PArt.Pages.P_Art.Repository;
using System.Data;
using System.Data.SqlClient;
using P_Art.Pages.P_Art.ModelNews;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_InstagramPost
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public List<Tbl_Instagram_Type> GetPosts(string postIds)
        {
            string cmd = "SELECT i.* , k.Title AS Keyword FROM dbo.Tbl_InstagramPosts AS i INNER JOIN dbo.Tbl_InstagramKeywords AS k ON k.Id = i.KeywordId WHERE i.Id IN (" + postIds + ")";
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            List<Tbl_Instagram_Type> CompiledPostsList = Tbl_Instagram_Type.GetFromDataRows(ds.Tables[0].Select());
            return CompiledPostsList;
        }
        public List<Tbl_InstagramPosts> GetAllIds(List<long> NewsIds)
        {
            var query = from news in _db.Tbl_InstagramPosts
                        where NewsIds.Contains(news.Id)
                        select news;
            return query.ToList();

        }
    }
}