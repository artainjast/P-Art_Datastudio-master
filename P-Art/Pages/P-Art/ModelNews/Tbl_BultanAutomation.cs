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
    
    public partial class Tbl_BultanAutomation
    {
        public int AutoID { get; set; }
        public int BultanFileID { get; set; }
        public string OrgName { get; set; }
        public string Districts { get; set; }
        public int NewsPercent { get; set; }
        public string SMSList { get; set; }
        public bool Active { get; set; }
        public string ExportPath { get; set; }
        public Nullable<int> Priority { get; set; }
        public string KeywordId { get; set; }
    
        public virtual Tbl_BultanFiles Tbl_BultanFiles { get; set; }
    }
}
