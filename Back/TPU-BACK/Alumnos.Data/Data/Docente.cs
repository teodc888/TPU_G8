using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Docente
{
    public int Legajo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int? TipoDoc { get; set; }

    public int NroDoc { get; set; }

    public string? Direccion { get; set; }

    public int? Localidad { get; set; }

    public int? EstadoCivil { get; set; }

    public int? EstadoHabit { get; set; }

    public int? SituacLab { get; set; }

    public DateTime? FechaNac { get; set; }

    public string? TituloUniversitario { get; set; }

    public int? Genero { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual ICollection<DocentesXTribunale> DocentesXTribunales { get; set; } = new List<DocentesXTribunale>();

    public virtual EstadoCivil? EstadoCivilNavigation { get; set; }

    public virtual Genero? GeneroNavigation { get; set; }

    public virtual Localidade? LocalidadNavigation { get; set; }

    public virtual ICollection<Materiasxcarrera> Materiasxcarreras { get; set; } = new List<Materiasxcarrera>();

    public virtual TiposDoc? TipoDocNavigation { get; set; }
}
