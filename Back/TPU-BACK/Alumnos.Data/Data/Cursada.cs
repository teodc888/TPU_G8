using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Cursada
{
    public int Id { get; set; }

    public DateOnly? Fecha { get; set; }

    public int MateriaCursada { get; set; }

    public int EstadoMateria { get; set; }

    public int Curso { get; set; }

    public virtual Curso CursoNavigation { get; set; } = null!;

    public virtual EstadosMateria EstadoMateriaNavigation { get; set; } = null!;

    public virtual ICollection<ExamenesXCursadum> ExamenesXCursada { get; set; } = new List<ExamenesXCursadum>();

    public virtual ICollection<InscripcionExamenesFinal> InscripcionExamenesFinals { get; set; } = new List<InscripcionExamenesFinal>();

    public virtual MateriasXCursado MateriaCursadaNavigation { get; set; } = null!;
}
