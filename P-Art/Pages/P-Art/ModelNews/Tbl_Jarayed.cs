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
    
    public partial class Tbl_Jarayed
    {
        public int JarayedId { get; set; }
        public Nullable<int> SiteId { get; set; }
        public string Title { get; set; }
        public Nullable<int> PagePosition { get; set; }
        public Nullable<int> CampainId { get; set; }
        public string OrginalImagePath { get; set; }
        public string ThumbnailImagePath { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<long> DateTimeIndex { get; set; }
        public Nullable<int> PanelId { get; set; }
        public Nullable<int> ColorMode { get; set; }
        public string Size { get; set; }
        public Nullable<int> periority { get; set; }
        public Nullable<int> nimta { get; set; }
        public Nullable<int> position { get; set; }
        public Nullable<long> Price { get; set; }
    
        public virtual Tbl_Sites Tbl_Sites { get; set; }
    }
}
