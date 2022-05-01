using Jironimo.Common.Models.Routing;
using Microsoft.AspNetCore.Routing;

namespace Jironimo.Common.Abstract
{
    public interface IRoutesMapper
    {
        void MapRoutes(List<RoutesSet> routesCollection, IEndpointRouteBuilder builder);
    }
}