using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class InfoAlumnoModels
    {
        public int Legajo { get; set; }
        public string Carrera { get; set; }
        public string Materia { get; set; }
        public string TipoMateria { get; set; }
        public string FechaInscripcionCursado { get; set; }
        public string FechaInscripcionMateria { get; set; }
    }

    public class InfoAlumnoNotasModls
    {
        public int Legajo { get; set; }
        public string Curso { get; set; }
        public string Estado { get; set; }
        public string Materia { get; set; }
        public string Nota { get; set; }
        public DateOnly? FechaCursado { get; set; }
    }
}
