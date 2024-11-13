using MdLogin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly MdLoginContext _contenx;
        public UsuarioRepository(MdLoginContext context) { 
            _contenx = context;
        }

        public int? CreateUser(Data.Usuario user)
        {
            _contenx.Usuarios.Add(user);
            var changes = _contenx.SaveChanges();

            return changes > 0 ? user.UsuarioId : (int?)null;
        }

        public bool DeleteUser(Data.Usuario user)
        {
            user.Estado = false;
            return _contenx.SaveChanges() > 0;
        }

        public List<Data.Usuario> GetAllUsuarios()
        {
            return _contenx.Usuarios.ToList();
        }

        public Data.Usuario GetUsuario(string user)
        {
            var userName = _contenx.Usuarios.Where(x => x.NombreUsuario == user).FirstOrDefault();
           
            if(userName == null)
            {
                var userEmail = _contenx.Usuarios.Where( x => x.Email == user).FirstOrDefault();
                return userEmail;
            }

            return userName;
        }

        public bool UpdateUser(Data.Usuario user)
        {
            _contenx.Usuarios.Update(user);
            return _contenx.SaveChanges() > 0 ;
        }
    }
}
