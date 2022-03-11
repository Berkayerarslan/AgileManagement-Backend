using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Core
{
    public class AuthenticatedUser
    {
        public string Email { get; set; }
        public string Id { get; set; }
    }

    public interface IAuthenticatedUser
    {
        AuthenticatedUser GetUser { get; }
    }

 
 
}
