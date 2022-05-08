using Jironimo.Common.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Jironimo.Dependencies.DependencyModules
{
    public static class ServicesModule
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IAppSettingsService, AppSettingsService>();
            services.AddHttpContextAccessor();
        }
    }
}
