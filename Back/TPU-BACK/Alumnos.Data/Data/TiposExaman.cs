using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class TiposExaman
{
    public int Id { get; set; }

    public string TipoExamen { get; set; } = null!;

    public virtual ICollection<Examene> Examenes { get; set; } = new List<Examene>();
}
