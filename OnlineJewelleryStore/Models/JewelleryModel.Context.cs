﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JewelleryDBEntities : DbContext
    {
        public JewelleryDBEntities()
            : base("name=JewelleryDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Category> Tbl_Category { get; set; }
        public virtual DbSet<Tbl_Member> Tbl_Member { get; set; }
        public virtual DbSet<Tbl_Order> Tbl_Order { get; set; }
        public virtual DbSet<Tbl_OrderDetails> Tbl_OrderDetails { get; set; }
        public virtual DbSet<Tbl_Role> Tbl_Role { get; set; }
        public virtual DbSet<Tbl_Product> Tbl_Product { get; set; }
        public object SqlQuery { get; internal set; }
    }
}
