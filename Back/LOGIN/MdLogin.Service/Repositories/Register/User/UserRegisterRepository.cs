using MdLogin.Data.Data;
using MdLogin.Data.Repositories.Usuario;
using MdLogin.Model.Models;
using MdLogin.Model.Validate;
using MdLogin.Service.External.JWT;
using MdLogin.Service.Repositories.Register.UserRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.Repositories.Register.User
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUserRolRegisterRepository _userRolRegisterRepository;
        private PasswordService PasswordService;
        private UserValidate UserValidate;
        public UserRegisterRepository(IUsuarioRepository usuarioRepository, IUserRolRegisterRepository userRolRegisterRepository) {
            _usuarioRepository = usuarioRepository;
            _userRolRegisterRepository = userRolRegisterRepository;
            PasswordService = new PasswordService();
        }

        public ResponseModel CreateUser(UserModel usuario)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                UserValidate = new UserValidate(usuario.UserName, usuario.Password, usuario.Email);
                if (!UserValidate.ValidateUser())
                {
                    throw new Exception("Error al cargar un usuario");
                }

                Usuario newUsuario = new Usuario();
                newUsuario.NombreUsuario = usuario.UserName;
                newUsuario.Email = usuario.Email;
                newUsuario.FechaCreacion = DateTime.Now;
                newUsuario.Estado = true;
                newUsuario.CompaniaId = usuario.Compania;

                string salt = String.Empty;
                newUsuario.PasswordHash = PasswordService.HashPassword(usuario.Password, out salt);
                newUsuario.PasswordSalt = salt;

                int? resultCreateUser =  _usuarioRepository.CreateUser(newUsuario);

                if (resultCreateUser == 0) {
                    throw new Exception("Ocurrio un error al querer ingresar un usuario");
                }

                bool resultCreateUserRol = _userRolRegisterRepository.AddRolUsuario((int)resultCreateUser, usuario.Rol);

                if (!resultCreateUserRol)
                {
                    throw new Exception("Ocurrio un error al querer ingresar un usuario");
                }

                responseModel.Result = true;
                responseModel.Response = resultCreateUserRol;
            }
            catch (Exception ex) {
                responseModel.Error = ex.ToString();
                responseModel.Error = ex.ToString();
                throw new Exception(ex.ToString());
            }

            return responseModel;
        }

        public ResponseModel GetAll()
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                List<Usuario> lstUser = _usuarioRepository.GetAllUsuarios();
                
                if(lstUser.Count < 0)
                {
                    throw new Exception("No hay usuarios");
                }

                responseModel.Result = true;
                responseModel.Response = lstUser;
            }
            catch (Exception ex) { 
                responseModel.Error = ex.ToString();
                responseModel.Result = false;
                throw new Exception(ex.ToString());
            }

            return responseModel;
        }

        public Usuario GetUser(LoginModel loginModel)
        {
            try
            {
                Usuario usuario = _usuarioRepository.GetUsuario(loginModel.UserName);

                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                if(!PasswordService.VerifyPassword(loginModel.Password, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new Exception("Contraseña Incorrecta");
                }

                return usuario;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
