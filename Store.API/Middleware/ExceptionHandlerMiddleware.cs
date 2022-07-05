using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Store.Application.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Store.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(badRequestException.Message);
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case Exception ex:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.StatusCode = (int)statusCode;

            if(result == String.Empty)
                result = JsonConvert.SerializeObject(new {error = exception.Message});

            return context.Response.WriteAsync(result);

        } 
    }
}
