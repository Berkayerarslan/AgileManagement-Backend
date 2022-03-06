using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class UserLoginAuthService : IApplicationService<UserLoginRequestDto, UserLoginResponseDto>
    {
        public UserLoginResponseDto OnProcess(UserLoginRequestDto request = null)
        {
           
        }
    }
}
