using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Alumno
{
    public int Legajo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int TipoDoc { get; set; }

    public int NroDoc { get; set; }

    public string? Direccion { get; set; }

    public int? Localidad { get; set; }

    public int? EstadoCivil { get; set; }

    public int? EstadoHabit { get; set; }

    public int? SituacLab { get; set; }

    public DateTime? FechaNac { get; set; }

    public int? Genero { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual EstadoCivil? EstadoCivilNavigation { get; set; }

    public virtual EstadoHabitacional? EstadoHabitNavigation { get; set; }

    public virtual Genero? GeneroNavigation { get; set; }

    public virtual ICollection<InscripcionACarrera> InscripcionACarreras { get; set; } = new List<InscripcionACarrera>();

    public virtual ICollection<InscripcionACursado> InscripcionACursados { get; set; } = new List<InscripcionACursado>();

    public virtual Localidade? LocalidadNavigation { get; set; }

    public virtual SituacionLaboral? SituacLabNavigation { get; set; }

    public virtual TiposDoc TipoDocNavigation { get; set; } = null!;
}
