using api.customer.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.customer.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate request, ILogger<ExceptionMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (ValidationException exception)
        {
            _logger.LogError(exception, exception.ToString());

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var error = exception.ToProblemDetails();
            await context.Response.WriteAsJsonAsync(error);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.ToString());

            context.Response.StatusCode = 500;
            var problem = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error occured while processing your request.", //exception.Message
                Instance = context.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message //exception.StackTrace
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}