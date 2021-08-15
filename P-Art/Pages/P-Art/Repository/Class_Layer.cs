using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P_Art.Pages.P_Art.ModelNews;
using FarsiLibrary.Utils;
using System.Data;
using PArt.Pages.P_Art.Repository;

namespace P_Art.Pages.P_Art.Repository
{
    public static class Class_Layer
    {
        public static void AddOnlineUser(Tbl_AgenceMembers user)
        {

            OnlineUsers().Add(user);
        }

        public static void DeleteOnlineUser(string SessionId)
        {
            try
            {
                for (int i = 0; i <= OnlineUsers().Count(); i++)
                {
                    if (OnlineUsers()[i].LastSessionID == SessionId)
                    {
                        OnlineUsers().RemoveAt(i);
                        return;
                    }
                }
            }
            catch
            {
                return;
            }

        }

        public static void SignOut()
        {
            try
            {
                if (HttpContext.Current.Session["CurrentDB"] != null)
                {
                    DeleteOnlineUser(HttpContext.Current.Session.SessionID);

                }
            }
            catch
            {
                HttpContext.Current.Session["CurrentDB"] = null;
                HttpContext.Current.Session.Clear();
            }
            HttpContext.Current.Session["CurrentDB"] = null;
            HttpContext.Current.Session.Clear();

        }
        public static void SignOutCookie()
        {
            try
            {
                string UserName = Class_Static.GetCookie("CurrentUser");
                if (UserName != null && UserName != string.Empty)
                {
                    Class_Static.RemoveCookie("CurrentUser");
                }
            }
            catch
            {
                //HttpContext.Current.Session["CurrentDB"] = null;
                //HttpContext.Current.Session.Clear();
            }
            //HttpContext.Current.Session["CurrentDB"] = null;
            //HttpContext.Current.Session.Clear();

        }
        public static List<Tbl_AgenceMembers> OnlineUsers()
        {
            if (HttpContext.Current.Application["OnlineUsers"] as List<Tbl_AgenceMembers> == null)
            {
                List<Tbl_AgenceMembers> OnlineUsers = new List<Tbl_AgenceMembers>();
                HttpContext.Current.Application["OnlineUsers"] = OnlineUsers;

            }
            return HttpContext.Current.Application["OnlineUsers"] as List<Tbl_AgenceMembers>;
        }

        public static void IsLogin()
        {
            if (HttpContext.Current.Session["CurrentUser"] == null)
            {
                HttpContext.Current.Response.Redirect("~/login");
            }
        }
        public static Tbl_AgenceMembers CurrentUser()
        {
            var db = new DB_NewsCenterEntities();
            // var currentUser = HttpContext.Current.Session["CurrentUser"] as Tbl_AgenceMembers;
            string UserName = Class_Static.GetCookie("CurrentUser");
            if (UserName != null && UserName != string.Empty)
            {
                return db.Tbl_AgenceMembers.FirstOrDefault(t => t.UserName == UserName);
            }
            else return null;
        }
        public static string CurrentUserCode()
        {
            return (HttpContext.Current.Session["CurrentUser"] as Tbl_AgenceMembers).ParminIds;


        }
        public static DataSet GetActivePanelData()
        {

            DataSet ds = PArtCore.Class.Class_Static.ExecuteDataset("", "p_Panel_GetExistNewsActiveList", CommandType.StoredProcedure);
            return ds;
           
        }
        public static List<int?> UserPanels()
        {
            var lst_Panel = new List<int?>();
            if (HttpContext.Current.Session["CurrentDB"] != null)
            {
                if (HttpContext.Current.Session["CurrentDB"].ToString() == "0")
                {
                    var panels = CurrentUser().ParminIds;



                    var numbers = panels.Split(',');
                    foreach (string s in numbers)
                    {
                        lst_Panel.Add(int.Parse(s));

                    }
                }
                else
                {

                    lst_Panel.Add(int.Parse(HttpContext.Current.Session["CurrentDB"].ToString()));
                }
            }
            else
            {

                var panels = CurrentUser().ParminIds;



                var numbers = panels.Split(',');
                foreach (string s in numbers)
                {
                    lst_Panel.Add(int.Parse(s));

                }
            }

            return lst_Panel;

        }
        public static List<int?> UserAllPanels()
        {
            var lst_Panel = new List<int?>();

            var panels = CurrentUser().ParminIds;

            var numbers = panels.Split(',');
            foreach (string s in numbers)
            {
                lst_Panel.Add(int.Parse(s));

            }

            return lst_Panel;

        }
        public static List<string> UserHighlight()
        {
            var lst_items = new List<string>();

            if (CurrentUser().keywords != null)
            {
                var items = CurrentUser().keywords.Split(',');

                foreach (var str in items)
                {
                    string s = "";

                    s = str.Replace('ی', 'ي');
                    var strCon = s;
                    strCon = strCon.Replace('ي', 'ی');

                    lst_items.Add(s);
                    lst_items.Add(strCon);
                }
            }


            return lst_items;
        }
        public static bool HasSwitch()
        {
            var panels = CurrentUser().ParminIds;
            if (panels.Split(',').Count() > 1)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public static void CheckSession()
        {
            string UserName = Class_Static.GetCookie("CurrentUser");
            if (UserName == null || UserName == string.Empty)
            {
                SignOutCookie();
                HttpContext.Current.Response.Redirect("~/Login");
            }

            //    if (HttpContext.Current.Session["CurrentUser"] == null)
            //{
            //    SignOutCookie();
            //    HttpContext.Current.Response.Redirect("~/Login");
            //}
        }
        public static bool CheckSession_Status()
        {
            string UserName = Class_Static.GetCookie("CurrentUser");
            if (UserName == null || UserName == string.Empty)
            {
                return false;
            }
            return true;

            //if (HttpContext.Current.Session["CurrentUser"] == null)
            //{
            //    return false;
            //}
            //return true;
        }
        public static DateTime ShamsiToMiladi(string Shamsi)
        {
            PersianDate pd = new PersianDate(Shamsi);
            return DateTime.Parse(PersianDateConverter.ToGregorianDate(pd));
        }
        public static string MiladiToShamsi(object Miladi)
        {
            try
            {


                if (Miladi == null) return "";
                if (Miladi.ToString() == "") return "";
                return PersianDateConverter.ToPersianDate(DateTime.Parse(Miladi.ToString())).ToString("d");
            }
            catch
            {
                return "";
            }

        }
    }
}