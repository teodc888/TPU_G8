using System;
using System.Collections.Generic;

namespace MdLogin.Data.Data;

public partial class Permiso
{
    public int PermisoId { get; set; }

    public string NombrePermiso { get; set; } = null!;

    public string? DescripciónPermiso { get; set; }

    public virtual ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
}
