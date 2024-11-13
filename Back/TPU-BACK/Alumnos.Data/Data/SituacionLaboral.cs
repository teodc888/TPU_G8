using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class SituacionLaboral
{
    public int Id { get; set; }

    public string SituacionLab { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
