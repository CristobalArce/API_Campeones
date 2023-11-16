using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API_Campeones.ContextBD
{
    public partial class CampeonesContext : DbContext
    {
        public CampeonesContext()
        {
        }

        public CampeonesContext(DbContextOptions<CampeonesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbcampeon> Tbcampeon { get; set; }
        public virtual DbSet<Tbdificultad> Tbdificultad { get; set; }
        public virtual DbSet<Tbrol> Tbrol { get; set; }
        public virtual DbSet<Tbusuario> Tbusuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbcampeon>(entity =>
            {
                entity.HasKey(e => e.IdCampeon);

                entity.ToTable("TBCampeon");

                entity.Property(e => e.IdCampeon).HasColumnName("idCampeon");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.IdDificultad).HasColumnName("idDificultad");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDificultadNavigation)
                    .WithMany(p => p.Tbcampeon)
                    .HasForeignKey(d => d.IdDificultad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBCampeon_TBDificultad");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Tbcampeon)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBCampeon_TBRol");
            });

            modelBuilder.Entity<Tbdificultad>(entity =>
            {
                entity.HasKey(e => e.IdDificultad);

                entity.ToTable("TBDificultad");

                entity.Property(e => e.IdDificultad).HasColumnName("idDificultad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbrol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("TBRol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbusuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
