﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodForLife.Data.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FeedforlifeEntities : DbContext
    {
        public FeedforlifeEntities()
            : base("name=FeedforlifeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<mtblPartyType> mtblPartyTypes { get; set; }
        public virtual DbSet<mtblRole> mtblRoles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblDonorRequest> tblDonorRequests { get; set; }
        public virtual DbSet<tblDonorRequestStatu> tblDonorRequestStatus { get; set; }
        public virtual DbSet<tblDonorRequestVendor> tblDonorRequestVendors { get; set; }
        public virtual DbSet<tbluser> tblusers { get; set; }
        public virtual DbSet<tblusersRole> tblusersRoles { get; set; }
        public virtual DbSet<tblVendor> tblVendors { get; set; }
    }
}
