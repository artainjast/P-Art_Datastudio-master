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
    /// Summary description for Part_LoadLast_Instagram_Source
    /// </summary>
    public class Part_LoadLast_Instagram_Source : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            List<Tbl_Media_Type> telegramCount = new List<Tbl_Media_Type>();
            if (context.Request["count"] != null & context.Request["fromDate"] != null &
                context.Request["toDate"] != null & context.Request["p"] != null)
            {

                string fromDate = context.Request["fromDate"].ToString();
                string toDate = context.Request["toDate"].ToString();
                int parmin = Convert.ToInt32(context.Request["p"].ToString());
                Class_News _clsNews = new Class_News();
                var fromDateIndex = Convert.ToInt64(fromDate.Replace("/", ""));
                var toDateIndex = Convert.ToInt64(toDate.Replace("/", ""));

                var fromDateTimeIndex = fromDateIndex * 10000;
                var toDateTimeIndex = toDateIndex * 10000;
                telegramCount = new List<Tbl_Media_Type>();

                DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
                //if (!Class_Layer.CheckSession_Status())
                //{

                //    HttpContext.Current.Response.Redirect("~/Welcome/");
                //}
                //var UserPanelList = Class_Layer.UserPanels();
                var ParminTable = _db.Tbl_Parmin.Where(p => p.ParminID == parmin).FirstOrDefault();


                var keyIds = "";
                List<int> Keys = new List<int>();
                foreach (var keySpil in keyIds.Split(','))
                {
                    try
                    {
                        Keys.Add(Convert.ToInt32(keySpil));
                    }
                    catch
                    {
                        continue;
                    }
                }

                context.Response.Write(jsonSerializer.Serialize(telegramCount));
            }
            else
            {
                context.Response.Write(jsonSerializer.Serialize(telegramCount));
            }
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