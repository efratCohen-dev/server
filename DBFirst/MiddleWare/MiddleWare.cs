using Serilog;

namespace DBFirst.MiddleWare
{
    public class MiddleWare
    {

        private readonly RequestDelegate _next;

        public MiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var myAction = httpContext.GetRouteData().Values["action"]?.ToString();
            Log.Information("action:" + " " + myAction);
            Log.Information("from new middleware");
            await _next(httpContext);
        }

    }
}
