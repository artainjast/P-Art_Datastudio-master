using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;
using PArt.Pages.P_Art.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P_Art
{
    public partial class ImportDBFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //access
        public DataTable FillDatabaseAccess(string cnnString, string command, List<OleDbParameter> sqlparams)
        {
            try
            {


                DataTable dt = new DataTable();
                using (var cnn = new OleDbConnection(cnnString))
                {
                    cnn.Open();

                    using (var dtr = new OleDbDataAdapter(command, cnn))
                    {


                        dtr.SelectCommand.Parameters.Clear();
                        if (sqlparams != null)
                        {
                            foreach (var param in sqlparams)
                            {
                                dtr.SelectCommand.Parameters.Add(param);
                            }
                        }
                        dtr.Fill(dt);

                        cnn.Close();


                    }
                    cnn.Close();
                }
                return dt;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //   Program.WriteLogException(ex, "Class_Ado_FillDatabase--sql--" + command);
                return null;
            }


        }

        protected void btnDo_Click(object sender, EventArgs e)
        {
            if (!fupFile.HasFile)
                return;
            Class_News _clsNews = new Class_News();

            var mapPath = Server.MapPath(".") + "db.mdb";

            fupFile.SaveAs(mapPath);
            string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mapPath + ";Jet OLEDB:Database Password=clsdir332211;";
            var dt = FillDatabaseAccess(conn, "SELECT * FROM Tbl_News", null);
            if (dt == null) return;

            var userSelectedNews = "";

            var count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                var newsId = Convert.ToInt32(dr["NewsId"] + "");
                var SiteId = Convert.ToInt32(dr["SiteId"] + "");
                var KeywordId = Convert.ToInt32(dr["KeywordId"] + "");
                var SiteType = Convert.ToInt32(dr["SiteType"] + "");
                var SiteTitle = (dr["SiteTitle"] + "").Trim();
                var NewsTitle = (dr["NewsTitle"] + "").Trim();
                var NewsLead = (dr["NewsLead"] + "").Trim();
                var NewsBody = (dr["NewsBody"] + "").Trim();
                var NewsTime = (dr["NewsTime"] + "").Trim();
                var NewsDate = (dr["NewsDate"] + "").Trim();
                var NewsDateIndex = (dr["NewsDateIndex"] + "").Trim();
                var NewsLink = (dr["NewsLink"] + "").Trim();
                var NewsPicture = (dr["NewsPicture"] + "").Trim();

                //
                userSelectedNews += "," + newsId + ",";


                //_clsNews.InsertNew(2160, SiteId, NewsTime, NewsTitle, NewsLead, NewsBody, NewsLink, NewsPicture, NewsDateIndex, KeywordId);
                //count++;
            }
            DB_NewsCenterEntities db = new DB_NewsCenterEntities();
            db.Database.ExecuteSqlCommand("update Tbl_AgenceMembers set SavedNewsIds = '" + userSelectedNews + "' where MemberID=" + 1241);

            ltCount.Text = count + "مورد ثبت شد" +" از " +dt.Rows.Count +" کل ";
        }
    }
}