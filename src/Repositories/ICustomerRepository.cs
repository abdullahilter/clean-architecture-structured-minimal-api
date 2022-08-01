using api.customer.Contracts.Data;

namespace api.customer.Repositories;

public interface ICustomerRepository
{
    Task<CustomerDto> CreateAsync(CustomerDto customer);

    Task<CustomerDto?> GetAsync(Guid id);

    Task<IEnumerable<CustomerDto>> GetAllAsync();

    Task<CustomerDto> UpdateAsync(CustomerDto customer);

    Task<bool> DeleteAsync(Guid id);
}