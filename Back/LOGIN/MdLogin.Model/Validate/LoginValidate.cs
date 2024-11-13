using MdLogin.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Model.Validate
{
    public class LoginValidate
    {
        public LoginValidate()
        {
        }

        public bool Validate(LoginModel login)
        {
            if (login == null)
            {
                return false;
            };
            if (string.IsNullOrEmpty(login.UserName))
            {
                return false;
            };
            if (string.IsNullOrEmpty(login.Password))
            {
                return false;
            } ;

            return true;
        }
    }
}
