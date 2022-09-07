using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.customer.Validations;

/// <summary>
/// https://www.rfc-editor.org/rfc/rfc7807
/// </summary>
public static class ValidationExtensions
{
    public static ValidationProblemDetails ToProblemDetails(
        this ValidationException exception)
    {
        var error = new ValidationProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Status = (int)HttpStatusCode.BadRequest
        };

        foreach (var validationFailure in exception.Errors)
        {
            if (error.Errors.ContainsKey(validationFailure.PropertyName))
            {
                error.Errors[validationFailure.PropertyName] =
                    error.Errors[validationFailure.PropertyName]
                    .Concat(new[] { validationFailure.ErrorMessage }).ToArray();

                continue;
            }

            error.Errors.Add(new KeyValuePair<string, string[]>(
                validationFailure.PropertyName,
                new[] { validationFailure.ErrorMessage }));
        }

        return error;
    }
}