using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Infrastructure.security.token
{
    public static class TokenHelper
    {
        public static string GetToken()
        {

            var randomNumber = new byte[32];
            string token = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }

            return token;

        }


        public static ClaimsPrincipal ValidateAccessToken(string accessToken)
        {
            // kullanıcı expire olduğundan ValidateLifetime false yaptık true yaparsak zaten validate olmaz.
            var tokenValidationParameters = new TokenValidationParameters
            {

                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("x-secret-key-x-secret-key")),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);


            return principal;

        }
    }
}
