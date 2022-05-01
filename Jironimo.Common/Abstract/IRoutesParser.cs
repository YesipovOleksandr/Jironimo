using Jironimo.Common.Models.Routing;

namespace Jironimo.Common.Abstract
{
    public interface IRoutesParser
    {
        List<RoutesSet> ParseTemplates();
    }
}
