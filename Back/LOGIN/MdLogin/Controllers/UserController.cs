using MdLogin.Model.Models;
using MdLogin.Service.Repositories.Register.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MdLogin.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRegisterRepository _userRegisterRepository;
        public UserController(IUserRegisterRepository userRegisterRepository) {
            _userRegisterRepository = userRegisterRepository;
        }

        [HttpPost("v1/[controller]")]
        public IActionResult Create([FromBody] UserModel user)
        {
            try
            {
                ResponseModel result = _userRegisterRepository.CreateUser(user);

                if (!result.Result)
                {
                    return StatusCode(400, "Error al crear el usuario");
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("v1/[controller]")]
        public IActionResult get()
        {
            try
            {
                ResponseModel result = _userRegisterRepository.GetAll();

                if (!result.Result)
                {
                    return StatusCode(400, "Error al crear el usuario");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
