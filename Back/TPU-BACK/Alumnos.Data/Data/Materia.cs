using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Materia
{
    public int Id { get; set; }

    public string Materia1 { get; set; } = null!;

    public int? TipoMateria { get; set; }

    public virtual ICollection<Materiasxcarrera> Materiasxcarreras { get; set; } = new List<Materiasxcarrera>();

    public virtual TiposMateria? TipoMateriaNavigation { get; set; }
}
