
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
    
public partial class Tbl_Topics
{

    public Tbl_Topics()
    {

        this.Tbl_Attachments = new HashSet<Tbl_Attachments>();

    }


    public int TopicID { get; set; }

    public string TopicSubject { get; set; }

    public Nullable<int> CreateUser { get; set; }

    public Nullable<System.DateTime> CreateDate { get; set; }

    public Nullable<int> ViewCount { get; set; }

    public Nullable<bool> Active { get; set; }

    public Nullable<System.DateTime> ActiveTime { get; set; }

    public Nullable<int> ActiveUser { get; set; }

    public Nullable<short> Periority { get; set; }



    public virtual Tbl_AgenceMembers Tbl_AgenceMembers { get; set; }

    public virtual ICollection<Tbl_Attachments> Tbl_Attachments { get; set; }

}

}
