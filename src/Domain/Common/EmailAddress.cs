using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace api.customer.Domain.Common;

public class EmailAddress : ValueOf<string, EmailAddress>
{
    private static readonly Regex _emailRegex =
        new("^[\\w!#$%&’*+/=?`{|}~^-]+(?:\\.[\\w!#$%&’*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!_emailRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid email address";

            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(EmailAddress), message)
            });
        }
    }
}