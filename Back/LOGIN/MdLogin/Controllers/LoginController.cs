using MdLogin.Model.Models;
using MdLogin.Service.Repositories.Login;
using Microsoft.AspNetCore.Mvc;

namespace MdLogin.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository) { 
            _loginRepository = loginRepository;
        }

        [HttpPost("v1/[controller]/Login")]
        public IActionResult Login([FromBody] LoginModel loginModel) {
            try
            {
                ResponseModel response = _loginRepository.Login(loginModel);

                if (!response.Result) {
                    return StatusCode(400, "Error al querer iniciar la session");
                }

                return Ok(response);
            }
            catch (Exception ex) { 
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("v1/[controller]/logout")]
        public IActionResult logout([FromBody] LogoutModel logoutModel)
        {
            try
            {
                ResponseModel response = _loginRepository.Logout(logoutModel);

                if (response == null)
                {
                    return StatusCode(400, "Error al querer iniciar la session");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("v1/[controller]/Validate")]
        public IActionResult Validate([FromBody] ValidateModel validate)
        {
            try
            {
                ResponseModel response = _loginRepository.Validate(validate);

                if (response == null)
                {
                    return StatusCode(400, "Error al querer iniciar la session");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
