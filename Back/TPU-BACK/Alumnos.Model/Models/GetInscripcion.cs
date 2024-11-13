using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class GetInscripcion
    {
        public int Alumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Materia { get; set; }
        public int Docente { get; set; }
        public string Carrera { get; set; }
        public int AnioPlan { get; set; }
    }

}
