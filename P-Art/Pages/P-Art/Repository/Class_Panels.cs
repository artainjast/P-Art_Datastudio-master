using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using System.Data;
using System.Data.SqlClient;
using PArt.Pages.P_Art.Repository;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Panels
    {
        DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public List<Tbl_Parmin> GetPanelsById(List<int?> PanelIds)
        {

            var query = from panel in _db.Tbl_Parmin
                        where PanelIds.Contains(panel.ParminID)
                        select panel;

            return query.ToList();

        }

        public void UpdateNewsCount(int NewsId)
        {
            var query = from news in _db.Tbl_Relation_NewsParminPanel
                        where news.NewsId == NewsId
                        select news;



            foreach (var panel in query)
            {
                var parmin = _db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == panel.ParminPanelId);
                if (parmin.UnreadNews == null)
                {
                    parmin.UnreadNews = 1;
                }
                else
                {

                    parmin.UnreadNews += 1;
                }
            }

            _db.SaveChanges();
        }

        public Tbl_BultanFiles GetBultanPathById(int bultanId)
        {
            try
            {
                var query = (from bultan in _db.Tbl_BultanFiles
                             where bultan.BultanID == bultanId
                             select bultan).FirstOrDefault();

                if (query == null)
                {
                    return null;
                }
                else
                {
                    return query;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return null;
            }
        }

        public  Tbl_Parmin GetParminById(int ParminId)
        {
            var query = (from parmin in _db.Tbl_Parmin
                         where parmin.ParminID == ParminId
                         select parmin).FirstOrDefault();

            return query;
        }


        public Tbl_SocialMediaBultan GetParminById2(int ParminId)
        {
            var query = (from parmin in _db.Tbl_SocialMediaBultan
                         where parmin.ParminID_FK == ParminId
                         select parmin).FirstOrDefault();

            return query;
        }



        public List<int> GetLastUpdatePanel(int categoryId)
        {
            var db = new SqlConnection(_db.Database.Connection.ConnectionString);
            db.Open();
            SqlDataAdapter dtr = new SqlDataAdapter();
            dtr.SelectCommand = new SqlCommand();
            dtr.SelectCommand.Connection = db;
            dtr.SelectCommand.CommandText = @"select top 6 * from (select distinct(ParminPanelId) from (select top 1000 * from dbo.Tbl_Relation_NewsParminPanel where ParminPanelId in (
                                            select parminid from dbo.Tbl_Parmin
                                            where PanelCategory = " + categoryId +
                                            ") order by RelationId desc) as tbl) as tbl2";
            DataTable dt = new DataTable();
            dtr.Fill(dt);

            List<int> items = new List<int>();
            foreach (DataRow row in dt.Rows)
            {
                items.Add(int.Parse(row[0].ToString()));

            }

            return items;
        }

        public List<NamayandehPanels> GetPanelNamayandehById(List<int> ids)
        {
            var result = new List<NamayandehPanels>();

            var query = from panel in _db.Tbl_Parmin
                        where ids.Contains(panel.ParminID)
                        select panel;

            foreach (var item in query)
            {
                if (item.Description == null) continue;
                var newItem = new NamayandehPanels();
                newItem.PanelId = item.ParminID;
                newItem.PanelName = item.AgName;
                newItem.City = item.Description.Split(';')[1];
                newItem.District = item.Description.Split(';')[0];
                newItem.ImagePath = item.Description.Split(';')[2];
                result.Add(newItem);

            }
            return result;

        }

        public void UpdateKeywordAnalyz(int parminId, string analyzKeys)
        {
            var query = (from parmin in _db.Tbl_Parmin
                         where parmin.ParminID == parminId
                         select parmin).FirstOrDefault();

            if (query == null) return;
            //query.AnalyzKeywords = "";
            query.AnalyzKeywords = analyzKeys;
            _db.SaveChanges();
        }

        public string GetkeywordAnalyz(int parminId)
        {
            var query = (from parmin in _db.Tbl_Parmin
                         where parmin.ParminID == parminId
                         select parmin).FirstOrDefault();

            return query.AnalyzKeywords;

        }

        public List<Tbl_BultanFiles> GetBultanFiles(List<int> bultanIds)
        {
            var query = from file in _db.Tbl_BultanFiles
                        where bultanIds.Contains(file.BultanID)
                        select file;

            return query.ToList();
        }

        public void InsertParminLog(int userId, string userName, string ipAddress)
        {
            var user = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == userId);
            var parminId = Convert.ToInt32(user.ParminIds.Split(',')[0]);
            var parmin = _db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == parminId);
            if (parmin.hdParmin == true) return;

            var newItem = new Tbl_UserParminLog();
            newItem.IPAddress = ipAddress;
            newItem.LoginDateTime = DateTime.Now;
            newItem.UserID = userId;
            newItem.UserName = userName;
            _db.Tbl_UserParminLog.Add(newItem);
            _db.SaveChanges();
        }
        public void UpdateParminNimtaCodes(int ParminId)
        {

        }
        public int UpdateParminNimtaCodes(int ParminID, string NimtaCodes)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "NimtaCodes",NimtaCodes)
        };
            return Convert.ToInt32(Class_Ado.ExecuteNonQuery("", "p_NimtaPanel_Update", CommandType.StoredProcedure, sqlParams));
        }
        public class Panel_Type
        {

            public int ParminID { get; set; }
            public string ParminNimtaCodes { get; set; }

            public static Panel_Type GetFromDataRows(DataRow[] Rows)
            {
                List<Panel_Type> list = new List<Panel_Type>();
                foreach (DataRow r in Rows)
                {
                    Panel_Type item = new Panel_Type();
                    try { item.ParminID = Convert.ToInt32(r["ParminID"]); } catch { item.ParminID = 0; }
                    try { item.ParminNimtaCodes = r["ParminNimtaCodes"].ToString(); } catch { item.ParminNimtaCodes = string.Empty; }
                    list.Add(item);
                }
                return list.Count != 0 ? list[0] : null;
            }
        }
    }
}