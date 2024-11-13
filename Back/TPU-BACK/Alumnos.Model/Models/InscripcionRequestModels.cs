using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class InscripcionRequestModels
    {
        public int Legajo { get; set; }
        public string NombreMateria { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }
}
