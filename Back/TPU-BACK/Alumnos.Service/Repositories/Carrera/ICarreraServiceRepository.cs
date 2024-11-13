using Alumnos.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Service.Repositories.Carrera
{
    public interface ICarreraServiceRepository
    {
        Task<List<InfoAlumnoModels>> GetCarreraInfoUserAsync(int legajo);
        Task<List<InfoAlumnoNotasModls>> GetCarreraInfoNotaUserAsync(int legajo);
    }
}
