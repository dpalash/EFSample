//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkTestDBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class EncCell
    {
        public int Id { get; set; }
        public int Issuer3Id { get; set; }
        public string CellName { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsForSale { get; set; }
    
        public virtual issuer issuer { get; set; }
    }
}