
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
    
public partial class Tbl_BilboardLog
{

    public int Id { get; set; }

    public Nullable<int> BilboardId_fk { get; set; }

    public Nullable<int> BilboardParminId { get; set; }

    public string BilboardParminName { get; set; }

    public Nullable<System.DateTime> BilboardDateInsert { get; set; }

    public string BilboardDateIndex { get; set; }

    public byte[] BilboardImage { get; set; }

    public string BilboardImageUrl { get; set; }

    public string UserMobile { get; set; }

    public Nullable<double> MapLat { get; set; }

    public Nullable<double> MapLongLat { get; set; }

    public Nullable<System.DateTime> DateInsert { get; set; }

    public Nullable<long> Price { get; set; }

    public Nullable<bool> Active { get; set; }

    public bool IsVisible { get; set; }

    public string Title { get; set; }

    public Nullable<int> CreateUser { get; set; }

    public Nullable<int> CampainId { get; set; }

}

}
