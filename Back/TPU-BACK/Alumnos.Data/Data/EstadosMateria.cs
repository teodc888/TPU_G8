using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class EstadosMateria
{
    public int Id { get; set; }

    public string EstadoMateria { get; set; } = null!;

    public virtual ICollection<Cursada> Cursada { get; set; } = new List<Cursada>();
}
