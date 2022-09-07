using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace api.customer.Domain.Common;

public class FullName : ValueOf<string, FullName>
{
    private static readonly int _minLength = 5;
    private static readonly int _maxLength = 250;
    private static readonly Regex _fullNameRegex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!_fullNameRegex.IsMatch(Value) || Value.Length < _minLength || Value.Length > _maxLength)
        {
            var message = $"{Value} is not a valid full name";

            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(FullName), message)
            });
        }
    }
}