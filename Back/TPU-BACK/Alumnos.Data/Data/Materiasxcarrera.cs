using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Materiasxcarrera
{
    public int Id { get; set; }

    public int Carrera { get; set; }

    public int Materia { get; set; }

    public int? DocenteACargo { get; set; }

    public virtual Carrera CarreraNavigation { get; set; } = null!;

    public virtual Docente? DocenteACargoNavigation { get; set; }

    public virtual Materia MateriaNavigation { get; set; } = null!;

    public virtual ICollection<MateriasXCursado> MateriasXCursados { get; set; } = new List<MateriasXCursado>();

    public virtual ICollection<Tribunale> Tribunales { get; set; } = new List<Tribunale>();
}
