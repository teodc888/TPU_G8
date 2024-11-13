using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.RolPermiso
{
    public interface IRolPermisoRepository
    {
        List<Data.RolPermiso> GetAll();
        Data.RolPermiso GetById(int id);
        bool Add(Data.RolPermiso rolPermiso);
        bool Update(Data.RolPermiso rolPermiso);
        bool Delete(int id);
    }
}
