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
    
    public partial class Tbl_Gallery
    {
        public Tbl_Gallery()
        {
            this.Tbl_Relation_Gallery = new HashSet<Tbl_Relation_Gallery>();
        }
    
        public int imageId { get; set; }
        public string SmallPath { get; set; }
        public string LargePath { get; set; }
        public int CreateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Title { get; set; }
    
        public virtual Tbl_Gallery Tbl_Gallery1 { get; set; }
        public virtual Tbl_Gallery Tbl_Gallery2 { get; set; }
        public virtual ICollection<Tbl_Relation_Gallery> Tbl_Relation_Gallery { get; set; }
    }
}