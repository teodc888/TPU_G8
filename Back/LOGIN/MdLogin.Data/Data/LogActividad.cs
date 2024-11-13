using System;
using System.Collections.Generic;

namespace MdLogin.Data.Data;

public partial class LogActividad
{
    public int LogId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaActividad { get; set; }

    public string TipoActividad { get; set; } = null!;

    public string? DescripciónActividad { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
