using MdLogin.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Model.Validate
{
    public class ValidateValidate
    {
        public ValidateValidate() { }

        public bool validate(ValidateModel validateModel) 
        {
            if (validateModel == null)
            {
                return false;
            };
            if (string.IsNullOrEmpty(validateModel.TokenSesion))
            {
                return false;
            };

            return true;
        }
    }
}
