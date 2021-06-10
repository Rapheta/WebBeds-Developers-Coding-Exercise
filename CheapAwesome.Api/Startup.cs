using System;
using AutoMapper;
using CheapAwesome.Core.Interfaces;
using CheapAwesome.Core.Services;
using CheapAwesome.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CheapAwesome.Api
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
            //Registro de nuestros mapeos
            //Obtener los Assemblies (proyectos compilados) en el dominio actual de nuestra aplicación para buscar los profiles
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Ignoraremos el error de referencia circular
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSingleton<IAvailabilityRepository, AvailabilityRepository>();
            services.AddSingleton<IAvailabilityService, AvailabilityService>();

            services.AddSingleton(Configuration);

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Availability}/{action=GetAvailability}/{destinationId?}/{nights?}");
            });
        }
    }
}
