using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_MemberParminSites
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public List<Tbl_MemberParminSites> GetMemberParminSite(int MemberId, int PanelID)
        {
            var query = from site in _db.Tbl_MemberParminSites
                        where site.MemberID == MemberId &&
                        site.PanelID == PanelID
                        select site;
            return query.ToList();

        }
        public static void UpdateMemeberPanelSite(int MemberID, string SiteIDs, int PanelID, byte MediaType)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "MemberID",MemberID),
                new SqlParameter("@" + "SiteIDs",SiteIDs),
                 new SqlParameter("@" + "PanelID",PanelID),
                  new SqlParameter("@" + "MediaType",MediaType)
        };

            int result = PArtCore.Class.Class_Static.ExecuteNonQuery("", "p_Member_Site_Update", CommandType.StoredProcedure, sqlParams);

        }

        public static void UpdateMemeberPanelSiteSingel(int MemberID, int SiteID, int PanelID, byte MediaType)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@" + "MemberID",MemberID),
                new SqlParameter("@" + "SiteID",SiteID),
                 new SqlParameter("@" + "PanelID",PanelID),
                  new SqlParameter("@" + "MediaType",MediaType)
        };

            int result = PArtCore.Class.Class_Static.ExecuteNonQuery("", "p_Member_Site_Singel_Update", CommandType.StoredProcedure, sqlParams);

        }
    }
}