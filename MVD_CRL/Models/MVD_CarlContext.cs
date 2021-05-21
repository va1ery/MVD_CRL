using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVD_CRL.Models
{
    public partial class MVD_CarlContext : DbContext
    {
        public MVD_CarlContext()
        {
        }

        public MVD_CarlContext(DbContextOptions<MVD_CarlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ВидыПреступлений> ВидыПреступлений { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Звания> Звания { get; set; }
        public virtual DbSet<Пострадавшие> Пострадавшие { get; set; }
        public virtual DbSet<Преступники> Преступники { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MVD_Carl;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ВидыПреступлений>(entity =>
            {
                entity.HasKey(e => e.КодВидаПреступления)
                    .HasName("PK__Виды_пре__C2E8B24414EB3E63");

                entity.Property(e => e.КодВидаПреступления).ValueGeneratedNever();
            });

            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.КодДолжности)
                    .HasName("PK__Должност__6F49B82E1D6C000B");

                entity.Property(e => e.КодДолжности).ValueGeneratedNever();
            });

            modelBuilder.Entity<Звания>(entity =>
            {
                entity.HasKey(e => e.КодЗвания)
                    .HasName("PK__Звания__590635FC51286356");

                entity.Property(e => e.КодЗвания).ValueGeneratedNever();
            });

            modelBuilder.Entity<Пострадавшие>(entity =>
            {
                entity.HasKey(e => e.КодПострадавшего)
                    .HasName("PK__Пострада__797BA8E29F4973AF");

                entity.Property(e => e.КодПострадавшего).ValueGeneratedNever();
            });

            modelBuilder.Entity<Преступники>(entity =>
            {
                entity.HasKey(e => e.НомерДела)
                    .HasName("PK__Преступн__A3C5D89E181AAD63");

                entity.Property(e => e.НомерДела).ValueGeneratedNever();

                entity.HasOne(d => d.КодВидаПреступленияNavigation)
                    .WithMany(p => p.Преступники)
                    .HasForeignKey(d => d.КодВидаПреступления)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Преступни__Код_в__1DE57479");

                entity.HasOne(d => d.КодПострадавшегоNavigation)
                    .WithMany(p => p.Преступники)
                    .HasForeignKey(d => d.КодПострадавшего)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Преступни__Код_п__1CF15040");

                entity.HasOne(d => d.КодСотрудникаNavigation)
                    .WithMany(p => p.Преступники)
                    .HasForeignKey(d => d.КодСотрудника)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Преступни__Код_с__1BFD2C07");
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.КодСотрудника)
                    .HasName("PK__Сотрудни__409003AE3329DB43");

                entity.Property(e => e.КодСотрудника).ValueGeneratedNever();

                entity.HasOne(d => d.КодДолжностиNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодДолжности)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Сотрудник__Код_д__182C9B23");

                entity.HasOne(d => d.КодЗванияNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодЗвания)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Сотрудник__Код_з__1920BF5C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
