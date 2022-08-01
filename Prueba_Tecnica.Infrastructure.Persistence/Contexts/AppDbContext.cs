using System;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Core.Domain.Entities;

#nullable disable

namespace Prueba_Tecnica.Infrastructure.Persistence.Contexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidato> Candidatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.ToTable("Candidato");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ExpectativaSalarial).HasColumnName("Expectativa_Salarial");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrabajoActual)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Trabajo_Actual");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
