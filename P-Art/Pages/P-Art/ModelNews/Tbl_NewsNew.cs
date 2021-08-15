//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P_Art.Pages.P_Art.ModelNews
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_NewsNew
    {
        public int NewsID { get; set; }
        public int SiteID { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public string NewsNumber { get; set; }
        public string NewsTitle { get; set; }
        public string NewsLead { get; set; }
        public string NewsBody { get; set; }
        public string NewsPicture { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<int> EditUser { get; set; }
        public Nullable<short> Rate { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string NewsLink { get; set; }
        public Nullable<int> NewsPosition { get; set; }
        public Nullable<long> NewsDateIndex { get; set; }
        public string NewsEnum { get; set; }
        public Nullable<bool> PicDownloaded { get; set; }
        public Nullable<bool> IsRelate { get; set; }
        public string RelateList { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public Nullable<bool> IsJarayed { get; set; }
        public Nullable<byte> NewsValue { get; set; }
        public Nullable<bool> IsRss { get; set; }
        public Nullable<bool> AllowTv { get; set; }
        public Nullable<int> KeywordId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<long> NewsLinkCRC { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public Nullable<int> WeekDayIndex { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public Nullable<int> MasterNewsTagID { get; set; }
        public Nullable<System.Guid> NewsGUID { get; set; }
        public Nullable<int> NewsType { get; set; }
        public Nullable<int> pageIndex { get; set; }
    }
}
