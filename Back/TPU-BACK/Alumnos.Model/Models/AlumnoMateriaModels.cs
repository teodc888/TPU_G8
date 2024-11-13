using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class AlumnoMateriaModels
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<NotaMateria> ListNota { get; set; }
    }

    public class NotaMateria
    {
        public string Materia { get; set; }
        public string Nota { get; set; }
    }
}
