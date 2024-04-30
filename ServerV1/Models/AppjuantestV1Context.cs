using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServerV1.Models;

public partial class AppjuantestV1Context : DbContext
{
    public AppjuantestV1Context()
    {
    }

    public AppjuantestV1Context(DbContextOptions<AppjuantestV1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Agenda> Agenda { get; set; }

    public virtual DbSet<Apto> Aptos { get; set; }

    public virtual DbSet<CategoriaI> CategoriaIs { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }

    public virtual DbSet<DetallesVianda> DetallesVianda { get; set; }

    public virtual DbSet<Ingredientes> Ingredientes { get; set; }

    public virtual DbSet<Logros> Logros { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<Profesionales> Profesionales { get; set; }

    public virtual DbSet<Progresos> Progresos { get; set; }

    public virtual DbSet<Suscripciones> Suscripciones { get; set; }

    public virtual DbSet<Transacciones> Transacciones { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Vianda> Viandas { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("Admin_PK");

            entity.ToTable("Admin");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Admin_Usuarios_FK");
        });

        modelBuilder.Entity<Agenda>(entity =>
        {
            entity.HasKey(e => e.AgendaId).HasName("Agenda_PK");

            entity.HasIndex(e => e.ClienteUsuarioId, "Agenda__IDX").IsUnique();

            entity.Property(e => e.AgendaId)
                .ValueGeneratedNever()
                .HasColumnName("AgendaID");
            entity.Property(e => e.ClienteUsuarioId).HasColumnName("Cliente_UsuarioID");
            entity.Property(e => e.Comentarios).HasMaxLength(255);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.MeetUrl)
                .HasColumnType("text")
                .HasColumnName("MeetURL");
            entity.Property(e => e.ProfesionalesUsuarioId).HasColumnName("Profesionales_UsuarioID");

            entity.HasOne(d => d.ClienteUsuario).WithOne(p => p.oAgenda)
                .HasForeignKey<Agenda>(d => d.ClienteUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Agenda_Cliente_FK");

            entity.HasOne(d => d.ProfesionalesUsuario).WithMany(p => p.oAgenda)
                .HasForeignKey(d => d.ProfesionalesUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Agenda_Profesionales_FK");
        });

        modelBuilder.Entity<Apto>(entity =>
        {
            entity.HasKey(e => e.AptoId).HasName("Apto_PK");

            entity.ToTable("Apto");

            entity.HasIndex(e => e.IngredientesIngredienteId, "Apto__IDX").IsUnique();

            entity.Property(e => e.AptoId)
                .ValueGeneratedNever()
                .HasColumnName("AptoID");
            entity.Property(e => e.ImagenUrl)
                .HasColumnType("text")
                .HasColumnName("ImagenURL");
            entity.Property(e => e.IngredientesIngredienteId).HasColumnName("Ingredientes_IngredienteID");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.oIngrediente).WithOne(p => p.Apto)
                .HasForeignKey<Apto>(d => d.IngredientesIngredienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Apto_Ingredientes_FK");
        });

        modelBuilder.Entity<CategoriaI>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("CategoriaI_PK");

            entity.ToTable("CategoriaI");

            entity.Property(e => e.TipoId)
                .ValueGeneratedNever()
                .HasColumnName("TipoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("Cliente_PK");

            entity.ToTable("Cliente");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.CodigoPostal).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Objetivo).HasMaxLength(255);

            entity.HasOne(d => d.oUsuario).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cliente_Usuarios_FK");
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.DetallePedidoId).HasName("DetallesPedido_PK");

            entity.ToTable("DetallesPedido");

            entity.HasIndex(e => e.PedidosPedidoId, "DetallesPedido__IDX").IsUnique();

            entity.Property(e => e.DetallePedidoId)
                .ValueGeneratedNever()
                .HasColumnName("DetallePedidoID");
            entity.Property(e => e.PedidosPedidoId).HasColumnName("Pedidos_PedidoID");

            entity.HasOne(d => d.oPedido).WithOne(p => p.oDetallesPedido)
                .HasForeignKey<DetallesPedido>(d => d.PedidosPedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DetallesPedido_Pedidos_FK");
        });

        modelBuilder.Entity<DetallesVianda>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("DetallesVianda_PK");

            entity.Property(e => e.DetalleId)
                .ValueGeneratedNever()
                .HasColumnName("DetalleID");
            entity.Property(e => e.Unidad).HasMaxLength(50);
        });

        modelBuilder.Entity<Ingredientes>(entity =>
        {
            entity.HasKey(e => e.IngredienteId).HasName("Ingredientes_PK");

            entity.HasIndex(e => e.CategoriaITipoId, "Ingredientes__IDX").IsUnique();

            entity.Property(e => e.IngredienteId)
                .ValueGeneratedNever()
                .HasColumnName("IngredienteID");
            entity.Property(e => e.CategoriaITipoId).HasColumnName("CategoriaI_TipoID");
            entity.Property(e => e.DetallesViandaDetalleId).HasColumnName("DetallesVianda_DetalleID");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.oCategoriaI).WithOne(p => p.oIngrediente)
                .HasForeignKey<Ingredientes>(d => d.CategoriaITipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ingredientes_CategoriaI_FK");

            entity.HasOne(d => d.oDetallesVianda).WithMany(p => p.oIngredientes)
                .HasForeignKey(d => d.DetallesViandaDetalleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ingredientes_DetallesVianda_FK");
        });

        modelBuilder.Entity<Logros>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.ClienteUsuarioId, "Logros__IDX").IsUnique();

            entity.Property(e => e.ClienteUsuarioId).HasColumnName("Cliente_UsuarioID");

            entity.HasOne(d => d.oClienteUsuario).WithOne()
                .HasForeignKey<Logros>(d => d.ClienteUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Logros_Cliente_FK");
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("Pedidos_PK");

            entity.Property(e => e.PedidoId)
                .ValueGeneratedNever()
                .HasColumnName("PedidoID");
            entity.Property(e => e.EstadoPago).HasColumnName("EstadoPAGO");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");
            entity.Property(e => e.FranjaHoraria).HasMaxLength(100);
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.UsuariosUsuarioId).HasColumnName("Usuarios_UsuarioID");

            entity.HasOne(d => d.oUsuarios).WithMany(p => p.oPedidos)
                .HasForeignKey(d => d.UsuariosUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pedidos_Usuarios_FK");
        });

        modelBuilder.Entity<Profesionales>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("Profesionales_PK");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.Rol).HasMaxLength(255);

            entity.HasOne(d => d.Usuario).WithOne(p => p.Profesional)
                .HasForeignKey<Profesionales>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Profesionales_Usuarios_FK");
        });

        modelBuilder.Entity<Progresos>(entity =>
        {
            entity.HasKey(e => e.ProgresoId).HasName("Progresos_PK");

            entity.Property(e => e.ProgresoId)
                .ValueGeneratedNever()
                .HasColumnName("ProgresoID");
            entity.Property(e => e.ClienteUsuarioId).HasColumnName("Cliente_UsuarioID");
            entity.Property(e => e.Comentario).HasMaxLength(255);
            entity.Property(e => e.FechaProgreso).HasColumnType("datetime");

            entity.HasOne(d => d.ClienteUsuario).WithMany(p => p.oProgresos)
                .HasForeignKey(d => d.ClienteUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Progresos_Cliente_FK");
        });

        modelBuilder.Entity<Suscripciones>(entity =>
        {
            entity.HasKey(e => e.SuscripcionId).HasName("Suscripciones_PK");

            entity.HasIndex(e => e.ClienteUsuarioId, "Suscripciones__IDX").IsUnique();

            entity.Property(e => e.SuscripcionId)
                .ValueGeneratedNever()
                .HasColumnName("SuscripcionID");
            entity.Property(e => e.ClienteUsuarioId).HasColumnName("Cliente_UsuarioID");
            entity.Property(e => e.FechaIncripcion).HasColumnType("datetime");
            entity.Property(e => e.FechaRenovacion).HasColumnType("datetime");
            entity.Property(e => e.VConsumidas).HasColumnName("V_Consumidas");

            entity.HasOne(d => d.ClienteUsuario).WithOne(p => p.oSuscripciones)
                .HasForeignKey<Suscripciones>(d => d.ClienteUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Suscripciones_Cliente_FK");
        });

        modelBuilder.Entity<Transacciones>(entity =>
        {
            entity.HasKey(e => e.TransaccionId).HasName("Transacciones_PK");

            entity.HasIndex(e => e.PedidosPedidoId, "Transacciones__IDX").IsUnique();

            entity.Property(e => e.TransaccionId)
                .ValueGeneratedNever()
                .HasColumnName("TransaccionID");
            entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");
            entity.Property(e => e.PedidosPedidoId).HasColumnName("Pedidos_PedidoID");

            entity.HasOne(d => d.oPedido).WithOne(p => p.oTransacciones)
                .HasForeignKey<Transacciones>(d => d.PedidosPedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Transacciones_Pedidos_FK");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("Usuarios_PK");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Vianda>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("Viandas_PK");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("ProductoID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.DetallesPedidoDetallePedidoId).HasColumnName("DetallesPedido_DetallePedidoID");
            entity.Property(e => e.DetallesViandaDetalleId).HasColumnName("DetallesVianda_DetalleID");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.oDetallePedido).WithMany(p => p.oVianda)
                .HasForeignKey(d => d.DetallesPedidoDetallePedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Viandas_DetallesPedido_FK");

            entity.HasOne(d => d.oDetalleVianda).WithMany(p => p.oVianda)
                .HasForeignKey(d => d.DetallesViandaDetalleId)
                .HasConstraintName("Viandas_DetallesVianda_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
