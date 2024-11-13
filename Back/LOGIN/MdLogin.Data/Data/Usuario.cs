using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdLogin.Data.Data;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int CompaniaId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public string PasswordSalt { get; set; } = null!;

    public virtual Companium Compania { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<LogActividad> LogActividads { get; set; } = new List<LogActividad>();

    [JsonIgnore]
    public virtual ICollection<Sesion> Sesions { get; set; } = new List<Sesion>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
