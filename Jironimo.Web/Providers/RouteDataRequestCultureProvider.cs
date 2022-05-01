using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Jironimo.Web.Providers
{
    public class RouteDataRequestCultureProvider : RequestCultureProvider
    {
        private static readonly StringComparer _stringComparer = StringComparer.InvariantCultureIgnoreCase;
        private static readonly Dictionary<string, CultureInfo> _cultures = new Dictionary<string, CultureInfo>(_stringComparer) { };

        static RouteDataRequestCultureProvider()
        {
            _cultures.Add("en", new CultureInfo("en-US"));
            _cultures.Add("fr", new CultureInfo("fr-FR"));
            _cultures.Add("de", new CultureInfo("de-DE"));
            _cultures.Add("it", new CultureInfo("it-IT"));
        }

        public static IList<CultureInfo> GetCultures()
        {
            return _cultures.Values.Select(d => d).ToList();
        }

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var language = httpContext.GetRouteData().Values["lang"]?.ToString();


            language = !string.IsNullOrEmpty(language) ? language : "en";

            CultureInfo culture = null;

            if (_cultures.ContainsKey(language))
                culture = _cultures[language];
            else
                culture = _cultures["en"];


            var providerResultCulture = new ProviderCultureResult(culture.Name, culture.Name);


            return Task.FromResult(providerResultCulture);
        }
    }
}