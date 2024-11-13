using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class MateriaModels
    {
        public int Legajo { get; set; }
        public string Carrera { get; set; }
        public string Materia { get; set; }
        public int? AnioPlan { get; set; }
        public List<AlumnoMateriaModels> ListAlumno { get; set; }
    }
}
