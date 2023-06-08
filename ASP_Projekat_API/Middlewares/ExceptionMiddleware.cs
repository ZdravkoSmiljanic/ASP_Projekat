using ASP_Projekat_Application.Exceptions;
using ASP_Projekat_Application.Logging;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Projekat_API.Middlewares
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
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 422;

                var errors = ex.Errors.Select(x => new
                {
                    x.ErrorMessage,
                    x.PropertyName
                });

                await context.Response.WriteAsJsonAsync(errors);
            }

            catch (UnauthorizedUserUseCaseException ex)
            {
                context.Response.StatusCode = 401;
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = 401;
            }
            catch (System.Exception ex)
            {
                Guid errorId = Guid.NewGuid();
                AppError error = new AppError
                {
                    Exception = ex,
                    ErrorId = errorId,
                    Username = "test"
                };
               
                //_errorLogger.Add(error);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var responseBody = new
                {
                
                    message = $"There was an error, please contact support with this error code: {errorId}."
                };

                await context.Response.WriteAsJsonAsync(ex.Message.ToString());
            }
        }
    }
}

