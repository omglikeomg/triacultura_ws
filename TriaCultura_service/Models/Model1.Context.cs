﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TriaCultura_service.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class triaculturaCTXEntities : DbContext
    {
        public triaculturaCTXEntities()
            : base("name=triaculturaCTXEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<capacity> capacities { get; set; }
        public virtual DbSet<file> files { get; set; }
        public virtual DbSet<place> places { get; set; }
        public virtual DbSet<place_has_capacity> place_has_capacity { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<rating> ratings { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<vote> votes { get; set; }
    }
}
