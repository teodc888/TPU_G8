using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class InfoDocenteModels
    {
        public double PromedioNotas { get; set; }
        public int AlumnosTotales { get; set; }
        public int MateriaInscriptas { get; set; }
        public int AlumnosEnRiesgo {  get; set; }
        public List<DocenteEstadoAlumnos> estadoAlumnos { get; set; }
        public List<DocenteDistriEdad> GetDocenteDistriEdad {  get; set; }
        public DocenteMateriasPromedioModel DocenteMateriasPromedio { get; set; }
    }
    
}
