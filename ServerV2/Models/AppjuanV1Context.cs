using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServerV2.Models;

public partial class AppjuanV1Context : DbContext
{
    public AppjuanV1Context()
    {
    }

    public AppjuanV1Context(DbContextOptions<AppjuanV1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Agenda> Agenda { get; set; }

    public virtual DbSet<Apto> Aptos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }

    public virtual DbSet<DetallesVianda> DetallesVianda { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Logro> Logros { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Profesional> Profesionals { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<Suscripcion> Suscripcions { get; set; }

    public virtual DbSet<Transaccion> Transaccions { get; set; }

    public virtual DbSet<Vianda> Vianda { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("Admin_PK");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Agenda>(entity =>
        {
            entity.HasKey(e => e.AgendaId).HasName("Agenda_PK");

            entity.HasIndex(e => e.ClienteId, "Agenda__IDX").IsUnique();

            entity.Property(e => e.AgendaId)
                .ValueGeneratedNever()
                .HasColumnName("AgendaID");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ClienteID");
            entity.Property(e => e.Comentarios).HasMaxLength(255);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.MeetUrl)
                .HasColumnType("text")
                .HasColumnName("MeetURL");
            entity.Property(e => e.ProfesionalId).HasColumnName("Profesional_ProfesionalID");

            entity.HasOne(d => d.oCliente).WithOne(p => p.oAgenda)
                .HasForeignKey<Agenda>(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Agenda_Cliente_FK");

            entity.HasOne(d => d.oProfesional).WithMany(p => p.oAgenda)
                .HasForeignKey(d => d.ProfesionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Agenda_Profesional_FK");
        });

        modelBuilder.Entity<Apto>(entity =>
        {
            entity.HasKey(e => e.AptoId).HasName("Apto_PK");

            entity.ToTable("Apto");

            entity.HasIndex(e => e.IngredienteId, "Apto__IDX").IsUnique();

            entity.Property(e => e.AptoId)
                .ValueGeneratedNever()
                .HasColumnName("AptoID");
            entity.Property(e => e.ImagenUrl)
                .HasColumnType("text")
                .HasColumnName("ImagenURL");
            entity.Property(e => e.IngredienteId).HasColumnName("Ingrediente_IngredienteID");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.oIngrediente).WithOne(p => p.oApto)
                .HasForeignKey<Apto>(d => d.IngredienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Apto_Ingrediente_FK");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("Cliente_PK");

            entity.ToTable("Cliente");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("ClienteID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.CodigoPostal).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Objetivo).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.DetallePedidoId).HasName("DetallesPedido_PK");

            entity.ToTable("DetallesPedido");

            entity.HasIndex(e => e.PedidoId, "DetallesPedido__IDX").IsUnique();

            entity.Property(e => e.DetallePedidoId)
                .ValueGeneratedNever()
                .HasColumnName("DetallePedidoID");
            entity.Property(e => e.PedidoId).HasColumnName("Pedido_PedidoID");

            entity.HasOne(d => d.oPedido).WithOne(p => p.oDetallesPedido)
                .HasForeignKey<DetallesPedido>(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DetallesPedido_Pedido_FK");
        });

        modelBuilder.Entity<DetallesVianda>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("DetallesVianda_PK");

            entity.Property(e => e.DetalleId)
                .ValueGeneratedNever()
                .HasColumnName("DetalleID");
            entity.Property(e => e.Unidad).HasMaxLength(50);
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IngredienteId).HasName("Ingrediente_PK");

            entity.ToTable("Ingrediente");

            entity.Property(e => e.IngredienteId)
                .ValueGeneratedNever()
                .HasColumnName("IngredienteID");
            entity.Property(e => e.Categoria).HasMaxLength(100);
            entity.Property(e => e.ViandaDetalleId).HasColumnName("DetallesVianda_DetalleID");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.oDetalleVianda).WithMany(p => p.oIngredientes)
                .HasForeignKey(d => d.ViandaDetalleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ingrediente_DetallesVianda_FK");
        });

        modelBuilder.Entity<Logro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Logro");

            entity.HasIndex(e => e.ClienteId, "Logro__IDX").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ClienteID");

            entity.HasOne(d => d.oCliente).WithOne()
                .HasForeignKey<Logro>(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Logro_Cliente_FK");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("Pedido_PK");

            entity.ToTable("Pedido");

            entity.Property(e => e.PedidoId)
                .ValueGeneratedNever()
                .HasColumnName("PedidoID");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ClienteID");
            entity.Property(e => e.EstadoPago).HasColumnName("EstadoPAGO");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");
            entity.Property(e => e.FranjaHoraria).HasMaxLength(100);
            entity.Property(e => e.MetodoPago).HasMaxLength(50);

            entity.HasOne(d => d.oCliente).WithMany(p => p.oPedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pedido_Cliente_FK");
        });

        modelBuilder.Entity<Profesional>(entity =>
        {
            entity.HasKey(e => e.ProfesionalId).HasName("Profesional_PK");

            entity.ToTable("Profesional");

            entity.Property(e => e.ProfesionalId)
                .ValueGeneratedNever()
                .HasColumnName("ProfesionalID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(255);
        });

        modelBuilder.Entity<Progreso>(entity =>
        {
            entity.HasKey(e => e.ProgresoId).HasName("Progresos_PK");

            entity.Property(e => e.ProgresoId)
                .ValueGeneratedNever()
                .HasColumnName("ProgresoID");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ClienteID");
            entity.Property(e => e.Comentario).HasMaxLength(255);
            entity.Property(e => e.FechaProgreso).HasColumnType("datetime");

            entity.HasOne(d => d.oCliente).WithMany(p => p.oProgresos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Progresos_Cliente_FK");
        });

        modelBuilder.Entity<Suscripcion>(entity =>
        {
            entity.HasKey(e => e.SuscripcionId).HasName("Suscripcion_PK");

            entity.ToTable("Suscripcion");

            entity.HasIndex(e => e.ClienteId, "Suscripcion__IDX").IsUnique();

            entity.Property(e => e.SuscripcionId)
                .ValueGeneratedNever()
                .HasColumnName("SuscripcionID");
            entity.Property(e => e.ClienteId).HasColumnName("Cliente_ClienteID");
            entity.Property(e => e.FechaIncripcion).HasColumnType("datetime");
            entity.Property(e => e.FechaRenovacion).HasColumnType("datetime");
            entity.Property(e => e.VConsumidas).HasColumnName("V_Consumidas");

            entity.HasOne(d => d.oCliente).WithOne(p => p.oSuscripcion)
                .HasForeignKey<Suscripcion>(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Suscripcion_Cliente_FK");
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => e.TransaccionId).HasName("Transaccion_PK");

            entity.ToTable("Transaccion");

            entity.HasIndex(e => e.PedidoId, "Transaccion__IDX").IsUnique();

            entity.Property(e => e.TransaccionId)
                .ValueGeneratedNever()
                .HasColumnName("TransaccionID");
            entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");
            entity.Property(e => e.PedidoId).HasColumnName("Pedido_PedidoID");

            entity.HasOne(d => d.oPedido).WithOne(p => p.oTransaccion)
                .HasForeignKey<Transaccion>(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Transaccion_Pedido_FK");
        });

        modelBuilder.Entity<Vianda>(entity =>
        {
            entity.HasKey(e => e.ViandaId).HasName("Vianda_PK");

            entity.Property(e => e.ViandaId)
                .ValueGeneratedNever()
                .HasColumnName("ViandaID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.DetallePedidoId).HasColumnName("DetallesPedido_DetallePedidoID");
            entity.Property(e => e.DetallesViandaId).HasColumnName("DetallesVianda_DetalleID");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.oDetallePedido).WithMany(p => p.oVianda)
                .HasForeignKey(d => d.DetallePedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vianda_DetallesPedido_FK");

            entity.HasOne(d => d.oDetallesVianda).WithMany(p => p.oVianda)
                .HasForeignKey(d => d.DetallesViandaId)
                .HasConstraintName("Vianda_DetallesVianda_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
