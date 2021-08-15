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
    
    public partial class Tbl_AgenceMembers
    {
        public Tbl_AgenceMembers()
        {
            this.Tbl_Log_Login = new HashSet<Tbl_Log_Login>();
            this.Tbl_Rate = new HashSet<Tbl_Rate>();
            this.Tbl_Topics = new HashSet<Tbl_Topics>();
            this.Tbl_TopicUsers = new HashSet<Tbl_TopicUsers>();
        }
    
        public int MemberID { get; set; }
        public Nullable<int> AgenceID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string keywords { get; set; }
        public string MailAddress { get; set; }
        public Nullable<System.DateTime> SignupDate { get; set; }
        public Nullable<bool> Active { get; set; }
        public string DistrictMovie { get; set; }
        public string DistrictSound { get; set; }
        public string DistrictJarayed { get; set; }
        public string SiteJarayed { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public string UserGroup { get; set; }
        public string UserIcon { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<bool> Status { get; set; }
        public string ChildUser { get; set; }
        public string Mobile { get; set; }
        public string LastSessionID { get; set; }
        public string ParminIds { get; set; }
        public string GalleryIds { get; set; }
        public string Description { get; set; }
        public Nullable<bool> AllowSaveNews { get; set; }
        public string SavedNewsIds { get; set; }
        public string ResourceSortingOrder { get; set; }
        public string SavedOrderIds { get; set; }
        public string DeviceId { get; set; }
    
        public virtual Tbl_Agences Tbl_Agences { get; set; }
        public virtual ICollection<Tbl_Log_Login> Tbl_Log_Login { get; set; }
        public virtual ICollection<Tbl_Rate> Tbl_Rate { get; set; }
        public virtual ICollection<Tbl_Topics> Tbl_Topics { get; set; }
        public virtual ICollection<Tbl_TopicUsers> Tbl_TopicUsers { get; set; }
    }
}