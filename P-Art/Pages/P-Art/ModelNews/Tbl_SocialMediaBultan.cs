
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
    
public partial class Tbl_SocialMediaBultan
{

    public int SocialMediaBultanID { get; set; }

    public Nullable<int> ParminID_FK { get; set; }

    public string Title { get; set; }

    public string CreateDate { get; set; }

    public Nullable<int> CreateUser_FK { get; set; }

    public string LastPDFPath { get; set; }

    public string LastWordPath { get; set; }

    public string SelectedPosts { get; set; }

    public Nullable<int> SocialPostId_FK { get; set; }

    public Nullable<bool> AllowChart { get; set; }

    public Nullable<long> dateindex { get; set; }



    public virtual Tbl_SocialMediaBultan Tbl_SocialMediaBultan1 { get; set; }

    public virtual Tbl_SocialMediaBultan Tbl_SocialMediaBultan2 { get; set; }

}

}
