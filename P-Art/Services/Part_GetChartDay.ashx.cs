using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using PArt.Core;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace P_Art.Services
{
    /// <summary>
    /// Summary description for Part_GetChartDay
    /// </summary>
    public class Part_GetChartDay : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int date = Convert.ToInt32(context.Request["date"].ToString());

            Class_Zaman _clsZm = new Class_Zaman();
            var fromDate = "";
            var toDate = "";
            var today = _clsZm.Today();
            //   txt_fromDate.Value = _clsZm.AddDayShamsi(today ,-2);

            switch (date)
            {
                case (1):
                    {
                        toDate = today;
                        fromDate = today;
                        break;
                    }
                case (3):
                    {
                        toDate = today;
                        fromDate = _clsZm.AddDayShamsi(today, -2);
                        break;
                    }
                case (7):
                    {
                        toDate = today;
                        fromDate = _clsZm.AddDayShamsi(today, -6);
                        break;
                    }
                case (30):
                    {
                        toDate = today;
                        fromDate = _clsZm.AddDayShamsi(today, -29);
                        break;
                    }
                default: break;
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            context.Response.Write(jsonSerializer.Serialize(fromDate + ";" + toDate));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}