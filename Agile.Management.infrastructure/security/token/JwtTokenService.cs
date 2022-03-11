
using AgileManagement.Application.services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Infrastructure.security.token
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public async Task<TokenResponse> GenerateToken(IEnumerable<Claim> Claims)
        {
            var token = new JwtSecurityToken
              (
                  issuer: _configuration["JWT:issuer"],
                  audience: _configuration["JWT:audience"],
                  claims: Claims,
              expires: DateTime.UtcNow.AddSeconds(3600),
              notBefore: DateTime.UtcNow,
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:signingKey"])),
                      SecurityAlgorithms.HmacSha512)


              );


            var model = new TokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = TokenHelper.GetToken()
            };

            return await Task.FromResult(model);

        }
    }
}
