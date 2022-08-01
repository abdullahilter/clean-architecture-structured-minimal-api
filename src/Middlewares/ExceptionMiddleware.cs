using api.customer.Contracts.Responses;
using FluentValidation;
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
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var validationFailureResponse = new ValidationFailureResponse
            {
                Errors = exception.Errors.Select(x => x.ErrorMessage).ToList()
            };

            _logger.LogError(exception, string.Join(", ", validationFailureResponse.Errors));

            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(HttpStatusCode.InternalServerError.ToString());
        }
    }
}