﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversityJournal.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UniversityEntities : DbContext
    {
        public UniversityEntities()
            : base("name=UniversityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<University_Group> University_Group { get; set; }
        public virtual DbSet<University_Schedule> University_Schedule { get; set; }
        public virtual DbSet<University_Student> University_Student { get; set; }
        public virtual DbSet<University_StudentPresence> University_StudentPresence { get; set; }
        public virtual DbSet<University_Subject> University_Subject { get; set; }
        public virtual DbSet<University_Teacher> University_Teacher { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<View_StudentPresence> View_StudentPresence { get; set; }
    }
}
