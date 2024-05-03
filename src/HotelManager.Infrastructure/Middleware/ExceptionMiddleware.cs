using System.Text;
using System.Net;
using Microsoft.AspNetCore.Http;
using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UserFriendlyException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await HandleExceptionAsync(context, exception);
            }
            catch (UserPermissionException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                await HandleExceptionAsync(context, exception);
            }
            catch (InternalException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            var bytes = Encoding.UTF8.GetBytes(exception.Message);

            httpContext.Response.ContentLength = bytes.Length;

            await httpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}