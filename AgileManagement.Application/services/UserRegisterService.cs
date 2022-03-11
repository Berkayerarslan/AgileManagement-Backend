using Agile.Management.Domain.events;
using Agile.Management.Domain.models;
using Agile.Management.Domain.repositories;
using AgileManagement.Application.dto;
using AgileManagement.Core;
using AgileManagement.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.services
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUserRepository _userRepository;

        public UserRegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserRegisterResponseDto OnProcess(UserRegisterRequestDto request = null)
        {
        
            try
            {
                var existingUser = _userRepository.GetQuery().Where(x => x.Email == request.Email).FirstOrDefault();
                if (existingUser != null)
                {
                    return new UserRegisterResponseDto
                    {
                        isSuccessed = false,
                        Message = "Zaten bu emaile kayıtlı bir kullanıcı bulunmaktadır."      
                    };
                }
                var user = new ApplicationUser(request.Email);
                user.SetProfileInfo(request.FirstName, request.LastName, "");
                user.SetEmail(request.Email);
                user.SetPasswordHash(CustomPasswordHashService.HashPassword(request.Password));
                _userRepository.Add(user);
                _userRepository.Save();
                DomainEvent.Raise(new UserCreatedEvent(user.Id,user.Email));

                return new UserRegisterResponseDto { isSuccessed = true, Message = "Kullanıcı oluşturuldu." };
            }
            catch (Exception ex)
            {

                return new UserRegisterResponseDto { isSuccessed = false, Message = ex.Message };
            }
        }
    }
}
