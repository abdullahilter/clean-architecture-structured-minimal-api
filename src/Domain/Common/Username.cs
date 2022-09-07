using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace api.customer.Domain.Common;

public class Username : ValueOf<string, Username>
{
    private static readonly int _minLength = 5;
    private static readonly int _maxLength = 250;
    private static readonly Regex _usernameRegex =
        new("^[a-z\\d](?:[a-z\\d]|-(?=[a-z\\d])){0,38}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!_usernameRegex.IsMatch(Value) || Value.Length < _minLength || Value.Length > _maxLength)
        {
            var message = $"{Value} is not a valid username";

            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Username), message)
            });
        }
    }
}