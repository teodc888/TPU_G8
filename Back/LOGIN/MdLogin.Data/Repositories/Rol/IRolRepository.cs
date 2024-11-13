using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Rol
{
    public interface IRolRepository
    {
        List<Data.Rol> GetAll();
        Data.Rol GetById(int id);
        void Add(Data.Rol rol);
        void Update(Data.Rol rol);
        void Delete(int id);
    }
}
