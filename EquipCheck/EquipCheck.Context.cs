﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquipCheck
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EquipCheckEntities : DbContext
    {
        public EquipCheckEntities()
            : base("name=EquipCheckEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<app_users> app_users { get; set; }
        public DbSet<checklist> checklists { get; set; }
        public DbSet<equipment_items> equipment_items { get; set; }
        public DbSet<equipment_lists> equipment_lists { get; set; }
    }
}