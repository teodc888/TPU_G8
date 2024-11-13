﻿using System;
using System.Collections.Generic;

namespace Alumnos.Data.Data;

public partial class TiposDoc
{
    public int Id { get; set; }

    public string TipoDoc { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();
}