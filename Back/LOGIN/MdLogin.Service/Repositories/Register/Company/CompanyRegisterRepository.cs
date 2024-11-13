using MdLogin.Data.Repositories.Compania;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.Repositories.Register.Company
{
    public class CompanyRegisterRepository : ICompanyRegisterRepository
    {
        private readonly ICompaniaRepository _companiaRepository;
        public CompanyRegisterRepository(ICompaniaRepository companiaRepository) {
            _companiaRepository = companiaRepository;
        }
        public string getByUrlCompany(int idCompany)
        {
            try
            {
                var company = _companiaRepository.GetById(idCompany);

                if (company == null)
                {
                    throw new Exception("Compania no encontrada");
                }

                return company.UrlDestino;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
