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
    
    public partial class Tbl_GoogleSEApiKeywords
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public string ExactTerms { get; set; }
        public string ExcludeTerms { get; set; }
        public int LastSearchTimeUnix { get; set; }
        public int PanelId { get; set; }
        public Nullable<int> KeysGroupID { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public Nullable<System.DateTime> EditDateTime { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
