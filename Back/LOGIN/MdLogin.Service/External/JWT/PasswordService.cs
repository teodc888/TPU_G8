using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.External.JWT
{
    public class PasswordService
    {
        public string HashPassword(string password, out string salt)
        {

            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            byte[] hashBytes = pbkdf2.GetBytes(20);

            byte[] hashWithSaltBytes = new byte[36];
            Array.Copy(saltBytes, 0, hashWithSaltBytes, 0, 16);
            Array.Copy(hashBytes, 0, hashWithSaltBytes, 16, 20);

            salt = Convert.ToBase64String(saltBytes);
            return Convert.ToBase64String(hashWithSaltBytes);
        }


        public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] storedHashBytes = Convert.FromBase64String(storedHash);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            byte[] enteredHashBytes = pbkdf2.GetBytes(20);


            for (int i = 0; i < 20; i++)
            {
                if (storedHashBytes[i + 16] != enteredHashBytes[i])
                {
                    return false;
                }
            }

            return true; 
        }
    }
}
