//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P_Art.Pages.P_Art.ModelNewMeda
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_News
    {
        public long NewsId { get; set; }
        public string NewsTitle { get; set; }
        public long NewsCreateDateTimeIndex { get; set; }
        public long NewsDateTimeIndex { get; set; }
        public string NewsLead { get; set; }
        public string NewsBody { get; set; }
        public string NewsPicture { get; set; }
        public string NewsOrginalLink { get; set; }
        public long NewsLinkCrc { get; set; }
        public int SiteId { get; set; }
        public int GroupId { get; set; }
        public System.DateTime NewsCreateDateTime { get; set; }
        public Nullable<int> ViewCount { get; set; }
    
        public virtual Tbl_NewsGroups Tbl_NewsGroups { get; set; }
        public virtual Tbl_Sites Tbl_Sites { get; set; }
    }
}