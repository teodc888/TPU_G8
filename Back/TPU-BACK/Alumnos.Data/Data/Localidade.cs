using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class Localidade
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Provincia { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    public virtual Provincia? ProvinciaNavigation { get; set; }
}
