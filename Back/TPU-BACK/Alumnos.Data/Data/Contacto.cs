using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Contacto
{
    public int Id { get; set; }

    public int TipoContacto { get; set; }

    public int? LegajoAlumno { get; set; }

    public int? LegajoDocente { get; set; }

    public string? Contacto1 { get; set; }

    public virtual Alumno? LegajoAlumnoNavigation { get; set; }

    public virtual Docente? LegajoDocenteNavigation { get; set; }

    public virtual TiposContacto TipoContactoNavigation { get; set; } = null!;
}
