using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class TiposMateria
{
    public int Id { get; set; }

    public string TipoMateria { get; set; } = null!;

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
