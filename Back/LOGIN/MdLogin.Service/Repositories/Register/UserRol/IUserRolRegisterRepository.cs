using MdLogin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.Repositories.Register.UserRol
{
    public interface IUserRolRegisterRepository
    {
        string NameRolById(int userId);
        bool AddRolUsuario(int idUser, int idRol);
    }
}
