using MdLogin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Sesion
{
    public class SesionRepository : ISesionRepository
    {
        private readonly MdLoginContext _context;
        public SesionRepository(MdLoginContext context)
        {
            _context = context;
        }

        public bool Add(Data.Sesion sesion)
        {
            _context.Add(sesion);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Data.Sesion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Data.Sesion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Data.Sesion GetByTokenAndUser(string tokenSesion, int userId)
        {
            var session = _context.Sesions.Where(x => x.TokenSesion == tokenSesion && x.UsuarioId == userId).FirstOrDefault();

            return session;

        }

        public Data.Sesion GetByUser(int userId)
        {
            var session = _context.Sesions.Where(x => x.UsuarioId == userId).FirstOrDefault();

            return session;
        }

        public bool Update(Data.Sesion sesion)
        {
            _context.Sesions.Update(sesion);
            return _context.SaveChanges() > 0;
        }
    }
}
