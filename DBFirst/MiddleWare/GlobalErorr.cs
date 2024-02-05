using Serilog;

namespace DBFirst.MiddleWare
{
    public class GlobalErorr
    {
        private readonly RequestDelegate _next;

        public GlobalErorr(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error("message: " + ex.Message);
            }

        }
    }
}
