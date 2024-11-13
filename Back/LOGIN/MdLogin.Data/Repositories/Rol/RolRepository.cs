using MdLogin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Rol
{
    public class RolRepository : IRolRepository
    {
        private readonly MdLoginContext _contex;
        public RolRepository(MdLoginContext context) {
            _contex = context;
        }
        public void Add(Data.Rol rol)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Data.Rol> GetAll()
        {
            throw new NotImplementedException();
        }

        public Data.Rol GetById(int id)
        {
            return _contex.Rols.Where(x => x.RolId == id).FirstOrDefault();
        }

        public void Update(Data.Rol rol)
        {
            throw new NotImplementedException();
        }
    }
}
