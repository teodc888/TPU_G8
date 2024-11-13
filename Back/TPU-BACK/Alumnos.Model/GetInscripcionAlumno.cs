using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model
{
    public class GetInscripcionAlumno
    {
        public int Docente { get; set; }
        public int Alumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Materia { get; set; }
        public string Carrera { get; set; }
        public int Anio { get; set; }
        public int Nota { get; set; }
        
    }
}
