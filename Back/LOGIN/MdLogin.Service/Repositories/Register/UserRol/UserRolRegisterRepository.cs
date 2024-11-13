using MdLogin.Data.Data;
using MdLogin.Data.Repositories.Rol;
using MdLogin.Data.Repositories.UsuarioRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.Repositories.Register.UserRol
{
    public class UserRolRegisterRepository : IUserRolRegisterRepository
    {
        private readonly IUsuarioRolRepository _usuarioRolRepository;
        private readonly IRolRepository _rolRepository;
        public UserRolRegisterRepository(IUsuarioRolRepository usuarioRolRepository, IRolRepository rolRepository) { 
            _usuarioRolRepository = usuarioRolRepository;
            _rolRepository = rolRepository;
        }

        public bool AddRolUsuario(int idUser, int idRol)
        {
            try
            {
                UsuarioRol usuarioRol = new UsuarioRol();
                usuarioRol.UsuarioId = idUser;
                usuarioRol.RolId = idRol;

                bool result = _usuarioRolRepository.Add(usuarioRol);

                if (!result) {
                    throw new Exception("Ocurrio un error al querer agregar el usuario");
                }

                return true;
            }
            catch (Exception ex) { 
                throw new Exception(ex.ToString());
            }
        }

        public string NameRolById(int userId)
        {
            try
            {
                var userRol = _usuarioRolRepository.GetByUserId(userId);

                if (userRol == null)
                {
                    throw new Exception("No se encontro el Usuariorol");
                }

                var rol = _rolRepository.GetById(userRol.RolId);

                if (rol == null)
                {
                    throw new Exception("No se encontro el rol");
                }


                return rol.NombreRol;
            }
            catch (Exception ex) {
                throw new Exception(ex.ToString());
            }
        }
    }
}
