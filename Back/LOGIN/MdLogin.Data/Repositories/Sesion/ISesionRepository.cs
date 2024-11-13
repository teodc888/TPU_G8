using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Sesion
{
    public interface ISesionRepository
    {
        List<Data.Sesion> GetAll();
        Data.Sesion GetById(int id);
        bool Add(Data.Sesion sesion);
        bool Update(Data.Sesion sesion);
        bool Delete(int id);
        Data.Sesion GetByTokenAndUser(string tokenSesion, int userId);
        Data.Sesion GetByUser(int userId);
    }
}
