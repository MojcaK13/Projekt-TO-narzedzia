﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiathlonEF.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BiathlonDBEntities : DbContext
    {
        public BiathlonDBEntities()
            : base("name=BiathlonDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TypStartu> TypStartu { get; set; }
        public virtual DbSet<Wyniki> Wyniki { get; set; }
        public virtual DbSet<Zawodnik> Zawodnik { get; set; }
    }
}
