
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
    
public partial class Tbl_Telegram_MessageMedias
{

    public int Id { get; set; }

    public Nullable<int> Fk_Id_Tbl_Messages { get; set; }

    public Nullable<int> local_id { get; set; }

    public Nullable<long> secret { get; set; }

    public Nullable<long> volume_id { get; set; }

    public string MediaType { get; set; }

}

}
