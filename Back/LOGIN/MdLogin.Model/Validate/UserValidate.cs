using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Model.Validate
{
    using System;
    using System.Text.RegularExpressions;

    public class UserValidate
    {
        // Propiedades
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Constructor
        public UserValidate(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        // Método para validar el usuario completo
        public bool ValidateUser()
        {
            // Validar nombre de usuario
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3)
            {
                return false; // Nombre de usuario inválido
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6 ||
                !Regex.IsMatch(Password, @"[A-Z]") || !Regex.IsMatch(Password, @"[a-z]") || !Regex.IsMatch(Password, @"[0-9]"))
            {
                return false; // Contraseña inválida
            }

            // Validar correo electrónico
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false; // Correo electrónico inválido
            }

            return true; // Todas las validaciones son satisfactorias
        }
    }

}
