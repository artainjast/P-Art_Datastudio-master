using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using System.Data;
using System.Data.SqlClient;

namespace P_Art.Pages.P_Art.Repository
{

    public class Class_Nimta
    {
        DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        Class_Ado ado = new Class_Ado();
        public List<NimtaType> GetTodayNimta()
        {
            var lastNimta = (from n in db.Tbl_Nimta
                             orderby n.NimtaID descending
                             select n).Take(1);

            var query = (from n in db.Tbl_Nimta
                         where n.NimtaDate == lastNimta.FirstOrDefault().NimtaDate
                         select n).ToList();
            return ConvertNimtaResult(query.ToList());
        }
        //public List<NimtaType> GetTodayNimta()
        //{

        //    var lastNimta = (from n in db.Tbl_Nimta
        //                     orderby n.NimtaID descending
        //                     select n).Take(1);

        //    var query = (from n in db.Tbl_Nimta
        //                 where n.NimtaDate == lastNimta.FirstOrDefault().NimtaDate
        //                 select n).ToList();
        //    return ConvertNimtaResult(query.ToList());
        //}
        public List<NimtaType> GetNimtaByDate(string nimtaDate)
        {
            var lastNimta = (from n in db.Tbl_Nimta
                             where n.NimtaDate == nimtaDate
                             orderby n.NimtaID descending
                             select n).Take(1);

            var query = (from n in db.Tbl_Nimta
                         where n.NimtaDate == lastNimta.FirstOrDefault().NimtaDate
                         select n).ToList();
            return ConvertNimtaResult(query.ToList());
        }

        private List<NimtaType> ConvertNimtaResult(List<Tbl_Nimta> NimtaList)
        {
            if (NimtaList == null) return null;
            var items = new List<NimtaType>();
            foreach (var item in NimtaList)
            {
                var newItem = new NimtaType();
                newItem.LargePath = "http://media.e-sepaar.net/nimta/" + item.LargePath;
                newItem.NimtaDate = item.NimtaDate;
                newItem.NimtaId = item.NimtaID;
                newItem.PreviewPath = "http://media.e-sepaar.net/nimta/" + item.PreviewPath;
                newItem.Title = item.Title;

                if (item.OriginalImage == null)
                {
                    newItem.originalPath = newItem.LargePath;
                }
                else
                {
                    newItem.originalPath = "http://media.e-sepaar.net/nimta/" + item.OriginalImage;
                }


                items.Add(newItem);
            }

            return items;

        }
        public DataSet GetData(int ParminID, string NimtaDate)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ParminID",ParminID),
                new SqlParameter("@" + "NimtaDate",NimtaDate)
        };
            return Class_Ado.ExecuteDataset("", "p_Nimta_Getdata", CommandType.StoredProcedure, sqlParams);
        }
        public DataSet GetReportData(string SiteCodes, string NimtaDate)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "SiteCodes",SiteCodes),
                new SqlParameter("@" + "NimtaDate",NimtaDate)
        };
            return Class_Ado.ExecuteDataset("", "p_Nimta_Report_Getdata", CommandType.StoredProcedure, sqlParams);
        }
        public static List<NimtaType> GetFromDataRows(DataRow[] Rows)
        {
            List<NimtaType> list = new List<NimtaType>();
            foreach (DataRow r in Rows)
            {
                NimtaType item = new NimtaType();
                try { item.NimtaId = Convert.ToInt32(r["NimtaId"]); } catch { item.NimtaId = 0; }
                try { item.SiteID_FK = Convert.ToInt32(r["SiteID_FK"]); } catch { item.SiteID_FK = 0; }
                try { item.NimtaDate = r["NimtaDate"].ToString(); } catch { item.NimtaDate = ""; }
                try { item.Title = r["Title"].ToString(); } catch { item.Title = string.Empty; }
                try { item.Logo = r["Logo"].ToString(); } catch { item.Logo = string.Empty; }
                try { item.OriginalImage = "http://media.e-sepaar.net/nimta/" + r["OriginalImage"].ToString(); } catch { item.OriginalImage = string.Empty; }
                try { item.PreviewPath = "http://media.e-sepaar.net/nimta/" + r["PreviewPath"].ToString(); } catch { item.PreviewPath = string.Empty; }
                try { item.LargePath = "http://media.e-sepaar.net/nimta/" + r["LargePath"].ToString(); } catch { item.LargePath = string.Empty; }
                list.Add(item);
            }
            return list;
        }
    }
    public class NimtaType
    {

        public int NimtaId { get; set; }

        public string NimtaDate { get; set; }

        public string PreviewPath { get; set; }

        public string LargePath { get; set; }

        public string Title { get; set; }
        public string originalPath { get; set; }
        public int SiteID_FK { get; set; }
        public string Logo { get; set; }
        public string OriginalImage { get; set; }

    }


}