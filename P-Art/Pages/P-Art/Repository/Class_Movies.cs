using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using System.Data.SqlClient;
using System.Data;

namespace P_Art.Pages.P_Art.Repository
{

    public class Class_Movies
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();
        public List<Tbl_Movies> GetAllMovie(int PageCount, int PageIndex, List<int?> PanelIds, bool? IsRead, string search, bool? foreignMovie)
        {


            IQueryable<Tbl_Movies> query;

            query = (from t in _db.Tbl_Movies
                     where
                         (from t0 in _db.Tbl_Relation_MovieParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.movieId).Contains(t.MovieID)
                          && t.Type == 0
                     orderby t.VideoDateIndex descending
                     select t).Skip((PageIndex - 1) * PageCount).Take(PageCount);



            if (search != "")
            {
                search = search.Replace('ی', 'ي');
                var strCon = search;
                strCon = strCon.Replace('ي', 'ی');


                query = query.Where(p => p.Title.Contains(search) || p.Title.Contains(strCon));

            }




            if (foreignMovie != null)
            {
                query = query.Where(p => p.IsForeign == foreignMovie);
            }

            return query.ToList();

        }
        public List<Tbl_Movies> GetAllMovie(int PageCount, int PageIndex, List<int?> PanelIds, bool? IsRead, string search, bool? foreignMovie, List<string> networks)
        {


            IQueryable<Tbl_Movies> query;

            query = (from t in _db.Tbl_Movies
                     where
                         (from t0 in _db.Tbl_Relation_MovieParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.movieId).Contains(t.MovieID)
                          && t.Type == 0 &&
                          networks.Contains(t.NetworkName)
                         && t.Title.Contains(search)
                     orderby t.VideoDateIndex descending
                     select t).Skip((PageIndex - 1) * PageCount).Take(PageCount);



            if (search != "")
            {
                search = search.Replace('ی', 'ي');
                var strCon = search;
                strCon = strCon.Replace('ي', 'ی');


                query = query.Where(p => p.Title.Contains(search) || p.Title.Contains(strCon));

            }




            if (foreignMovie != null)
            {
                query = query.Where(p => p.IsForeign == foreignMovie);
            }

            return query.ToList();

        }
        public List<Tbl_Movies> GetAllMovie(int PageCount, int PageIndex, List<int?> PanelIds, bool? IsRead, string search, bool? foreignMovie, List<string> networks, int fromIndex, int toIndex)
        {
            //string panelIds = "";
            //string network = "";
            //foreach (int i in PanelIds)
            //{ panelIds += i + ","; }
            //foreach (string n in networks)
            //{ network += n + ","; }
            //string cmd = "SELECT * FROM dbo.Tbl_Movies WHERE MovieID IN (SELECT movieId FROM dbo.Tbl_Relation_MovieParminPanel WHERE ParminPanelId IN (" +
            //  panelIds + ")) AND [Type] = 0 AND NetworkName IN (" + network + ") AND Title LIKE N'%" + search +
            //  "%' AND VideoDateIndex BETWEEN '" + fromIndex + "' AND '" + toIndex + "' ORDER BY VideoDateIndex DESC";

            //SqlConnection _Cnn = new SqlConnection(_db.Database.Connection.ConnectionString);
            //_Cnn.Open();

            //SqlDataAdapter dtr = new SqlDataAdapter();
            //dtr.SelectCommand = new SqlCommand();
            //dtr.SelectCommand.Connection = _Cnn;
            //dtr.SelectCommand.CommandText = cmd;
            //dtr.SelectCommand.CommandTimeout = 20000;
            //DataTable dt = new DataTable();
            //dtr.Fill(dt);

            //_Cnn.Close();



            //return (from item in _db.Tbl_Movies
            //        where item.CompanyCode == companyCode
            //        select item).ToList<Karsa_Profile_Company>().FirstOrDefault();


            IQueryable<Tbl_Movies> query;

            query = (from t in _db.Tbl_Movies
                     where
                         (from t0 in _db.Tbl_Relation_MovieParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.movieId).Contains(t.MovieID)
                          && t.Type == 0 &&
                          networks.Contains(t.NetworkName)
                         && t.Title.Contains(search)
                     orderby t.VideoDateIndex descending
                     select t);
            int f = Convert.ToInt32(fromIndex);
            int tt  = Convert.ToInt32(toIndex);
            query = query.Take(PageCount);

            if (search != "")
            {
                search = search.Replace('ی', 'ي');
                var strCon = search;
                strCon = strCon.Replace('ي', 'ی');


                query = query.Where(p => p.Title.Contains(search) || p.Title.Contains(strCon));

            }




            if (foreignMovie != null)
            {
                query = query.Where(p => p.IsForeign == foreignMovie);
            }

            return query.ToList();

        }
        public List<Tbl_Movies> GetAllMovie(int PageCount, int PageIndex, List<int?> PanelIds, bool? IsRead, string search, bool? foreignMovie, string dateIndex)
        {


            IQueryable<Tbl_Movies> query;

            query = (from t in _db.Tbl_Movies
                     where
                         (from t0 in _db.Tbl_Relation_MovieParminPanel
                          where
                          PanelIds.Contains(t0.ParminPanelId)
                          select t0.movieId).Contains(t.MovieID)
                          && t.Type == 0 && t.VideoDateIndex == dateIndex
                     orderby t.MovieID descending
                     select t).Skip((PageIndex - 1) * PageCount).Take(PageCount);



            if (search != "")
            {
                search = search.Replace('ی', 'ي');
                var strCon = search;
                strCon = strCon.Replace('ي', 'ی');


                query = query.Where(p => p.Title.Contains(search) || p.Title.Contains(strCon));

            }




            if (foreignMovie != null)
            {
                query = query.Where(p => p.IsForeign == foreignMovie);
            }

            return query.ToList();

        }
        public Tbl_Movies GetMovieById(int MovieId, List<int?> PanelIds)
        {
            var query = (from t in _db.Tbl_Movies
                         where
                             (from t0 in _db.Tbl_Relation_MovieParminPanel
                              where
                              PanelIds.Contains(t0.ParminPanelId)
                              select t0.movieId).Contains(t.MovieID)
                              && t.MovieID == MovieId
                         orderby t.MovieID descending
                         select t).FirstOrDefault();

            if (query != null)
                query.IsView = true;
            _db.SaveChanges();
            return query;
        }
        public long GetMovieCount(List<int?> PanelIds, bool? IsView)
        {
            IQueryable<Tbl_Movies> query;

            query = from t in _db.Tbl_Movies
                    where
                        (from t0 in _db.Tbl_Relation_MovieParminPanel
                         where
                         PanelIds.Contains(t0.ParminPanelId)
                         select t0.movieId).Contains(t.MovieID)
                    orderby t.MovieID descending
                    select t;




            if (IsView == null)
            {
                query = query.Where(p => p.IsView == null || p.IsView == false);
            }
            else if (IsView == false)
            {

                query = query.Where(p => p.IsView == false);

            }
            else
            {
                query = query.Where(p => p.IsView == true);
            }

            return query.Count();
        }

        public class Tbl_Type_Movie
        {
            public int MovieID { get; set; }
            public Nullable<long> PackageID { get; set; }
            public Nullable<int> CompanyType { get; set; }
            public Nullable<int> MediaKitGroupID { get; set; }
            public Nullable<int> TizerPackCount { get; set; }
            public Nullable<bool> Active { get; set; }
            public string PosterPath { get; set; }
            public string VideoPath { get; set; }
            public string Title { get; set; }
            public Nullable<int> ViewCount { get; set; }
            public Nullable<int> Rate { get; set; }
            public int CreateUser { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<int> EditUser { get; set; }
            public Nullable<System.DateTime> EditDate { get; set; }
            public string NetworkName { get; set; }
            public Nullable<int> NetworkGroupID { get; set; }
            public string ProgramName { get; set; }
            public string ProgramTime { get; set; }
            public string PlayTime { get; set; }
            public string VideoTime { get; set; }
            public string VideoDate { get; set; }
            public Nullable<bool> IsView { get; set; }
            public Nullable<bool> IsForeign { get; set; }
            public Nullable<int> CampainId { get; set; }
            public Nullable<int> Position { get; set; }
            public Nullable<int> weekdayindex { get; set; }
            public Nullable<int> Periority { get; set; }
            public Nullable<int> Type { get; set; }
            public Nullable<int> Percent { get; set; }
            public Nullable<int> Tabaghe { get; set; }
            public Nullable<long> DefaultPrice { get; set; }
            public Nullable<long> VideoPriceGroup { get; set; }
            public int VideoDateIndex { get; set; }
            public Nullable<bool> SendAllInOneTelegram { get; set; }
        }

    }
}