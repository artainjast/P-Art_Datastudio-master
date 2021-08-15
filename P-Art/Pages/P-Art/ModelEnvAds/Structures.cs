//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P_Art.Pages.P_Art.ModelEnvAds
{
    using System;
    using System.Collections.Generic;
    
    public partial class Structures
    {
        public Structures()
        {
            this.Advertises = new HashSet<Advertises>();
        }
    
        public int StructureId { get; set; }
        public Nullable<int> StructureTypeId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> AddressTypeId { get; set; }
        public string Address { get; set; }
        public Nullable<int> Area { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual AddressTypes AddressTypes { get; set; }
        public virtual ICollection<Advertises> Advertises { get; set; }
        public virtual Cities Cities { get; set; }
        public virtual StructureTypes StructureTypes { get; set; }
    }
}
