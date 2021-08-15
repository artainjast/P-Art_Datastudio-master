using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace P_Art.Services
{
    /// <summary>
    /// Summary description for Part_MediaAnalyze_GetMediaShahed
    /// </summary>
    public class Part_MediaAnalyze_GetMediaShahed : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["id"] != null &  context.Request["t"] != null)
            {
                int newsid = Convert.ToInt32(context.Request["id"].ToString());
                string type = context.Request["t"].ToString();
                
                DataSet ds = Tbl_News_General.GetMediaShahed(newsid, type);
                AllMedia_General mediaList = new AllMedia_General();
                mediaList.NewsList = Tbl_News_General.GetFromDataRows(ds.Tables[0].Select());
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                context.Response.Write(jsonSerializer.Serialize(mediaList));
            }
            else context.Response.Write("");
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