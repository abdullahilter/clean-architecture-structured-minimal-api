using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace api.customer.Domain.Common;

public class DateOfBirth : ValueOf<DateOnly, DateOfBirth>
{
    protected override void Validate()
    {
        if (Value > DateOnly.FromDateTime(DateTime.Now) || Value.Year <= 1900)
        {
            var message = "Your date of birth is not in the valid range";

            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(DateOfBirth), message)
            });
        }
    }
}