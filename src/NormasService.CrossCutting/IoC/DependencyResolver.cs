using Microsoft.Extensions.DependencyInjection;
using NormasService.Application;
using NormasService.Application.Interfaces;
using NormasService.Domain.Repositories;
using NormasService.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace NormasService.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<INormaApplication, NormaApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<INormaRepository, NormaRepository>();
        }
    }
}