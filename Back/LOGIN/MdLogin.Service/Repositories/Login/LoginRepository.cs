using MdLogin.Data.Data;
using MdLogin.Model.Const;
using MdLogin.Model.Models;
using MdLogin.Model.Validate;
using MdLogin.Service.External.JWT;
using MdLogin.Service.Repositories.Register.Company;
using MdLogin.Service.Repositories.Register.LogActividad;
using MdLogin.Service.Repositories.Register.Session;
using MdLogin.Service.Repositories.Register.User;
using MdLogin.Service.Repositories.Register.UserRol;


namespace MdLogin.Service.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IUserRegisterRepository _usuarioRepository;
        private readonly ISessionRegisterRepository _sessionRepository;
        private readonly ILogActividadRegisterRepository _LogActividadRegisterRepository;
        private readonly IUserRolRegisterRepository _userRolRegisterRepository;
        private readonly ICompanyRegisterRepository _companyRegisterRepository;
        private readonly LoginValidate loginValidate;
        private readonly LogoutValidate logoutValidate;
        private readonly ValidateValidate validateValidate;
        private readonly JwtServices jwtServices;
        public LoginRepository(IUserRegisterRepository usuarioRepository, ISessionRegisterRepository sessionRepository, ILogActividadRegisterRepository logActividadRegisterRepository, IUserRolRegisterRepository userRolRegisterRepository, ICompanyRegisterRepository companyRegisterRepository)
        {
            _usuarioRepository = usuarioRepository;
            _sessionRepository = sessionRepository;
            _LogActividadRegisterRepository = logActividadRegisterRepository;
            _userRolRegisterRepository = userRolRegisterRepository;
            _companyRegisterRepository = companyRegisterRepository;
            loginValidate = new LoginValidate();
            logoutValidate = new LogoutValidate();
            jwtServices = new JwtServices();
            validateValidate = new ValidateValidate();
        }

        public ResponseModel Login(LoginModel login)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (!loginValidate.Validate(login))
                {
                    throw new Exception("Error en el body del login");
                }

                var User = _usuarioRepository.GetUser(login);

                Sesion sesion = new Sesion();

                if (!_sessionRepository.ValidateSessionUser(User.UsuarioId, out sesion))
                {
                    TokenModel tokenModel = jwtServices.CreateToken(login);

                    sesion = _sessionRepository.InitialSession(User.UsuarioId, tokenModel.Expiration, tokenModel.Token);
                }

                responseModel.UserName = User.NombreUsuario;
                responseModel.Rol = _userRolRegisterRepository.NameRolById(User.UsuarioId);
                responseModel.UrlDestino = _companyRegisterRepository.getByUrlCompany(User.CompaniaId);
                _LogActividadRegisterRepository.AddLogActivity(User.UsuarioId, TypeActivityConst.Login, "Logeo de un usuario");
                responseModel.Response = sesion;
                responseModel.Result = true;
                
            }
            catch (Exception ex)
            {
                responseModel.Result = false;
                responseModel.Error = ex.Message;
                throw new Exception(ex.ToString());
            }

            return responseModel;
        }
        public ResponseModel Logout(LogoutModel logout)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (!logoutValidate.Validate(logout))
                {
                    throw new Exception("Body invalido");
                }

                Sesion sesion = new Sesion();
                if (!_sessionRepository.ValidateSessionUser(logout.UsuarioId, out sesion))
                {
                    throw new Exception("Usuario No logeado");
                }

                sesion.EstadoSesion = false;
                sesion.FechaFin = DateTime.Now;

                bool result = _sessionRepository.LogoutSession(sesion);

                responseModel.Response = sesion;
                responseModel.Result = true;


            }
            catch (Exception ex)
            {
                responseModel.Error = ex.ToString();
                responseModel.Result = false;
                throw new Exception(ex.ToString());
            }

            return responseModel;
        }

        public ResponseModel Validate(ValidateModel validate)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (!validateValidate.validate(validate))
                {
                    throw new Exception("Body invalido");
                }

                if (!_sessionRepository.ValidateSessionUserAndToken(validate.UsuarioId, validate.TokenSesion))
                {
                    responseModel.Response = "false";
                    responseModel.Result = true;
                }
                else
                {
                    responseModel.Response = "true";
                    responseModel.Result = true;
                }
            }
            catch (Exception ex) {
                responseModel.Error = "No existe una sesion creada para este usuario";
                responseModel.Result = false;
                throw new Exception(ex.ToString());
            }

            return responseModel;
        }
    }
}
