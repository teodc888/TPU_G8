using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Alumnos.Data.Data;

public partial class InscripcionExamenesFinal
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public int Cursada { get; set; }

    public string? Codigo { get; set; }

    [JsonIgnore]
    public virtual Cursada CursadaNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Examene> Examenes { get; set; } = new List<Examene>();
}
