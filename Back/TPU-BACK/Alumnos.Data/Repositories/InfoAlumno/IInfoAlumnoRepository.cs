using Alumnos.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Data.Repositories.Carrera
{
    public interface IInfoAlumnoRepository
    {
        Task<List<InfoAlumnoModels>> GetCarreraInfoUserAsync(int legajo);
        Task<List<InfoAlumnoNotasModls>> GetCarreraNotasInfoAsync(int legajo);
    }
}
