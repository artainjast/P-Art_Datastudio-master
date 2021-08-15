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
using System.Text;

namespace P_Art.Services
{
    /// <summary>
    /// Summary description for Part_SetBultanArchive
    /// </summary>
    public class Part_SetBultanArchive : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            if (context.Request["fromDate"] != null & context.Request["toDate"] != null & context.Request["bultanTitle"] != null & context.Request["fromTime"] != null
                 & context.Request["toTime"] != null & context.Request["allowNewspaper"] != null & context.Request["galleryNewspaper"] != null
                  & context.Request["arz"] != null & context.Request["sima"] != null & context.Request["highLight"] != null & context.Request["allowGroup"] != null
                   & context.Request["related"] != null & context.Request["selectedBultan"] != null & context.Request["isArchive"] != null
                    & context.Request["chart"] != null & context.Request["jeld"] != null & context.Request["BultanType"] != null
                     & context.Request["linkUrl"] != null & context.Request["p"] != null
                & context.Request["member"] != null)
            {
                try
                {
                    DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
                    //var parmin = Class_Layer.UserPanels().FirstOrDefault().Value;

                    string fromDate = context.Request["fromDate"].ToString().Replace("/", "");
                    string toDate = context.Request["toDate"].ToString().Replace("/", "");
                    string fromTime = context.Request["fromTime"].ToString().Replace(":", "");
                    string toTime = context.Request["toTime"].ToString().Replace(":", "");
                    var memberId = Convert.ToInt32(context.Request["member"]);
                    var userPanelId = Convert.ToInt32(context.Request["p"]);

                    long fromDateTime = Convert.ToInt64(fromDate + (string.IsNullOrEmpty(fromTime) ? "0000" : fromTime));
                    long toDateTime = Convert.ToInt64(toDate + (string.IsNullOrEmpty(toTime) ? "2500" : toTime));

                    //List<int> AllNewsInSelectedTime = _dbStatic.Tbl_News
                    //    .Where(n => n.ParminId == userPanelId && n.NewsDateTimeIndex >= fromDateTime && n.NewsDateTimeIndex <= toDateTime)
                    //    .Select(n => n.NewsID).ToList();


                    Class_BultanArchive archive = new Class_BultanArchive();

                    StringBuilder str = new StringBuilder();

                  

                    var NewsList = _dbStatic.v_MemberNewSelectionForBultan
                            .Where(n => n.PanelID == userPanelId && n.MemberID == memberId && n.NewsDateTimeIndex >= fromDateTime && n.NewsDateTimeIndex <= toDateTime)
                            .Select(n => n.NewsID).ToList();

                    foreach (var item in NewsList)
                    {
                        str.Append(item.ToString() + ",");
                    }


                    int result = archive.InsertArchive(Convert.ToInt64(PArt.Pages.P_Art.Repository.Class_Static.ShamisiWithoutSlash(fromDate)),
                        userPanelId, context.Request["linkUrl"], Class_Static.ConvertToLatinNumberSam(context.Request["bultanTitle"]), str.ToString().Substring(0, str.Length - 1), fromDate, toDate, fromTime, toTime, Convert.ToBoolean(context.Request["allowNewspaper"]),
                       Convert.ToBoolean(context.Request["galleryNewspaper"]), Convert.ToBoolean(context.Request["arz"]), Convert.ToBoolean(context.Request["sima"]), Convert.ToBoolean(context.Request["highLight"]), Convert.ToBoolean(context.Request["allowGroup"]),
                      Convert.ToBoolean(context.Request["related"]), Convert.ToInt32(context.Request["selectedBultan"]), Convert.ToBoolean(context.Request["isArchive"]), Convert.ToBoolean(context.Request["chart"]), Convert.ToBoolean(context.Request["jeld"]), Convert.ToByte(context.Request["BultanType"]));
                    context.Response.Write(jsonSerializer.Serialize(result));
                }
                catch
                {
                    context.Response.Write(jsonSerializer.Serialize(0));
                }
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