using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using timetable.Models;

namespace timetable.Persistence
{
    public partial class TimeTableDbContext : DbContext
    {
        public TimeTableDbContext()
        {
        }

        public TimeTableDbContext(DbContextOptions<TimeTableDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deget> Deget { get; set; }
        public virtual DbSet<Disponibel> Disponibel { get; set; }
        public virtual DbSet<Ditet> Ditet { get; set; }
        public virtual DbSet<ImportLendet> ImportLendet { get; set; }
        public virtual DbSet<Klasat> Klasat { get; set; }
        public virtual DbSet<Lendet> Lendet { get; set; }
        public virtual DbSet<Orari> Orari { get; set; }
        public virtual DbSet<Oret> Oret { get; set; }
        public virtual DbSet<Tipet> Tipet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //             if (!optionsBuilder.IsConfigured)
            //             {
            // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                 optionsBuilder.UseSqlServer("Server=localhost; Database=ORARI_DEMO; password=MyComplexPassword123!; user id=sa;");
            //             }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deget>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Disponibel>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Ditet>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Dita).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ImportLendet>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Klasat>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Godina).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Klasa).IsUnicode(false);

                entity.Property(e => e.KlasaNew).IsUnicode(false);
            });

            modelBuilder.Entity<Lendet>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Orari>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Oret>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ora).IsUnicode(false);
            });

            modelBuilder.Entity<Tipet>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
