using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CarRentalSystem.Infrastructure.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected exception {ex.Message} \n{ex.StackTrace}");
                await HandleException(httpContext, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)GetResponseError(exception);
            string message = exception.Message;
            string[] messages = GetMessages(exception);

            return context.Response.WriteAsync(new
            {
                Status = context.Response.StatusCode,
                Title = ((HttpStatusCode)context.Response.StatusCode).ToString(),
                Message = message,
                Messages = messages,
                TraceId = context.TraceIdentifier
            }.ToString());
        }

        private string[] GetMessages(Exception exception)
        {
            switch (exception)
            {
                case NullReferenceException e: return new[] { e.Message };
                case UnauthorizedAccessException e: return new[] {e.Message};
                case ValidationException e: return new[] {e.Message};
                default:
                    return null;
            }
        }

        private HttpStatusCode GetResponseError(Exception exception)
        {
            switch (exception)
            {
                case NullReferenceException _: return HttpStatusCode.NotFound;
                case UnauthorizedAccessException _: return HttpStatusCode.Forbidden;
                case ValidationException _: return HttpStatusCode.NotAcceptable;
                default: return HttpStatusCode.InternalServerError;
            }
        }
    }
}
