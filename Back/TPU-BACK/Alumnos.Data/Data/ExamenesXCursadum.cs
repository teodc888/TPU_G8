using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class ExamenesXCursadum
{
    public int Id { get; set; }

    public int Cursada { get; set; }

    public int Examen { get; set; }

    public virtual Cursada CursadaNavigation { get; set; } = null!;

    public virtual Examene ExamenNavigation { get; set; } = null!;
}
