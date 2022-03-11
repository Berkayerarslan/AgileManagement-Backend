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
        
        private readonly IUserRegisterService _userRegisterService;
        private readonly UserLoginAuthService _userLoginAuthService;

        public AuthenticationController( IUserRegisterService userRegisterService,UserLoginAuthService userLoginAuthService)
        {
       
            _userRegisterService = userRegisterService;
            _userLoginAuthService = userLoginAuthService;
            
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto model)
        {

            var response = await _userLoginAuthService.OnProcess(model);
            if (!response.IsSuccessed) return BadRequest();

            return Ok(response.TokenResponse);
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
