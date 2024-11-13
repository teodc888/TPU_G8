using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Permiso
{
    public interface IPermisoRepository
    {
        List<Data.Permiso> GetAll();
        Data.Permiso GetById(int id);
        void Add(Data.Permiso permiso);
        void Update(Data.Permiso permiso);
        void Delete(int id);
    }
}
