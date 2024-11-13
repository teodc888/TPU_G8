using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class GetAlumnosMateria
    {
        public List<AlumnosGet> Alumnos { get; set; }
        public List<MateriaGet> Materias { get; set; }

    }

    public class AlumnosGet
    {
        public int Nombre { get; set; }
    }

    public class MateriaGet
    {
        public string Nombre { get; set; }
    }

}
