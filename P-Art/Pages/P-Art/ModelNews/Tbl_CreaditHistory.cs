
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
    
public partial class Tbl_CreaditHistory
{

    public int CreaditID { get; set; }

    public int AgenceID { get; set; }

    public string FishDate { get; set; }

    public string FishNumber { get; set; }

    public string FishBank { get; set; }

    public string FishShobe { get; set; }

    public Nullable<int> FishPrice { get; set; }

    public Nullable<System.DateTime> CreateDate { get; set; }

    public Nullable<bool> IsOK { get; set; }

    public Nullable<int> OkUser { get; set; }

    public Nullable<System.DateTime> OKDate { get; set; }



    public virtual Tbl_Agences Tbl_Agences { get; set; }

}

}
