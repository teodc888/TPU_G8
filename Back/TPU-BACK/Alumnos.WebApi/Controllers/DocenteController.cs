using Alumnos.Model.Models;
using Alumnos.Service.Repositories.Docente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alumnos.WebApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [ExternalTokenValidationAttribute]
    public class DocenteController : ControllerBase
    {

        private readonly IDocenteServiceRepository _docenteServiceRepository;

        public DocenteController(IDocenteServiceRepository docenteServiceRepository)
        {
            _docenteServiceRepository = docenteServiceRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetDocente([FromQuery] int legajo)
        {
            try
            {
                var docente = await _docenteServiceRepository.GetDocente(legajo);

                return Ok(docente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetInfoDocente([FromQuery] int legajo)
        {
            try
            {
                var docente = await _docenteServiceRepository.GetInfoDocente(legajo);

                return Ok(docente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet("tribunal")]
        public async Task<IActionResult> GetDocenteXTribunal([FromQuery] int legajo)
        {
            try
            {
                var docente = await _docenteServiceRepository.GetTribunalDocente(legajo);

                return Ok(docente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet("materia")]
        public async Task<IActionResult> GetDocenteXMateria([FromQuery] int legajo)
        {
            try
            {
                var docente = await _docenteServiceRepository.GetMateriaDocente(legajo);

                return Ok(docente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet("materia/only")]
        public async Task<IActionResult> GetDocenteXMateriaOnly([FromQuery] int legajo)
        {
            try
            {
                var docente = await _docenteServiceRepository.GetMateriaDocenteOnly(legajo);

                return Ok(docente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet("info/materiasAndAlumnos")]
        public async Task<IActionResult> GetMateriaAlumnos()
        {
            try
            {
                var response = await _docenteServiceRepository.GetAlumnosMateria();

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpPut("materia/editar")]
        public async Task<IActionResult> editNotaMateria([FromQuery] EditarNotaModels editarNotaModels)
        {
            try
            {
                var docente = await _docenteServiceRepository.EditarMateria(editarNotaModels.Legajo, editarNotaModels.Nota, editarNotaModels.Materia);

                return Ok(docente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpPost("alumno/materia")]
        public async Task<IActionResult> insertAlumnoMateria([FromQuery] InsertAlumnoMateria editarNotaModels)
        {
            try
            {
                var docente = await _docenteServiceRepository.InsertAlumoMateria(editarNotaModels);

                return Ok("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
