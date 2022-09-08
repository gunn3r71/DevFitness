using DevFitness.API.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using DevFitness.API.Configuration;
using DevFitness.API.Middlewares;
using DevFitness.Infrastructure.Context;

namespace DevFitness.API
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DevFitnessCs");

            services.AddDbContext<DevFitnessDbContext>(
                options =>
                {
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                });

            services.AddAutoMapper(typeof(UserProfile));

            services.ResolveDependencies();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DevFitness.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Email = "Lucas.p.oliveira@outlook.pt",
                        Name = "Lucas Pereira",
                        Url = new Uri("https://www.linkedin.com/in/lucas-pereira-cod3r/")
                    }
                });
                /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var path = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(path);*/
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFitness.API v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFitness.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
