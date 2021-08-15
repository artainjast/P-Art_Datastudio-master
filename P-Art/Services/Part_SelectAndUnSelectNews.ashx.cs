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
    /// Summary description for Part_SelectAndUnSelectNews
    /// </summary>
    public class Part_SelectAndUnSelectNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            bool check = false;
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            if (context.Request["newsIds"] != null & context.Request["check"] != null & context.Request["p"] != null
                & context.Request["member"] != null)
            {
                try
                {
                    DB_NewsCenterEntities _dbStatic = new DB_NewsCenterEntities();
                    var memberId = Convert.ToInt32(context.Request["member"]);
                    var userPanelId = Convert.ToInt32(context.Request["p"]);
                    check = Convert.ToBoolean(context.Request["check"].ToString());
                    var NewsIdsListString = context.Request["newsIds"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    List<int> newsIdList = new List<int>();
                    foreach (var newsId in NewsIdsListString)
                    {
                        try
                        {
                            newsIdList.Add(Convert.ToInt32(newsId));
                        }
                        catch (Exception)
                        { }

                    }

                    if (check)
                    {
                        foreach (var newsId in newsIdList)
                        {
                            _dbStatic.Tbl_MemberNewsSelectionForBultan.Add(new Tbl_MemberNewsSelectionForBultan
                            {
                                MemberID = memberId,
                                NewsID = newsId,
                                PanelID = userPanelId
                            });
                        }

                    }
                    else
                    {
                        var items = _dbStatic.Tbl_MemberNewsSelectionForBultan.Where(n => n.PanelID == userPanelId && n.MemberID == memberId && newsIdList.Contains(n.NewsID)).ToList();
                        foreach (var item in items)
                        {
                            _dbStatic.Tbl_MemberNewsSelectionForBultan.Remove(item);
                        }

                    }
                    if( _dbStatic.SaveChanges() > 0)
                        context.Response.Write(jsonSerializer.Serialize(true));
                    else context.Response.Write(jsonSerializer.Serialize(false));

                }
                catch (Exception ex)
                {
                    context.Response.Write(jsonSerializer.Serialize(false));
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