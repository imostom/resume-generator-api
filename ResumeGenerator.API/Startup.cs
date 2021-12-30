using App.Core.Models;
using App.Core.Services;
using App.Database.DbContext;
using App.Database.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ResumeGenerator.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeGenerator.API
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
            //config injection
            AppConfigurations appConfigurations = new AppConfigurations();
            Configuration.GetSection("AppConfigurations").Bind(appConfigurations);
            services.AddSingleton(appConfigurations);

            //postmark injection
            var postmarkService = new PostmarkService(appConfigurations);
            services.AddSingleton(postmarkService);

            //services.AddSingleton(serviceProvider =>
            //{
            //    return new PostmarkService(appConfigurations);
            //});

            //repository and dbcontext injection
            services.AddSingleton<IResumeRepository>(serviceProvider =>
            {
                return new ResumeRepository(postmarkService, appConfigurations);
            });
            services.AddSingleton<IDataContext>(serviceProvider =>
            {
                return new DataContext(appConfigurations.ConnectionString);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ResumeGenerator.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResumeGenerator.API v1"));
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
