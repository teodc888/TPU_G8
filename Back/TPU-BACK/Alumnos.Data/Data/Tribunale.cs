using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Tribunale
{
    public int Id { get; set; }

    public int Materia { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Aula { get; set; }

    public virtual ICollection<DocentesXTribunale> DocentesXTribunales { get; set; } = new List<DocentesXTribunale>();

    public virtual Materiasxcarrera MateriaNavigation { get; set; } = null!;
}
