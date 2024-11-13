using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.UsuarioRol
{
    public interface IUsuarioRolRepository
    {
        List<Data.UsuarioRol> GetAll();
        Data.UsuarioRol GetByUserId(int id);
        bool Add(Data.UsuarioRol usuarioRol);
        void Update(Data.UsuarioRol usuarioRol);
        void Delete(int id);
    }
}
