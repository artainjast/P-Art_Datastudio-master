
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
    
public partial class Tbl_KeywordEvents
{

    public int id { get; set; }

    public int KeyId { get; set; }

    public System.DateTime DDate { get; set; }

    public int NewsId { get; set; }

    public Nullable<int> CCount { get; set; }



    public virtual Tbl_Keywords Tbl_Keywords { get; set; }

}

}
