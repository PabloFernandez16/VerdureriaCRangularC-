using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_Verdureria.Modelos
{
    public partial class DbVerdurasContext : DbContext
    {
        public DbVerdurasContext()
        {
        }

        public DbVerdurasContext(DbContextOptions<DbVerdurasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOPMP\\SQLEXPRESS;Database=DbVerduras;Trusted_Connection=True; trustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("Compra");

                entity.HasIndex(e => e.ClienteId, "IX_Compra_ClienteId");

                entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.ClienteId);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.HasIndex(e => e.CompraId, "IX_Producto_CompraId");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CompraId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
