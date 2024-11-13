using MdLogin.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.Repositories.Login
{
    public interface ILoginRepository
    {
        ResponseModel Login(LoginModel login);
        ResponseModel Logout(LogoutModel logout);
        ResponseModel Validate(ValidateModel logout);

    }
}
