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
    
    public partial class Tbl_BultanFiles
    {
        public Tbl_BultanFiles()
        {
            this.Tbl_BultanAutomation = new HashSet<Tbl_BultanAutomation>();
        }
    
        public int BultanID { get; set; }
        public Nullable<System.Guid> BultanGUID { get; set; }
        public string BultanPreview { get; set; }
        public string BultanPath { get; set; }
        public string BultanJeldPath { get; set; }
        public string Title { get; set; }
        public Nullable<int> pageIndexNimta { get; set; }
        public Nullable<int> pageIndexKeys { get; set; }
        public Nullable<int> pageIndexChart1 { get; set; }
        public Nullable<int> pageIndexChart2 { get; set; }
        public Nullable<int> pageIndexChart3 { get; set; }
        public Nullable<int> pageIndexTV { get; set; }
        public Nullable<int> pageIndexJarayed { get; set; }
        public Nullable<int> pageIndexKhabarGozari { get; set; }
        public Nullable<int> pageIndexPeople { get; set; }
        public Nullable<int> pageIndexList { get; set; }
        public Nullable<int> MaxCharecterPerPage { get; set; }
    
        public virtual ICollection<Tbl_BultanAutomation> Tbl_BultanAutomation { get; set; }
    }
}
