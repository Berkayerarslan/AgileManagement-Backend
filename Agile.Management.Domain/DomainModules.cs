using Agile.Management.Domain.events;
using Agile.Management.Domain.handlers;
using AgileManagement.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Management.Domain
{
    public static class DomainModules
    {
        public static void Load(IServiceCollection services)
        {
            
            services.AddTransient<IDomainEventHandler<UserCreatedEvent>, UserCreatedHandler>();
           
            //// event handlerlar her çağrıldığında sistem tarafından yeni bir instance alınsın.


        }
    }
}
