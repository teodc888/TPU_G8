using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class TiposContacto
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}
