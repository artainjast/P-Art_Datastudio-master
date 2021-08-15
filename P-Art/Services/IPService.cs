using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PArt.Pages.P_Art.Repository;
using P_Art.Pages.P_Art.ModelNews;
using System.Data;

namespace P_Art.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPService" in both code and config file together.
    [ServiceContract]
    public interface IPService
    {
        [OperationContract]
        List<Tbl_BultanArchive> GetBultanByDate(long fromDate, long toDate,string key);

        [OperationContract]
        DataTable GetDtBultanByDate(string fromDate, string toDate, string key);

    }
}
