using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Alumnos.Data.Data;

public partial class TpiDatosContext : DbContext
{
    public TpiDatosContext()
    {
    }

    public TpiDatosContext(DbContextOptions<TpiDatosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Cursada> Cursadas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<DocentesXTribunale> DocentesXTribunales { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<EstadoHabitacional> EstadoHabitacionals { get; set; }

    public virtual DbSet<EstadosExamene> EstadosExamenes { get; set; }

    public virtual DbSet<EstadosMateria> EstadosMaterias { get; set; }

    public virtual DbSet<Examene> Examenes { get; set; }

    public virtual DbSet<ExamenesXCursadum> ExamenesXCursada { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<InscripcionACarrera> InscripcionACarreras { get; set; }

    public virtual DbSet<InscripcionACursado> InscripcionACursados { get; set; }

    public virtual DbSet<InscripcionExamenesFinal> InscripcionExamenesFinals { get; set; }

    public virtual DbSet<Localidade> Localidades { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<MateriasXCursado> MateriasXCursados { get; set; }

    public virtual DbSet<Materiasxcarrera> Materiasxcarreras { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<SituacionLaboral> SituacionLaborals { get; set; }

    public virtual DbSet<TiposContacto> TiposContactos { get; set; }

    public virtual DbSet<TiposDoc> TiposDocs { get; set; }

    public virtual DbSet<TiposExaman> TiposExamen { get; set; }

    public virtual DbSet<TiposMateria> TiposMaterias { get; set; }

    public virtual DbSet<Tribunale> Tribunales { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TEODELLACQUA\\TEODELLACQUA; Initial Catalog=TPI_DATOS;Persist Security Info=True;User ID=sa;password=12345678;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Legajo).HasName("PK__ALUMNOS__5487D90708BDFD50");

            entity.ToTable("ALUMNOS");

            entity.Property(e => e.Legajo)
                .ValueGeneratedNever()
                .HasColumnName("LEGAJO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.EstadoCivil).HasColumnName("ESTADO_CIVIL");
            entity.Property(e => e.EstadoHabit).HasColumnName("ESTADO_HABIT");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ALTA");
            entity.Property(e => e.FechaBaja)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_BAJA");
            entity.Property(e => e.FechaNac)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NAC");
            entity.Property(e => e.Genero).HasColumnName("GENERO");
            entity.Property(e => e.Localidad).HasColumnName("LOCALIDAD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.SituacLab).HasColumnName("SITUAC_LAB");
            entity.Property(e => e.TipoDoc).HasColumnName("TIPO_DOC");

            entity.HasOne(d => d.EstadoCivilNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.EstadoCivil)
                .HasConstraintName("FK_ESTADO_CIVIL_AL");

            entity.HasOne(d => d.EstadoHabitNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.EstadoHabit)
                .HasConstraintName("FK_ESTADO_HABIT_AL");

            entity.HasOne(d => d.GeneroNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.Genero)
                .HasConstraintName("FK_GENERO_AL");

            entity.HasOne(d => d.LocalidadNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.Localidad)
                .HasConstraintName("FK_LOCALIDAD_AL");

            entity.HasOne(d => d.SituacLabNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.SituacLab)
                .HasConstraintName("FK_SITUAC_LAB_AL");

            entity.HasOne(d => d.TipoDocNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.TipoDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIPO_DOC_AL");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CARRERAS__3214EC273C8F32F9");

            entity.ToTable("CARRERAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnioPlan).HasColumnName("ANIO_PLAN");
            entity.Property(e => e.Carrera1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CARRERA");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CONTACTO__3214EC27C01F9EC6");

            entity.ToTable("CONTACTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contacto1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.LegajoAlumno).HasColumnName("LEGAJO_ALUMNO");
            entity.Property(e => e.LegajoDocente).HasColumnName("LEGAJO_DOCENTE");
            entity.Property(e => e.TipoContacto).HasColumnName("TIPO_CONTACTO");

            entity.HasOne(d => d.LegajoAlumnoNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.LegajoAlumno)
                .HasConstraintName("FK_CONTACTOS_ALUMNOS");

            entity.HasOne(d => d.LegajoDocenteNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.LegajoDocente)
                .HasConstraintName("FK_CONTACTOS_DOCENTES");

            entity.HasOne(d => d.TipoContactoNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.TipoContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONTACTOS_TIPO_CONTACTO");
        });

        modelBuilder.Entity<Cursada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CURSADAS__3214EC2701CD4BD2");

            entity.ToTable("CURSADAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Curso).HasColumnName("CURSO");
            entity.Property(e => e.EstadoMateria).HasColumnName("ESTADO_MATERIA");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.MateriaCursada).HasColumnName("MATERIA_CURSADA");

            entity.HasOne(d => d.CursoNavigation).WithMany(p => p.Cursada)
                .HasForeignKey(d => d.Curso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CURSO");

            entity.HasOne(d => d.EstadoMateriaNavigation).WithMany(p => p.Cursada)
                .HasForeignKey(d => d.EstadoMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ESTADO_MATERIA");

            entity.HasOne(d => d.MateriaCursadaNavigation).WithMany(p => p.Cursada)
                .HasForeignKey(d => d.MateriaCursada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MAT_CURSADA");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CURSOS__3214EC27F0DF3A7C");

            entity.ToTable("CURSOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Curso1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURSO");
            entity.Property(e => e.Turno).HasColumnName("TURNO");

            entity.HasOne(d => d.TurnoNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.Turno)
                .HasConstraintName("FK_TURNO");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.Legajo).HasName("PK__DOCENTES__5487D907348E5DCA");

            entity.ToTable("DOCENTES");

            entity.Property(e => e.Legajo)
                .ValueGeneratedNever()
                .HasColumnName("LEGAJO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.EstadoCivil).HasColumnName("ESTADO_CIVIL");
            entity.Property(e => e.EstadoHabit).HasColumnName("ESTADO_HABIT");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ALTA");
            entity.Property(e => e.FechaBaja)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_BAJA");
            entity.Property(e => e.FechaNac)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NAC");
            entity.Property(e => e.Genero).HasColumnName("GENERO");
            entity.Property(e => e.Localidad).HasColumnName("LOCALIDAD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.SituacLab).HasColumnName("SITUAC_LAB");
            entity.Property(e => e.TipoDoc).HasColumnName("TIPO_DOC");
            entity.Property(e => e.TituloUniversitario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TITULO_UNIVERSITARIO");

            entity.HasOne(d => d.EstadoCivilNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.EstadoCivil)
                .HasConstraintName("FK_ESTADO_CIVIL_DOC");

            entity.HasOne(d => d.GeneroNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.Genero)
                .HasConstraintName("FK_GENERO_DOC");

            entity.HasOne(d => d.LocalidadNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.Localidad)
                .HasConstraintName("FK_LOCALIDAD_DOC");

            entity.HasOne(d => d.TipoDocNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.TipoDoc)
                .HasConstraintName("FK_TIPO_DOC_DOC");
        });

        modelBuilder.Entity<DocentesXTribunale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DOCENTES__3214EC270A4BF54B");

            entity.ToTable("DOCENTES_X_TRIBUNALES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Docente).HasColumnName("DOCENTE");
            entity.Property(e => e.Tribunal).HasColumnName("TRIBUNAL");

            entity.HasOne(d => d.DocenteNavigation).WithMany(p => p.DocentesXTribunales)
                .HasForeignKey(d => d.Docente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DOCENTE");

            entity.HasOne(d => d.TribunalNavigation).WithMany(p => p.DocentesXTribunales)
                .HasForeignKey(d => d.Tribunal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TRIBUNALES");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADO_C__3214EC270167EDF4");

            entity.ToTable("ESTADO_CIVIL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoCivil1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO_CIVIL");
        });

        modelBuilder.Entity<EstadoHabitacional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADO_H__3214EC2730853C9A");

            entity.ToTable("ESTADO_HABITACIONAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoHabitacional1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO_HABITACIONAL");
        });

        modelBuilder.Entity<EstadosExamene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOS___3214EC27EF47283D");

            entity.ToTable("ESTADOS_EXAMENES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoExamen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO_EXAMEN");
        });

        modelBuilder.Entity<EstadosMateria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADOS___3214EC27C2FFC643");

            entity.ToTable("ESTADOS_MATERIAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoMateria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO_MATERIA");
        });

        modelBuilder.Entity<Examene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EXAMENES__3214EC27BD04CF80");

            entity.ToTable("EXAMENES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstadoExamen).HasColumnName("ESTADO_EXAMEN");
            entity.Property(e => e.InscripFinal).HasColumnName("INSCRIP_FINAL");
            entity.Property(e => e.Nota).HasColumnName("NOTA");
            entity.Property(e => e.TipoExamen).HasColumnName("TIPO_EXAMEN");
            entity.Property(e => e.Tribunal).HasColumnName("TRIBUNAL");

            entity.HasOne(d => d.EstadoExamenNavigation).WithMany(p => p.Examenes)
                .HasForeignKey(d => d.EstadoExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ESTADO_EXAMEN");

            entity.HasOne(d => d.InscripFinalNavigation).WithMany(p => p.Examenes)
                .HasForeignKey(d => d.InscripFinal)
                .HasConstraintName("FK_INSCRIP_FINAL");

            entity.HasOne(d => d.TipoExamenNavigation).WithMany(p => p.Examenes)
                .HasForeignKey(d => d.TipoExamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIPO_EXAMEN");

            entity.HasOne(d => d.TribunalNavigation).WithMany(p => p.Examenes)
                .HasForeignKey(d => d.Tribunal)
                .HasConstraintName("FK_DOC_X_TRIB");
        });

        modelBuilder.Entity<ExamenesXCursadum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EXAMENES__3214EC2783915DFA");

            entity.ToTable("EXAMENES_X_CURSADA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cursada).HasColumnName("CURSADA");
            entity.Property(e => e.Examen).HasColumnName("EXAMEN");

            entity.HasOne(d => d.CursadaNavigation).WithMany(p => p.ExamenesXCursada)
                .HasForeignKey(d => d.Cursada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CURSADA");

            entity.HasOne(d => d.ExamenNavigation).WithMany(p => p.ExamenesXCursada)
                .HasForeignKey(d => d.Examen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EXAMEN");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GENEROS__3214EC27311A9964");

            entity.ToTable("GENEROS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Genero1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GENERO");
        });

        modelBuilder.Entity<InscripcionACarrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INSCRIPC__3214EC27E16CE7BE");

            entity.ToTable("INSCRIPCION_A_CARRERAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Alumno).HasColumnName("ALUMNO");
            entity.Property(e => e.Carrera).HasColumnName("CARRERA");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");

            entity.HasOne(d => d.AlumnoNavigation).WithMany(p => p.InscripcionACarreras)
                .HasForeignKey(d => d.Alumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALUMNO_CARR");

            entity.HasOne(d => d.CarreraNavigation).WithMany(p => p.InscripcionACarreras)
                .HasForeignKey(d => d.Carrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CARRERA_INSC");
        });

        modelBuilder.Entity<InscripcionACursado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INSCRIPC__3214EC27BC9C52B4");

            entity.ToTable("INSCRIPCION_A_CURSADO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Alumno).HasColumnName("ALUMNO");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.InscripCarrer).HasColumnName("INSCRIP_CARRER");

            entity.HasOne(d => d.AlumnoNavigation).WithMany(p => p.InscripcionACursados)
                .HasForeignKey(d => d.Alumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALUMNO_MAT");

            entity.HasOne(d => d.InscripCarrerNavigation).WithMany(p => p.InscripcionACursados)
                .HasForeignKey(d => d.InscripCarrer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRIP_CARRER");
        });

        modelBuilder.Entity<InscripcionExamenesFinal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INSCRIPC__3214EC276815A65E");

            entity.ToTable("INSCRIPCION_EXAMENES_FINAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Cursada).HasColumnName("CURSADA");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.Hora).HasColumnName("HORA");

            entity.HasOne(d => d.CursadaNavigation).WithMany(p => p.InscripcionExamenesFinals)
                .HasForeignKey(d => d.Cursada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATERIA_CURSADA_FINAL");
        });

        modelBuilder.Entity<Localidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOCALIDA__3214EC2732181198");

            entity.ToTable("LOCALIDADES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Provincia).HasColumnName("PROVINCIA");

            entity.HasOne(d => d.ProvinciaNavigation).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.Provincia)
                .HasConstraintName("FK_PROVINCIA");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAS__3214EC27B1F00071");

            entity.ToTable("MATERIAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Materia1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MATERIA");
            entity.Property(e => e.TipoMateria).HasColumnName("TIPO_MATERIA");

            entity.HasOne(d => d.TipoMateriaNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.TipoMateria)
                .HasConstraintName("FK_TIPO_MATERIA");
        });

        modelBuilder.Entity<MateriasXCursado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAS__3214EC27E7EB1358");

            entity.ToTable("MATERIAS_X_CURSADO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InscripCursado).HasColumnName("INSCRIP_CURSADO");
            entity.Property(e => e.Materiaxcarrera).HasColumnName("MATERIAXCARRERA");

            entity.HasOne(d => d.InscripCursadoNavigation).WithMany(p => p.MateriasXCursados)
                .HasForeignKey(d => d.InscripCursado)
                .HasConstraintName("INSCRIP_CURSADO");

            entity.HasOne(d => d.MateriaxcarreraNavigation).WithMany(p => p.MateriasXCursados)
                .HasForeignKey(d => d.Materiaxcarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATERIAXCARR");
        });

        modelBuilder.Entity<Materiasxcarrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAS__3214EC277A60D102");

            entity.ToTable("MATERIASXCARRERAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Carrera).HasColumnName("CARRERA");
            entity.Property(e => e.DocenteACargo).HasColumnName("DOCENTE_A_CARGO");
            entity.Property(e => e.Materia).HasColumnName("MATERIA");

            entity.HasOne(d => d.CarreraNavigation).WithMany(p => p.Materiasxcarreras)
                .HasForeignKey(d => d.Carrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CARRERA");

            entity.HasOne(d => d.DocenteACargoNavigation).WithMany(p => p.Materiasxcarreras)
                .HasForeignKey(d => d.DocenteACargo)
                .HasConstraintName("FK_DOCENTE_A_CARGO");

            entity.HasOne(d => d.MateriaNavigation).WithMany(p => p.Materiasxcarreras)
                .HasForeignKey(d => d.Materia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATERIA");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PROVINCI__3214EC27604B14E0");

            entity.ToTable("PROVINCIAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<SituacionLaboral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SITUACIO__3214EC27C3BEFB68");

            entity.ToTable("SITUACION_LABORAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SituacionLab)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SITUACION_LAB");
        });

        modelBuilder.Entity<TiposContacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOS_CO__3214EC27C1FF6BD0");

            entity.ToTable("TIPOS_CONTACTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<TiposDoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOS_DO__3214EC279D737F58");

            entity.ToTable("TIPOS_DOC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_DOC");
        });

        modelBuilder.Entity<TiposExaman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOS_EX__3214EC272C35BFB8");

            entity.ToTable("TIPOS_EXAMEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TipoExamen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_EXAMEN");
        });

        modelBuilder.Entity<TiposMateria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TIPOS_MA__3214EC271B6FED68");

            entity.ToTable("TIPOS_MATERIAS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TipoMateria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_MATERIA");
        });

        modelBuilder.Entity<Tribunale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TRIBUNAL__3214EC27A52749DE");

            entity.ToTable("TRIBUNALES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AULA");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.Materia).HasColumnName("MATERIA");

            entity.HasOne(d => d.MateriaNavigation).WithMany(p => p.Tribunales)
                .HasForeignKey(d => d.Materia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATERIA_TRIB");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TURNOS__3214EC274357BABE");

            entity.ToTable("TURNOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Turno1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TURNO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
