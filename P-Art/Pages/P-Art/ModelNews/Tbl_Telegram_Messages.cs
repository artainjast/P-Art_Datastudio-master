
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
    
public partial class Tbl_Telegram_Messages
{

    public int Id { get; set; }

    public int FK_Id_Tbl_SearchKeyWord { get; set; }

    public Nullable<int> Message_Id { get; set; }

    public Nullable<int> Message_Date { get; set; }

    public Nullable<int> Message_Edit_Date { get; set; }

    public string Message_Text { get; set; }

    public Nullable<int> Message_SenderType { get; set; }

    public Nullable<int> Message_SenderID { get; set; }

    public string DateTimeInsert { get; set; }

    public Nullable<int> FK_ParminId { get; set; }

    public string MessageFile { get; set; }

    public string ChannelName { get; set; }

    public string FileType { get; set; }

    public Nullable<long> DateTimeIndex { get; set; }

    public Nullable<byte> IsSendToTelegram { get; set; }

}

}
