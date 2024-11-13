using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Model.Models
{
    public class AlumnoModels
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string? Direccion { get; set; }
        public string Localidad { get; set; }
        public string EstadoCivil { get; set; }
        public string EstadoHabitacional { get; set; }
        public string SituacionLaboral { get; set; }
        public string FechaNacimiento { get; set; } 
        public string Genero { get; set; }
    }
}
