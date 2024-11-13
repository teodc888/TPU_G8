using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.Compania
{
    public interface ICompaniaRepository
    {
        List<Data.Companium> GetAll();
        Data.Companium GetById(int id);
        bool Add(Data.Companium compania);
        bool Update(Data.Companium compania);
        bool Delete(int id);
    }
}
