using api.customer.Contracts.Data;
using Microsoft.EntityFrameworkCore;

namespace api.customer.Database;

public class TestContext : DbContext
{
    public TestContext(DbContextOptions<TestContext> options)
       : base(options)
    {
    }

    public virtual DbSet<CustomerDto> Customers { get; set; }
}