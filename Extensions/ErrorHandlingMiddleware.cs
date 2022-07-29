using FrontTest.Extensions.Exceptions;
using System.Net;
using System.Text.Json;

namespace FrontTest.Extensions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is MyBadRequestException) code = HttpStatusCode.BadRequest;

            var result = JsonSerializer.Serialize(new { Код = code, Текст = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
