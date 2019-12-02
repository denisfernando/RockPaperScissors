using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiCommunication
{
    public class Startup
    {
        public readonly IHostingEnvironment _env;
        public readonly IConfiguration _config;
        public readonly ILoggerFactory _loggerFactory;



        public Startup(IHostingEnvironment env ,IConfiguration config, ILoggerFactory loggerFactory)
        {
            _env = env ?? throw new ArgumentNullException($"IHostingEnvironment não foi injetado");
            _config = config ?? throw new ArgumentNullException($"IConfiguration não foi injetado");
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException($"ILoggerFactory não foi injetado");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var logger = _loggerFactory.CreateLogger<Startup>();

            if(_env.IsDevelopment())
            {
                logger.LogInformation("Aplicação em modo Development");
            }
            setContainer(services);
            services.AddMvc();
        }


        private void setContainer(IServiceCollection services)
        {
            #region instanciando as DI
            //Applications
            services.AddScoped<IApplicationTournament, ApplicationTournament>();
            services.AddScoped<IApplicationGame, ApplicationGame>();

            //Services
            services.AddScoped<IServiceTournament, ServiceTournament>();
            services.AddScoped<IServiceGame, ServiceGame>();

           
            #endregion
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseMvcWithDefaultRoute();
            //app.UseHttpsRedirection();

        }
    }
}
