using Jironimo.Common.Models.Settings;

namespace Jironimo.Common.Abstract
{
    public interface IAppSettingsService
    {
        AppSettings GetSettings { get; }
        JironimoSettings JironimoSettings { get; }

    }
}
