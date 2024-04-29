using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationTest.Models;

public partial class TestBusContext : DbContext
{
    public TestBusContext()
    {
    }

    public TestBusContext(DbContextOptions<TestBusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsiganacionViaje> AsiganacionViajes { get; set; }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Organizacion> Organizacions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Rutum> Ruta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        // => optionsBuilder.UseSqlServer("Server=(local); DataBase=TestBus;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsiganacionViaje>(entity =>
        {
            entity.HasKey(e => new { e.IdAsiganacion, e.IdRuta, e.IdEmpleado, e.IdBus, e.IdHorario });

            entity.ToTable("Asiganacion_viaje");

            entity.HasIndex(e => e.UsuarioId, "IX_Relationship21");

            entity.Property(e => e.IdAsiganacion).HasColumnName("Id_Asiganacion");
            entity.Property(e => e.IdRuta).HasColumnName("Id_ruta");
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");
            entity.Property(e => e.IdBus).HasColumnName("Id_Bus");
            entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");
            entity.Property(e => e.AsientosDisponibles).HasColumnName("Asientos_disponibles");
            entity.Property(e => e.AsientosOcupados).HasColumnName("Asientos_ocupados");
            entity.Property(e => e.DescripcionRuta)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("Descripcion_ruta");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.AsiganacionViajes)
                .HasForeignKey(d => d.IdBus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Relationship11");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.AsiganacionViajes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Relationship9");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.AsiganacionViajes)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Relationship12");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.AsiganacionViajes)
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Relationship10");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AsiganacionViajes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("Relationship21");
        });

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.IdBus);

            entity.ToTable("Bus");

            entity.Property(e => e.IdBus).HasColumnName("Id_Bus");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => new { e.IdDepartamento, e.IdOrganizacion });

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).HasColumnName("Id_Departamento");
            entity.Property(e => e.IdOrganizacion).HasColumnName("Id_Organizacion");
            entity.Property(e => e.NombreDepto)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("Nombre_Depto");

            entity.HasOne(d => d.IdOrganizacionNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdOrganizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Relationship16");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("Empleado");

            entity.HasIndex(e => new { e.IdDepartamento, e.IdOrganizacion }, "IX_Relationship6");

            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("Id_Empleado");
            entity.Property(e => e.IdDepartamento).HasColumnName("Id_Departamento");
            entity.Property(e => e.IdOrganizacion).HasColumnName("Id_Organizacion");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("Nombre_Empleado");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Empleados)
                .HasForeignKey(d => new { d.IdDepartamento, d.IdOrganizacion })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Relationship6");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario);

            entity.ToTable("Horario");

            entity.Property(e => e.IdHorario)
                .ValueGeneratedNever()
                .HasColumnName("Id_Horario");
            entity.Property(e => e.FinHorario).HasColumnName("Fin_Horario");
            entity.Property(e => e.InicioHorario).HasColumnName("Inicio_Horario");
        });

        modelBuilder.Entity<Organizacion>(entity =>
        {
            entity.HasKey(e => e.IdOrganizacion);

            entity.ToTable("Organizacion");

            entity.Property(e => e.IdOrganizacion)
                .ValueGeneratedNever()
                .HasColumnName("Id_Organizacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("Id_Rol");
            entity.Property(e => e.DescripcionRol)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("Descripcion_rol");
        });

        modelBuilder.Entity<Rutum>(entity =>
        {
            entity.HasKey(e => e.IdRuta);

            entity.Property(e => e.IdRuta)
                .ValueGeneratedNever()
                .HasColumnName("Id_ruta");
            entity.Property(e => e.Destino)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Origen)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.HasIndex(e => e.IdRol, "IX_Relationship20");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("Relationship20");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
