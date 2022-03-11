using Agile.Management.Domain.repositories;
using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.verify
{
    public class UserVerifyRequestDto
    {
        public string UserId { get; set; }
    }
    public class UserVerifyResponseDto
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
    }
    public class UserVerifyMailService : IApplicationService<UserVerifyRequestDto, UserVerifyResponseDto>
    {
        private readonly IUserRepository _userRepository;
        public UserVerifyMailService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserVerifyResponseDto OnProcess(UserVerifyRequestDto request = null)
        {
            if (request == null)
                throw new ArgumentNullException();
            var user = _userRepository.Find(request.UserId);

            if (user == null) return new UserVerifyResponseDto { IsSuccessed = false, Message = "Aradığınız kullanıcı bulunamadı." };

            user.SetVerifyEmail();
            _userRepository.Save();

            return new UserVerifyResponseDto { IsSuccessed = true, Message = "Email onaylandı." };



        }
    }
}
