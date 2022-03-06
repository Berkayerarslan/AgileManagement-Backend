using Agile.Management.Domain.models;
using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Management.Domain.events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public string Name { get; set; } = "UserAccountCreated";

        public string UserId { get; set; }
        public string Email { get; set; }

        // event içerisinde taşınacak olan değer. user bilgisi taşınacak
        /// <summary>
        /// Taşınacak olan bu user bilgisine Args (Argümanlar) deriz.
        /// </summary>
        /// <param name="applicationUser"></param>
        public UserCreatedEvent(string userId, string email)
        {
           UserId  = userId;
            Email = email;
        }
    }
}
