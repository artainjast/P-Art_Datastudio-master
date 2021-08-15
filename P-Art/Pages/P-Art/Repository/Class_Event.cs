using P_Art.Pages.P_Art.ModelNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_Event
    {
        //0 login
        //1 Insert News
        //2 Edit News
        //3 Delete News
        //4 insert movie
        //5 edit movie
        //6 insert sound
        //7 edit sound

        public void InsertEvent(int EventType, int UserID, int NewsID,string title)
        {
            try
            {
                DB_NewsCenterEntities db = new DB_NewsCenterEntities();

                Tbl_Events ev = new Tbl_Events();
                ev.CreateDate = DateTime.Now;
                ev.EventType = EventType;
                ev.UserID = UserID;
                ev.NewsID = NewsID;
                ev.Title = title;
                db.Tbl_Events.Add(ev);

                db.SaveChanges();
            }
            catch
            {

            }


        }

        public void InsertError(int userID, string title, string Message)
        {
            try
            {
                DB_NewsCenterEntities db = new DB_NewsCenterEntities();
                Tbl_Errors err = new Tbl_Errors();
                err.DDate = DateTime.Now;
                err.ErrorMessage = Message;
                err.Title = title;

                db.Tbl_Errors.Add(err);
                db.SaveChanges();
            }
            catch
            {

            }
        }



    }
}