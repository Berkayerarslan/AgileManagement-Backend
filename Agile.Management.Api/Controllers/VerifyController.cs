using AgileManagement.Application.verify;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyController : ControllerBase
    {
        private UserVerifyMailService _userVerifyMailService;

        public VerifyController(UserVerifyMailService userVerifyMailService)
        {
            _userVerifyMailService = userVerifyMailService;
        }
        [HttpPost("verify-email")]
        public IActionResult VerifyUserEmail(UserVerifyRequestDto model)
        {
            var response = _userVerifyMailService.OnProcess(model);
            if (response.IsSuccessed)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
            
        }
    }
}
