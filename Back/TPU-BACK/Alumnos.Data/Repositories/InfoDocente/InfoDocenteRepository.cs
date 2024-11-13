using Alumnos.Data.Data;
using Alumnos.Model;
using Alumnos.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Data.Repositories.InfoDocente
{
    public class InfoDocenteRepository : IInfoDocenteRepository
    {
        private readonly TpiDatosContext _context;

        public InfoDocenteRepository(TpiDatosContext context)
        {
            _context = context;
        }

        public async Task<DocenteAlumnosRiesgo> GetAlumnosRiesgo(int legajo)
        {
            try
            {
                var result = await (from a in _context.Alumnos
                                    join ic in _context.InscripcionACursados on a.Legajo equals ic.Alumno
                                    join mxcurs in _context.MateriasXCursados on ic.Id equals mxcurs.InscripCursado
                                    join mxc in _context.Materiasxcarreras on mxcurs.Materiaxcarrera equals mxc.Id
                                    join d in _context.Docentes on mxc.DocenteACargo equals d.Legajo
                                    join curs in _context.Cursadas on mxcurs.Id equals curs.MateriaCursada
                                    join exc in _context.ExamenesXCursada on curs.Id equals exc.Cursada
                                    join e in _context.Examenes on exc.Examen equals e.Id
                                    where e.Nota < 6 && d.Legajo == 2001 // Cambia el legajo por el parámetro si es necesario
                                    group a by d.Legajo into docenteGroup
                                    select new DocenteAlumnosRiesgo
                                    {
                                        Legajo = docenteGroup.Key,
                                        AlumnosRiesgo = docenteGroup.Count()
                                    }).FirstOrDefaultAsync();


                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving at-risk students for docente: " + ex.Message);
            }
        }

        public async Task<List<DocenteDistriEdad>> GetDocenteDistriEdad(int legajo)
        {
            try
            {
                var result = await (from d in _context.Docentes
                                    join mxc in _context.Materiasxcarreras on d.Legajo equals mxc.DocenteACargo
                                    join maxc in _context.MateriasXCursados on mxc.Id equals maxc.Materiaxcarrera
                                    join ic in _context.InscripcionACursados on maxc.InscripCursado equals ic.Id
                                    join a in _context.Alumnos on ic.Alumno equals a.Legajo
                                    where d.Legajo == legajo
                                    group a by new
                                    {
                                        d.Legajo,
                                        Edad = (DateTime.Now.Year - a.FechaNac.Value.Year)
                                    } into grupo
                                    select new DocenteDistriEdad
                                    {
                                        LegajoDocente = grupo.Key.Legajo,
                                        Edad = grupo.Key.Edad,
                                        CantidadAlumnos = grupo.Count()
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving age distribution: " + ex.Message);
            }
        }

        public async Task<List<DocenteEstadoAlumnos>> GetDocenteEstadoAlumnos(int legajo)
        {
            try
            {
                var resultados = await (from d in _context.Docentes
                                        join mxc in _context.Materiasxcarreras on d.Legajo equals mxc.DocenteACargo
                                        join maxc in _context.MateriasXCursados on mxc.Id equals maxc.Materiaxcarrera
                                        join c in _context.Cursadas on maxc.Id equals c.MateriaCursada
                                        join em in _context.EstadosMaterias on c.EstadoMateria equals em.Id
                                        where d.Legajo == legajo
                                        group em by em.EstadoMateria into grupo
                                        select new DocenteEstadoAlumnos
                                        {
                                            LegajoDocente = legajo,
                                            EstadoMateria = grupo.Key,
                                            Cantidad = grupo.Count() // Contamos cuántos alumnos están en cada estado
                                        }).ToListAsync();

                return resultados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estado de alumnos por docente: " + ex.Message);
            }
        }

        public async Task<DocentePromedioNotasModel> GetDocentePromedioNotasAsync(int docenteId)
        {
            try
            {
                var result = await (from d in _context.Docentes
                                    join mxc in _context.Materiasxcarreras on d.Legajo equals mxc.DocenteACargo
                                    join maxc in _context.MateriasXCursados on mxc.Id equals maxc.Materiaxcarrera
                                    join c in _context.Cursadas on maxc.Id equals c.MateriaCursada
                                    join exc in _context.ExamenesXCursada on c.Id equals exc.Cursada
                                    join e in _context.Examenes on exc.Examen equals e.Id
                                    where d.Legajo == docenteId
                                    group e by d.Legajo into docenteGroup
                                    select new DocentePromedioNotasModel
                                    {
                                        Legajo = docenteGroup.Key,
                                        PromedioNotas = docenteGroup.Average(x => x.Nota)
                                    }).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving average grades for docente: " + ex.Message);
            }
        }

        public async Task<DocenteTotalAlumnosModel> GetTotalAlumnosPorDocenteAsync(int legajo)
        {
            try
            {
                var result = await (from d in _context.Docentes
                                    join mxc in _context.Materiasxcarreras on d.Legajo equals mxc.DocenteACargo
                                    join maxc in _context.MateriasXCursados on mxc.Id equals maxc.Materiaxcarrera
                                    join iac in _context.InscripcionACursados on maxc.InscripCursado equals iac.Id
                                    join a in _context.Alumnos on iac.Alumno equals a.Legajo
                                    where d.Legajo == legajo
                                    group a by d.Legajo into docenteGroup
                                    select new DocenteTotalAlumnosModel
                                    {
                                        Legajo = docenteGroup.Key,
                                        TotalAlumnos = docenteGroup.Count()
                                    }).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving total students for docente: " + ex.Message);
            }
        }

        public async Task<DocenteTotalMateriasModel> GetTotalMateriasPorDocenteAsync(int legajo)
        {
            try
            {
                var result = await (from d in _context.Docentes
                                    join mxc in _context.Materiasxcarreras on d.Legajo equals mxc.DocenteACargo
                                    join m in _context.Materias on mxc.Materia equals m.Id
                                    where d.Legajo == legajo
                                    group m by d.Legajo into docenteGroup
                                    select new DocenteTotalMateriasModel
                                    {
                                        Legajo = docenteGroup.Key,
                                        TotalMaterias = docenteGroup.Count()
                                    }).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving total subjects for docente: " + ex.Message);
            }
        }
        public async Task<DocenteMateriasPromedioModel> GetMejorYPeorPromedioMateriasPorDocenteAsync(int docenteId)
        {
            try
            {
                var promedioMaterias = from d in _context.Docentes
                                       join mxc in _context.Materiasxcarreras on d.Legajo equals mxc.DocenteACargo
                                       join m in _context.Materias on mxc.Materia equals m.Id
                                       join maxc in _context.MateriasXCursados on mxc.Id equals maxc.Materiaxcarrera
                                       join c in _context.Cursadas on maxc.Id equals c.MateriaCursada
                                       join exc in _context.ExamenesXCursada on c.Id equals exc.Cursada
                                       join e in _context.Examenes on exc.Examen equals e.Id
                                       where d.Legajo == docenteId
                                       group e by new { d.Legajo, m.Materia1 } into docenteMateriaGroup
                                       select new MateriaPromedioModel
                                       {
                                           Legajo = docenteMateriaGroup.Key.Legajo,
                                           Materia = docenteMateriaGroup.Key.Materia1,
                                           PromedioNotas = docenteMateriaGroup.Average(x => x.Nota)
                                       };

                var mejoresMaterias = await promedioMaterias
                    .OrderByDescending(x => x.PromedioNotas)
                    .Take(2)
                    .ToListAsync();

                var peoresMaterias = await promedioMaterias
                    .OrderBy(x => x.PromedioNotas)
                    .Take(2)
                    .ToListAsync();

                return new DocenteMateriasPromedioModel
                {
                    Legajo = docenteId,
                    MejoresMaterias = mejoresMaterias,
                    PeoresMaterias = peoresMaterias
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving best and worst average grades for docente: " + ex.Message);
            }
        }

        public async Task<List<GetInscripcionAlumno>> GetInscripcionAlumno(int legajoDocente)
        {
            try
            {
                var result = await (from a in _context.Alumnos
                                    join iac in _context.InscripcionACursados on a.Legajo equals iac.Alumno
                                    join mxc in _context.MateriasXCursados on iac.Id equals mxc.InscripCursado
                                    join mx in _context.Materiasxcarreras on mxc.Materiaxcarrera equals mx.Id
                                    join ca in _context.Carreras on mx.Carrera equals ca.Id
                                    join m in _context.Materias on mx.Materia equals m.Id
                                    join cu in _context.Cursadas on mxc.Id equals cu.MateriaCursada
                                    join exc in _context.ExamenesXCursada on cu.Id equals exc.Cursada
                                    join ex in _context.Examenes on exc.Examen equals ex.Id
                                    where mx.DocenteACargo == legajoDocente
                                    orderby m.Materia1
                                    select new GetInscripcionAlumno
                                    {
                                        Alumno = a.Legajo,
                                        Nombre = a.Nombre,
                                        Apellido = a.Apellido,
                                        Materia = m.Materia1,
                                        Docente = (int)mx.DocenteACargo,
                                        Nota = ex.Nota,
                                        Carrera = ca.Carrera1,
                                        Anio = (int)ca.AnioPlan
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving enrollment data for docente: " + ex.Message);
            }
        }

        public async Task<List<GetInscripcion>> GetInscripcion(int legajoDocente)
        {
            try
            {
                var result = await (from a in _context.Alumnos
                                    join iac in _context.InscripcionACursados on a.Legajo equals iac.Alumno
                                    join mxc in _context.MateriasXCursados on iac.Id equals mxc.InscripCursado
                                    join mx in _context.Materiasxcarreras on mxc.Materiaxcarrera equals mx.Id
                                    join ca in _context.Carreras on mx.Carrera equals ca.Id
                                    join m in _context.Materias on mx.Materia equals m.Id
                                    where mx.DocenteACargo == legajoDocente
                                    orderby m.Materia1
                                    select new GetInscripcion
                                    {
                                        Alumno = a.Legajo,
                                        Nombre = a.Nombre,
                                        Apellido = a.Apellido,
                                        Materia = m.Materia1,
                                        Docente = (int)mx.DocenteACargo,
                                        Carrera = ca.Carrera1,
                                        AnioPlan = (int)ca.AnioPlan 
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving enrollment data: " + ex.Message);
            }
        }






    }
}
