using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace P_Art.Services
{
    /// <summary>
    /// Summary description for PService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public  List<Tbl_BultanArchive> GetBultanByDate(long fromDate, long toDate, string key)
        {
            Class_BultanArchive _cls = new Class_BultanArchive();
            var result = _cls.GetBultanByDate(fromDate, toDate, key);

            for (int i = 0; i <= result.Count - 1; i++)
            {
                result[i].Path = "http://new.e-sepaar.net/BultanArchive/" + result[i].Path.Replace("\\", "/");
            }
            return result;
        }
        [WebMethod]
        public DataTable GetDtBultanByDate(string fromDate, string toDate, string key)
        {
            try
            {


                var result = GetBultanByDate(long.Parse(fromDate.Replace("/", "")), long.Parse(toDate.Replace("/", "")), key);
                DataTable dt = new DataTable();
                dt.TableName = "DataArchive";
                dt.Columns.Add(new DataColumn { ColumnName = "ArchiveId", DataType = typeof(int) });
                dt.Columns.Add(new DataColumn { ColumnName = "NewsDateIndex", DataType = typeof(long) });
                dt.Columns.Add(new DataColumn { ColumnName = "PanelId", DataType = typeof(int) });
                dt.Columns.Add(new DataColumn { ColumnName = "Path", DataType = typeof(string) });

                foreach (var item in result)
                {
                    DataRow row = dt.NewRow();
                    row["ArchiveId"] = item.ArchiveId;
                    row["NewsDateIndex"] = item.NewsDateIndex;
                    row["PanelId"] = item.PanelId;
                    row["Path"] = item.Path;
                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
