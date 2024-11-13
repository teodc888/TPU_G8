using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Alumnos.Data.Data;

public partial class InscripcionACarrera
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int Alumno { get; set; }

    public int Carrera { get; set; }

    public virtual Alumno AlumnoNavigation { get; set; } = null!;

    public virtual Carrera CarreraNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<InscripcionACursado> InscripcionACursados { get; set; } = new List<InscripcionACursado>();
}
