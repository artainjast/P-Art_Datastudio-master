
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
    
public partial class Tbl_Comments
{

    public int CommentID { get; set; }

    public Nullable<int> AgenceID { get; set; }

    public System.DateTime DateTime { get; set; }

    public string Name { get; set; }

    public string Tel { get; set; }

    public string Mail { get; set; }

    public string IP { get; set; }

    public Nullable<bool> Show { get; set; }

    public string Comment { get; set; }



    public virtual Tbl_Agences Tbl_Agences { get; set; }

    public virtual Tbl_Comments Tbl_Comments1 { get; set; }

    public virtual Tbl_Comments Tbl_Comments2 { get; set; }

}

}
