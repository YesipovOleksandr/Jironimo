using Jironimo.Dependencies.DependencyModules;
using Microsoft.Extensions.DependencyInjection;

namespace Jironimo.Dependencies
{
    public static class DependencyRegistrator
    {
        public static void RegisterDependencyModules(this IServiceCollection services)
        {
            services.RegisterRoutes();
            services.RegisterServices();
        }
    }
}
