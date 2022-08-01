using api.customer.Contracts.Data;
using api.customer.Database;
using Microsoft.EntityFrameworkCore;

namespace api.customer.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly TestContext _context;

    public CustomerRepository(TestContext context)
    {
        _context = context;
    }

    public async Task<CustomerDto> CreateAsync(CustomerDto customer)
    {
        await _context.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<CustomerDto?> GetAsync(Guid id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        return customer;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _context.Customers.ToListAsync();
        return customers;
    }

    public async Task<CustomerDto> UpdateAsync(CustomerDto customer)
    {
        _context.Update(customer);

        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customer = await GetAsync(id);

        _context.Remove(customer!);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}