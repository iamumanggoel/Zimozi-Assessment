using System.Net;
using System.Text.Json;

namespace TaskManagerAPI.Middlewares
{
    public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;

        //TODO: Cloud based Logging can be setup
        private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");
                await Handler(context, ex);
            }
        }

        private static Task Handler(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500

            var response = new
            {
                context.Response.StatusCode,
                exception.Message,
                exception.StackTrace,
                InnerExceptionMessage = exception.InnerException?.Message,
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}