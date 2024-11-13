using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class DocenteMateriasPromedioModel
    {
        public int Legajo { get; set; }
        public List<MateriaPromedioModel> MejoresMaterias { get; set; }
        public List<MateriaPromedioModel> PeoresMaterias { get; set; }
    }

    public class MateriaPromedioModel
    {
        public int Legajo { get; set; }
        public string Materia { get; set; }
        public double PromedioNotas { get; set; }
    }
}
