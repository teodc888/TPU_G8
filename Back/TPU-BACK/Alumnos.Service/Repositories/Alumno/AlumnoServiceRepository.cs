using Alumnos.Data.Data;
using Alumnos.Data.Repositories.GenericRepository;
using Alumnos.Model.Models;
using Alumnos.Service.Repositories.Carrera;
using Alumnos.Service.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alumnos.Service.Repositories.Alumno
{
    public class AlumnoServiceRepository : IAlumnoServiceRepository
    {
        private readonly IGenericRepository<Data.Data.Alumno> _repositoryAlumno;
        private readonly IGenericRepository<TiposDoc> _repositoryTipoDoc;
        private readonly IGenericRepository<Localidade> _repositoryLocalidate;
        private readonly IGenericRepository<EstadoCivil> _repositoryEstadoCivil;
        private readonly IGenericRepository<EstadoHabitacional> _repositoryEstadoHabitacional;
        private readonly IGenericRepository<SituacionLaboral> _repositorySituacionLaboral;
        private readonly IGenericRepository<Genero> _repositoryGenero;
        private readonly ICarreraServiceRepository _carreraServiceRepository;
        private readonly AlumnoValidation alumnoValidation;
        private readonly IGenericRepository<InscripcionExamenesFinal> _repositoryInscripcionExamenFinal;
        private readonly IGenericRepository<InscripcionACursado> _repositoryIncripcionCursado;
        private readonly IGenericRepository<MateriasXCursado> _repositoryMateriasCursado;
        private readonly IGenericRepository<EstadosMateria> _repositoryEstadoMateria;
        private readonly IGenericRepository<Cursada> _repositoryCursada;
        private readonly IGenericRepository<Examene> _repositoryExamen;
        private readonly IGenericRepository<Materia> _repositoryMateria;
        private readonly IGenericRepository<Materiasxcarrera> _repositoryMateriasxcarrera;
        public AlumnoServiceRepository(
            IGenericRepository<Data.Data.Alumno> repository,
            IGenericRepository<Localidade> repositoryLocalidate,
            IGenericRepository<EstadoCivil> repositoryEstadoCivil,
            IGenericRepository<EstadoHabitacional> repositoryEstadoHabitacional,
            IGenericRepository<SituacionLaboral> repositorySituacionLaboral,
            IGenericRepository<Genero> repositoryGenero,
            IGenericRepository<TiposDoc> repositoryTipoDoc,
            ICarreraServiceRepository carreraServiceRepository,
            IGenericRepository<InscripcionExamenesFinal> repositoryInscripcionExamenFinal,// Repositorio de Inscripciones
            IGenericRepository<InscripcionACursado> repositoryIncripcionCursado,
            IGenericRepository<MateriasXCursado> repositoryMateriasCursado,
            IGenericRepository<EstadosMateria> repositoryEstadoMateria,
            IGenericRepository<Cursada> repositoryCursada,
            IGenericRepository<Examene> repositoryExamen,
            IGenericRepository<Materia> repositoryMateria,
            IGenericRepository<Materiasxcarrera> repositoryMateriasxcarrera
            )
        {
            _repositoryAlumno = repository;
            _repositoryInscripcionExamenFinal = repositoryInscripcionExamenFinal;
            _repositoryIncripcionCursado = repositoryIncripcionCursado;
            _repositoryMateriasCursado = repositoryMateriasCursado;
            _repositoryEstadoMateria = repositoryEstadoMateria;
            _repositoryCursada = repositoryCursada;
            alumnoValidation = new AlumnoValidation();
            _repositoryLocalidate = repositoryLocalidate;
            _repositoryEstadoCivil = repositoryEstadoCivil;
            _repositoryEstadoHabitacional = repositoryEstadoHabitacional;
            _repositorySituacionLaboral = repositorySituacionLaboral;
            _repositoryGenero = repositoryGenero;
            _repositoryTipoDoc = repositoryTipoDoc;
            _carreraServiceRepository = carreraServiceRepository;
            _repositoryExamen = repositoryExamen;
            _repositoryMateria = repositoryMateria;
            _repositoryMateriasxcarrera = repositoryMateriasxcarrera;
        }

        public async Task<AlumnoModels> GetAlumnoNombreAsync(int legajo)
        {
            try
            {
                AlumnoModels alumnoModels = new AlumnoModels();
                Data.Data.Alumno alumnoEncontrado = await _repositoryAlumno.GetByIdAsync(legajo);

                if (!alumnoValidation.Validate(alumnoEncontrado))
                {
                    throw new Exception("Alumno Invalido");
                }

                alumnoModels.Legajo = alumnoEncontrado.Legajo;
                alumnoModels.Nombre = alumnoEncontrado.Nombre;
                alumnoModels.Apellido = alumnoEncontrado.Apellido;
                alumnoModels.NumeroDocumento = alumnoEncontrado.NroDoc;
                alumnoModels.Direccion = alumnoEncontrado.Direccion;
                alumnoModels.FechaNacimiento = ((DateTime)alumnoEncontrado.FechaNac).ToString("dd/MM/yyyy");

                TiposDoc tiposDoc = await _repositoryTipoDoc.GetByIdAsync(alumnoEncontrado.TipoDoc);
                alumnoModels.TipoDocumento = tiposDoc.TipoDoc;

                Localidade localidad = await _repositoryLocalidate.GetByIdAsync(alumnoEncontrado.Localidad);
                alumnoModels.Localidad = localidad.Nombre;

                EstadoCivil estadoCivil = await _repositoryEstadoCivil.GetByIdAsync(alumnoEncontrado.EstadoCivil);
                alumnoModels.EstadoCivil = estadoCivil.EstadoCivil1;

                EstadoHabitacional estadoHabitacional = await _repositoryEstadoHabitacional.GetByIdAsync(alumnoEncontrado.EstadoHabit);
                alumnoModels.EstadoHabitacional = estadoHabitacional.EstadoHabitacional1;

                SituacionLaboral situacionLaboral = await _repositorySituacionLaboral.GetByIdAsync(alumnoEncontrado.SituacLab);
                alumnoModels.SituacionLaboral = situacionLaboral.SituacionLab;

                Genero genero = await _repositoryGenero.GetByIdAsync(alumnoEncontrado.Genero);
                alumnoModels.Genero = genero.Genero1;

                return alumnoModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<InfoAlumnoModels>> GetAlumnoInfoAsync(int legajo)
        {
            try
            {
                Data.Data.Alumno alumnoEncontrado = await _repositoryAlumno.GetByIdAsync(legajo);

                if (!alumnoValidation.Validate(alumnoEncontrado))
                {
                    throw new Exception("Alumno Invalido");
                }

                List<InfoAlumnoModels> infoAlumnoModels = await _carreraServiceRepository.GetCarreraInfoUserAsync(alumnoEncontrado.Legajo);

                if (infoAlumnoModels == null)
                {
                    throw new Exception("Informacion del alumno invalida");
                }

                return infoAlumnoModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<InfoAlumnoNotasModls>> GetAlumnoInfoNotaAsync(int legajo)
        {
            try
            {
                Data.Data.Alumno alumnoEncontrado = await _repositoryAlumno.GetByIdAsync(legajo);

                if (!alumnoValidation.Validate(alumnoEncontrado))
                {
                    throw new Exception("Alumno Invalido");
                }

                List<InfoAlumnoNotasModls> infoAlumnoModels = await _carreraServiceRepository.GetCarreraInfoNotaUserAsync(alumnoEncontrado.Legajo);

                if (infoAlumnoModels == null)
                {
                    throw new Exception("Informacion del alumno invalida");
                }

                return infoAlumnoModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<Data.Data.Alumno>> GetAlumnosAsync()
        {
            return (List<Data.Data.Alumno>)await _repositoryAlumno.GetAllAsync();
        }

        public async Task InscribirAlumnoEnExamenFinalAsync(int legajo, string nombreMateria, DateTime fechaInscripcion)
        {
            var alumnoInscripto = await _repositoryAlumno.GetByIdAsync(legajo);
            if (alumnoInscripto == null)
            {
                throw new Exception("El alumno no existe.");
            }

            var listMaterias = await _repositoryMateria.GetAllAsync();
            Materia materia = listMaterias.FirstOrDefault(materia => materia.Materia1 == nombreMateria);

            if (materia == null)
            {
                throw new Exception("No se encontro la materia");
            }

            var ListinscripcionACursado = await _repositoryIncripcionCursado.GetAllAsync();
            InscripcionACursado inscripcionACursado = ListinscripcionACursado.FirstOrDefault(x => x.Alumno == legajo);

            if (inscripcionACursado == null)
            {
                throw new Exception("El alumno no tiene inscripcionACursado.");
            }

            var Listmateriasxcarrera = await _repositoryMateriasxcarrera.GetAllAsync();
            Materiasxcarrera materiasxcarrera = Listmateriasxcarrera.FirstOrDefault(x => x.Materia == materia.Id && x.Carrera == 1);

            if (materiasxcarrera == null)
            {
                throw new Exception("El alumno no tiene materiasxcarrera.");
            }

            var ListMateriaXCursado = await _repositoryMateriasCursado.GetAllAsync();
            MateriasXCursado materiasXCursado = ListMateriaXCursado.FirstOrDefault(x => x.Materiaxcarrera == materiasxcarrera.Id && x.InscripCursado == inscripcionACursado.Id);

            if (materiasXCursado == null)
            {
                throw new Exception("El alumno no tiene materiasXCursado.");
            }

            var ListCursadas = await _repositoryCursada.GetAllAsync();
            Cursada cursada = ListCursadas.FirstOrDefault(x => x.MateriaCursada == materiasXCursado.Id);

            if (cursada == null)
            {
                throw new Exception("El alumno no tiene cursada.");
            }

            var inscripcionExamen = new InscripcionExamenesFinal
            {
                Fecha = DateOnly.FromDateTime(fechaInscripcion),
                Hora = TimeOnly.FromDateTime(DateTime.Now),
                Cursada = cursada.Id,
                CursadaNavigation = cursada,
                Codigo = legajo + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString()
            };

            try
            {
                await _repositoryInscripcionExamenFinal.InsertAsync(inscripcionExamen);
                await _repositoryInscripcionExamenFinal.SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al guardar en la base de datos: {ex.InnerException?.Message}");
            }
        }

        public async Task<List<InscripcionExamenFinalModels>> GetExamenFinal(int legajo)
        {
            try
            {
                List<InscripcionExamenFinalModels> ListinscripcionExamenFinalModels = new List<InscripcionExamenFinalModels>();

                var ListInscripcionExamenesFinal = await _repositoryInscripcionExamenFinal.GetAllAsync();

                foreach (InscripcionExamenesFinal inscripcionExamenesFinal in ListInscripcionExamenesFinal)
                {
                    InscripcionExamenFinalModels inscripcionExamenFinalModels1 = new InscripcionExamenFinalModels();

                    Cursada cursada = await _repositoryCursada.GetByIdAsync(inscripcionExamenesFinal.Cursada);

                    MateriasXCursado materiasXCursado = await _repositoryMateriasCursado.GetByIdAsync(cursada.MateriaCursada);

                    InscripcionACursado inscripcionACursado = await _repositoryIncripcionCursado.GetByIdAsync(materiasXCursado.InscripCursado);

                    if (inscripcionACursado.Alumno != legajo)
                        continue;

                    Materiasxcarrera materiasxcarrera = await _repositoryMateriasxcarrera.GetByIdAsync(materiasXCursado.Materiaxcarrera);

                    Materia materia = await _repositoryMateria.GetByIdAsync(materiasxcarrera.Materia);

                    inscripcionExamenFinalModels1.Legajo = legajo;
                    inscripcionExamenFinalModels1.NombreMateria = materia.Materia1;
                    inscripcionExamenFinalModels1.Fecha = inscripcionExamenesFinal.Fecha;

                    ListinscripcionExamenFinalModels.Add(inscripcionExamenFinalModels1);
                }


                return ListinscripcionExamenFinalModels;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
