using Jironimo.Common.Models.Routing.ApiRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Abstract
{
    public interface IApiRoutesParser
    {
        List<RoutesSet> ParseTemplates();
    }
}
