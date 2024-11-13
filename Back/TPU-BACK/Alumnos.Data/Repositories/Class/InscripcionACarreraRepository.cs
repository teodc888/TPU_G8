using Alumnos.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Alumnos.Data.Repositories.Class
{
    public class InscripcionACarreraRepository : GenericRepository<InscripcionACarrera>
    {
        public InscripcionACarreraRepository(TpiDatosContext context) : base(context)
        {
        }

        public async Task<InscripcionACarrera> GetInscripcionCarreraLegajoAsync(int legajo)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Alumno == legajo);
        }
        public async Task<List<InscripcionACarrera>> GetInscripcionCarreraCarreraAsync(int carrera)
        {
            return await _dbSet.Where(p => p.Carrera == carrera).ToListAsync();
        }
    }
}
