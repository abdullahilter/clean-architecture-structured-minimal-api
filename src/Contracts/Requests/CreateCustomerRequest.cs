namespace api.customer.Contracts.Requests;

public class CreateCustomerRequest
{
    public string Username { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string EmailAddress { get; init; } = default!;

    public DateTime DateOfBirth { get; init; }
}