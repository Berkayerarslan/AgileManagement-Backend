using AgileManagement.Application.dto;
using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.services
{
    public interface IUserRegisterService:IApplicationService<UserRegisterRequestDto, UserRegisterResponseDto>
    {
    }
}
