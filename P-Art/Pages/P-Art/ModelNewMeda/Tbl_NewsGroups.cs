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
    
    public partial class Tbl_NewsGroups
    {
        public Tbl_NewsGroups()
        {
            this.Tbl_News = new HashSet<Tbl_News>();
        }
    
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
    
        public virtual ICollection<Tbl_News> Tbl_News { get; set; }
    }
}
