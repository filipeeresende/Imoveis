using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Imoveis_Infraestrutura.Entities
{
    public partial class LOCADORA_IMOVEISContext : DbContext
    {
        public LOCADORA_IMOVEISContext()
        {
        }

        public LOCADORA_IMOVEISContext(DbContextOptions<LOCADORA_IMOVEISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Imoveis> Imoveis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Imoveis>(entity =>
            {
                entity.ToTable("imoveis");

                entity.Property(e => e.Endereco).HasMaxLength(30);

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.Property(e => e.TipoContrato)
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_Contrato");

                entity.Property(e => e.Valor).HasPrecision(15, 2);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
