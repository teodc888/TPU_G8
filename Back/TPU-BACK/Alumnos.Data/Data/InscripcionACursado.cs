using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class InscripcionACursado
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int Alumno { get; set; }

    public int InscripCarrer { get; set; }

    public virtual Alumno AlumnoNavigation { get; set; } = null!;

    public virtual InscripcionACarrera InscripCarrerNavigation { get; set; } = null!;

    public virtual ICollection<MateriasXCursado> MateriasXCursados { get; set; } = new List<MateriasXCursado>();
}
