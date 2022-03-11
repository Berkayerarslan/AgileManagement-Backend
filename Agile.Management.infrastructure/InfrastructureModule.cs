using AgileManagement.Application.services;
using AgileManagement.Core;
using AgileManagement.Infrastructure.Notification.Smtp;
using AgileManagement.Infrastructure.security.token;
using AgileManagementSystem.Infrastructure.Events;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Agile.Management.infrastructure
{
    public class InfrastructureModule
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<ITokenService, JwtTokenService>();
            services.AddSingleton<IEmailService, NetSmtpEmailService>();
            services.AddSingleton<IDomainEventDispatcher, NetCoreEventDispatcher>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;// token sessionda tutumamızı sağlar
                //opt.Audience = Configuration["JWT:audience"];

                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true, // yanlış audince gönderirse token kabul etme
                    ValidateIssuer = true, // access tokendan yanlış issuer gelirse validate etme
                    ValidateIssuerSigningKey = true, // çok önemli signkey validate etmemiz lazım
                    ValidateLifetime = true, // token yaşam süresini kontrol et
                    ValidIssuer = configuration["JWT:issuer"], // valid issuer değeri
                    ValidAudience = configuration["JWT:audience"], // valid audience değeri
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:signingKey"])),

                };
            });
           

        }
        
    }
}
