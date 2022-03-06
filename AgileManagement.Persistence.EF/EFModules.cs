using Agile.Management.Domain.repositories;
using AgileManagement.Persistence.EF.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AgileManagement.Persistence.EF
{
    public static class EFModules
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LocalDb"));
            });

            services.AddScoped<IUserRepository, EFUserRepository>();
         
         
            // best practice olarak db context uygyulaması appsettings dosyasından bilgileri conectionstrings node dan alırız.
        }
    }
}
