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
    
    public partial class Tbl_TwitterAcount
    {
        public int ID { get; set; }
        public string Mail { get; set; }
        public string MailPassword { get; set; }
        public string CONSUMER_KEY { get; set; }
        public string CONSUMER_SECRET { get; set; }
        public string ACCESS_TOKEN { get; set; }
        public string ACCESS_TOKEN_SECRET { get; set; }
        public string TwitterUserID { get; set; }
        public bool Active { get; set; }
        public string TwitterPassword { get; set; }
        public int AcountType { get; set; }
        public Nullable<System.DateTime> LastUsedDateTime { get; set; }
    }
}
