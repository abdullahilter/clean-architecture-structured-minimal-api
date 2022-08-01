using api.customer.Domain;

namespace api.customer.Services;

public interface ICustomerService
{
    Task<Customer> CreateAsync(Customer customer);

    Task<Customer?> GetAsync(Guid id);

    Task<IEnumerable<Customer>> GetAllAsync();

    Task<Customer> UpdateAsync(Customer customer);

    Task<bool> DeleteAsync(Guid id);
}