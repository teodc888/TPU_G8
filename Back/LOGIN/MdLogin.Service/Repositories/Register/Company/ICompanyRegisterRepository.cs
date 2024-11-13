using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.Repositories.Register.Company
{
    public interface ICompanyRegisterRepository
    {
        string getByUrlCompany(int idCompany);
    }
}
