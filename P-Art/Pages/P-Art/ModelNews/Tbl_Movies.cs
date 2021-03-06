
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
    
public partial class Tbl_Movies
{

    public Tbl_Movies()
    {

        this.Tbl_Relation_MovieDistrict = new HashSet<Tbl_Relation_MovieDistrict>();

    }


    public int MovieID { get; set; }

    public Nullable<long> PackageID { get; set; }

    public Nullable<int> CompanyType { get; set; }

    public Nullable<int> MediaKitGroupID { get; set; }

    public Nullable<int> TizerPackCount { get; set; }

    public Nullable<bool> Active { get; set; }

    public string PosterPath { get; set; }

    public string VideoPath { get; set; }

    public string Title { get; set; }

    public Nullable<int> ViewCount { get; set; }

    public Nullable<int> Rate { get; set; }

    public int CreateUser { get; set; }

    public Nullable<System.DateTime> CreateDate { get; set; }

    public Nullable<int> EditUser { get; set; }

    public Nullable<System.DateTime> EditDate { get; set; }

    public string NetworkName { get; set; }

    public Nullable<int> NetworkGroupID { get; set; }

    public string ProgramName { get; set; }

    public string ProgramTime { get; set; }

    public string PlayTime { get; set; }

    public string VideoTime { get; set; }

    public string VideoDate { get; set; }

    public Nullable<bool> IsView { get; set; }

    public Nullable<bool> IsForeign { get; set; }

    public Nullable<int> CampainId { get; set; }

    public Nullable<int> Position { get; set; }

    public Nullable<int> weekdayindex { get; set; }

    public Nullable<int> Periority { get; set; }

    public Nullable<int> Type { get; set; }

    public Nullable<int> Percent { get; set; }

    public Nullable<int> Tabaghe { get; set; }

    public Nullable<long> DefaultPrice { get; set; }

    public Nullable<long> VideoPriceGroup { get; set; }

    public string VideoDateIndex { get; set; }

    public Nullable<bool> SendAllInOneTelegram { get; set; }



    public virtual ICollection<Tbl_Relation_MovieDistrict> Tbl_Relation_MovieDistrict { get; set; }

}

}
