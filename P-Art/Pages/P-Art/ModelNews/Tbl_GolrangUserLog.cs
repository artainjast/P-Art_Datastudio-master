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
    
    public partial class Tbl_GolrangUserLog
    {
        public int GolrangLogID { get; set; }
        public Nullable<int> LogType { get; set; }
        public Nullable<int> GolrangUserID_FK { get; set; }
        public string LogDateTimeIndex { get; set; }
        public string Comment { get; set; }
        public string IP { get; set; }
    }
}
