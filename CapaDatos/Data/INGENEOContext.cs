using System;
using CapaDatos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CapaDatos
{
    public partial class INGENEOContext : DbContext
    {
        public INGENEOContext()
        {
        }

        public INGENEOContext(DbContextOptions<INGENEOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<PlanEntrega> PlanEntregas { get; set; }
        public virtual DbSet<PuntoEntrega> PuntoEntregas { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<TipoLogistica> TipoLogisticas { get; set; }
        public virtual DbSet<TipoProducto> TipoProductos { get; set; }
        public virtual DbSet<TipoPuntoEntrega> TipoPuntoEntregas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_TipoDocumento");
            });

            modelBuilder.Entity<PlanEntrega>(entity =>
            {
                entity.HasKey(e => e.IdPlanEntrega);

                entity.ToTable("PlanEntrega");

                entity.Property(e => e.FechaEntrega).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdentificacionTransporte)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.NumeroGuia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.PlanEntregas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanEntrega_Cliente");

                entity.HasOne(d => d.IdPuntoEntregaNavigation)
                    .WithMany(p => p.PlanEntregas)
                    .HasForeignKey(d => d.IdPuntoEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanEntrega_PuntoEntrega");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.PlanEntregas)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanEntrega_TipoProducto");
            });

            modelBuilder.Entity<PuntoEntrega>(entity =>
            {
                entity.HasKey(e => e.IdPuntoEntrega);

                entity.ToTable("PuntoEntrega");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdTipoPuntoEntregaNavigation)
                    .WithMany(p => p.PuntoEntregas)
                    .HasForeignKey(d => d.IdTipoPuntoEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoEntrega_TipoPuntoEntrega");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.ToTable("TipoDocumento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TipoLogistica>(entity =>
            {
                entity.HasKey(e => e.IdTipoLogistica);

                entity.ToTable("TipoLogistica");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto);

                entity.ToTable("TipoProducto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdTipoLogisticaNavigation)
                    .WithMany(p => p.TipoProductos)
                    .HasForeignKey(d => d.IdTipoLogistica)
                    .HasConstraintName("FK_TipoProducto_TipoLogistica");
            });

            modelBuilder.Entity<TipoPuntoEntrega>(entity =>
            {
                entity.HasKey(e => e.IdTipoPuntoEntrega);

                entity.ToTable("TipoPuntoEntrega");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdTipoLogisticaNavigation)
                    .WithMany(p => p.TipoPuntoEntregas)
                    .HasForeignKey(d => d.IdTipoLogistica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoPuntoEntrega_TipoLogistica");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
