using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Carrera
{
    public int Id { get; set; }

    public string Carrera1 { get; set; } = null!;

    public int? AnioPlan { get; set; }

    public virtual ICollection<InscripcionACarrera> InscripcionACarreras { get; set; } = new List<InscripcionACarrera>();

    public virtual ICollection<Materiasxcarrera> Materiasxcarreras { get; set; } = new List<Materiasxcarrera>();
}
