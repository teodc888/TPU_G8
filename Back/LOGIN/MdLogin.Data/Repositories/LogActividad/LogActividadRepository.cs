using MdLogin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.LogActividad
{
    public class LogActividadRepository : ILogActividadRepository
    {

        private readonly MdLoginContext _context;
        public LogActividadRepository(MdLoginContext context) {
            _context = context;
        }
        public bool Add(Data.LogActividad logActividad)
        {
            _context.LogActividads.Add(logActividad);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Data.LogActividad> GetAll()
        {
            throw new NotImplementedException();
        }

        public Data.LogActividad GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Data.LogActividad logActividad)
        {
            throw new NotImplementedException();
        }
    }
}
