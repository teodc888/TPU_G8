using Alumnos.Data.Data;
using Alumnos.Data.Repositories.Class;
using Alumnos.Data.Repositories.GenericRepository;
using Alumnos.Data.Repositories.InfoDocente;
using Alumnos.Model;
using Alumnos.Model.Models;
using Alumnos.Service.Repositories.Alumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Service.Repositories.Docente
{
    public class DocenteServiceRepository : IDocenteServiceRepository
    {
        private readonly IGenericRepository<Data.Data.Docente> _repositoryDocente;
        private readonly IGenericRepository<TiposDoc> _repositoryTipoDoc;
        private readonly IGenericRepository<Localidade> _repositoryLocalidate;
        private readonly IGenericRepository<EstadoCivil> _repositoryEstadoCivil;
        private readonly IGenericRepository<EstadoHabitacional> _repositoryEstadoHabitacional;
        private readonly IGenericRepository<SituacionLaboral> _repositorySituacionLaboral;
        private readonly IGenericRepository<Genero> _repositoryGenero;
        private readonly IGenericRepository<Tribunale> _repositoryTribunal;
        private readonly IGenericRepository<Materia> _repositoryMateria;
        private readonly IGenericRepository<Data.Data.Carrera> _repositoryCarrera;
        private readonly IGenericRepository<Data.Data.Alumno> _repositoryAlumno;
        private readonly IGenericRepository<InscripcionACursado> _repositoryInscripcionACursado;
        private readonly IGenericRepository<MateriasXCursado> _repositoryMateriasXCursado;
        private readonly IGenericRepository<Cursada> _repositoryCursada;
        private readonly IGenericRepository<ExamenesXCursadum> _repositoryExamenesXCursadum;
        private readonly IGenericRepository<Examene> _repositoryExamene;
        private readonly IGenericRepository<EstadosExamene> _repositoryEstadosExamene;
        private readonly IGenericRepository<InscripcionACarrera> _repositoryInscripcionACarrera;
        private readonly IGenericRepository<Materiasxcarrera> _repositoryMateriasxcarrera;
        private readonly IInfoDocenteRepository _infoDocenteRepository;
        private readonly IAlumnoServiceRepository _alumnoServiceRepository;
        private readonly DocenteXTribunalesRepository _docenteXTribunalesRepository;
        private readonly MateriasxcarreraRepository _materiasxcarreraRepository;
        private readonly InscripcionACarreraRepository _inscripcionACarreraRepository;
        public DocenteServiceRepository(
            IGenericRepository<Data.Data.Docente> repositoryDocente,
            IGenericRepository<Localidade> repositoryLocalidate,
            IGenericRepository<EstadoCivil> repositoryEstadoCivil,
            IGenericRepository<EstadoHabitacional> repositoryEstadoHabitacional,
            IGenericRepository<SituacionLaboral> repositorySituacionLaboral,
            IGenericRepository<Genero> repositoryGenero,
            IGenericRepository<TiposDoc> repositoryTipoDoc,
            IGenericRepository<Tribunale> repositoryTribunal,
            IGenericRepository<Materia> repositoryMateria,
            IGenericRepository<Data.Data.Carrera> repositoryCarrera,
            IGenericRepository<Data.Data.Alumno> repositoryAlumno,
            IGenericRepository<InscripcionACursado> inscripcionACursado,
            IGenericRepository<MateriasXCursado> repositoryMateriasXCursado,
            IGenericRepository<Cursada> repositoryCursada,
            IGenericRepository<ExamenesXCursadum> repositoryExamenesXCursadum,
            IGenericRepository<Examene> repositoryExamene,
            IGenericRepository<EstadosExamene> repositoryEstadosExamene,
            IGenericRepository<InscripcionACarrera> repositoryInscripcionACarrera,
            IGenericRepository<Materiasxcarrera> repositoryMateriasxcarrera,
            IInfoDocenteRepository infoDocenteRepository,
            IAlumnoServiceRepository alumnoServiceRepository,
            DocenteXTribunalesRepository docenteXTribunalesRepository,
            MateriasxcarreraRepository materiasxcarreraRepository,
            InscripcionACarreraRepository inscripcionACarreraRepository)
        {
            _repositoryDocente = repositoryDocente;
            _repositoryLocalidate = repositoryLocalidate;
            _repositoryEstadoCivil = repositoryEstadoCivil;
            _repositoryEstadoHabitacional = repositoryEstadoHabitacional;
            _repositorySituacionLaboral = repositorySituacionLaboral;
            _repositoryGenero = repositoryGenero;
            _repositoryTipoDoc = repositoryTipoDoc;
            _repositoryTribunal = repositoryTribunal;
            _repositoryMateria = repositoryMateria;
            _repositoryCarrera = repositoryCarrera;
            _infoDocenteRepository = infoDocenteRepository;
            _docenteXTribunalesRepository = docenteXTribunalesRepository;
            _materiasxcarreraRepository = materiasxcarreraRepository;
            _inscripcionACarreraRepository = inscripcionACarreraRepository;
            _alumnoServiceRepository = alumnoServiceRepository;
            _repositoryAlumno = repositoryAlumno;
            _repositoryInscripcionACursado = inscripcionACursado;
            _repositoryMateriasXCursado = repositoryMateriasXCursado;
            _repositoryCursada = repositoryCursada;
            _repositoryExamenesXCursadum = repositoryExamenesXCursadum;
            _repositoryExamene = repositoryExamene;
            _repositoryEstadosExamene = repositoryEstadosExamene;
            _repositoryInscripcionACarrera = repositoryInscripcionACarrera;
            _repositoryMateriasxcarrera = repositoryMateriasxcarrera;
        }
        public async Task<DocenteModels> GetDocente(int legajo)
        {
            try
            {
                DocenteModels docenteModels = new DocenteModels();
                Data.Data.Docente docenteEncontrado = await _repositoryDocente.GetByIdAsync(legajo);

                if (docenteEncontrado == null)
                {
                    throw new Exception("Docente no encontrado");
                }

                docenteModels.Legajo = docenteEncontrado.Legajo;
                docenteModels.Nombre = docenteEncontrado.Nombre;
                docenteModels.Apellido = docenteEncontrado.Apellido;
                docenteModels.NumeroDocumento = docenteEncontrado.NroDoc;
                docenteModels.Direccion = docenteEncontrado.Direccion;
                docenteModels.FechaNacimiento = ((DateTime)docenteEncontrado.FechaNac).ToString("dd/MM/yyyy");
                docenteModels.TituloUniversitario = docenteEncontrado.TituloUniversitario;

                TiposDoc tiposDoc = await _repositoryTipoDoc.GetByIdAsync(docenteEncontrado.TipoDoc);
                docenteModels.TipoDocumento = tiposDoc.TipoDoc;

                Localidade localidad = await _repositoryLocalidate.GetByIdAsync(docenteEncontrado.Localidad);
                docenteModels.Localidad = localidad.Nombre;

                EstadoCivil estadoCivil = await _repositoryEstadoCivil.GetByIdAsync(docenteEncontrado.EstadoCivil);
                docenteModels.EstadoCivil = estadoCivil.EstadoCivil1;

                EstadoHabitacional estadoHabitacional = await _repositoryEstadoHabitacional.GetByIdAsync(docenteEncontrado.EstadoHabit);
                docenteModels.EstadoHabitacional = estadoHabitacional.EstadoHabitacional1;

                SituacionLaboral situacionLaboral = await _repositorySituacionLaboral.GetByIdAsync(docenteEncontrado.SituacLab);
                docenteModels.SituacionLaboral = situacionLaboral.SituacionLab;

                Genero genero = await _repositoryGenero.GetByIdAsync(docenteEncontrado.Genero);
                docenteModels.Genero = genero.Genero1;

                return docenteModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<InfoDocenteModels> GetInfoDocente(int legajo)
        {
            try
            {
                InfoDocenteModels infoDocente = new InfoDocenteModels();

                DocenteTotalAlumnosModel totalAlumnosModel = await _infoDocenteRepository.GetTotalAlumnosPorDocenteAsync(legajo);
                DocentePromedioNotasModel docentePromedioNotas = await _infoDocenteRepository.GetDocentePromedioNotasAsync(legajo);
                DocenteTotalMateriasModel docenteTotalMaterias = await _infoDocenteRepository.GetTotalMateriasPorDocenteAsync(legajo);
                DocenteAlumnosRiesgo docenteAlumnosRiesgo = await _infoDocenteRepository.GetAlumnosRiesgo(legajo);
                List<DocenteEstadoAlumnos> docenteEstadoAlumnos = await _infoDocenteRepository.GetDocenteEstadoAlumnos(legajo);
                List<DocenteDistriEdad> docenteDistriEdads = await _infoDocenteRepository.GetDocenteDistriEdad(legajo);
                DocenteMateriasPromedioModel docenteMateriasPromedioModels = await _infoDocenteRepository.GetMejorYPeorPromedioMateriasPorDocenteAsync(legajo);

                infoDocente.AlumnosTotales = totalAlumnosModel?.TotalAlumnos == null ? 0 : totalAlumnosModel.TotalAlumnos;
                infoDocente.PromedioNotas = docentePromedioNotas?.PromedioNotas == null ? 0 : docentePromedioNotas.PromedioNotas;
                infoDocente.MateriaInscriptas = docenteTotalMaterias?.TotalMaterias == null ? 0 : docenteTotalMaterias.TotalMaterias;
                infoDocente.AlumnosEnRiesgo = docenteAlumnosRiesgo?.AlumnosRiesgo == null ? 0 : docenteAlumnosRiesgo.AlumnosRiesgo;
                infoDocente.estadoAlumnos = docenteEstadoAlumnos;
                infoDocente.GetDocenteDistriEdad = docenteDistriEdads;
                infoDocente.DocenteMateriasPromedio = docenteMateriasPromedioModels;

                return infoDocente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<MateriaModels>> GetMateriaDocente(int legajo)
        {
            try
            {   
                var inscripciones = await _infoDocenteRepository.GetInscripcionAlumno(legajo);

                var materias = inscripciones
                    .GroupBy(i => new { i.Materia, i.Carrera, i.Anio })
                    .Select(g => new MateriaModels
                    {
                        Legajo = legajo,
                        Materia = g.Key.Materia,
                        Carrera = g.Key.Carrera,
                        AnioPlan = g.Key.Anio,
                        ListAlumno = g.GroupBy(i => new { i.Alumno, i.Nombre, i.Apellido })
                                      .Select(a => new AlumnoMateriaModels
                                      {
                                          Legajo = a.Key.Alumno,
                                          Nombre = a.Key.Nombre,
                                          Apellido = a.Key.Apellido,
                                          ListNota = a.Select(n => new NotaMateria
                                          {
                                              Materia = g.Key.Materia,
                                              Nota = n.Nota.ToString()
                                          }).ToList()
                                      }).ToList()
                    }).ToList();

                return materias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public async Task<List<MateriaModels>> GetMateriaDocenteOnly(int legajo)
        {
            try
            {
                var inscripciones = await _infoDocenteRepository.GetInscripcion(legajo);

                var materias = inscripciones
                    .GroupBy(i => new { i.Materia, i.Carrera, i.AnioPlan })
                    .Select(g => new MateriaModels
                    {
                        Legajo = legajo,
                        Materia = g.Key.Materia,
                        Carrera = g.Key.Carrera,
                        AnioPlan = g.Key.AnioPlan,
                        ListAlumno = g.GroupBy(i => new { i.Alumno, i.Nombre, i.Apellido })
                                      .Select(a => new AlumnoMateriaModels
                                      {
                                          Legajo = a.Key.Alumno,
                                          Nombre = a.Key.Nombre,
                                          Apellido = a.Key.Apellido,
                                          ListNota = a.Select(n => new NotaMateria
                                          {
                                              Materia = g.Key.Materia             
                                          }).ToList()
                                      }).ToList()
                    }).ToList();

                return materias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> EditarMateria(int legajo, int Nota, string Materia)
        {
            try
            {
                var ListMateria1 = await _repositoryMateria.GetAllAsync();
                Materia materia1 = ListMateria1.First(x => x.Materia1 == Materia);

                if (materia1 == null)
                {
                    throw new Exception("Materia no encontrada");
                }

                Data.Data.Alumno alumno = await _repositoryAlumno.GetByIdAsync(legajo);

                if (alumno == null)
                {
                    throw new Exception("alumno no encontrada");
                }

                var listInscripcionACursado = await _repositoryInscripcionACursado.GetAllAsync();
                InscripcionACursado inscripcionACursado = listInscripcionACursado.FirstOrDefault(x => x.Alumno == alumno.Legajo);

                var Listmateriasxcarrera = await _materiasxcarreraRepository.GetAllAsync();
                List<Materiasxcarrera> materiasxcarrera = Listmateriasxcarrera.Where(x => x.Materia == materia1.Id && x.Carrera == 1).ToList();

                MateriasXCursado materiasXCursado = new MateriasXCursado();

                foreach (Materiasxcarrera materiasxcarrera1 in materiasxcarrera)
                {
                    var ListMateriaXCursado = await _repositoryMateriasXCursado.GetAllAsync();
                    materiasXCursado = ListMateriaXCursado.FirstOrDefault(x => x.Materiaxcarrera == materiasxcarrera1.Id && x.InscripCursado == inscripcionACursado.Id);

                    if(materiasXCursado != null)
                    {
                        break;
                    }
                }

                var ListCursada = await _repositoryCursada.GetAllAsync();
                Cursada cursada = ListCursada.FirstOrDefault(x => x.MateriaCursada == materiasXCursado.Id);

                var ListExamenesXCursadum = await _repositoryExamenesXCursadum.GetAllAsync();
                ExamenesXCursadum examenesXCursadum = ListExamenesXCursadum.FirstOrDefault(x => x.Cursada == cursada.Id);

                Examene examene = await _repositoryExamene.GetByIdAsync(examenesXCursadum.Examen);
                examene.Nota = Nota;

                var ListEstadosExamene = await _repositoryEstadosExamene.GetAllAsync();

                if (Nota < 6)
                {
                    examene.EstadoExamen = ListEstadosExamene.FirstOrDefault(x => x.EstadoExamen == "DESAPROBADO").Id;
                }
                else
                {
                    examene.EstadoExamen = ListEstadosExamene.FirstOrDefault(x => x.EstadoExamen == "APROBADO").Id;
                }

                try
                {
                    await _repositoryExamene.UpdateAsync(examene);
                    await _repositoryExamene.SaveAsync();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                return true;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<TribunalModels>> GetTribunalDocente(int legajo)
        {
            try
            {
                List<TribunalModels> lstTribunales = new List<TribunalModels>();

                List<DocentesXTribunale> lstDocenteXTribunales = await _docenteXTribunalesRepository.GetLegajoTribunal(legajo);

                if (lstDocenteXTribunales.Count == 0)
                {
                    throw new Exception("No se encontraron tribunales");
                }

                foreach (DocentesXTribunale docentesXTribunale in lstDocenteXTribunales)
                {
                    TribunalModels tribunalModels = new TribunalModels();

                    tribunalModels.Legajo = docentesXTribunale.Docente;

                    Tribunale tribunale = await _repositoryTribunal.GetByIdAsync(docentesXTribunale.Tribunal);
                    tribunalModels.Aula = tribunale.Aula;
                    tribunalModels.Fecha = ((DateOnly)tribunale.Fecha).ToString("dd/MM/yyyy");

                    Materia materia = await _repositoryMateria.GetByIdAsync(tribunale.Materia);
                    tribunalModels.Materia = materia.Materia1;

                    lstTribunales.Add(tribunalModels);
                }

                return lstTribunales;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> InsertAlumoMateria(InsertAlumnoMateria insertAlumnoMateria)
        {
            try
            {
                DateTime dateTime = DateTime.Now;

                DateOnly dateOnly = DateOnly.FromDateTime(dateTime);

                Data.Data.Alumno alumno = await _repositoryAlumno.GetByIdAsync(insertAlumnoMateria.LegajoAlumno);

                if (alumno == null)
                {
                    throw new Exception("Alumno no existed");
                }

                Data.Data.Docente docente = await _repositoryDocente.GetByIdAsync(insertAlumnoMateria.LegajoDocente);

                if (docente == null)
                {
                    throw new Exception("Alumno no existed");
                }

                var ListMateria = await _repositoryMateria.GetAllAsync();
                Materia materia = ListMateria.FirstOrDefault(x => x.Materia1 == insertAlumnoMateria.NombreMateria);
                if (materia == null)
                {
                    throw new Exception("Alumno no existed");
                }

                var ListInscripcionACarrera = await _inscripcionACarreraRepository.GetAllAsync();
                InscripcionACarrera inscripcionACarrera = ListInscripcionACarrera.FirstOrDefault(x => x.Alumno == alumno.Legajo);

                InscripcionACursado inscripcionACursado = new InscripcionACursado();
                inscripcionACursado.Fecha = dateOnly;
                inscripcionACursado.Alumno = alumno.Legajo;
                inscripcionACursado.InscripCarrer = inscripcionACarrera.Id;

                int idInscripcionACursado = 0;
                try
                {
                    idInscripcionACursado =  await _repositoryInscripcionACursado.InsertAsyncReturnId(inscripcionACursado);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                Materiasxcarrera materiasxcarrera = new Materiasxcarrera();
                materiasxcarrera.DocenteACargo = docente.Legajo;
                materiasxcarrera.Materia = materia.Id;
                materiasxcarrera.Carrera = 1;

                int idMateriaCarrera = 0;
                try
                {
                    idMateriaCarrera = await _repositoryMateriasxcarrera.InsertAsyncReturnId(materiasxcarrera);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                MateriasXCursado materiasXCursado = new MateriasXCursado();
                materiasXCursado.InscripCursado = idInscripcionACursado;
                materiasXCursado.Materiaxcarrera = idMateriaCarrera;

                int idMateriaXCursado = 0;
                try
                {
                    idMateriaXCursado = await _repositoryMateriasXCursado.InsertAsyncReturnId(materiasXCursado);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<GetAlumnosMateria> GetAlumnosMateria()
        {
            try
            {
                GetAlumnosMateria getAlumnosMateria = new GetAlumnosMateria();
                var alumnos = await _repositoryAlumno.GetAllAsync();
                var materias = await _repositoryMateria.GetAllAsync();

                List<AlumnosGet> Alumnos = new List<AlumnosGet>();
                foreach (Data.Data.Alumno alumno in alumnos)
                {
                    AlumnosGet alumnosGet = new AlumnosGet();
                    alumnosGet.Nombre = alumno.Legajo;

                    Alumnos.Add(alumnosGet);
                }

                List<MateriaGet> Materias = new List<MateriaGet>();
                foreach (Data.Data.Materia materia in materias)
                {
                    MateriaGet materiaGet = new MateriaGet();
                    materiaGet.Nombre = materia.Materia1;

                    Materias.Add(materiaGet);
                }
                getAlumnosMateria.Alumnos = Alumnos;
                getAlumnosMateria.Materias = Materias;

                return getAlumnosMateria;
            }
            catch (Exception ex) {
                throw new Exception(ex.ToString());
            }
        }

    }
}
