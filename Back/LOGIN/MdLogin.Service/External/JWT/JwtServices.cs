using Jose;
using MdLogin.Model.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Service.External.JWT
{
    public class JwtServices
    {
        private static readonly string SecretKey = "w6X9u2+yVyfYxrMgQclRJc4GuPQW3H2pfmahJ5B2EP4=";
        private static readonly string Issuer = "Login";
        private static readonly string Audience = "Api";
        public JwtServices() { }

        #region -[CreateToken]-        
        /// <summary>
        /// Metodo para crear el token 
        /// </summary>
        /// <param name="pcredentials"></param>
        /// <returns></returns>
        public TokenModel CreateToken(LoginModel login)
        {
            TokenModel createTokenRs = new TokenModel();
            try
            {

                // Crear las claims (información del usuario) para incluir en el token
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, login.UserName),

                };

                // Configurar la clave secreta para firmar el token (deberías almacenar esto de manera segura)
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                // Configurar la fecha de vencimiento del token
                var expiration = DateTime.UtcNow.AddHours(1);

                // Crear el token JWT con fecha de vencimiento
                var token = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signingCredentials
                );

                // Generar el token como una cadena JWT
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                createTokenRs.Token = tokenString;
                createTokenRs.Expiration = expiration;
            }
            catch (Exception ex)
            {

            }

            return createTokenRs;
        }
        #endregion

        #region -[ValidateToken]-        
        /// <summary>
        /// Metodo para crear el token 
        /// </summary>
        /// <param name="pcredentials"></param>
        /// <returns></returns>
        public bool ValidateToken(TokenModel tokenRequest)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = secretKey,
                ClockSkew = TimeSpan.Zero 
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameters, out validatedToken);

                var username = principal.Identity.Name;

                return true;
            }
            catch (SecurityTokenException ex)
            {
                return false;
            }

        }
        #endregion

    }
}
