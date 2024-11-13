using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class DocentesXTribunale
{
    public int Id { get; set; }

    public int Docente { get; set; }

    public int Tribunal { get; set; }

    public virtual Docente DocenteNavigation { get; set; } = null!;

    public virtual ICollection<Examene> Examenes { get; set; } = new List<Examene>();

    public virtual Tribunale TribunalNavigation { get; set; } = null!;
}
