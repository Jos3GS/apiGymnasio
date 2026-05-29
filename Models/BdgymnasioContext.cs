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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BDGymnasio; Trusted_Connection=SSPI; MultipleActiveResultSets=true; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCargo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblCargo__40F9A2071AF7EDD2");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblCiuda__40F9A2076A6F4972");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblClase__40F9A20764C856A3");

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

            entity.HasOne(d => d.FkEspecialidadNavigation).WithMany(p => p.TblClases)
                .HasForeignKey(d => d.FkEspecialidad)
                .HasConstraintName("FK__tblClase__FK_esp__2FCF1A8A");

            entity.HasOne(d => d.FkMonitorNavigation).WithMany(p => p.TblClases)
                .HasForeignKey(d => d.FkMonitor)
                .HasConstraintName("FK__tblClase__FK_mon__2DE6D218");

            entity.HasOne(d => d.FkSalaNavigation).WithMany(p => p.TblClases)
                .HasForeignKey(d => d.FkSala)
                .HasConstraintName("FK__tblClase__FK_sal__2EDAF651");
        });

        modelBuilder.Entity<TblDetalleMatricula>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblDetal__40F9A207FB376167");

            entity.ToTable("tblDetalleMatricula");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FkClase).HasColumnName("FK_clase");
            entity.Property(e => e.FkMatricula).HasColumnName("FK_matricula");

            entity.HasOne(d => d.FkClaseNavigation).WithMany(p => p.TblDetalleMatriculas)
                .HasForeignKey(d => d.FkClase)
                .HasConstraintName("FK__tblDetall__FK_cl__32AB8735");

            entity.HasOne(d => d.FkMatriculaNavigation).WithMany(p => p.TblDetalleMatriculas)
                .HasForeignKey(d => d.FkMatricula)
                .HasConstraintName("FK__tblDetall__FK_ma__339FAB6E");
        });

        modelBuilder.Entity<TblDireccionEmpleado>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblDirec__40F9A20706BCA6BE");

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

            entity.HasOne(d => d.FkCiudadNavigation).WithMany(p => p.TblDireccionEmpleados)
                .HasForeignKey(d => d.FkCiudad)
                .HasConstraintName("FK__tblDirecc__FK_ci__25518C17");

            entity.HasOne(d => d.FkEmpleadoNavigation).WithMany(p => p.TblDireccionEmpleados)
                .HasForeignKey(d => d.FkEmpleado)
                .HasConstraintName("FK__tblDirecc__FK_em__245D67DE");
        });

        modelBuilder.Entity<TblDireccionSocio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblDirec__40F9A207DBDE3F54");

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

            entity.HasOne(d => d.FkCiudadNavigation).WithMany(p => p.TblDireccionSocios)
                .HasForeignKey(d => d.FkCiudad)
                .HasConstraintName("FK__tblDirecc__FK_ci__208CD6FA");

            entity.HasOne(d => d.FkSocioNavigation).WithMany(p => p.TblDireccionSocios)
                .HasForeignKey(d => d.FkSocio)
                .HasConstraintName("FK__tblDirecc__FK_so__1F98B2C1");
        });

        modelBuilder.Entity<TblEmpleado>(entity =>
        {
            entity.HasKey(e => e.NumeroId).HasName("PK__tblEmple__405E79FE1F2927BB");

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

            entity.HasOne(d => d.FkCargoNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.FkCargo)
                .HasConstraintName("FK__tblEmplea__FK_ca__7F2BE32F");

            entity.HasOne(d => d.FkEspecialidadNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.FkEspecialidad)
                .HasConstraintName("FK__tblEmplea__FK_es__01142BA1");

            entity.HasOne(d => d.FkTipoDocumentoNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.FkTipoDocumento)
                .HasConstraintName("FK__tblEmplea__FK_ti__7D439ABD");

            entity.HasOne(d => d.FkTurnoNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.FkTurno)
                .HasConstraintName("FK__tblEmplea__FK_tu__00200768");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK__tblEmplea__FK_us__7E37BEF6");
        });

        modelBuilder.Entity<TblEspecialidad>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblEspec__40F9A20791F57E3B");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblEstad__40F9A207FC7DC2B8");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblEstad__40F9A207090B1001");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblForma__40F9A207FD145700");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblMarca__40F9A20719D07E01");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblMatri__40F9A20795328852");

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

            entity.HasOne(d => d.FkFormaPagoNavigation).WithMany(p => p.TblMatriculas)
                .HasForeignKey(d => d.FkFormaPago)
                .HasConstraintName("FK__tblMatric__FK_fo__2A164134");

            entity.HasOne(d => d.FkSocioNavigation).WithMany(p => p.TblMatriculas)
                .HasForeignKey(d => d.FkSocio)
                .HasConstraintName("FK__tblMatric__FK_so__29221CFB");
        });

        modelBuilder.Entity<TblMembresium>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblMembr__40F9A20735E44A64");

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
            entity.HasKey(e => e.NumeroId).HasName("PK__tblMonit__405E79FE9BCEF84D");

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

            entity.HasOne(d => d.FkEspecialidadNavigation).WithMany(p => p.TblMonitors)
                .HasForeignKey(d => d.FkEspecialidad)
                .HasConstraintName("FK__tblMonito__FK_es__04E4BC85");

            entity.HasOne(d => d.Numero).WithOne(p => p.TblMonitor)
                .HasForeignKey<TblMonitor>(d => d.NumeroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblMonito__numer__03F0984C");
        });

        modelBuilder.Entity<TblProfesion>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblProfe__40F9A20758C87FDD");

            entity.ToTable("tblProfesion");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblRecurso>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblRecur__40F9A2079C5DE570");

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

            entity.HasOne(d => d.FkEstadoConservacionNavigation).WithMany(p => p.TblRecursos)
                .HasForeignKey(d => d.FkEstadoConservacion)
                .HasConstraintName("FK__tblRecurs__FK_es__797309D9");

            entity.HasOne(d => d.FkMarcaNavigation).WithMany(p => p.TblRecursos)
                .HasForeignKey(d => d.FkMarca)
                .HasConstraintName("FK__tblRecurs__FK_ma__7A672E12");

            entity.HasOne(d => d.FkSalaNavigation).WithMany(p => p.TblRecursos)
                .HasForeignKey(d => d.FkSala)
                .HasConstraintName("FK__tblRecurs__FK_sa__787EE5A0");
        });

        modelBuilder.Entity<TblSala>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK__tblSala__FC77F210A2C5FDFD");

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

            entity.HasOne(d => d.FkTamanoNavigation).WithMany(p => p.TblSalas)
                .HasForeignKey(d => d.FkTamano)
                .HasConstraintName("FK__tblSala__FK_tama__73BA3083");

            entity.HasOne(d => d.FkTipoSalaNavigation).WithMany(p => p.TblSalas)
                .HasForeignKey(d => d.FkTipoSala)
                .HasConstraintName("FK__tblSala__FK_tipo__74AE54BC");
        });

        modelBuilder.Entity<TblSocio>(entity =>
        {
            entity.HasKey(e => e.NumeroId).HasName("PK__tblSocio__405E79FE13FC47FB");

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

            entity.HasOne(d => d.FkEstadoNavigation).WithMany(p => p.TblSocios)
                .HasForeignKey(d => d.FkEstado)
                .HasConstraintName("FK__tblSocio__FK_est__09A971A2");

            entity.HasOne(d => d.FkMembresiaNavigation).WithMany(p => p.TblSocios)
                .HasForeignKey(d => d.FkMembresia)
                .HasConstraintName("FK__tblSocio__FK_mem__0A9D95DB");

            entity.HasOne(d => d.FkProfesionNavigation).WithMany(p => p.TblSocios)
                .HasForeignKey(d => d.FkProfesion)
                .HasConstraintName("FK__tblSocio__FK_pro__07C12930");

            entity.HasOne(d => d.FkTipoDocumentoNavigation).WithMany(p => p.TblSocios)
                .HasForeignKey(d => d.FkTipoDocumento)
                .HasConstraintName("FK__tblSocio__FK_tip__08B54D69");
        });

        modelBuilder.Entity<TblTamano>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTaman__40F9A2078F265C1D");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelEm__40F9A207840B33EF");

            entity.ToTable("tblTelEmpleado_Empleado");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FkEmpleado).HasColumnName("FK_empleado");
            entity.Property(e => e.FkTelefonoEmpleado).HasColumnName("FK_telefonoEmpleado");

            entity.HasOne(d => d.FkEmpleadoNavigation).WithMany(p => p.TblTelEmpleadoEmpleados)
                .HasForeignKey(d => d.FkEmpleado)
                .HasConstraintName("FK__tblTelEmp__FK_em__1BC821DD");

            entity.HasOne(d => d.FkTelefonoEmpleadoNavigation).WithMany(p => p.TblTelEmpleadoEmpleados)
                .HasForeignKey(d => d.FkTelefonoEmpleado)
                .HasConstraintName("FK__tblTelEmp__FK_te__1AD3FDA4");
        });

        modelBuilder.Entity<TblTelSocioSocio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelSo__40F9A207E38C5BCF");

            entity.ToTable("tblTelSocio_Socio");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.FkSocio).HasColumnName("FK_socio");
            entity.Property(e => e.FkTelefonoSocio).HasColumnName("FK_telefonoSocio");

            entity.HasOne(d => d.FkSocioNavigation).WithMany(p => p.TblTelSocioSocios)
                .HasForeignKey(d => d.FkSocio)
                .HasConstraintName("FK__tblTelSoc__FK_so__1332DBDC");

            entity.HasOne(d => d.FkTelefonoSocioNavigation).WithMany(p => p.TblTelSocioSocios)
                .HasForeignKey(d => d.FkTelefonoSocio)
                .HasConstraintName("FK__tblTelSoc__FK_te__123EB7A3");
        });

        modelBuilder.Entity<TblTelefonoEmpleado>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelef__40F9A207A37B85AC");

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

            entity.HasOne(d => d.FkTipoTelefonoNavigation).WithMany(p => p.TblTelefonoEmpleados)
                .HasForeignKey(d => d.FkTipoTelefono)
                .HasConstraintName("FK__tblTelefo__FK_ti__17F790F9");
        });

        modelBuilder.Entity<TblTelefonoSocio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTelef__40F9A2070BCD4E8D");

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

            entity.HasOne(d => d.FkTipoTelefonoNavigation).WithMany(p => p.TblTelefonoSocios)
                .HasForeignKey(d => d.FkTipoTelefono)
                .HasConstraintName("FK__tblTelefo__FK_ti__0F624AF8");
        });

        modelBuilder.Entity<TblTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tblTipoD__40F9A2073286F78D");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblTipoS__40F9A207E1630F78");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblTipoT__40F9A2078D4E6BCE");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblTurno__40F9A207D34BC532");

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
            entity.HasKey(e => e.Codigo).HasName("PK__tblUsuar__40F9A207DF494E11");

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
