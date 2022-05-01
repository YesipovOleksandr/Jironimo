using Jironimo.Common.Abstract;
using Jironimo.Common.Models.Routing;
using Newtonsoft.Json;

namespace Jironimo.Common.Concrete
{
    public class RoutesParser : IRoutesParser
    {
        private readonly string _routesPaths;
        public RoutesParser(string routesPaths)
        {
            _routesPaths = routesPaths;
        }
        public List<RoutesSet> ParseTemplates()
        {
            List<RoutesSet> routesCollection = new List<RoutesSet>();

            using (StreamReader reader = new StreamReader(string.Format(_routesPaths)))
            {

                string json = reader.ReadToEnd();
                var routesSet = JsonConvert.DeserializeObject<RoutesSet>(json);
                if (routesSet != null)
                {
                    routesCollection.Add(routesSet);
                }
            }

            return routesCollection;
        }
    }
}
