using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdLogin.Data.Data;

public partial class Companium
{
    public int CompaniaId { get; set; }

    public string NombreCompania { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public string? UrlDestino { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
