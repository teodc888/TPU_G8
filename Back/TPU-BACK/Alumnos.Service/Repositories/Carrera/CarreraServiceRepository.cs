using Alumnos.Data.Data;
using Alumnos.Data.Repositories.Carrera;
using Alumnos.Data.Repositories.Class;
using Alumnos.Data.Repositories.GenericRepository;
using Alumnos.Model.Models;
using System;
using System.Threading.Tasks;

namespace Alumnos.Service.Repositories.Carrera
{
    public class CarreraServiceRepository : ICarreraServiceRepository
    {
        private readonly InscripcionACarreraRepository _repositoryInscripcionACarrera;
        private readonly IGenericRepository<Data.Data.Carrera> _repositoryCarrera;
        private readonly MateriasxcarreraRepository _repositoryMateriaXCarrera;
        private readonly IGenericRepository<Materia> _repositoryMateria;
        private readonly IGenericRepository<TiposMateria> _repositoryTiposMateria;
        private readonly IGenericRepository<MateriasXCursado> _repositoryMateriasXCursado;
        private readonly IGenericRepository<InscripcionACursado> _repositoryInscripcionACursado;
        private readonly IInfoAlumnoRepository _infoAlumnoRepository;

        public CarreraServiceRepository(
            InscripcionACarreraRepository repositoryInscripcionACarrera,
            IGenericRepository<Data.Data.Carrera> repositoryCarrera,
            MateriasxcarreraRepository repositoryMateriaXCarrera,
            IGenericRepository<Materia> repositoryMateria,
            IGenericRepository<TiposMateria> repositoryTiposMateria,
            IGenericRepository<MateriasXCursado> repositoryMateriasXCursado,
            IGenericRepository<InscripcionACursado> repositoryInscripcionACursado,
            IInfoAlumnoRepository infoAlumnoRepository
            )
        {
            _repositoryInscripcionACarrera = repositoryInscripcionACarrera;
            _repositoryCarrera = repositoryCarrera;
            _repositoryMateriaXCarrera = repositoryMateriaXCarrera;
            _repositoryMateria = repositoryMateria;
            _repositoryTiposMateria = repositoryTiposMateria;
            _repositoryMateriasXCursado = repositoryMateriasXCursado;
            _repositoryInscripcionACursado = repositoryInscripcionACursado;
            _infoAlumnoRepository = infoAlumnoRepository;
        }

        public async Task<List<InfoAlumnoModels>> GetCarreraInfoUserAsync(int legajo)
        {
            try
            {
                List<InfoAlumnoModels> list = await _infoAlumnoRepository.GetCarreraInfoUserAsync(legajo);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<InfoAlumnoNotasModls>> GetCarreraInfoNotaUserAsync(int legajo)
        {
            try
            {
                List<InfoAlumnoNotasModls> list = await _infoAlumnoRepository.GetCarreraNotasInfoAsync(legajo);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
