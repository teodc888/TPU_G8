using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class EstadosExamene
{
    public int Id { get; set; }

    public string EstadoExamen { get; set; } = null!;

    public virtual ICollection<Examene> Examenes { get; set; } = new List<Examene>();
}
