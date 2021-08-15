using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_TLPMessages
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public List<v_TLP_Messages> GetMessages(List<long> Ids)
        {
            var query = from site in _db.v_TLP_Messages
                        where Ids.Contains(site.ID)
                        select site;
            return query.ToList();

        }
        public List<Tbl_Telegram_Type> GetPosts(string postIds)
        {
            string cmd = "SELECT * FROM	dbo.v_TLP_Messages WHERE ID IN  (" + postIds + ")";
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            List<Tbl_Telegram_Type> CompiledPostsList = Tbl_Telegram_Type.GetFromDataRows(ds.Tables[0].Select());
            return CompiledPostsList;
        }
    }
}