using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Genero
{
    public int Id { get; set; }

    public string? Genero1 { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();
}
