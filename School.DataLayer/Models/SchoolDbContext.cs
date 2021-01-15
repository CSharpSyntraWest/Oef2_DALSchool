using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.DataLayer.Models
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext() { }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            :base(options)
        { 
        
        }
        public virtual DbSet<DbVak> DbVakken { get; set; }
        public virtual DbSet<DbSchool> DbScholen { get; set; }
        public virtual DbSet<DbPersoon> DbPersonen { get; set; }
        public virtual DbSet<DbStudent> DbStudenten { get; set; }
        public virtual DbSet<DbDocent> DbDocenten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ScholenDb;Integrated Security=True;Pooling=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbSchool>(entity =>
            {
                entity.HasKey(e => e.SchoolId).HasName("PK_School");
                entity.ToTable("School");
                entity.Property(e => e.Naam).HasMaxLength(100).IsUnicode(false);
                entity.HasMany(e => e.Studenten);
                entity.HasMany(e => e.Docenten);
            });
            modelBuilder.Entity<DbPersoon>(entity => {
                entity.HasKey(e => e.PersoonId).HasName("PK_Persoon");
                entity.ToTable("Persoon");
            });
            modelBuilder.Entity<DbVak>(entity =>
            {
                entity.HasKey(e => e.VakId).HasName("PK_Vak");
                entity.HasMany(e => e.Studenten);
            });
        }
    }
}
