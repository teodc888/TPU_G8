using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Turno
{
    public int Id { get; set; }

    public string Turno1 { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
