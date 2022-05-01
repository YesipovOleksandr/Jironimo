using Microsoft.AspNetCore.Routing;

namespace Jironimo.Common.Abstract
{
    public interface IRoutesConfigurator
    {
        void BuildRoutesUsingTemplates(IEndpointRouteBuilder builder);
    }
}
