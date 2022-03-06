using Agile.Management.Domain.events;
using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Management.Domain.handlers
{
    public class UserCreatedHandler : IDomainEventHandler<UserCreatedEvent>
    {

        private readonly IEmailService _emailService;
      

        // ILogService logService,
        public UserCreatedHandler(IEmailService emailService)
        {
            //_logService = logService;
            _emailService = emailService;
            //_dataProtector = dataProtectionProvider.CreateProtector(UserTokenNames.EmailVerification);
            // _dataProtector servisi ile userId şifreleyip daha sonra çözeceğiz
            // şifreli halini mail adresine göndereceğiz. böylelikle verificationCode direk oluşturmuş olacağız.
        }
        public void Handle(UserCreatedEvent @event)
        {
            string activationLink = "http://localhost:3000/VerifyMail/" + @event.UserId;
            _emailService.SendSingleEmailAsync(@event.Email, $"Email onayı", $"<p> Emaili onaylamak için <a href='{activationLink}&accepted=true'> Tıklaynız <a/></p>");
        }

      
    }
}
