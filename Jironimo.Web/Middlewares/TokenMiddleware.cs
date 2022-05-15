namespace Jironimo.Web.Middlewares
{
    public class TokenMiddleware
    {
        private const string _loginPath = "/login";
        private readonly RequestDelegate _next;
        private string _token;

        public TokenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/admin") || context.Request.Path.StartsWithSegments("/api/account/token"))
            {
                if (context.Request.Cookies.ContainsKey(".AspNetCore.Cookies"))
                {
                    _token = context.Request.Cookies[".AspNetCore.Cookies"];
                    context.Request.Headers.Add("Authorization", $"Bearer {_token}");
                }
                else
                {
                    context.Request.Path = _loginPath;
                    context.Request.Method = "GET";
                }
            }
            await _next.Invoke(context);
        }
    }
}
