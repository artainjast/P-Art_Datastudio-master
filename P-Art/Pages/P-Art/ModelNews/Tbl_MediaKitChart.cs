
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
    
public partial class Tbl_MediaKitChart
{

    public int Id { get; set; }

    public Nullable<bool> Active { get; set; }

    public int GroupId_fk { get; set; }

    public Nullable<int> ChartNumber { get; set; }

    public string ReportContains { get; set; }

    public string Title { get; set; }

    public string DateMode { get; set; }

    public string ChartsId { get; set; }

    public string ClickModeUrl { get; set; }

    public Nullable<int> OrderNumber { get; set; }

    public int ReportMediaType { get; set; }

    public bool GridSinglePage { get; set; }

    public bool NoteSinglePage { get; set; }

}

}
