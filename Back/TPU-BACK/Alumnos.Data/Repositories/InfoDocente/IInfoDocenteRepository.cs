using Alumnos.Model;
using Alumnos.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Data.Repositories.InfoDocente
{
    public interface IInfoDocenteRepository
    {
        Task<DocentePromedioNotasModel> GetDocentePromedioNotasAsync(int docente);
        Task<DocenteTotalAlumnosModel> GetTotalAlumnosPorDocenteAsync(int docente);
        Task<DocenteTotalMateriasModel> GetTotalMateriasPorDocenteAsync(int docenteId);
        Task<DocenteAlumnosRiesgo> GetAlumnosRiesgo(int legajo);
        Task<List<DocenteEstadoAlumnos>> GetDocenteEstadoAlumnos(int legajo);
        Task <List<DocenteDistriEdad>> GetDocenteDistriEdad(int legajo);
        Task<DocenteMateriasPromedioModel> GetMejorYPeorPromedioMateriasPorDocenteAsync(int legajo);
        Task<List<GetInscripcionAlumno>> GetInscripcionAlumno(int legajoDocente);
        Task<List<GetInscripcion>> GetInscripcion(int legajoDocente);


    }
}
