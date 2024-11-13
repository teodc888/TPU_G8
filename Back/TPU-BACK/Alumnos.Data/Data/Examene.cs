using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Examene
{
    public int Id { get; set; }

    public int Nota { get; set; }

    public int EstadoExamen { get; set; }

    public int TipoExamen { get; set; }

    public int? InscripFinal { get; set; }

    public int? Tribunal { get; set; }

    public virtual EstadosExamene EstadoExamenNavigation { get; set; } = null!;

    public virtual ICollection<ExamenesXCursadum> ExamenesXCursada { get; set; } = new List<ExamenesXCursadum>();

    public virtual InscripcionExamenesFinal? InscripFinalNavigation { get; set; }

    public virtual TiposExaman TipoExamenNavigation { get; set; } = null!;

    public virtual DocentesXTribunale? TribunalNavigation { get; set; }
}
