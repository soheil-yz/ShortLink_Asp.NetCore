using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using ShortLink.Application.Interfaces;
using ShortLink.Infra.Data.Context;
using System.Threading.Tasks;

namespace ShortLinkWeb.Middelware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ShortLinkUrlRedirect
    {
        private readonly RequestDelegate _next;
        private ILinkService _linkService;
        public ShortLinkUrlRedirect(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _linkService = (ILinkService)httpContext.RequestServices.GetService(typeof(ILinkService));
            var userAgent = StringValues.Empty;
            httpContext.Request.Headers.TryGetValue("User-Agent", out userAgent);
            if(httpContext.Request.Path.ToString().Length == 6)
            {
                _linkService.AddUserAgent(userAgent);
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ShortLinkUrlRedirectExtensions
    {
        public static IApplicationBuilder UseShortLinkUrlRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShortLinkUrlRedirect>();
        }
    }
}
