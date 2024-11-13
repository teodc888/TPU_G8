using Alumnos.Model.Models;
using Alumnos.Service.Repositories.Alumno;
using Microsoft.AspNetCore.Mvc;

namespace Alumnos.WebApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [ExternalTokenValidationAttribute]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoServiceRepository _repository;

        public AlumnoController(IAlumnoServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlumno([FromQuery] int legajo)
        {
            try
            {
                var alumno = await _repository.GetAlumnoNombreAsync(legajo);
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetAlumnoInfo([FromQuery] int legajo)
        {
            try
            {
                var alumnoInfo = await _repository.GetAlumnoInfoAsync(legajo);
                return Ok(alumnoInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("info/notas")]
        public async Task<IActionResult> GetAlumnosInfoNota([FromQuery] int legajo)
        {
            try
            {
                var alumnoInfo = await _repository.GetAlumnoInfoNotaAsync(legajo);
                return Ok(alumnoInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("examen/final")]
        public async Task<IActionResult> GetInscripcionExamenFinal([FromQuery] int legajo)
        {
            try
            {
                var response = await _repository.GetExamenFinal(legajo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al inscribir al alumno: {ex.Message}");
            }
        }

        [HttpPost("inscribir")]
        public async Task<IActionResult> InscribirAlumnoEnExamenFinal([FromBody] InscripcionRequestModels request)
        {
            try
            {
                await _repository.InscribirAlumnoEnExamenFinalAsync(request.Legajo, request.NombreMateria, request.FechaInscripcion);
                return Ok("Inscripción exitosa.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al inscribir al alumno: {ex.Message}");
            }
        }
    }
}

