
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.services
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireDateSeconds { get; set; } = 3600;
        public string TokenType { get; set; } = "Bearer";
    }
    public interface ITokenService
    {
        /// <summary>
        /// TokenDto Response dönecek olan method
        /// </summary>
        /// <returns></returns>
        Task<TokenResponse> GenerateToken(IEnumerable<Claim> Claims);
    }
}
