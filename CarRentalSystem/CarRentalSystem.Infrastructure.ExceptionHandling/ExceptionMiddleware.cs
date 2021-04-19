using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarRentalSystem.Infrastructure.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                await HandleException(httpContext, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = exception.Message;

            return context.Response.WriteAsync(new
            {
                Status = context.Response.StatusCode,
                Title = ((HttpStatusCode)context.Response.StatusCode).ToString(),
                Message = message,
                TraceId = context.TraceIdentifier
            }.ToString());
        }
    }
}
