using BCR.ScrepperWeb.Service.Services;
using BCR.ScrepperWeb.Service.Services.Interfaces;
using BCR.WebScrapper.AccesData.Request;
using BCR.WebScrapper.AccesData.Request.Interfaces;
using BCR.WebScrapper.Aplication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCR.WebScrapper.WebApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BCR.WebScrapper.WebApi", Version = "v1" });
            });

            services.AddTransient<IBoletinArgRequest, BoletinArgRequest>();
            services.AddTransient<IRuntimeProvider, RuntimeProvider>();
            services.AddTransient<IBoletinOficialArgService, BoletinOficialArgService>();
            services.AddTransient<IBoletinStaFeService, BoletinStaFeService>();
            services.AddTransient<IBoletinStaFeRequest, BoletinStaFeRequest>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BCR.WebScrapper.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
