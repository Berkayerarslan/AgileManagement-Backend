using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Management.Domain.handlers
{
    internal class UserCreatedNotifyHandler : IDomainEventHandler<UserRegisteredEvent>
    {
        public void Handle(UserRegisteredEvent @event)
        {
           
        }
    }
}
