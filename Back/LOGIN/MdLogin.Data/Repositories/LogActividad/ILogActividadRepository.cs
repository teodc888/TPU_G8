using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.LogActividad
{
    public interface ILogActividadRepository
    {
        List<Data.LogActividad> GetAll();
        Data.LogActividad GetById(int id);
        bool Add(Data.LogActividad logActividad);
        bool Update(Data.LogActividad logActividad);
        bool Delete(int id);
    }
}
