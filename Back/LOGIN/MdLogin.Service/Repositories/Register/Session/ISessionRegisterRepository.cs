using MdLogin.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.Repositories.Register.Session
{
    public interface ISessionRegisterRepository
    {
        Data.Data.Sesion InitialSession(int UsuarioId, DateTime FinishDate, string Token);
        bool ValidateSessionUser(int userId, out Data.Data.Sesion sesion);
        bool ValidateSessionUserAndToken(int userId, string token);
        bool LogoutSession(Data.Data.Sesion sesion);
    }
}
