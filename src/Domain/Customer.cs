using api.customer.Domain.Common;

namespace api.customer.Domain;

public class Customer
{
    public CustomerId Id { get; init; } = CustomerId.From(Guid.NewGuid());

    public Username Username { get; init; } = default!;

    public FullName FullName { get; init; } = default!;

    public EmailAddress EmailAddress { get; init; } = default!;

    public DateOfBirth DateOfBirth { get; init; } = default!;
}