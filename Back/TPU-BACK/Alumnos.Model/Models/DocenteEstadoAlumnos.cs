using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class DocenteEstadoAlumnos
    {
        public int LegajoDocente { get; set; }
        public string EstadoMateria { get; set; }
        public int Cantidad { get; set; } // Propiedad para contar la cantidad de alumnos
    }
}
