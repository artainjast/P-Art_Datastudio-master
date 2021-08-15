using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using System.Data;
namespace P_Art.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PService.svc or PService.svc.cs at the Solution Explorer and start debugging.
    public class PService : IPService
    {
        public List<Tbl_BultanArchive> GetBultanByDate(long fromDate, long toDate, string key)
        {
            Class_BultanArchive _cls = new Class_BultanArchive();
            var result = _cls.GetBultanByDate(fromDate, toDate, key);

            for (int i = 0; i <= result.Count - 1; i++)
            {
                result[i].Path = "http://new.e-sepaar.net/BultanArchive/" + result[i].Path.Replace("\\", "/");
            }
            return result;
        }

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

                foreach(var item in result)
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
