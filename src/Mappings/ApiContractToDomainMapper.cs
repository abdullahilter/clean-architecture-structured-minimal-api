using api.customer.Contracts.Requests;
using api.customer.Domain;
using api.customer.Domain.Common;

namespace api.customer.Mappings;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CreateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(Guid.NewGuid()),
            EmailAddress = EmailAddress.From(request.EmailAddress),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }

    public static Customer ToCustomer(this UpdateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(request.Id),
            EmailAddress = EmailAddress.From(request.EmailAddress),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }
}