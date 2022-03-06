using Agile.Management.Domain;
using Agile.Management.infrastructure;
using AgileManagement.Application;
using AgileManagement.Application.services;
using AgileManagement.Persistence.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Management.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();


            // burasý çok önemli sakýn singleton yapmayalým.

            DomainModules.Load(services);
            ApplicationModule.Load(services);
            EFModules.Load(services, Configuration);
            InfrastructureModule.Load(services);


            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod(); // GET,POST apida açýk, HTTPDELETE, HTTPUT içinde açmýþ olduk; 415 hatasýda HttpMethod izni verilmemiþtir.
                    policy.AllowAnyOrigin(); // Herhangi bir domaine istek atabiliriz.
                    //policy.WithOrigins("www.a.com", "www.b.com");
                    policy.AllowAnyHeader(); // Application/json appliation/xml
                    //policy.WithHeaders("x-token"); // Application/json appliation/xml
                });
            });

            //services.AddAuthentication("adminScheme").AddJwtBearer()
          

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agile.Management.Api", Version = "v1" });
            });





            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            //{
            //    opt.SaveToken = true;// token sessionda tutumamýzý saðlar
            //    //opt.Audience = Configuration["JWT:audience"];

            //    opt.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateAudience = true, // yanlýþ audince gönderirse token kabul etme
            //        ValidateIssuer = true, // access tokendan yanlýþ issuer gelirse validate etme
            //        ValidateIssuerSigningKey = true, // çok önemli signkey validate etmemiz lazým
            //        ValidateLifetime = true, // token yaþam süresini kontrol et
            //        ValidIssuer = Configuration["JWT:issuer"], // valid issuer deðeri
            //        ValidAudience = Configuration["JWT:audience"], // valid audience deðeri
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:signingKey"])),

            //    };
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agile.Management.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(); // cors aç
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
