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
    
    public partial class Tbl_TelegramSearchChannelPost
    {
        public int ChannelPostID { get; set; }
        public Nullable<int> TelegramChannelID { get; set; }
        public Nullable<int> Telegram_Id { get; set; }
        public Nullable<System.DateTime> Message_Date { get; set; }
        public string Message_DateTimeIndex { get; set; }
        public string Message_Text { get; set; }
        public Nullable<long> Text_CRC { get; set; }
    }
}