using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_Art.Services
{
    /// <summary>
    /// Summary description for Part_SiteMember_Update
    /// </summary>
    public class Part_SiteMember_Update : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["s"] != null & context.Request["t"] != null &
                context.Request["p"] != null & context.Request["m"] != null)
            {
                try
                {
                    int siteOrChannelId = Convert.ToInt32(context.Request["s"]);
                    byte mediaType = Convert.ToByte(context.Request["t"]);
                    int panelId = Convert.ToInt32(context.Request["p"]);
                    int memberId = Convert.ToInt32(context.Request["m"]);
                    Class_MemberParminSites.UpdateMemeberPanelSiteSingel(memberId, siteOrChannelId, panelId, mediaType/*1=site 2=telegram*/);
                    context.Response.Write("0");
                }
                catch
                {
                    context.Response.Write("-1");
                }
            }
            else context.Response.Write("-1");
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
