
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
    
public partial class Tbl_SocialMediaPost
{

    public int SocialMediaPostID { get; set; }

    public Nullable<long> SocialPostID { get; set; }

    public Nullable<int> SocialMediaKeyID_FK { get; set; }

    public Nullable<int> SocialMediaUserID_FK { get; set; }

    public Nullable<bool> Active { get; set; }

    public string Text { get; set; }

    public string UserName { get; set; }

    public Nullable<int> LikeCount { get; set; }

    public Nullable<int> CommentCount { get; set; }

    public Nullable<System.DateTime> PostDate { get; set; }

    public string PosteDateIndex { get; set; }

    public string PosteDateTimeIndex { get; set; }

    public Nullable<int> RetweetCount { get; set; }

    public string Lang { get; set; }

    public string LinkUrl { get; set; }

    public Nullable<long> LinkUrlCRC { get; set; }

    public Nullable<System.DateTime> CreateDate { get; set; }

    public Nullable<byte> NewsValue { get; set; }

    public Nullable<bool> SendAllInOneTelegram { get; set; }

}

}
