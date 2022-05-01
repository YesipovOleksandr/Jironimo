using Jironimo.Common.Abstract;
using Jironimo.Common.Models.Settings;
using Microsoft.Extensions.Configuration;

namespace Jironimo.Dependencies.DependencyModules
{
    public class AppSettingsService : IAppSettingsService
    {
        public AppSettings GetSettings { get; }

        public JironimoSettings JironimoSettings { get; }


        public AppSettingsService(IConfiguration configuration)
        {
            GetSettings = new AppSettings();
            JironimoSettings = new JironimoSettings(configuration);
            configuration.GetSection("GlobalSettings").Bind(GetSettings);

        }
    }
}
