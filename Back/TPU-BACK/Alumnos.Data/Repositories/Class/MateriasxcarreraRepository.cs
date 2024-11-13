using Alumnos.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Alumnos.Data.Repositories.Class
{
    public class MateriasxcarreraRepository : GenericRepository<Materiasxcarrera>
    {
        public MateriasxcarreraRepository(TpiDatosContext context) : base(context)
        {
        }

        public async Task<List<Materiasxcarrera>> GetByMateriaXCarreraIdLegajoAsync(int legajo)
        {
            return await _dbSet.Where(p => p.DocenteACargo == legajo).ToListAsync();
        }
    }
}
