using AgileManagement.Application.services;
using AgileManagement.Core;
using AgileManagement.Infrastructure.Notification.Smtp;
using AgileManagement.Infrastructure.security.token;
using AgileManagementSystem.Infrastructure.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Agile.Management.infrastructure
{
    public class InfrastructureModule
    {
        public static void Load(IServiceCollection services)
        {
           
            services.AddSingleton<ITokenService, JwtTokenService>();
            services.AddSingleton<IEmailService, NetSmtpEmailService>();
            services.AddSingleton<IDomainEventDispatcher, NetCoreEventDispatcher>();
        }
    }
}
