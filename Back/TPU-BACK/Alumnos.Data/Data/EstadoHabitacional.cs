using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class EstadoHabitacional
{
    public int Id { get; set; }

    public string EstadoHabitacional1 { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
