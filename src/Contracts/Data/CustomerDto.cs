namespace api.customer.Contracts.Data;

public class CustomerDto
{
    public Guid Id { get; init; } = default!;

    public string Username { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string EmailAddress { get; init; } = default!;

    public DateTime DateOfBirth { get; init; }
}