using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Serilog;


namespace DAL.Middleware
{
    public class Middleware
    {

        //private readonly RequestDelegate _next;

        //public Middleware(RequestDelegate next)
        //{
        //    _next = next;
        //}

        //public async Task InvokeAsync(HttpContext httpContext)
        //{
        //    var myAction = httpContext.GetRouteData().Values["action"]?.ToString();
        //    Log.Information("action:" + " " + myAction);
        //    Log.Information("from new middleware");
        //    await _next(httpContext);
        //}

    }
}
