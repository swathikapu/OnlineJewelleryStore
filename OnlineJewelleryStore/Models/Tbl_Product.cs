//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineJewelleryStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Tbl_Category Tbl_Category { get; set; }
    }
}
