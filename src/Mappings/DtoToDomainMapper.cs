using api.customer.Contracts.Data;
using api.customer.Domain;
using api.customer.Domain.Common;

namespace api.customer.Mappings;

public static class DtoToDomainMapper
{
    public static Customer ToCustomer(this CustomerDto customerDto)
    {
        return new Customer
        {
            Id = CustomerId.From(customerDto.Id),
            EmailAddress = EmailAddress.From(customerDto.EmailAddress),
            Username = Username.From(customerDto.Username),
            FullName = FullName.From(customerDto.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(customerDto.DateOfBirth))
        };
    }
}