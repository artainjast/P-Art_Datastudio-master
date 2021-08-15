using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using P_Art.Pages.P_Art.Repository;


namespace PArt.Pages.P_Art.Repository
{

    public class Class_User
    {
        private DB_NewsCenterEntities _db = new DB_NewsCenterEntities();

        public Tbl_AgenceMembers AuthenticateUser(string UserName, string Password)
        {
            try
            {
                var query = (from r in _db.Tbl_AgenceMembers
                             where r.UserName == UserName
                             && r.Password == Password
                             && r.AgenceID == 54
                             && r.Active == true
                             select r).FirstOrDefault();

                if (query != null)
                {
                    //Update Last Login Informarion
                    try
                    {
                        query.LastSessionID = HttpContext.Current.Session.SessionID;
                        query.LastLogin = DateTime.Now;

                        _db.SaveChanges();
                    }
                    catch
                    {
                        return query;
                    }

                    Insert_Log_Login(query.MemberID);

                }
                return query;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                return null;
            }
        }

        public void SetActiveUser(Tbl_AgenceMembers user)
        {

            HttpContext.Current.Session["ActiveUser"] = user;
        }

        public Tbl_Users GetDBUser(int userId)
        {
            var query = (from u in _db.Tbl_Users
                         where u.UserID == userId
                         select u).FirstOrDefault();

            return query;

        }

        public void Insert_Log_Login(int memberId)
        {
            try
            {
                var user = _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == memberId);
                var parminId = Convert.ToInt32(user.ParminIds.Split(',')[0]);
                var parmin = _db.Tbl_Parmin.FirstOrDefault(t => t.ParminID == parminId);
                if (parmin.hdParmin == true) return;
                Tbl_Log_Login newItem = new Tbl_Log_Login();
                newItem.MemberId = memberId;
                newItem.LoginDate = DateTime.Now;

                _db.Tbl_Log_Login.Add(newItem);
                _db.SaveChanges();
            }
            catch
            {

            }
        }



        public Tbl_AgenceMembers SelectSingle(int memberId)
        {
            return _db.Tbl_AgenceMembers.FirstOrDefault(t => t.MemberID == memberId);
        }
        public Tbl_AgenceMembers UpdateUserSortOrder(int memberId, string siteIds)
        {
            var item = SelectSingle(memberId);
            if (item == null)
                return null;
            item.ResourceSortingOrder = siteIds;
            _db.SaveChanges();
            return item;

        }


        public Tbl_AgenceMembers SelectByUser(string username)
        {
            return _db.Tbl_AgenceMembers.FirstOrDefault(t => t.UserName == username);

        }
    }

}
