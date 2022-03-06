﻿using AgileManagement.Application.services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AgileManagement.Application
{
    public class ApplicationModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddScoped<IUserRegisterService,UserRegisterService>();
        }
    }
        
}
