﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestaurentEntities : DbContext
    {
        public RestaurentEntities()
            : base("name=RestaurentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AmountRationInInvitation> AmountRationInInvitation { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<FoodCategory> FoodCategory { get; set; }
        public virtual DbSet<InvitationInTable> InvitationInTable { get; set; }
        public virtual DbSet<Invitations> Invitations { get; set; }
        public virtual DbSet<RateRations> RateRations { get; set; }
        public virtual DbSet<RationInInvitation> RationInInvitation { get; set; }
        public virtual DbSet<Rations> Rations { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
    }
}
