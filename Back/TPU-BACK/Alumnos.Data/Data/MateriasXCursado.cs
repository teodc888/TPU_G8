using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class MateriasXCursado
{
    public int Id { get; set; }

    public int Materiaxcarrera { get; set; }

    public int? InscripCursado { get; set; }

    public virtual ICollection<Cursada> Cursada { get; set; } = new List<Cursada>();

    public virtual InscripcionACursado? InscripCursadoNavigation { get; set; }

    public virtual Materiasxcarrera MateriaxcarreraNavigation { get; set; } = null!;
}
