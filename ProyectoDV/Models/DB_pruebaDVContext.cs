using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoDV.Models
{
    public partial class DB_pruebaDVContext : DbContext
    {
        public DB_pruebaDVContext()
        {
        }

        public DB_pruebaDVContext(DbContextOptions<DB_pruebaDVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trace> Traces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trace>(entity =>
            {
                entity.ToTable("TRACE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dispositivo).HasMaxLength(100);

                entity.Property(e => e.FechaYhora)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaYHora");

                entity.Property(e => e.Identificador)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Latitud).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
