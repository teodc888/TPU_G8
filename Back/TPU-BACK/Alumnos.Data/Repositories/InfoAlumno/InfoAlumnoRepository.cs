using Alumnos.Data.Data;
using Alumnos.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Data.Repositories.Carrera
{
    public class InfoAlumnoRepository : IInfoAlumnoRepository
    {
        private readonly TpiDatosContext _context;

        public InfoAlumnoRepository(TpiDatosContext context)
        {
            _context = context;
        }

        public async Task<List<InfoAlumnoModels>> GetCarreraInfoUserAsync(int legajo)
        {
            try
            {
                var result = await (from a in _context.Alumnos
                                    join iac in _context.InscripcionACursados on a.Legajo equals iac.Alumno
                                    join mxc in _context.MateriasXCursados on iac.Id equals mxc.InscripCursado
                                    join mx in _context.Materiasxcarreras on mxc.Materiaxcarrera equals mx.Id
                                    join m in _context.Materias on mx.Materia equals m.Id
                                    join c in _context.Carreras on mx.Carrera equals c.Id
                                    join tm in _context.TiposMaterias on m.TipoMateria equals tm.Id
                                    where a.Legajo == legajo
                                    select new InfoAlumnoModels
                                    {
                                        Legajo = a.Legajo,
                                        Carrera = c.Carrera1, 
                                        Materia = m.Materia1, 
                                        TipoMateria = tm.TipoMateria, 
                                        FechaInscripcionCursado = iac.Fecha.ToString("dd/MM/yyyy"),
                                        FechaInscripcionMateria = iac.Fecha.ToString("dd/MM/yyyy")
                                    }).Distinct().ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Carrera Info: " + ex.Message);
            }
        }



        public async Task<List<InfoAlumnoNotasModls>> GetCarreraNotasInfoAsync(int legajo)
        {
            try
            {
                var result = await (from c in _context.Cursadas
                                    join cu in _context.Cursos on c.Curso equals cu.Id
                                    join es in _context.EstadosMaterias on c.EstadoMateria equals es.Id 
                                    join mxc in _context.MateriasXCursados on c.MateriaCursada equals mxc.Id
                                    join mxca in _context.Materiasxcarreras on mxc.Materiaxcarrera equals mxca.Id 
                                    join mat in _context.Materias on mxca.Materia equals mat.Id 
                                    join exc in _context.ExamenesXCursada on c.Id equals exc.Cursada 
                                    join e in _context.Examenes on exc.Examen equals e.Id 
                                    join esx in _context.EstadosExamenes on e.EstadoExamen equals esx.Id 
                                    join iac in _context.InscripcionACursados on mxc.InscripCursado equals iac.Id 
                                    join a in _context.Alumnos on iac.Alumno equals a.Legajo 
                                    where a.Legajo == legajo
                                    select new InfoAlumnoNotasModls
                                    {
                                        Legajo = a.Legajo,
                                        Curso = cu.Curso1,
                                        Estado = es.EstadoMateria,
                                        Materia = mat.Materia1,
                                        Nota = e.Nota.ToString(), 
                                        FechaCursado = c.Fecha
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Carrera Notas Info: " + ex.Message);
            }
        }


    }
}
