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
    
    public partial class Tbl_UserJobLog
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public string DateIndex { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> LastEditedDate { get; set; }
        public bool Active { get; set; }
    }
}