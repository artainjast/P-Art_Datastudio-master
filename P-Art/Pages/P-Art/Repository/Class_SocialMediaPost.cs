using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PArt.Pages.P_Art.Repository;
using System.Data;
using System.Data.SqlClient;
using P_Art.Pages.P_Art.ModelNews;

namespace P_Art.Pages.P_Art.Repository
{
    public class Class_SocialMediaPost
    {
        public int Row { get; set; }
        public int SocialMediaPostID { get; set; }
        public long SocialPostID { get; set; }
        public int SocialMediaUserID_FK { get; set; }
        public bool Active { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime PostDate { get; set; }
        public string PosteDateIndex { get; set; }
        public string PosteDateTimeIndex { get; set; }
        public int RetweetCount { get; set; }
        public string Lang { get; set; }
        public string LinkUrl { get; set; }
        public long LinkUrlCRC { get; set; }
        public DateTime CreateDate { get; set; }

        public int NewsValue { get; set; }
        public static List<Class_SocialMediaPost> GetFromDataRows(DataRow[] Rows)
        {
            List<Class_SocialMediaPost> list = new List<Class_SocialMediaPost>();
            foreach (DataRow r in Rows)
            {
                Class_SocialMediaPost item = new Class_SocialMediaPost();
                try { item.Row = Convert.ToInt32(r["Row"]); } catch { item.Row = 0; }
                try { item.SocialMediaPostID = Convert.ToInt32(r["SocialMediaPostID"]); } catch { item.SocialMediaPostID = 0; }
                try { item.SocialPostID = Convert.ToInt64(r["SocialPostID"]); } catch { item.SocialPostID = 0; }
                try { item.SocialMediaUserID_FK = Convert.ToInt32(r["SocialMediaUserID_FK"]); } catch { item.SocialMediaUserID_FK = 0; }
                try { item.Active = Convert.ToBoolean(r["Active"]); } catch { item.Active = false; }
                try { item.Text = r["Text"].ToString(); } catch { item.Text = string.Empty; }
                try { item.UserName = r["UserName"].ToString(); } catch { item.UserName = string.Empty; }
                try { item.LikeCount = Convert.ToInt32(r["LikeCount"]); } catch { item.LikeCount = 0; }
                try { item.CommentCount = Convert.ToInt32(r["CommentCount"]); } catch { item.CommentCount = 0; }
                try { item.PostDate = Convert.ToDateTime(r["PostDate"]); } catch { item.PostDate = DateTime.Now; }
                try { item.PosteDateIndex = r["PosteDateIndex"].ToString(); } catch { item.PosteDateIndex = string.Empty; }
                try { item.PosteDateTimeIndex = r["PosteDateTimeIndex"].ToString(); } catch { item.PosteDateTimeIndex = string.Empty; }
                try { item.RetweetCount = Convert.ToInt32(r["RetweetCount"]); } catch { item.RetweetCount = 0; }
                try { item.Lang = r["Lang"].ToString(); } catch { item.Lang = string.Empty; }
                try { item.LinkUrl = r["LinkUrl"].ToString(); } catch { item.LinkUrl = string.Empty; }
                try { item.LinkUrlCRC = Convert.ToInt64(r["LinkUrlCRC"]); } catch { item.LinkUrlCRC = 0; }
                try { item.CreateDate = Convert.ToDateTime(r["CreateDate"]); } catch { item.CreateDate = DateTime.Now; }
                try { item.NewsValue = Convert.ToInt32(r["NewsValue"]); } catch { item.NewsValue = 0; }
                list.Add(item);
            }
            return list;
        }
        public List<Tbl_Twitter_Type> GetPosts(string postIds)
        {
            string cmd = "SELECT t.*,k.Title as Keyword FROM	dbo.Tbl_TwitterPost as t inner join dbo.Tbl_TwitterKeywords as k on k.ID = t.KeywordID WHERE t.ID IN  (" + postIds + ")";
            DataSet ds = Class_Ado.ExecuteDataset("", cmd, CommandType.Text);
           List<Tbl_Twitter_Type> CompiledPostsList = Tbl_Twitter_Type.GetFromDataRows(ds.Tables[0].Select());
            return CompiledPostsList;
        }
    }
}