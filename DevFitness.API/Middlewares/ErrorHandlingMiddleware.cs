using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DevFitness.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace DevFitness.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;

            if (exception is NotExistsException) code = StatusCodes.Status404NotFound;
            else if (exception is ValidationException) code = StatusCodes.Status400BadRequest;
            
            var result = JsonSerializer.Serialize(new { Message = exception.Message });
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}