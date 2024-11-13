using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Curso
{
    public int Id { get; set; }

    public string Curso1 { get; set; } = null!;

    public int? Turno { get; set; }

    public virtual ICollection<Cursada> Cursada { get; set; } = new List<Cursada>();

    public virtual Turno? TurnoNavigation { get; set; }
}
