using Alumnos.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Service.Repositories.Docente
{
    public interface IDocenteServiceRepository 
    {
        Task<DocenteModels> GetDocente(int legajo);
        Task<InfoDocenteModels> GetInfoDocente(int legajo);
        Task<List<TribunalModels>> GetTribunalDocente(int legajo);
        Task<List<MateriaModels>> GetMateriaDocente(int legajo);
        Task<List<MateriaModels>> GetMateriaDocenteOnly(int legajo);
        Task<bool> EditarMateria(int legajo, int Nota, string materia);
        Task<bool> InsertAlumoMateria(InsertAlumnoMateria insertAlumnoMateria);
        Task<GetAlumnosMateria> GetAlumnosMateria();

    }
}
