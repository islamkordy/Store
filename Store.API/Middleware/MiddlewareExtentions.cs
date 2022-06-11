using Microsoft.AspNetCore.Builder;

namespace Store.API.Middleware
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceprionHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
