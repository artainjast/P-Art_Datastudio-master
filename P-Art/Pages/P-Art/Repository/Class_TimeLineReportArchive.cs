using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using System.Data;
using System.Data.SqlClient;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_TimeLineReportArchive
    {
        DB_NewsCenterEntities db = new DB_NewsCenterEntities();
        Class_Ado ado = new Class_Ado();

        public int ArchiveId { get; set; }
        public int PanelId { get; set; }
        public string ArchiveDateIndex { get; set; }
        public string FromDateTimeIndex { get; set; }
        public string ToDateTimeIndex { get; set; }
        public string Title { get; set; }
        public string SelectedNews { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsCover { get; set; }
        public bool IsAboutPayesh { get; set; }
        public bool IsAboutProject { get; set; }
        public bool IsFehrest { get; set; }
        public bool IsProjectSubject { get; set; }
        public byte ReportType { get; set; }
        public string CreateUser { get; set; }
        public string AboutProject { get; set; }
        public string ProjectSubject { get; set; }
        public int BultanFileId { get; set; }
        public static List<Class_TimeLineReportArchive> GetFromDataRows(DataRow[] Rows)
        {
            List<Class_TimeLineReportArchive> list = new List<Class_TimeLineReportArchive>();
            foreach (DataRow r in Rows)
            {
                Class_TimeLineReportArchive item = new Class_TimeLineReportArchive();
                try { item.ArchiveId = Convert.ToInt32(r["ArchiveId"]); } catch { item.ArchiveId = 0; }
                try { item.BultanFileId = Convert.ToInt32(r["BultanFileId"]); } catch { item.BultanFileId = 0; }
                try { item.PanelId = Convert.ToInt32(r["PanelId"]); } catch { item.PanelId = 0; }
                try { item.FromDateTimeIndex = r["FromDateTimeIndex"].ToString(); } catch { item.FromDateTimeIndex = ""; }
                try { item.ToDateTimeIndex = r["ToDateTimeIndex"].ToString(); } catch { item.ToDateTimeIndex = ""; }
                try { item.Title = r["Title"].ToString(); } catch { item.Title = string.Empty; }
                try { item.ArchiveDateIndex = r["ArchiveDateIndex"].ToString(); } catch { item.ArchiveDateIndex = string.Empty; }
                try { item.SelectedNews = r["SelectedNews"].ToString(); } catch { item.SelectedNews = string.Empty; }
                try { item.CreateDate = Convert.ToDateTime(r["CreateDate"]); } catch { item.CreateDate = DateTime.Now; }
                try { item.IsCover = Convert.ToBoolean(r["IsCover"]); } catch { item.IsCover = false; }
                try { item.IsAboutPayesh = Convert.ToBoolean(r["IsAboutPayesh"]); } catch { item.IsAboutPayesh = false; }
                try { item.IsAboutProject = Convert.ToBoolean(r["IsAboutProject"]); } catch { item.IsAboutProject = false; }
                try { item.IsFehrest = Convert.ToBoolean(r["IsFehrest"]); } catch { item.IsFehrest = false; }
                try { item.IsProjectSubject = Convert.ToBoolean(r["IsProjectSubject"]); } catch { item.IsProjectSubject = false; }
                try { item.ReportType = Convert.ToByte(r["ReportType"]); } catch { item.ReportType = 1; }
                try { item.CreateUser = r["CreateUser"].ToString(); } catch { item.CreateUser = ""; }
                try { item.AboutProject = r["AboutProject"].ToString(); } catch { item.AboutProject = ""; }
                try { item.ProjectSubject = r["ProjectSubject"].ToString(); } catch { item.ProjectSubject = ""; }
                list.Add(item);
            }
            return list;
        }
        public List<Class_TimeLineReportArchive> GetList(string FromDateTimeIndex, string ToDateTimeIndex)
        {
            string cmd = "SELECT * FROM dbo.Tbl_TimeLineReportArchives WHERE ArchiveDateIndex BETWEEN '" +
                FromDateTimeIndex + "' AND '" + ToDateTimeIndex + "'";
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            return GetFromDataRows(ds.Tables[0].Select());
        }
        public Class_TimeLineReportArchive GetReport(int ArchiveId)
        {
            string cmd = "SELECT * FROM dbo.Tbl_TimeLineReportArchives WHERE ArchiveId =" +
                ArchiveId;
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
            List<Class_TimeLineReportArchive> list = GetFromDataRows(ds.Tables[0].Select());
            return list.Count != 0 ? list[0] : null;
        }
        public int Insert(int ArchiveId, int PanelId, string ArchiveDateIndex, string FromDateTimeIndex, string ToDateTimeIndex,
            string Title, string SelectedNews, DateTime CreateDate, bool IsCover, bool IsAboutPayesh, bool IsAboutProject,
            bool IsFehrest, bool IsProjectSubject, byte ReportType, string CreateUser, string AboutProject, string ProjectSubject,
          int BultanFileId)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
                new SqlParameter("@" + "PanelId",PanelId),
                new SqlParameter("@" + "ArchiveDateIndex",ArchiveDateIndex),
                new SqlParameter("@" + "FromDateTimeIndex",FromDateTimeIndex),
                new SqlParameter("@" + "ToDateTimeIndex",ToDateTimeIndex),
                new SqlParameter("@" + "Title",Title),
                new SqlParameter("@" + "SelectedNews",SelectedNews),
                new SqlParameter("@" + "CreateDate",CreateDate),
                new SqlParameter("@" + "IsCover",IsCover),
                new SqlParameter("@" + "IsAboutPayesh",IsAboutPayesh),
                new SqlParameter("@" + "IsAboutProject",IsAboutProject),
                new SqlParameter("@" + "IsFehrest",IsFehrest),
                new SqlParameter("@" + "IsProjectSubject",IsProjectSubject),
                new SqlParameter("@" + "ReportType",ReportType),
                new SqlParameter("@" + "CreateUser",CreateUser),
                new SqlParameter("@" + "AboutProject",AboutProject),
                new SqlParameter("@" + "ProjectSubject",ProjectSubject),
                new SqlParameter("@" + "BultanFileId",BultanFileId),
                new SqlParameter("@" + "Mode","insert"),

        };
           return Convert.ToInt32(Class_Ado.ExecuteScalar("", "p_NewsTimeLineReport_Update", CommandType.StoredProcedure, sqlParams));
        }


        public int InsertFocus(int ArchiveId, int PanelId, string ArchiveDateIndex, string FromDateTimeIndex, string ToDateTimeIndex,
    string Title, string SelectedNews, DateTime CreateDate, bool IsCover, bool IsAboutPayesh, bool IsAboutProject,
    bool IsFehrest, bool IsProjectSubject, byte ReportType, string CreateUser, string AboutProject, string ProjectSubject,
  int BultanFileId)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "ArchiveId",ArchiveId),
                new SqlParameter("@" + "PanelId",PanelId),
                new SqlParameter("@" + "ArchiveDateIndex",ArchiveDateIndex),
                new SqlParameter("@" + "FromDateTimeIndex",FromDateTimeIndex),
                new SqlParameter("@" + "ToDateTimeIndex",ToDateTimeIndex),
                new SqlParameter("@" + "Title",Title),
                new SqlParameter("@" + "SelectedNews",SelectedNews),
                new SqlParameter("@" + "CreateDate",CreateDate),
                new SqlParameter("@" + "IsCover",IsCover),
                new SqlParameter("@" + "IsAboutPayesh",IsAboutPayesh),
                new SqlParameter("@" + "IsAboutProject",IsAboutProject),
                new SqlParameter("@" + "IsFehrest",IsFehrest),
                new SqlParameter("@" + "IsProjectSubject",IsProjectSubject),
                new SqlParameter("@" + "ReportType",ReportType),
                new SqlParameter("@" + "CreateUser",CreateUser),
                new SqlParameter("@" + "AboutProject",AboutProject),
                new SqlParameter("@" + "ProjectSubject",ProjectSubject),
                new SqlParameter("@" + "BultanFileId",BultanFileId),
                new SqlParameter("@" + "Mode","insert"),

        };
            return Convert.ToInt32(Class_Ado.ExecuteScalar("", "p_NewsTimeLineReport_Update", CommandType.StoredProcedure, sqlParams));
        }


    }
}