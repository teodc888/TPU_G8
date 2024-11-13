using MdLogin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Compania
{
    public class CompaniaRepository : ICompaniaRepository
    {
        private readonly MdLoginContext _context;
        public CompaniaRepository(MdLoginContext context) { 
            _context = context;
        }

        public bool Add(Companium compania)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Companium> GetAll()
        {
            throw new NotImplementedException();
        }

        public Companium GetById(int id)
        {
            return _context.Compania.Where(x => x.CompaniaId == id).FirstOrDefault();
        }

        public bool Update(Companium compania)
        {
            throw new NotImplementedException();
        }
    }
}
