﻿using System.Linq;
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
    /// Summary description for Part_LoadLast_Twitter_Source
    /// </summary>
    public class Part_LoadLast_Twitter_Source : IHttpHandler
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

                DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
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

                if (ParminTable.AccessTwitter == true)
                {
                    string fromTime = "0000";
                    string toTime = "2400";
                    long fromDateTimeIndex_ = Convert.ToInt64(fromDate.Replace("/", "") + fromTime);
                    long toDateTimeIndex_ = Convert.ToInt64(toDate.Replace("/", "") + toTime);

                    DataSet ds = Tbl_News_General.GetHighNumberMedia(parmin, fromDateTimeIndex_, toDateTimeIndex_, "");
                    AllMedia_HighSource mediaList = new AllMedia_HighSource();
                    //mediaList.AllMediaCount = Tbl_Media_CountType.GetFromDataRow(ds.Tables[0].Select());
                    //mediaList.NewsCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[1].Select());
                    //mediaList.NewsPaperCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[2].Select());

                    // telegramCount = mediaList.AllMediaCount.TelegramCount;
                    mediaList.TwitterCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[4].Select());
                    telegramCount = mediaList.TwitterCountList;
                    //  mediaList.TwitterCountList = Tbl_Media_Type.GetFromDataRows(ds.Tables[4].Select());
                }


                context.Response.Write(jsonSerializer.Serialize(telegramCount));
                //var websiteCount = _clsNews.GetAllNewsDataTable(1000000, 1, UserPanelList, null, true,null,fromDate, toDate, "", 1, null, "", "", "", "", false);
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