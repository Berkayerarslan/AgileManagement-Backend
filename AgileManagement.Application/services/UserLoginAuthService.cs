using Agile.Management.Domain.repositories;
using AgileManagement.Core;
using AgileManagement.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.services
{
    public class UserLoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserLoginResponseDto
    {
        public bool IsSuccessed { get; set; }
        public TokenResponse TokenResponse { get; set; }


    }
    public class UserLoginAuthService : IApplicationService<UserLoginRequestDto, Task<UserLoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserLoginAuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<UserLoginResponseDto> OnProcess(UserLoginRequestDto request = null)
        {

            try
            {
                var existingUser = _userRepository.GetQuery().Where(x => x.Email == request.Email && x.PasswordHash == CustomPasswordHashService.HashPassword(request.Password) && x.EmailVerified == true).FirstOrDefault();
                if (existingUser == null) return await Task.FromResult(new UserLoginResponseDto { IsSuccessed = false });

                var claims = new List<Claim>{
                    new Claim("id",existingUser.Id),
                    new Claim("email", existingUser.Email)
                   
                };
                var tokenResponse = await _tokenService.GenerateToken(claims);
                existingUser.SetRefreshToken(tokenResponse.RefreshToken);
                _userRepository.Save();

                return await Task.FromResult(new UserLoginResponseDto
                {
                    IsSuccessed = true,
                    TokenResponse = tokenResponse
                });


            }
            catch (Exception)
            {

                return new UserLoginResponseDto { IsSuccessed = false };
            }
           
            
           
           
        }

        
    }
}
