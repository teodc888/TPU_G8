using Alumnos.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Data.Repositories.Class
{
    public class DocenteXTribunalesRepository : GenericRepository<DocentesXTribunale>
    {
        public DocenteXTribunalesRepository(TpiDatosContext context) : base(context)
        {
        }

        public async Task<List<DocentesXTribunale>> GetLegajoTribunal(int legajo)
        {
            return await _dbSet.Where(p => p.Docente == legajo).ToListAsync();
        }
    }
}
