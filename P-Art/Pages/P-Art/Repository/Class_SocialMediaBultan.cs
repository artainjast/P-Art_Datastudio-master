using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using System.Data;
using System.Data.SqlClient;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_SocialMediaBultan
    {
        DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        Class_Ado ado = new Class_Ado();
        public int SocialMediaBultanID { get; set; }
        public int ParminID_FK { get; set; }
        public string Title { get; set; }
        public string CreateDate { get; set; }
        public int CreateUser_FK { get; set; }
        public string LastPDFPath { get; set; }
        public string LastWordPath { get; set; }
        public string SelectedPosts { get; set; }
        public int SocialPostId_FK { get; set; }

        public bool AllowChart { get; set; }

        public static List<Class_SocialMediaBultan> GetFromDataRows(DataRow[] Rows)
        {
            List<Class_SocialMediaBultan> list = new List<Class_SocialMediaBultan>();
            foreach (DataRow r in Rows)
            {
                Class_SocialMediaBultan item = new Class_SocialMediaBultan();
                try { item.SocialMediaBultanID = Convert.ToInt32(r["SocialMediaBultanID"]); } catch { item.SocialMediaBultanID = 0; }
                try { item.ParminID_FK = Convert.ToInt32(r["ParminID_FK"]); } catch { item.ParminID_FK = 0; }
                try { item.CreateUser_FK = Convert.ToInt32(r["CreateUser_FK"]); } catch { item.CreateUser_FK = 0; }
                try { item.Title = r["Title"].ToString(); } catch { item.Title = ""; }
                try { item.LastPDFPath = r["LastPDFPath"].ToString(); } catch { item.LastPDFPath = ""; }
                try { item.CreateDate = r["CreateDate"].ToString(); } catch { item.CreateDate = string.Empty; }
                try { item.LastWordPath = r["LastWordPath"].ToString(); } catch { item.LastWordPath = string.Empty; }
                try { item.SelectedPosts = r["SelectedPosts"].ToString(); } catch { item.SelectedPosts = string.Empty; }
                try { item.CreateDate = r["CreateDate"].ToString(); } catch { item.CreateDate = ""; }
                try { item.SocialPostId_FK = Convert.ToInt32(r["SocialPostId_FK"]); } catch { item.SocialPostId_FK = 0; }

                try { item.AllowChart = Convert.ToBoolean(r["AllowChart"]); } catch { item.AllowChart = false; }
                list.Add(item);
            }
            return list;
        }
        public List<Class_SocialMediaBultan> GetList(string FromDateTimeIndex, string ToDateTimeIndex)
        {
            string cmd = "SELECT * FROM dbo.Tbl_SocialMediaBultan WHERE CreateDate BETWEEN '" +
                FromDateTimeIndex + "' AND '" + ToDateTimeIndex + "'";
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            return GetFromDataRows(ds.Tables[0].Select());
        }
        public Class_SocialMediaBultan GetReport(int SocialMediaBultanID)
        {
            string cmd = "SELECT * FROM dbo.Tbl_SocialMediaBultan WHERE SocialMediaBultanID =" +
                SocialMediaBultanID;
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            List<Class_SocialMediaBultan> list = GetFromDataRows(ds.Tables[0].Select());
            return list.Count != 0 ? list[0] : null;
        }
    }
}