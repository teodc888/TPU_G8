using MdLogin.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Model.Validate
{
    public class LogoutValidate
    {
        public LogoutValidate() { }

        public bool Validate(LogoutModel logout)
        {
            if (logout == null)
            {
                return false;
            };
            if (string.IsNullOrEmpty(logout.TokenSesion))
            {
                return false;
            };
            if (logout.UsuarioId == 0)
            {
                return false;
            };

            return true;
        }
    }
}
