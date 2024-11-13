using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdLogin.Data.Data;

public partial class Sesion
{
    public int SesionId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string TokenSesion { get; set; } = null!;

    public bool? EstadoSesion { get; set; }

    [JsonIgnore]
    public virtual Usuario Usuario { get; set; } = null!;
}
