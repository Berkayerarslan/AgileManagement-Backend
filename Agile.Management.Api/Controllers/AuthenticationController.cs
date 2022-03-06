using Agile.Management.Domain.models;
using Agile.Management.Domain.repositories;
using AgileManagement.Application.dto;
using AgileManagement.Application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Agile.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUserRegisterService _userRegisterService;

        public AuthenticationController(ITokenService tokenService, IUserRepository userRepository, IUserRegisterService userRegisterService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _userRegisterService = userRegisterService;
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(/*[FromBody] AuthDto model*/)
        {


            //if ((model.UserName == "mert" || model.UserName == "berkay") && model.Password == "1234" && model.GrantType == GrantTypes.Password)
            //{
            //    // access token da saklanacak bilgiler.
            //    var claims = new List<Claim>
            //    {
            //        new Claim("id",model.UserName == "mert" ? "1":"2"),
            //        new Claim(ClaimTypes.Name,model.UserName),
            //        new Claim("username",model.UserName),
            //          new Claim("role","admin,manager")
            //    };

            //    var response = await _tokenService.GenerateToken(claims);

            //    RefreshTokenStore.Tokens.Add(response.RefreshToken);

            //    return Ok(response);
            //}

            //eğer sistemde kayıtlı bir kullanıcı değilsek 401 hatası döndür.
            return Unauthorized();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequestDto model)
        {
            var response = _userRegisterService.OnProcess(model);
            if (response.isSuccessed)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
        }
    }
}
