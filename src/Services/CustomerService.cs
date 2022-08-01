using api.customer.Domain;
using api.customer.Mappings;
using api.customer.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace api.customer.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        var existingCustomer = await _customerRepository.GetAsync(customer.Id.Value);
        if (existingCustomer is not null)
        {
            var message = $"A customer with id {customer.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Customer), message)
            });
        }

        var customerDto = customer.ToCustomerDto();
        await _customerRepository.CreateAsync(customerDto);
        return customerDto.ToCustomer();
    }

    public async Task<Customer?> GetAsync(Guid id)
    {
        var customerDto = await _customerRepository.GetAsync(id);
        return customerDto?.ToCustomer();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customerDtos = await _customerRepository.GetAllAsync();
        return customerDtos.Select(x => x.ToCustomer());
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        var customerDto = customer.ToCustomerDto();
        await _customerRepository.UpdateAsync(customerDto);
        return customerDto.ToCustomer();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _customerRepository.DeleteAsync(id);
        return result;
    }
}