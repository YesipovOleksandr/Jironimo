using Jironimo.Common.Abstract;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Concrete
{
    public class RoutesConfigurator : IRoutesConfigurator
    {
        private readonly IRoutesMapper _routesMapper;
        private readonly IRoutesParser _routesParser;
        public RoutesConfigurator(IRoutesMapper routesMapper, IRoutesParser routesParser)
        {
            _routesMapper = routesMapper;
            _routesParser = routesParser;
        }

        public void BuildRoutesUsingTemplates(IEndpointRouteBuilder builder)
        {
            _routesMapper.MapRoutes(_routesParser.ParseTemplates(), builder);
        }
    }
}
