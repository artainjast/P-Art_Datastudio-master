
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
    
public partial class Tbl_Nimta
{

    public int NimtaID { get; set; }

    public Nullable<int> SiteID_FK { get; set; }

    public Nullable<System.Guid> NimtaGUID { get; set; }

    public string NimtaDate { get; set; }

    public string PreviewPath { get; set; }

    public string LargePath { get; set; }

    public Nullable<int> CreateUser { get; set; }

    public Nullable<System.DateTime> CreateDate { get; set; }

    public string Title { get; set; }

    public Nullable<short> NimtaMode { get; set; }

    public string Url { get; set; }

    public string OriginalImage { get; set; }

}

}
