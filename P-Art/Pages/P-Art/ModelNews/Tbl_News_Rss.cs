
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
    
public partial class Tbl_News_Rss
{

    public long NewsId { get; set; }

    public int SiteId { get; set; }

    public long NewsDateTimeIndex { get; set; }

    public string NewsDate { get; set; }

    public string NewsTime { get; set; }

    public string NewsTitle { get; set; }

    public string NewsLead { get; set; }

    public string NewsBody { get; set; }

    public string NewsPicture { get; set; }

    public Nullable<int> ViewCount { get; set; }

    public Nullable<long> NewsLinkCrc { get; set; }

    public Nullable<bool> IsSendToTelegram { get; set; }

    public Nullable<int> SiteType { get; set; }

    public string SourceLink { get; set; }

    public Nullable<int> NewsType { get; set; }

}

}
