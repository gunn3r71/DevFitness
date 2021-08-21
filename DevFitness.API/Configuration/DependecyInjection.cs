using DevFitness.Core.Interfaces.Repositories;
using DevFitness.Core.Interfaces.Services;
using DevFitness.Core.Services;
using DevFitness.Infrastructure.Context;
using DevFitness.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevFitness.API.Configuration
{
    /// <summary>
    /// Class that solves the dependencies
    /// </summary>
    public static class DependecyInjection
    {
        /// <summary>
        /// Extension method to resolve dependencies
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DevFitnessDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}