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
    
    public partial class Tbl_SmsHistory
    {
        public int ID { get; set; }
        public Nullable<int> NewsID { get; set; }
        public Nullable<int> ParminID { get; set; }
        public Nullable<System.DateTime> SmsDate { get; set; }
        public string MobileNumber { get; set; }
        public string Comment { get; set; }
        public Nullable<long> SmsDeliveryCode { get; set; }
        public Nullable<bool> SmsStatus { get; set; }
        public string SMSText { get; set; }
    }
}
