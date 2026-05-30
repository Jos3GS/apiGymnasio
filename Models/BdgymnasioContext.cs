using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace apiGymnasio.Models;

public partial class BdgymnasioContext : DbContext
{
    public BdgymnasioContext()
    {
    }

    public BdgymnasioContext(DbContextOptions<BdgymnasioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCargo> TblCargos { get; set; }

    public virtual DbSet<TblCiudad> TblCiudads { get; set; }

    public virtual DbSet<TblClase> TblClases { get; set; }

    public virtual DbSet<TblDetalleMatricula> TblDetalleMatriculas { get; set; }

    public virtual DbSet<TblDireccionEmpleado> TblDireccionEmpleados { get; set; }

    public virtual DbSet<TblDireccionSocio> TblDireccionSocios { get; set; }

    public virtual DbSet<TblEmpleado> TblEmpleados { get; set; }

    public virtual DbSet<TblEspecialidad> TblEspecialidads { get; set; }

    public virtual DbSet<TblEstado> TblEstados { get; set; }

    public virtual DbSet<TblEstadoConservacion> TblEstadoConservacions { get; set; }

    public virtual DbSet<TblFormaPago> TblFormaPagos { get; set; }

    public virtual DbSet<TblMarca> TblMarcas { get; set; }

    public virtual DbSet<TblMatricula> TblMatriculas { get; set; }

    public virtual DbSet<TblMembresium> TblMembresia { get; set; }

    public virtual DbSet<TblMonitor> TblMonitors { get; set; }

    public virtual DbSet<TblProfesion> TblProfesions { get; set; }

    public virtual DbSet<TblRecurso> TblRecursos { get; set; }

    public virtual DbSet<TblSala> TblSalas { get; set; }

    public virtual DbSet<TblSocio> TblSocios { get; set; }

    public virtual DbSet<TblTamano> TblTamanos { get; set; }

    public virtual DbSet<TblTelEmpleadoEmpleado> TblTelEmpleadoEmpleados { get; set; }

    public virtual DbSet<TblTelSocioSocio> TblTelSocioSocios { get; set; }

    public virtual DbSet<TblTelefonoEmpleado> TblTelefonoEmpleados { get; set; }

    public virtual DbSet<TblTelefonoSocio> TblTelefonoSocios { get; set; }

    public virtual DbSet<TblTipoDocumento> TblTipoDocumentos { get; set; }

    public virtual DbSet<TblTipoSala> TblTipoSalas { get; set; }

    public virtual DbSet<TblTipoTelefono> TblTipoTelefonos { get; set; }

    public virtual DbSet<TblTurno> TblTurnos { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BDGymnasio; Trusted_Connection=SSPI; MultipleActiveResultSets=true; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCargo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblCargo__40F9A2079C56BBBA");

            entity.ToTable("tblCargo");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblCiudad>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblCiuda__40F9A207D504D2B8");

            entity.ToTable("tblCiudad");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblClase>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblClase__40F9A2075932E14A");

            entity.ToTable("tblClase");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FkEspecialidad).HasColumnName("FK_especialidad");
            entity.Property(e => e.FkMonitor).HasColumnName("FK_monitor");
            entity.Property(e => e.FkSala).HasColumnName("FK_sala");
            entity.Property(e => e.Horario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("horario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UsuarioCrea).HasColumnName("usuarioCrea");

            
        });

        modelBuilder.Entity<TblDetalleMatricula>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblDetal__40F9A20700D60C3A");

            entity.ToTable("tblDetalleMatricula");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FechaMatricula).HasColumnName("fechaMatricula");
            entity.Property(e => e.FkClase).HasColumnName("FK_clase");
            entity.Property(e => e.FkMatricula).HasColumnName("FK_matricula");

            
        });

        modelBuilder.Entity<TblDireccionEmpleado>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblDirec__40F9A20728D0244E");

            entity.ToTable("tblDireccionEmpleado");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FkCiudad).HasColumnName("FK_ciudad");
            entity.Property(e => e.FkEmpleado).HasColumnName("FK_empleado");

           
        });

        modelBuilder.Entity<TblDireccionSocio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblDirec__40F9A2079C9E736B");

            entity.ToTable("tblDireccionSocio");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FkCiudad).HasColumnName("FK_ciudad");
            entity.Property(e => e.FkSocio).HasColumnName("FK_socio");

            
        });

        modelBuilder.Entity<TblEmpleado>(entity =>
        {
            entity.HasKey(e => e.NumeroId).HasName("PK__tblEmple__405E79FEE1EA01B3");

            entity.ToTable("tblEmpleado");

            entity.Property(e => e.NumeroId)
                .ValueGeneratedNever()
                .HasColumnName("numeroID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.FkCargo).HasColumnName("FK_cargo");
            entity.Property(e => e.FkEspecialidad).HasColumnName("FK_especialidad");
            entity.Property(e => e.FkTipoDocumento).HasColumnName("FK_tipoDocumento");
            entity.Property(e => e.FkTurno).HasColumnName("FK_turno");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Salario).HasColumnName("salario");
            entity.Property(e => e.UsuarioCrea).HasColumnName("usuarioCrea");

            
        });

        modelBuilder.Entity<TblEspecialidad>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblEspec__40F9A207AAC04EC0");

            entity.ToTable("tblEspecialidad");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UsuarioCrea).HasColumnName("usuarioCrea");
        });

        modelBuilder.Entity<TblEstado>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblEstad__40F9A207DFEAEB66");

            entity.ToTable("tblEstado");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblEstadoConservacion>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblEstad__40F9A2077DA553FC");

            entity.ToTable("tblEstadoConservacion");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblFormaPago>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblForma__40F9A207146314AC");

            entity.ToTable("tblFormaPago");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblMarca>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblMarca__40F9A207F70304CE");

            entity.ToTable("tblMarca");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblMatricula>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblMatri__40F9A2075D32E1AE");

            entity.ToTable("tblMatricula");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.FkFormaPago).HasColumnName("FK_formaPago");
            entity.Property(e => e.FkSocio).HasColumnName("FK_socio");
            entity.Property(e => e.MontoPagado).HasColumnName("montoPagado");
            entity.Property(e => e.Recurrente)
                .HasDefaultValue(true)
                .HasColumnName("recurrente");
            entity.Property(e => e.UsuarioCrea).HasColumnName("usuarioCrea");

            
        });

        modelBuilder.Entity<TblMembresium>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblMembr__40F9A20739F2CDEF");

            entity.ToTable("tblMembresia");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblMonitor>(entity =>
        {
            entity.HasKey(e => e.NumeroId).HasName("PK__tblMonit__405E79FE58FF38A7");

            entity.ToTable("tblMonitor");

            entity.Property(e => e.NumeroId)
                .ValueGeneratedNever()
                .HasColumnName("numeroID");
            entity.Property(e => e.Experiencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("experiencia");
            entity.Property(e => e.FkEspecialidad).HasColumnName("FK_especialidad");
            entity.Property(e => e.Titulacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulacion");

            
        });

        modelBuilder.Entity<TblProfesion>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblProfe__40F9A207C3AFF5B2");

            entity.ToTable("tblProfesion");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblRecurso>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblRecur__40F9A207B70FF902");

            entity.ToTable("tblRecurso");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCompra).HasColumnName("fechaCompra");
            entity.Property(e => e.FkEstadoConservacion).HasColumnName("FK_estadoConservacion");
            entity.Property(e => e.FkMarca).HasColumnName("FK_marca");
            entity.Property(e => e.FkSala).HasColumnName("FK_sala");
            entity.Property(e => e.UsuarioCrea).HasColumnName("usuarioCrea");

            
        });

        modelBuilder.Entity<TblSala>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK__tblSala__FC77F210B0A07EF5");

            entity.ToTable("tblSala");

            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.FkTamano).HasColumnName("FK_tamano");
            entity.Property(e => e.FkTipoSala).HasColumnName("FK_tipoSala");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            
        });

        modelBuilder.Entity<TblSocio>(entity =>
        {
            entity.HasKey(e => e.NumeroId).HasName("PK__tblSocio__405E79FED3E9C6F0");

            entity.ToTable("tblSocio");

            entity.Property(e => e.NumeroId)
                .ValueGeneratedNever()
                .HasColumnName("numeroID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FechaAfiliacion).HasColumnName("fechaAfiliacion");
            entity.Property(e => e.FkEstado).HasColumnName("FK_estado");
            entity.Property(e => e.FkMembresia).HasColumnName("FK_membresia");
            entity.Property(e => e.FkProfesion).HasColumnName("FK_profesion");
            entity.Property(e => e.FkTipoDocumento).HasColumnName("FK_tipoDocumento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ObservacionMedica)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observacionMedica");
            entity.Property(e => e.UsuarioCrea).HasColumnName("usuarioCrea");

            
        });

        modelBuilder.Entity<TblTamano>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTaman__40F9A207B1E3E274");

            entity.ToTable("tblTamano");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Espacio).HasColumnName("espacio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblTelEmpleadoEmpleado>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelEm__40F9A207A0EA3FD0");

            entity.ToTable("tblTelEmpleado_Empleado");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FkEmpleado).HasColumnName("FK_empleado");
            entity.Property(e => e.FkTelefonoEmpleado).HasColumnName("FK_telefonoEmpleado");

            
        });

        modelBuilder.Entity<TblTelSocioSocio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelSo__40F9A20773624FB9");

            entity.ToTable("tblTelSocio_Socio");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FkSocio).HasColumnName("FK_socio");
            entity.Property(e => e.FkTelefonoSocio).HasColumnName("FK_telefonoSocio");

           
        });

        modelBuilder.Entity<TblTelefonoEmpleado>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelef__40F9A207D2ECBE7F");

            entity.ToTable("tblTelefonoEmpleado");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.FkTipoTelefono).HasColumnName("FK_tipoTelefono");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Principal)
                .HasDefaultValue(false)
                .HasColumnName("principal");

            
        });

        modelBuilder.Entity<TblTelefonoSocio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelef__40F9A2073D9EDAFE");

            entity.ToTable("tblTelefonoSocio");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.FkTipoTelefono).HasColumnName("FK_tipoTelefono");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Principal)
                .HasDefaultValue(false)
                .HasColumnName("principal");

            
        });

        modelBuilder.Entity<TblTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTipoD__40F9A207E3721610");

            entity.ToTable("tblTipoDocumento");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblTipoSala>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTipoS__40F9A2070BC0A92C");

            entity.ToTable("tblTipoSala");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblTipoTelefono>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTipoT__40F9A207711C874B");

            entity.ToTable("tblTipoTelefono");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TblTurno>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTurno__40F9A2070AA83327");

            entity.ToTable("tblTurno");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblUsuar__40F9A2073224EAC7");

            entity.ToTable("tblUsuario");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Usuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
