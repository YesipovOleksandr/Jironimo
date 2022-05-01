using Jironimo.Common.Models.Routing.ApiRoute;
using Microsoft.AspNetCore.Routing;

namespace Jironimo.Common.Abstract
{
    public interface IRoutesMapper
    {
        void MapRoutes(List<RoutesSet> routesCollection, IEndpointRouteBuilder builder);
    }
}